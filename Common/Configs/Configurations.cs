using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Configs
{
    public static class Configurations
    {
        public static string ConfluenceTableSelector = @"//*[@id='main-content']/div[1]/table";
        public static string ConfluenceBase = ConfigurationManager.AppSettings["ConfluenceBase"];
        public static string ConfluenceUserStatusLink = ConfigurationManager.AppSettings["ConfluenceUserStatusLink"];
        public static string Users = ConfigurationManager.AppSettings["Users"];
        public static int LastStatusDayIndex = Convert.ToInt32(ConfigurationManager.AppSettings["LastStatusDayIndex"]);
        public static int ReportFrequency = Convert.ToInt32(ConfigurationManager.AppSettings["ReportFrequency"]);
        public static string CustomTask = ConfigurationManager.AppSettings["CustomTask"];

        public static string JiraBase = ConfigurationManager.AppSettings["JiraBase"];
        public static string JiraStatusLink = ConfigurationManager.AppSettings["JiraStatusLink"];
        public static string JiraTypeLink = ConfigurationManager.AppSettings["JiraTypeLink"];
        public static string JiraSummaryLink = ConfigurationManager.AppSettings["JiraSummaryLink"];
        public static string JiraTaskIdentifier = ConfigurationManager.AppSettings["JiraTaskIdentifier"];

        public static string JiraStatusChange = ConfigurationManager.AppSettings["JiraStatusChange"];
        public static string QA = ConfigurationManager.AppSettings["QA"];
        public static string JiraAssigneeDetails = ConfigurationManager.AppSettings["JiraAssigneeDetails"];
        public static string JiraAssigneeSet = ConfigurationManager.AppSettings["JiraAssigneeSet"];

        public static string QueryJiraWithCustomQuery = ConfigurationManager.AppSettings["QueryJiraWithCustomQuery"];
        public static string QueryJira = ConfigurationManager.AppSettings["QueryJira"];

        public static string StatusRecepientTo = ConfigurationManager.AppSettings["StatusRecepientTo"];
        public static string StatusRecepientCC = ConfigurationManager.AppSettings["StatusRecepientCC"];
        public static string SendStatusSubject = ConfigurationManager.AppSettings["SendStatusSubject"];

        public static string DeviceID = ConfigurationManager.AppSettings["DeviceID"];
        public static string SendNotificationUrl = ConfigurationManager.AppSettings["SendNotification"];
        public static string ClearAllNotificationUrl = ConfigurationManager.AppSettings["ClearAllNotification"];
        public static string ClearANotificationUrl = ConfigurationManager.AppSettings["ClearANotification"];

        public static string ZoomCallTip = ConfigurationManager.AppSettings["ZoomCallTip"];
        public static string SkypeCallTip = ConfigurationManager.AppSettings["SkypeCallTip"];

        public static string AppId = ConfigurationManager.AppSettings["appId"];
        public static string TenantId = ConfigurationManager.AppSettings["tenantId"];

        public static string StashBase = ConfigurationManager.AppSettings["StashBase"];
        public static string StashProject = ConfigurationManager.AppSettings["StashProject"];
        public static string StashRepo = ConfigurationManager.AppSettings["StashRepo"];
        public static string StashPRsLink = ConfigurationManager.AppSettings["StashPullRequests"];
        public static string CustomStashPullRequests = ConfigurationManager.AppSettings["CustomStashPullRequests"];
        public static string StashMerge = ConfigurationManager.AppSettings["StashMerge"];
        public static string StashMergePost = ConfigurationManager.AppSettings["StashMergePost"];
        public static string StashRebase = ConfigurationManager.AppSettings["StashRebase"];
        public static string StashOverview = ConfigurationManager.AppSettings["StashOverview"];
         
        public static string GetJiraId = ConfigurationManager.AppSettings["GetJiraId"];
        public static string GetJiraPRs = ConfigurationManager.AppSettings["GetJiraPRs"];

        public const int SaltSize = 8;
        public const string FileName = "EncryptedData.txt";

    }
}
