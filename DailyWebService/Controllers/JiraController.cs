using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.Contract;
using Common.Models;
using Common.Utils;

namespace DailyWebService.Controllers
{
    public class JiraController : ApiController
    {
        // Paswords can be replaced with token 

        private readonly IJiraStatusHelper jiraStatusHelper;
        private readonly IJiraTracker jiraTracker;

        public JiraController(IJiraStatusHelper jiraStatusHelper, IJiraTracker jiraTracker)
        {
            this.jiraStatusHelper = jiraStatusHelper;
            this.jiraTracker = jiraTracker;
        }

        // GET api/<controller>
        public JiraCustomSearchResponse GetJiraCustomSearchResult(JiraCustomRequest jiraCustomRequest)
        {
            jiraCustomRequest.UserName = Utility.DecryptStringAES(jiraCustomRequest.UserName);
            jiraCustomRequest.Password = Utility.DecryptStringAES(jiraCustomRequest.Password);

            return this.jiraTracker.GetJiraCustomSearchResult(jiraCustomRequest, jiraCustomRequest.UserName, jiraCustomRequest.Password);
        }

        public string GetJiraStatus(string jiraTaskId, string userName, string password)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);

            return this.jiraStatusHelper.GetJiraStatus(jiraTaskId, userName, password);
        }

        public string GetJiraType(string jiraTaskId, string userName, string password)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);

            return this.jiraStatusHelper.GetJiraType(jiraTaskId, userName, password);
        }

        public string GetJiraSummary(string jiraTaskId, string userName, string password)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);

            return this.jiraStatusHelper.GetJiraSummary(jiraTaskId, userName, password);
        }

        public void LoadJiraStatusDto(string userName, string password, JiraStatusDto jiraStatusDto)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);

            this.jiraStatusHelper.LoadJiraStatusDto(userName, password, jiraStatusDto);
        }

        public bool ChangeStatus(Transitions status, string jiraTaskId, string userName, string password)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);

            return this.jiraStatusHelper.ChangeStatus(status, jiraTaskId, userName, password);
        }
    }
}