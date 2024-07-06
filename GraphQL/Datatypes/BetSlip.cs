using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class BetSlip
    {
        [JsonProperty("marketId", NullValueHandling = NullValueHandling.Ignore)]
        public long? MarketId { get; set; }

        [JsonProperty("selectionId", NullValueHandling = NullValueHandling.Ignore)]
        public long? SelectionId { get; set; }
    }
}