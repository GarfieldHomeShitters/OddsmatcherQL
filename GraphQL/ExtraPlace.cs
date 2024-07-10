using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<Race> ExtraPlaceRaces; 

        public ExtraPlace(APIService apiService)
        {
            InitializeComponent();

            _smarketsClient = new SmarketsClient();
            _raceFinder = new EPRaceFinder();
            _apiService = apiService; // Just reuse the API from Oddsmatcher Form.
        }

        public async void refreshExtraPlaceRaces()
        {
            // All EP Race times as strings ["14:55 Lingfield", "15:55 Lingfield", "16:45 Pontefract", "17:10 Tramore", "17:17 Pontefract", "17:30 Lingfield", "18:05 Uttoxeter", "18:35 Uttoxeter", "18:55 Brighton", "19:05 Uttoxeter", "19:35 Uttoxeter", "20:20 Tramore"]
            List<string> _epRaces = await _raceFinder.GetRaceTimesAsync();
            // ALL [HORSES] FOR ALL THE RACES + ODDS
            List<GetBestMatch> allRaces = await _apiService.getAllRaceData(SelectedBookmakers);
            // ALL HORSES THAT ARE RACING IN THE EP RACES
            List<GetBestMatch> epRaceMatches = allRaces.Where(x => _epRaces.Contains(x.EventName)).ToList();
            // ALL EVENT ID AND MARKET
            List<(string, int)> smarketMarkets = _smarketsClient.GetAllHorseRacePlaceMarkets();
            foreach (string eventName in _epRaces)
            {
                ExtraPlaceRaces.Add(new Race(eventName, 0));
            }
        }
    }
}