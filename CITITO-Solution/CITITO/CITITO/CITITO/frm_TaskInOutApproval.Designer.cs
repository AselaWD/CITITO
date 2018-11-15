namespace CITITO
{
    partial class frm_TaskInOutApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TaskInOutApproval));
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.dataGridViewTaskInOutForApproval = new MetroFramework.Controls.MetroGrid();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnApprove = new MetroFramework.Controls.MetroButton();
            this.btnDisapprove = new MetroFramework.Controls.MetroButton();
            this.btnTimeModify = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnHistory = new MetroFramework.Controls.MetroButton();
            this.lblTaskIn = new MetroFramework.Controls.MetroLabel();
            this.btnCheck = new MetroFramework.Controls.MetroButton();
            this.dateTimePickerTo = new MetroFramework.Controls.MetroDateTime();
            this.dateTimePickerFrom = new MetroFramework.Controls.MetroDateTime();
            this.lblTaskOut = new System.Windows.Forms.Label();
            this.cmbUserID = new MetroFramework.Controls.MetroTextBox();
            this.cmbPCPCode = new MetroFramework.Controls.MetroTextBox();
            this.lblMUID = new MetroFramework.Controls.MetroLabel();
            this.lblPIC = new MetroFramework.Controls.MetroLabel();
            this.cmbFileName = new MetroFramework.Controls.MetroTextBox();
            this.cmbMUID1 = new MetroFramework.Controls.MetroComboBox();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.pBoxRefersh = new System.Windows.Forms.PictureBox();
            this.btnModify = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskInOutForApproval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(1096, 44);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 305;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(1169, 426);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 36);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dataGridViewTaskInOutForApproval
            // 
            this.dataGridViewTaskInOutForApproval.AllowUserToAddRows = false;
            this.dataGridViewTaskInOutForApproval.AllowUserToDeleteRows = false;
            this.dataGridViewTaskInOutForApproval.AllowUserToResizeRows = false;
            this.dataGridViewTaskInOutForApproval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTaskInOutForApproval.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTaskInOutForApproval.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTaskInOutForApproval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTaskInOutForApproval.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewTaskInOutForApproval.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTaskInOutForApproval.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTaskInOutForApproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaskInOutForApproval.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTaskInOutForApproval.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTaskInOutForApproval.EnableHeadersVisualStyles = false;
            this.dataGridViewTaskInOutForApproval.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewTaskInOutForApproval.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTaskInOutForApproval.Location = new System.Drawing.Point(13, 95);
            this.dataGridViewTaskInOutForApproval.Name = "dataGridViewTaskInOutForApproval";
            this.dataGridViewTaskInOutForApproval.ReadOnly = true;
            this.dataGridViewTaskInOutForApproval.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTaskInOutForApproval.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTaskInOutForApproval.RowHeadersVisible = false;
            this.dataGridViewTaskInOutForApproval.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTaskInOutForApproval.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewTaskInOutForApproval.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewTaskInOutForApproval.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTaskInOutForApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTaskInOutForApproval.Size = new System.Drawing.Size(1142, 605);
            this.dataGridViewTaskInOutForApproval.Style = MetroFramework.MetroColorStyle.Teal;
            this.dataGridViewTaskInOutForApproval.TabIndex = 302;
            this.dataGridViewTaskInOutForApproval.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewTaskInOutForApproval.UseCustomBackColor = true;
            this.dataGridViewTaskInOutForApproval.UseCustomForeColor = true;
            this.dataGridViewTaskInOutForApproval.UseStyleColors = true;
            this.dataGridViewTaskInOutForApproval.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTaskInOutForApproval_CellContentClick);
            this.dataGridViewTaskInOutForApproval.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewTaskInOutForApproval_CellFormatting);
            this.dataGridViewTaskInOutForApproval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewTaskInOutForApproval_KeyDown);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(1169, 471);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 36);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApprove.Location = new System.Drawing.Point(1169, 246);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(102, 36);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseSelectable = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnDisapprove
            // 
            this.btnDisapprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisapprove.Location = new System.Drawing.Point(1169, 291);
            this.btnDisapprove.Name = "btnDisapprove";
            this.btnDisapprove.Size = new System.Drawing.Size(102, 36);
            this.btnDisapprove.TabIndex = 2;
            this.btnDisapprove.Text = "Disapprove";
            this.btnDisapprove.UseSelectable = true;
            this.btnDisapprove.Click += new System.EventHandler(this.btnDisapprove_Click);
            // 
            // btnTimeModify
            // 
            this.btnTimeModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimeModify.Location = new System.Drawing.Point(1169, 536);
            this.btnTimeModify.Name = "btnTimeModify";
            this.btnTimeModify.Size = new System.Drawing.Size(102, 36);
            this.btnTimeModify.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnTimeModify.TabIndex = 8;
            this.btnTimeModify.Text = "Modify Time";
            this.btnTimeModify.UseSelectable = true;
            this.btnTimeModify.UseStyleColors = true;
            this.btnTimeModify.Visible = false;
            this.btnTimeModify.Click += new System.EventHandler(this.btnTimeModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(1169, 336);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 36);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistory.Location = new System.Drawing.Point(1169, 153);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(102, 36);
            this.btnHistory.Style = MetroFramework.MetroColorStyle.Green;
            this.btnHistory.TabIndex = 7;
            this.btnHistory.Text = "History";
            this.btnHistory.UseSelectable = true;
            this.btnHistory.UseStyleColors = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // lblTaskIn
            // 
            this.lblTaskIn.AutoSize = true;
            this.lblTaskIn.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTaskIn.Location = new System.Drawing.Point(654, 69);
            this.lblTaskIn.Name = "lblTaskIn";
            this.lblTaskIn.Size = new System.Drawing.Size(69, 15);
            this.lblTaskIn.TabIndex = 318;
            this.lblTaskIn.Text = "Date Range:";
            this.lblTaskIn.UseCustomBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.Location = new System.Drawing.Point(1011, 60);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(48, 29);
            this.btnCheck.TabIndex = 14;
            this.btnCheck.Text = "Check";
            this.btnCheck.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnCheck.UseSelectable = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(872, 64);
            this.dateTimePickerTo.MinimumSize = new System.Drawing.Size(0, 25);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(119, 25);
            this.dateTimePickerTo.Style = MetroFramework.MetroColorStyle.Blue;
            this.dateTimePickerTo.TabIndex = 13;
            this.dateTimePickerTo.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dateTimePickerTo.UseCustomBackColor = true;
            this.dateTimePickerTo.UseCustomForeColor = true;
            this.dateTimePickerTo.UseStyleColors = true;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(729, 64);
            this.dateTimePickerFrom.MinimumSize = new System.Drawing.Size(0, 25);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(119, 25);
            this.dateTimePickerFrom.Style = MetroFramework.MetroColorStyle.Blue;
            this.dateTimePickerFrom.TabIndex = 12;
            this.dateTimePickerFrom.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dateTimePickerFrom.UseCustomBackColor = true;
            this.dateTimePickerFrom.UseCustomForeColor = true;
            this.dateTimePickerFrom.UseStyleColors = true;
            // 
            // lblTaskOut
            // 
            this.lblTaskOut.AutoSize = true;
            this.lblTaskOut.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskOut.ForeColor = System.Drawing.Color.Navy;
            this.lblTaskOut.Location = new System.Drawing.Point(854, 68);
            this.lblTaskOut.Name = "lblTaskOut";
            this.lblTaskOut.Size = new System.Drawing.Size(12, 16);
            this.lblTaskOut.TabIndex = 316;
            this.lblTaskOut.Text = "-";
            // 
            // cmbUserID
            // 
            // 
            // 
            // 
            this.cmbUserID.CustomButton.Image = null;
            this.cmbUserID.CustomButton.Location = new System.Drawing.Point(53, 2);
            this.cmbUserID.CustomButton.Name = "";
            this.cmbUserID.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.cmbUserID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.cmbUserID.CustomButton.TabIndex = 1;
            this.cmbUserID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cmbUserID.CustomButton.UseSelectable = true;
            this.cmbUserID.CustomButton.Visible = false;
            this.cmbUserID.Lines = new string[0];
            this.cmbUserID.Location = new System.Drawing.Point(177, 63);
            this.cmbUserID.MaxLength = 32767;
            this.cmbUserID.Name = "cmbUserID";
            this.cmbUserID.PasswordChar = '\0';
            this.cmbUserID.PromptText = "User ID";
            this.cmbUserID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cmbUserID.SelectedText = "";
            this.cmbUserID.SelectionLength = 0;
            this.cmbUserID.SelectionStart = 0;
            this.cmbUserID.ShortcutsEnabled = true;
            this.cmbUserID.Size = new System.Drawing.Size(75, 24);
            this.cmbUserID.TabIndex = 9;
            this.cmbUserID.UseSelectable = true;
            this.cmbUserID.WaterMark = "User ID";
            this.cmbUserID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbUserID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.cmbUserID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbUserID_KeyUp);
            // 
            // cmbPCPCode
            // 
            // 
            // 
            // 
            this.cmbPCPCode.CustomButton.Image = null;
            this.cmbPCPCode.CustomButton.Location = new System.Drawing.Point(108, 2);
            this.cmbPCPCode.CustomButton.Name = "";
            this.cmbPCPCode.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.cmbPCPCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.cmbPCPCode.CustomButton.TabIndex = 1;
            this.cmbPCPCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cmbPCPCode.CustomButton.UseSelectable = true;
            this.cmbPCPCode.CustomButton.Visible = false;
            this.cmbPCPCode.Lines = new string[0];
            this.cmbPCPCode.Location = new System.Drawing.Point(272, 63);
            this.cmbPCPCode.MaxLength = 32767;
            this.cmbPCPCode.Name = "cmbPCPCode";
            this.cmbPCPCode.PasswordChar = '\0';
            this.cmbPCPCode.PromptText = "Job Code";
            this.cmbPCPCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cmbPCPCode.SelectedText = "";
            this.cmbPCPCode.SelectionLength = 0;
            this.cmbPCPCode.SelectionStart = 0;
            this.cmbPCPCode.ShortcutsEnabled = true;
            this.cmbPCPCode.Size = new System.Drawing.Size(130, 24);
            this.cmbPCPCode.TabIndex = 10;
            this.cmbPCPCode.UseSelectable = true;
            this.cmbPCPCode.WaterMark = "Job Code";
            this.cmbPCPCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbPCPCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.cmbPCPCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbPCPCode_KeyUp);
            // 
            // lblMUID
            // 
            this.lblMUID.AutoSize = true;
            this.lblMUID.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblMUID.Location = new System.Drawing.Point(428, 19);
            this.lblMUID.Name = "lblMUID";
            this.lblMUID.Size = new System.Drawing.Size(36, 15);
            this.lblMUID.TabIndex = 325;
            this.lblMUID.Text = "MUID";
            this.lblMUID.Visible = false;
            // 
            // lblPIC
            // 
            this.lblPIC.AutoSize = true;
            this.lblPIC.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblPIC.Location = new System.Drawing.Point(396, 19);
            this.lblPIC.Name = "lblPIC";
            this.lblPIC.Size = new System.Drawing.Size(24, 15);
            this.lblPIC.TabIndex = 322;
            this.lblPIC.Text = "PIC";
            this.lblPIC.Visible = false;
            // 
            // cmbFileName
            // 
            // 
            // 
            // 
            this.cmbFileName.CustomButton.Image = null;
            this.cmbFileName.CustomButton.Location = new System.Drawing.Point(108, 2);
            this.cmbFileName.CustomButton.Name = "";
            this.cmbFileName.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.cmbFileName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.cmbFileName.CustomButton.TabIndex = 1;
            this.cmbFileName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cmbFileName.CustomButton.UseSelectable = true;
            this.cmbFileName.CustomButton.Visible = false;
            this.cmbFileName.Lines = new string[0];
            this.cmbFileName.Location = new System.Drawing.Point(422, 63);
            this.cmbFileName.MaxLength = 32767;
            this.cmbFileName.Name = "cmbFileName";
            this.cmbFileName.PasswordChar = '\0';
            this.cmbFileName.PromptText = "File Name";
            this.cmbFileName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cmbFileName.SelectedText = "";
            this.cmbFileName.SelectionLength = 0;
            this.cmbFileName.SelectionStart = 0;
            this.cmbFileName.ShortcutsEnabled = true;
            this.cmbFileName.Size = new System.Drawing.Size(130, 24);
            this.cmbFileName.TabIndex = 11;
            this.cmbFileName.UseSelectable = true;
            this.cmbFileName.WaterMark = "File Name";
            this.cmbFileName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbFileName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.cmbFileName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbFileName_KeyUp);
            // 
            // cmbMUID1
            // 
            this.cmbMUID1.FormattingEnabled = true;
            this.cmbMUID1.ItemHeight = 23;
            this.cmbMUID1.Location = new System.Drawing.Point(68, 60);
            this.cmbMUID1.Name = "cmbMUID1";
            this.cmbMUID1.PromptText = "Manager";
            this.cmbMUID1.Size = new System.Drawing.Size(89, 29);
            this.cmbMUID1.TabIndex = 8;
            this.cmbMUID1.UseSelectable = true;
            this.cmbMUID1.SelectedIndexChanged += new System.EventHandler(this.cmbMUID1_SelectedIndexChanged);
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(1114, 62);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(38, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 304;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // pBoxRefersh
            // 
            this.pBoxRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxRefersh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxRefersh.Image")));
            this.pBoxRefersh.Location = new System.Drawing.Point(13, 69);
            this.pBoxRefersh.Name = "pBoxRefersh";
            this.pBoxRefersh.Size = new System.Drawing.Size(22, 20);
            this.pBoxRefersh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRefersh.TabIndex = 303;
            this.pBoxRefersh.TabStop = false;
            this.pBoxRefersh.WaitOnLoad = true;
            this.pBoxRefersh.Click += new System.EventHandler(this.pBoxRefersh_Click);
            // 
            // btnModify
            // 
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.Location = new System.Drawing.Point(1169, 381);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(102, 36);
            this.btnModify.TabIndex = 4;
            this.btnModify.Text = "Modify";
            this.btnModify.UseSelectable = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // frm_TaskInOutApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 705);
            this.ControlBox = false;
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.cmbMUID1);
            this.Controls.Add(this.cmbFileName);
            this.Controls.Add(this.lblMUID);
            this.Controls.Add(this.lblPIC);
            this.Controls.Add(this.cmbPCPCode);
            this.Controls.Add(this.cmbUserID);
            this.Controls.Add(this.lblTaskIn);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.lblTaskOut);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnTimeModify);
            this.Controls.Add(this.btnDisapprove);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.pBoxExportExcel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pBoxRefersh);
            this.Controls.Add(this.dataGridViewTaskInOutForApproval);
            this.Controls.Add(this.btnExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "frm_TaskInOutApproval";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frm_TaskInOutApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskInOutForApproval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
        private MetroFramework.Controls.MetroButton btnClear;
        private System.Windows.Forms.PictureBox pBoxRefersh;
        private MetroFramework.Controls.MetroGrid dataGridViewTaskInOutForApproval;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnApprove;
        private MetroFramework.Controls.MetroButton btnDisapprove;
        private MetroFramework.Controls.MetroButton btnTimeModify;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnHistory;
        private MetroFramework.Controls.MetroLabel lblTaskIn;
        private MetroFramework.Controls.MetroButton btnCheck;
        private MetroFramework.Controls.MetroDateTime dateTimePickerTo;
        private MetroFramework.Controls.MetroDateTime dateTimePickerFrom;
        private System.Windows.Forms.Label lblTaskOut;
        private MetroFramework.Controls.MetroTextBox cmbUserID;
        private MetroFramework.Controls.MetroTextBox cmbPCPCode;
        private MetroFramework.Controls.MetroLabel lblMUID;
        private MetroFramework.Controls.MetroLabel lblPIC;
        private MetroFramework.Controls.MetroTextBox cmbFileName;
        private MetroFramework.Controls.MetroComboBox cmbMUID1;
        private MetroFramework.Controls.MetroButton btnModify;
    }
}