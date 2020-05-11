using Common.Models;

namespace Common.Contract
{
    public interface IJiraStatusHelper
    {
        string GetJiraStatus(string jiraTaskId, string userName, string password);

        string GetJiraType(string jiraTaskId, string userName, string password);

        string GetJiraSummary(string jiraTaskId, string userName, string password);

        JiraPriority GetJiraPriority(string jiraTaskId, string userName, string password);

        void LoadJiraStatusDto(string userName, string password, JiraStatusDto jiraStatusDto);

        bool ChangeStatus(Transitions status, string jiraTasId, string userName, string password);
    }
}
