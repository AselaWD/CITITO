namespace CITITO
{
    partial class frm_DeleteUsersFromProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DeleteUsersFromProject));
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.lblCurrentUserList = new MetroFramework.Controls.MetroLabel();
            this.cmbCurrentProject = new MetroFramework.Controls.MetroComboBox();
            this.lblCurrentProject = new MetroFramework.Controls.MetroLabel();
            this.chkSelectAll = new MetroFramework.Controls.MetroCheckBox();
            this.checkedListBoxUsersToDelete = new System.Windows.Forms.CheckedListBox();
            this.lblPIC = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(437, 201);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 32);
            this.btnClear.TabIndex = 238;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(437, 155);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 32);
            this.btnDelete.TabIndex = 237;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblCurrentUserList
            // 
            this.lblCurrentUserList.AutoSize = true;
            this.lblCurrentUserList.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblCurrentUserList.Location = new System.Drawing.Point(23, 137);
            this.lblCurrentUserList.Name = "lblCurrentUserList";
            this.lblCurrentUserList.Size = new System.Drawing.Size(52, 15);
            this.lblCurrentUserList.TabIndex = 236;
            this.lblCurrentUserList.Text = "User List:";
            // 
            // cmbCurrentProject
            // 
            this.cmbCurrentProject.FormattingEnabled = true;
            this.cmbCurrentProject.ItemHeight = 23;
            this.cmbCurrentProject.Location = new System.Drawing.Point(130, 63);
            this.cmbCurrentProject.Name = "cmbCurrentProject";
            this.cmbCurrentProject.Size = new System.Drawing.Size(136, 29);
            this.cmbCurrentProject.TabIndex = 234;
            this.cmbCurrentProject.UseSelectable = true;
            this.cmbCurrentProject.SelectedIndexChanged += new System.EventHandler(this.cmbCurrentProject_SelectedIndexChanged);
            // 
            // lblCurrentProject
            // 
            this.lblCurrentProject.AutoSize = true;
            this.lblCurrentProject.Location = new System.Drawing.Point(23, 73);
            this.lblCurrentProject.Name = "lblCurrentProject";
            this.lblCurrentProject.Size = new System.Drawing.Size(101, 19);
            this.lblCurrentProject.TabIndex = 235;
            this.lblCurrentProject.Text = "Current Project:";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(23, 631);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(71, 15);
            this.chkSelectAll.TabIndex = 233;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseSelectable = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // checkedListBoxUsersToDelete
            // 
            this.checkedListBoxUsersToDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxUsersToDelete.CheckOnClick = true;
            this.checkedListBoxUsersToDelete.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxUsersToDelete.FormattingEnabled = true;
            this.checkedListBoxUsersToDelete.Location = new System.Drawing.Point(23, 155);
            this.checkedListBoxUsersToDelete.Name = "checkedListBoxUsersToDelete";
            this.checkedListBoxUsersToDelete.Size = new System.Drawing.Size(277, 470);
            this.checkedListBoxUsersToDelete.TabIndex = 232;
            // 
            // lblPIC
            // 
            this.lblPIC.AutoSize = true;
            this.lblPIC.Location = new System.Drawing.Point(356, 40);
            this.lblPIC.Name = "lblPIC";
            this.lblPIC.Size = new System.Drawing.Size(29, 19);
            this.lblPIC.TabIndex = 231;
            this.lblPIC.Text = "PIC";
            this.lblPIC.Visible = false;
            // 
            // frm_DeleteUsersFromProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 670);
            this.ControlBox = false;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblCurrentUserList);
            this.Controls.Add(this.cmbCurrentProject);
            this.Controls.Add(this.lblCurrentProject);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.checkedListBoxUsersToDelete);
            this.Controls.Add(this.lblPIC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_DeleteUsersFromProject";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Load += new System.EventHandler(this.frm_DeleteUsersFromProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroLabel lblCurrentUserList;
        private MetroFramework.Controls.MetroComboBox cmbCurrentProject;
        private MetroFramework.Controls.MetroLabel lblCurrentProject;
        private MetroFramework.Controls.MetroCheckBox chkSelectAll;
        private System.Windows.Forms.CheckedListBox checkedListBoxUsersToDelete;
        private MetroFramework.Controls.MetroLabel lblPIC;
    }
}