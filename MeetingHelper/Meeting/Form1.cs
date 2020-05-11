using BusinessLogic.Meeting;
using Common.Contract;
using Common.Models;
using Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Unity;

namespace DailyHelper
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        int initialDurationRange = Convert.ToInt32(ConfigurationManager.AppSettings["InitialDurationInMinutes"]) / 2;
        int incrementInDays = Convert.ToInt32(ConfigurationManager.AppSettings["IncrementInDays"]) / 2;
        bool excludeExpiredMeetings = Convert.ToBoolean(ConfigurationManager.AppSettings["InitialDurationExcludeExpiredMeetings"]);

        private readonly IMeeting meeting;

        IEnumerable<MeetingDataList> meetingDataLists = new List<MeetingDataList>();

        private readonly IConfigurations configurations;

        public bool UseLocal { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Form1(IMeeting meeting, IConfigurations configurations)
        {
            this.Name = "Meeting Helper";
            this.meeting = meeting;
            this.configurations = configurations;
            ComboBox.CheckForIllegalCrossThreadCalls = false;
            TextBox.CheckForIllegalCrossThreadCalls = false;
            CheckBox.CheckForIllegalCrossThreadCalls = false;            

            InitializeComponent();            
        }

        public void Initialize()
        {
            if(!UseLocal)
            {
                SingletonAction.action = GetAction();              
            }

            GetCurrentMeeting();
        }

        private Action GetAction()
        {
            return new Action(() =>
            {
                this.meetingDataLists = this.meeting.SearchCalendarItemsAsync(fromDP.Value, toDP.Value, excludeExpiredMeetings).Result;
                if (excludeExpiredMeetings)
                {
                    meetingDataLists = meetingDataLists.Where(x => x.MeetingEndTime > DateTime.Now);
                }                

                SetDropdownValue();
            });
        }

        private void GetCurrentMeeting()
        {
            DateTime fromDate = DateTime.Now.AddMinutes(-1 * (initialDurationRange));
            DateTime toDate = DateTime.Now.AddMinutes(initialDurationRange);
            fromDP.Value = fromDate;
            toDP.Value = toDate;

            if (UseLocal)
            {
                meetingDataLists = meeting.SearchCalendarItemsAsync(fromDate, toDate, excludeExpiredMeetings).Result;
                if (excludeExpiredMeetings)
                {
                    meetingDataLists = meetingDataLists.Where(x => x.MeetingEndTime > DateTime.Now);
                }
                SetDropdownValue();
            }
        }

        private async void fetch_Click(object sender, EventArgs e)
        {
            if (toDP.Value > DateTime.MinValue && fromDP.Value > DateTime.MinValue)
            {
                meetingDataLists = await meeting.SearchCalendarItemsAsync(fromDP.Value, toDP.Value);
                SetDropdownValue();
            }
            else
            {
                MessageBox.Show("Please enter from and to date");
            }
        }

        private void SetDropdownValue()
        {
            var data = meetingDataLists.Select(oneData => new
            {
                Value = oneData.Id,
                Text = oneData.MeetingTitle
            }).ToList();


            meetingList.ValueMember = "Value";
            meetingList.DisplayMember = "Text";
            meetingList.DataSource = data;
        }

        private void fromDP_ValueChanged(object sender, EventArgs e)
        {
            meetingList.DataSource = null;
            locationTxt.Text = string.Empty;
            linkTxt.Text = string.Empty;
            meetingIdTxt.Text = string.Empty;
            meetingPwdTxt.Text = string.Empty;
            setDatePickerToNull(localTime);
            setDatePickerToNull(endMeetingTime);
            autoStart.Checked = false;
            timer?.Stop();
        }

        private void toDP_ValueChanged(object sender, EventArgs e)
        {
            meetingList.DataSource = null;
            locationTxt.Text = string.Empty;
            linkTxt.Text = string.Empty;
            meetingIdTxt.Text = string.Empty;
            meetingPwdTxt.Text = string.Empty;

            setDatePickerToNull(localTime);
            setDatePickerToNull(endMeetingTime);
            autoStart.Checked = false;
            timer?.Stop();
        }

        private void setDatePickerToNull(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = " ";
        }

        private void meetingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer?.Stop();
            var id = Convert.ToInt32(meetingList.SelectedValue);
            var meetingData = meetingDataLists.FirstOrDefault(x => x.Id == id);
            if (meetingData != null)
            {
                locationTxt.Text = meetingData.Location ?? string.Empty;
                linkTxt.Text = meetingData.Link;
                localTime.Format = DateTimePickerFormat.Time;
                localTime.Value = meetingData.MyStartTime;

                endMeetingTime.Format = DateTimePickerFormat.Time;
                endMeetingTime.Value = meetingData.MeetingEndTime;

                if (UseLocal)
                {
                    if (!string.IsNullOrWhiteSpace(meetingData.Password))
                        Clipboard.SetText(meetingData.Password);
                    else if (!string.IsNullOrWhiteSpace(meetingData.MeetingId))
                        Clipboard.SetText(meetingData.MeetingId);
                }
                meetingPwdTxt.Text = meetingData.Password;
                meetingIdTxt.Text = meetingData.MeetingId;

                autoStart.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(linkTxt.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(meetingList.SelectedValue);
            var meetingData = meetingDataLists.FirstOrDefault(x => x.Id == id);
            if (meetingData != null)
            {
                Form2 testDialog = new Form2(meetingData.Description);
                testDialog.Name = "Meeting Body"; 
                testDialog.ShowDialog(this);
                testDialog.Dispose();
            }
        }

        private void autoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (meetingList.SelectedValue != null && autoStart.Checked && localTime.Value >= DateTime.Today)
            {
                schedule_Timer(DateTime.Now, localTime.Value);
            }
        }

        bool? isRecurring(object id)
        {
            return meetingDataLists.FirstOrDefault(x => x.Id == Convert.ToInt32(id))?.IsRecurring;
        }

        void schedule_Timer(DateTime currentTime, DateTime scheduledTime)
        {
            if (currentTime.Hour >= scheduledTime.Hour && currentTime.Minute > scheduledTime.Minute && isRecurring(meetingList.SelectedValue).HasValue)
            {
                scheduledTime = scheduledTime.AddDays(incrementInDays);
            }

            double tickTime = (double)(scheduledTime - currentTime).TotalMilliseconds;
            timer = new System.Timers.Timer(tickTime);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            System.Diagnostics.Process.Start(linkTxt.Text);

        }
    }
}
