namespace Common.Contract
{
    public interface INotifier
    {
        void SendNotification(string message, string title = "alert", string type = "monitoring");

        void ClearAllNotification();

        void ClearANotification(int messageId);

        int GetAllSendNotificationIds(); 
    }
}
