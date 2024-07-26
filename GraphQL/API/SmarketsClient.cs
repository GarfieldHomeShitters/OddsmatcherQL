using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Datatypes;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;


namespace GraphQL.API
{
    public class SmarketsClient
    {
        private RestClient _Client = new RestClient("https://api.smarkets.com/v3/", configureSerialization: s => s.UseNewtonsoftJson());

        public SmarketsClient()
        {

        }
        
        /// <summary>
        /// Gets all horse racing events and returns event name and ID
        /// </summary>
        /// <returns>List<list type="(string, int)"></list></returns>
        public async Task<List<SmarketEvent>> GetAllHorseRaces()
        {
            DateTime startDateTimeMin = DateTime.Now.Date;
            string startDateTimeMax = Uri.EscapeUriString(DateTime.Now.Date.AddDays(1).AddMilliseconds(-1).ToString("yyyy-MM-ddTHH:mm:ssZ"));
            string formattedDateTime = startDateTimeMin.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string urlSafeTime = Uri.EscapeUriString(formattedDateTime);
            string endpoint = $"/events/?state=upcoming&type_domain=horse_racing&type_scope=single_event&with_new_type=true&start_datetime_min={urlSafeTime}&start_datetime_max={startDateTimeMax}&sort=id&limit=200&include_hidden=false";
            RestRequest eventRequest = new RestRequest(endpoint);
            EventsResponse response = await _Client.GetAsync<EventsResponse>(eventRequest);
            return response.Events;
        }

        public async Task<List<SmarketMarket>> GetPlaceMarkets(List<SmarketEvent> smarketEvents)
        {
            List<int> eventIdToFetch = new List<int>();
            foreach (SmarketEvent @event in smarketEvents)
            {
                eventIdToFetch.Add(int.Parse(@event.id));
            }

            string endpoint = $"events/{string.Join(",", eventIdToFetch)}/markets/?sort=event_id%2Cdisplay_order&popular=false&include_hidden=false";
            RestRequest marketRequest = new RestRequest(endpoint);
            MarketsResponse response = await _Client.GetAsync<MarketsResponse>(marketRequest);

            List<SmarketMarket> markets = response.markets.Any() ? new List<SmarketMarket>(response.markets.Where(x => x.slug.Contains("to-place"))) : null;

            return markets;
        }

        public async Task<List<SmarketContract>> GetContracts(List<Race> races)
        {
            // TODO: UPDATE TO GET ALL PLACE MARKETS AND CONTRACTS FOR THESE - ASSOCIATE WITH DICTIONARY IN HORSE.
            List<string> marketIdToFetch = new List<string>();
            foreach (Race race in races)
            {
                marketIdToFetch.AddRange(race.MarketIDs.Values);
            }
            
            //IEnumerable<string> MarketIds = System.Linq.Chunk()
            string endpoint = $"markets/{string.Join(",", marketIdToFetch)}/contracts/?include_hidden=false";
            ContractResponse response = await _Client.GetAsync<ContractResponse>(endpoint);
            List<SmarketContract> contracts = new List<SmarketContract>(response.contracts);
            return contracts;
        }

        public async Task<Dictionary<string,QuoteResponse>> GetQuotes(Race race, int places)
        {
            string endpoint = $"markets/{race.MarketIDs[places]}/quotes/";
            return await _Client.GetAsync<Dictionary<string, QuoteResponse>>(endpoint);
        }
        
    }
}