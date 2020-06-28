using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Http;
using Common.Contract;
using Common.Models;

namespace BusinessLogic.Report
{
    public class StatusHelper : IStatusHelper
    {
        private readonly IHttpRequestHelper requestHelper;
        private readonly IConfigurations configurations;
        private readonly IJiraStatusHelper jiraStatusHelper;


        public StatusHelper(IConfigurations configurations, IHttpRequestHelper requestHelper, IJiraStatusHelper jiraStatusHelper)
        {
            this.configurations = configurations;
            this.requestHelper = requestHelper;
            this.jiraStatusHelper = jiraStatusHelper;
        }

        /// <summary>
        /// Get status.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<JiraStatusDto> GetStatus(string userName, string password, DateTime? fromDate, DateTime? toDate, string[] users)
        {
            List<string> tasks = new List<string>();
            DateTime today = toDate ?? DateTime.Today;
            DateTime previousDay = toDate ?? DateTime.Today;
            DateTime lastStatusDay = toDate != null ? toDate.Value.AddDays(-1) :DateTime.Today.AddDays(-1);
            var reportFreq = (fromDate != null && toDate != null) ? (toDate.Value - fromDate.Value).Days : this.configurations.ReportSettings.ReportFrequency;
            int count = 1;
            var day = toDate != null ? toDate.Value.DayOfWeek :(DayOfWeek)this.configurations.ReportSettings.LastStatusDayIndex;

            while (lastStatusDay.DayOfWeek != day)
            {
                lastStatusDay = lastStatusDay.AddDays(-1);
                count = count + 1;
            }

            if(count >= reportFreq)
            {                
                previousDay = previousDay.AddDays(-1 * count);
            }
            else
            {
                count = count + reportFreq;
                previousDay = previousDay.AddDays(-1 * (count));
            }

            var userData = users != null ? users : this.configurations.ReportSettings.Users.Split(',');
            var data = GetConfluenceStatus(userName, password, userData, count);
            var ignoreData = data.Where(x => x.Date == previousDay).ToList();  // ignore previous day of previous report previous day work
            if(ignoreData?.Count > 0)
            {
                foreach (var data1 in ignoreData)
                {
                    data1.PreviousDay = null;
                }                
            }

            var actualData = data.Where(x => x.Date <= today && x.Date >= previousDay);

            foreach (var status in actualData)
            {
                var previousDayData = status.PreviousDay?.Where(x => x != null).ToList();
                if(previousDayData?.Count > 0)
                {
                    tasks.AddRange(previousDayData);
                }

                var todayData = status.Today?.Where(x => x != null).ToList();
                if (todayData?.Count > 0)
                {
                    tasks.AddRange(todayData);
                }
            }

            tasks = tasks.Distinct().ToList();  // get all distinct tasks
            List<JiraStatusDto> finalResult = new List<JiraStatusDto>();

            foreach (var task in tasks)
            {
                JiraStatusDto dto = new JiraStatusDto(task);
                this.jiraStatusHelper.LoadJiraStatusDto(userName, password, dto);
                finalResult.Add(dto);
            }

            return finalResult;
        }

        /// <summary>
        /// get confluence status of each user.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="users"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<ConfluenceTableData> GetConfluenceStatus(string userName, string password, string[] users, int count)
        {
            try
            {
                List<ConfluenceTableData> allData = new List<ConfluenceTableData>();
                foreach (var user in users)
                {
                    var result = this.requestHelper.CallUrl(string.Format(this.configurations.ReportSettings.ConfluenceUserStatusLink, this.configurations.ReportSettings.ConfluenceBase, user), userName, password, null, HttpMethod.Get);

                    allData.AddRange(ExtractResults(result, count));
                }

                return allData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// extract result from html page.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<ConfluenceTableData> ExtractResults(string html, int count)
        {
            var confluenceTableRows = new List<ConfluenceTableData>();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            List<List<string>> table = doc.DocumentNode.SelectSingleNode(this.configurations.ReportSettings.ConfluenceTableSelector)
                        .Descendants("tr")
                        .Skip(1)  // header
                        .Take(count)
                        .Where(tr => tr.Elements("td").Count() > 1)
                        .Select(tr => tr.Elements("td").Select(td => td?.InnerText?.Trim()).ToList())
                        .ToList();
                        
            foreach (var row in table)
            {
                var confluenceTableRow = new ConfluenceTableData();

                confluenceTableRow.Date = GuessDateFromDateColumn(row[0]);
                confluenceTableRow.PreviousDay = GetJiraTickets(row[1]);
                confluenceTableRow.Today = GetJiraTickets(row[2]);
                // ignore other values

                confluenceTableRows.Add(confluenceTableRow);
            }

            return confluenceTableRows;
        }

        /// <summary>
        /// Guess date from date column.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private DateTime? GuessDateFromDateColumn(string date)
        {
            if(string.IsNullOrWhiteSpace(date))
            {
                return null;
            }

            var data = date.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;
            var previousYear = DateTime.Now.AddYears(-1).Year;

            string sMonthName = data[1];
            //sMonthName = "January"; 
            int iMonthNo = Convert.ToDateTime("01-" + sMonthName + "-2011").Month;

            // Match anything that is NOT a digit 
            string splitPattern = @"[^\d]";

            // Split approach: split on the pattern and exclude the match, hence the reverse logic of 
            // matching on anything that is NOT a digit 
            string[] results = Regex.Split(data[0], splitPattern);

            StringBuilder sb = new StringBuilder();

            foreach (string s in results)
            {
                sb.Append(s);
            }

            int dateNo = Int32.Parse(sb.ToString());
            var year = iMonthNo > currentMonth ? previousYear : currentYear;
            return new DateTime(year, iMonthNo, dateNo);
        }

        /// <summary>
        /// Get jira tickets.
        /// </summary>
        /// <param name="taskColumn"></param>
        /// <returns></returns>
        private List<string> GetJiraTickets(string taskColumn)
        {
            if(string.IsNullOrWhiteSpace(taskColumn))
            {
                return null;
            }

            var result = new List<string>();
            string taskPattern = @"\bCMCM-\d{6}|\bCONSVR-\d{4}|\bESC-\d{5}";

            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(taskColumn, taskPattern, options))
            {
                result.Add(m?.Value);
            }

            string otherTaskPattern = "(?i)" + this.configurations.ReportSettings.CustomTask + @"(.*?)(?=[.])";

            foreach (Match m in Regex.Matches(taskColumn, otherTaskPattern, options))
            {
                result.Add(m?.Groups[1]?.Value);
            }

            return result;
        }
    }
}
