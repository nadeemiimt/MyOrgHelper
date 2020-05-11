using RazorEngine;
using RazorEngine.Templating; // For extension methods.
using System;
using System.IO;
using System.Linq;
using System.Security.Principal;
using Common.Contract;
using BusinessLogic.Meeting;
using Common.Models;
using Common.Utils;
using Unity;
using Unity.Resolution;

namespace BusinessLogic.Report
{
    public class ReportGenerator : IReport
    {
        private readonly IStatusHelper statusHelper;
        private readonly IConfigurations configurations;
        private readonly IUnityContainer unityContainer;

        public ReportGenerator(IUnityContainer unityContainer, IConfigurations configurations, IStatusHelper statusHelper)
        {
            this.configurations = configurations;
            this.statusHelper = statusHelper;
            this.unityContainer = unityContainer;
        }

        /// <summary>
        /// Generate status report with multiple options.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="sendEmail"></param>
        /// <param name="noCc"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="users"></param>
        /// <param name="generatePdf"></param>
        /// <param name="openInBrowser"></param>
        /// <param name="location"></param>
        /// <param name="pdfName"></param>
        /// <param name="useLocal"></param>
        public void GenerateStatusReport(string userName, string password, bool sendEmail, bool noCc, DateTime? fromDate, DateTime? toDate, string[] users, bool generatePdf, bool openInBrowser, string location, string pdfName, bool useLocal)
        {
            var html = GenerateReportHtml(userName, password, fromDate, toDate, users);

            if (sendEmail && !string.IsNullOrWhiteSpace(html) && html?.Length > 20)
            {
                SendEmail(html, this.configurations.MeetingSettings.StatusRecepientTo, this.configurations.MeetingSettings.StatusRecepientCC, useLocal, noCc);
            }

            if (generatePdf)
            {
                GeneratePdf(location, pdfName, html);
            }

            if (openInBrowser)
            {
                OpenInBrowser(html);
            }
        }

        public void GenerateAndSendReport(string userName, string password, DateTime? fromDate, DateTime? toDate, string[] users, bool noCc, string token, bool useLocal = false)
        {
            var html = GenerateReportHtml(userName, password, fromDate, toDate, users);
            SendEmail(html, this.configurations.MeetingSettings.StatusRecepientTo, this.configurations.MeetingSettings.StatusRecepientCC, useLocal, noCc, token);
        }

        public string GenerateReportHtml(string userName, string password, DateTime? fromDate, DateTime? toDate, string[] users)
        {
            var data = new StatusDataModel();

            data.Status = this.statusHelper.GetStatus(userName, password, fromDate, toDate, users).OrderByDescending(x => x.JiraTaskId).ToList();
            data.JiraTaskIdentifier = this.configurations.JiraSettings.JiraTaskIdentifier;
            data.JiraBase = this.configurations.JiraSettings.JiraBase;
            data.EnableStoryPoints = this.configurations.ReportSettings.EnableStoryPoints;

            return GetReportData(data);
        }

        public byte[] GenerateReportPdf(string userName, string password, DateTime? fromDate, DateTime? toDate, string[] users)
        {
            var data = new StatusDataModel();

            data.Status = this.statusHelper.GetStatus(userName, password, fromDate, toDate, users).OrderByDescending(x => x.JiraTaskId).ToList();
            data.JiraTaskIdentifier = this.configurations.JiraSettings.JiraTaskIdentifier;
            data.JiraBase = this.configurations.JiraSettings.JiraBase;
            data.EnableStoryPoints = this.configurations.ReportSettings.EnableStoryPoints;

            var html = GetReportData(data);

            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            return htmlToPdf.GeneratePdf(html);
        }

        public string GetReportData(StatusDataModel data, string reportPath = null, string reportName =null)
        {
            if (string.IsNullOrWhiteSpace(reportPath))
            {
                var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                reportPath = System.IO.Path.GetDirectoryName(path);
            }

            return RunCompile(reportPath, reportName ?? this.configurations.ReportSettings.StatusReportTemplate, null, data);
        }

        /// <summary>
        /// Code to open report in browser.
        /// </summary>
        /// <param name="html"></param>
        private void OpenInBrowser(string html)
        {
            string filename = string.Format(@"{0}\{1}",
                    System.IO.Path.GetTempPath(),
                    $"test{DateTime.Now.Ticks}.html");
            File.WriteAllText(filename, html);
            System.Diagnostics.Process.Start(filename);
            //  File.Delete(filename);
        }

        /// <summary>
        /// Code to generate pdf.
        /// </summary>
        /// <param name="folderLoc"></param>
        /// <param name="fileName"></param>
        /// <param name="html"></param>
        public void GeneratePdf(string folderLoc, string fileName, string html)
        {
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(html);
            if (!fileName.ToUpper().Contains(".PDF"))
            {
                fileName = $"{fileName}.pdf";
            }
            var path = Path.Combine(folderLoc, fileName);
            File.WriteAllBytes(path, pdfBytes);

            System.Diagnostics.Process.Start(path);
        }

        /// <summary>
        /// code to senr report on email.
        /// </summary>
        /// <param name="textHtml"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="useLocal"></param>
        /// <param name="noCC"></param>
        /// <param name="token"></param>
        public void SendEmail(string textHtml, string to, string cc, bool useLocal, bool noCC, string subject = null, string token = null)
        {
            IMeeting meeting = useLocal ? this.unityContainer.Resolve<IMeeting>(Constants.LocalOutlook) : this.unityContainer.Resolve<IMeeting>(Constants.ExchangeServer, new ParameterOverride("action", null), new ParameterOverride("token", token));

            cc = noCC ? string.Empty : cc;

            if(!useLocal && string.IsNullOrWhiteSpace(token))
            {
                SingletonAction.action = GetAction(textHtml, to, cc, meeting);
            }
            else
            {
                meeting.SendEmail(subject ?? this.configurations.MeetingSettings.SendStatusSubject, to, cc, textHtml, true);
            }
            
        }

        private Action GetAction(string textHtml, string to, string cc, IMeeting meeting)
        {
            return new System.Action(() =>
             {
                 meeting.SendEmail(this.configurations.MeetingSettings.SendStatusSubject, to, cc, textHtml, true);
             });
        }

        /// <summary>
        /// Generate an HTML document from the specified Razor template and model.
        /// </summary>
        /// <param name="rootpath">The path to the folder containing the Razor templates</param>
        /// <param name="templatename">The name of the Razor template (.cshtml)</param>
        /// <param name="templatekey">The template key used for caching Razor templates which is essential for improved performance</param>
        /// <param name="model">The model containing the information to be supplied to the Razor template</param>
        /// <returns></returns>
        public string RunCompile(string rootpath, string templatename, string templatekey, object model)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(rootpath) || string.IsNullOrEmpty(templatename) || model == null) return result;

            string templateFilePath = Path.Combine(rootpath, templatename);

            if (File.Exists(templateFilePath))
            {
                string template = File.ReadAllText(templateFilePath);

                if (string.IsNullOrEmpty(templatekey))
                {
                    templatekey = Guid.NewGuid().ToString();
                }
                result = Engine.Razor.RunCompile(template, templatekey, null, model);
            }
            return result;
        }
    }
}
