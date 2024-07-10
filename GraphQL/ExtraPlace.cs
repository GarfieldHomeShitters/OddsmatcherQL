using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Compilation;
using GraphQL.API;
using GraphQL.Datatypes;

namespace GraphQL
{
    public partial class ExtraPlace : Form
    {
        private readonly EPRaceFinder _raceFinder;
        private readonly APIService _apiService;
        private readonly SmarketsClient _smarketsClient;
        private string[] SelectedBookmakers;
        private List<Race> ExtraPlaceRaces = new List<Race>();
        private string[] Bookmakers;
        private List<HorseExtraPlace> horseExtra = new List<HorseExtraPlace>();

        public ExtraPlace(APIService apiService)
        {
            InitializeComponent();
            Bookmakers = File.ReadAllLines("X:\\Projects\\MatchedBetting\\GraphQL\\GraphQL\\Default\\extraPlaceBookmakers.txt");
            _smarketsClient = new SmarketsClient();
            _raceFinder = new EPRaceFinder();
            _apiService = apiService; // Just reuse the API from Oddsmatcher Form.
        }

        public async Task initExtraPlaceRaces()
        {
            ExtraPlaceRaces.Clear();
            SelectedBookmakers = new []{bookmakerCombo.SelectedItem.ToString()};
            // All EP Race times as strings ["14:55 Lingfield", "15:55 Lingfield", "16:45 Pontefract", "17:10 Tramore", "17:17 Pontefract", "17:30 Lingfield", "18:05 Uttoxeter", "18:35 Uttoxeter", "18:55 Brighton", "19:05 Uttoxeter", "19:35 Uttoxeter", "20:20 Tramore"]
            Task<List<string>> _epRacesTask = _raceFinder.GetRaceTimesAsync();
            // ALL [HORSES] FOR ALL THE RACES + ODDS
            Task<List<GetBestMatch>> allRacesTask = _apiService.getAllRaceData(SelectedBookmakers);
            // ALL EVENTS
            Task<List<SmarketEvent>> allEventsTask =  _smarketsClient.GetAllHorseRaces();
            try
            {
                await Task.WhenAll(_epRacesTask, allRacesTask, allEventsTask);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            List<string> _epRaces = _epRacesTask.Result;
            List<GetBestMatch> allRaces = allRacesTask.Result;
            List<SmarketEvent> allEvents = allEventsTask.Result;
            // ALL EP EVENTS
            List<SmarketEvent> extraPlaceEvents = allEvents.Where(x => _epRaces.Contains(x.short_name.Replace("@ ", ""))).ToList();
            // ALL HORSES THAT ARE RACING IN THE EP RACES
            List<GetBestMatch> epRaceMatches = allRaces.Where(x => _epRaces.Contains(x.EventName)).ToList();
            // ALL EVENT ID AND MARKET
            List<SmarketMarket> placeMarkets = await _smarketsClient.GetPlaceMarkets(extraPlaceEvents);
            //List<(string, int)> smarketMarkets = _smarketsClient.GetAllHorseRacePlaceMarkets();
            foreach (SmarketEvent @event in extraPlaceEvents)
            {
                string eventName = @event.short_name.Replace("@ ", "");
                Race _race = new Race(eventName, @event.id);
                _race.addHorses(epRaceMatches.Where(x => x.EventName == eventName).ToList());
                _race.assignMarketID(placeMarkets.First(x => x.event_id == _race.EventID));
                ExtraPlaceRaces.Add(_race);
            }

            List<SmarketContract> contracts = await _smarketsClient.GetContracts(ExtraPlaceRaces);
            var contractDictionary = contracts.ToDictionary(contract => contract.slug, contract => contract.id);
            foreach (Race race in ExtraPlaceRaces)
            {
                foreach (Horse horse in race.Horses)
                {
                    if (contractDictionary.TryGetValue(horse.Name, out var contractId))
                    {
                        horse.contractID = contractId;
                    }
                }
            }
        }

        private async void loadRacesButton_Click(object sender, EventArgs e)
        {
            await initExtraPlaceRaces();
            epRaceCombo.DataSource = ExtraPlaceRaces;
            epRaceCombo.DisplayMember = "EventName";
            epRaceCombo.Refresh();
        }

        private void loadDataBtn_Click(object sender, EventArgs e)
        {
            Race raceToLoad = epRaceCombo.SelectedItem as Race;
            UpdateData(raceToLoad);
        }

        private async void UpdateData(Race race)
        {
            epDatagrid.DataSource = null;
            epDatagrid.Refresh();
            Task<List<GetBestMatch>> getAllHorses = _apiService.getAllRaceData(SelectedBookmakers);
            Task<Dictionary<string, QuoteResponse>> getQuotes = _smarketsClient.GetQuotes(race);
            await Task.WhenAll(getAllHorses, getQuotes);

            List<GetBestMatch> allHorses = getAllHorses.Result;
            Dictionary<string, QuoteResponse> quotes = getQuotes.Result;
            horseExtra.Clear();
            foreach (Horse horse in race.Horses)
            {
                QuoteResponse horseQuotes = quotes[horse.contractID];
                GetBestMatch matchingHorse = allHorses.Find(x => x.MarketName == horse.Name);
                horse.backOdds = decimal.Parse(matchingHorse.Back.Odds);
                horse.layOdds = decimal.Parse(matchingHorse.Lay.Odds);
                if (horseQuotes.Bids != null && horseQuotes.Bids.Any())
                {
                    horse.addSmarketInfo(horseQuotes.Bids.OrderBy(bid => bid.Price).First().Price);
                }
                horseExtra.Add(new HorseExtraPlace(horse, stakeNumeric.Value));
            }

            epDatagrid.DataSource = horseExtra;
            epDatagrid.Refresh();

        }

        private void ExtraPlace_Load(object sender, EventArgs e)
        {
            bookmakerCombo.DataSource = Bookmakers;
        }
    }
}