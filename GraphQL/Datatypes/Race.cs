using System.Collections.Generic;
using System.Data;

namespace GraphQL.Datatypes
{
    public class Race
    {
        public string EventName;
        public List<Horse> Horses;
        public int MarketID;
        public List<int> ContractID;

        public Race(string eventName, int marketId)
        {
            EventName = eventName;
            MarketID = marketId;
            Horses = new List<Horse>();
        }

        public void addHorse(Horse horse)
        {
            Horses.Add(horse);
        }
    }
}