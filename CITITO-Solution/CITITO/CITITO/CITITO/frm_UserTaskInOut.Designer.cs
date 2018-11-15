namespace CITITO
{
    partial class frm_UserTaskInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserTaskInOut));
            this.line = new MetroFramework.Controls.MetroPanel();
            this.lblManagerToFill = new MetroFramework.Controls.MetroLabel();
            this.lblManager = new MetroFramework.Controls.MetroLabel();
            this.lblTimeToFill = new MetroFramework.Controls.MetroLabel();
            this.lblUserNameToFill = new MetroFramework.Controls.MetroLabel();
            this.lblUIDToFill = new MetroFramework.Controls.MetroLabel();
            this.lblLoggedTime = new MetroFramework.Controls.MetroLabel();
            this.lblUserName = new MetroFramework.Controls.MetroLabel();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tglLogut = new MetroFramework.Controls.MetroToggle();
            this.lblUserTaskPanel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelLeft = new MetroFramework.Controls.MetroPanel();
            this.tileIDLE = new MetroFramework.Controls.MetroTile();
            this.tileTaskInOut = new MetroFramework.Controls.MetroTile();
            this.pnlMain = new MetroFramework.Controls.MetroPanel();
            this.panelHover = new MetroFramework.Controls.MetroPanel();
            this.CITITONotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.tileX3 = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.Teal;
            this.line.HorizontalScrollbarBarColor = true;
            this.line.HorizontalScrollbarHighlightOnWheel = false;
            this.line.HorizontalScrollbarSize = 10;
            this.line.Location = new System.Drawing.Point(-1, 164);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(1229, 2);
            this.line.TabIndex = 162;
            this.line.UseCustomBackColor = true;
            this.line.VerticalScrollbarBarColor = true;
            this.line.VerticalScrollbarHighlightOnWheel = false;
            this.line.VerticalScrollbarSize = 10;
            // 
            // lblManagerToFill
            // 
            this.lblManagerToFill.AutoSize = true;
            this.lblManagerToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblManagerToFill.Location = new System.Drawing.Point(161, 141);
            this.lblManagerToFill.Name = "lblManagerToFill";
            this.lblManagerToFill.Size = new System.Drawing.Size(12, 15);
            this.lblManagerToFill.TabIndex = 161;
            this.lblManagerToFill.Text = "-";
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblManager.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblManager.Location = new System.Drawing.Point(33, 141);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(122, 15);
            this.lblManager.TabIndex = 160;
            this.lblManager.Text = "Immidiate Supervisor:";
            // 
            // lblTimeToFill
            // 
            this.lblTimeToFill.AutoSize = true;
            this.lblTimeToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTimeToFill.Location = new System.Drawing.Point(1031, 72);
            this.lblTimeToFill.Name = "lblTimeToFill";
            this.lblTimeToFill.Size = new System.Drawing.Size(12, 15);
            this.lblTimeToFill.TabIndex = 159;
            this.lblTimeToFill.Text = "-";
            // 
            // lblUserNameToFill
            // 
            this.lblUserNameToFill.AutoSize = true;
            this.lblUserNameToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUserNameToFill.Location = new System.Drawing.Point(161, 118);
            this.lblUserNameToFill.Name = "lblUserNameToFill";
            this.lblUserNameToFill.Size = new System.Drawing.Size(12, 15);
            this.lblUserNameToFill.TabIndex = 158;
            this.lblUserNameToFill.Text = "-";
            // 
            // lblUIDToFill
            // 
            this.lblUIDToFill.AutoSize = true;
            this.lblUIDToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUIDToFill.Location = new System.Drawing.Point(161, 98);
            this.lblUIDToFill.Name = "lblUIDToFill";
            this.lblUIDToFill.Size = new System.Drawing.Size(12, 15);
            this.lblUIDToFill.TabIndex = 157;
            this.lblUIDToFill.Text = "-";
            // 
            // lblLoggedTime
            // 
            this.lblLoggedTime.AutoSize = true;
            this.lblLoggedTime.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblLoggedTime.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblLoggedTime.Location = new System.Drawing.Point(988, 72);
            this.lblLoggedTime.Name = "lblLoggedTime";
            this.lblLoggedTime.Size = new System.Drawing.Size(37, 15);
            this.lblLoggedTime.TabIndex = 156;
            this.lblLoggedTime.Text = "Time:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUserName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblUserName.Location = new System.Drawing.Point(87, 118);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(68, 15);
            this.lblUserName.TabIndex = 155;
            this.lblUserName.Text = "User Name:";
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUID.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblUID.Location = new System.Drawing.Point(108, 98);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(47, 15);
            this.lblUID.TabIndex = 154;
            this.lblUID.Text = "User ID:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(1075, 42);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(54, 19);
            this.metroLabel1.TabIndex = 153;
            this.metroLabel1.Text = "Logged";
            // 
            // tglLogut
            // 
            this.tglLogut.AutoSize = true;
            this.tglLogut.Checked = true;
            this.tglLogut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tglLogut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tglLogut.Location = new System.Drawing.Point(1126, 44);
            this.tglLogut.Name = "tglLogut";
            this.tglLogut.Size = new System.Drawing.Size(80, 17);
            this.tglLogut.Style = MetroFramework.MetroColorStyle.Green;
            this.tglLogut.TabIndex = 152;
            this.tglLogut.Text = "On";
            this.tglLogut.UseSelectable = true;
            this.tglLogut.CheckedChanged += new System.EventHandler(this.tglLogut_CheckedChanged);
            // 
            // lblUserTaskPanel
            // 
            this.lblUserTaskPanel.AutoSize = true;
            this.lblUserTaskPanel.BackColor = System.Drawing.Color.Transparent;
            this.lblUserTaskPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserTaskPanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblUserTaskPanel.Location = new System.Drawing.Point(126, 44);
            this.lblUserTaskPanel.Name = "lblUserTaskPanel";
            this.lblUserTaskPanel.Size = new System.Drawing.Size(158, 30);
            this.lblUserTaskPanel.TabIndex = 151;
            this.lblUserTaskPanel.Text = "User Task Panel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 150;
            this.pictureBox1.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.tileX3);
            this.panelLeft.Controls.Add(this.tileIDLE);
            this.panelLeft.Controls.Add(this.tileTaskInOut);
            this.panelLeft.HorizontalScrollbarBarColor = true;
            this.panelLeft.HorizontalScrollbarHighlightOnWheel = false;
            this.panelLeft.HorizontalScrollbarSize = 10;
            this.panelLeft.Location = new System.Drawing.Point(-1, 166);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(156, 660);
            this.panelLeft.TabIndex = 163;
            this.panelLeft.UseCustomBackColor = true;
            this.panelLeft.VerticalScrollbarBarColor = true;
            this.panelLeft.VerticalScrollbarHighlightOnWheel = false;
            this.panelLeft.VerticalScrollbarSize = 10;
            // 
            // tileIDLE
            // 
            this.tileIDLE.ActiveControl = null;
            this.tileIDLE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileIDLE.Location = new System.Drawing.Point(0, 66);
            this.tileIDLE.Name = "tileIDLE";
            this.tileIDLE.Size = new System.Drawing.Size(156, 62);
            this.tileIDLE.Style = MetroFramework.MetroColorStyle.Blue;
            this.tileIDLE.TabIndex = 3;
            this.tileIDLE.Text = "IDLE";
            this.tileIDLE.UseSelectable = true;
            this.tileIDLE.Click += new System.EventHandler(this.tileIDLE_Click);
            // 
            // tileTaskInOut
            // 
            this.tileTaskInOut.ActiveControl = null;
            this.tileTaskInOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileTaskInOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileTaskInOut.Location = new System.Drawing.Point(0, 0);
            this.tileTaskInOut.Name = "tileTaskInOut";
            this.tileTaskInOut.Size = new System.Drawing.Size(154, 62);
            this.tileTaskInOut.Style = MetroFramework.MetroColorStyle.Teal;
            this.tileTaskInOut.TabIndex = 2;
            this.tileTaskInOut.Text = "Task In/Out";
            this.tileTaskInOut.UseSelectable = true;
            this.tileTaskInOut.Click += new System.EventHandler(this.tileTaskInOut_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.HorizontalScrollbarBarColor = true;
            this.pnlMain.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMain.HorizontalScrollbarSize = 10;
            this.pnlMain.Location = new System.Drawing.Point(156, 166);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1071, 652);
            this.pnlMain.TabIndex = 164;
            this.pnlMain.VerticalScrollbarBarColor = true;
            this.pnlMain.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMain.VerticalScrollbarSize = 10;
            // 
            // panelHover
            // 
            this.panelHover.BackColor = System.Drawing.Color.Gold;
            this.panelHover.HorizontalScrollbarBarColor = true;
            this.panelHover.HorizontalScrollbarHighlightOnWheel = false;
            this.panelHover.HorizontalScrollbarSize = 10;
            this.panelHover.Location = new System.Drawing.Point(155, 166);
            this.panelHover.Name = "panelHover";
            this.panelHover.Size = new System.Drawing.Size(5, 62);
            this.panelHover.TabIndex = 2;
            this.panelHover.UseCustomBackColor = true;
            this.panelHover.VerticalScrollbarBarColor = true;
            this.panelHover.VerticalScrollbarHighlightOnWheel = false;
            this.panelHover.VerticalScrollbarSize = 10;
            // 
            // CITITONotification
            // 
            this.CITITONotification.Icon = ((System.Drawing.Icon)(resources.GetObject("CITITONotification.Icon")));
            this.CITITONotification.Text = "Productivity Management System";
            this.CITITONotification.Visible = true;
            this.CITITONotification.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CITITONotification_MouseDoubleClick_1);
            // 
            // tileX3
            // 
            this.tileX3.ActiveControl = null;
            this.tileX3.Location = new System.Drawing.Point(-1, 132);
            this.tileX3.Name = "tileX3";
            this.tileX3.Size = new System.Drawing.Size(156, 62);
            this.tileX3.Style = MetroFramework.MetroColorStyle.Silver;
            this.tileX3.TabIndex = 4;
            this.tileX3.Text = "X3 Performace";
            this.tileX3.UseSelectable = true;
            this.tileX3.Click += new System.EventHandler(this.tileX3_Click);
            // 
            // frm_UserTaskInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 820);
            this.Controls.Add(this.line);
            this.Controls.Add(this.panelHover);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.lblManagerToFill);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.lblTimeToFill);
            this.Controls.Add(this.lblUserNameToFill);
            this.Controls.Add(this.lblUIDToFill);
            this.Controls.Add(this.lblLoggedTime);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tglLogut);
            this.Controls.Add(this.lblUserTaskPanel);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_UserTaskInOut";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_UserTaskInOut_FormClosing);
            this.Load += new System.EventHandler(this.frm_UserTaskInOut_Load);
            this.Resize += new System.EventHandler(this.frm_UserTaskInOut_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel line;
        private MetroFramework.Controls.MetroLabel lblManagerToFill;
        private MetroFramework.Controls.MetroLabel lblManager;
        private MetroFramework.Controls.MetroLabel lblTimeToFill;
        private MetroFramework.Controls.MetroLabel lblUserNameToFill;
        private MetroFramework.Controls.MetroLabel lblUIDToFill;
        private MetroFramework.Controls.MetroLabel lblLoggedTime;
        private MetroFramework.Controls.MetroLabel lblUserName;
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroToggle tglLogut;
        private System.Windows.Forms.Label lblUserTaskPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroPanel panelLeft;
        private MetroFramework.Controls.MetroPanel pnlMain;
        private MetroFramework.Controls.MetroTile tileIDLE;
        private MetroFramework.Controls.MetroTile tileTaskInOut;
        private MetroFramework.Controls.MetroPanel panelHover;
        private System.Windows.Forms.NotifyIcon CITITONotification;
        private MetroFramework.Controls.MetroTile tileX3;
    }
}