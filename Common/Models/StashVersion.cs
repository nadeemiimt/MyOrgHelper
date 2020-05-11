namespace Common.Models
{
    using Newtonsoft.Json;

    public class StashVersion
    {
        public StashVersion(long version)
        {
            this.Version = version;
        }

        [JsonProperty("version")]
        public long Version { get; set; }
    }
}
