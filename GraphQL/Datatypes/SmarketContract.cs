using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class SmarketContract
    {
        [JsonProperty("id")]
        public string id;

        [JsonProperty("market_id")]
        public string market_id;

        [JsonProperty("slug")]
        public string slug;

        [JsonProperty("state_or_outcome")]
        public string state_or_outcome;

        [JsonProperty("name")] 
        public string name;
    }
}