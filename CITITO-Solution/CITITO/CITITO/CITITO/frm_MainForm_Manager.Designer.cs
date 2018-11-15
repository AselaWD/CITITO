namespace CITITO
{
    partial class frm_MainForm_Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MainForm_Manager));
            this.tileUserRegistration = new MetroFramework.Controls.MetroTile();
            this.lblTimeToFill = new MetroFramework.Controls.MetroLabel();
            this.lblUserNameToFill = new MetroFramework.Controls.MetroLabel();
            this.lblUIDToFill = new MetroFramework.Controls.MetroLabel();
            this.lblLoggedTime = new MetroFramework.Controls.MetroLabel();
            this.lblUserName = new MetroFramework.Controls.MetroLabel();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tglLogut = new MetroFramework.Controls.MetroToggle();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.lblMainPanel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tielTaskApproval = new MetroFramework.Controls.MetroTile();
            this.tileReports = new MetroFramework.Controls.MetroTile();
            this.lblPICToFill = new MetroFramework.Controls.MetroLabel();
            this.lblPICName = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tileUserRegistration
            // 
            this.tileUserRegistration.ActiveControl = null;
            this.tileUserRegistration.Location = new System.Drawing.Point(78, 217);
            this.tileUserRegistration.Name = "tileUserRegistration";
            this.tileUserRegistration.Size = new System.Drawing.Size(152, 110);
            this.tileUserRegistration.Style = MetroFramework.MetroColorStyle.Teal;
            this.tileUserRegistration.TabIndex = 151;
            this.tileUserRegistration.Text = "User Registration";
            this.tileUserRegistration.UseSelectable = true;
            this.tileUserRegistration.UseStyleColors = true;
            this.tileUserRegistration.Click += new System.EventHandler(this.tileUserRegistration_Click);
            // 
            // lblTimeToFill
            // 
            this.lblTimeToFill.AutoSize = true;
            this.lblTimeToFill.Location = new System.Drawing.Point(691, 74);
            this.lblTimeToFill.Name = "lblTimeToFill";
            this.lblTimeToFill.Size = new System.Drawing.Size(15, 19);
            this.lblTimeToFill.TabIndex = 148;
            this.lblTimeToFill.Text = "-";
            // 
            // lblUserNameToFill
            // 
            this.lblUserNameToFill.AutoSize = true;
            this.lblUserNameToFill.Location = new System.Drawing.Point(159, 151);
            this.lblUserNameToFill.Name = "lblUserNameToFill";
            this.lblUserNameToFill.Size = new System.Drawing.Size(15, 19);
            this.lblUserNameToFill.TabIndex = 147;
            this.lblUserNameToFill.Text = "-";
            // 
            // lblUIDToFill
            // 
            this.lblUIDToFill.AutoSize = true;
            this.lblUIDToFill.Location = new System.Drawing.Point(159, 123);
            this.lblUIDToFill.Name = "lblUIDToFill";
            this.lblUIDToFill.Size = new System.Drawing.Size(15, 19);
            this.lblUIDToFill.TabIndex = 146;
            this.lblUIDToFill.Text = "-";
            // 
            // lblLoggedTime
            // 
            this.lblLoggedTime.AutoSize = true;
            this.lblLoggedTime.Location = new System.Drawing.Point(644, 74);
            this.lblLoggedTime.Name = "lblLoggedTime";
            this.lblLoggedTime.Size = new System.Drawing.Size(41, 19);
            this.lblLoggedTime.TabIndex = 145;
            this.lblLoggedTime.Text = "Time:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(75, 151);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(78, 19);
            this.lblUserName.TabIndex = 144;
            this.lblUserName.Text = "User Name:";
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(99, 123);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(54, 19);
            this.lblUID.TabIndex = 143;
            this.lblUID.Text = "User ID:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(710, 42);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(54, 19);
            this.metroLabel1.TabIndex = 142;
            this.metroLabel1.Text = "Logged";
            // 
            // tglLogut
            // 
            this.tglLogut.AutoSize = true;
            this.tglLogut.Checked = true;
            this.tglLogut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tglLogut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tglLogut.Location = new System.Drawing.Point(761, 44);
            this.tglLogut.Name = "tglLogut";
            this.tglLogut.Size = new System.Drawing.Size(80, 17);
            this.tglLogut.Style = MetroFramework.MetroColorStyle.Green;
            this.tglLogut.TabIndex = 141;
            this.tglLogut.Text = "On";
            this.tglLogut.UseSelectable = true;
            this.tglLogut.CheckedChanged += new System.EventHandler(this.tglLogut_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(761, 561);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 33);
            this.btnExit.TabIndex = 140;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblMainPanel
            // 
            this.lblMainPanel.AutoSize = true;
            this.lblMainPanel.BackColor = System.Drawing.Color.Transparent;
            this.lblMainPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainPanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMainPanel.Location = new System.Drawing.Point(169, 56);
            this.lblMainPanel.Name = "lblMainPanel";
            this.lblMainPanel.Size = new System.Drawing.Size(262, 37);
            this.lblMainPanel.TabIndex = 139;
            this.lblMainPanel.Text = "Main Panel Manager";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 138;
            this.pictureBox1.TabStop = false;
            // 
            // tielTaskApproval
            // 
            this.tielTaskApproval.ActiveControl = null;
            this.tielTaskApproval.Location = new System.Drawing.Point(236, 217);
            this.tielTaskApproval.Name = "tielTaskApproval";
            this.tielTaskApproval.Size = new System.Drawing.Size(185, 110);
            this.tielTaskApproval.Style = MetroFramework.MetroColorStyle.Green;
            this.tielTaskApproval.TabIndex = 152;
            this.tielTaskApproval.Text = "Task Approval";
            this.tielTaskApproval.UseSelectable = true;
            this.tielTaskApproval.Click += new System.EventHandler(this.tielTaskApproval_Click);
            // 
            // tileReports
            // 
            this.tileReports.ActiveControl = null;
            this.tileReports.Location = new System.Drawing.Point(427, 217);
            this.tileReports.Name = "tileReports";
            this.tileReports.Size = new System.Drawing.Size(168, 110);
            this.tileReports.Style = MetroFramework.MetroColorStyle.Purple;
            this.tileReports.TabIndex = 153;
            this.tileReports.Text = "Reports";
            this.tileReports.UseSelectable = true;
            this.tileReports.Click += new System.EventHandler(this.tileReports_Click);
            // 
            // lblPICToFill
            // 
            this.lblPICToFill.AutoSize = true;
            this.lblPICToFill.Location = new System.Drawing.Point(160, 179);
            this.lblPICToFill.Name = "lblPICToFill";
            this.lblPICToFill.Size = new System.Drawing.Size(15, 19);
            this.lblPICToFill.TabIndex = 155;
            this.lblPICToFill.Text = "-";
            // 
            // lblPICName
            // 
            this.lblPICName.AutoSize = true;
            this.lblPICName.Location = new System.Drawing.Point(39, 179);
            this.lblPICName.Name = "lblPICName";
            this.lblPICName.Size = new System.Drawing.Size(114, 19);
            this.lblPICName.TabIndex = 154;
            this.lblPICName.Text = "Project In Charge:";
            // 
            // frm_MainForm_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 613);
            this.Controls.Add(this.lblPICToFill);
            this.Controls.Add(this.lblPICName);
            this.Controls.Add(this.tileReports);
            this.Controls.Add(this.tielTaskApproval);
            this.Controls.Add(this.tileUserRegistration);
            this.Controls.Add(this.lblTimeToFill);
            this.Controls.Add(this.lblUserNameToFill);
            this.Controls.Add(this.lblUIDToFill);
            this.Controls.Add(this.lblLoggedTime);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tglLogut);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblMainPanel);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_MainForm_Manager";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_MainForm_Manager_FormClosing);
            this.Load += new System.EventHandler(this.frm_MainForm_Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile tileUserRegistration;
        private MetroFramework.Controls.MetroLabel lblTimeToFill;
        private MetroFramework.Controls.MetroLabel lblUserNameToFill;
        private MetroFramework.Controls.MetroLabel lblUIDToFill;
        private MetroFramework.Controls.MetroLabel lblLoggedTime;
        private MetroFramework.Controls.MetroLabel lblUserName;
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroToggle tglLogut;
        private MetroFramework.Controls.MetroButton btnExit;
        private System.Windows.Forms.Label lblMainPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTile tielTaskApproval;
        private MetroFramework.Controls.MetroTile tileReports;
        private MetroFramework.Controls.MetroLabel lblPICToFill;
        private MetroFramework.Controls.MetroLabel lblPICName;
    }
}