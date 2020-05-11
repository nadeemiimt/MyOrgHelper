using Common.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public partial class JiraStatusRequest
    {
        [JsonProperty("update")]
        public Update Update { get; set; }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }

        [JsonProperty("transition")]
        public Transition Transition { get; set; }

        [JsonProperty("historyMetadata")]
        public HistoryMetadata HistoryMetadata { get; set; }
    }

    public partial class Fields
    {
        [JsonProperty("assignee")]
        public Assignee Assignee { get; set; }

        [JsonProperty("resolution")]
        public Assignee Resolution { get; set; }
    }

    public partial class HistoryMetadata
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("descriptionKey")]
        public string DescriptionKey { get; set; }

        [JsonProperty("activityDescription")]
        public string ActivityDescription { get; set; }

        [JsonProperty("activityDescriptionKey")]
        public string ActivityDescriptionKey { get; set; }

        [JsonProperty("actor")]
        public Actor Actor { get; set; }

        [JsonProperty("generator")]
        public Cause Generator { get; set; }

        [JsonProperty("cause")]
        public Cause Cause { get; set; }

        [JsonProperty("extraData")]
        public ExtraData ExtraData { get; set; }
    }

    public partial class Actor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("avatarUrl")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Cause
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class ExtraData
    {
        [JsonProperty("keyvalue")]
        public string Keyvalue { get; set; }

        [JsonProperty("goes")]
        public string Goes { get; set; }
    }

    public partial class Transition
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }
    }

    public partial class Update
    {
        [JsonProperty("comment")]
        public List<Comment> Comment { get; set; }
    }

    public partial class Comment
    {
        [JsonProperty("add")]
        public Add Add { get; set; }
    }

    public partial class Add
    {
        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public partial class JiraStatusRequest
    {
        public static JiraStatusRequest FromJson(string json) => JsonConvert.DeserializeObject<JiraStatusRequest>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this JiraStatusRequest self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
