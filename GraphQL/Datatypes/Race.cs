using System.Collections.Generic;
using System.Data;

namespace GraphQL.Datatypes
{
    public class Race
    {
        public string EventName;
        public List<Horse> Horses;
        public string MarketID;
        public string EventID;

        public Race(string eventName, string eventId)
        {
            EventName = eventName;
            EventID = eventId;
            Horses = new List<Horse>();
        }

        public void addHorses(List<GetBestMatch> _horses)
        {
            foreach (GetBestMatch _horse in _horses)
            {
                Horse horse = new Horse(_horse.MarketName, decimal.Parse(_horse.Back.Odds), decimal.Parse(_horse.Lay.Odds));
                Horses.Add(horse);
            }
        }

        public void assignMarketID(SmarketMarket market)
        {
            MarketID = market.id;
        }
        
        public override string ToString()
        {
            return EventName;
        }
    }
}