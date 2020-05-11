using System.Configuration;

namespace Common.Configs
{
    public class StashSettings : ConfigurationElement
    {
        [ConfigurationProperty("QA", IsRequired = true)]
        public string QA
        {
            get
            {
                return (string)this["QA"];
            }
            set
            {
                value = (string)this["QA"];
            }
        }

        [ConfigurationProperty("StashBase", IsRequired = true)]
        public string StashBase
        {
            get
            {
                return (string)this["StashBase"];
            }
            set
            {
                value = (string)this["StashBase"];
            }
        }

        [ConfigurationProperty("StashApprove", IsRequired = true)]
        public string StashApprove
        {
            get
            {
                return (string)this["StashApprove"];
            }
            set
            {
                value = (string)this["StashApprove"];
            }
        }

        [ConfigurationProperty("StashProject", IsRequired = true)]
        public string StashProject
        {
            get
            {
                return (string)this["StashProject"];
            }
            set
            {
                value = (string)this["StashProject"];
            }
        }

        [ConfigurationProperty("StashRepo", IsRequired = true)]
        public string StashRepo
        {
            get
            {
                return (string)this["StashRepo"];
            }
            set
            {
                value = (string)this["StashRepo"];
            }
        }

        [ConfigurationProperty("StashPRsLink", IsRequired = true)]
        public string StashPRsLink
        {
            get
            {
                return (string)this["StashPRsLink"];
            }
            set
            {
                value = (string)this["StashPRsLink"];
            }
        }

        [ConfigurationProperty("CustomStashPullRequests", IsRequired = true)]
        public string CustomStashPullRequests
        {
            get
            {
                return (string)this["CustomStashPullRequests"];
            }
            set
            {
                value = (string)this["CustomStashPullRequests"];
            }
        }

        [ConfigurationProperty("StashMerge", IsRequired = true)]
        public string StashMerge
        {
            get
            {
                return (string)this["StashMerge"];
            }
            set
            {
                value = (string)this["StashMerge"];
            }
        }

        [ConfigurationProperty("StashMergePost", IsRequired = true)]
        public string StashMergePost
        {
            get
            {
                return (string)this["StashMergePost"];
            }
            set
            {
                value = (string)this["StashMergePost"];
            }
        }

        [ConfigurationProperty("StashRebase", IsRequired = true)]
        public string StashRebase
        {
            get
            {
                return (string)this["StashRebase"];
            }
            set
            {
                value = (string)this["StashRebase"];
            }
        }

        [ConfigurationProperty("StashOverview", IsRequired = true)]
        public string StashOverview
        {
            get
            {
                return (string)this["StashOverview"];
            }
            set
            {
                value = (string)this["StashOverview"];
            }
        }
    }
}
