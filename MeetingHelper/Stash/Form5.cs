using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Contract;
using Common.Models;
using Common.Utils;
using DailyHelper.Helper;
using log4net;
using log4net.Core;
using Newtonsoft.Json;

namespace DailyHelper
{
    public partial class Form5 : Form
    {
        // API Doc Reference: https://docs.atlassian.com/bitbucket-server/rest/5.10.0/bitbucket-rest.html?_ga=2.182404711.1540523479.1585044717-1819885808.1585044717#idm46340512758048

        List<Value> prData = new List<Value>();
        System.Timers.Timer timer = new System.Timers.Timer();
        static int TimerFrequencyInMinutes = Convert.ToInt32(ConfigurationManager.AppSettings["TimerFrequencyInMinutes"]);

        private readonly INotifier notifier;
        private readonly IDataHelper dataHelper;
        private readonly IStashProvider stashProvider;
        private readonly IJiraStatusHelper jiraStatusHelper;
        private readonly IConfigurations configurations;
        private readonly ILog logger;

        bool isDefault = true;
        Transitions currentJiraStatus;

        public string UserName { get; set; }
        public string Password { get; set; }

        public Form5(INotifier notifier, IDataHelper dataHelper, IStashProvider stashProvider, IJiraStatusHelper jiraStatusHelper, ILog logger, IConfigurations configurations)
        {
            this.dataHelper = dataHelper;
            this.notifier = notifier;
            this.stashProvider = stashProvider;
            this.jiraStatusHelper = jiraStatusHelper;
            this.logger = logger;
            this.configurations = configurations;
            InitializeComponent();

            this.Name = "Stash Helper";
            refresh.Font = new Font("Wingdings 3", 20, FontStyle.Bold);
            refresh.Text = Char.ConvertFromUtf32(80); // or 81
            refresh.Width = 40;
            refresh.Height = 40;

            new EnumCombobox<Transitions>(prStatusDpdwn);            
        }

        public void Initialize()
        {
            timerTxt.Text = TimerFrequencyInMinutes.ToString();

            if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
            {
                unTxt.Text = UserName;
                pwdTxt.Text = Password;
            }
            else
            {
                var data = this.dataHelper.GetCredentials();
                unTxt.Text = data?.UserName;
                pwdTxt.Text = Utility.Base64Decode(data?.Password);
            }

            SetPrList(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(unTxt.Text) || string.IsNullOrWhiteSpace(pwdTxt.Text))
            {
                MessageBox.Show("Please enter your credentials");
                return;
            }

            var cred = new Credentials(unTxt.Text, Utility.Base64Encode(pwdTxt.Text));
            MessageBox.Show(this.dataHelper.SaveCredentials(cred) ? "Saved Successfully!" : "Save Failed!");
        }

        private void fetchPr_Click(object sender, EventArgs e)
        {
            SetPrItems();
        }

        private void SetPrItems(bool reset = true, List<Value> values = null)
        {
            Cursor = Cursors.WaitCursor;
            comboBox1.Items.Clear();

            if(reset)
            {
                Reset();
            }
            
            SetPrList(false, values);
            Cursor = Cursors.Arrow;
        }

        private void SetPrList(bool init = false, List<Value> values = null)
        {
            if (string.IsNullOrWhiteSpace(unTxt.Text) || string.IsNullOrWhiteSpace(pwdTxt.Text))
            {
                if (!init)
                {
                    MessageBox.Show("Please enter your credentials");
                }

                return;
            }

            if(isDefault)
            {
                prData = values ?? this.stashProvider.GetPrList(unTxt.Text, pwdTxt.Text);
            }
            else
            {
                prData = values ?? this.stashProvider.GetCustomPrList(unTxt.Text, pwdTxt.Text, customPRTxt.Text?.Split(','));
            }            

            var item = $"{prData?.Count ?? 0} PR.";
            comboBox1.Items.Add(item);

            if (prData?.Count > 0)
            {                
                foreach (var pr in prData)
                {
                    comboBox1.Items.Add(pr.Title);
                }
            }

            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(item);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset();

            if(comboBox1.SelectedIndex == 0)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(unTxt.Text) || string.IsNullOrWhiteSpace(pwdTxt.Text))
            {
                MessageBox.Show("Please enter your credentials");
                return;
            }
            Cursor = Cursors.WaitCursor;
            var pr = getPr(comboBox1.SelectedItem.ToString());
            var prId = pr.Id;

