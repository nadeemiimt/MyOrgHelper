using Common.Contract;
using Common.Models;
using Common.Utils;
using DailyHelper.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Unity;
using Unity.Resolution;

namespace DailyHelper
{
    public partial class Form3 : Form
    {
        static bool HideStatus = Convert.ToBoolean(ConfigurationManager.AppSettings["HideStatus"]);
        static bool HideStash = Convert.ToBoolean(ConfigurationManager.AppSettings["HideStash"]);
        static bool HideMeeting = Convert.ToBoolean(ConfigurationManager.AppSettings["HideMeeting"]);

        private readonly IDataHelper dataHelper;
        private readonly IUnityContainer container;
        private readonly ILog logger;

        public Form3(IDataHelper dataHelper, IUnityContainer container, ILog logger)
        {
            InitializeComponent();
            
            //// Adding handler - to show log messages (ILoggerHandler)
            //Logger.LoggerHandlerManager
            //    //   .AddHandler(new ConsoleLoggerHandler())
            //    .AddHandler(new FileLoggerHandler());
            ////    .AddHandler(new DebugConsoleLoggerHandler());

            this.dataHelper = dataHelper;
            this.container = container;
            this.logger = logger;
            Icon = new Icon("vmware32logo.ico");
            this.Text = "Daily Helper";

            var data = this.dataHelper.GetCredentials();
            unTxt.Text = data?.UserName;
            pwdTxt.Text = Utility.Base64Decode(data?.Password);

            if (HideMeeting)
            {
                Meeting.Visible = false;
            }

            if (HideStash)
            {
                stashBtn.Visible = false;
            }

            if (HideStatus)
            {
                Status.Visible = false;
            }
        }

        private async void Meeting_Click(object sender, EventArgs e)
        {
            if (!localOutlook.Checked && (string.IsNullOrWhiteSpace(unTxt.Text) || string.IsNullOrWhiteSpace(pwdTxt.Text)))
            {
                MessageBox.Show("Please enter your credentials");
                return;
            }

            Cursor = Cursors.WaitCursor;
            Form1 f1;
            if(localOutlook.Checked)
            {
                f1 = this.container.Resolve<Form1>(new ParameterOverride("meeting", container.Resolve<IMeeting>(Constants.LocalOutlook)));
            }
            else
            {
                f1 = this.container.Resolve<Form1>(new ParameterOverride("meeting", container.Resolve<IMeeting>(Constants.ExchangeServer, new ParameterOverride("action", null), new ParameterOverride("token", null))));
            }

            // f1 = container.Resolve<Form1>(new ParameterOverride("meeting", container.Resolve<IMeeting>(localOutlook.Checked ? Constants.LocalOutlook : Constants.ExchangeServer, new ParameterOverride("action", action))));
            f1.UseLocal = localOutlook.Checked;
            f1.UserName = unTxt.Text;
            f1.Password = pwdTxt.Text;

            f1.Initialize();

           // Form1 f1 = new Form1(unTxt.Text, pwdTxt.Text, localOutlook.Checked);
            f1.Show();
            Cursor = Cursors.Arrow;
        }

        private void Status_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(unTxt.Text) || string.IsNullOrWhiteSpace(pwdTxt.Text))
            {
                MessageBox.Show("Please enter your credentials");
                return;
            }

            Form4 f4 = this.container.Resolve<Form4>();
            f4.UseLocal = localOutlook.Checked;
            f4.UserName = unTxt.Text;
            f4.Password = pwdTxt.Text;

            f4.Initialize();
           // Form4 f4 = new Form4(unTxt.Text, pwdTxt.Text, localOutlook.Checked);
            f4.Show();
        }

        private void stashBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(unTxt.Text) || string.IsNullOrWhiteSpace(pwdTxt.Text))
            {
                MessageBox.Show("Please enter your credentials");
                return;
            }

            Cursor = Cursors.WaitCursor;
            Form5 f5 = container.Resolve<Form5>();
            f5.UserName = unTxt.Text;
            f5.Password = pwdTxt.Text;

            f5.Initialize();
           // Form5 f5 = new Form5(unTxt.Text, pwdTxt.Text);
            f5.Show();
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
    }
}
