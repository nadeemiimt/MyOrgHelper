using Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Contract
{
    public interface IMeeting
    {
        Task<IEnumerable<MeetingDataList>> SearchCalendarItemsAsync(DateTime startTime, DateTime endTime, bool excludeExpiredMeetings = false);

        void SendEmail(string subjectEmail, string toEmail, string ccEmail, string bodyEmail, bool isHtml);
    }
}
