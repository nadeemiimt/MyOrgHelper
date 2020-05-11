namespace Common.Models
{
    using Common.Utils;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Get all PR data created by me.
    /// </summary>
    public partial class StashPrResponse
    {
        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("isLastPage")]
        public bool IsLastPage { get; set; }

        [JsonProperty("values")]
        public List<Value> Values { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }
    }

    public partial class Value
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
        public List<object> Participants { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("links")]
        public UserLinks Links { get; set; }
    }

    public partial class Author
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }

        [JsonProperty("status")]
        public StatusEnum Status { get; set; }

        [JsonProperty("lastReviewedCommit", NullValueHandling = NullValueHandling.Ignore)]
        public string LastReviewedCommit { get; set; }
    }

    public partial class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("links")]
        public UserLinks Links { get; set; }

        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }
    }

    public partial class UserLinks
    {
        [JsonProperty("self")]
        public List<Self> Self { get; set; }
    }

    public partial class Self
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class Ref
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayId")]
        public string DisplayId { get; set; }

        [JsonProperty("latestCommit")]
        public string LatestCommit { get; set; }

        [JsonProperty("repository")]
        public Repository Repository { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Repository
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("scmId")]
        public string ScmId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("statusMessage")]
        public string StatusMessage { get; set; }

        [JsonProperty("forkable")]
        public bool Forkable { get; set; }

        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("links")]
        public RepositoryLinks Links { get; set; }
    }

    public partial class RepositoryLinks
    {
        [JsonProperty("clone")]
        public List<Clone> Clone { get; set; }

        [JsonProperty("self")]
        public List<Self> Self { get; set; }
    }

    public partial class Clone
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }
    }

    public partial class Project
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("links")]
        public UserLinks Links { get; set; }

        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }
    }

    public partial class Properties
    {
        [JsonProperty("mergeResult")]
        public MergeResult MergeResult { get; set; }

        [JsonProperty("resolvedTaskCount")]
        public long ResolvedTaskCount { get; set; }

        [JsonProperty("commentCount")]
        public long CommentCount { get; set; }

        [JsonProperty("openTaskCount")]
        public long OpenTaskCount { get; set; }
    }

    public class MergeResult
    {
        [JsonProperty("outcome")]
        public string Outcome { get; set; }

        [JsonProperty("current")]
        public bool Current { get; set; }
    }

    public enum Role { Author, Reviewer, Participant };

    public enum StatusEnum { Approved, Unapproved };

    public enum TypeEnum { Normal };

    public enum Name { Http, Ssh };

    public partial class StashPrResponse
    {
        public static StashPrResponse FromJson(string json) => JsonConvert.DeserializeObject<StashPrResponse>(json, Converter.Settings);
    }

    public partial class Value
    {
        public static Value FromJson(string json) => JsonConvert.DeserializeObject<Value>(json, Converter.Settings);
    }

    internal class RoleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Role) || t == typeof(Role?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value?.ToUpperInvariant())
            {
                case "AUTHOR":
                    return Role.Author;
                case "REVIEWER":
                    return Role.Reviewer;
                case "PARTICIPANT":
                    return Role.Participant;
            }
            throw new Exception("Cannot unmarshal type Role");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Role)untypedValue;
            switch (value)
            {
                case Role.Author:
                    serializer.Serialize(writer, "AUTHOR");
                    return;
                case Role.Reviewer:
                    serializer.Serialize(writer, "REVIEWER");
                    return;
            }
            throw new Exception("Cannot marshal type Role");
        }

        public static readonly RoleConverter Singleton = new RoleConverter();
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StatusEnum) || t == typeof(StatusEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "APPROVED":
                    return StatusEnum.Approved;
                case "UNAPPROVED":
                    return StatusEnum.Unapproved;
            }
            throw new Exception("Cannot unmarshal type StatusEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StatusEnum)untypedValue;
            switch (value)
            {
                case StatusEnum.Approved:
                    serializer.Serialize(writer, "APPROVED");
                    return;
                case StatusEnum.Unapproved:
                    serializer.Serialize(writer, "UNAPPROVED");
                    return;
            }
            throw new Exception("Cannot marshal type StatusEnum");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "NORMAL")
            {
                return TypeEnum.Normal;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            if (value == TypeEnum.Normal)
            {
                serializer.Serialize(writer, "NORMAL");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class NameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "http":
                    return Name.Http;
                case "ssh":
                    return Name.Ssh;
            }
            throw new Exception("Cannot unmarshal type Name");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Name)untypedValue;
            switch (value)
            {
                case Name.Http:
                    serializer.Serialize(writer, "http");
                    return;
                case Name.Ssh:
                    serializer.Serialize(writer, "ssh");
                    return;
            }
            throw new Exception("Cannot marshal type Name");
        }

        public static readonly NameConverter Singleton = new NameConverter();
    }
}
