using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailyWebService.Models
{
    public class ReportRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string[] Users { get; set; }
        public bool NoCc { get; set; }
        public string Token { get; set; }
        public bool UseLocal { get; set; }
    }
}