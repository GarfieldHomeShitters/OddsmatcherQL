using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class Data
    {
        [JsonProperty("getBestMatches", NullValueHandling = NullValueHandling.Ignore)]
        public Match[] Matches { get; set; }
    }
}