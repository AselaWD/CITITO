namespace CITITO
{
    partial class frm_PICRegisterPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PICRegisterPanel));
            this.txtRePassword = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.lblRePassword = new MetroFramework.Controls.MetroLabel();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.btnAddManager = new MetroFramework.Controls.MetroButton();
            this.dataGridViewImmediateManagerRegister = new MetroFramework.Controls.MetroGrid();
            this.txtUID = new MetroFramework.Controls.MetroTextBox();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.txtManagerName = new MetroFramework.Controls.MetroTextBox();
            this.lblImmediateManagerName = new MetroFramework.Controls.MetroLabel();
            this.pBoxRefersh = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pBoxCorrect = new System.Windows.Forms.PictureBox();
            this.lblPasswordMessage = new MetroFramework.Controls.MetroLabel();
            this.pBoxError = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImmediateManagerRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCorrect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            this.SuspendLayout();
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
            this.txtRePassword.Location = new System.Drawing.Point(138, 261);
            this.txtRePassword.MaxLength = 32767;
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '●';
            this.txtRePassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRePassword.SelectedText = "";
            this.txtRePassword.SelectionLength = 0;
            this.txtRePassword.SelectionStart = 0;
            this.txtRePassword.ShortcutsEnabled = true;
            this.txtRePassword.Size = new System.Drawing.Size(199, 23);
            this.txtRePassword.TabIndex = 164;
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
            this.txtPassword.Location = new System.Drawing.Point(138, 223);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(199, 23);
            this.txtPassword.TabIndex = 163;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblRePassword
            // 
            this.lblRePassword.AutoSize = true;
            this.lblRePassword.Location = new System.Drawing.Point(38, 265);
            this.lblRePassword.Name = "lblRePassword";
            this.lblRePassword.Size = new System.Drawing.Size(87, 19);
            this.lblRePassword.TabIndex = 179;
            this.lblRePassword.Text = "Re-Password:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(59, 227);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 19);
            this.lblPassword.TabIndex = 180;
            this.lblPassword.Text = "Password:";
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(636, 248);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 36);
            this.btnExit.TabIndex = 171;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(636, 201);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 36);
            this.btnClear.TabIndex = 170;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(636, 155);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 36);
            this.btnDelete.TabIndex = 169;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Location = new System.Drawing.Point(636, 109);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 36);
            this.btnUpdate.TabIndex = 168;
            this.btnUpdate.Text = "Modify";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAddManager
            // 
            this.btnAddManager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddManager.Location = new System.Drawing.Point(636, 63);
            this.btnAddManager.Name = "btnAddManager";
            this.btnAddManager.Size = new System.Drawing.Size(102, 36);
            this.btnAddManager.TabIndex = 167;
            this.btnAddManager.Text = "Add Manager";
            this.btnAddManager.UseSelectable = true;
            this.btnAddManager.Click += new System.EventHandler(this.btnAddManager_Click);
            // 
            // dataGridViewImmediateManagerRegister
            // 
            this.dataGridViewImmediateManagerRegister.AllowUserToAddRows = false;
            this.dataGridViewImmediateManagerRegister.AllowUserToDeleteRows = false;
            this.dataGridViewImmediateManagerRegister.AllowUserToResizeRows = false;
            this.dataGridViewImmediateManagerRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewImmediateManagerRegister.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewImmediateManagerRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewImmediateManagerRegister.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewImmediateManagerRegister.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImmediateManagerRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewImmediateManagerRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImmediateManagerRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImmediateManagerRegister.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewImmediateManagerRegister.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewImmediateManagerRegister.EnableHeadersVisualStyles = false;
            this.dataGridViewImmediateManagerRegister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewImmediateManagerRegister.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewImmediateManagerRegister.Location = new System.Drawing.Point(20, 353);
            this.dataGridViewImmediateManagerRegister.Name = "dataGridViewImmediateManagerRegister";
            this.dataGridViewImmediateManagerRegister.ReadOnly = true;
            this.dataGridViewImmediateManagerRegister.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImmediateManagerRegister.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewImmediateManagerRegister.RowHeadersVisible = false;
            this.dataGridViewImmediateManagerRegister.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewImmediateManagerRegister.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewImmediateManagerRegister.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewImmediateManagerRegister.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewImmediateManagerRegister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewImmediateManagerRegister.Size = new System.Drawing.Size(718, 282);
            this.dataGridViewImmediateManagerRegister.Style = MetroFramework.MetroColorStyle.Teal;
            this.dataGridViewImmediateManagerRegister.TabIndex = 176;
            this.dataGridViewImmediateManagerRegister.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewImmediateManagerRegister.UseCustomBackColor = true;
            this.dataGridViewImmediateManagerRegister.UseCustomForeColor = true;
            this.dataGridViewImmediateManagerRegister.UseStyleColors = true;
            this.dataGridViewImmediateManagerRegister.Click += new System.EventHandler(this.dataGridViewImmediateManagerRegister_Click);
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
            this.txtUID.Location = new System.Drawing.Point(138, 147);
            this.txtUID.MaxLength = 32767;
            this.txtUID.Name = "txtUID";
            this.txtUID.PasswordChar = '\0';
            this.txtUID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUID.SelectedText = "";
            this.txtUID.SelectionLength = 0;
            this.txtUID.SelectionStart = 0;
            this.txtUID.ShortcutsEnabled = true;
            this.txtUID.Size = new System.Drawing.Size(70, 23);
            this.txtUID.TabIndex = 161;
            this.txtUID.UseSelectable = true;
            this.txtUID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtUID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUID_KeyUp);
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(65, 147);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(54, 19);
            this.lblUID.TabIndex = 175;
            this.lblUID.Text = "User ID:";
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
            this.txtManagerName.Location = new System.Drawing.Point(138, 183);
            this.txtManagerName.MaxLength = 32767;
            this.txtManagerName.Name = "txtManagerName";
            this.txtManagerName.PasswordChar = '\0';
            this.txtManagerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtManagerName.SelectedText = "";
            this.txtManagerName.SelectionLength = 0;
            this.txtManagerName.SelectionStart = 0;
            this.txtManagerName.ShortcutsEnabled = true;
            this.txtManagerName.Size = new System.Drawing.Size(199, 23);
            this.txtManagerName.TabIndex = 162;
            this.txtManagerName.UseSelectable = true;
            this.txtManagerName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtManagerName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblImmediateManagerName
            // 
            this.lblImmediateManagerName.AutoSize = true;
            this.lblImmediateManagerName.Location = new System.Drawing.Point(20, 185);
            this.lblImmediateManagerName.Name = "lblImmediateManagerName";
            this.lblImmediateManagerName.Size = new System.Drawing.Size(105, 19);
            this.lblImmediateManagerName.TabIndex = 174;
            this.lblImmediateManagerName.Text = "Manager Name:";
            // 
            // pBoxRefersh
            // 
            this.pBoxRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxRefersh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxRefersh.Image")));
            this.pBoxRefersh.Location = new System.Drawing.Point(20, 327);
            this.pBoxRefersh.Name = "pBoxRefersh";
            this.pBoxRefersh.Size = new System.Drawing.Size(22, 20);
            this.pBoxRefersh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRefersh.TabIndex = 173;
            this.pBoxRefersh.TabStop = false;
            this.pBoxRefersh.WaitOnLoad = true;
            this.pBoxRefersh.Click += new System.EventHandler(this.pBoxRefersh_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 172;
            this.pictureBox1.TabStop = false;
            // 
            // pBoxCorrect
            // 
            this.pBoxCorrect.Image = ((System.Drawing.Image)(resources.GetObject("pBoxCorrect.Image")));
            this.pBoxCorrect.Location = new System.Drawing.Point(353, 242);
            this.pBoxCorrect.Name = "pBoxCorrect";
            this.pBoxCorrect.Size = new System.Drawing.Size(22, 19);
            this.pBoxCorrect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxCorrect.TabIndex = 182;
            this.pBoxCorrect.TabStop = false;
            this.pBoxCorrect.Visible = false;
            // 
            // lblPasswordMessage
            // 
            this.lblPasswordMessage.AutoSize = true;
            this.lblPasswordMessage.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPasswordMessage.Location = new System.Drawing.Point(375, 242);
            this.lblPasswordMessage.Name = "lblPasswordMessage";
            this.lblPasswordMessage.Size = new System.Drawing.Size(22, 19);
            this.lblPasswordMessage.TabIndex = 181;
            this.lblPasswordMessage.Text = "M";
            this.lblPasswordMessage.UseCustomForeColor = true;
            this.lblPasswordMessage.Visible = false;
            // 
            // pBoxError
            // 
            this.pBoxError.Image = ((System.Drawing.Image)(resources.GetObject("pBoxError.Image")));
            this.pBoxError.Location = new System.Drawing.Point(353, 242);
            this.pBoxError.Name = "pBoxError";
            this.pBoxError.Size = new System.Drawing.Size(22, 19);
            this.pBoxError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxError.TabIndex = 183;
            this.pBoxError.TabStop = false;
            this.pBoxError.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(115, 42);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(183, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 184;
            this.metroLabel1.Text = "PIC Registration Panel";
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(679, 302);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 233;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(699, 320);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(36, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 232;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // frm_PICRegisterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 655);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.pBoxExportExcel);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pBoxError);
            this.Controls.Add(this.pBoxCorrect);
            this.Controls.Add(this.lblPasswordMessage);
            this.Controls.Add(this.txtRePassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblRePassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddManager);
            this.Controls.Add(this.dataGridViewImmediateManagerRegister);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.txtManagerName);
            this.Controls.Add(this.lblImmediateManagerName);
            this.Controls.Add(this.pBoxRefersh);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_PICRegisterPanel";
            this.Resizable = false;
            this.Activated += new System.EventHandler(this.frm_PICRegisterPanel_Activated);
            this.Load += new System.EventHandler(this.frm_PICRegisterPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImmediateManagerRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCorrect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtRePassword;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroLabel lblRePassword;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnUpdate;
        private MetroFramework.Controls.MetroButton btnAddManager;
        private MetroFramework.Controls.MetroGrid dataGridViewImmediateManagerRegister;
        private MetroFramework.Controls.MetroTextBox txtUID;
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroTextBox txtManagerName;
        private MetroFramework.Controls.MetroLabel lblImmediateManagerName;
        private System.Windows.Forms.PictureBox pBoxRefersh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pBoxCorrect;
        private MetroFramework.Controls.MetroLabel lblPasswordMessage;
        private System.Windows.Forms.PictureBox pBoxError;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
    }
}

