namespace Common.Models
{
    using System;
    using System.Collections.Generic;

    public class ConfluenceTableData
    {
        public DateTime? Date { get; set; }
        public List<string> PreviousDay { get; set; }
        public List<string> Today { get; set; }
    }
}
