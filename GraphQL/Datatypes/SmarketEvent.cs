using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class SmarketEvent
    {
        [JsonProperty("full_slug", NullValueHandling = NullValueHandling.Ignore)]
        public string full_slug;
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string id;
        [JsonProperty("short_name", NullValueHandling = NullValueHandling.Ignore)]
        public string short_name;
        [JsonProperty("start_datetime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? start_datetime;
    }
}