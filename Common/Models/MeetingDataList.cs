namespace Common.Models
{
    using System;
    using System.Linq;

    public class MeetingDataList
    {
        public int Id { get; set; }
        public string MeetingTitle { get; set; }
        public bool IsRecurring { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime MyStartTime { get; set; }
        public DateTime MeetingEndTime { get; set; }
        private string MeetingHelper { get { return !string.IsNullOrWhiteSpace(Link) ? Link.Split(',').OrderByDescending(s => s.Length).FirstOrDefault() : Link; } }
        public string MeetingId => !string.IsNullOrWhiteSpace(MeetingHelper) 
                                  ? MeetingHelper.Contains("?") ? new String(MeetingHelper.Substring(MeetingHelper.LastIndexOf("/", StringComparison.Ordinal) + 1, MeetingHelper.LastIndexOf("?") - MeetingHelper.LastIndexOf("/") - 1).Where(Char.IsDigit).ToArray())
                                                                : new String(MeetingHelper.Substring(MeetingHelper.LastIndexOf("/", StringComparison.Ordinal) + 1).Where(Char.IsDigit).ToArray())
                                  : null;
        public string Password => !string.IsNullOrWhiteSpace(MeetingHelper) && MeetingHelper.Contains("?") ? MeetingHelper.Substring(MeetingHelper.LastIndexOf("?", StringComparison.Ordinal) + 5).Replace(",", string.Empty) : null;
    }
}
