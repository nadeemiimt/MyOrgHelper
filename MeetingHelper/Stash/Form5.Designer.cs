namespace DailyHelper
{
    partial class Form5
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
            this.un = new System.Windows.Forms.Label();
            this.unTxt = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.Label();
            this.pwdTxt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timerTxt = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fetchPr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prTitleTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openTasks = new System.Windows.Forms.TextBox();
            this.BuildPassed = new System.Windows.Forms.CheckBox();
            this.MandatoryApprovals = new System.Windows.Forms.CheckBox();
            this.MasterPassed = new System.Windows.Forms.CheckBox();
            this.mergePR = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.autoMerge = new System.Windows.Forms.CheckBox();
            this.HasConflicts = new System.Windows.Forms.CheckBox();
            this.RebaseAvailable = new System.Windows.Forms.CheckBox();
            this.CanMerge = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.refresh = new System.Windows.Forms.Button();
            this.NoPermission = new System.Windows.Forms.CheckBox();
            this.rebaseBtn = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.CheckBox();
            this.AutoRebase = new System.Windows.Forms.CheckBox();
            this.autoClose = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.Custom = new System.Windows.Forms.RadioButton();
            this.customPRTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.approvePR = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ChangeStatus = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.prStatusDpdwn = new System.Windows.Forms.ComboBox();
            this.blockerChk = new System.Windows.Forms.CheckBox();
            this.RebaseRequired = new System.Windows.Forms.CheckBox();
            this.openPR = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // un
            // 
            this.un.AutoSize = true;
            this.un.Location = new System.Drawing.Point(67, 93);
            this.un.Name = "un";
            this.un.Size = new System.Drawing.Size(63, 32);
            this.un.TabIndex = 5;
            this.un.Text = "UN:";
            // 
            // unTxt
            // 
            this.unTxt.Location = new System.Drawing.Point(172, 87);
            this.unTxt.Name = "unTxt";
            this.unTxt.Size = new System.Drawing.Size(351, 38);
            this.unTxt.TabIndex = 7;
            // 
            // pwd
            // 
            this.pwd.AutoSize = true;
            this.pwd.Location = new System.Drawing.Point(603, 81);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(88, 32);
            this.pwd.TabIndex = 8;
            this.pwd.Text = "PWD:";
            // 
            // pwdTxt
            // 
            this.pwdTxt.Location = new System.Drawing.Point(717, 75);
            this.pwdTxt.Name = "pwdTxt";
            this.pwdTxt.Size = new System.Drawing.Size(351, 38);
            this.pwdTxt.TabIndex = 9;
            this.pwdTxt.UseSystemPasswordChar = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1085, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 58);
            this.button2.TabIndex = 11;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timerTxt
            // 
            this.timerTxt.Location = new System.Drawing.Point(912, 801);
            this.timerTxt.Name = "timerTxt";
            this.timerTxt.Size = new System.Drawing.Size(82, 38);
            this.timerTxt.TabIndex = 36;
            this.toolTip1.SetToolTip(this.timerTxt, "In minutes.");
            // 
            // fetchPr
            // 
            this.fetchPr.Location = new System.Drawing.Point(510, 248);
            this.fetchPr.Name = "fetchPr";
            this.fetchPr.Size = new System.Drawing.Size(156, 54);
            this.fetchPr.TabIndex = 12;
            this.fetchPr.Text = "Fetch PRs";
            this.fetchPr.UseVisualStyleBackColor = true;
            this.fetchPr.Click += new System.EventHandler(this.fetchPr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Approvers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 32);
            this.label2.TabIndex = 16;
            this.label2.Text = "PR Title: ";
            // 
            // prTitleTxt
            // 
            this.prTitleTxt.Location = new System.Drawing.Point(188, 414);
            this.prTitleTxt.Multiline = true;
            this.prTitleTxt.Name = "prTitleTxt";
            this.prTitleTxt.ReadOnly = true;
            this.prTitleTxt.Size = new System.Drawing.Size(941, 38);
            this.prTitleTxt.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 584);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 32);
            this.label3.TabIndex = 18;
            this.label3.Text = "Open Tasks:";
            // 
            // openTasks
            // 
            this.openTasks.Location = new System.Drawing.Point(214, 578);
            this.openTasks.Name = "openTasks";
            this.openTasks.ReadOnly = true;
            this.openTasks.Size = new System.Drawing.Size(74, 38);
            this.openTasks.TabIndex = 19;
            // 
            // BuildPassed
            // 
            this.BuildPassed.AutoSize = true;
            this.BuildPassed.Enabled = false;
            this.BuildPassed.Location = new System.Drawing.Point(339, 580);
            this.BuildPassed.Name = "BuildPassed";
            this.BuildPassed.Size = new System.Drawing.Size(220, 36);
            this.BuildPassed.TabIndex = 20;
            this.BuildPassed.Text = "Build Passed";
            this.BuildPassed.UseVisualStyleBackColor = true;
            // 
            // MandatoryApprovals
            // 
            this.MandatoryApprovals.AutoSize = true;
            this.MandatoryApprovals.Enabled = false;
            this.MandatoryApprovals.Location = new System.Drawing.Point(603, 580);
            this.MandatoryApprovals.Name = "MandatoryApprovals";
            this.MandatoryApprovals.Size = new System.Drawing.Size(321, 36);
            this.MandatoryApprovals.TabIndex = 21;
            this.MandatoryApprovals.Text = "Mandatory Approvals";
            this.MandatoryApprovals.UseVisualStyleBackColor = true;
            // 
            // MasterPassed
            // 
            this.MasterPassed.AutoSize = true;
            this.MasterPassed.Enabled = false;
            this.MasterPassed.Location = new System.Drawing.Point(935, 580);
            this.MasterPassed.Name = "MasterPassed";
            this.MasterPassed.Size = new System.Drawing.Size(241, 36);
            this.MasterPassed.TabIndex = 22;
            this.MasterPassed.Text = "Master Passed";
            this.MasterPassed.UseVisualStyleBackColor = true;
            // 
            // mergePR
            // 
            this.mergePR.Location = new System.Drawing.Point(403, 845);
            this.mergePR.Name = "mergePR";
            this.mergePR.Size = new System.Drawing.Size(156, 54);
            this.mergePR.TabIndex = 23;
            this.mergePR.Text = "Merge PR";
            this.mergePR.UseVisualStyleBackColor = true;
            this.mergePR.Click += new System.EventHandler(this.mergePR_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 32);
            this.label4.TabIndex = 24;
            this.label4.Text = "PRs:";
            // 
            // autoMerge
            // 
            this.autoMerge.AutoSize = true;
            this.autoMerge.Location = new System.Drawing.Point(656, 802);
            this.autoMerge.Name = "autoMerge";
            this.autoMerge.Size = new System.Drawing.Size(199, 36);
            this.autoMerge.TabIndex = 25;
            this.autoMerge.Text = "Auto Merge";
            this.autoMerge.UseVisualStyleBackColor = true;
            this.autoMerge.CheckedChanged += new System.EventHandler(this.autoMerge_CheckedChanged);
            // 
            // HasConflicts
            // 
            this.HasConflicts.AutoSize = true;
            this.HasConflicts.Enabled = false;
            this.HasConflicts.Location = new System.Drawing.Point(339, 652);
            this.HasConflicts.Name = "HasConflicts";
            this.HasConflicts.Size = new System.Drawing.Size(220, 36);
            this.HasConflicts.TabIndex = 26;
            this.HasConflicts.Text = "Has Conflicts";
            this.HasConflicts.UseVisualStyleBackColor = true;
            // 
            // RebaseAvailable
            // 
            this.RebaseAvailable.AutoSize = true;
            this.RebaseAvailable.Enabled = false;
            this.RebaseAvailable.Location = new System.Drawing.Point(27, 652);
            this.RebaseAvailable.Name = "RebaseAvailable";
            this.RebaseAvailable.Size = new System.Drawing.Size(276, 36);
            this.RebaseAvailable.TabIndex = 27;
            this.RebaseAvailable.Text = "Rebase Available";
            this.RebaseAvailable.UseVisualStyleBackColor = true;
            // 
            // CanMerge
            // 
            this.CanMerge.AutoSize = true;
            this.CanMerge.Enabled = false;
            this.CanMerge.Location = new System.Drawing.Point(603, 652);
            this.CanMerge.Name = "CanMerge";
            this.CanMerge.Size = new System.Drawing.Size(192, 36);
            this.CanMerge.TabIndex = 28;
            this.CanMerge.Text = "Can Merge";
            this.CanMerge.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(188, 332);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(941, 39);
            this.comboBox1.TabIndex = 29;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(188, 492);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(941, 39);
            this.comboBox2.TabIndex = 30;
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(1153, 321);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(67, 58);
            this.refresh.TabIndex = 31;
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // NoPermission
            // 
            this.NoPermission.AutoSize = true;
            this.NoPermission.Enabled = false;
            this.NoPermission.Location = new System.Drawing.Point(935, 652);
            this.NoPermission.Name = "NoPermission";
            this.NoPermission.Size = new System.Drawing.Size(237, 36);
            this.NoPermission.TabIndex = 32;
            this.NoPermission.Text = "No Permission";
            this.NoPermission.UseVisualStyleBackColor = true;
            // 
            // rebaseBtn
            // 
            this.rebaseBtn.Enabled = false;
            this.rebaseBtn.Location = new System.Drawing.Point(27, 844);
            this.rebaseBtn.Name = "rebaseBtn";
            this.rebaseBtn.Size = new System.Drawing.Size(156, 56);
            this.rebaseBtn.TabIndex = 33;
            this.rebaseBtn.Text = "Rebase PR";
            this.rebaseBtn.UseVisualStyleBackColor = true;
            this.rebaseBtn.Click += new System.EventHandler(this.rebaseBtn_Click);
            // 
            // confirm
            // 
            this.confirm.AutoSize = true;
            this.confirm.Location = new System.Drawing.Point(656, 882);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(239, 36);
            this.confirm.TabIndex = 34;
            this.confirm.Text = "Confirm Merge";
            this.confirm.UseVisualStyleBackColor = true;
            // 
            // AutoRebase
            // 
            this.AutoRebase.AutoSize = true;
            this.AutoRebase.Location = new System.Drawing.Point(912, 882);
            this.AutoRebase.Name = "AutoRebase";
            this.AutoRebase.Size = new System.Drawing.Size(217, 36);
            this.AutoRebase.TabIndex = 35;
            this.AutoRebase.Text = "Auto Rebase";
            this.AutoRebase.UseVisualStyleBackColor = true;
            // 
            // autoClose
            // 
            this.autoClose.AutoSize = true;
            this.autoClose.Location = new System.Drawing.Point(1028, 803);
            this.autoClose.Name = "autoClose";
            this.autoClose.Size = new System.Drawing.Size(192, 36);
            this.autoClose.TabIndex = 37;
            this.autoClose.Text = "Auto Close";
            this.autoClose.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 37);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(143, 36);
            this.radioButton1.TabIndex = 38;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Default";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Custom
            // 
            this.Custom.AutoSize = true;
            this.Custom.Location = new System.Drawing.Point(193, 37);
            this.Custom.Name = "Custom";
            this.Custom.Size = new System.Drawing.Size(149, 36);
            this.Custom.TabIndex = 39;
            this.Custom.Text = "Custom";
            this.Custom.UseVisualStyleBackColor = true;
            this.Custom.CheckedChanged += new System.EventHandler(this.Custom_CheckedChanged);
            // 
            // customPRTxt
            // 
            this.customPRTxt.Enabled = false;
            this.customPRTxt.Location = new System.Drawing.Point(773, 181);
            this.customPRTxt.Name = "customPRTxt";
            this.customPRTxt.Size = new System.Drawing.Size(420, 38);
            this.customPRTxt.TabIndex = 40;
            this.customPRTxt.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.Custom);
            this.groupBox1.Location = new System.Drawing.Point(339, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 86);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // approvePR
            // 
            this.approvePR.Enabled = false;
            this.approvePR.Location = new System.Drawing.Point(768, 248);
            this.approvePR.Name = "approvePR";
            this.approvePR.Size = new System.Drawing.Size(156, 56);
            this.approvePR.TabIndex = 42;
            this.approvePR.Text = "Approve";
            this.approvePR.UseVisualStyleBackColor = true;
            this.approvePR.Visible = false;
            this.approvePR.Click += new System.EventHandler(this.approvePR_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 32);
            this.label5.TabIndex = 43;
            this.label5.Text = "Status:";
            // 
            // ChangeStatus
            // 
            this.ChangeStatus.Location = new System.Drawing.Point(392, 73);
            this.ChangeStatus.Name = "ChangeStatus";
            this.ChangeStatus.Size = new System.Drawing.Size(155, 52);
            this.ChangeStatus.TabIndex = 45;
            this.ChangeStatus.Text = "Change";
            this.ChangeStatus.UseVisualStyleBackColor = true;
            this.ChangeStatus.Click += new System.EventHandler(this.ChangeStatus_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.prStatusDpdwn);
            this.panel1.Controls.Add(this.ChangeStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(27, 965);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 144);
            this.panel1.TabIndex = 46;
            this.panel1.Visible = false;
            // 
            // prStatusDpdwn
            // 
            this.prStatusDpdwn.FormattingEnabled = true;
            this.prStatusDpdwn.Location = new System.Drawing.Point(34, 77);
            this.prStatusDpdwn.Name = "prStatusDpdwn";
            this.prStatusDpdwn.Size = new System.Drawing.Size(339, 39);
            this.prStatusDpdwn.TabIndex = 47;
            // 
            // blockerChk
            // 
            this.blockerChk.AutoSize = true;
            this.blockerChk.Location = new System.Drawing.Point(339, 732);
            this.blockerChk.Name = "blockerChk";
            this.blockerChk.Size = new System.Drawing.Size(205, 36);
            this.blockerChk.TabIndex = 47;
            this.blockerChk.Text = "Has Blocker";
            this.blockerChk.UseVisualStyleBackColor = true;
            // 
            // RebaseRequired
            // 
            this.RebaseRequired.AutoSize = true;
            this.RebaseRequired.Enabled = false;
            this.RebaseRequired.Location = new System.Drawing.Point(27, 732);
            this.RebaseRequired.Name = "RebaseRequired";
            this.RebaseRequired.Size = new System.Drawing.Size(274, 36);
            this.RebaseRequired.TabIndex = 48;
            this.RebaseRequired.Text = "Rebase Required";
            this.RebaseRequired.UseVisualStyleBackColor = true;
            // 
            // openPR
            // 
            this.openPR.Enabled = false;
            this.openPR.Location = new System.Drawing.Point(1153, 431);
            this.openPR.Name = "openPR";
            this.openPR.Size = new System.Drawing.Size(155, 52);
            this.openPR.TabIndex = 48;
            this.openPR.Text = "Open";
            this.openPR.UseVisualStyleBackColor = true;
            this.openPR.Click += new System.EventHandler(this.openPR_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1337, 1172);
            this.Controls.Add(this.openPR);
            this.Controls.Add(this.RebaseRequired);
            this.Controls.Add(this.blockerChk);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.approvePR);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customPRTxt);
            this.Controls.Add(this.autoClose);
            this.Controls.Add(this.timerTxt);
            this.Controls.Add(this.AutoRebase);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.rebaseBtn);
            this.Controls.Add(this.NoPermission);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.CanMerge);
            this.Controls.Add(this.RebaseAvailable);
            this.Controls.Add(this.HasConflicts);
            this.Controls.Add(this.autoMerge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mergePR);
            this.Controls.Add(this.MasterPassed);
            this.Controls.Add(this.MandatoryApprovals);
            this.Controls.Add(this.BuildPassed);
            this.Controls.Add(this.openTasks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.prTitleTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fetchPr);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pwdTxt);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.unTxt);
            this.Controls.Add(this.un);
            this.Name = "Form5";
            this.Text = "Stash Helper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label un;
        private System.Windows.Forms.TextBox unTxt;
        private System.Windows.Forms.Label pwd;
        private System.Windows.Forms.TextBox pwdTxt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button fetchPr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox prTitleTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox openTasks;
        private System.Windows.Forms.CheckBox BuildPassed;
        private System.Windows.Forms.CheckBox MandatoryApprovals;
        private System.Windows.Forms.CheckBox MasterPassed;
        private System.Windows.Forms.Button mergePR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox autoMerge;
        private System.Windows.Forms.CheckBox HasConflicts;
        private System.Windows.Forms.CheckBox RebaseAvailable;
        private System.Windows.Forms.CheckBox CanMerge;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.CheckBox NoPermission;
        private System.Windows.Forms.Button rebaseBtn;
        private System.Windows.Forms.CheckBox confirm;
        private System.Windows.Forms.CheckBox AutoRebase;
        private System.Windows.Forms.TextBox timerTxt;
        private System.Windows.Forms.CheckBox autoClose;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton Custom;
        private System.Windows.Forms.TextBox customPRTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button approvePR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ChangeStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox prStatusDpdwn;
        private System.Windows.Forms.CheckBox blockerChk;
        private System.Windows.Forms.CheckBox RebaseRequired;
        private System.Windows.Forms.Button openPR;
    }
}