using System;
using Common.Models;

namespace Common.Contract
{
    public interface IReport
    {
        /// <summary>
        /// Get report
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="sendEmail"></param>
        /// <param name="generatePdf"></param>
        /// <param name="openInBrowser"></param>
        /// <param name="location"></param>
        /// <param name="pdfName"></param>
        /// <param name="useLocal"></param>
        void GenerateStatusReport(string userName, string password, bool sendEmail, bool noCc, DateTime? fromDate, DateTime? toDate, string[] users, bool generatePdf, bool openInBrowser, string location, string pdfName, bool useLocal);

        /// <summary>
        /// Generate an HTML document from the specified Razor template and model.
        /// </summary>
        /// <param name="rootpath">The path to the folder containing the Razor templates</param>
        /// <param name="templatename">The name of the Razor template (.cshtml)</param>
        /// <param name="templatekey">The template key used for caching Razor templates which is essential for improved performance</param>
        /// <param name="model">The model containing the information to be supplied to the Razor template</param>
        /// <returns></returns>
        string RunCompile(string rootpath, string templatename, string templatekey, object model);

        /// <summary>
        /// Code to generate pdf.
        /// </summary>
        /// <param name="folderLoc"></param>
        /// <param name="fileName"></param>
        /// <param name="html"></param>
        void GeneratePdf(string folderLoc, string fileName, string html);

        /// <summary>
        /// Get html data
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        string GenerateReportHtml(string userName, string password, DateTime? fromDate, DateTime? toDate, string[] users);

        /// <summary>
        /// Generate pdf.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        byte[] GenerateReportPdf(string userName, string password, DateTime? fromDate, DateTime? toDate, string[] users);

        /// <summary>
        /// GenerateAndSendReport
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="users"></param>
        /// <param name="useLocal"></param>
        /// <param name="token"></param>
        /// <param name="noCc"></param>
        void GenerateAndSendReport(string userName, string password, DateTime? fromDate, DateTime? toDate, string[] users, bool noCc, string token, bool useLocal = false);

        string GetReportData(StatusDataModel data, string reportPath = null, string reportName = null);

        void SendEmail(string textHtml, string to, string cc, bool useLocal, bool noCC, string subject = null,
            string token = null);
    }
}
