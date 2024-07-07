using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GraphQL.Datatypes
{
    public partial class ReturnData
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("getBestMatches", NullValueHandling = NullValueHandling.Ignore)]
        public GetBestMatch[] GetBestMatches { get; set; }
    }

    public class GetBestMatch
    {
        [JsonProperty("eventName", NullValueHandling = NullValueHandling.Ignore)]
        public string EventName { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("startAt", NullValueHandling = NullValueHandling.Ignore)]
        public string StartAt { get; set; }

        [JsonProperty("selectionId", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectionId { get; set; }

        [JsonProperty("marketId", NullValueHandling = NullValueHandling.Ignore)]
        public string MarketId { get; set; }

        [JsonProperty("eventId", NullValueHandling = NullValueHandling.Ignore)]
        public string EventId { get; set; }

        [JsonProperty("back", NullValueHandling = NullValueHandling.Ignore)]
        public Back Back { get; set; }

        [JsonProperty("lay", NullValueHandling = NullValueHandling.Ignore)]
        public Lay Lay { get; set; }

        [JsonProperty("eventGroup", NullValueHandling = NullValueHandling.Ignore)]
        public EventGroup EventGroup { get; set; }

        [JsonProperty("marketGroup", NullValueHandling = NullValueHandling.Ignore)]
        public MarketGroup MarketGroup { get; set; }

        [JsonProperty("marketName", NullValueHandling = NullValueHandling.Ignore)]
        public string MarketName { get; set; }

        [JsonProperty("rating", NullValueHandling = NullValueHandling.Ignore)]
        public string Rating { get; set; }

        [JsonProperty("selectionName", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectionName { get; set; }

        [JsonProperty("snr", NullValueHandling = NullValueHandling.Ignore)]
        public string Snr { get; set; }

        [JsonProperty("sport", NullValueHandling = NullValueHandling.Ignore)]
        public Sport Sport { get; set; }
    }

    public class Back
    {
        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; set; }

        [JsonProperty("odds", NullValueHandling = NullValueHandling.Ignore)]
        public string Odds { get; set; }

        [JsonProperty("fetchedAt", NullValueHandling = NullValueHandling.Ignore)]
        public string FetchedAt { get; set; }

        [JsonProperty("deepLink", NullValueHandling = NullValueHandling.Ignore)]
        public string DeepLink { get; set; }

        [JsonProperty("bookmaker", NullValueHandling = NullValueHandling.Ignore)]
        public Bookmaker Bookmaker { get; set; }
    }

    public class Bookmaker
    {
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Active { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("logo")] public object Logo { get; set; }
    }

    public class EventGroup
    {
        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("sourceName", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceName { get; set; }

        [JsonProperty("sport", NullValueHandling = NullValueHandling.Ignore)]
        public string Sport { get; set; }
    }

    public class Lay
    {
        [JsonProperty("bookmaker", NullValueHandling = NullValueHandling.Ignore)]
        public Bookmaker Bookmaker { get; set; }

        [JsonProperty("deepLink", NullValueHandling = NullValueHandling.Ignore)]
        public string DeepLink { get; set; }

        [JsonProperty("fetchedAt", NullValueHandling = NullValueHandling.Ignore)]
        public string FetchedAt { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; set; }

        [JsonProperty("odds", NullValueHandling = NullValueHandling.Ignore)]
        public string Odds { get; set; }

        [JsonProperty("liquidity", NullValueHandling = NullValueHandling.Ignore)]
        public string Liquidity { get; set; }

        [JsonProperty("betSlip")] public BetSlip BetSlip { get; set; }
    }

    public class BetSlip
    {
        [JsonProperty("marketId", NullValueHandling = NullValueHandling.Ignore)]
        public string MarketId { get; set; }

        [JsonProperty("selectionId", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectionId { get; set; }
    }

    public class MarketGroup
    {
        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("sport", NullValueHandling = NullValueHandling.Ignore)]
        public string Sport { get; set; }
    }

    public class Sport
    {
        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }

    public partial class ReturnData
    {
        public static ReturnData FromJson(string json) => JsonConvert.DeserializeObject<ReturnData>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ReturnData self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}