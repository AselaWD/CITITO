namespace CITITO
{
    partial class frm_ProjectRegistrationPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProjectRegistrationPanel));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbRegistrationPanel = new System.Windows.Forms.Label();
            this.tileProject = new MetroFramework.Controls.MetroTile();
            this.tileTaskCodes = new MetroFramework.Controls.MetroTile();
            this.lblManagerName = new MetroFramework.Controls.MetroLabel();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.lblTime = new MetroFramework.Controls.MetroLabel();
            this.panelRegistration = new MetroFramework.Controls.MetroPanel();
            this.hoverPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 126;
            this.pictureBox1.TabStop = false;
            // 
            // lbRegistrationPanel
            // 
            this.lbRegistrationPanel.AutoSize = true;
            this.lbRegistrationPanel.BackColor = System.Drawing.Color.Transparent;
            this.lbRegistrationPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegistrationPanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbRegistrationPanel.Location = new System.Drawing.Point(131, 33);
            this.lbRegistrationPanel.Name = "lbRegistrationPanel";
            this.lbRegistrationPanel.Size = new System.Drawing.Size(232, 37);
            this.lbRegistrationPanel.TabIndex = 127;
            this.lbRegistrationPanel.Text = "Registration Panel";
            // 
            // tileProject
            // 
            this.tileProject.ActiveControl = null;
            this.tileProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileProject.Location = new System.Drawing.Point(0, 98);
            this.tileProject.Name = "tileProject";
            this.tileProject.Size = new System.Drawing.Size(125, 42);
            this.tileProject.Style = MetroFramework.MetroColorStyle.Teal;
            this.tileProject.TabIndex = 129;
            this.tileProject.Text = "Project";
            this.tileProject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileProject.UseSelectable = true;
            this.tileProject.Click += new System.EventHandler(this.tileProject_Click);
            // 
            // tileTaskCodes
            // 
            this.tileTaskCodes.ActiveControl = null;
            this.tileTaskCodes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileTaskCodes.Location = new System.Drawing.Point(131, 98);
            this.tileTaskCodes.Name = "tileTaskCodes";
            this.tileTaskCodes.Size = new System.Drawing.Size(125, 42);
            this.tileTaskCodes.Style = MetroFramework.MetroColorStyle.Green;
            this.tileTaskCodes.TabIndex = 130;
            this.tileTaskCodes.Text = "Task Codes";
            this.tileTaskCodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileTaskCodes.UseSelectable = true;
            this.tileTaskCodes.Click += new System.EventHandler(this.tileTaskCodes_Click);
            // 
            // lblManagerName
            // 
            this.lblManagerName.AutoSize = true;
            this.lblManagerName.Location = new System.Drawing.Point(697, 51);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(45, 19);
            this.lblManagerName.TabIndex = 190;
            this.lblManagerName.Text = "Name";
            this.lblManagerName.Visible = false;
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(661, 51);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(30, 19);
            this.lblUID.TabIndex = 189;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(748, 51);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(38, 19);
            this.lblTime.TabIndex = 191;
            this.lblTime.Text = "Time";
            this.lblTime.Visible = false;
            // 
            // panelRegistration
            // 
            this.panelRegistration.HorizontalScrollbarBarColor = true;
            this.panelRegistration.HorizontalScrollbarHighlightOnWheel = false;
            this.panelRegistration.HorizontalScrollbarSize = 10;
            this.panelRegistration.Location = new System.Drawing.Point(-1, 140);
            this.panelRegistration.Name = "panelRegistration";
            this.panelRegistration.Size = new System.Drawing.Size(1239, 668);
            this.panelRegistration.TabIndex = 192;
            this.panelRegistration.VerticalScrollbarBarColor = true;
            this.panelRegistration.VerticalScrollbarHighlightOnWheel = false;
            this.panelRegistration.VerticalScrollbarSize = 10;
            // 
            // hoverPanel
            // 
            this.hoverPanel.BackColor = System.Drawing.Color.Gold;
            this.hoverPanel.Location = new System.Drawing.Point(-1, 93);
            this.hoverPanel.Name = "hoverPanel";
            this.hoverPanel.Size = new System.Drawing.Size(126, 5);
            this.hoverPanel.TabIndex = 193;
            // 
            // frm_ProjectRegistrationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 807);
            this.Controls.Add(this.hoverPanel);
            this.Controls.Add(this.panelRegistration);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblManagerName);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.tileTaskCodes);
            this.Controls.Add(this.tileProject);
            this.Controls.Add(this.lbRegistrationPanel);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_ProjectRegistrationPanel";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_ProjectRegistrationPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbRegistrationPanel;
        private MetroFramework.Controls.MetroTile tileProject;
        private MetroFramework.Controls.MetroTile tileTaskCodes;
        private MetroFramework.Controls.MetroLabel lblManagerName;
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroLabel lblTime;
        private MetroFramework.Controls.MetroPanel panelRegistration;
        private System.Windows.Forms.Panel hoverPanel;
    }
}