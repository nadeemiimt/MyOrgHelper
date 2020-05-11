using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net.Http;
using Common.Contract;
using Common.Models;
using Common.Utils;
using HtmlAgilityPack;
using log4net;
using Newtonsoft.Json;
using RestSharp;

namespace BusinessLogic.Report
{
    public class ConfluencePageHelper : IConfluencePageHelper
    {
        private readonly IHttpRequestHelper httpRequestHelper;
        private readonly IConfigurations configurations;
        private readonly IJiraTracker jiraTracker;
        private readonly IJiraStatusHelper jiraStatusHelper;
        private readonly IReport report;
        private readonly ILog logger;
        public ConfluencePageHelper(IHttpRequestHelper httpRequestHelper, IConfigurations configurations, IJiraTracker jiraTracker, IJiraStatusHelper jiraStatusHelper, IReport report, ILog logger)
        {
            this.httpRequestHelper = httpRequestHelper;
            this.configurations = configurations;
            this.jiraTracker = jiraTracker;
            this.jiraStatusHelper = jiraStatusHelper;
            this.report = report;
            this.logger = logger;
        }

        /// <summary>
        /// Get confluence page record.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="pageId"></param>
        /// <returns></returns>
        public ConfluencePageResponse GetConfluencePage(string userName, string password, string pageId)
        {
            Dictionary<string, Tuple<object, ParameterType>> parameters = new Dictionary<string, Tuple<object, ParameterType>>();
            parameters.Add("Content-Type", new Tuple<object, ParameterType>("application/json", ParameterType.HttpHeader));
            var result = this.httpRequestHelper.CallUrl(string.Format(this.configurations.ReportSettings.ConfluencePageApiUrl, this.configurations.ReportSettings.ConfluenceBase, pageId), userName, password, parameters, HttpMethod.Get);

            return ConfluencePageResponse.FromJson(result);
        }

        /// <summary>
        /// Update confluence page.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="pageId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public ConfluencePageResponse UpdateConfluencePage(string userName, string password, string pageId, ConfluencePageResponse request)
        {
            Dictionary<string, Tuple<object, ParameterType>> parameters = new Dictionary<string, Tuple<object, ParameterType>>();
            parameters.Add("User-Agent", new Tuple<object, ParameterType>("random", ParameterType.HttpHeader));
            parameters.Add("Content-Type", new Tuple<object, ParameterType>("application/json;charset=UTF-8", ParameterType.HttpHeader));
            parameters.Add("X-Atlassian-Token", new Tuple<object, ParameterType>("nocheck", ParameterType.HttpHeader));

            parameters.Add("body", new Tuple<object, ParameterType>(JsonConvert.SerializeObject(request), ParameterType.RequestBody));

            var result = this.httpRequestHelper.CallUrl(string.Format(this.configurations.ReportSettings.ConfluencePageApiUrl.Split(new[] { '?' })[0], this.configurations.ReportSettings.ConfluenceBase, pageId), userName, password, parameters, HttpMethod.Put);

            return ConfluencePageResponse.FromJson(result);
        }

