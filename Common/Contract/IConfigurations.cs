using Common.Configs;

namespace Common.Contract
{
    public interface IConfigurations
    {
        MeetingSettings MeetingSettings { get; set; }
        JiraSettings JiraSettings { get; set; }
        ReportSettings ReportSettings { get; set; }
        StashSettings StashSettings { get; set; }
        NotificationSettings NotificationSettings { get; set; }
        CommonSettings CommonSettings { get; set; }
    }
}
