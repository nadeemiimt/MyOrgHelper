namespace DailyHelper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fromDP = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toDP = new System.Windows.Forms.DateTimePicker();
            this.meetingList = new System.Windows.Forms.ComboBox();
            this.fetch = new System.Windows.Forms.Button();
            this.locationTxt = new System.Windows.Forms.TextBox();
            this.location = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.localTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.autoStart = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.endMeetingTime = new System.Windows.Forms.DateTimePicker();
            this.meetingPwdTxt = new System.Windows.Forms.TextBox();
            this.meetingIdTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.webView1 = new Microsoft.Toolkit.Forms.UI.Controls.WebView();
            ((System.ComponentModel.ISupportInitialize)(this.webView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fromDP
            // 
            this.fromDP.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.fromDP.Location = new System.Drawing.Point(185, 121);
            this.fromDP.Name = "fromDP";
            this.fromDP.Size = new System.Drawing.Size(293, 38);
            this.fromDP.TabIndex = 0;
            this.fromDP.ValueChanged += new System.EventHandler(this.fromDP_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // toDP
            // 
            this.toDP.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.toDP.Location = new System.Drawing.Point(783, 121);
            this.toDP.Name = "toDP";
            this.toDP.Size = new System.Drawing.Size(282, 38);
            this.toDP.TabIndex = 3;
            this.toDP.ValueChanged += new System.EventHandler(this.toDP_ValueChanged);
            // 
            // meetingList
            // 
            this.meetingList.FormattingEnabled = true;
            this.meetingList.Location = new System.Drawing.Point(94, 385);
            this.meetingList.Name = "meetingList";
            this.meetingList.Size = new System.Drawing.Size(1006, 39);
            this.meetingList.TabIndex = 4;
            this.meetingList.SelectedIndexChanged += new System.EventHandler(this.meetingList_SelectedIndexChanged);
            // 
            // fetch
            // 
            this.fetch.Location = new System.Drawing.Point(527, 255);
            this.fetch.Name = "fetch";
            this.fetch.Size = new System.Drawing.Size(146, 53);
            this.fetch.TabIndex = 5;
            this.fetch.Text = "Fetch";
            this.fetch.UseVisualStyleBackColor = true;
            this.fetch.Click += new System.EventHandler(this.fetch_Click);
            // 
            // locationTxt
            // 
            this.locationTxt.Location = new System.Drawing.Point(313, 569);
            this.locationTxt.Name = "locationTxt";
            this.locationTxt.ReadOnly = true;
            this.locationTxt.Size = new System.Drawing.Size(765, 38);
            this.locationTxt.TabIndex = 6;
            // 
            // location
            // 
            this.location.AutoSize = true;
            this.location.Location = new System.Drawing.Point(88, 575);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(132, 32);
            this.location.TabIndex = 7;
            this.location.Text = "Location:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 700);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Link:";
            // 
            // linkTxt
            // 
            this.linkTxt.Location = new System.Drawing.Point(313, 694);
            this.linkTxt.Name = "linkTxt";
            this.linkTxt.ReadOnly = true;
            this.linkTxt.Size = new System.Drawing.Size(765, 38);
            this.linkTxt.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(583, 896);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 53);
            this.button1.TabIndex = 10;
            this.button1.Text = "Start Meeting";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1122, 626);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 54);
            this.button2.TabIndex = 11;
            this.button2.Text = "Details";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // localTime
            // 
            this.localTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.localTime.Location = new System.Drawing.Point(185, 464);
            this.localTime.Name = "localTime";
            this.localTime.Size = new System.Drawing.Size(282, 38);
            this.localTime.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 470);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "Start @";
            // 
            // autoStart
            // 
            this.autoStart.AutoSize = true;
            this.autoStart.Location = new System.Drawing.Point(959, 470);
            this.autoStart.Name = "autoStart";
            this.autoStart.Size = new System.Drawing.Size(169, 36);
            this.autoStart.TabIndex = 15;
            this.autoStart.Text = "autoStart";
            this.autoStart.UseVisualStyleBackColor = true;
            this.autoStart.CheckedChanged += new System.EventHandler(this.autoStart_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 32);
            this.label5.TabIndex = 16;
            this.label5.Text = "End @";
            // 
            // endMeetingTime
            // 
            this.endMeetingTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endMeetingTime.Location = new System.Drawing.Point(628, 466);
            this.endMeetingTime.Name = "endMeetingTime";
            this.endMeetingTime.Size = new System.Drawing.Size(282, 38);
            this.endMeetingTime.TabIndex = 17;
            // 
            // meetingPwdTxt
            // 
            this.meetingPwdTxt.Location = new System.Drawing.Point(812, 772);
            this.meetingPwdTxt.Name = "meetingPwdTxt";
            this.meetingPwdTxt.ReadOnly = true;
            this.meetingPwdTxt.Size = new System.Drawing.Size(471, 38);
            this.meetingPwdTxt.TabIndex = 18;
            // 
            // meetingIdTxt
            // 
            this.meetingIdTxt.Location = new System.Drawing.Point(190, 772);
            this.meetingIdTxt.Name = "meetingIdTxt";
            this.meetingIdTxt.ReadOnly = true;
            this.meetingIdTxt.Size = new System.Drawing.Size(411, 38);
            this.meetingIdTxt.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 772);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 32);
            this.label6.TabIndex = 20;
            this.label6.Text = "ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(662, 772);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 32);
            this.label7.TabIndex = 21;
            this.label7.Text = "PWD:";
            // 
            // webView1
            // 
            this.webView1.Location = new System.Drawing.Point(1386, 1058);
            this.webView1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webView1.Name = "webView1";
            this.webView1.Size = new System.Drawing.Size(250, 250);
            this.webView1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1689, 1329);
            this.Controls.Add(this.webView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.meetingIdTxt);
            this.Controls.Add(this.meetingPwdTxt);
            this.Controls.Add(this.endMeetingTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.autoStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.localTime);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.location);
            this.Controls.Add(this.locationTxt);
            this.Controls.Add(this.fetch);
            this.Controls.Add(this.meetingList);
            this.Controls.Add(this.toDP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fromDP);
            this.Name = "Form1";
            this.Text = "Meeting Helper";
            ((System.ComponentModel.ISupportInitialize)(this.webView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fromDP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker toDP;
        private System.Windows.Forms.ComboBox meetingList;
        private System.Windows.Forms.Button fetch;
        private System.Windows.Forms.TextBox locationTxt;
        private System.Windows.Forms.Label location;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox linkTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker localTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox autoStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker endMeetingTime;
        private System.Windows.Forms.TextBox meetingPwdTxt;
        private System.Windows.Forms.TextBox meetingIdTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Microsoft.Toolkit.Forms.UI.Controls.WebView webView1;
    }
}

