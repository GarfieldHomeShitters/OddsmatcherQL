using System;
using System.Collections.Generic;

namespace GraphQL.Datatypes
{
    public class Horse
    {
        public string DisplayName;
        public string Name;
        public decimal backOdds;
        public decimal layOdds;
        public decimal backPlaceOdds;
        public decimal layPlaceOdds;
        public Dictionary<string, string> contractIDs;
        public Horse(string Name, decimal backOdds, decimal layOdds)
        {
            this.Name = Name;
            this.backOdds = backOdds;
            this.layOdds = layOdds;
            contractIDs = new Dictionary<string, string>();
            backPlaceOdds = ((this.backOdds - 1) / 5) + 1;
        }

        public void addSmarketInfo(int percentagePrice =88888 )
        {
            // Looks weird, but we have to cast one to a decimal to get out a decimal from the division
            // Decimal over float so that we have increased precision, not really needed because we round 
            // but the standard throughout the API has always been to use a decimal. 
            layPlaceOdds = Math.Round( ((decimal)10000 / percentagePrice) , 2);
        }
    }
}