            var jiraId = Utility.GetJiraTickets(pr.Title);

            try
            {
                var jiraStatus = this.jiraStatusHelper.GetJiraStatus(jiraId, unTxt.Text, pwdTxt.Text);

                currentJiraStatus = Utility.GetValueFromDescription<Transitions>(jiraStatus);
                prStatusDpdwn.SelectedValue = currentJiraStatus;
                panel1.Visible = true;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex);
            }
            openTasks.Text = pr?.Properties?.OpenTaskCount.ToString();

            if(pr?.Properties?.OpenTaskCount > 0)  // if task are pending no need to check other.
            {
                Cursor = Cursors.Arrow;
                return;
            }

            var summaryTask = Task.Run(() => this.stashProvider.GetPrSummary(unTxt.Text, pwdTxt.Text, prId));
            var prMergeDetailTask = Task.Run(() => this.stashProvider.GetMergeDetails(unTxt.Text, pwdTxt.Text, prId));

            var prSummary = summaryTask.Result;
            var prDetails = prMergeDetailTask.Result;

            if(prDetails.Errors?.Count > 0)
            {
                var isMerged = prDetails.Errors.Any(x => x.Message.Contains("already merged"));
                if(isMerged)
                {
                    MessageBox.Show($"PR id: {prId} is merged");
                }
                else
                {
                    MessageBox.Show($"PR id: {prId} has some errors:" + String.Join("/n", prDetails.Errors.Select(x => x.Message)));
                }
                Reset();
                return;
            }

            var vetoes = prDetails.Vetoes;

            for (int i = 0; i < 5; i++)
            {
                if(vetoes.Any(x=>x.SummaryMessage == SummaryMessage.Retry))
                {
                    prMergeDetailTask = Task.Run(() => this.stashProvider.GetMergeDetails(unTxt.Text, pwdTxt.Text, prId));
                    prDetails = prMergeDetailTask.Result;
                    vetoes = prDetails.Vetoes;
                }
                else
                {
                    break;
                }
            }
            SetApprovers(pr.Reviewers);
            prTitleTxt.Text = comboBox1.SelectedItem.ToString();            
            BuildPassed.Checked =
                vetoes.All(x => x.SummaryMessage != SummaryMessage.BuildFailedOrInProgress);

            NoPermission.Checked =
               vetoes.Any(x => x.SummaryMessage == SummaryMessage.NoPermission);

            RebaseRequired.Checked =
                vetoes.Any(x => x.SummaryMessage == SummaryMessage.RebaseRequired);

            blockerChk.Checked =
                vetoes.Any(x => x.SummaryMessage == SummaryMessage.OpenIssues);

            if (blockerChk.Checked)
            {
                toolTip1.SetToolTip(this.blockerChk, vetoes.FirstOrDefault(x => x.SummaryMessage == SummaryMessage.OpenIssues).DetailedMessage);
            }

            if (NoPermission.Checked)
            {
                autoMerge.Enabled = false;
            }

            MandatoryApprovals.Checked =
                vetoes.All(x => x.SummaryMessage != SummaryMessage.InsufficientApprovals) &&
                vetoes.All(x => x.SummaryMessage != SummaryMessage.SherpaApprovals);

            MasterPassed.Checked =
                vetoes.All(x => x.SummaryMessage != SummaryMessage.MasterBuildCNBroken) &&
                vetoes.All(x => x.SummaryMessage != SummaryMessage.MasterBuildCITBroken);

