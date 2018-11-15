namespace CITITO
{
    partial class frm_UserManagementPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserManagementPanel));
            this.lblTime = new MetroFramework.Controls.MetroLabel();
            this.lblPIC = new MetroFramework.Controls.MetroLabel();
            this.lblMUID = new MetroFramework.Controls.MetroLabel();
            this.tileUser = new MetroFramework.Controls.MetroTile();
            this.tileManager = new MetroFramework.Controls.MetroTile();
            this.lbRegistrationPanel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelRegistration = new MetroFramework.Controls.MetroPanel();
            this.lblManagerName = new MetroFramework.Controls.MetroLabel();
            this.hoverPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(794, 48);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(38, 19);
            this.lblTime.TabIndex = 198;
            this.lblTime.Text = "Time";
            this.lblTime.Visible = false;
            // 
            // lblPIC
            // 
            this.lblPIC.AutoSize = true;
            this.lblPIC.Location = new System.Drawing.Point(708, 48);
            this.lblPIC.Name = "lblPIC";
            this.lblPIC.Size = new System.Drawing.Size(29, 19);
            this.lblPIC.TabIndex = 197;
            this.lblPIC.Text = "PIC";
            this.lblPIC.Visible = false;
            // 
            // lblMUID
            // 
            this.lblMUID.AutoSize = true;
            this.lblMUID.Location = new System.Drawing.Point(660, 48);
            this.lblMUID.Name = "lblMUID";
            this.lblMUID.Size = new System.Drawing.Size(42, 19);
            this.lblMUID.TabIndex = 196;
            this.lblMUID.Text = "MUID";
            this.lblMUID.Visible = false;
            // 
            // tileUser
            // 
            this.tileUser.ActiveControl = null;
            this.tileUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileUser.Location = new System.Drawing.Point(0, 96);
            this.tileUser.Name = "tileUser";
            this.tileUser.Size = new System.Drawing.Size(125, 42);
            this.tileUser.Style = MetroFramework.MetroColorStyle.Green;
            this.tileUser.TabIndex = 1;
            this.tileUser.Text = "User";
            this.tileUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileUser.UseSelectable = true;
            this.tileUser.Click += new System.EventHandler(this.tileUser_Click);
            // 
            // tileManager
            // 
            this.tileManager.ActiveControl = null;
            this.tileManager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileManager.Location = new System.Drawing.Point(131, 96);
            this.tileManager.Name = "tileManager";
            this.tileManager.Size = new System.Drawing.Size(125, 42);
            this.tileManager.Style = MetroFramework.MetroColorStyle.Teal;
            this.tileManager.TabIndex = 2;
            this.tileManager.Text = "Manager/DCD";
            this.tileManager.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileManager.UseSelectable = true;
            this.tileManager.Click += new System.EventHandler(this.tileManager_Click);
            // 
            // lbRegistrationPanel
            // 
            this.lbRegistrationPanel.AutoSize = true;
            this.lbRegistrationPanel.BackColor = System.Drawing.Color.Transparent;
            this.lbRegistrationPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegistrationPanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbRegistrationPanel.Location = new System.Drawing.Point(130, 29);
            this.lbRegistrationPanel.Name = "lbRegistrationPanel";
            this.lbRegistrationPanel.Size = new System.Drawing.Size(292, 37);
            this.lbRegistrationPanel.TabIndex = 193;
            this.lbRegistrationPanel.Text = "User Registration Panel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 192;
            this.pictureBox1.TabStop = false;
            // 
            // panelRegistration
            // 
            this.panelRegistration.HorizontalScrollbarBarColor = true;
            this.panelRegistration.HorizontalScrollbarHighlightOnWheel = false;
            this.panelRegistration.HorizontalScrollbarSize = 10;
            this.panelRegistration.Location = new System.Drawing.Point(0, 139);
            this.panelRegistration.Name = "panelRegistration";
            this.panelRegistration.Size = new System.Drawing.Size(1090, 691);
            this.panelRegistration.TabIndex = 199;
            this.panelRegistration.VerticalScrollbarBarColor = true;
            this.panelRegistration.VerticalScrollbarHighlightOnWheel = false;
            this.panelRegistration.VerticalScrollbarSize = 10;
            // 
            // lblManagerName
            // 
            this.lblManagerName.AutoSize = true;
            this.lblManagerName.Location = new System.Drawing.Point(743, 48);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(45, 19);
            this.lblManagerName.TabIndex = 200;
            this.lblManagerName.Text = "Name";
            this.lblManagerName.Visible = false;
            // 
            // hoverPanel
            // 
            this.hoverPanel.BackColor = System.Drawing.Color.Gold;
            this.hoverPanel.Location = new System.Drawing.Point(0, 91);
            this.hoverPanel.Name = "hoverPanel";
            this.hoverPanel.Size = new System.Drawing.Size(125, 5);
            this.hoverPanel.TabIndex = 201;
            // 
            // frm_UserManagementPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 831);
            this.Controls.Add(this.hoverPanel);
            this.Controls.Add(this.lblManagerName);
            this.Controls.Add(this.panelRegistration);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblPIC);
            this.Controls.Add(this.lblMUID);
            this.Controls.Add(this.tileUser);
            this.Controls.Add(this.tileManager);
            this.Controls.Add(this.lbRegistrationPanel);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_UserManagementPanel";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_UserManagementPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblTime;
        private MetroFramework.Controls.MetroLabel lblPIC;
        private MetroFramework.Controls.MetroLabel lblMUID;
        private MetroFramework.Controls.MetroTile tileUser;
        private MetroFramework.Controls.MetroTile tileManager;
        private System.Windows.Forms.Label lbRegistrationPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroPanel panelRegistration;
        private MetroFramework.Controls.MetroLabel lblManagerName;
        private System.Windows.Forms.Panel hoverPanel;
    }
}