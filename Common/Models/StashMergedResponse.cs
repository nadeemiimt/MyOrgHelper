namespace Common.Models
{
    using Common.Utils;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Stash merge post response.
    /// </summary>
    public partial class StashMergedResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("open")]
        public bool Open { get; set; }

        [JsonProperty("closed")]
        public bool Closed { get; set; }

        [JsonProperty("createdDate")]
        public long CreatedDate { get; set; }

        [JsonProperty("updatedDate")]
        public long UpdatedDate { get; set; }

        [JsonProperty("closedDate")]
        public long ClosedDate { get; set; }

        [JsonProperty("fromRef")]
        public Ref FromRef { get; set; }

        [JsonProperty("toRef")]
        public Ref ToRef { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("reviewers")]
        public List<Author> Reviewers { get; set; }

        [JsonProperty("participants")]
        public List<Author> Participants { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("self")]
        public List<Self> Self { get; set; }
    }

    public partial class StashMergedResponse
    {
        public static StashMergedResponse FromJson(string json) => JsonConvert.DeserializeObject<StashMergedResponse>(json, Converter.Settings);
    }
}
