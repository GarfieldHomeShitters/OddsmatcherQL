using System;
using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class Match
    {
        [JsonProperty("eventName", NullValueHandling = NullValueHandling.Ignore)]
        public string EventName { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("startAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StartAt { get; set; }

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
        public SportClass Sport { get; set; }
    }
}