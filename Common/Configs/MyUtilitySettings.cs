using Common.Contract;
using System.Configuration;

namespace Common.Configs
{
    public class MyUtilitySettings : ConfigurationSection, IConfigurations
    {
        [ConfigurationProperty("MeetingSettings")]
        public MeetingSettings MeetingSettings
        {
            get
            {
                return (MeetingSettings)this["MeetingSettings"];
            }
            set
            {
                value = (MeetingSettings)this["MeetingSettings"];
            }
        }

        [ConfigurationProperty("JiraSettings")]
        public JiraSettings JiraSettings
        {
            get
            {
                return (JiraSettings)this["JiraSettings"];
            }
            set
            {
                value = (JiraSettings)this["JiraSettings"];
            }
        }

        [ConfigurationProperty("ReportSettings")]
        public ReportSettings ReportSettings
        {
            get
            {
                return (ReportSettings)this["ReportSettings"];
            }
            set
            {
                value = (ReportSettings)this["ReportSettings"];
            }
        }

        [ConfigurationProperty("StashSettings")]
        public StashSettings StashSettings
        {
            get
            {
                return (StashSettings)this["StashSettings"];
            }
            set
            {
                value = (StashSettings)this["StashSettings"];
            }
        }


        [ConfigurationProperty("NotificationSettings")]
        public NotificationSettings NotificationSettings
        {
            get
            {
                return (NotificationSettings)this["NotificationSettings"];
            }
            set
            {
                value = (NotificationSettings)this["NotificationSettings"];
            }
        }



        [ConfigurationProperty("CommonSettings")]
        public CommonSettings CommonSettings
        {
            get
            {
                return (CommonSettings)this["CommonSettings"];
            }
            set
            {
                value = (CommonSettings)this["CommonSettings"];
            }
        }

    }
}
