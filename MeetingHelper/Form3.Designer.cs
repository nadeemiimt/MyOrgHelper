namespace DailyHelper
{
    partial class Form3
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
            this.Meeting = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Button();
            this.stashBtn = new System.Windows.Forms.Button();
            this.un = new System.Windows.Forms.Label();
            this.unTxt = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.Label();
            this.pwdTxt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.localOutlook = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Meeting
            // 
            this.Meeting.Location = new System.Drawing.Point(73, 209);
            this.Meeting.Name = "Meeting";
            this.Meeting.Size = new System.Drawing.Size(187, 98);
            this.Meeting.TabIndex = 0;
            this.Meeting.Text = "Meeting";
            this.Meeting.UseVisualStyleBackColor = true;
            this.Meeting.Click += new System.EventHandler(this.Meeting_Click);
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(391, 209);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(187, 98);
            this.Status.TabIndex = 1;
            this.Status.Text = "Weekly Status";
            this.Status.UseVisualStyleBackColor = true;
            this.Status.Click += new System.EventHandler(this.Status_Click);
            // 
            // stashBtn
            // 
            this.stashBtn.Location = new System.Drawing.Point(710, 209);
            this.stashBtn.Name = "stashBtn";
            this.stashBtn.Size = new System.Drawing.Size(187, 98);
            this.stashBtn.TabIndex = 2;
            this.stashBtn.Text = "Stash";
            this.stashBtn.UseVisualStyleBackColor = true;
            this.stashBtn.Click += new System.EventHandler(this.stashBtn_Click);
            // 
            // un
            // 
            this.un.AutoSize = true;
            this.un.Location = new System.Drawing.Point(67, 61);
            this.un.Name = "un";
            this.un.Size = new System.Drawing.Size(63, 32);
            this.un.TabIndex = 5;
            this.un.Text = "UN:";
            // 
            // unTxt
            // 
            this.unTxt.Location = new System.Drawing.Point(146, 55);
            this.unTxt.Name = "unTxt";
            this.unTxt.Size = new System.Drawing.Size(351, 38);
            this.unTxt.TabIndex = 7;
            // 
            // pwd
            // 
            this.pwd.AutoSize = true;
            this.pwd.Location = new System.Drawing.Point(540, 61);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(88, 32);
            this.pwd.TabIndex = 8;
            this.pwd.Text = "PWD:";
            // 
            // pwdTxt
            // 
            this.pwdTxt.Location = new System.Drawing.Point(648, 55);
            this.pwdTxt.Name = "pwdTxt";
            this.pwdTxt.Size = new System.Drawing.Size(351, 38);
            this.pwdTxt.TabIndex = 9;
            this.pwdTxt.UseSystemPasswordChar = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1034, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 51);
            this.button2.TabIndex = 11;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // localOutlook
            // 
            this.localOutlook.AutoSize = true;
            this.localOutlook.Location = new System.Drawing.Point(88, 368);
            this.localOutlook.Name = "localOutlook";
            this.localOutlook.Size = new System.Drawing.Size(228, 36);
            this.localOutlook.TabIndex = 12;
            this.localOutlook.Text = "Local Outlook";
            this.localOutlook.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1191, 815);
            this.Controls.Add(this.localOutlook);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pwdTxt);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.unTxt);
            this.Controls.Add(this.un);
            this.Controls.Add(this.stashBtn);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Meeting);
            this.Name = "Form3";
            this.Text = "Daily Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Meeting;
        private System.Windows.Forms.Button Status;
        private System.Windows.Forms.Button stashBtn;
        private System.Windows.Forms.Label un;
        private System.Windows.Forms.TextBox unTxt;
        private System.Windows.Forms.Label pwd;
        private System.Windows.Forms.TextBox pwdTxt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox localOutlook;
    }
}