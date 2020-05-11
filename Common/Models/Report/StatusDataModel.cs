using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class StatusDataModel
    {
        public StatusDataModel()
        {
            this.Status = new List<JiraStatusDto>();
        }

        public string JiraTaskIdentifier { get; set; }
        public string JiraBase { get; set; }

        public bool EnableStoryPoints { get; set; }
        public bool IsJiraTaskAlert { get; set; }
        public string JiraTaskConfluencePage { get; set; }

        public List<JiraStatusDto> Status { get; set; }
    }
}
