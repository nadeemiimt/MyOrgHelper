namespace Common.Models
{
    using Common.Utils;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Stash merge get response.
    /// </summary>
    public partial class StashMergeStatusResponse
    {
        [JsonProperty("canMerge")]
        public bool CanMerge { get; set; }

        [JsonProperty("conflicted")]
        public bool Conflicted { get; set; }

        [JsonProperty("outcome")]
        public string Outcome { get; set; }

        [JsonProperty("vetoes")]
        public List<Vetoe> Vetoes { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }

    public partial class Error
    {
        [JsonProperty("context")]
        public object Context { get; set; }

        [JsonProperty("exceptionName")]
        public string ExceptionName { get; set; }
    }

    public partial class Vetoe
    {
        [JsonProperty("summaryMessage")]
        public SummaryMessage SummaryMessage { get; set; }

        [JsonProperty("detailedMessage")]
        public string DetailedMessage { get; set; }
    }

    public partial class StashMergeStatusResponse
    {
        public static StashMergeStatusResponse FromJson(string json) => JsonConvert.DeserializeObject<StashMergeStatusResponse>(json, Converter.Settings);       
    }  
}
