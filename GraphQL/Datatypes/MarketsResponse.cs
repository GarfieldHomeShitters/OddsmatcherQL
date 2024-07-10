using System.Collections.Generic;
using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class MarketsResponse
    {
        [JsonProperty("markets", NullValueHandling = NullValueHandling.Ignore)]
        public List<SmarketMarket> markets;
    }
}