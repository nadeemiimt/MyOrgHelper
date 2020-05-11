namespace Common.Models
{
    using Common.Utils;
    using Newtonsoft.Json;
    using System.ComponentModel;

    /// <summary>
    /// This summary message needs to be customized as per need.
    /// </summary>
    [JsonConverter(typeof(JsonConverter<SummaryMessage>))]
    public class SummaryMessage : StringEnumBase<SummaryMessage>
    {
        private SummaryMessage(string value) : base(value) { }
        public static SummaryMessage BuildFailedOrInProgress => new SummaryMessage("Not all required builds are successful yet"); // Rebase if available.
        public static SummaryMessage InsufficientApprovals => new SummaryMessage("Requires approvals"); // will automate sending reminder from a list of friendly approvals/ BLRCodeReview group.
        public static SummaryMessage SherpaApprovals => new SummaryMessage("BG Sherpa approval required"); // will automate sending message on slack.
        public static SummaryMessage Retry => new SummaryMessage("Script merge check exception"); // will automate sending message on slack.
        public static SummaryMessage ResolveAllTask => new SummaryMessage("Requires all tasks to be resolved"); // will automate sending message on slack.
        public static SummaryMessage MasterBuildCITBroken => new SummaryMessage("The Canonical (ACP-CIT) master build is broken!");
        public static SummaryMessage MasterBuildCNBroken => new SummaryMessage("The Canonical (COM-CN) master build is broken!");
        public static SummaryMessage NoPermission => new SummaryMessage("Insufficient branch permissions");
        public static SummaryMessage OpenIssues => new SummaryMessage("open issue(s) found");
        public static SummaryMessage RebaseRequired => new SummaryMessage("Rebase your branch");
    }

    public class Constants
    {
        public const string BuildFailMessage = "You cannot merge this pull request while it has failed builds. You still need a minimum of 3 successful builds before this pull request can be merged.";
        public const string BuildInProgressMessage = "You cannot merge this pull request while it has in-progress builds. You still need a minimum of 3 successful builds before this pull request can be merged.";

        public const string ExchangeServer = "ExchangeServer";
        public const string LocalOutlook = "LocalOutlook";
    }

    // Get it from https://{BASE}/jira/rest/api/2/issue/{TaskId}/transitions
    public enum Transitions
        {
        [Description("To Do")]
        ToDo = 10801,
        [Description("Code Review")]
        CodeReview = 10008,
        [Description("New")]
        New = 2,
        //[Description("Done")]
        //Done = 3,
        [Description("In Progress")]
        InProgress = 3,
        [Description("Start Progress")]
        StartProgress = 4,
        [Description("Resolve Issue")]
        ResolveIssue = 5,
        [Description("Pull Request Submitted")]
        PullRequestSubmitted = 331,
        [Description("Pull Request Accepted")]
        PullRequestAccepted = 341,
        [Description("On Hold")]
        OnHold = 361,
        [Description("Stop Progress")]
        StopProgress = 301,
        [Description("Dev Complete")]
        DevComplete = 431,
        [Description("Closed")]
        Closed = 6,
    }

        public enum Resolutions
        {
            [Description("Done/Fixed")]
            DoneOrFixed,
            [Description("NotInVision")]
            NotInVision,
            [Description("Done")]
            Done,
            [Description("Duplicate")]
            Duplicate,
            [Description("Blocked")]
            Blocked
        }

        public enum JiraType
        {
            [Description("EPIC")]
            EPIC,
            [Description("BUG")]
            BUG,
            [Description("TASK")]
            TASK
        }

        public enum JiraStatus
        {
            [Description("Onboarded")]
            Onboarded,
            [Description("Rejected")]
            Rejected,
            [Description("Requested")]
            Requested,
            [Description("Closed")]
            Closed,
            [Description("Code+Review")]
            CodeReview,
            [Description("To+Do")]
            ToDo
        }

        public enum JiraPriority
        {
            [Description("Not Set")]
            NotSet,
            [Description("P0")]
            P0,
            [Description("P1")]
            P1,
            [Description("P2")]
            P2,
            [Description("P3")]
            P3,
            [Description("P4")]
            P4
    }
}
