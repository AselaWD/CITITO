namespace CITITO
{
    partial class frm_UserModifyByManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserModifyByManager));
            this.btnMultiRemove = new MetroFramework.Controls.MetroButton();
            this.btnMultiAdd = new MetroFramework.Controls.MetroButton();
            this.lblAdd = new MetroFramework.Controls.MetroLabel();
            this.lblRemoved = new MetroFramework.Controls.MetroLabel();
            this.checkedListBoxAddProjects = new System.Windows.Forms.ListBox();
            this.checkedListBoxRemoveProjects = new System.Windows.Forms.ListBox();
            this.btnRemoveToList = new MetroFramework.Controls.MetroButton();
            this.btnAddToList = new MetroFramework.Controls.MetroButton();
            this.rdoProjectDetails = new MetroFramework.Controls.MetroRadioButton();
            this.rdoBasicDetails = new MetroFramework.Controls.MetroRadioButton();
            this.lblManagerUID = new MetroFramework.Controls.MetroLabel();
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
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.txtResourceID = new MetroFramework.Controls.MetroTextBox();
            this.lblResourceID = new MetroFramework.Controls.MetroLabel();
            this.lblErrorResourceID = new MetroFramework.Controls.MetroLabel();
            this.lblviewResourceList = new MetroFramework.Controls.MetroLink();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCorrect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxError)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMultiRemove
            // 
            this.btnMultiRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMultiRemove.BackgroundImage")));
            this.btnMultiRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMultiRemove.Location = new System.Drawing.Point(322, 291);
            this.btnMultiRemove.Name = "btnMultiRemove";
            this.btnMultiRemove.Size = new System.Drawing.Size(25, 23);
            this.btnMultiRemove.TabIndex = 253;
            this.btnMultiRemove.UseSelectable = true;
            this.btnMultiRemove.Click += new System.EventHandler(this.btnMultiRemove_Click);
            // 
            // btnMultiAdd
            // 
            this.btnMultiAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMultiAdd.BackgroundImage")));
            this.btnMultiAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMultiAdd.Location = new System.Drawing.Point(322, 205);
            this.btnMultiAdd.Name = "btnMultiAdd";
            this.btnMultiAdd.Size = new System.Drawing.Size(25, 23);
            this.btnMultiAdd.TabIndex = 252;
            this.btnMultiAdd.UseSelectable = true;
            this.btnMultiAdd.Click += new System.EventHandler(this.btnMultiAdd_Click);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblAdd.Location = new System.Drawing.Point(369, 135);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(70, 15);
            this.lblAdd.TabIndex = 251;
            this.lblAdd.Text = "Add Project:";
            this.lblAdd.Visible = false;
            // 
            // lblRemoved
            // 
            this.lblRemoved.AutoSize = true;
            this.lblRemoved.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblRemoved.Location = new System.Drawing.Point(154, 135);
            this.lblRemoved.Name = "lblRemoved";
            this.lblRemoved.Size = new System.Drawing.Size(89, 15);
            this.lblRemoved.TabIndex = 250;
            this.lblRemoved.Text = "Remove Project:";
            this.lblRemoved.Visible = false;
            // 
            // checkedListBoxAddProjects
            // 
            this.checkedListBoxAddProjects.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.checkedListBoxAddProjects.FormattingEnabled = true;
            this.checkedListBoxAddProjects.ItemHeight = 15;
            this.checkedListBoxAddProjects.Location = new System.Drawing.Point(369, 153);
            this.checkedListBoxAddProjects.Name = "checkedListBoxAddProjects";
            this.checkedListBoxAddProjects.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.checkedListBoxAddProjects.Size = new System.Drawing.Size(145, 184);
            this.checkedListBoxAddProjects.TabIndex = 249;
            // 
            // checkedListBoxRemoveProjects
            // 
            this.checkedListBoxRemoveProjects.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.checkedListBoxRemoveProjects.FormattingEnabled = true;
            this.checkedListBoxRemoveProjects.ItemHeight = 15;
            this.checkedListBoxRemoveProjects.Location = new System.Drawing.Point(154, 153);
            this.checkedListBoxRemoveProjects.Name = "checkedListBoxRemoveProjects";
            this.checkedListBoxRemoveProjects.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.checkedListBoxRemoveProjects.Size = new System.Drawing.Size(145, 184);
            this.checkedListBoxRemoveProjects.TabIndex = 248;
            // 
            // btnRemoveToList
            // 
            this.btnRemoveToList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveToList.BackgroundImage")));
            this.btnRemoveToList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveToList.Location = new System.Drawing.Point(322, 262);
            this.btnRemoveToList.Name = "btnRemoveToList";
            this.btnRemoveToList.Size = new System.Drawing.Size(25, 23);
            this.btnRemoveToList.TabIndex = 247;
            this.btnRemoveToList.UseSelectable = true;
            this.btnRemoveToList.Click += new System.EventHandler(this.btnRemoveToList_Click);
            // 
            // btnAddToList
            // 
            this.btnAddToList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddToList.BackgroundImage")));
            this.btnAddToList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddToList.Location = new System.Drawing.Point(322, 176);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(25, 23);
            this.btnAddToList.TabIndex = 246;
            this.btnAddToList.UseSelectable = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // rdoProjectDetails
            // 
            this.rdoProjectDetails.AutoSize = true;
            this.rdoProjectDetails.Location = new System.Drawing.Point(305, 104);
            this.rdoProjectDetails.Name = "rdoProjectDetails";
            this.rdoProjectDetails.Size = new System.Drawing.Size(98, 15);
            this.rdoProjectDetails.TabIndex = 245;
            this.rdoProjectDetails.Text = "Project Details";
            this.rdoProjectDetails.UseSelectable = true;
            this.rdoProjectDetails.CheckedChanged += new System.EventHandler(this.rdoProjectDetails_CheckedChanged);
            // 
            // rdoBasicDetails
            // 
            this.rdoBasicDetails.AutoSize = true;
            this.rdoBasicDetails.Location = new System.Drawing.Point(107, 104);
            this.rdoBasicDetails.Name = "rdoBasicDetails";
            this.rdoBasicDetails.Size = new System.Drawing.Size(88, 15);
            this.rdoBasicDetails.TabIndex = 244;
            this.rdoBasicDetails.Text = "Basic Details";
            this.rdoBasicDetails.UseSelectable = true;
            this.rdoBasicDetails.CheckedChanged += new System.EventHandler(this.rdoBasicDetails_CheckedChanged);
            // 
            // lblManagerUID
            // 
            this.lblManagerUID.AutoSize = true;
            this.lblManagerUID.Location = new System.Drawing.Point(480, 39);
            this.lblManagerUID.Name = "lblManagerUID";
            this.lblManagerUID.Size = new System.Drawing.Size(62, 19);
            this.lblManagerUID.TabIndex = 243;
            this.lblManagerUID.Text = "Manager";
            this.lblManagerUID.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(112, 39);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(167, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 242;
            this.metroLabel1.Text = "Modify User Details";
            this.metroLabel1.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 241;
            this.pictureBox1.TabStop = false;
            // 
            // pBoxCorrect
            // 
            this.pBoxCorrect.Image = ((System.Drawing.Image)(resources.GetObject("pBoxCorrect.Image")));
            this.pBoxCorrect.Location = new System.Drawing.Point(381, 290);
            this.pBoxCorrect.Name = "pBoxCorrect";
            this.pBoxCorrect.Size = new System.Drawing.Size(22, 19);
            this.pBoxCorrect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxCorrect.TabIndex = 240;
            this.pBoxCorrect.TabStop = false;
            this.pBoxCorrect.Visible = false;
            // 
            // chkModifyPassword
            // 
            this.chkModifyPassword.AutoSize = true;
            this.chkModifyPassword.Location = new System.Drawing.Point(176, 244);
            this.chkModifyPassword.Name = "chkModifyPassword";
            this.chkModifyPassword.Size = new System.Drawing.Size(114, 15);
            this.chkModifyPassword.TabIndex = 228;
            this.chkModifyPassword.Text = "Modify Password";
            this.chkModifyPassword.UseSelectable = true;
            this.chkModifyPassword.CheckedChanged += new System.EventHandler(this.chkModifyPassword_CheckedChanged);
            // 
            // lblPasswordMessage
            // 
            this.lblPasswordMessage.AutoSize = true;
            this.lblPasswordMessage.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPasswordMessage.Location = new System.Drawing.Point(403, 290);
            this.lblPasswordMessage.Name = "lblPasswordMessage";
            this.lblPasswordMessage.Size = new System.Drawing.Size(22, 19);
            this.lblPasswordMessage.TabIndex = 239;
            this.lblPasswordMessage.Text = "M";
            this.lblPasswordMessage.UseCustomForeColor = true;
            this.lblPasswordMessage.Visible = false;
            // 
            // pBoxError
            // 
            this.pBoxError.Image = ((System.Drawing.Image)(resources.GetObject("pBoxError.Image")));
            this.pBoxError.Location = new System.Drawing.Point(381, 290);
            this.pBoxError.Name = "pBoxError";
            this.pBoxError.Size = new System.Drawing.Size(22, 19);
            this.pBoxError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxError.TabIndex = 238;
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
            this.txtRePassword.Location = new System.Drawing.Point(176, 307);
            this.txtRePassword.MaxLength = 32767;
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '●';
            this.txtRePassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRePassword.SelectedText = "";
            this.txtRePassword.SelectionLength = 0;
            this.txtRePassword.SelectionStart = 0;
            this.txtRePassword.ShortcutsEnabled = true;
            this.txtRePassword.Size = new System.Drawing.Size(199, 23);
            this.txtRePassword.TabIndex = 230;
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
            this.txtPassword.Location = new System.Drawing.Point(176, 269);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(199, 23);
            this.txtPassword.TabIndex = 229;
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
            this.lblRePassword.Location = new System.Drawing.Point(76, 311);
            this.lblRePassword.Name = "lblRePassword";
            this.lblRePassword.Size = new System.Drawing.Size(87, 19);
            this.lblRePassword.TabIndex = 236;
            this.lblRePassword.Text = "Re-Password:";
            this.lblRePassword.UseCustomBackColor = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(97, 273);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 19);
            this.lblPassword.TabIndex = 237;
            this.lblPassword.Text = "Password:";
            this.lblPassword.UseCustomBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(621, 411);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 232;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(514, 411);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 32);
            this.btnUpdate.TabIndex = 231;
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
            this.txtNewName.Location = new System.Drawing.Point(176, 208);
            this.txtNewName.MaxLength = 32767;
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.PasswordChar = '\0';
            this.txtNewName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewName.SelectedText = "";
            this.txtNewName.SelectionLength = 0;
            this.txtNewName.SelectionStart = 0;
            this.txtNewName.ShortcutsEnabled = true;
            this.txtNewName.Size = new System.Drawing.Size(187, 23);
            this.txtNewName.TabIndex = 227;
            this.txtNewName.UseSelectable = true;
            this.txtNewName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNewName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblNewName
            // 
            this.lblNewName.AutoSize = true;
            this.lblNewName.Location = new System.Drawing.Point(92, 208);
            this.lblNewName.Name = "lblNewName";
            this.lblNewName.Size = new System.Drawing.Size(78, 19);
            this.lblNewName.TabIndex = 235;
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
            this.txtCurrentName.Location = new System.Drawing.Point(176, 167);
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
            this.txtCurrentName.TabIndex = 226;
            this.txtCurrentName.UseSelectable = true;
            this.txtCurrentName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrentName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCurrentName
            // 
            this.lblCurrentName.AutoSize = true;
            this.lblCurrentName.Location = new System.Drawing.Point(74, 167);
            this.lblCurrentName.Name = "lblCurrentName";
            this.lblCurrentName.Size = new System.Drawing.Size(96, 19);
            this.lblCurrentName.TabIndex = 234;
            this.lblCurrentName.Text = "Current Name:";
            // 
            // lblPIC
            // 
            this.lblPIC.AutoSize = true;
            this.lblPIC.Location = new System.Drawing.Point(548, 39);
            this.lblPIC.Name = "lblPIC";
            this.lblPIC.Size = new System.Drawing.Size(29, 19);
            this.lblPIC.TabIndex = 233;
            this.lblPIC.Text = "PIC";
            this.lblPIC.Visible = false;
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(444, 39);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(30, 19);
            this.lblUID.TabIndex = 254;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // txtResourceID
            // 
            // 
            // 
            // 
            this.txtResourceID.CustomButton.Image = null;
            this.txtResourceID.CustomButton.Location = new System.Drawing.Point(101, 1);
            this.txtResourceID.CustomButton.Name = "";
            this.txtResourceID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtResourceID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtResourceID.CustomButton.TabIndex = 1;
            this.txtResourceID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtResourceID.CustomButton.UseSelectable = true;
            this.txtResourceID.CustomButton.Visible = false;
            this.txtResourceID.Lines = new string[0];
            this.txtResourceID.Location = new System.Drawing.Point(176, 358);
            this.txtResourceID.MaxLength = 32767;
            this.txtResourceID.Name = "txtResourceID";
            this.txtResourceID.PasswordChar = '\0';
            this.txtResourceID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtResourceID.SelectedText = "";
            this.txtResourceID.SelectionLength = 0;
            this.txtResourceID.SelectionStart = 0;
            this.txtResourceID.ShortcutsEnabled = true;
            this.txtResourceID.Size = new System.Drawing.Size(123, 23);
            this.txtResourceID.TabIndex = 255;
            this.txtResourceID.UseCustomBackColor = true;
            this.txtResourceID.UseSelectable = true;
            this.txtResourceID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtResourceID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtResourceID.TextChanged += new System.EventHandler(this.txtResourceID_TextChanged);
            this.txtResourceID.Leave += new System.EventHandler(this.txtResourceID_Leave);
            // 
            // lblResourceID
            // 
            this.lblResourceID.AutoSize = true;
            this.lblResourceID.Location = new System.Drawing.Point(82, 362);
            this.lblResourceID.Name = "lblResourceID";
            this.lblResourceID.Size = new System.Drawing.Size(81, 19);
            this.lblResourceID.TabIndex = 256;
            this.lblResourceID.Text = "Resource ID:";
            this.lblResourceID.UseCustomBackColor = true;
            // 
            // lblErrorResourceID
            // 
            this.lblErrorResourceID.AutoSize = true;
            this.lblErrorResourceID.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblErrorResourceID.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblErrorResourceID.Location = new System.Drawing.Point(179, 340);
            this.lblErrorResourceID.Name = "lblErrorResourceID";
            this.lblErrorResourceID.Size = new System.Drawing.Size(12, 15);
            this.lblErrorResourceID.Style = MetroFramework.MetroColorStyle.Red;
            this.lblErrorResourceID.TabIndex = 313;
            this.lblErrorResourceID.Text = "-";
            this.lblErrorResourceID.UseStyleColors = true;
            this.lblErrorResourceID.Visible = false;
            // 
            // lblviewResourceList
            // 
            this.lblviewResourceList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblviewResourceList.Location = new System.Drawing.Point(305, 354);
            this.lblviewResourceList.Name = "lblviewResourceList";
            this.lblviewResourceList.Size = new System.Drawing.Size(137, 30);
            this.lblviewResourceList.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblviewResourceList.TabIndex = 314;
            this.lblviewResourceList.Text = "View Resource ID List";
            this.lblviewResourceList.UseSelectable = true;
            this.lblviewResourceList.UseStyleColors = true;
            this.lblviewResourceList.Click += new System.EventHandler(this.lblviewResourceList_Click);
            // 
            // frm_UserModifyByManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 466);
            this.Controls.Add(this.lblviewResourceList);
            this.Controls.Add(this.lblErrorResourceID);
            this.Controls.Add(this.txtResourceID);
            this.Controls.Add(this.lblResourceID);
            this.Controls.Add(this.lblUID);
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
            this.Name = "frm_UserModifyByManager";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_UserModifyByManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCorrect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnMultiRemove;
        private MetroFramework.Controls.MetroButton btnMultiAdd;
        private MetroFramework.Controls.MetroLabel lblAdd;
        private MetroFramework.Controls.MetroLabel lblRemoved;
        private System.Windows.Forms.ListBox checkedListBoxAddProjects;
        private System.Windows.Forms.ListBox checkedListBoxRemoveProjects;
        private MetroFramework.Controls.MetroButton btnRemoveToList;
        private MetroFramework.Controls.MetroButton btnAddToList;
        private MetroFramework.Controls.MetroRadioButton rdoProjectDetails;
        private MetroFramework.Controls.MetroRadioButton rdoBasicDetails;
        private MetroFramework.Controls.MetroLabel lblManagerUID;
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
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroTextBox txtResourceID;
        private MetroFramework.Controls.MetroLabel lblResourceID;
        private MetroFramework.Controls.MetroLabel lblErrorResourceID;
        private MetroFramework.Controls.MetroLink lblviewResourceList;
    }
}