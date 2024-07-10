using System.Collections.Generic;
using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class QuoteResponse
    {
        [JsonProperty("bids")]
        public List<BidOffer> Bids { get; set; }

        [JsonProperty("offers")]
        public List<BidOffer> Offers { get; set; }
    }
}