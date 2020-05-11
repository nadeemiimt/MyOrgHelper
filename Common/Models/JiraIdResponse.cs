namespace Common.Models
{
    using System;
    using Common.Utils;
    using Newtonsoft.Json;

    public partial class JiraIdResponse
    {
        [JsonProperty("expand")]
        public string Expand { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }

    public partial class JiraIdResponse
    {
        public static JiraIdResponse FromJson(string json) => JsonConvert.DeserializeObject<JiraIdResponse>(json, Converter.Settings);
    }
}
