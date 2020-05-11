using BusinessLogic.Report;
using Common.Contract;
using Common.Models;
using Common.Utils;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DailyHelper
{
    public partial class Form4 : Form
    {
        public bool UseLocal { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        private readonly IReport report;
        private readonly IDataHelper dataHelper;
        private readonly IConfigurations configurations;
        private readonly IConfluencePageHelper confluencePageHelper;

        public Form4(IReport report, IDataHelper dataHelper, IConfigurations configurations, IConfluencePageHelper confluencePageHelper)
        {
            this.report = report;
            this.dataHelper = dataHelper;
            this.configurations = configurations;
            this.confluencePageHelper = confluencePageHelper;
            this.Name = "Report Helper";

            InitializeComponent();

            SetCustomVisibility(false);           
            
        }

        public void Initialize()
        {
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
            var users = this.configurations.ReportSettings.Users.Split(',').ToList();

            foreach (var item in users)
            {
                userList.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(unTxt.Text) || string.IsNullOrWhiteSpace(pwdTxt.Text))
            {
                MessageBox.Show("Please enter your credentials");
                return;
            }
            Cursor = Cursors.WaitCursor;
            var path = "";
            var fileName = "";
            if (pdf.Checked && folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                fileName = Interaction.InputBox("Please enter pdf file name.", "Pdf file name", "");
            }

            if(pdf.Checked)
            {
                if(string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(fileName))
                {
                    MessageBox.Show("Folder or filename is incorrect.");
                    Cursor = Cursors.Arrow;
                    return;
                }
            }
            var users = new List<string>();

            if (customSearch.Checked)
            {
                foreach (var item in userList.SelectedItems)
                {
                    users.Add((string)item);
                }
            }

            DateTime? to = !customSearch.Checked ? (DateTime?)null : toDate.Value;
            DateTime? from = !customSearch.Checked ? (DateTime?)null : fromDate.Value;
            string[] user = users?.Count > 0 && customSearch.Checked ? users.ToArray() : null;

            if(customSearch.Checked && fromDate.Value.Date >= toDate.Value.Date)
            {
                MessageBox.Show("Please enter valid range");
                return;
            }

            report.GenerateStatusReport(unTxt.Text, pwdTxt.Text, sendEmail.Checked, noCcCheck.Checked, from, to, user, pdf.Checked, browser.Checked, path, fileName, UseLocal);
            Cursor = Cursors.Arrow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var password = Prompt.ShowDialog("Please enter the text", "test", true);
            //if(string.IsNullOrWhiteSpace(password))
            //{
            //    MessageBox.Show("Please enter non empty value.");
            //    return;
            //}
            //Clipboard.SetText(Helper.Base64Encode(password));
            //MessageBox.Show("Password copied in clipboard.");

            if (string.IsNullOrWhiteSpace(unTxt.Text) || string.IsNullOrWhiteSpace(pwdTxt.Text))
            {
                MessageBox.Show("Please enter your credentails");
                return;
            }

            var cred = new Credentials(unTxt.Text, Utility.Base64Encode(pwdTxt.Text));
            MessageBox.Show(this.dataHelper.SaveCredentials(cred) ? "Saved Successfully!" : "Save Failed!");
        }

        private void customSearch_CheckedChanged(object sender, EventArgs e)
        {
            if(customSearch.Checked)
            {
                SetCustomVisibility(true);
            }
            else
            {
                SetCustomVisibility(false);
            }
        }

       private void SetCustomVisibility(bool visible)
        {
            userLabel.Visible = visible;
            fromLabel.Visible = visible;
            toLabel.Visible = visible;
            fromDate.Visible = visible;
            toDate.Visible = visible;
            userList.Visible = visible;
        }

        private void jiraTasks_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                this.confluencePageHelper.SendAlertForStatusChange(UserName, Password, true);
                Cursor = Cursors.Arrow;
                MessageBox.Show("Done");
            }
            catch (Exception exception)
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show("Failed");
            }
            
            
        }
    }
}
