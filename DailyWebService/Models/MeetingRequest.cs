using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailyWebService.Models
{
    public class MeetingRequest
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsLocal { get; set; }
        public string MeetingToken { get; set; }
    }
}