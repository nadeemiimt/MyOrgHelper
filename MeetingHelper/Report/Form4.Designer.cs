namespace DailyHelper
{
    partial class Form4
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.button1 = new System.Windows.Forms.Button();
            this.un = new System.Windows.Forms.Label();
            this.pwd = new System.Windows.Forms.Label();
            this.unTxt = new System.Windows.Forms.TextBox();
            this.pwdTxt = new System.Windows.Forms.TextBox();
            this.sendEmail = new System.Windows.Forms.CheckBox();
            this.pdf = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.browser = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.userList = new System.Windows.Forms.ListBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.noCcCheck = new System.Windows.Forms.CheckBox();
            this.customSearch = new System.Windows.Forms.CheckBox();
            this.jiraTasks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 694);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 95);
            this.button1.TabIndex = 3;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // un
            // 
            this.un.AutoSize = true;
            this.un.Location = new System.Drawing.Point(110, 92);
            this.un.Name = "un";
            this.un.Size = new System.Drawing.Size(63, 32);
            this.un.TabIndex = 4;
            this.un.Text = "UN:";
            // 
            // pwd
            // 
            this.pwd.AutoSize = true;
            this.pwd.Location = new System.Drawing.Point(673, 91);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(88, 32);
            this.pwd.TabIndex = 5;
            this.pwd.Text = "PWD:";
            // 
            // unTxt
            // 
            this.unTxt.Location = new System.Drawing.Point(239, 85);
            this.unTxt.Name = "unTxt";
            this.unTxt.Size = new System.Drawing.Size(351, 38);
            this.unTxt.TabIndex = 6;
            // 
            // pwdTxt
            // 
            this.pwdTxt.Location = new System.Drawing.Point(855, 88);
            this.pwdTxt.Name = "pwdTxt";
            this.pwdTxt.Size = new System.Drawing.Size(351, 38);
            this.pwdTxt.TabIndex = 7;
            this.pwdTxt.UseSystemPasswordChar = true;
            // 
            // sendEmail
            // 
            this.sendEmail.AutoSize = true;
            this.sendEmail.Checked = true;
            this.sendEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sendEmail.Location = new System.Drawing.Point(514, 208);
            this.sendEmail.Name = "sendEmail";
            this.sendEmail.Size = new System.Drawing.Size(192, 36);
            this.sendEmail.TabIndex = 8;
            this.sendEmail.Text = "SendEmail";
            this.sendEmail.UseVisualStyleBackColor = true;
            // 
            // pdf
            // 
            this.pdf.AutoSize = true;
            this.pdf.Location = new System.Drawing.Point(875, 208);
            this.pdf.Name = "pdf";
            this.pdf.Size = new System.Drawing.Size(215, 36);
            this.pdf.TabIndex = 9;
            this.pdf.Text = "GeneratePdf";
            this.pdf.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1246, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 38);
            this.button2.TabIndex = 10;
            this.button2.Text = "Save";
            this.toolTip1.SetToolTip(this.button2, "Get encoded password.");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // browser
            // 
            this.browser.AutoSize = true;
            this.browser.Location = new System.Drawing.Point(128, 208);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(263, 36);
            this.browser.TabIndex = 11;
            this.browser.Text = "Open In Browser";
            this.browser.UseVisualStyleBackColor = true;
            // 
            // fromDate
            // 
            this.fromDate.Location = new System.Drawing.Point(295, 594);
            this.fromDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(200, 38);
            this.fromDate.TabIndex = 12;
            // 
            // toDate
            // 
            this.toDate.Location = new System.Drawing.Point(770, 594);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(200, 38);
            this.toDate.TabIndex = 13;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(140, 600);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(88, 32);
            this.fromLabel.TabIndex = 14;
            this.fromLabel.Text = "From:";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(624, 600);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(56, 32);
            this.toLabel.TabIndex = 15;
            this.toLabel.Text = "To:";
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.ItemHeight = 31;
            this.userList.Location = new System.Drawing.Point(391, 365);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(569, 159);
            this.userList.TabIndex = 16;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(212, 365);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(96, 32);
            this.userLabel.TabIndex = 17;
            this.userLabel.Text = "Users:";
            // 
            // noCcCheck
            // 
            this.noCcCheck.AutoSize = true;
            this.noCcCheck.Location = new System.Drawing.Point(514, 271);
            this.noCcCheck.Name = "noCcCheck";
            this.noCcCheck.Size = new System.Drawing.Size(136, 36);
            this.noCcCheck.TabIndex = 18;
            this.noCcCheck.Text = "No CC";
            this.noCcCheck.UseVisualStyleBackColor = true;
            // 
            // customSearch
            // 
            this.customSearch.AutoSize = true;
            this.customSearch.Location = new System.Drawing.Point(875, 271);
            this.customSearch.Name = "customSearch";
            this.customSearch.Size = new System.Drawing.Size(247, 36);
            this.customSearch.TabIndex = 19;
            this.customSearch.Text = "Custom Search";
            this.customSearch.UseVisualStyleBackColor = true;
            this.customSearch.CheckedChanged += new System.EventHandler(this.customSearch_CheckedChanged);
            // 
            // jiraTasks
            // 
            this.jiraTasks.Location = new System.Drawing.Point(1064, 356);
            this.jiraTasks.Name = "jiraTasks";
            this.jiraTasks.Size = new System.Drawing.Size(175, 89);
            this.jiraTasks.TabIndex = 20;
            this.jiraTasks.Text = "Check Tasks";
            this.jiraTasks.UseVisualStyleBackColor = true;
            this.jiraTasks.Click += new System.EventHandler(this.jiraTasks_Click);
            // 
            // Form4
            // 
            this.ClientSize = new System.Drawing.Size(1373, 940);
            this.Controls.Add(this.jiraTasks);
            this.Controls.Add(this.customSearch);
            this.Controls.Add(this.noCcCheck);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.fromDate);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pdf);
            this.Controls.Add(this.sendEmail);
            this.Controls.Add(this.pwdTxt);
            this.Controls.Add(this.unTxt);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.un);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Text = "Report Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label un;
        private System.Windows.Forms.Label pwd;
        private System.Windows.Forms.TextBox unTxt;
        private System.Windows.Forms.TextBox pwdTxt;
        private System.Windows.Forms.CheckBox sendEmail;
        private System.Windows.Forms.CheckBox pdf;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox browser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.CheckBox noCcCheck;
        private System.Windows.Forms.CheckBox customSearch;
        private System.Windows.Forms.Button jiraTasks;
    }
}