namespace Common.Models
{
    using System.Collections.Generic;
    using Common.Utils;
    using Newtonsoft.Json;

    /// <summary>
    /// Get If rebase is needed
    /// </summary>
    public partial class RebaseStatusResponse
    {
        [JsonProperty("canRebase")]
        public bool CanRebase { get; set; }

        [JsonProperty("canWrite")]
        public bool CanWrite { get; set; }

        [JsonProperty("vetoes")]
        public List<object> Vetoes { get; set; }
    }

    public partial class RebaseStatusResponse
    {
        public static RebaseStatusResponse FromJson(string json) => JsonConvert.DeserializeObject<RebaseStatusResponse>(json, Converter.Settings);
    }
}
