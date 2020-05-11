using System.Configuration;

namespace Common.Configs
{
    public class NotificationSettings : ConfigurationElement
    {
        [ConfigurationProperty("DeviceID", IsRequired = true)]
        public string DeviceID
        {
            get
            {
                return (string)this["DeviceID"];
            }
            set
            {
                value = (string)this["DeviceID"];
            }
        }

        [ConfigurationProperty("SendNotificationUrl", IsRequired = true)]
        public string SendNotificationUrl
        {
            get
            {
                return (string)this["SendNotificationUrl"];
            }
            set
            {
                value = (string)this["SendNotificationUrl"];
            }
        }

        [ConfigurationProperty("ClearAllNotificationUrl", IsRequired = true)]
        public string ClearAllNotificationUrl
        {
            get
            {
                return (string)this["ClearAllNotificationUrl"];
            }
            set
            {
                value = (string)this["ClearAllNotificationUrl"];
            }
        }

        [ConfigurationProperty("ClearANotificationUrl", IsRequired = true)]
        public string ClearANotificationUrl
        {
            get
            {
                return (string)this["ClearANotificationUrl"];
            }
            set
            {
                value = (string)this["ClearANotificationUrl"];
            }
        }

    }
}
