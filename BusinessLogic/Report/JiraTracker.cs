using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using Common.Contract;
using Common.Models;
using Common.Utils;
using RestSharp;

namespace BusinessLogic.Report
{
    public class JiraTracker : IJiraTracker 
    {
        private readonly IHttpRequestHelper requestHelper;
        private readonly IConfigurations configurations;

        public JiraTracker(IConfigurations configurations, IHttpRequestHelper requestHelper)
        {
            this.configurations = configurations;
            this.requestHelper = requestHelper;
        }

        /// <inheritdoc/>
        public JiraCustomSearchResponse GetJiraCustomSearchResult(JiraCustomRequest jiraCustomRequest, string userName, string password)
        {
            var url = string.IsNullOrWhiteSpace(jiraCustomRequest.JiraQuery) ? string.Format(this.configurations.JiraSettings.QueryJira, this.configurations.JiraSettings.JiraBase, jiraCustomRequest.JiraType.ToDescriptionString(), jiraCustomRequest.From, jiraCustomRequest.To, jiraCustomRequest.ProjectName, jiraCustomRequest.JiraStatus.ToDescriptionString())
                : string.Format(this.configurations.JiraSettings.QueryJiraWithCustomQuery, this.configurations.JiraSettings.JiraBase, DecodeInputForJquery(jiraCustomRequest.JiraQuery));

            Dictionary<string, Tuple<object, ParameterType>> parameters = new Dictionary<string, Tuple<object, ParameterType>>();
            parameters.Add("User-Agent", new Tuple<object, ParameterType>("random", ParameterType.HttpHeader));
            parameters.Add("Content-Type", new Tuple<object, ParameterType>("application/json;charset=UTF-8", ParameterType.HttpHeader));
            parameters.Add("X-Atlassian-Token", new Tuple<object, ParameterType>("nocheck", ParameterType.HttpHeader));

            var data = this.requestHelper.CallUrl(url, userName, password, parameters, HttpMethod.Get);

            return JiraCustomSearchResponse.FromJson(data);
        }

        private string DecodeInputForJquery(string input)
        {
            return input.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"");
        }
    }
}
