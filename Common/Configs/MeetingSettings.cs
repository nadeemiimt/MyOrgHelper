using System.Configuration;

namespace Common.Configs
{
    public class MeetingSettings : ConfigurationElement
    {
        [ConfigurationProperty("StatusRecepientTo", IsRequired = true)]
        public string StatusRecepientTo
        {
            get
            {
                return (string)this["StatusRecepientTo"];
            }
            set
            {
                value = (string)this["StatusRecepientTo"];
            }
        }

        [ConfigurationProperty("StatusRecepientCC", IsRequired = true)]
        public string StatusRecepientCC
        {
            get
            {
                return (string)this["StatusRecepientCC"];
            }
            set
            {
                value = (string)this["StatusRecepientCC"];
            }
        }

        [ConfigurationProperty("SendStatusSubject", IsRequired = true)]
        public string SendStatusSubject
        {
            get
            {
                return (string)this["SendStatusSubject"];
            }
            set
            {
                value = (string)this["SendStatusSubject"];
            }
        }

        [ConfigurationProperty("ZoomCallTip", IsRequired = true)]
        public string ZoomCallTip
        {
            get
            {
                return (string)this["ZoomCallTip"];
            }
            set
            {
                value = (string)this["ZoomCallTip"];
            }
        }

        [ConfigurationProperty("SkypeCallTip", IsRequired = true)]
        public string SkypeCallTip
        {
            get
            {
                return (string)this["SkypeCallTip"];
            }
            set
            {
                value = (string)this["SkypeCallTip"];
            }
        }

        [ConfigurationProperty("AppId", IsRequired = true)]
        public string AppId
        {
            get
            {
                return (string)this["AppId"];
            }
            set
            {
                value = (string)this["AppId"];
            }
        }

        [ConfigurationProperty("TenantId", IsRequired = true)]
        public string TenantId
        {
            get
            {
                return (string)this["TenantId"];
            }
            set
            {
                value = (string)this["TenantId"];
            }
        }

        [ConfigurationProperty("ExchangeUrl", IsRequired = true)]
        public string ExchangeUrl
        {
            get
            {
                return (string)this["ExchangeUrl"];
            }
            set
            {
                value = (string)this["ExchangeUrl"];
            }
        }

        [ConfigurationProperty("ScopeUrl", IsRequired = true)]
        public string ScopeUrl
        {
            get
            {
                return (string)this["ScopeUrl"];
            }
            set
            {
                value = (string)this["ScopeUrl"];
            }
        }

        [ConfigurationProperty("AllScope", IsRequired = false)]
        public string AllScope
        {
            get
            {
                return (string)this["AllScope"];
            }
            set
            {
                value = (string)this["AllScope"];
            }
        }

    }
}
