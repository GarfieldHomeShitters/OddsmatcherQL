using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class SmarketMarket
    {
        [JsonProperty("event_id", NullValueHandling = NullValueHandling.Ignore)]
        public string event_id;

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string id;
        
        [JsonProperty("market_type", NullValueHandling = NullValueHandling.Ignore)]
        public MarketType market_type;
        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string slug;
        
        [JsonProperty("winner_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? winner_count;
    }
    
    public class MarketType
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name;

        [JsonProperty("param", NullValueHandling = NullValueHandling.Ignore)]
        public string param;
    }
}