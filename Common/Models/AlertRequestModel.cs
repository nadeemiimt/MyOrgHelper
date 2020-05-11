using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class AlertRequestModel
    {
        public AlertRequestModel(string alertType, string jql, string audience, string dayOfWeek, int frequency, string previousRunTasks, string currentTasks, string previousRunTime)
        {
            this.AlertType = alertType;
            this.Jql = jql;
            this.Audience = audience;
            this.DayOfWeek = dayOfWeek;
            this.Frequency = frequency;
            this.PreviousRunTasks = previousRunTasks;
            this.CurrentTasks = currentTasks;
            this.PreviousRunTime = previousRunTime;
        }
        public string AlertType { get; set; }
        public string Jql { get; set; }
        public string Audience { get; set; }
        public string DayOfWeek { get; set; }
        public int Frequency { get; set; }
        public string PreviousRunTasks { get; set; }
        public string CurrentTasks { get; set; }
        public string PreviousRunTime { get; set; }
    }
}
