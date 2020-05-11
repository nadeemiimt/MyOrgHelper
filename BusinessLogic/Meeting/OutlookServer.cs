using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Contract;
using Common.Models;
using Common.Utils;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Identity.Client;

namespace BusinessLogic.Meeting
{
    public class OutlookServer : IMeeting
    {
        private readonly IConfigurations configurations;

        static ExchangeService service = null;

        public OutlookServer(IConfigurations configurations, Action action, string token)
        {
            this.configurations = configurations;
            SetServiceAsync(configurations, action, token);
        }

        private async System.Threading.Tasks.Task SetServiceAsync(IConfigurations configurations, Action action, string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                SetExchangeService(token);
            }
            else
            {
                // Configure the MSAL client to get tokens
                var pcaOptions = new PublicClientApplicationOptions
                {
                    ClientId = this.configurations.MeetingSettings.AppId,
                    TenantId = this.configurations.MeetingSettings.TenantId
                };

                var pca = PublicClientApplicationBuilder
                    .CreateWithApplicationOptions(pcaOptions).Build();

                var ewsScopes = new string[] {configurations.MeetingSettings.ScopeUrl};

                var authResult = await pca.AcquireTokenInteractive(ewsScopes)
                    .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
                    //          .WithUseEmbeddedWebView(true)
                    //      .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
                    .ExecuteAsync();

                this.SetExchangeService(authResult.AccessToken);
                action = action ?? SingletonAction.action; // required for Single Threaded app like winform
                await System.Threading.Tasks.Task.Factory.StartNew(() => action?.Invoke());
            }
        }

        private void SetExchangeService(string token)
        {
            service = new ExchangeService();
            service.Url = new Uri(configurations.MeetingSettings.ExchangeUrl);
            service.Credentials = new OAuthCredentials(token);
        }

        public async Task<IEnumerable<MeetingDataList>> SearchCalendarItemsAsync(DateTime startTime, DateTime endTime, bool excludeExpiredMeetings = false)
        {
            List<MeetingDataList> meetings = new List<MeetingDataList>();
            if (service != null)
            {
                // Set the start and end time and number of appointments to retrieve.
                CalendarView cView = new CalendarView(startTime, endTime);

                // Send the request to search the SentItems and get the results.
                FindItemsResults<Appointment> findResults = service.FindAppointments(WellKnownFolderName.Calendar, cView);

                if (findResults?.Items?.Count > 0)
                {
                    // Identify the Body property to return so we can use it as a filter.
                    service.LoadPropertiesForItems(findResults.Items, new PropertySet(BasePropertySet.IdOnly, ItemSchema.Body, AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.End, AppointmentSchema.IsRecurring, AppointmentSchema.Location));
                    int id = 1;
                    foreach (var item in findResults)
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
                }
            }

            return meetings;
        }

        public void SendEmail(string subjectEmail, string toEmail, string ccEmail, string bodyEmail, bool isHtml)
        {
            if (service != null)
            {
                // Create an email message and provide it with connection 
                // configuration information by using an ExchangeService object named service.
                EmailMessage message = new EmailMessage(service);

                message.Subject = subjectEmail;

                string[] recips = toEmail.Split(',');

                foreach (string recip in recips)
                {
                    message.ToRecipients.Add(recip);
                }

                if (!string.IsNullOrWhiteSpace(ccEmail))
                {
                    string[] ccs = ccEmail.Split(',');

                    foreach (string cc in ccs)
                    {
                        message.CcRecipients.Add(cc);
                    }
                }

                message.Body = bodyEmail;

                if (!isHtml)
                {
                    message.Body.BodyType = BodyType.Text;
                }
                else
                {
                    message.Body.BodyType = BodyType.HTML;
                }

                message.Importance = Importance.Normal;

                // Send the email message and save a copy.
                // This method call results in a CreateItem call to EWS.
                message.SendAndSaveCopy();
            }
        }
    }
}
