using System.Configuration;

namespace Common.Configs
{
    public class JiraSettings : ConfigurationElement
    {
        [ConfigurationProperty("JiraBase", IsRequired = true)]
        public string JiraBase
        {
            get
            {
                return (string)this["JiraBase"];
            }
            set
            {
                value = (string)this["JiraBase"];
            }
        }

        [ConfigurationProperty("JiraStatusLink", IsRequired = true)]
        public string JiraStatusLink
        {
            get
            {
                return (string)this["JiraStatusLink"];
            }
            set
            {
                value = (string)this["JiraStatusLink"];
            }
        }

        [ConfigurationProperty("JiraTypeLink", IsRequired = true)]
        public string JiraTypeLink
        {
            get
            {
                return (string)this["JiraTypeLink"];
            }
            set
            {
                value = (string)this["JiraTypeLink"];
            }
        }

        [ConfigurationProperty("JiraSummaryLink", IsRequired = true)]
        public string JiraSummaryLink
        {
            get
            {
                return (string)this["JiraSummaryLink"];
            }
            set
            {
                value = (string)this["JiraSummaryLink"];
            }
        }
        

        [ConfigurationProperty("JiraPriorityLink", IsRequired = true)]
        public string JiraPriorityLink
        {
            get
            {
                return (string)this["JiraPriorityLink"];
            }
            set
            {
                value = (string)this["JiraPriorityLink"];
            }
        }

        [ConfigurationProperty("JiraTaskIdentifier", IsRequired = true)]
        public string JiraTaskIdentifier
        {
            get
            {
                return (string)this["JiraTaskIdentifier"];
            }
            set
            {
                value = (string)this["JiraTaskIdentifier"];
            }
        }

        [ConfigurationProperty("JiraStatusChange", IsRequired = true)]
        public string JiraStatusChange
        {
            get
            {
                return (string)this["JiraStatusChange"];
            }
            set
            {
                value = (string)this["JiraStatusChange"];
            }
        }

        [ConfigurationProperty("JiraAssigneeDetails", IsRequired = true)]
        public string JiraAssigneeDetails
        {
            get
            {
                return (string)this["JiraAssigneeDetails"];
            }
            set
            {
                value = (string)this["JiraAssigneeDetails"];
            }
        }

        [ConfigurationProperty("JiraAssigneeSet", IsRequired = true)]
        public string JiraAssigneeSet
        {
            get
            {
                return (string)this["JiraAssigneeSet"];
            }
            set
            {
                value = (string)this["JiraAssigneeSet"];
            }
        }

        [ConfigurationProperty("QueryJiraWithCustomQuery", IsRequired = true)]
        public string QueryJiraWithCustomQuery
        {
            get
            {
                return (string)this["QueryJiraWithCustomQuery"];
            }
            set
            {
                value = (string)this["QueryJiraWithCustomQuery"];
            }
        }

        [ConfigurationProperty("QueryJira", IsRequired = true)]
        public string QueryJira
        {
            get
            {
                return (string)this["QueryJira"];
            }
            set
            {
                value = (string)this["QueryJira"];
            }
        }

        [ConfigurationProperty("GetJiraId", IsRequired = true)]
        public string GetJiraId
        {
            get
            {
                return (string)this["GetJiraId"];
            }
            set
            {
                value = (string)this["GetJiraId"];
            }
        }

        [ConfigurationProperty("GetJiraPRs", IsRequired = true)]
        public string GetJiraPRs
        {
            get
            {
                return (string)this["GetJiraPRs"];
            }
            set
            {
                value = (string)this["GetJiraPRs"];
            }
        }

        [ConfigurationProperty("JiraStoryPointLink", IsRequired = true)]
        public string JiraStoryPointLink
        {
            get
            {
                return (string)this["JiraStoryPointLink"];
            }
            set
            {
                value = (string)this["JiraStoryPointLink"];
            }
        }

        [ConfigurationProperty("StoryPointField", IsRequired = true)]
        public string StoryPointField
        {
            get
            {
                return (string)this["StoryPointField"];
            }
            set
            {
                value = (string)this["StoryPointField"];
            }
        }

    }
}
