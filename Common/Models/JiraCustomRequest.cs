using System;
using System.ComponentModel;

namespace Common.Models
{
    public class JiraCustomRequest
    {
        public JiraType JiraType { get; set; }

        public JiraStatus JiraStatus { get; set; }

        public DateTime? FromDate { get; set; }

        public string From { get {
                return FromDate?.ToString("yyyy-MM-dd");
            } }

        public DateTime? ToDate { get; set; }

        public string To
        {
            get
            {
                return FromDate?.ToString("yyyy-MM-dd");
            }
        }

        public string ProjectName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string JiraQuery { get; set; }
    }
}
