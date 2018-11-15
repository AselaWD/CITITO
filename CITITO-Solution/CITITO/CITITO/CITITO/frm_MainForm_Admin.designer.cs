namespace CITITO
{
    partial class frm_MainForm_Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MainForm_Admin));
            this.lblMainPanel = new System.Windows.Forms.Label();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.tglLogut = new MetroFramework.Controls.MetroToggle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.lblUserName = new MetroFramework.Controls.MetroLabel();
            this.lblLoggedTime = new MetroFramework.Controls.MetroLabel();
            this.lblUIDToFill = new MetroFramework.Controls.MetroLabel();
            this.lblUserNameToFill = new MetroFramework.Controls.MetroLabel();
            this.lblTimeToFill = new MetroFramework.Controls.MetroLabel();
            this.tileProjectRegister = new MetroFramework.Controls.MetroTile();
            this.tilePICRegistration = new MetroFramework.Controls.MetroTile();
            this.tileChangePICToProject = new MetroFramework.Controls.MetroTile();
            this.tilePTRCostResource = new MetroFramework.Controls.MetroTile();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMainPanel
            // 
            this.lblMainPanel.AutoSize = true;
            this.lblMainPanel.BackColor = System.Drawing.Color.Transparent;
            this.lblMainPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainPanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMainPanel.Location = new System.Drawing.Point(163, 52);
            this.lblMainPanel.Name = "lblMainPanel";
            this.lblMainPanel.Size = new System.Drawing.Size(149, 37);
            this.lblMainPanel.TabIndex = 125;
            this.lblMainPanel.Text = "Main Panel";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(755, 557);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 33);
            this.btnExit.TabIndex = 127;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tglLogut
            // 
            this.tglLogut.AutoSize = true;
            this.tglLogut.Checked = true;
            this.tglLogut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tglLogut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tglLogut.Location = new System.Drawing.Point(755, 40);
            this.tglLogut.Name = "tglLogut";
            this.tglLogut.Size = new System.Drawing.Size(80, 17);
            this.tglLogut.Style = MetroFramework.MetroColorStyle.Green;
            this.tglLogut.TabIndex = 128;
            this.tglLogut.Text = "On";
            this.tglLogut.UseSelectable = true;
            this.tglLogut.CheckedChanged += new System.EventHandler(this.tglLogut_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(704, 38);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(54, 19);
            this.metroLabel1.TabIndex = 129;
            this.metroLabel1.Text = "Logged";
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(72, 118);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(54, 19);
            this.lblUID.TabIndex = 130;
            this.lblUID.Text = "User ID:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(48, 146);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(78, 19);
            this.lblUserName.TabIndex = 131;
            this.lblUserName.Text = "User Name:";
            // 
            // lblLoggedTime
            // 
            this.lblLoggedTime.AutoSize = true;
            this.lblLoggedTime.Location = new System.Drawing.Point(638, 70);
            this.lblLoggedTime.Name = "lblLoggedTime";
            this.lblLoggedTime.Size = new System.Drawing.Size(41, 19);
            this.lblLoggedTime.TabIndex = 132;
            this.lblLoggedTime.Text = "Time:";
            // 
            // lblUIDToFill
            // 
            this.lblUIDToFill.AutoSize = true;
            this.lblUIDToFill.Location = new System.Drawing.Point(132, 118);
            this.lblUIDToFill.Name = "lblUIDToFill";
            this.lblUIDToFill.Size = new System.Drawing.Size(15, 19);
            this.lblUIDToFill.TabIndex = 133;
            this.lblUIDToFill.Text = "-";
            // 
            // lblUserNameToFill
            // 
            this.lblUserNameToFill.AutoSize = true;
            this.lblUserNameToFill.Location = new System.Drawing.Point(132, 146);
            this.lblUserNameToFill.Name = "lblUserNameToFill";
            this.lblUserNameToFill.Size = new System.Drawing.Size(15, 19);
            this.lblUserNameToFill.TabIndex = 134;
            this.lblUserNameToFill.Text = "-";
            // 
            // lblTimeToFill
            // 
            this.lblTimeToFill.AutoSize = true;
            this.lblTimeToFill.Location = new System.Drawing.Point(685, 70);
            this.lblTimeToFill.Name = "lblTimeToFill";
            this.lblTimeToFill.Size = new System.Drawing.Size(15, 19);
            this.lblTimeToFill.TabIndex = 135;
            this.lblTimeToFill.Text = "-";
            // 
            // tileProjectRegister
            // 
            this.tileProjectRegister.ActiveControl = null;
            this.tileProjectRegister.Location = new System.Drawing.Point(72, 331);
            this.tileProjectRegister.Name = "tileProjectRegister";
            this.tileProjectRegister.Size = new System.Drawing.Size(306, 110);
            this.tileProjectRegister.TabIndex = 136;
            this.tileProjectRegister.Text = "Registration Panel [Project, Process/Task Codes]";
            this.tileProjectRegister.UseSelectable = true;
            this.tileProjectRegister.Visible = false;
            this.tileProjectRegister.Click += new System.EventHandler(this.tileProjectRegister_Click);
            // 
            // tilePICRegistration
            // 
            this.tilePICRegistration.ActiveControl = null;
            this.tilePICRegistration.Location = new System.Drawing.Point(72, 215);
            this.tilePICRegistration.Name = "tilePICRegistration";
            this.tilePICRegistration.Size = new System.Drawing.Size(117, 110);
            this.tilePICRegistration.Style = MetroFramework.MetroColorStyle.Teal;
            this.tilePICRegistration.TabIndex = 137;
            this.tilePICRegistration.Text = "PIC Registration";
            this.tilePICRegistration.UseSelectable = true;
            this.tilePICRegistration.Click += new System.EventHandler(this.tilePICRegistration_Click);
            // 
            // tileChangePICToProject
            // 
            this.tileChangePICToProject.ActiveControl = null;
            this.tileChangePICToProject.Location = new System.Drawing.Point(195, 215);
            this.tileChangePICToProject.Name = "tileChangePICToProject";
            this.tileChangePICToProject.Size = new System.Drawing.Size(182, 110);
            this.tileChangePICToProject.Style = MetroFramework.MetroColorStyle.Green;
            this.tileChangePICToProject.TabIndex = 138;
            this.tileChangePICToProject.Text = "Change PIC\'s Project ";
            this.tileChangePICToProject.UseSelectable = true;
            this.tileChangePICToProject.Click += new System.EventHandler(this.tileChangePICToProject_Click);
            // 
            // tilePTRCostResource
            // 
            this.tilePTRCostResource.ActiveControl = null;
            this.tilePTRCostResource.Location = new System.Drawing.Point(383, 215);
            this.tilePTRCostResource.Name = "tilePTRCostResource";
            this.tilePTRCostResource.Size = new System.Drawing.Size(130, 110);
            this.tilePTRCostResource.Style = MetroFramework.MetroColorStyle.Orange;
            this.tilePTRCostResource.TabIndex = 139;
            this.tilePTRCostResource.Text = "PTR Cost Resource";
            this.tilePTRCostResource.UseSelectable = true;
            this.tilePTRCostResource.Click += new System.EventHandler(this.tilePTRCostResource_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 122;
            this.pictureBox1.TabStop = false;
            // 
            // frm_MainForm_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 613);
            this.Controls.Add(this.tilePTRCostResource);
            this.Controls.Add(this.tileChangePICToProject);
            this.Controls.Add(this.tilePICRegistration);
            this.Controls.Add(this.tileProjectRegister);
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
            this.Name = "frm_MainForm_Admin";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_MainForm_Admin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_MainForm_Admin_FormClosed);
            this.Load += new System.EventHandler(this.frm_MainForm_Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMainPanel;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroToggle tglLogut;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroLabel lblUserName;
        private MetroFramework.Controls.MetroLabel lblLoggedTime;
        private MetroFramework.Controls.MetroLabel lblUIDToFill;
        private MetroFramework.Controls.MetroLabel lblUserNameToFill;
        private MetroFramework.Controls.MetroLabel lblTimeToFill;
        private MetroFramework.Controls.MetroTile tileProjectRegister;
        private MetroFramework.Controls.MetroTile tilePICRegistration;
        private MetroFramework.Controls.MetroTile tileChangePICToProject;
        private MetroFramework.Controls.MetroTile tilePTRCostResource;
    }
}