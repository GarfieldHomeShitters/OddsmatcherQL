using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class BidOffer
    {
        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}