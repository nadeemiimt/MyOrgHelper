using Common.Contract;
using Common.Models;
using Common.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using log4net;
using Newtonsoft.Json;

namespace BusinessLogic.Report
{
    public class JiraStatusHelper : IJiraStatusHelper
    {
        private readonly IHttpRequestHelper requestHelper;
        private readonly IConfigurations configurations;
        private readonly ILog logger;


        public JiraStatusHelper(IConfigurations configurations, IHttpRequestHelper requestHelper, ILog logger)
        {
            this.configurations = configurations;
            this.requestHelper = requestHelper;
            this.logger = logger;
        }

        public void LoadJiraStatusDto(string userName, string password, JiraStatusDto jiraStatusDto)
        {
            if (!this.configurations.JiraSettings.JiraTaskIdentifier.Split(',').Any(x => jiraStatusDto.JiraTaskId.Contains(x)))
            {
                jiraStatusDto.JiraTaskId = this.configurations.ReportSettings.CustomTask.Trim().Replace(":", "");
                jiraStatusDto.Status = string.Empty;
                jiraStatusDto.Type = string.Empty;
                jiraStatusDto.Summary = jiraStatusDto.JiraTaskId;
            }
            else
            {
                jiraStatusDto.JiraTaskId = jiraStatusDto.JiraTaskId;
                jiraStatusDto.Status = GetJiraStatus(jiraStatusDto.JiraTaskId, userName, password);
                jiraStatusDto.Type = GetJiraType(jiraStatusDto.JiraTaskId, userName, password);
                jiraStatusDto.Summary = GetJiraSummary(jiraStatusDto.JiraTaskId, userName, password);
                jiraStatusDto.Priority = GetJiraPriority(jiraStatusDto.JiraTaskId, userName, password).ToDescriptionString();
                jiraStatusDto.StoryPoint = GetJiraStoryPoints(jiraStatusDto.JiraTaskId, userName, password);
            }
        }

        public string GetJiraStatus(string jiraTaskId, string userName, string password)
        {
            var result = this.requestHelper.CallUrl(string.Format(this.configurations.JiraSettings.JiraStatusLink, this.configurations.JiraSettings.JiraBase, jiraTaskId), userName, password, null, HttpMethod.Get);

            return JiraResponse.FromJson(result)?.Fields?.Status?.Name;
        }

        public string GetJiraType(string jiraTaskId, string userName, string password)
        {
            var result = this.requestHelper.CallUrl(string.Format(this.configurations.JiraSettings.JiraTypeLink, this.configurations.JiraSettings.JiraBase, jiraTaskId), userName, password, null, HttpMethod.Get);

            return JiraResponse.FromJson(result)?.Fields?.Issuetype?.Name;
        }

        public string GetJiraSummary(string jiraTaskId, string userName, string password)
        {
            var result = this.requestHelper.CallUrl(string.Format(this.configurations.JiraSettings.JiraSummaryLink, this.configurations.JiraSettings.JiraBase, jiraTaskId), userName, password, null, HttpMethod.Get);

            return JiraResponse.FromJson(result)?.Fields?.Summary?.Trim();
        }
        

        public JiraPriority GetJiraPriority(string jiraTaskId, string userName, string password)
        {
            var result = this.requestHelper.CallUrl(string.Format(this.configurations.JiraSettings.JiraPriorityLink, this.configurations.JiraSettings.JiraBase, jiraTaskId), userName, password, null, HttpMethod.Get);

            return Utility.GetValueFromDescription<JiraPriority>(JiraResponse.FromJson(result)?.Fields?.Priority?.Name?.Trim());
        }

        public int GetJiraStoryPoints(string jiraTaskId, string userName, string password)
        {
            var data = this.requestHelper.CallUrl(string.Format(this.configurations.JiraSettings.JiraStoryPointLink, this.configurations.JiraSettings.JiraBase, jiraTaskId, this.configurations.JiraSettings.StoryPointField), userName, password, null, HttpMethod.Get);

            var result = JsonConvert.DeserializeObject<JiraResponse>(data,
                new JsonSerializerSettings { ContractResolver = new CustomDataContractResolver(typeof(Fields),nameof(Fields.StoryPoint), this.configurations.JiraSettings.StoryPointField)});
            return Convert.ToInt32(Convert.ToDouble(result?.Fields?.StoryPoint));
        }

        public bool ChangeStatus(Transitions status, string jiraTasId, string userName, string password)
        {
            Dictionary<string, Tuple<object, ParameterType>> parameters = new Dictionary<string, Tuple<object, ParameterType>>();
            parameters.Add("User-Agent", new Tuple<object, ParameterType>("random", ParameterType.HttpHeader));
            parameters.Add("Content-Type", new Tuple<object, ParameterType>("application/json", ParameterType.HttpHeader));
            parameters.Add("X-Atlassian-Token", new Tuple<object, ParameterType>("nocheck", ParameterType.HttpHeader));
            

            try
            {
                var req = PrepareStatusRequest(status);

                parameters.Add("body", new Tuple<object, ParameterType>(req, ParameterType.RequestBody));

                var result = this.requestHelper.CallUrl(string.Format(this.configurations.JiraSettings.JiraStatusChange, this.configurations.JiraSettings.JiraBase, jiraTasId), userName, password, parameters, HttpMethod.Post);

                if(status == Transitions.PullRequestAccepted)
                {
                    checkAndReAssign(jiraTasId, userName, password, this.configurations.StashSettings.QA);
                }

                return result == string.Empty;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void checkAndReAssign(string jiraTasId, string userName, string password, string assignee)
        {
            Dictionary<string, Tuple<object, ParameterType>> parameters = new Dictionary<string, Tuple<object, ParameterType>>();
            parameters.Add("User-Agent", new Tuple<object, ParameterType>("random", ParameterType.HttpHeader));
            parameters.Add("Content-Type", new Tuple<object, ParameterType>("application/json", ParameterType.HttpHeader));
            parameters.Add("X-Atlassian-Token", new Tuple<object, ParameterType>("nocheck", ParameterType.HttpHeader));

            var result = JiraAssigneeResponse.FromJson(this.requestHelper.CallUrl(string.Format(this.configurations.JiraSettings.JiraAssigneeDetails, this.configurations.JiraSettings.JiraBase, jiraTasId), userName, password, parameters, HttpMethod.Get));

            if(result?.Fields?.Assignee?.Name != assignee)
            {
                parameters.Add("assignee", new Tuple<object, ParameterType>("{\"name\":\"" + assignee +"\"}", ParameterType.RequestBody));

                var resultSet = this.requestHelper.CallUrl(string.Format(this.configurations.JiraSettings.JiraAssigneeSet, this.configurations.JiraSettings.JiraBase, jiraTasId), userName, password, parameters, HttpMethod.Put);

                this.logger.Info(resultSet);
            }
        }

        private string PrepareStatusRequest(Transitions status)
        {
            var req = new JiraStatusRequest();
            req.Transition = new Transition()
            {
                Id = (int)status
            };
            
            switch (status)
            {
                case Transitions.PullRequestAccepted:
                    req.Fields = new Fields()
                    {
                        Resolution = new Assignee(),
                        Assignee = new Assignee()
                    };

                    req.Fields.Resolution.Name = Resolutions.DoneOrFixed.ToDescriptionString();
                    req.Fields.Assignee.Name = this.configurations.StashSettings.QA;
                    break;
            }

            return req.ToJson();
        }
    }
}
