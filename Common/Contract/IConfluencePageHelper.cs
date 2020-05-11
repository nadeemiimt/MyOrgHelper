using Common.Models;

namespace Common.Contract
{
    public interface IConfluencePageHelper
    {
        ConfluencePageResponse GetConfluencePage(string userName, string password, string pageId);

        ConfluencePageResponse UpdateConfluencePage(string userName, string password, string pageId,
            ConfluencePageResponse request);

        void SendAlertForStatusChange(string userName, string password, bool useLocalOutlook, string token = null);
    }
}
