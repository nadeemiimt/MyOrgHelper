namespace Common.Models
{
    using System.Collections.Generic;
    using Common.Utils;
    using Newtonsoft.Json;

    public partial class StashRebaseResponse
    {
        [JsonProperty("refChange")]
        public RefChange RefChange { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }

    public partial class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class RefChange
    {
        [JsonProperty("ref")]
        public Ref Ref { get; set; }

        [JsonProperty("refId")]
        public string RefId { get; set; }

        [JsonProperty("fromHash")]
        public string FromHash { get; set; }

        [JsonProperty("toHash")]
        public string ToHash { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class StashRebaseResponse
    {
        public static StashRebaseResponse FromJson(string json) => JsonConvert.DeserializeObject<StashRebaseResponse>(json, Converter.Settings);
    }
}
