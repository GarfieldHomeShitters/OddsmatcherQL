using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class MarketGroup
    {
        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("sport", NullValueHandling = NullValueHandling.Ignore)]
        public SportEnum? Sport { get; set; }
    }
    public enum SportEnum { Horseracing, Horses, Soccer };
}