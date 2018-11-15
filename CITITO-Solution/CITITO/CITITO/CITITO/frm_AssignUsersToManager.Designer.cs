namespace CITITO
{
    partial class frm_AssignUsersToManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AssignUsersToManager));
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.chkSelectAll = new MetroFramework.Controls.MetroCheckBox();
            this.lblCurrentManagertUserList = new MetroFramework.Controls.MetroLabel();
            this.checkedListBoxManagerToUsers = new System.Windows.Forms.CheckedListBox();
            this.lblPIC = new MetroFramework.Controls.MetroLabel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnAssign = new MetroFramework.Controls.MetroButton();
            this.cmbAssignManager = new MetroFramework.Controls.MetroComboBox();
            this.lblAssignManager = new MetroFramework.Controls.MetroLabel();
            this.lblManager = new MetroFramework.Controls.MetroLabel();
            this.txtCurrentManager = new MetroFramework.Controls.MetroTextBox();
            this.lblCurrentManager = new MetroFramework.Controls.MetroLabel();
            this.lblAssignManagers = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(454, 375);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 35);
            this.btnClear.TabIndex = 233;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(43, 663);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(71, 15);
            this.chkSelectAll.TabIndex = 232;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseSelectable = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // lblCurrentManagertUserList
            // 
            this.lblCurrentManagertUserList.AutoSize = true;
            this.lblCurrentManagertUserList.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblCurrentManagertUserList.Location = new System.Drawing.Point(43, 165);
            this.lblCurrentManagertUserList.Name = "lblCurrentManagertUserList";
            this.lblCurrentManagertUserList.Size = new System.Drawing.Size(140, 15);
            this.lblCurrentManagertUserList.TabIndex = 231;
            this.lblCurrentManagertUserList.Text = "Current Manager User List:";
            // 
            // checkedListBoxManagerToUsers
            // 
            this.checkedListBoxManagerToUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxManagerToUsers.CheckOnClick = true;
            this.checkedListBoxManagerToUsers.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxManagerToUsers.FormattingEnabled = true;
            this.checkedListBoxManagerToUsers.Location = new System.Drawing.Point(43, 183);
            this.checkedListBoxManagerToUsers.Name = "checkedListBoxManagerToUsers";
            this.checkedListBoxManagerToUsers.Size = new System.Drawing.Size(363, 470);
            this.checkedListBoxManagerToUsers.TabIndex = 230;
            // 
            // lblPIC
            // 
            this.lblPIC.AutoSize = true;
            this.lblPIC.Location = new System.Drawing.Point(477, 49);
            this.lblPIC.Name = "lblPIC";
            this.lblPIC.Size = new System.Drawing.Size(29, 19);
            this.lblPIC.TabIndex = 229;
            this.lblPIC.Text = "PIC";
            this.lblPIC.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(454, 424);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 223;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(454, 329);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(80, 32);
            this.btnAssign.TabIndex = 222;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseSelectable = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // cmbAssignManager
            // 
            this.cmbAssignManager.FormattingEnabled = true;
            this.cmbAssignManager.ItemHeight = 23;
            this.cmbAssignManager.Location = new System.Drawing.Point(385, 97);
            this.cmbAssignManager.Name = "cmbAssignManager";
            this.cmbAssignManager.Size = new System.Drawing.Size(121, 29);
            this.cmbAssignManager.TabIndex = 221;
            this.cmbAssignManager.UseSelectable = true;
            // 
            // lblAssignManager
            // 
            this.lblAssignManager.AutoSize = true;
            this.lblAssignManager.Location = new System.Drawing.Point(272, 107);
            this.lblAssignManager.Name = "lblAssignManager";
            this.lblAssignManager.Size = new System.Drawing.Size(107, 19);
            this.lblAssignManager.TabIndex = 228;
            this.lblAssignManager.Text = "Assign Manager:";
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Location = new System.Drawing.Point(408, 49);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(62, 19);
            this.lblManager.TabIndex = 227;
            this.lblManager.Text = "Manager";
            this.lblManager.Visible = false;
            // 
            // txtCurrentManager
            // 
            // 
            // 
            // 
            this.txtCurrentManager.CustomButton.Image = null;
            this.txtCurrentManager.CustomButton.Location = new System.Drawing.Point(65, 1);
            this.txtCurrentManager.CustomButton.Name = "";
            this.txtCurrentManager.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCurrentManager.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrentManager.CustomButton.TabIndex = 1;
            this.txtCurrentManager.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrentManager.CustomButton.UseSelectable = true;
            this.txtCurrentManager.CustomButton.Visible = false;
            this.txtCurrentManager.Enabled = false;
            this.txtCurrentManager.Lines = new string[0];
            this.txtCurrentManager.Location = new System.Drawing.Point(143, 103);
            this.txtCurrentManager.MaxLength = 32767;
            this.txtCurrentManager.Name = "txtCurrentManager";
            this.txtCurrentManager.PasswordChar = '\0';
            this.txtCurrentManager.ReadOnly = true;
            this.txtCurrentManager.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrentManager.SelectedText = "";
            this.txtCurrentManager.SelectionLength = 0;
            this.txtCurrentManager.SelectionStart = 0;
            this.txtCurrentManager.ShortcutsEnabled = true;
            this.txtCurrentManager.Size = new System.Drawing.Size(87, 23);
            this.txtCurrentManager.TabIndex = 220;
            this.txtCurrentManager.UseSelectable = true;
            this.txtCurrentManager.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrentManager.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCurrentManager
            // 
            this.lblCurrentManager.AutoSize = true;
            this.lblCurrentManager.Location = new System.Drawing.Point(23, 107);
            this.lblCurrentManager.Name = "lblCurrentManager";
            this.lblCurrentManager.Size = new System.Drawing.Size(114, 19);
            this.lblCurrentManager.TabIndex = 226;
            this.lblCurrentManager.Text = "Current Manager:";
            // 
            // lblAssignManagers
            // 
            this.lblAssignManagers.AutoSize = true;
            this.lblAssignManagers.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAssignManagers.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAssignManagers.Location = new System.Drawing.Point(118, 47);
            this.lblAssignManagers.Name = "lblAssignManagers";
            this.lblAssignManagers.Size = new System.Drawing.Size(210, 25);
            this.lblAssignManagers.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblAssignManagers.TabIndex = 225;
            this.lblAssignManagers.Text = "Assign Users to Manager";
            this.lblAssignManagers.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 224;
            this.pictureBox1.TabStop = false;
            // 
            // frm_AssignUsersToManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 706);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.lblCurrentManagertUserList);
            this.Controls.Add(this.checkedListBoxManagerToUsers);
            this.Controls.Add(this.lblPIC);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.cmbAssignManager);
            this.Controls.Add(this.lblAssignManager);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.txtCurrentManager);
            this.Controls.Add(this.lblCurrentManager);
            this.Controls.Add(this.lblAssignManagers);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_AssignUsersToManager";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_AssignUsersToManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroCheckBox chkSelectAll;
        private MetroFramework.Controls.MetroLabel lblCurrentManagertUserList;
        private System.Windows.Forms.CheckedListBox checkedListBoxManagerToUsers;
        private MetroFramework.Controls.MetroLabel lblPIC;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnAssign;
        private MetroFramework.Controls.MetroComboBox cmbAssignManager;
        private MetroFramework.Controls.MetroLabel lblAssignManager;
        private MetroFramework.Controls.MetroLabel lblManager;
        private MetroFramework.Controls.MetroTextBox txtCurrentManager;
        private MetroFramework.Controls.MetroLabel lblCurrentManager;
        private MetroFramework.Controls.MetroLabel lblAssignManagers;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}