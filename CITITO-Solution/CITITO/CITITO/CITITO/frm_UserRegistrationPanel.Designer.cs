namespace CITITO
{
    partial class frm_UserRegistrationPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserRegistrationPanel));
            this.chkSelectAll = new MetroFramework.Controls.MetroCheckBox();
            this.checkedListBoxProjects = new System.Windows.Forms.CheckedListBox();
            this.lblProjects = new MetroFramework.Controls.MetroLabel();
            this.lblPasswordMessage = new MetroFramework.Controls.MetroLabel();
            this.txtRePassword = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.lblRePassword = new MetroFramework.Controls.MetroLabel();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.btnAddUser = new MetroFramework.Controls.MetroButton();
            this.dataGridViewUserRegister = new MetroFramework.Controls.MetroGrid();
            this.txtUID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtManagerName = new MetroFramework.Controls.MetroTextBox();
            this.lblIName = new MetroFramework.Controls.MetroLabel();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.lblManager = new MetroFramework.Controls.MetroLabel();
            this.cmbManagersUID = new MetroFramework.Controls.MetroComboBox();
            this.cmbSystemAccess = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblPICTemp = new MetroFramework.Controls.MetroLabel();
            this.lblTaskCode = new MetroFramework.Controls.MetroLabel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btn_BulkImport = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dateTimePickerTaskOut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTaskIn = new System.Windows.Forms.DateTimePicker();
            this.lblIDLEMessage = new MetroFramework.Controls.MetroLabel();
            this.lblTo = new MetroFramework.Controls.MetroLabel();
            this.lblTaskIn = new MetroFramework.Controls.MetroLabel();
            this.groupBoxShift = new System.Windows.Forms.GroupBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.lblviewResourceList = new MetroFramework.Controls.MetroLink();
            this.txtResourceId = new MetroFramework.Controls.MetroTextBox();
            this.lblErrorResourceID = new MetroFramework.Controls.MetroLabel();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.pBoxError = new System.Windows.Forms.PictureBox();
            this.pBoxCorrect = new System.Windows.Forms.PictureBox();
            this.pBoxRefersh = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserRegister)).BeginInit();
            this.groupBoxShift.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCorrect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(136, 406);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(71, 15);
            this.chkSelectAll.TabIndex = 9;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseSelectable = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // checkedListBoxProjects
            // 
            this.checkedListBoxProjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxProjects.CheckOnClick = true;
            this.checkedListBoxProjects.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxProjects.FormattingEnabled = true;
            this.checkedListBoxProjects.Location = new System.Drawing.Point(136, 290);
            this.checkedListBoxProjects.Name = "checkedListBoxProjects";
            this.checkedListBoxProjects.Size = new System.Drawing.Size(200, 110);
            this.checkedListBoxProjects.TabIndex = 8;
            // 
            // lblProjects
            // 
            this.lblProjects.AutoSize = true;
            this.lblProjects.Location = new System.Drawing.Point(70, 290);
            this.lblProjects.Name = "lblProjects";
            this.lblProjects.Size = new System.Drawing.Size(53, 19);
            this.lblProjects.TabIndex = 240;
            this.lblProjects.Text = "Project:";
            // 
            // lblPasswordMessage
            // 
            this.lblPasswordMessage.AutoSize = true;
            this.lblPasswordMessage.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPasswordMessage.Location = new System.Drawing.Point(373, 153);
            this.lblPasswordMessage.Name = "lblPasswordMessage";
            this.lblPasswordMessage.Size = new System.Drawing.Size(22, 19);
            this.lblPasswordMessage.TabIndex = 237;
            this.lblPasswordMessage.Text = "M";
            this.lblPasswordMessage.UseCustomForeColor = true;
            this.lblPasswordMessage.Visible = false;
            // 
            // txtRePassword
            // 
            // 
            // 
            // 
            this.txtRePassword.CustomButton.Image = null;
            this.txtRePassword.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtRePassword.CustomButton.Name = "";
            this.txtRePassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRePassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRePassword.CustomButton.TabIndex = 1;
            this.txtRePassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRePassword.CustomButton.UseSelectable = true;
            this.txtRePassword.CustomButton.Visible = false;
            this.txtRePassword.Lines = new string[0];
            this.txtRePassword.Location = new System.Drawing.Point(136, 172);
            this.txtRePassword.MaxLength = 32767;
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '●';
            this.txtRePassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRePassword.SelectedText = "";
            this.txtRePassword.SelectionLength = 0;
            this.txtRePassword.SelectionStart = 0;
            this.txtRePassword.ShortcutsEnabled = true;
            this.txtRePassword.Size = new System.Drawing.Size(199, 23);
            this.txtRePassword.TabIndex = 4;
            this.txtRePassword.UseSelectable = true;
            this.txtRePassword.UseSystemPasswordChar = true;
            this.txtRePassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRePassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtRePassword.TextChanged += new System.EventHandler(this.txtRePassword_TextChanged);
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(136, 134);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(199, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblRePassword
            // 
            this.lblRePassword.AutoSize = true;
            this.lblRePassword.Location = new System.Drawing.Point(36, 176);
            this.lblRePassword.Name = "lblRePassword";
            this.lblRePassword.Size = new System.Drawing.Size(87, 19);
            this.lblRePassword.TabIndex = 235;
            this.lblRePassword.Text = "Re-Password:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(57, 138);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 19);
            this.lblPassword.TabIndex = 236;
            this.lblPassword.Text = "Password:";
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(968, 250);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 36);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(968, 199);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 36);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Location = new System.Drawing.Point(968, 150);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 36);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Modify";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.Location = new System.Drawing.Point(968, 99);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(102, 36);
            this.btnAddUser.TabIndex = 12;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseSelectable = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddManager_Click);
            // 
            // dataGridViewUserRegister
            // 
            this.dataGridViewUserRegister.AllowUserToAddRows = false;
            this.dataGridViewUserRegister.AllowUserToDeleteRows = false;
            this.dataGridViewUserRegister.AllowUserToResizeRows = false;
            this.dataGridViewUserRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUserRegister.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewUserRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUserRegister.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewUserRegister.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUserRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUserRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUserRegister.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUserRegister.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewUserRegister.EnableHeadersVisualStyles = false;
            this.dataGridViewUserRegister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewUserRegister.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewUserRegister.Location = new System.Drawing.Point(20, 441);
            this.dataGridViewUserRegister.Name = "dataGridViewUserRegister";
            this.dataGridViewUserRegister.ReadOnly = true;
            this.dataGridViewUserRegister.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUserRegister.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewUserRegister.RowHeadersVisible = false;
            this.dataGridViewUserRegister.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewUserRegister.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewUserRegister.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewUserRegister.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewUserRegister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserRegister.Size = new System.Drawing.Size(1050, 230);
            this.dataGridViewUserRegister.Style = MetroFramework.MetroColorStyle.Teal;
            this.dataGridViewUserRegister.TabIndex = 234;
            this.dataGridViewUserRegister.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewUserRegister.UseCustomBackColor = true;
            this.dataGridViewUserRegister.UseCustomForeColor = true;
            this.dataGridViewUserRegister.UseStyleColors = true;
            this.dataGridViewUserRegister.Click += new System.EventHandler(this.dataGridViewManagerRegister_Click);
            // 
            // txtUID
            // 
            // 
            // 
            // 
            this.txtUID.CustomButton.Image = null;
            this.txtUID.CustomButton.Location = new System.Drawing.Point(48, 1);
            this.txtUID.CustomButton.Name = "";
            this.txtUID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUID.CustomButton.TabIndex = 1;
            this.txtUID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUID.CustomButton.UseSelectable = true;
            this.txtUID.CustomButton.Visible = false;
            this.txtUID.Lines = new string[0];
            this.txtUID.Location = new System.Drawing.Point(136, 59);
            this.txtUID.MaxLength = 32767;
            this.txtUID.Name = "txtUID";
            this.txtUID.PasswordChar = '\0';
            this.txtUID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUID.SelectedText = "";
            this.txtUID.SelectionLength = 0;
            this.txtUID.SelectionStart = 0;
            this.txtUID.ShortcutsEnabled = true;
            this.txtUID.Size = new System.Drawing.Size(70, 23);
            this.txtUID.TabIndex = 1;
            this.txtUID.UseSelectable = true;
            this.txtUID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtUID.TextChanged += new System.EventHandler(this.txtUID_TextChanged);
            this.txtUID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUID_KeyUp);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(67, 63);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(54, 19);
            this.metroLabel1.TabIndex = 233;
            this.metroLabel1.Text = "User ID:";
            // 
            // txtManagerName
            // 
            // 
            // 
            // 
            this.txtManagerName.CustomButton.Image = null;
            this.txtManagerName.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtManagerName.CustomButton.Name = "";
            this.txtManagerName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtManagerName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtManagerName.CustomButton.TabIndex = 1;
            this.txtManagerName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtManagerName.CustomButton.UseSelectable = true;
            this.txtManagerName.CustomButton.Visible = false;
            this.txtManagerName.Lines = new string[0];
            this.txtManagerName.Location = new System.Drawing.Point(136, 95);
            this.txtManagerName.MaxLength = 32767;
            this.txtManagerName.Name = "txtManagerName";
            this.txtManagerName.PasswordChar = '\0';
            this.txtManagerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtManagerName.SelectedText = "";
            this.txtManagerName.SelectionLength = 0;
            this.txtManagerName.SelectionStart = 0;
            this.txtManagerName.ShortcutsEnabled = true;
            this.txtManagerName.Size = new System.Drawing.Size(199, 23);
            this.txtManagerName.TabIndex = 2;
            this.txtManagerName.UseSelectable = true;
            this.txtManagerName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtManagerName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblIName
            // 
            this.lblIName.AutoSize = true;
            this.lblIName.Location = new System.Drawing.Point(73, 99);
            this.lblIName.Name = "lblIName";
            this.lblIName.Size = new System.Drawing.Size(48, 19);
            this.lblIName.TabIndex = 232;
            this.lblIName.Text = "Name:";
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(394, 44);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(30, 19);
            this.lblUID.TabIndex = 219;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Location = new System.Drawing.Point(55, 254);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(66, 19);
            this.lblManager.TabIndex = 244;
            this.lblManager.Text = "Manager:";
            // 
            // cmbManagersUID
            // 
            this.cmbManagersUID.FormattingEnabled = true;
            this.cmbManagersUID.ItemHeight = 23;
            this.cmbManagersUID.Location = new System.Drawing.Point(136, 249);
            this.cmbManagersUID.Name = "cmbManagersUID";
            this.cmbManagersUID.Size = new System.Drawing.Size(105, 29);
            this.cmbManagersUID.TabIndex = 6;
            this.cmbManagersUID.UseSelectable = true;
            this.cmbManagersUID.SelectedIndexChanged += new System.EventHandler(this.cmbManagersUID_SelectedIndexChanged);
            // 
            // cmbSystemAccess
            // 
            this.cmbSystemAccess.FormattingEnabled = true;
            this.cmbSystemAccess.ItemHeight = 23;
            this.cmbSystemAccess.Location = new System.Drawing.Point(136, 208);
            this.cmbSystemAccess.Name = "cmbSystemAccess";
            this.cmbSystemAccess.Size = new System.Drawing.Size(167, 29);
            this.cmbSystemAccess.TabIndex = 5;
            this.cmbSystemAccess.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(26, 213);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(95, 19);
            this.metroLabel2.TabIndex = 246;
            this.metroLabel2.Text = "System Access:";
            // 
            // lblPICTemp
            // 
            this.lblPICTemp.AutoSize = true;
            this.lblPICTemp.Location = new System.Drawing.Point(445, 44);
            this.lblPICTemp.Name = "lblPICTemp";
            this.lblPICTemp.Size = new System.Drawing.Size(61, 19);
            this.lblPICTemp.TabIndex = 247;
            this.lblPICTemp.Text = "PICTemp";
            this.lblPICTemp.Visible = false;
            // 
            // lblTaskCode
            // 
            this.lblTaskCode.AutoSize = true;
            this.lblTaskCode.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTaskCode.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTaskCode.Location = new System.Drawing.Point(20, 16);
            this.lblTaskCode.Name = "lblTaskCode";
            this.lblTaskCode.Size = new System.Drawing.Size(115, 25);
            this.lblTaskCode.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblTaskCode.TabIndex = 248;
            this.lblTaskCode.Text = "Register User";
            this.lblTaskCode.UseStyleColors = true;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(968, 301);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 36);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btn_BulkImport
            // 
            this.btn_BulkImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BulkImport.Location = new System.Drawing.Point(968, 49);
            this.btn_BulkImport.Name = "btn_BulkImport";
            this.btn_BulkImport.Size = new System.Drawing.Size(102, 36);
            this.btn_BulkImport.TabIndex = 16;
            this.btn_BulkImport.Text = "Bulk Import";
            this.btn_BulkImport.UseSelectable = true;
            this.btn_BulkImport.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(1014, 390);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 301;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            // 
            // dateTimePickerTaskOut
            // 
            this.dateTimePickerTaskOut.CalendarFont = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerTaskOut.CustomFormat = "hh:mm tt";
            this.dateTimePickerTaskOut.Font = new System.Drawing.Font("Segoe UI", 10.9F);
            this.dateTimePickerTaskOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTaskOut.Location = new System.Drawing.Point(217, 50);
            this.dateTimePickerTaskOut.MinimumSize = new System.Drawing.Size(4, 29);
            this.dateTimePickerTaskOut.Name = "dateTimePickerTaskOut";
            this.dateTimePickerTaskOut.Size = new System.Drawing.Size(121, 29);
            this.dateTimePickerTaskOut.TabIndex = 11;
            this.dateTimePickerTaskOut.ValueChanged += new System.EventHandler(this.dateTimePickerTaskOut_ValueChanged);
            // 
            // dateTimePickerTaskIn
            // 
            this.dateTimePickerTaskIn.CalendarFont = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerTaskIn.CustomFormat = "hh:mm tt";
            this.dateTimePickerTaskIn.Font = new System.Drawing.Font("Segoe UI", 10.9F);
            this.dateTimePickerTaskIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTaskIn.Location = new System.Drawing.Point(64, 50);
            this.dateTimePickerTaskIn.MinimumSize = new System.Drawing.Size(4, 29);
            this.dateTimePickerTaskIn.Name = "dateTimePickerTaskIn";
            this.dateTimePickerTaskIn.Size = new System.Drawing.Size(121, 29);
            this.dateTimePickerTaskIn.TabIndex = 10;
            this.dateTimePickerTaskIn.ValueChanged += new System.EventHandler(this.dateTimePickerTaskIn_ValueChanged);
            // 
            // lblIDLEMessage
            // 
            this.lblIDLEMessage.AutoSize = true;
            this.lblIDLEMessage.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblIDLEMessage.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblIDLEMessage.Location = new System.Drawing.Point(37, 29);
            this.lblIDLEMessage.Name = "lblIDLEMessage";
            this.lblIDLEMessage.Size = new System.Drawing.Size(12, 15);
            this.lblIDLEMessage.Style = MetroFramework.MetroColorStyle.Red;
            this.lblIDLEMessage.TabIndex = 307;
            this.lblIDLEMessage.Text = "-";
            this.lblIDLEMessage.UseStyleColors = true;
            this.lblIDLEMessage.Visible = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(191, 55);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 19);
            this.lblTo.TabIndex = 306;
            this.lblTo.Text = "to";
            // 
            // lblTaskIn
            // 
            this.lblTaskIn.AutoSize = true;
            this.lblTaskIn.Location = new System.Drawing.Point(21, 55);
            this.lblTaskIn.Name = "lblTaskIn";
            this.lblTaskIn.Size = new System.Drawing.Size(41, 19);
            this.lblTaskIn.TabIndex = 305;
            this.lblTaskIn.Text = "From";
            // 
            // groupBoxShift
            // 
            this.groupBoxShift.Controls.Add(this.dateTimePickerTaskIn);
            this.groupBoxShift.Controls.Add(this.dateTimePickerTaskOut);
            this.groupBoxShift.Controls.Add(this.lblTaskIn);
            this.groupBoxShift.Controls.Add(this.lblTo);
            this.groupBoxShift.Controls.Add(this.lblIDLEMessage);
            this.groupBoxShift.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxShift.Location = new System.Drawing.Point(373, 290);
            this.groupBoxShift.Name = "groupBoxShift";
            this.groupBoxShift.Size = new System.Drawing.Size(385, 110);
            this.groupBoxShift.TabIndex = 308;
            this.groupBoxShift.TabStop = false;
            this.groupBoxShift.Text = "Shift Time: ";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(373, 254);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(81, 19);
            this.metroLabel4.TabIndex = 310;
            this.metroLabel4.Text = "Resource ID:";
            // 
            // lblviewResourceList
            // 
            this.lblviewResourceList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblviewResourceList.Location = new System.Drawing.Point(552, 248);
            this.lblviewResourceList.Name = "lblviewResourceList";
            this.lblviewResourceList.Size = new System.Drawing.Size(137, 30);
            this.lblviewResourceList.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblviewResourceList.TabIndex = 311;
            this.lblviewResourceList.Text = "View Resource ID List";
            this.lblviewResourceList.UseSelectable = true;
            this.lblviewResourceList.UseStyleColors = true;
            this.lblviewResourceList.Click += new System.EventHandler(this.lblviewResourceList_Click);
            // 
            // txtResourceId
            // 
            // 
            // 
            // 
            this.txtResourceId.CustomButton.Image = null;
            this.txtResourceId.CustomButton.Location = new System.Drawing.Point(64, 1);
            this.txtResourceId.CustomButton.Name = "";
            this.txtResourceId.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtResourceId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtResourceId.CustomButton.TabIndex = 1;
            this.txtResourceId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtResourceId.CustomButton.UseSelectable = true;
            this.txtResourceId.CustomButton.Visible = false;
            this.txtResourceId.Lines = new string[0];
            this.txtResourceId.Location = new System.Drawing.Point(460, 251);
            this.txtResourceId.MaxLength = 32767;
            this.txtResourceId.Name = "txtResourceId";
            this.txtResourceId.PasswordChar = '\0';
            this.txtResourceId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtResourceId.SelectedText = "";
            this.txtResourceId.SelectionLength = 0;
            this.txtResourceId.SelectionStart = 0;
            this.txtResourceId.ShortcutsEnabled = true;
            this.txtResourceId.Size = new System.Drawing.Size(86, 23);
            this.txtResourceId.TabIndex = 7;
            this.txtResourceId.UseSelectable = true;
            this.txtResourceId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtResourceId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtResourceId.TextChanged += new System.EventHandler(this.txtResourceId_TextChanged);
            this.txtResourceId.Leave += new System.EventHandler(this.metroTextBox1_Leave);
            // 
            // lblErrorResourceID
            // 
            this.lblErrorResourceID.AutoSize = true;
            this.lblErrorResourceID.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblErrorResourceID.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblErrorResourceID.Location = new System.Drawing.Point(460, 228);
            this.lblErrorResourceID.Name = "lblErrorResourceID";
            this.lblErrorResourceID.Size = new System.Drawing.Size(12, 15);
            this.lblErrorResourceID.Style = MetroFramework.MetroColorStyle.Red;
            this.lblErrorResourceID.TabIndex = 312;
            this.lblErrorResourceID.Text = "-";
            this.lblErrorResourceID.UseStyleColors = true;
            this.lblErrorResourceID.Visible = false;
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(1027, 408);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(40, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 300;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // pBoxError
            // 
            this.pBoxError.Image = ((System.Drawing.Image)(resources.GetObject("pBoxError.Image")));
            this.pBoxError.Location = new System.Drawing.Point(351, 153);
            this.pBoxError.Name = "pBoxError";
            this.pBoxError.Size = new System.Drawing.Size(22, 19);
            this.pBoxError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxError.TabIndex = 239;
            this.pBoxError.TabStop = false;
            this.pBoxError.Visible = false;
            // 
            // pBoxCorrect
            // 
            this.pBoxCorrect.Image = ((System.Drawing.Image)(resources.GetObject("pBoxCorrect.Image")));
            this.pBoxCorrect.Location = new System.Drawing.Point(351, 153);
            this.pBoxCorrect.Name = "pBoxCorrect";
            this.pBoxCorrect.Size = new System.Drawing.Size(22, 19);
            this.pBoxCorrect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxCorrect.TabIndex = 238;
            this.pBoxCorrect.TabStop = false;
            this.pBoxCorrect.Visible = false;
            // 
            // pBoxRefersh
            // 
            this.pBoxRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxRefersh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxRefersh.Image")));
            this.pBoxRefersh.Location = new System.Drawing.Point(20, 415);
            this.pBoxRefersh.Name = "pBoxRefersh";
            this.pBoxRefersh.Size = new System.Drawing.Size(22, 20);
            this.pBoxRefersh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRefersh.TabIndex = 231;
            this.pBoxRefersh.TabStop = false;
            this.pBoxRefersh.WaitOnLoad = true;
            this.pBoxRefersh.Click += new System.EventHandler(this.pBoxRefersh_Click);
            // 
            // frm_UserRegistrationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 691);
            this.ControlBox = false;
            this.Controls.Add(this.lblErrorResourceID);
            this.Controls.Add(this.txtResourceId);
            this.Controls.Add(this.lblviewResourceList);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.groupBoxShift);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.pBoxExportExcel);
            this.Controls.Add(this.btn_BulkImport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTaskCode);
            this.Controls.Add(this.lblPICTemp);
            this.Controls.Add(this.cmbSystemAccess);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.cmbManagersUID);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.checkedListBoxProjects);
            this.Controls.Add(this.lblProjects);
            this.Controls.Add(this.pBoxError);
            this.Controls.Add(this.pBoxCorrect);
            this.Controls.Add(this.lblPasswordMessage);
            this.Controls.Add(this.txtRePassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblRePassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.dataGridViewUserRegister);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtManagerName);
            this.Controls.Add(this.lblIName);
            this.Controls.Add(this.pBoxRefersh);
            this.Controls.Add(this.lblUID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "frm_UserRegistrationPanel";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Activated += new System.EventHandler(this.frm_UserRegistrationPanel_Activated);
            this.Load += new System.EventHandler(this.frm_UserRegistrationPanel_Load);
            this.Enter += new System.EventHandler(this.frm_UserRegistrationPanel_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserRegister)).EndInit();
            this.groupBoxShift.ResumeLayout(false);
            this.groupBoxShift.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCorrect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroCheckBox chkSelectAll;
        private System.Windows.Forms.CheckedListBox checkedListBoxProjects;
        private MetroFramework.Controls.MetroLabel lblProjects;
        private System.Windows.Forms.PictureBox pBoxError;
        private System.Windows.Forms.PictureBox pBoxCorrect;
        private MetroFramework.Controls.MetroLabel lblPasswordMessage;
        private MetroFramework.Controls.MetroTextBox txtRePassword;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroLabel lblRePassword;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnUpdate;
        private MetroFramework.Controls.MetroButton btnAddUser;
        private MetroFramework.Controls.MetroGrid dataGridViewUserRegister;
        private MetroFramework.Controls.MetroTextBox txtUID;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtManagerName;
        private MetroFramework.Controls.MetroLabel lblIName;
        private System.Windows.Forms.PictureBox pBoxRefersh;
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroLabel lblManager;
        private MetroFramework.Controls.MetroComboBox cmbManagersUID;
        private MetroFramework.Controls.MetroComboBox cmbSystemAccess;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblPICTemp;
        private MetroFramework.Controls.MetroLabel lblTaskCode;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btn_BulkImport;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskIn;
        private MetroFramework.Controls.MetroLabel lblIDLEMessage;
        private MetroFramework.Controls.MetroLabel lblTo;
        private MetroFramework.Controls.MetroLabel lblTaskIn;
        private System.Windows.Forms.GroupBox groupBoxShift;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLink lblviewResourceList;
        private MetroFramework.Controls.MetroTextBox txtResourceId;
        private MetroFramework.Controls.MetroLabel lblErrorResourceID;
    }
}