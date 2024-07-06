using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class EventGroup : MarketGroup
    {
        [JsonProperty("sourceName", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceName { get; set; }
    }
    
}