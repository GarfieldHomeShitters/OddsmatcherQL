using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public enum Active { AccaCatcher, BalanceChecker, BalanceTracker, Epm, LuckyFinder, NewPa, OddsMatch, OddsMatchUi, OutPlayed, ProfitTracker };
    public class Bookmaker
    {
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public Active[] Active { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("logo")]
        public object Logo { get; set; }
    }
}