using Newtonsoft.Json;

namespace GraphQL.Datatypes
{
    public class SportClass
    {
        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public DisplayName? DisplayName { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public SportEnum? Id { get; set; }
    }
    
    public enum DisplayName { Football, HorseRacing };
}