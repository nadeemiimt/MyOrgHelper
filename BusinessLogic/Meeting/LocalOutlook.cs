using Common.Contract;
using Common.Models;
using Common.Utils;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Meeting
{
    public class LocalOutlook : IMeeting
    {
        private readonly IConfigurations configurations;

        public LocalOutlook(IConfigurations configurations)
        {
            this.configurations = configurations;
        }

        public async Task<IEnumerable<MeetingDataList>> SearchCalendarItemsAsync(DateTime startTime, DateTime endTime, bool excludeExpiredMeetings = false)
        {
            return GetAllCalendarItems(startTime, endTime, excludeExpiredMeetings);
        }

        public void SendEmail(string subjectEmail, string toEmail, string ccEmail, string bodyEmail, bool isHtml)
        {
            MailItem eMail = (MailItem)
                new Application().CreateItem(OlItemType.olMailItem);
            eMail.Subject = subjectEmail;

            string[] recips = toEmail.Split(',');
            Microsoft.Office.Interop.Outlook.Recipients oRecipsTo = (Microsoft.Office.Interop.Outlook.Recipients)eMail.Recipients;

            foreach (string recip in recips)
            {
                Recipient oTORecip = oRecipsTo.Add(recip);
                oTORecip.Type = (int)OlMailRecipientType.olTo;
                oTORecip.Resolve();
            }

            // eMail.To = toEmail;
            if (!string.IsNullOrWhiteSpace(ccEmail))
            {
                string[] ccs = ccEmail.Split(',');
                Microsoft.Office.Interop.Outlook.Recipients oRecipsCC = (Microsoft.Office.Interop.Outlook.Recipients)eMail.Recipients;

                foreach (string cc in ccs)
                {
                    Recipient oCCRecip = oRecipsCC.Add(cc);
                    oCCRecip.Type = (int)OlMailRecipientType.olCC;
                    oCCRecip.Resolve();
                }
                //  eMail.CC = ccEmail;
            }
            if (!isHtml)
                eMail.Body = bodyEmail;

            eMail.BodyFormat = OlBodyFormat.olFormatHTML;

            if (isHtml)
                eMail.HTMLBody = bodyEmail;

            eMail.Importance = OlImportance.olImportanceNormal;
            ((_MailItem)eMail).Send();
        }

        private IEnumerable<MeetingDataList> GetAllCalendarItems(DateTime startTime, DateTime endTime, bool excludeExpiredMeetings = false)
        {
            int id = 1;
            List<MeetingDataList> meetings  = new List<MeetingDataList>();
            Application oApp = null;
            NameSpace mapiNamespace = null;
            MAPIFolder CalendarFolder = null;
            Items outlookCalendarItems = null;
            Items outlookFilteredCalendarItems = null;

            oApp = new Application();
            mapiNamespace = oApp.GetNamespace("MAPI");
            CalendarFolder = mapiNamespace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
            outlookCalendarItems = CalendarFolder.Items;
            outlookCalendarItems.IncludeRecurrences = true;
            outlookCalendarItems.Sort("[Start]");
            string filter = string.Empty;
            if(excludeExpiredMeetings)
            {
                filter = "[Start] >= '"
                                    + startTime.ToString("g")
                                    + "' AND [Start] <= '"
                                    + endTime.ToString("g") + "'"
                                    + "' AND [End] >= '"
                                    + startTime.ToString("g") + "'";
            }
            else
            {
                filter = "[Start] >= '"
                                    + startTime.ToString("g")
                                    + "' AND [Start] <= '"
                                    + endTime.ToString("g") + "'";
            }

            outlookFilteredCalendarItems = outlookCalendarItems.Restrict(filter);

            oApp = null;
            mapiNamespace = null;
            CalendarFolder = null;
            outlookCalendarItems = null;

            foreach (AppointmentItem item in outlookFilteredCalendarItems)
            {
                
                    meetings.Add(new MeetingDataList()
                    {
                        Id = id++,
                        MeetingTitle = item.Subject,
                        IsRecurring = item.IsRecurring,
                        Description = item.Body,
                        Location = item.Location,
                        Link = Utility.FigureOutLink(item.Location, item.Body, this.configurations.MeetingSettings.ZoomCallTip, this.configurations.MeetingSettings.SkypeCallTip),
                        MyStartTime = item.Start,
                        MeetingEndTime = item.End
                    });
            }

            outlookFilteredCalendarItems = null;

            return meetings;
        }

    }
}
