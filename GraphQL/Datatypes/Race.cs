using System.Collections.Generic;
using System.Data;

namespace GraphQL.Datatypes
{
    public class Race
    {
        public string EventName;
        public List<Horse> Horses;
        public Dictionary<int, string> MarketIDs;
        public string EventID;
        public string link;

        public Race(string eventName, string eventId)
        {
            EventName = eventName;
            EventID = eventId;
            Horses = new List<Horse>();
            MarketIDs = new Dictionary<int, string>();
            link = $"https://smarkets.com/event/{eventId}";
        }

        public void addHorses(List<GetBestMatch> _horses)
        {
            foreach (GetBestMatch _horse in _horses)
            {
                Horse horse = new Horse(_horse.SelectionId, decimal.Parse(_horse.Back.Odds), decimal.Parse(_horse.Lay.Odds));
                horse.DisplayName = _horse.SelectionName;
                Horses.Add(horse);
            }
        }

        private void assignMarketID(int places, SmarketMarket market)
        {
            MarketIDs.Add(places, market.id);
        }

        public void assignMarketIDs(List<SmarketMarket> markets)
        {
            // Shouldn't be an issue but just make sure that all the entries are clear.
            MarketIDs.Clear();
            foreach (var market in markets) assignMarketID(market.winner_count, market);
        }
        
        public override string ToString()
        {
            return EventName;
        }
    }
}