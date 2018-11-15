namespace CITITO
{
    partial class frm_AssignUsersToProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AssignUsersToProject));
            this.lblPIC = new MetroFramework.Controls.MetroLabel();
            this.chkSelectAll = new MetroFramework.Controls.MetroCheckBox();
            this.checkedListBoxUsers = new System.Windows.Forms.CheckedListBox();
            this.cmbAssignProject = new MetroFramework.Controls.MetroComboBox();
            this.cmbCurrentProject = new MetroFramework.Controls.MetroComboBox();
            this.lblCurrentProject = new MetroFramework.Controls.MetroLabel();
            this.lblCurrentUserList = new MetroFramework.Controls.MetroLabel();
            this.lblAssignProject = new MetroFramework.Controls.MetroLabel();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnAssign = new MetroFramework.Controls.MetroButton();
            this.treeViewUserList = new System.Windows.Forms.TreeView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblPIC
            // 
            this.lblPIC.AutoSize = true;
            this.lblPIC.Location = new System.Drawing.Point(354, 16);
            this.lblPIC.Name = "lblPIC";
            this.lblPIC.Size = new System.Drawing.Size(29, 19);
            this.lblPIC.TabIndex = 196;
            this.lblPIC.Text = "PIC";
            this.lblPIC.Visible = false;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(46, 630);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(71, 15);
            this.chkSelectAll.TabIndex = 218;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseSelectable = true;
            this.chkSelectAll.Visible = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // checkedListBoxUsers
            // 
            this.checkedListBoxUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxUsers.CheckOnClick = true;
            this.checkedListBoxUsers.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxUsers.FormattingEnabled = true;
            this.checkedListBoxUsers.Location = new System.Drawing.Point(46, 208);
            this.checkedListBoxUsers.Name = "checkedListBoxUsers";
            this.checkedListBoxUsers.Size = new System.Drawing.Size(195, 416);
            this.checkedListBoxUsers.TabIndex = 217;
            this.checkedListBoxUsers.Visible = false;
            // 
            // cmbAssignProject
            // 
            this.cmbAssignProject.FormattingEnabled = true;
            this.cmbAssignProject.ItemHeight = 23;
            this.cmbAssignProject.Location = new System.Drawing.Point(386, 63);
            this.cmbAssignProject.Name = "cmbAssignProject";
            this.cmbAssignProject.Size = new System.Drawing.Size(136, 29);
            this.cmbAssignProject.TabIndex = 223;
            this.cmbAssignProject.UseSelectable = true;
            // 
            // cmbCurrentProject
            // 
            this.cmbCurrentProject.FormattingEnabled = true;
            this.cmbCurrentProject.ItemHeight = 23;
            this.cmbCurrentProject.Location = new System.Drawing.Point(132, 63);
            this.cmbCurrentProject.Name = "cmbCurrentProject";
            this.cmbCurrentProject.Size = new System.Drawing.Size(136, 29);
            this.cmbCurrentProject.TabIndex = 219;
            this.cmbCurrentProject.UseSelectable = true;
            this.cmbCurrentProject.SelectedIndexChanged += new System.EventHandler(this.cmbCurrentProject_SelectedIndexChanged);
            // 
            // lblCurrentProject
            // 
            this.lblCurrentProject.AutoSize = true;
            this.lblCurrentProject.Location = new System.Drawing.Point(25, 73);
            this.lblCurrentProject.Name = "lblCurrentProject";
            this.lblCurrentProject.Size = new System.Drawing.Size(101, 19);
            this.lblCurrentProject.TabIndex = 220;
            this.lblCurrentProject.Text = "Current Project:";
            // 
            // lblCurrentUserList
            // 
            this.lblCurrentUserList.AutoSize = true;
            this.lblCurrentUserList.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblCurrentUserList.Location = new System.Drawing.Point(46, 173);
            this.lblCurrentUserList.Name = "lblCurrentUserList";
            this.lblCurrentUserList.Size = new System.Drawing.Size(52, 15);
            this.lblCurrentUserList.TabIndex = 224;
            this.lblCurrentUserList.Text = "User List:";
            // 
            // lblAssignProject
            // 
            this.lblAssignProject.AutoSize = true;
            this.lblAssignProject.Location = new System.Drawing.Point(286, 73);
            this.lblAssignProject.Name = "lblAssignProject";
            this.lblAssignProject.Size = new System.Drawing.Size(94, 19);
            this.lblAssignProject.TabIndex = 225;
            this.lblAssignProject.Text = "Assign Project:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(439, 254);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 32);
            this.btnClear.TabIndex = 227;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(439, 208);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(83, 32);
            this.btnAssign.TabIndex = 226;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseSelectable = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // treeViewUserList
            // 
            this.treeViewUserList.CheckBoxes = true;
            this.treeViewUserList.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.treeViewUserList.Location = new System.Drawing.Point(46, 191);
            this.treeViewUserList.Name = "treeViewUserList";
            this.treeViewUserList.Size = new System.Drawing.Size(195, 433);
            this.treeViewUserList.TabIndex = 228;
            this.treeViewUserList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewUserList_AfterCheck);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(46, 122);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(292, 30);
            this.metroLabel1.TabIndex = 229;
            this.metroLabel1.Text = "You can only assign users under relevant managers. \r\nCannot assign managers to a " +
    "project from this.";
            // 
            // frm_AssignUsersToProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 670);
            this.ControlBox = false;
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.treeViewUserList);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.lblAssignProject);
            this.Controls.Add(this.lblCurrentUserList);
            this.Controls.Add(this.cmbAssignProject);
            this.Controls.Add(this.cmbCurrentProject);
            this.Controls.Add(this.lblCurrentProject);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.checkedListBoxUsers);
            this.Controls.Add(this.lblPIC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_AssignUsersToProject";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Load += new System.EventHandler(this.frm_AssignUsersToProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel lblPIC;
        private MetroFramework.Controls.MetroCheckBox chkSelectAll;
        private System.Windows.Forms.CheckedListBox checkedListBoxUsers;
        private MetroFramework.Controls.MetroComboBox cmbAssignProject;
        private MetroFramework.Controls.MetroComboBox cmbCurrentProject;
        private MetroFramework.Controls.MetroLabel lblCurrentProject;
        private MetroFramework.Controls.MetroLabel lblCurrentUserList;
        private MetroFramework.Controls.MetroLabel lblAssignProject;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnAssign;
        private System.Windows.Forms.TreeView treeViewUserList;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}