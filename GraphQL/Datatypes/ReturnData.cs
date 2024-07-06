using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class ReturnData
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Data Data { get; set; }
    }
}