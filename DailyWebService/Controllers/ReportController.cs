using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.Contract;
using Common.Utils;
using DailyWebService.Models;

namespace DailyWebService.Controllers
{
    [Authorize]
    public class ReportController : ApiController
    {
        private readonly IReport report;
        private readonly IDataHelper dataHelper;
        private readonly IConfigurations configurations;
        public ReportController(IReport report, IDataHelper dataHelper, IConfigurations configurations)
        {
            this.report = report;
            this.dataHelper = dataHelper;
            this.configurations = configurations;
        }
        // GET api/<controller>
        // http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/aes.js  
        //CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(txtUserName), key,  
        //{
        //    keySize: 128 / 8,   
        //    iv: iv,  
        //    mode: CryptoJS.mode.CBC,  
        //    padding: CryptoJS.pad.Pkcs7
        //});  
        public bool SendStatusReport(ReportRequest reportRequest)
        {
            try
            {
                var username = Utility.DecryptStringAES(reportRequest.UserName);
                var password = Utility.DecryptStringAES(reportRequest.Password);

                this.report.GenerateAndSendReport(username, password, reportRequest.FromDate, reportRequest.ToDate, reportRequest.Users, reportRequest.NoCc, reportRequest.Token, reportRequest.UseLocal);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}