namespace CITITO
{
    partial class frm_ManagerModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ManagerModify));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pBoxCorrect = new System.Windows.Forms.PictureBox();
            this.chkModifyPassword = new MetroFramework.Controls.MetroCheckBox();
            this.lblPasswordMessage = new MetroFramework.Controls.MetroLabel();
            this.pBoxError = new System.Windows.Forms.PictureBox();
            this.txtRePassword = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.lblRePassword = new MetroFramework.Controls.MetroLabel();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.txtNewName = new MetroFramework.Controls.MetroTextBox();
            this.lblNewName = new MetroFramework.Controls.MetroLabel();
            this.txtCurrentName = new MetroFramework.Controls.MetroTextBox();
            this.lblCurrentName = new MetroFramework.Controls.MetroLabel();
            this.lblPIC = new MetroFramework.Controls.MetroLabel();
            this.lblManagerUID = new MetroFramework.Controls.MetroLabel();
            this.rdoBasicDetails = new MetroFramework.Controls.MetroRadioButton();
            this.rdoProjectDetails = new MetroFramework.Controls.MetroRadioButton();
            this.btnAddToList = new MetroFramework.Controls.MetroButton();
            this.btnRemoveToList = new MetroFramework.Controls.MetroButton();
            this.checkedListBoxRemoveProjects = new System.Windows.Forms.ListBox();
            this.checkedListBoxAddProjects = new System.Windows.Forms.ListBox();
            this.lblRemoved = new MetroFramework.Controls.MetroLabel();
            this.lblAdd = new MetroFramework.Controls.MetroLabel();
            this.btnMultiAdd = new MetroFramework.Controls.MetroButton();
            this.btnMultiRemove = new MetroFramework.Controls.MetroButton();
            this.txtCurrentAccess = new MetroFramework.Controls.MetroTextBox();
            this.lblCurrentAccess = new MetroFramework.Controls.MetroLabel();
            this.cmbSystemAccess = new MetroFramework.Controls.MetroComboBox();
            this.lblChangeAccess = new MetroFramework.Controls.MetroLabel();
            this.metroRadioButtonAccessDetails = new MetroFramework.Controls.MetroRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCorrect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxError)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(106, 37);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(202, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 203;
            this.metroLabel1.Text = "Modify Manager Details";
            this.metroLabel1.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 202;
            this.pictureBox1.TabStop = false;
            // 
            // pBoxCorrect
            // 
            this.pBoxCorrect.Image = ((System.Drawing.Image)(resources.GetObject("pBoxCorrect.Image")));
            this.pBoxCorrect.Location = new System.Drawing.Point(435, 289);
            this.pBoxCorrect.Name = "pBoxCorrect";
            this.pBoxCorrect.Size = new System.Drawing.Size(22, 17);
            this.pBoxCorrect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxCorrect.TabIndex = 201;
            this.pBoxCorrect.TabStop = false;
            this.pBoxCorrect.Visible = false;
            // 
            // chkModifyPassword
            // 
            this.chkModifyPassword.AutoSize = true;
            this.chkModifyPassword.Location = new System.Drawing.Point(230, 243);
            this.chkModifyPassword.Name = "chkModifyPassword";
            this.chkModifyPassword.Size = new System.Drawing.Size(114, 15);
            this.chkModifyPassword.TabIndex = 189;
            this.chkModifyPassword.Text = "Modify Password";
            this.chkModifyPassword.UseSelectable = true;
            this.chkModifyPassword.CheckedChanged += new System.EventHandler(this.chkModifyPassword_CheckedChanged);
            // 
            // lblPasswordMessage
            // 
            this.lblPasswordMessage.AutoSize = true;
            this.lblPasswordMessage.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPasswordMessage.Location = new System.Drawing.Point(457, 289);
            this.lblPasswordMessage.Name = "lblPasswordMessage";
            this.lblPasswordMessage.Size = new System.Drawing.Size(22, 19);
            this.lblPasswordMessage.TabIndex = 200;
            this.lblPasswordMessage.Text = "M";
            this.lblPasswordMessage.UseCustomForeColor = true;
            this.lblPasswordMessage.Visible = false;
            // 
            // pBoxError
            // 
            this.pBoxError.Image = ((System.Drawing.Image)(resources.GetObject("pBoxError.Image")));
            this.pBoxError.Location = new System.Drawing.Point(435, 289);
            this.pBoxError.Name = "pBoxError";
            this.pBoxError.Size = new System.Drawing.Size(22, 17);
            this.pBoxError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxError.TabIndex = 199;
            this.pBoxError.TabStop = false;
            this.pBoxError.Visible = false;
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
            this.txtRePassword.Location = new System.Drawing.Point(230, 306);
            this.txtRePassword.MaxLength = 32767;
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '●';
            this.txtRePassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRePassword.SelectedText = "";
            this.txtRePassword.SelectionLength = 0;
            this.txtRePassword.SelectionStart = 0;
            this.txtRePassword.ShortcutsEnabled = true;
            this.txtRePassword.Size = new System.Drawing.Size(199, 23);
            this.txtRePassword.TabIndex = 191;
            this.txtRePassword.UseCustomBackColor = true;
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
            this.txtPassword.Location = new System.Drawing.Point(230, 268);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(199, 23);
            this.txtPassword.TabIndex = 190;
            this.txtPassword.UseCustomBackColor = true;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblRePassword
            // 
            this.lblRePassword.AutoSize = true;
            this.lblRePassword.Location = new System.Drawing.Point(130, 310);
            this.lblRePassword.Name = "lblRePassword";
            this.lblRePassword.Size = new System.Drawing.Size(87, 19);
            this.lblRePassword.TabIndex = 197;
            this.lblRePassword.Text = "Re-Password:";
            this.lblRePassword.UseCustomBackColor = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(151, 272);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 19);
            this.lblPassword.TabIndex = 198;
            this.lblPassword.Text = "Password:";
            this.lblPassword.UseCustomBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(621, 376);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 193;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(514, 376);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 32);
            this.btnUpdate.TabIndex = 192;
            this.btnUpdate.Text = "Modify";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtNewName
            // 
            // 
            // 
            // 
            this.txtNewName.CustomButton.Image = null;
            this.txtNewName.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.txtNewName.CustomButton.Name = "";
            this.txtNewName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNewName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNewName.CustomButton.TabIndex = 1;
            this.txtNewName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNewName.CustomButton.UseSelectable = true;
            this.txtNewName.CustomButton.Visible = false;
            this.txtNewName.Lines = new string[0];
            this.txtNewName.Location = new System.Drawing.Point(230, 207);
            this.txtNewName.MaxLength = 32767;
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.PasswordChar = '\0';
            this.txtNewName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewName.SelectedText = "";
            this.txtNewName.SelectionLength = 0;
            this.txtNewName.SelectionStart = 0;
            this.txtNewName.ShortcutsEnabled = true;
            this.txtNewName.Size = new System.Drawing.Size(187, 23);
            this.txtNewName.TabIndex = 188;
            this.txtNewName.UseSelectable = true;
            this.txtNewName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNewName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblNewName
            // 
            this.lblNewName.AutoSize = true;
            this.lblNewName.Location = new System.Drawing.Point(146, 207);
            this.lblNewName.Name = "lblNewName";
            this.lblNewName.Size = new System.Drawing.Size(78, 19);
            this.lblNewName.TabIndex = 196;
            this.lblNewName.Text = "New Name:";
            // 
            // txtCurrentName
            // 
            // 
            // 
            // 
            this.txtCurrentName.CustomButton.Image = null;
            this.txtCurrentName.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.txtCurrentName.CustomButton.Name = "";
            this.txtCurrentName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCurrentName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrentName.CustomButton.TabIndex = 1;
            this.txtCurrentName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrentName.CustomButton.UseSelectable = true;
            this.txtCurrentName.CustomButton.Visible = false;
            this.txtCurrentName.Enabled = false;
            this.txtCurrentName.Lines = new string[0];
            this.txtCurrentName.Location = new System.Drawing.Point(230, 166);
            this.txtCurrentName.MaxLength = 32767;
            this.txtCurrentName.Name = "txtCurrentName";
            this.txtCurrentName.PasswordChar = '\0';
            this.txtCurrentName.ReadOnly = true;
            this.txtCurrentName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrentName.SelectedText = "";
            this.txtCurrentName.SelectionLength = 0;
            this.txtCurrentName.SelectionStart = 0;
            this.txtCurrentName.ShortcutsEnabled = true;
            this.txtCurrentName.Size = new System.Drawing.Size(187, 23);
            this.txtCurrentName.TabIndex = 187;
            this.txtCurrentName.UseSelectable = true;
            this.txtCurrentName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrentName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCurrentName
            // 
            this.lblCurrentName.AutoSize = true;
            this.lblCurrentName.Location = new System.Drawing.Point(128, 166);
            this.lblCurrentName.Name = "lblCurrentName";
            this.lblCurrentName.Size = new System.Drawing.Size(96, 19);
            this.lblCurrentName.TabIndex = 195;
            this.lblCurrentName.Text = "Current Name:";
            // 
            // lblPIC
            // 
            this.lblPIC.AutoSize = true;
            this.lblPIC.Location = new System.Drawing.Point(529, 43);
            this.lblPIC.Name = "lblPIC";
            this.lblPIC.Size = new System.Drawing.Size(29, 19);
            this.lblPIC.TabIndex = 194;
            this.lblPIC.Text = "PIC";
            this.lblPIC.Visible = false;
            // 
            // lblManagerUID
            // 
            this.lblManagerUID.AutoSize = true;
            this.lblManagerUID.Location = new System.Drawing.Point(461, 43);
            this.lblManagerUID.Name = "lblManagerUID";
            this.lblManagerUID.Size = new System.Drawing.Size(62, 19);
            this.lblManagerUID.TabIndex = 204;
            this.lblManagerUID.Text = "Manager";
            this.lblManagerUID.Visible = false;
            // 
            // rdoBasicDetails
            // 
            this.rdoBasicDetails.AutoSize = true;
            this.rdoBasicDetails.Location = new System.Drawing.Point(101, 102);
            this.rdoBasicDetails.Name = "rdoBasicDetails";
            this.rdoBasicDetails.Size = new System.Drawing.Size(88, 15);
            this.rdoBasicDetails.TabIndex = 205;
            this.rdoBasicDetails.Text = "Basic Details";
            this.rdoBasicDetails.UseSelectable = true;
            this.rdoBasicDetails.CheckedChanged += new System.EventHandler(this.rdoBasicDetails_CheckedChanged);
            // 
            // rdoProjectDetails
            // 
            this.rdoProjectDetails.AutoSize = true;
            this.rdoProjectDetails.Location = new System.Drawing.Point(310, 102);
            this.rdoProjectDetails.Name = "rdoProjectDetails";
            this.rdoProjectDetails.Size = new System.Drawing.Size(98, 15);
            this.rdoProjectDetails.TabIndex = 206;
            this.rdoProjectDetails.Text = "Project Details";
            this.rdoProjectDetails.UseSelectable = true;
            this.rdoProjectDetails.CheckedChanged += new System.EventHandler(this.rdoProjectDetails_CheckedChanged);
            // 
            // btnAddToList
            // 
            this.btnAddToList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddToList.BackgroundImage")));
            this.btnAddToList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddToList.Location = new System.Drawing.Point(303, 178);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(25, 21);
            this.btnAddToList.TabIndex = 218;
            this.btnAddToList.UseSelectable = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnRemoveToList
            // 
            this.btnRemoveToList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveToList.BackgroundImage")));
            this.btnRemoveToList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveToList.Location = new System.Drawing.Point(303, 264);
            this.btnRemoveToList.Name = "btnRemoveToList";
            this.btnRemoveToList.Size = new System.Drawing.Size(25, 21);
            this.btnRemoveToList.TabIndex = 219;
            this.btnRemoveToList.UseSelectable = true;
            this.btnRemoveToList.Click += new System.EventHandler(this.btnRemoveToList_Click);
            // 
            // checkedListBoxRemoveProjects
            // 
            this.checkedListBoxRemoveProjects.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.checkedListBoxRemoveProjects.FormattingEnabled = true;
            this.checkedListBoxRemoveProjects.ItemHeight = 15;
            this.checkedListBoxRemoveProjects.Location = new System.Drawing.Point(135, 155);
            this.checkedListBoxRemoveProjects.Name = "checkedListBoxRemoveProjects";
            this.checkedListBoxRemoveProjects.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.checkedListBoxRemoveProjects.Size = new System.Drawing.Size(145, 169);
            this.checkedListBoxRemoveProjects.TabIndex = 220;
            // 
            // checkedListBoxAddProjects
            // 
            this.checkedListBoxAddProjects.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.checkedListBoxAddProjects.FormattingEnabled = true;
            this.checkedListBoxAddProjects.ItemHeight = 15;
            this.checkedListBoxAddProjects.Location = new System.Drawing.Point(350, 155);
            this.checkedListBoxAddProjects.Name = "checkedListBoxAddProjects";
            this.checkedListBoxAddProjects.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.checkedListBoxAddProjects.Size = new System.Drawing.Size(145, 169);
            this.checkedListBoxAddProjects.TabIndex = 221;
            // 
            // lblRemoved
            // 
            this.lblRemoved.AutoSize = true;
            this.lblRemoved.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblRemoved.Location = new System.Drawing.Point(135, 137);
            this.lblRemoved.Name = "lblRemoved";
            this.lblRemoved.Size = new System.Drawing.Size(89, 15);
            this.lblRemoved.TabIndex = 222;
            this.lblRemoved.Text = "Remove Project:";
            this.lblRemoved.Visible = false;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblAdd.Location = new System.Drawing.Point(350, 137);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(70, 15);
            this.lblAdd.TabIndex = 223;
            this.lblAdd.Text = "Add Project:";
            this.lblAdd.Visible = false;
            // 
            // btnMultiAdd
            // 
            this.btnMultiAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMultiAdd.BackgroundImage")));
            this.btnMultiAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMultiAdd.Location = new System.Drawing.Point(303, 207);
            this.btnMultiAdd.Name = "btnMultiAdd";
            this.btnMultiAdd.Size = new System.Drawing.Size(25, 21);
            this.btnMultiAdd.TabIndex = 224;
            this.btnMultiAdd.UseSelectable = true;
            this.btnMultiAdd.Click += new System.EventHandler(this.btnMultiAdd_Click);
            // 
            // btnMultiRemove
            // 
            this.btnMultiRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMultiRemove.BackgroundImage")));
            this.btnMultiRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMultiRemove.Location = new System.Drawing.Point(303, 293);
            this.btnMultiRemove.Name = "btnMultiRemove";
            this.btnMultiRemove.Size = new System.Drawing.Size(25, 21);
            this.btnMultiRemove.TabIndex = 225;
            this.btnMultiRemove.UseSelectable = true;
            this.btnMultiRemove.Click += new System.EventHandler(this.btnMultiRemove_Click);
            // 
            // txtCurrentAccess
            // 
            // 
            // 
            // 
            this.txtCurrentAccess.CustomButton.Image = null;
            this.txtCurrentAccess.CustomButton.Location = new System.Drawing.Point(145, 1);
            this.txtCurrentAccess.CustomButton.Name = "";
            this.txtCurrentAccess.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCurrentAccess.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrentAccess.CustomButton.TabIndex = 1;
            this.txtCurrentAccess.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrentAccess.CustomButton.UseSelectable = true;
            this.txtCurrentAccess.CustomButton.Visible = false;
            this.txtCurrentAccess.Enabled = false;
            this.txtCurrentAccess.Lines = new string[0];
            this.txtCurrentAccess.Location = new System.Drawing.Point(357, 152);
            this.txtCurrentAccess.MaxLength = 32767;
            this.txtCurrentAccess.Name = "txtCurrentAccess";
            this.txtCurrentAccess.PasswordChar = '\0';
            this.txtCurrentAccess.ReadOnly = true;
            this.txtCurrentAccess.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrentAccess.SelectedText = "";
            this.txtCurrentAccess.SelectionLength = 0;
            this.txtCurrentAccess.SelectionStart = 0;
            this.txtCurrentAccess.ShortcutsEnabled = true;
            this.txtCurrentAccess.Size = new System.Drawing.Size(167, 23);
            this.txtCurrentAccess.TabIndex = 264;
            this.txtCurrentAccess.UseSelectable = true;
            this.txtCurrentAccess.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrentAccess.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCurrentAccess
            // 
            this.lblCurrentAccess.AutoSize = true;
            this.lblCurrentAccess.Location = new System.Drawing.Point(248, 156);
            this.lblCurrentAccess.Name = "lblCurrentAccess";
            this.lblCurrentAccess.Size = new System.Drawing.Size(98, 19);
            this.lblCurrentAccess.TabIndex = 263;
            this.lblCurrentAccess.Text = "Current Access:";
            // 
            // cmbSystemAccess
            // 
            this.cmbSystemAccess.FormattingEnabled = true;
            this.cmbSystemAccess.ItemHeight = 23;
            this.cmbSystemAccess.Location = new System.Drawing.Point(357, 187);
            this.cmbSystemAccess.Name = "cmbSystemAccess";
            this.cmbSystemAccess.Size = new System.Drawing.Size(167, 29);
            this.cmbSystemAccess.TabIndex = 261;
            this.cmbSystemAccess.UseSelectable = true;
            // 
            // lblChangeAccess
            // 
            this.lblChangeAccess.AutoSize = true;
            this.lblChangeAccess.Location = new System.Drawing.Point(247, 197);
            this.lblChangeAccess.Name = "lblChangeAccess";
            this.lblChangeAccess.Size = new System.Drawing.Size(99, 19);
            this.lblChangeAccess.TabIndex = 262;
            this.lblChangeAccess.Text = "Change Access:";
            // 
            // metroRadioButtonAccessDetails
            // 
            this.metroRadioButtonAccessDetails.AutoSize = true;
            this.metroRadioButtonAccessDetails.Location = new System.Drawing.Point(514, 102);
            this.metroRadioButtonAccessDetails.Name = "metroRadioButtonAccessDetails";
            this.metroRadioButtonAccessDetails.Size = new System.Drawing.Size(97, 15);
            this.metroRadioButtonAccessDetails.TabIndex = 260;
            this.metroRadioButtonAccessDetails.Text = "Access Details";
            this.metroRadioButtonAccessDetails.UseSelectable = true;
            this.metroRadioButtonAccessDetails.CheckedChanged += new System.EventHandler(this.metroRadioButtonAccessDetails_CheckedChanged);
            // 
            // frm_ManagerModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 431);
            this.Controls.Add(this.txtCurrentAccess);
            this.Controls.Add(this.lblCurrentAccess);
            this.Controls.Add(this.cmbSystemAccess);
            this.Controls.Add(this.lblChangeAccess);
            this.Controls.Add(this.metroRadioButtonAccessDetails);
            this.Controls.Add(this.btnMultiRemove);
            this.Controls.Add(this.btnMultiAdd);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.lblRemoved);
            this.Controls.Add(this.checkedListBoxAddProjects);
            this.Controls.Add(this.checkedListBoxRemoveProjects);
            this.Controls.Add(this.btnRemoveToList);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.rdoProjectDetails);
            this.Controls.Add(this.rdoBasicDetails);
            this.Controls.Add(this.lblManagerUID);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pBoxCorrect);
            this.Controls.Add(this.chkModifyPassword);
            this.Controls.Add(this.lblPasswordMessage);
            this.Controls.Add(this.pBoxError);
            this.Controls.Add(this.txtRePassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblRePassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.lblNewName);
            this.Controls.Add(this.txtCurrentName);
            this.Controls.Add(this.lblCurrentName);
            this.Controls.Add(this.lblPIC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_ManagerModify";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_ManagerModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCorrect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pBoxCorrect;
        private MetroFramework.Controls.MetroCheckBox chkModifyPassword;
        private MetroFramework.Controls.MetroLabel lblPasswordMessage;
        private System.Windows.Forms.PictureBox pBoxError;
        private MetroFramework.Controls.MetroTextBox txtRePassword;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroLabel lblRePassword;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnUpdate;
        private MetroFramework.Controls.MetroTextBox txtNewName;
        private MetroFramework.Controls.MetroLabel lblNewName;
        private MetroFramework.Controls.MetroTextBox txtCurrentName;
        private MetroFramework.Controls.MetroLabel lblCurrentName;
        private MetroFramework.Controls.MetroLabel lblPIC;
        private MetroFramework.Controls.MetroLabel lblManagerUID;
        private MetroFramework.Controls.MetroRadioButton rdoBasicDetails;
        private MetroFramework.Controls.MetroRadioButton rdoProjectDetails;
        private MetroFramework.Controls.MetroButton btnAddToList;
        private MetroFramework.Controls.MetroButton btnRemoveToList;
        private System.Windows.Forms.ListBox checkedListBoxRemoveProjects;
        private System.Windows.Forms.ListBox checkedListBoxAddProjects;
        private MetroFramework.Controls.MetroLabel lblRemoved;
        private MetroFramework.Controls.MetroLabel lblAdd;
        private MetroFramework.Controls.MetroButton btnMultiAdd;
        private MetroFramework.Controls.MetroButton btnMultiRemove;
        private MetroFramework.Controls.MetroTextBox txtCurrentAccess;
        private MetroFramework.Controls.MetroLabel lblCurrentAccess;
        private MetroFramework.Controls.MetroComboBox cmbSystemAccess;
        private MetroFramework.Controls.MetroLabel lblChangeAccess;
        private MetroFramework.Controls.MetroRadioButton metroRadioButtonAccessDetails;
    }
}