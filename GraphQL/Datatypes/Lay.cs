using System;
using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class Lay
    {
        [JsonProperty("bookmaker", NullValueHandling = NullValueHandling.Ignore)]
        public Bookmaker Bookmaker { get; set; }

        [JsonProperty("deepLink", NullValueHandling = NullValueHandling.Ignore)]
        public string DeepLink { get; set; }

        [JsonProperty("fetchedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? FetchedAt { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("odds", NullValueHandling = NullValueHandling.Ignore)]
        public string Odds { get; set; }

        [JsonProperty("liquidity", NullValueHandling = NullValueHandling.Ignore)]
        public string Liquidity { get; set; }

        [JsonProperty("betSlip", NullValueHandling = NullValueHandling.Ignore)]
        public BetSlip BetSlip { get; set; }
    }
}