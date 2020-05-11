namespace Common.Models
{
    public class JiraStatusDto
    {
        public JiraStatusDto(string jiraTaskId)
        {
            this.JiraTaskId = jiraTaskId;
        }

        public string JiraTaskId { get; set; }

        public string Status { get; set; }

        public string Summary { get; set; }

        public string Priority { get; set; }

        public string Type { get; set; }

        public int? StoryPoint { get; set; }

        public bool IsNew { get; set; }
    }
}
