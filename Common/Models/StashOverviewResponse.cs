namespace Common.Models
{
    using Common.Utils;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public partial class StashOverviewResponse
    {
        [JsonProperty("enabled")]
        public List<bool> Enabled { get; set; }

        [JsonProperty("userHasWrite")]
        public bool UserHasWrite { get; set; }

        [JsonProperty("commitCount")]
        public string CommitCount { get; set; }

        [JsonProperty("fromBranch")]
        public string FromBranch { get; set; }

        [JsonProperty("toBranch")]
        public string ToBranch { get; set; }

        [JsonProperty("tipMsg")]
        public string TipMsg { get; set; }

        [JsonProperty("isSquashed")]
        public bool IsSquashed { get; set; }

        [JsonProperty("isRebased")]
        public bool IsRebased { get; set; }

        [JsonProperty("isConflicted")]
        public bool IsConflicted { get; set; }

        [JsonProperty("blockMsg")]
        public string BlockMsg { get; set; }

        [JsonProperty("authors")]
        public List<string> Authors { get; set; }

        [JsonProperty("defaultAuthor")]
        public string DefaultAuthor { get; set; }

        [JsonProperty("amendAuthor")]
        public string AmendAuthor { get; set; }

        [JsonProperty("squashMsg")]
        public string SquashMsg { get; set; }

        [JsonProperty("eof")]
        public string Eof { get; set; }
    }

    public partial class StashOverviewResponse
    {
        public static StashOverviewResponse FromJson(string json) => JsonConvert.DeserializeObject<StashOverviewResponse>(json, Converter.Settings);
    }
}