            RebaseAvailable.Checked = !prSummary.IsRebased;
            rebaseBtn.Enabled = RebaseAvailable.Checked;

            HasConflicts.Checked = prSummary.IsConflicted;

            CanMerge.Checked = prDetails.CanMerge;
            mergePR.Enabled = prDetails.CanMerge;
            openPR.Enabled = true;
            Cursor = Cursors.Arrow;
        }

        private Value getPr(string title)
        {
            var pr = prData?.FirstOrDefault(x => x.Title.Equals(title));
            if (pr == null)
            {
               // refresh data.
                if (isDefault)
                {
                    prData = this.stashProvider.GetPrList(unTxt.Text, pwdTxt.Text);
                }
                else
                {
                    prData = this.stashProvider.GetCustomPrList(unTxt.Text, pwdTxt.Text, customPRTxt.Text?.Split(','));
                }

                pr = prData?.FirstOrDefault(x => x.Title.Equals(title));
            }

            return pr;
        }

        private void SetApprovers(List<Author> reviewers)
        {
            if (reviewers?.Count == 0)
            {
                return;
            }

            var approvers = reviewers.Where(x => x.Approved).ToList();

            var item = $"{approvers?.Count ?? 0} Approvers.";
            comboBox2.Items.Add(item);

            foreach (var approver in approvers)
            {
                comboBox2.Items.Add(approver.User.DisplayName + "- (" + approver.User.EmailAddress + ")");
            }

            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(item);
        }

        private void Reset()
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            prTitleTxt.Text = "";
            openTasks.Text = "";
            BuildPassed.Checked = false;
            MandatoryApprovals.Checked = false;
            MasterPassed.Checked = false;
            RebaseAvailable.Checked = false;
            HasConflicts.Checked = false;
            toolTip1.SetToolTip(this.blockerChk, "");
            RebaseRequired.Checked = false;
            openPR.Enabled = false;
            CanMerge.Checked = false;
            NoPermission.Checked = false;
            mergePR.Enabled = false;
            autoMerge.Enabled = true;
            autoMerge.Checked = false;
            AutoRebase.Checked = false;
            blockerChk.Checked = false;
            rebaseBtn.Enabled = false;
            autoClose.Checked = false;
            timer.Stop();

            if(isDefault)
            {
                customPRTxt.Enabled = false;
                customPRTxt.Visible = false;
                approvePR.Visible = false;
                approvePR.Enabled = false;
            }
            else
            {
                customPRTxt.Visible = true;
                customPRTxt.Enabled = true;
                approvePR.Visible = true;
                approvePR.Enabled = true;
            }

            panel1.Visible = false;

            Cursor = Cursors.Arrow;
        }

        private void mergePR_Click(object sender, EventArgs e)
        {
            if (mergePR.Enabled)
            {
                Cursor = Cursors.WaitCursor;
                var pr = getPr(comboBox1.SelectedItem.ToString());
                var prId = pr.Id;
                var jiraId = Utility.GetJiraTickets(pr.Title);
                var response = this.stashProvider.MergePR(unTxt.Text, pwdTxt.Text, prId, pr.Version);
                this.jiraStatusHelper.ChangeStatus(Transitions.PullRequestAccepted, jiraId, unTxt.Text, pwdTxt.Text);
                Cursor = Cursors.Arrow;
                MessageBox.Show(response.State + "##" + pr?.Title);
            }
            else
            {
                MessageBox.Show("Merge is disabled");
            }
        }

        private void autoMerge_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(unTxt.Text) || string.IsNullOrWhiteSpace(pwdTxt.Text))
            {
                MessageBox.Show("Please enter your credentials");
                return;
            }
            if (autoMerge.Checked)
            {
                var pr = getPr(comboBox1.SelectedItem.ToString());
                var prId = pr.Id;

                openTasks.Text = pr?.Properties?.OpenTaskCount.ToString();

                if (pr?.Properties?.OpenTaskCount > 0)  // if task are pending no need to check other.
                {
                    MessageBox.Show("Please complete tasks first.");
                    return;
                }
                // do a scheduler task.
                var timerVal = Convert.ToInt32(timerTxt.Text);
                schedule_Timer(DateTime.Now, DateTime.Now.AddMinutes(timerVal), unTxt.Text, pwdTxt.Text, prId);
            }
            else
            {
                timer.Stop();
            }
        }

        void schedule_Timer(DateTime currentTime, DateTime scheduledTimeInterval, string userName, string password, long prId)
        {
            double tickTime = (double)(scheduledTimeInterval - currentTime).TotalMilliseconds;
            timer = new System.Timers.Timer(tickTime);
            timer.Elapsed += delegate { KeepAliveElapsed(userName, password, prId); };
            timer.Start();
        }

        /// <summary>
        /// test if merge available.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="prId"></param>
        void KeepAliveElapsed(string userName, string password, long prId)
        {
            if (isDefault)
            {
                prData = this.stashProvider.GetPrList(unTxt.Text, pwdTxt.Text);
            }
            else
            {
                prData = this.stashProvider.GetCustomPrList(unTxt.Text, pwdTxt.Text, customPRTxt.Text?.Split(','));
            }
            var prMergeDetailTask = Task.Run(() => this.stashProvider.GetMergeDetails(userName, password, prId));
            var prDetails = prMergeDetailTask.Result;
            var pr = prData.FirstOrDefault(x => x.Id == prId);

            if (prDetails.CanMerge)
            {
                this.logger.Info("Merge in progress, for PR: " + pr.Title,null );
                this.notifier.SendNotification("Trying to merge PR " + pr.Title.RemoveDigits().Substring(5, 20), "AutoMerge"); // take only short info
                
                StashMergedResponse response = new StashMergedResponse();
                var jiraId = Utility.GetJiraTickets(pr.Title);

                this.SetPrItems(true, prData);  // refresh

                try
                {                    
                    if(confirm.Checked)
                    {
                        System.Media.SystemSounds.Beep.Play();
                        Thread.Sleep(2000);
                        System.Media.SystemSounds.Hand.Play();

                        var result = MessageBox.Show("Confirm ?", "PR Merge Confirmation", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            response = this.stashProvider.MergePR(userName, password, prId, pr.Version);
                            this.jiraStatusHelper.ChangeStatus(Transitions.PullRequestAccepted, jiraId, unTxt.Text, pwdTxt.Text);
                            MessageBox.Show(response.State + "##" + pr?.Description);
                            return;
                        }
                        else if (result == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }

                    response = this.stashProvider.MergePR(userName, password, prId, pr.Version);
                    this.jiraStatusHelper.ChangeStatus(Transitions.PullRequestAccepted, jiraId, unTxt.Text, pwdTxt.Text);
                    this.logger.Info(response.State + "##" + pr?.Description);
                    this.notifier.SendNotification("PR " + pr.Title.RemoveDigits().Substring(5, 20) + " status is "+ response.State, "AuroMerge"); // take only short info
                    if (autoClose.Checked)
                    {
                        Environment.Exit(0);
                    }
                }
                catch (Exception e)
                {
                    this.logger.Error(JsonConvert.SerializeObject(response));
                    this.logger.Error(e);
                    this.SetPrItems(true, prData);  // refresh
                }               
            }
            else if(prDetails.Conflicted)
            {
                this.logger.Error("Conflict occured, for PR: " + pr.Title);
                this.notifier.SendNotification("Conflict came in PR " + pr.Title.RemoveDigits().Substring(5, 20), "Conflict"); // take only short info
                this.SetPrItems(true, prData);  // refresh
                if (autoClose.Checked)
                {
                    Environment.Exit(0);
                }
                return;
            }
            else if(AutoRebase.Checked && (prDetails.Vetoes.Any(x => x.SummaryMessage == SummaryMessage.BuildFailedOrInProgress) && prDetails.Vetoes.Any(x=>x.DetailedMessage == Constants.BuildFailMessage) || prDetails.Vetoes.Any(x => x.SummaryMessage == SummaryMessage.RebaseRequired)))
            {
                this.notifier.SendNotification("Build failed in PR " + pr.Title.RemoveDigits().Substring(5, 20), "BuildFail"); // take only short info
                var rebaseAvailable = !(Task.Run(() => this.stashProvider.GetPrSummary(unTxt.Text, pwdTxt.Text, prId)).Result.IsRebased);
                if(rebaseAvailable)
                {
                    this.logger.Info("Rebased, for PR: " + pr.Title);
                    var isRebased = this.RebasePr(prId, pr.Version);

                    if(isRebased)
                    {
                        this.notifier.SendNotification("Rabased automatically in PR " + pr.Title.RemoveDigits().Substring(5, 20), "AutoRebase"); // take only short info
                        return;  // continue the timer to wait for successful build
                    }
                    else
                    {
                        this.notifier.SendNotification("Auto rebased failed in PR " + pr.Title.RemoveDigits().Substring(5, 20), "AutoRebase"); // take only short info
                        this.SetPrItems(true, prData);  // refresh
                    }
                }
                else
                {
                    this.logger.Error("Unknown, for PR: " + pr.Title);
                    this.SetPrItems(true, prData);  // refresh
                }
            }
            else
            {
                // continue;
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            this.SetPrItems(true, null);
        }

        private void rebaseBtn_Click(object sender, EventArgs e)
        {
            var pr = getPr(comboBox1.SelectedItem.ToString());
            var prId = pr.Id;

            this.RebasePr(prId, pr.Version);
            this.SetPrItems(true, null);
        }

        private bool RebasePr(long prId, long prVersion)
        {
            try
            {
                var response = this.stashProvider.RebasePR(unTxt.Text, pwdTxt.Text, prId, prVersion);

                if (response != null)
                {
                    MessageBox.Show("Done");
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed");
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed");
                return false;
            }
        }       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                isDefault = true;
                customPRTxt.Text = "";
                Reset();

                comboBox1.Items.Clear();
            }
        }

        private void Custom_CheckedChanged(object sender, EventArgs e)
        {
            if (Custom.Checked)
            {
                isDefault = false;
                customPRTxt.Text = "";
                Reset();
                comboBox1.Items.Clear();
            }
        }

        private void approvePR_Click(object sender, EventArgs e)
        {
            var pr = getPr(comboBox1.SelectedItem.ToString());
            var prId = pr.Id;

            try
            {
                var response = this.stashProvider.ApprovePr(unTxt.Text, pwdTxt.Text, prId, pr.Version);

                if (response != null)
                {
                    MessageBox.Show("Done");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed");
            }

            this.SetPrItems(true, null);
        }

        private void ChangeStatus_Click(object sender, EventArgs e)
        {
            var selectedStatus = ((EnumWithName<Transitions>)prStatusDpdwn.SelectedItem).Value;

            if(currentJiraStatus != selectedStatus)
            {
                var pr = getPr(comboBox1.SelectedItem.ToString());
                var prId = pr.Id;
                var jiraId = Utility.GetJiraTickets(pr.Title);
                this.jiraStatusHelper.ChangeStatus(selectedStatus, jiraId, unTxt.Text, pwdTxt.Text);
            }
        }

        private void openPR_Click(object sender, EventArgs e)
        {
            var pr = getPr(comboBox1.SelectedItem.ToString());
            var prId = pr.Id;

            var link = $"https://{this.configurations.StashSettings.StashBase}/projects/{this.configurations.StashSettings.StashProject}/repos/{this.configurations.StashSettings.StashRepo}/pull-requests/{prId}/overview";
            System.Diagnostics.Process.Start(link);
        }
    }
}
