using System.Linq;
using System.Net.Http;
using Common.Contract;

namespace BusinessLogic.Notification
{
    public class WirePusher : INotifier
    {
        private readonly IHttpRequestHelper requestHelper;
        private readonly IDataHelper dataHelper;
        private readonly IConfigurations configurations;

        public WirePusher(IConfigurations configurations, IHttpRequestHelper requestHelper, IDataHelper dataHelper)
        {
            this.configurations = configurations;
            this.requestHelper = requestHelper;
            this.dataHelper = dataHelper;
        }

        private readonly string mIdFile = "PushMessages";

        public void ClearAllNotification()
        {
            var url = string.Format(this.configurations.NotificationSettings.ClearAllNotificationUrl, this.configurations.NotificationSettings.DeviceID);
            this.requestHelper.CallUrl(url, null, null, null, HttpMethod.Post);
        }

        public void ClearANotification(int messageId)
        {
            var url = string.Format(this.configurations.NotificationSettings.ClearANotificationUrl, this.configurations.NotificationSettings.DeviceID, messageId);
            this.requestHelper.CallUrl(url, null, null, null, HttpMethod.Post);
        }

        public int GetAllSendNotificationIds()  // can be extended to save & get notifications status
        {
            return this.dataHelper.GetSavedFileDataInEachLine(mIdFile).Count;
        }

        public void SendNotification(string message, string title = "alert", string type = "monitoring")
        {
            var url = string.Format(this.configurations.NotificationSettings.SendNotificationUrl, this.configurations.NotificationSettings.DeviceID, title, message, type);
            var result = this.requestHelper.CallUrl(url, null, null, null, HttpMethod.Post);
            this.dataHelper.SaveInFile(mIdFile, result);
        }
    }
}
