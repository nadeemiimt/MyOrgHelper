using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using Common.Contract;
using Common.Models;
using Common.Utils;
using log4net;
using Newtonsoft.Json;
using RestSharp;

namespace BusinessLogic.Stash
{
    public class StashHelper : IStashProvider
    {
        private readonly IHttpRequestHelper requestHelper;
        private readonly IConfigurations configurations;
        private readonly ILog logger;

        public StashHelper(IConfigurations configurations, IHttpRequestHelper requestHelper, ILog logger)
        {
            this.configurations = configurations;
            this.requestHelper = requestHelper;
            this.logger = logger;
        }

        public List<Value> GetPrList(string userName, string password)
        {
            var result = this.requestHelper.CallUrl(string.Format(this.configurations.StashSettings.StashPRsLink, this.configurations.StashSettings.StashBase), userName, password, null, HttpMethod.Get);

            return StashPrResponse.FromJson(result)?.Values;
        }

        public List<Value> GetCustomPrList(string userName, string password, string[] prs)
        {
            List<Value> values = new List<Value>();
            foreach (var pr in prs)
            {
                string result = string.Empty;

                if(Utility.IsJiraTicket(pr))
                {
                    var jiraId = JiraIdResponse.FromJson(this.requestHelper.CallUrl(string.Format(this.configurations.JiraSettings.GetJiraId, this.configurations.JiraSettings.JiraBase, pr), userName, password, null, HttpMethod.Get)).Id;            

                    var stashPrIds = JiraPrResponse.FromJson(this.requestHelper.CallUrl(string.Format(this.configurations.JiraSettings.GetJiraPRs, this.configurations.JiraSettings.JiraBase, jiraId), userName, password, HttpMethod.Get, false)).Detail.SelectMany(x=>x.PullRequests).Select(x=>x.Id).ToList();

                    Thread.Sleep(1000);
                    foreach (var item in stashPrIds)
                    {
                        result = this.requestHelper.CallUrl(string.Format(this.configurations.StashSettings.CustomStashPullRequests, this.configurations.StashSettings.StashBase, this.configurations.StashSettings.StashProject, this.configurations.StashSettings.StashRepo, item.Replace("#", string.Empty)), userName, password, null, HttpMethod.Get);
                        values.Add(Value.FromJson(result));
                        Thread.Sleep(300);
                    }
                }
                else
                {
                    result = this.requestHelper.CallUrl(string.Format(this.configurations.StashSettings.CustomStashPullRequests, this.configurations.StashSettings.StashBase, this.configurations.StashSettings.StashProject, this.configurations.StashSettings.StashRepo, pr), userName, password, null, HttpMethod.Get);
                    values.Add(Value.FromJson(result));
                }
            }

            return values;
        }

        public StashOverviewResponse GetPrSummary(string userName, string password, long prId)
        {
            var result = this.requestHelper.CallUrl(string.Format(this.configurations.StashSettings.StashOverview, this.configurations.StashSettings.StashBase, this.configurations.StashSettings.StashProject, this.configurations.StashSettings.StashRepo, prId), userName, password, null, HttpMethod.Get);

            return StashOverviewResponse.FromJson(result);
        }

        public StashMergeStatusResponse GetMergeDetails(string userName, string password, long prId)
        {
            var result = this.requestHelper.CallUrl(string.Format(this.configurations.StashSettings.StashMerge, this.configurations.StashSettings.StashBase, this.configurations.StashSettings.StashProject, this.configurations.StashSettings.StashRepo, prId), userName, password, null, HttpMethod.Get);

            return StashMergeStatusResponse.FromJson(result);
        }

        public StashRebaseResponse RebasePR(string userName, string password, long prId, long version)
        {
            Dictionary<string, Tuple<object, ParameterType>> parameters = new Dictionary<string, Tuple<object, ParameterType>>();
            parameters.Add("User-Agent", new Tuple<object, ParameterType>("random", ParameterType.HttpHeader));
            parameters.Add("Content-Type", new Tuple<object, ParameterType>("application/json;charset=UTF-8", ParameterType.HttpHeader));
            parameters.Add("X-Atlassian-Token", new Tuple<object, ParameterType>("nocheck", ParameterType.HttpHeader));
            parameters.Add("body", new Tuple<object, ParameterType>(JsonConvert.SerializeObject(new StashVersion(version)), ParameterType.RequestBody));
            var result = this.requestHelper.CallUrl(string.Format(this.configurations.StashSettings.StashRebase, this.configurations.StashSettings.StashBase, this.configurations.StashSettings.StashProject, this.configurations.StashSettings.StashRepo, prId, version), userName, password, parameters, HttpMethod.Post);

            return StashRebaseResponse.FromJson(result);
        }

        public StashRebaseResponse ApprovePr(string userName, string password, long prId, long version)
        {
            Dictionary<string, Tuple<object, ParameterType>> parameters = new Dictionary<string, Tuple<object, ParameterType>>();
            parameters.Add("User-Agent", new Tuple<object, ParameterType>("random", ParameterType.HttpHeader));
            parameters.Add("Content-Type", new Tuple<object, ParameterType>("application/json;charset=UTF-8", ParameterType.HttpHeader));
            parameters.Add("X-Atlassian-Token", new Tuple<object, ParameterType>("nocheck", ParameterType.HttpHeader));
            parameters.Add("body", new Tuple<object, ParameterType>(JsonConvert.SerializeObject(new StashVersion(version)), ParameterType.RequestBody));
            var result = this.requestHelper.CallUrl(string.Format(this.configurations.StashSettings.StashApprove, this.configurations.StashSettings.StashBase, this.configurations.StashSettings.StashProject, this.configurations.StashSettings.StashRepo, prId, version), userName, password, parameters, HttpMethod.Post);

            return StashRebaseResponse.FromJson(result);
        }

        public StashMergedResponse MergePR(string userName, string password, long prId, long version)
        {
            Dictionary<string, Tuple<object, ParameterType>> parameters = new Dictionary<string, Tuple<object, ParameterType>>();
            parameters.Add("User-Agent", new Tuple<object, ParameterType>("random", ParameterType.HttpHeader));
            parameters.Add("X-Atlassian-Token", new Tuple<object, ParameterType>("nocheck", ParameterType.HttpHeader));
            var url = string.Format(this.configurations.StashSettings.StashMergePost, this.configurations.StashSettings.StashBase, this.configurations.StashSettings.StashProject, this.configurations.StashSettings.StashRepo, prId, version);
            this.logger.Info(url);
            var result = this.requestHelper.CallUrl(url, userName, password, parameters, HttpMethod.Post);
            this.logger.Info(result);
            return result.IsValidJson() ? StashMergedResponse.FromJson(result) : throw new Exception(result);
        }
    }
}
