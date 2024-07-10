using System.Collections.Generic;
using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class EventsResponse
    {
        [JsonProperty("events")]
        public List<SmarketEvent> Events { get; set; }
    }
}