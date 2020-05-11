namespace Common.Models
{
    using System;
    using Common.Utils;
    using Newtonsoft.Json;

    public partial class ConfluencePageResponse
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("version")]
        public Version Version { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("extensions")]
        public Extensions Extensions { get; set; }

        [JsonProperty("_links")]
        public ConfluencePageResponseLinks Links { get; set; }

        [JsonProperty("_expandable")]
        public ConfluencePageResponseExpandable Expandable { get; set; }
    }

    public partial class Body
    {
        [JsonProperty("storage")]
        public Storage Storage { get; set; }

        [JsonProperty("_expandable")]
        public BodyExpandable Expandable { get; set; }
    }

    public partial class BodyExpandable
    {
        [JsonProperty("editor")]
        public string Editor { get; set; }

        [JsonProperty("view")]
        public string View { get; set; }

        [JsonProperty("export_view")]
        public string ExportView { get; set; }

        [JsonProperty("styled_view")]
        public string StyledView { get; set; }

        [JsonProperty("anonymous_export_view")]
        public string AnonymousExportView { get; set; }
    }

    public partial class Storage
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("representation")]
        public string Representation { get; set; }

        [JsonProperty("_expandable")]
        public StorageExpandable Expandable { get; set; }
    }

    public partial class StorageExpandable
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public partial class ConfluencePageResponseExpandable
    {
        [JsonProperty("container")]
        public string Container { get; set; }

        [JsonProperty("metadata")]
        public string Metadata { get; set; }

        [JsonProperty("operations")]
        public string Operations { get; set; }

        [JsonProperty("children")]
        public string Children { get; set; }

        [JsonProperty("restrictions")]
        public string Restrictions { get; set; }

        [JsonProperty("history")]
        public string History { get; set; }

        [JsonProperty("ancestors")]
        public string Ancestors { get; set; }

        [JsonProperty("descendants")]
        public string Descendants { get; set; }

        [JsonProperty("space")]
        public string Space { get; set; }
    }

    public partial class Extensions
    {
        [JsonProperty("position")]
        public long Position { get; set; }
    }

    public partial class ConfluencePageResponseLinks
    {
        [JsonProperty("webui")]
        public string Webui { get; set; }

        [JsonProperty("edit")]
        public string Edit { get; set; }

        [JsonProperty("tinyui")]
        public string Tinyui { get; set; }

        [JsonProperty("collection")]
        public string Collection { get; set; }

        [JsonProperty("base")]
        public Uri Base { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }
    }

    public partial class Version
    {
        [JsonProperty("by")]
        public By By { get; set; }

        [JsonProperty("when")]
        public string When { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("minorEdit")]
        public bool MinorEdit { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("_links")]
        public VersionLinks Links { get; set; }

        [JsonProperty("_expandable")]
        public StorageExpandable Expandable { get; set; }
    }

    public partial class By
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("userKey")]
        public string UserKey { get; set; }

        [JsonProperty("profilePicture")]
        public ProfilePicture ProfilePicture { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("_links")]
        public VersionLinks Links { get; set; }

        [JsonProperty("_expandable")]
        public ByExpandable Expandable { get; set; }
    }

    public partial class ByExpandable
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class VersionLinks
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }
    }

    public partial class ProfilePicture
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }
    }

    public partial class ConfluencePageResponse
    {
        public static ConfluencePageResponse FromJson(string json) => JsonConvert.DeserializeObject<ConfluencePageResponse>(json, Converter.Settings);
    }
}
