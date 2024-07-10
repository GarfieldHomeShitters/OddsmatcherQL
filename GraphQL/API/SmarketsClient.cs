using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using GraphQL.Datatypes;
using RestSharp;

namespace GraphQL.API
{
    public class SmarketsClient
    {
        private RestClient _Client = new RestClient("https://api.smarkets.com/v3/");

        public SmarketsClient()
        {
            
        }
        
        /// <summary>
        /// Gets all horse racing events and returns event name and ID
        /// </summary>
        /// <returns>List<list type="(string, int)"></list></returns>
        private async Task<List<SmarketEvent>> GetAllHorseRaces()
        {
            DateTime startDateTimeMin = DateTime.UtcNow.Date;
            string formattedDateTime = startDateTimeMin.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string urlSafeTime = Uri.EscapeUriString(formattedDateTime);
            string endpoint = $"/events/?state=upcoming&type_domain=horse_racing&type_scope=single_event&with_new_type=true&start_datetime_min={urlSafeTime}&sort=id&limit=200&include_hidden=false";
            RestRequest eventRequest = new RestRequest(endpoint);
            EventsResponse response = await _Client.GetAsync<EventsResponse>(eventRequest);
            return response.Events;
        }

        private async Task<List<SmarketMarket>> GetPlaceMarkets(List<SmarketEvent> smarketEvents)
        {
            List<int> eventIdToFetch = new List<int>();
            foreach (SmarketEvent @event in smarketEvents)
            {
                eventIdToFetch.Add(int.Parse(@event.id));
            }

            string endpoint = $"events/{string.Join(",", eventIdToFetch)}/markets/?sort=event_id%2Cdisplay_order&popular=false&include_hidden=false";
            RestRequest marketRequest = new RestRequest(endpoint);
            MarketsResponse response = await _Client.GetAsync<MarketsResponse>(marketRequest);
            return new List<SmarketMarket>(response.markets.Where(x => x.slug == "to-place-3"));
        }

        public List<(string, int)> GetAllHorseRacePlaceMarkets()
        {
            return new List<(string, int)>();
        }
        
        public List<(int, int)> getContracts(SmarketMarket market)
        {
            return new List<(int, int)>();
        }
    }
}