        /// <summary>
        /// This method updates a confluence table having some jql used for alert.
        /// Can be used with a service to get the latest bugs or tasks.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="useLocalOutlook"></param>
        /// <param name="token"></param>
        public void SendAlertForStatusChange(string userName, string password, bool useLocalOutlook, string token = null)
        {
            var alertPageId = this.configurations.ReportSettings.AlertPageId;

            var pageData = this.GetConfluencePage(userName, password, alertPageId);

            var doc = new HtmlDocument();
            doc.OptionWriteEmptyNodes = true; // imp
            doc.LoadHtml(pageData?.Body?.Storage?.Value);

            var rows = doc.DocumentNode
                .SelectNodes("//tr")
                .Skip(1) // header
                .Where(tr => tr.Elements("td").Count() > 1);

            foreach (var row in rows)
            {
                var columns = row.Elements("td").ToList();
                var emails = string.Join(",",Utility.ExtractEmails(columns[2].InnerHtml).Distinct());
                var alertRequest = new AlertRequestModel(columns[0].InnerText, columns[1].InnerText, emails, columns[3].InnerText, Convert.ToInt32(columns[4].InnerText), columns[5].InnerText, columns[6].InnerText, columns[7].InnerText);

                var jiraTickets =
                    this.jiraTracker.GetJiraCustomSearchResult(new JiraCustomRequest() {JiraQuery = alertRequest.Jql},
                        userName, password);

                var getCurrentTickets = jiraTickets.Issues.Select(x => x.Key).OrderByDescending(x => x).ToList();
                var oldTickets = string.IsNullOrWhiteSpace(alertRequest.PreviousRunTasks) ? null : alertRequest.PreviousRunTasks.Split(',').OrderByDescending(x=>x).ToList();

                var newlyAddedTickets = oldTickets?.Count > 0 ? getCurrentTickets.Where(p => oldTickets.All(p2 => p2 != p)).ToList() : getCurrentTickets;
                var existingTickets = newlyAddedTickets?.Count > 0 ? getCurrentTickets.Where(p => newlyAddedTickets.All(p2 => p2 != p)).ToList() : getCurrentTickets;

                var currentRunTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");

                var previousRunTime = alertRequest.PreviousRunTime;

                var frequency = alertRequest.Frequency;

                if (newlyAddedTickets?.Count > 0 && (frequency < 7 || DateTime.Now.DayOfWeek.ToString() == alertRequest.DayOfWeek) && string.IsNullOrWhiteSpace(previousRunTime)) // today is the day or frequency is less than week and some tasks are there // Not Run
                {
                    GetTaskAndSendEmail(newlyAddedTickets, userName, password, useLocalOutlook, columns, currentRunTime, alertRequest.AlertType, alertRequest.Audience, token);
                }
                else if (getCurrentTickets?.Count > 0 && (frequency < 7  || DateTime.Now.DayOfWeek.ToString() == alertRequest.DayOfWeek)) // today is the day or frequency is less than week and some tasks are there
                {
                    if ((DateTime.Parse(currentRunTime).Date - DateTime.Parse(previousRunTime).Date).TotalDays >=
                             frequency)
                    {
                        GetTaskAndSendEmail(existingTickets, userName, password, useLocalOutlook, columns, currentRunTime, alertRequest.AlertType, alertRequest.Audience, token, newlyAddedTickets);
                    }
                }
                else
                {
                    columns[7].InnerHtml = currentRunTime;
                }
            }

            var document = doc.DocumentNode.InnerHtml;

            pageData.Version.Number = pageData.Version.Number + 1;
            pageData.Body.Storage.Value = document;

            var response = this.UpdateConfluencePage(userName, password, alertPageId, pageData);
        }

        private void GetTaskAndSendEmail(List<string> tasks, string userName, string password, bool useLocalOutlook, List<HtmlNode> columns, string currentRunTime, string subject, string recipient, string token, List<string> newTasks = null)
        {
            List<JiraStatusDto> finalResult = new List<JiraStatusDto>();

            foreach (var task in tasks)
            {
                JiraStatusDto dto = new JiraStatusDto(task);
                this.jiraStatusHelper.LoadJiraStatusDto(userName, password, dto);
                finalResult.Add(dto);
            }

            if (newTasks?.Count > 0)
            {
                foreach (var task in newTasks)
                {
                    JiraStatusDto dto = new JiraStatusDto(task);
                    dto.IsNew = true;
                    this.jiraStatusHelper.LoadJiraStatusDto(userName, password, dto);
                    finalResult.Add(dto);
                }
            }

            finalResult = finalResult.OrderByDescending(x => x.JiraTaskId).ToList();

            var currentTasks = string.Join(",", finalResult.Select(x=>x.JiraTaskId).OrderByDescending(x => x));

            if (string.IsNullOrWhiteSpace(columns[6].InnerText))
            {
                columns[5].InnerHtml = currentTasks;
            }
            else
            {
                columns[5].InnerHtml = columns[6].InnerHtml;
            }

            columns[6].InnerHtml = currentTasks;

            columns[7].InnerHtml = currentRunTime;

            var data = new StatusDataModel();

            data.Status = finalResult;
            data.EnableStoryPoints = true;
            data.JiraTaskConfluencePage = string.Format(this.configurations.ReportSettings.ConfluencePageUrl, this.configurations.ReportSettings.ConfluenceBase);
            data.IsJiraTaskAlert = true;
            data.JiraTaskIdentifier = this.configurations.JiraSettings.JiraTaskIdentifier;
            data.JiraBase = this.configurations.JiraSettings.JiraBase;
            data.EnableStoryPoints = this.configurations.ReportSettings.EnableStoryPoints;

            var html = this.report.GetReportData(data);
            try
            {
                this.report.SendEmail(html, recipient, null, useLocalOutlook, true, subject, token);
            }
            catch (Exception e)
            {
                this.logger.Error(e);
            }
        }
    }
}
