using System.Configuration;

namespace Common.Configs
{
    public class ReportSettings : ConfigurationElement
    {
        [ConfigurationProperty("ConfluenceTableSelector", IsRequired = true)]
        public string ConfluenceTableSelector
        {
            get
            {
                return (string)this["ConfluenceTableSelector"];
            }
            set
            {
                value = (string)this["ConfluenceTableSelector"];
            }
        }

        [ConfigurationProperty("ConfluenceBase", IsRequired = true)]
        public string ConfluenceBase
        {
            get
            {
                return (string)this["ConfluenceBase"];
            }
            set
            {
                value = (string)this["ConfluenceBase"];
            }
        }

        [ConfigurationProperty("EnableStoryPoints", DefaultValue = false, IsRequired = true)]
        public bool EnableStoryPoints
        {
            get
            {
                return (bool)this["EnableStoryPoints"];
            }
            set
            {
                value = (bool)this["EnableStoryPoints"];
            }
        }

        [ConfigurationProperty("ConfluenceUserStatusLink", IsRequired = true)]
        public string ConfluenceUserStatusLink
        {
            get
            {
                return (string)this["ConfluenceUserStatusLink"];
            }
            set
            {
                value = (string)this["ConfluenceUserStatusLink"];
            }
        }

        [ConfigurationProperty("Users", IsRequired = true)]
        public string Users
        {
            get
            {
                return (string)this["Users"];
            }
            set
            {
                value = (string)this["Users"];
            }
        }

        [ConfigurationProperty("LastStatusDayIndex", IsRequired = true)]
        public int LastStatusDayIndex
        {
            get
            {
                return (int)this["LastStatusDayIndex"];
            }
            set
            {
                value = (int)this["LastStatusDayIndex"];
            }
        }

        [ConfigurationProperty("ReportFrequency", IsRequired = true)]
        public int ReportFrequency
        {
            get
            {
                return (int)this["ReportFrequency"];
            }
            set
            {
                value = (int)this["ReportFrequency"];
            }
        }

        [ConfigurationProperty("CustomTask", IsRequired = true)]
        public string CustomTask
        {
            get
            {
                return (string)this["CustomTask"];
            }
            set
            {
                value = (string)this["CustomTask"];
            }
        }

        [ConfigurationProperty("StatusReportTemplate", IsRequired = true)]
        public string StatusReportTemplate
        {
            get
            {
                return (string)this["StatusReportTemplate"];
            }
            set
            {
                value = (string)this["StatusReportTemplate"];
            }
        }

        [ConfigurationProperty("ConfluencePageApiUrl", IsRequired = true)]
        public string ConfluencePageApiUrl
        {
            get
            {
                return (string)this["ConfluencePageApiUrl"];
            }
            set
            {
                value = (string)this["ConfluencePageApiUrl"];
            }
        }


        [ConfigurationProperty("ConfluencePageUrl", IsRequired = true)]
        public string ConfluencePageUrl
        {
            get
            {
                return (string)this["ConfluencePageUrl"];
            }
            set
            {
                value = (string)this["ConfluencePageUrl"];
            }
        }

        [ConfigurationProperty("AlertPageId", IsRequired = true)]
        public string AlertPageId
        {
            get
            {
                return (string)this["AlertPageId"];
            }
            set
            {
                value = (string)this["AlertPageId"];
            }
        }
    }
}
