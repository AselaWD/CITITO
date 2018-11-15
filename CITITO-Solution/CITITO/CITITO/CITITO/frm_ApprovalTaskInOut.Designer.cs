namespace CITITO
{
    partial class frm_ApprovalTaskInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ApprovalTaskInOut));
            this.CITITONotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.tileIDLEApproval = new MetroFramework.Controls.MetroTile();
            this.tileTaskInOutApproval = new MetroFramework.Controls.MetroTile();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelLeft = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.tileModifiedApproval = new MetroFramework.Controls.MetroTile();
            this.tileModifiedRecords = new MetroFramework.Controls.MetroTile();
            this.lblTaskApprovePanel = new System.Windows.Forms.Label();
            this.lblUIDToFill = new MetroFramework.Controls.MetroLabel();
            this.lblPICToFill = new MetroFramework.Controls.MetroLabel();
            this.line = new MetroFramework.Controls.MetroPanel();
            this.panelLoadUserTasks = new MetroFramework.Controls.MetroPanel();
            this.panelHover = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tilePendingRecords = new MetroFramework.Controls.MetroTile();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CITITONotification
            // 
            this.CITITONotification.Icon = ((System.Drawing.Icon)(resources.GetObject("CITITONotification.Icon")));
            this.CITITONotification.Text = "Productivity Management System";
            this.CITITONotification.Visible = true;
            // 
            // tileIDLEApproval
            // 
            this.tileIDLEApproval.ActiveControl = null;
            this.tileIDLEApproval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileIDLEApproval.Location = new System.Drawing.Point(0, 146);
            this.tileIDLEApproval.Name = "tileIDLEApproval";
            this.tileIDLEApproval.Size = new System.Drawing.Size(156, 62);
            this.tileIDLEApproval.Style = MetroFramework.MetroColorStyle.Blue;
            this.tileIDLEApproval.TabIndex = 3;
            this.tileIDLEApproval.Text = "IDLE Approval";
            this.tileIDLEApproval.UseSelectable = true;
            this.tileIDLEApproval.Click += new System.EventHandler(this.tileIDLEApproval_Click);
            // 
            // tileTaskInOutApproval
            // 
            this.tileTaskInOutApproval.ActiveControl = null;
            this.tileTaskInOutApproval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileTaskInOutApproval.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileTaskInOutApproval.Location = new System.Drawing.Point(0, 0);
            this.tileTaskInOutApproval.Name = "tileTaskInOutApproval";
            this.tileTaskInOutApproval.Size = new System.Drawing.Size(154, 62);
            this.tileTaskInOutApproval.Style = MetroFramework.MetroColorStyle.Teal;
            this.tileTaskInOutApproval.TabIndex = 2;
            this.tileTaskInOutApproval.Text = "Task In/Out Approval";
            this.tileTaskInOutApproval.UseSelectable = true;
            this.tileTaskInOutApproval.Click += new System.EventHandler(this.tileTaskInOutApproval_Click_1);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.metroPanel2);
            this.panelLeft.Controls.Add(this.metroPanel1);
            this.panelLeft.Controls.Add(this.tileModifiedApproval);
            this.panelLeft.Controls.Add(this.tileModifiedRecords);
            this.panelLeft.Controls.Add(this.tileIDLEApproval);
            this.panelLeft.Controls.Add(this.tileTaskInOutApproval);
            this.panelLeft.Controls.Add(this.tilePendingRecords);
            this.panelLeft.HorizontalScrollbarBarColor = true;
            this.panelLeft.HorizontalScrollbarHighlightOnWheel = false;
            this.panelLeft.HorizontalScrollbarSize = 10;
            this.panelLeft.Location = new System.Drawing.Point(-1, 122);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(156, 705);
            this.panelLeft.TabIndex = 179;
            this.panelLeft.UseCustomBackColor = true;
            this.panelLeft.VerticalScrollbarBarColor = true;
            this.panelLeft.VerticalScrollbarHighlightOnWheel = false;
            this.panelLeft.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.Teal;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(19, 104);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(5, 39);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroPanel1.TabIndex = 6;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.UseStyleColors = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // tileModifiedApproval
            // 
            this.tileModifiedApproval.ActiveControl = null;
            this.tileModifiedApproval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileModifiedApproval.Location = new System.Drawing.Point(23, 104);
            this.tileModifiedApproval.Name = "tileModifiedApproval";
            this.tileModifiedApproval.Size = new System.Drawing.Size(132, 39);
            this.tileModifiedApproval.Style = MetroFramework.MetroColorStyle.Silver;
            this.tileModifiedApproval.TabIndex = 5;
            this.tileModifiedApproval.Text = "Modified Approval";
            this.tileModifiedApproval.UseSelectable = true;
            this.tileModifiedApproval.Click += new System.EventHandler(this.tileModifiedApproval_Click);
            // 
            // tileModifiedRecords
            // 
            this.tileModifiedRecords.ActiveControl = null;
            this.tileModifiedRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileModifiedRecords.Location = new System.Drawing.Point(23, 104);
            this.tileModifiedRecords.Name = "tileModifiedRecords";
            this.tileModifiedRecords.Size = new System.Drawing.Size(132, 39);
            this.tileModifiedRecords.Style = MetroFramework.MetroColorStyle.Silver;
            this.tileModifiedRecords.TabIndex = 4;
            this.tileModifiedRecords.Text = "Modified Records";
            this.tileModifiedRecords.UseSelectable = true;
            this.tileModifiedRecords.Click += new System.EventHandler(this.tileModifiedRecords_Click);
            // 
            // lblTaskApprovePanel
            // 
            this.lblTaskApprovePanel.AutoSize = true;
            this.lblTaskApprovePanel.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskApprovePanel.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskApprovePanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTaskApprovePanel.Location = new System.Drawing.Point(126, 40);
            this.lblTaskApprovePanel.Name = "lblTaskApprovePanel";
            this.lblTaskApprovePanel.Size = new System.Drawing.Size(195, 30);
            this.lblTaskApprovePanel.TabIndex = 167;
            this.lblTaskApprovePanel.Text = "Task Approve Panel";
            // 
            // lblUIDToFill
            // 
            this.lblUIDToFill.AutoSize = true;
            this.lblUIDToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUIDToFill.Location = new System.Drawing.Point(571, 44);
            this.lblUIDToFill.Name = "lblUIDToFill";
            this.lblUIDToFill.Size = new System.Drawing.Size(26, 15);
            this.lblUIDToFill.TabIndex = 173;
            this.lblUIDToFill.Text = "UID";
            this.lblUIDToFill.Visible = false;
            // 
            // lblPICToFill
            // 
            this.lblPICToFill.AutoSize = true;
            this.lblPICToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblPICToFill.Location = new System.Drawing.Point(615, 44);
            this.lblPICToFill.Name = "lblPICToFill";
            this.lblPICToFill.Size = new System.Drawing.Size(24, 15);
            this.lblPICToFill.TabIndex = 177;
            this.lblPICToFill.Text = "PIC";
            this.lblPICToFill.Visible = false;
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.Teal;
            this.line.HorizontalScrollbarBarColor = true;
            this.line.HorizontalScrollbarHighlightOnWheel = false;
            this.line.HorizontalScrollbarSize = 10;
            this.line.Location = new System.Drawing.Point(0, 120);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(1448, 2);
            this.line.TabIndex = 178;
            this.line.UseCustomBackColor = true;
            this.line.VerticalScrollbarBarColor = true;
            this.line.VerticalScrollbarHighlightOnWheel = false;
            this.line.VerticalScrollbarSize = 10;
            // 
            // panelLoadUserTasks
            // 
            this.panelLoadUserTasks.HorizontalScrollbarBarColor = true;
            this.panelLoadUserTasks.HorizontalScrollbarHighlightOnWheel = false;
            this.panelLoadUserTasks.HorizontalScrollbarSize = 10;
            this.panelLoadUserTasks.Location = new System.Drawing.Point(155, 122);
            this.panelLoadUserTasks.Name = "panelLoadUserTasks";
            this.panelLoadUserTasks.Size = new System.Drawing.Size(1294, 705);
            this.panelLoadUserTasks.TabIndex = 2;
            this.panelLoadUserTasks.VerticalScrollbarBarColor = true;
            this.panelLoadUserTasks.VerticalScrollbarHighlightOnWheel = false;
            this.panelLoadUserTasks.VerticalScrollbarSize = 10;
            // 
            // panelHover
            // 
            this.panelHover.BackColor = System.Drawing.Color.Gold;
            this.panelHover.Location = new System.Drawing.Point(155, 123);
            this.panelHover.Name = "panelHover";
            this.panelHover.Size = new System.Drawing.Size(5, 62);
            this.panelHover.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 166;
            this.pictureBox1.TabStop = false;
            // 
            // tilePendingRecords
            // 
            this.tilePendingRecords.ActiveControl = null;
            this.tilePendingRecords.Location = new System.Drawing.Point(23, 64);
            this.tilePendingRecords.Name = "tilePendingRecords";
            this.tilePendingRecords.Size = new System.Drawing.Size(132, 39);
            this.tilePendingRecords.Style = MetroFramework.MetroColorStyle.Silver;
            this.tilePendingRecords.TabIndex = 7;
            this.tilePendingRecords.Text = "Pending Records";
            this.tilePendingRecords.UseSelectable = true;
            this.tilePendingRecords.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackColor = System.Drawing.Color.Teal;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(19, 64);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(5, 39);
            this.metroPanel2.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroPanel2.TabIndex = 7;
            this.metroPanel2.UseCustomBackColor = true;
            this.metroPanel2.UseStyleColors = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // frm_ApprovalTaskInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 825);
            this.Controls.Add(this.panelHover);
            this.Controls.Add(this.panelLoadUserTasks);
            this.Controls.Add(this.line);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.lblPICToFill);
            this.Controls.Add(this.lblUIDToFill);
            this.Controls.Add(this.lblTaskApprovePanel);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "frm_ApprovalTaskInOut";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_ApprovalTaskInOut_Load);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon CITITONotification;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroPanel panelLeft;
        private System.Windows.Forms.Label lblTaskApprovePanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel lblUIDToFill;
        private MetroFramework.Controls.MetroLabel lblPICToFill;
        private MetroFramework.Controls.MetroPanel panelLoadUserTasks;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        public MetroFramework.Controls.MetroTile tileIDLEApproval;
        public MetroFramework.Controls.MetroTile tileTaskInOutApproval;
        public System.Windows.Forms.Panel panelHover;
        public MetroFramework.Controls.MetroTile tileModifiedApproval;
        public MetroFramework.Controls.MetroTile tileModifiedRecords;
        public MetroFramework.Controls.MetroPanel line;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroTile tilePendingRecords;
    }
}