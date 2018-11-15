namespace CITITO
{
    partial class frm_IDLETask
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_IDLETask));
            this.lblManagerUIDToFill = new MetroFramework.Controls.MetroLabel();
            this.lblTimeToFill = new MetroFramework.Controls.MetroLabel();
            this.lblManagerNameToFill = new MetroFramework.Controls.MetroLabel();
            this.lblUIDToFill = new MetroFramework.Controls.MetroLabel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnFileTask = new MetroFramework.Controls.MetroButton();
            this.dataGridViewIDLERecord = new MetroFramework.Controls.MetroGrid();
            this.cmbProject = new MetroFramework.Controls.MetroComboBox();
            this.lblProject = new MetroFramework.Controls.MetroLabel();
            this.lblTaskIn = new MetroFramework.Controls.MetroLabel();
            this.lblTaskOut = new MetroFramework.Controls.MetroLabel();
            this.cmbReason = new MetroFramework.Controls.MetroComboBox();
            this.lblReason = new MetroFramework.Controls.MetroLabel();
            this.txtIDLEHours = new MetroFramework.Controls.MetroTextBox();
            this.lblIDLEHours = new MetroFramework.Controls.MetroLabel();
            this.lblIDLEMessage = new MetroFramework.Controls.MetroLabel();
            this.dateTimePickerTaskIn = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTaskOut = new System.Windows.Forms.DateTimePicker();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.pBoxRefersh = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtRemark = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblLength = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIDLERecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).BeginInit();
            this.SuspendLayout();
            // 
            // lblManagerUIDToFill
            // 
            this.lblManagerUIDToFill.AutoSize = true;
            this.lblManagerUIDToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblManagerUIDToFill.Location = new System.Drawing.Point(602, 23);
            this.lblManagerUIDToFill.Name = "lblManagerUIDToFill";
            this.lblManagerUIDToFill.Size = new System.Drawing.Size(36, 15);
            this.lblManagerUIDToFill.TabIndex = 266;
            this.lblManagerUIDToFill.Text = "MUID";
            this.lblManagerUIDToFill.Visible = false;
            // 
            // lblTimeToFill
            // 
            this.lblTimeToFill.AutoSize = true;
            this.lblTimeToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTimeToFill.Location = new System.Drawing.Point(736, 23);
            this.lblTimeToFill.Name = "lblTimeToFill";
            this.lblTimeToFill.Size = new System.Drawing.Size(31, 15);
            this.lblTimeToFill.TabIndex = 265;
            this.lblTimeToFill.Text = "Time";
            this.lblTimeToFill.Visible = false;
            // 
            // lblManagerNameToFill
            // 
            this.lblManagerNameToFill.AutoSize = true;
            this.lblManagerNameToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblManagerNameToFill.Location = new System.Drawing.Point(644, 23);
            this.lblManagerNameToFill.Name = "lblManagerNameToFill";
            this.lblManagerNameToFill.Size = new System.Drawing.Size(86, 15);
            this.lblManagerNameToFill.TabIndex = 264;
            this.lblManagerNameToFill.Text = "NamagerName";
            this.lblManagerNameToFill.Visible = false;
            // 
            // lblUIDToFill
            // 
            this.lblUIDToFill.AutoSize = true;
            this.lblUIDToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUIDToFill.Location = new System.Drawing.Point(570, 23);
            this.lblUIDToFill.Name = "lblUIDToFill";
            this.lblUIDToFill.Size = new System.Drawing.Size(26, 15);
            this.lblUIDToFill.TabIndex = 263;
            this.lblUIDToFill.Text = "UID";
            this.lblUIDToFill.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(933, 208);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 36);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(933, 158);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 36);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFileTask
            // 
            this.btnFileTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFileTask.Location = new System.Drawing.Point(933, 108);
            this.btnFileTask.Name = "btnFileTask";
            this.btnFileTask.Size = new System.Drawing.Size(102, 36);
            this.btnFileTask.TabIndex = 6;
            this.btnFileTask.Text = "File Task";
            this.btnFileTask.UseSelectable = true;
            this.btnFileTask.Click += new System.EventHandler(this.btnFileTask_Click);
            // 
            // dataGridViewIDLERecord
            // 
            this.dataGridViewIDLERecord.AllowUserToAddRows = false;
            this.dataGridViewIDLERecord.AllowUserToDeleteRows = false;
            this.dataGridViewIDLERecord.AllowUserToResizeRows = false;
            this.dataGridViewIDLERecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIDLERecord.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewIDLERecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewIDLERecord.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewIDLERecord.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewIDLERecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewIDLERecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIDLERecord.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewIDLERecord.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewIDLERecord.EnableHeadersVisualStyles = false;
            this.dataGridViewIDLERecord.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewIDLERecord.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewIDLERecord.Location = new System.Drawing.Point(20, 323);
            this.dataGridViewIDLERecord.MultiSelect = false;
            this.dataGridViewIDLERecord.Name = "dataGridViewIDLERecord";
            this.dataGridViewIDLERecord.ReadOnly = true;
            this.dataGridViewIDLERecord.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewIDLERecord.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewIDLERecord.RowHeadersVisible = false;
            this.dataGridViewIDLERecord.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewIDLERecord.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewIDLERecord.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewIDLERecord.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewIDLERecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIDLERecord.Size = new System.Drawing.Size(1015, 270);
            this.dataGridViewIDLERecord.Style = MetroFramework.MetroColorStyle.Blue;
            this.dataGridViewIDLERecord.TabIndex = 268;
            this.dataGridViewIDLERecord.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewIDLERecord.UseCustomBackColor = true;
            this.dataGridViewIDLERecord.UseCustomForeColor = true;
            this.dataGridViewIDLERecord.UseStyleColors = true;
            this.dataGridViewIDLERecord.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewIDLERecord_CellFormatting);
            // 
            // cmbProject
            // 
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.ItemHeight = 23;
            this.cmbProject.Location = new System.Drawing.Point(136, 24);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(160, 29);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.UseSelectable = true;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(70, 34);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(57, 19);
            this.lblProject.TabIndex = 286;
            this.lblProject.Text = "Project: ";
            // 
            // lblTaskIn
            // 
            this.lblTaskIn.AutoSize = true;
            this.lblTaskIn.Location = new System.Drawing.Point(73, 90);
            this.lblTaskIn.Name = "lblTaskIn";
            this.lblTaskIn.Size = new System.Drawing.Size(49, 19);
            this.lblTaskIn.TabIndex = 289;
            this.lblTaskIn.Text = "Task In:";
            // 
            // lblTaskOut
            // 
            this.lblTaskOut.AutoSize = true;
            this.lblTaskOut.Location = new System.Drawing.Point(372, 90);
            this.lblTaskOut.Name = "lblTaskOut";
            this.lblTaskOut.Size = new System.Drawing.Size(61, 19);
            this.lblTaskOut.TabIndex = 290;
            this.lblTaskOut.Text = "Task Out:";
            // 
            // cmbReason
            // 
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.ItemHeight = 23;
            this.cmbReason.Location = new System.Drawing.Point(136, 117);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(302, 29);
            this.cmbReason.TabIndex = 4;
            this.cmbReason.UseSelectable = true;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(68, 125);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(54, 19);
            this.lblReason.TabIndex = 292;
            this.lblReason.Text = "Reason:";
            // 
            // txtIDLEHours
            // 
            // 
            // 
            // 
            this.txtIDLEHours.CustomButton.Image = null;
            this.txtIDLEHours.CustomButton.Location = new System.Drawing.Point(82, 1);
            this.txtIDLEHours.CustomButton.Name = "";
            this.txtIDLEHours.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtIDLEHours.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIDLEHours.CustomButton.TabIndex = 1;
            this.txtIDLEHours.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIDLEHours.CustomButton.UseSelectable = true;
            this.txtIDLEHours.CustomButton.Visible = false;
            this.txtIDLEHours.Enabled = false;
            this.txtIDLEHours.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtIDLEHours.Lines = new string[0];
            this.txtIDLEHours.Location = new System.Drawing.Point(136, 155);
            this.txtIDLEHours.MaxLength = 32767;
            this.txtIDLEHours.Name = "txtIDLEHours";
            this.txtIDLEHours.PasswordChar = '\0';
            this.txtIDLEHours.ReadOnly = true;
            this.txtIDLEHours.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIDLEHours.SelectedText = "";
            this.txtIDLEHours.SelectionLength = 0;
            this.txtIDLEHours.SelectionStart = 0;
            this.txtIDLEHours.ShortcutsEnabled = true;
            this.txtIDLEHours.Size = new System.Drawing.Size(106, 25);
            this.txtIDLEHours.TabIndex = 5;
            this.txtIDLEHours.UseSelectable = true;
            this.txtIDLEHours.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIDLEHours.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtIDLEHours.TextChanged += new System.EventHandler(this.txtIDLEHours_TextChanged);
            // 
            // lblIDLEHours
            // 
            this.lblIDLEHours.AutoSize = true;
            this.lblIDLEHours.Location = new System.Drawing.Point(47, 161);
            this.lblIDLEHours.Name = "lblIDLEHours";
            this.lblIDLEHours.Size = new System.Drawing.Size(75, 19);
            this.lblIDLEHours.TabIndex = 294;
            this.lblIDLEHours.Text = "IDLE Hours:";
            // 
            // lblIDLEMessage
            // 
            this.lblIDLEMessage.AutoSize = true;
            this.lblIDLEMessage.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblIDLEMessage.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblIDLEMessage.Location = new System.Drawing.Point(227, 59);
            this.lblIDLEMessage.Name = "lblIDLEMessage";
            this.lblIDLEMessage.Size = new System.Drawing.Size(12, 15);
            this.lblIDLEMessage.Style = MetroFramework.MetroColorStyle.Red;
            this.lblIDLEMessage.TabIndex = 295;
            this.lblIDLEMessage.Text = "-";
            this.lblIDLEMessage.UseStyleColors = true;
            this.lblIDLEMessage.Visible = false;
            // 
            // dateTimePickerTaskIn
            // 
            this.dateTimePickerTaskIn.CalendarFont = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerTaskIn.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePickerTaskIn.Font = new System.Drawing.Font("Segoe UI", 10.9F);
            this.dateTimePickerTaskIn.Location = new System.Drawing.Point(136, 82);
            this.dateTimePickerTaskIn.MinimumSize = new System.Drawing.Size(4, 29);
            this.dateTimePickerTaskIn.Name = "dateTimePickerTaskIn";
            this.dateTimePickerTaskIn.Size = new System.Drawing.Size(212, 29);
            this.dateTimePickerTaskIn.TabIndex = 2;
            this.dateTimePickerTaskIn.ValueChanged += new System.EventHandler(this.dateTimePickerTaskIn_ValueChanged);
            // 
            // dateTimePickerTaskOut
            // 
            this.dateTimePickerTaskOut.CalendarFont = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerTaskOut.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePickerTaskOut.Font = new System.Drawing.Font("Segoe UI", 10.9F);
            this.dateTimePickerTaskOut.Location = new System.Drawing.Point(439, 80);
            this.dateTimePickerTaskOut.MinimumSize = new System.Drawing.Size(4, 29);
            this.dateTimePickerTaskOut.Name = "dateTimePickerTaskOut";
            this.dateTimePickerTaskOut.Size = new System.Drawing.Size(212, 29);
            this.dateTimePickerTaskOut.TabIndex = 3;
            this.dateTimePickerTaskOut.ValueChanged += new System.EventHandler(this.dateTimePickerTaskOut_ValueChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(976, 272);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 297;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(997, 290);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(35, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 296;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // pBoxRefersh
            // 
            this.pBoxRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxRefersh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxRefersh.Image")));
            this.pBoxRefersh.Location = new System.Drawing.Point(20, 297);
            this.pBoxRefersh.Name = "pBoxRefersh";
            this.pBoxRefersh.Size = new System.Drawing.Size(22, 20);
            this.pBoxRefersh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRefersh.TabIndex = 267;
            this.pBoxRefersh.TabStop = false;
            this.pBoxRefersh.WaitOnLoad = true;
            this.pBoxRefersh.Click += new System.EventHandler(this.pBoxRefersh_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(65, 204);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(57, 19);
            this.metroLabel1.TabIndex = 298;
            this.metroLabel1.Text = "Remark:";
            // 
            // txtRemark
            // 
            // 
            // 
            // 
            this.txtRemark.CustomButton.Image = null;
            this.txtRemark.CustomButton.Location = new System.Drawing.Point(264, 2);
            this.txtRemark.CustomButton.Name = "";
            this.txtRemark.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.txtRemark.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRemark.CustomButton.TabIndex = 1;
            this.txtRemark.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRemark.CustomButton.UseSelectable = true;
            this.txtRemark.CustomButton.Visible = false;
            this.txtRemark.Lines = new string[0];
            this.txtRemark.Location = new System.Drawing.Point(136, 204);
            this.txtRemark.MaxLength = 20;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PasswordChar = '\0';
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRemark.SelectedText = "";
            this.txtRemark.SelectionLength = 0;
            this.txtRemark.SelectionStart = 0;
            this.txtRemark.ShortcutsEnabled = true;
            this.txtRemark.Size = new System.Drawing.Size(302, 40);
            this.txtRemark.TabIndex = 299;
            this.txtRemark.UseSelectable = true;
            this.txtRemark.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRemark.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtRemark.TextChanged += new System.EventHandler(this.txtRemark_TextChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(63, 229);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(59, 15);
            this.metroLabel2.TabIndex = 300;
            this.metroLabel2.Text = "(optional)";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblLength.Location = new System.Drawing.Point(344, 247);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(97, 15);
            this.lblLength.Style = MetroFramework.MetroColorStyle.Silver;
            this.lblLength.TabIndex = 301;
            this.lblLength.Text = "(20 characters left)";
            this.lblLength.UseStyleColors = true;
            // 
            // frm_IDLETask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 613);
            this.ControlBox = false;
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.pBoxExportExcel);
            this.Controls.Add(this.dateTimePickerTaskOut);
            this.Controls.Add(this.dateTimePickerTaskIn);
            this.Controls.Add(this.lblIDLEMessage);
            this.Controls.Add(this.txtIDLEHours);
            this.Controls.Add(this.lblIDLEHours);
            this.Controls.Add(this.cmbReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblTaskOut);
            this.Controls.Add(this.lblTaskIn);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.dataGridViewIDLERecord);
            this.Controls.Add(this.pBoxRefersh);
            this.Controls.Add(this.lblManagerUIDToFill);
            this.Controls.Add(this.lblTimeToFill);
            this.Controls.Add(this.lblManagerNameToFill);
            this.Controls.Add(this.lblUIDToFill);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFileTask);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Movable = false;
            this.Name = "frm_IDLETask";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Load += new System.EventHandler(this.frm_IDLETask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIDLERecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblManagerUIDToFill;
        private MetroFramework.Controls.MetroLabel lblTimeToFill;
        private MetroFramework.Controls.MetroLabel lblManagerNameToFill;
        private MetroFramework.Controls.MetroLabel lblUIDToFill;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnFileTask;
        private MetroFramework.Controls.MetroGrid dataGridViewIDLERecord;
        private System.Windows.Forms.PictureBox pBoxRefersh;
        private MetroFramework.Controls.MetroComboBox cmbProject;
        private MetroFramework.Controls.MetroLabel lblProject;
        private MetroFramework.Controls.MetroLabel lblTaskIn;
        private MetroFramework.Controls.MetroLabel lblTaskOut;
        private MetroFramework.Controls.MetroComboBox cmbReason;
        private MetroFramework.Controls.MetroLabel lblReason;
        private MetroFramework.Controls.MetroTextBox txtIDLEHours;
        private MetroFramework.Controls.MetroLabel lblIDLEHours;
        private MetroFramework.Controls.MetroLabel lblIDLEMessage;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskOut;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtRemark;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblLength;
    }
}