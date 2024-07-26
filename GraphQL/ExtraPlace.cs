using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.API;
using GraphQL.Datatypes;
using Syncfusion.DataSource.Extensions;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;

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

        private void EpDatagridOnQueryRowStyle(object sender, QueryRowStyleEventArgs e)
        {
            if (e.RowType == RowType.DefaultRow)
            {
                if ((e.RowData as HorseExtraPlace).rating >= 95)
                    e.Style.BackColor = Color.PowderBlue;
                else if ((e.RowData as HorseExtraPlace).rating >= 90)
                    e.Style.BackColor = Color.DarkOrange;
                else if ((e.RowData as HorseExtraPlace).rating >= 85)
                    e.Style.BackColor = Color.PaleVioletRed;
            }
        }

        public async Task initExtraPlaceRaces()
        {
            ExtraPlaceRaces.Clear();
            SelectedBookmakers = new[] { bookmakerCombo.SelectedItem.ToString() };
            // All EP Race times as strings ["14:55 Lingfield", "15:55 Lingfield", "16:45 Pontefract", "17:10 Tramore", "17:17 Pontefract", "17:30 Lingfield", "18:05 Uttoxeter", "18:35 Uttoxeter", "18:55 Brighton", "19:05 Uttoxeter", "19:35 Uttoxeter", "20:20 Tramore"]
            Task<List<string>> _epRacesTask = _raceFinder.GetRaceTimesAsync();
            // ALL [HORSES] FOR ALL THE RACES + ODDS
            Task<List<GetBestMatch>> allRacesTask = _apiService.getAllRaceData(SelectedBookmakers);
            // ALL EVENTS
            Task<List<SmarketEvent>> allEventsTask = _smarketsClient.GetAllHorseRaces();
            try
            {
                await Task.WhenAll(_epRacesTask, allRacesTask, allEventsTask);
            }
            catch (Exception ex)
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
                try
                {
                    string eventName = @event.short_name.Replace("@ ", "");
                    Race _race = new Race(eventName, @event.id);
                    _race.addHorses(epRaceMatches.Where(x => x.EventName == eventName).ToList());
                    var marketID = placeMarkets.Where(x => x.event_id == _race.EventID);
                    if (marketID != null)
                    {
                        // ASSIGN ALL PLACE MARKET IDs AT ONCE AND FILTER TO A DICTIONARY.
                        _race.assignMarketIDs(marketID.ToList());
                        ExtraPlaceRaces.Add(_race);
                    }
                    else
                    {
                        MessageBox.Show(eventName);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(@event.short_name, e.GetType().Name);
                }
            }
            
            List<SmarketContract> contracts = await _smarketsClient.GetContracts(ExtraPlaceRaces);
            // vvvvvvv Not necessarily needed but will ensure that there is less performance hit. vvvvvvv
            // TODO: USE DICTIONARY KEY AS SLUG? -> SLUG IS HORSE NAME BUT MULTIPLE PLACE MARKETS -> SAME KEY -> LIST OF CONTRACTS???
            // Dictionary<string, List<string>> _contractDictionary = new Dictionary<string, List<string>>();
            foreach (Race race in ExtraPlaceRaces)
            {
                foreach (Horse horse in race.Horses)
                {
                    List<SmarketContract> _contracts = contracts.Where(x => x.name.Replace(" ", "-").Replace("'", "").ToLower() == horse.Name).ToList();
                    foreach (var contract in _contracts)
                    {
                        horse.contractIDs.Add(contract.market_id, contract.id);
                    }
                }
            }
        }

        private async void loadRacesButton_Click(object sender, EventArgs e)
        {
            await initExtraPlaceRaces();
            ExtraPlaceRaces.Sort((p1, p2) =>p1.EventName.CompareTo(p2.EventName));
            epRaceCombo.DataSource = ExtraPlaceRaces;
            epRaceCombo.DisplayMember = "EventName";
            epRaceCombo.Refresh();
        }

        private async void loadDataBtn_Click(object sender, EventArgs e)
        {
            Race raceToLoad = epRaceCombo.SelectedItem as Race;
            await UpdateData(raceToLoad);
        }

        private async Task UpdateData(Race race)
        {
            epDatagrid.DataSource = null;
            epDatagrid.Refresh();
            epDatagrid.SortColumnDescriptions.Clear();
            Task<List<GetBestMatch>> getAllHorses = _apiService.getAllRaceData(SelectedBookmakers);
            int places = int.Parse(placesCombobox.SelectedItem.ToString());
            Task<Dictionary<string, QuoteResponse>> getQuotes = _smarketsClient.GetQuotes(race, places);
            await Task.WhenAll(getAllHorses, getQuotes);

            List<GetBestMatch> allHorses = getAllHorses.Result;
            Dictionary<string, QuoteResponse> quotes = getQuotes.Result;
            horseExtra.Clear();
            foreach (Horse horse in race.Horses)
            {
                QuoteResponse horseQuotes = null;
                string contractID = horse.contractIDs[race.MarketIDs[places]];
                bool shouldContinue = horse.contractIDs != null && quotes.TryGetValue(contractID, out horseQuotes); 

                GetBestMatch matchingHorse = allHorses.Find(x => x.SelectionId == horse.Name);
                if (matchingHorse != null)
                {
                    horse.backOdds = decimal.Parse(matchingHorse.Back.Odds);
                    horse.layOdds = decimal.Parse(matchingHorse.Lay.Odds);
                    horse.backPlaceOdds = ((horse.backOdds - 1) / 5) + 1;
                }

                if (shouldContinue && horseQuotes.Bids != null && horseQuotes.Bids.Any()) 
                {
                    horse.addSmarketInfo(horseQuotes.Bids.OrderByDescending(bid => bid.Price).First().Price);
                } else
                {
                    horse.addSmarketInfo(1);
                }
                horseExtra.Add(new HorseExtraPlace(horse, stakeNumeric.Value));
            }

            foreach (HorseExtraPlace horse in horseExtra)
            {
                horse.calculateProfitLoss();
            }
            
            epDatagrid.DataSource = horseExtra;
            epDatagrid.QueryRowStyle += EpDatagridOnQueryRowStyle;
            epDatagrid.SortColumnDescriptions.Add(new SortColumnDescription {ColumnName = "rating", SortDirection = ListSortDirection.Descending});
        }

        private void ExtraPlace_Load(object sender, EventArgs e)
        {
            bookmakerCombo.DataSource = Bookmakers;
        }

        private void smarketBtn_Click(object sender, EventArgs e)
        {
            Process.Start((epRaceCombo.SelectedItem as Race).link);
        }

        private void epRaceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            placesCombobox.DataSource = null;
            placesCombobox.Refresh();
            placesCombobox.DataSource = (epRaceCombo.SelectedItem as Race).MarketIDs.Keys;
            placesCombobox.Refresh();
        }
    }
}