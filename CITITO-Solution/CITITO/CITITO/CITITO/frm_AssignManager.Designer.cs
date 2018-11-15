namespace CITITO
{
    partial class frm_AssignManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AssignManager));
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnAssign = new MetroFramework.Controls.MetroButton();
            this.cmbAssignProject = new MetroFramework.Controls.MetroComboBox();
            this.lblAssignProject = new MetroFramework.Controls.MetroLabel();
            this.lblProject = new MetroFramework.Controls.MetroLabel();
            this.txtCurrentProject = new MetroFramework.Controls.MetroTextBox();
            this.lblCurrentProject = new MetroFramework.Controls.MetroLabel();
            this.lblAssignManagers = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPIC = new MetroFramework.Controls.MetroLabel();
            this.checkedListBoxProjectToUsers = new System.Windows.Forms.CheckedListBox();
            this.lblCurrentProjectUserList = new MetroFramework.Controls.MetroLabel();
            this.chkSelectAll = new MetroFramework.Controls.MetroCheckBox();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(442, 459);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 196;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(442, 364);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(80, 32);
            this.btnAssign.TabIndex = 195;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseSelectable = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // cmbAssignProject
            // 
            this.cmbAssignProject.FormattingEnabled = true;
            this.cmbAssignProject.ItemHeight = 23;
            this.cmbAssignProject.Location = new System.Drawing.Point(401, 86);
            this.cmbAssignProject.Name = "cmbAssignProject";
            this.cmbAssignProject.Size = new System.Drawing.Size(121, 29);
            this.cmbAssignProject.TabIndex = 194;
            this.cmbAssignProject.UseSelectable = true;
            // 
            // lblAssignProject
            // 
            this.lblAssignProject.AutoSize = true;
            this.lblAssignProject.Location = new System.Drawing.Point(301, 96);
            this.lblAssignProject.Name = "lblAssignProject";
            this.lblAssignProject.Size = new System.Drawing.Size(94, 19);
            this.lblAssignProject.TabIndex = 201;
            this.lblAssignProject.Text = "Assign Project:";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(397, 38);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(50, 19);
            this.lblProject.TabIndex = 200;
            this.lblProject.Text = "Project";
            this.lblProject.Visible = false;
            // 
            // txtCurrentProject
            // 
            // 
            // 
            // 
            this.txtCurrentProject.CustomButton.Image = null;
            this.txtCurrentProject.CustomButton.Location = new System.Drawing.Point(101, 1);
            this.txtCurrentProject.CustomButton.Name = "";
            this.txtCurrentProject.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCurrentProject.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrentProject.CustomButton.TabIndex = 1;
            this.txtCurrentProject.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrentProject.CustomButton.UseSelectable = true;
            this.txtCurrentProject.CustomButton.Visible = false;
            this.txtCurrentProject.Enabled = false;
            this.txtCurrentProject.Lines = new string[0];
            this.txtCurrentProject.Location = new System.Drawing.Point(139, 92);
            this.txtCurrentProject.MaxLength = 32767;
            this.txtCurrentProject.Name = "txtCurrentProject";
            this.txtCurrentProject.PasswordChar = '\0';
            this.txtCurrentProject.ReadOnly = true;
            this.txtCurrentProject.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrentProject.SelectedText = "";
            this.txtCurrentProject.SelectionLength = 0;
            this.txtCurrentProject.SelectionStart = 0;
            this.txtCurrentProject.ShortcutsEnabled = true;
            this.txtCurrentProject.Size = new System.Drawing.Size(123, 23);
            this.txtCurrentProject.TabIndex = 193;
            this.txtCurrentProject.UseSelectable = true;
            this.txtCurrentProject.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrentProject.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCurrentProject
            // 
            this.lblCurrentProject.AutoSize = true;
            this.lblCurrentProject.Location = new System.Drawing.Point(32, 96);
            this.lblCurrentProject.Name = "lblCurrentProject";
            this.lblCurrentProject.Size = new System.Drawing.Size(101, 19);
            this.lblCurrentProject.TabIndex = 199;
            this.lblCurrentProject.Text = "Current Project:";
            // 
            // lblAssignManagers
            // 
            this.lblAssignManagers.AutoSize = true;
            this.lblAssignManagers.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAssignManagers.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAssignManagers.Location = new System.Drawing.Point(107, 36);
            this.lblAssignManagers.Name = "lblAssignManagers";
            this.lblAssignManagers.Size = new System.Drawing.Size(194, 25);
            this.lblAssignManagers.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblAssignManagers.TabIndex = 198;
            this.lblAssignManagers.Text = "Assign Users to Ptoject";
            this.lblAssignManagers.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 197;
            this.pictureBox1.TabStop = false;
            // 
            // lblPIC
            // 
            this.lblPIC.AutoSize = true;
            this.lblPIC.Location = new System.Drawing.Point(466, 38);
            this.lblPIC.Name = "lblPIC";
            this.lblPIC.Size = new System.Drawing.Size(29, 19);
            this.lblPIC.TabIndex = 202;
            this.lblPIC.Text = "PIC";
            this.lblPIC.Visible = false;
            // 
            // checkedListBoxProjectToUsers
            // 
            this.checkedListBoxProjectToUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxProjectToUsers.CheckOnClick = true;
            this.checkedListBoxProjectToUsers.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxProjectToUsers.FormattingEnabled = true;
            this.checkedListBoxProjectToUsers.Location = new System.Drawing.Point(32, 172);
            this.checkedListBoxProjectToUsers.Name = "checkedListBoxProjectToUsers";
            this.checkedListBoxProjectToUsers.Size = new System.Drawing.Size(363, 470);
            this.checkedListBoxProjectToUsers.TabIndex = 216;
            // 
            // lblCurrentProjectUserList
            // 
            this.lblCurrentProjectUserList.AutoSize = true;
            this.lblCurrentProjectUserList.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblCurrentProjectUserList.Location = new System.Drawing.Point(32, 154);
            this.lblCurrentProjectUserList.Name = "lblCurrentProjectUserList";
            this.lblCurrentProjectUserList.Size = new System.Drawing.Size(130, 15);
            this.lblCurrentProjectUserList.TabIndex = 217;
            this.lblCurrentProjectUserList.Text = "Current Project User List:";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(32, 652);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(71, 15);
            this.chkSelectAll.TabIndex = 218;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseSelectable = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(442, 410);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 35);
            this.btnClear.TabIndex = 219;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frm_AssignManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 706);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.lblCurrentProjectUserList);
            this.Controls.Add(this.checkedListBoxProjectToUsers);
            this.Controls.Add(this.lblPIC);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.cmbAssignProject);
            this.Controls.Add(this.lblAssignProject);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.txtCurrentProject);
            this.Controls.Add(this.lblCurrentProject);
            this.Controls.Add(this.lblAssignManagers);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_AssignManager";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_AssignManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnAssign;
        private MetroFramework.Controls.MetroComboBox cmbAssignProject;
        private MetroFramework.Controls.MetroLabel lblAssignProject;
        private MetroFramework.Controls.MetroLabel lblProject;
        private MetroFramework.Controls.MetroTextBox txtCurrentProject;
        private MetroFramework.Controls.MetroLabel lblCurrentProject;
        private MetroFramework.Controls.MetroLabel lblAssignManagers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel lblPIC;
        private System.Windows.Forms.CheckedListBox checkedListBoxProjectToUsers;
        private MetroFramework.Controls.MetroLabel lblCurrentProjectUserList;
        private MetroFramework.Controls.MetroCheckBox chkSelectAll;
        private MetroFramework.Controls.MetroButton btnClear;
    }
}