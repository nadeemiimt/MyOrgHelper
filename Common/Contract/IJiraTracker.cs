using Common.Models;

namespace Common.Contract
{
    public interface IJiraTracker
    {
        /// <summary>
        /// Ger Custom Jira Query result.
        /// </summary>
        /// <param name="jiraCustomRequest"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>JiraCustomSearchResponse</returns>
        JiraCustomSearchResponse GetJiraCustomSearchResult(JiraCustomRequest jiraCustomRequest, string userName, string password);
    }
}
