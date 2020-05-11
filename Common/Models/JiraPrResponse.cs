namespace Common.Models
{
    using System;
    using System.Collections.Generic;
    using Common.Utils;
    using Newtonsoft.Json;

    public partial class JiraPrResponse
    {
        [JsonProperty("errors")]
        public List<object> Errors { get; set; }

        [JsonProperty("detail")]
        public List<Detail> Detail { get; set; }
    }

    public partial class Detail
    {
        [JsonProperty("branches")]
        public List<object> Branches { get; set; }

        [JsonProperty("pullRequests")]
        public List<PullRequest> PullRequests { get; set; }

        [JsonProperty("repositories")]
        public List<object> Repositories { get; set; }

        [JsonProperty("_instance")]
        public Instance Instance { get; set; }
    }

    public partial class Instance
    {
        [JsonProperty("primary")]
        public bool Primary { get; set; }

        [JsonProperty("baseUrl")]
        public Uri BaseUrl { get; set; }

        [JsonProperty("applicationLinkId")]
        public Guid ApplicationLinkId { get; set; }

        [JsonProperty("singleInstance")]
        public bool SingleInstance { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("typeName")]
        public string TypeName { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class PullRequest
    {
        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("commentCount")]
        public long CommentCount { get; set; }

        [JsonProperty("source")]
        public Destination Source { get; set; }

        [JsonProperty("destination")]
        public Destination Destination { get; set; }

        [JsonProperty("reviewers")]
        public List<Reviewer> Reviewers { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("lastUpdate")]
        public string LastUpdate { get; set; }
    }

    public partial class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public Uri Avatar { get; set; }
    }

    public partial class Destination
    {
        [JsonProperty("branch")]
        public string Branch { get; set; }

        [JsonProperty("repository")]
        public Repository Repository { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Repository
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public Uri Avatar { get; set; }

        [JsonProperty("avatarDescription")]
        public string AvatarDescription { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Reviewer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public Uri Avatar { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }
    }

    public partial class JiraPrResponse
    {
        public static JiraPrResponse FromJson(string json) => JsonConvert.DeserializeObject<JiraPrResponse>(json, Converter.Settings);
    }
}
