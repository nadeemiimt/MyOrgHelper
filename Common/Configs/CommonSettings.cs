using System.Configuration;

namespace Common.Configs
{
    public class CommonSettings : ConfigurationElement
    {
        [ConfigurationProperty("SaltSize", DefaultValue = 8, IsRequired = true)]
        public int SaltSize
        {
            get
            {
                return (int)this["SaltSize"];
            }
            set
            {
                value = (int)this["SaltSize"];
            }
        }

        [ConfigurationProperty("FileName", DefaultValue = "EncryptedData.txt", IsRequired = false)]
        public string FileName
        {
            get
            {
                return (string)this["FileName"];
            }
            set
            {
                value = (string)this["FileName"];
            }
        }

        [ConfigurationProperty("Tenant", IsRequired = false)]
        public string Tenant
        {
            get
            {
                return (string)this["Tenant"];
            }
            set
            {
                value = (string)this["Tenant"];
            }
        }
        

        [ConfigurationProperty("IsApi", IsRequired = false, DefaultValue = false)]
        public bool IsApi
        {
            get
            {
                return (bool)this["IsApi"];
            }
            set
            {
                value = (bool)this["IsApi"];
            }
        }

        [ConfigurationProperty("Resource", IsRequired = false)]
        public string Resource
        {
            get
            {
                return (string)this["Resource"];
            }
            set
            {
                value = (string)this["Resource"];
            }
        }
        

        [ConfigurationProperty("Secret", IsRequired = false)]
        public string Secret
        {
            get
            {
                return (string)this["Secret"];
            }
            set
            {
                value = (string)this["Secret"];
            }
        }

        [ConfigurationProperty("RedirectUrl", IsRequired = false)]
        public string RedirectUrl
        {
            get
            {
                return (string)this["RedirectUrl"];
            }
            set
            {
                value = (string)this["RedirectUrl"];
            }
        }

        [ConfigurationProperty("Audience",  IsRequired = false)]
        public string Audience
        {
            get
            {
                return (string)this["Audience"];
            }
            set
            {
                value = (string)this["Audience"];
            }
        }

        [ConfigurationProperty("EncryptPassword", DefaultValue = "HelperDataPass123", IsRequired = false)]
        public string EncryptPassword
        {
            get
            {
                return (string)this["EncryptPassword"];
            }
            set
            {
                value = (string)this["EncryptPassword"];
            }
        }

        [ConfigurationProperty("AuthCode", IsRequired = false)]
        public string AuthCode
        {
            get
            {
                return (string)this["AuthCode"];
            }
            set
            {
                value = (string)this["AuthCode"];
            }
        }

        [ConfigurationProperty("MeetingCode", IsRequired = false)]
        public string MeetingCode
        {
            get
            {
                return (string)this["MeetingCode"];
            }
            set
            {
                value = (string)this["MeetingCode"];
            }
        }

        [ConfigurationProperty("AuthUrl", IsRequired = false)]
        public string AuthUrl
        {
            get
            {
                return (string)this["AuthUrl"];
            }
            set
            {
                value = (string)this["AuthUrl"];
            }
        }

        [ConfigurationProperty("MeetingUrl" , IsRequired = false)]
        public string MeetingUrl
        {
            get
            {
                return (string)this["MeetingUrl"];
            }
            set
            {
                value = (string)this["MeetingUrl"];
            }
        }
    }
}
