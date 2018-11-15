namespace CITITO
{
    partial class frm_TaskInOut
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TaskInOut));
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.lblManagerUIDToFill = new MetroFramework.Controls.MetroLabel();
            this.lblTimeToFill = new MetroFramework.Controls.MetroLabel();
            this.lblManagerNameToFill = new MetroFramework.Controls.MetroLabel();
            this.lblUIDToFill = new MetroFramework.Controls.MetroLabel();
            this.txtFileName = new MetroFramework.Controls.MetroTextBox();
            this.lblFileName = new MetroFramework.Controls.MetroLabel();
            this.lblJobCode = new MetroFramework.Controls.MetroLabel();
            this.txtJobCode = new MetroFramework.Controls.MetroTextBox();
            this.lblShipment = new MetroFramework.Controls.MetroLabel();
            this.lblTaskCode = new MetroFramework.Controls.MetroLabel();
            this.cmbtaskCode = new MetroFramework.Controls.MetroComboBox();
            this.lblFileSize = new MetroFramework.Controls.MetroLabel();
            this.numericUpDownFileSize = new System.Windows.Forms.NumericUpDown();
            this.lblPagesKB = new MetroFramework.Controls.MetroLabel();
            this.lblTaskIn = new MetroFramework.Controls.MetroLabel();
            this.dateTimePickerTaskIn = new MetroFramework.Controls.MetroDateTime();
            this.dateTimePickerTaskOut = new MetroFramework.Controls.MetroDateTime();
            this.cmbTaskStatus = new MetroFramework.Controls.MetroComboBox();
            this.lblTaskStatus = new MetroFramework.Controls.MetroLabel();
            this.dataGridViewTaskInOut = new MetroFramework.Controls.MetroGrid();
            this.btnTaskIn = new MetroFramework.Controls.MetroButton();
            this.btnTaskOut = new MetroFramework.Controls.MetroButton();
            this.lblTaskInMessage = new MetroFramework.Controls.MetroLabel();
            this.pBoxRefersh = new System.Windows.Forms.PictureBox();
            this.cmbProject = new MetroFramework.Controls.MetroComboBox();
            this.lblProject = new MetroFramework.Controls.MetroLabel();
            this.lblTaskPendingMessage = new MetroFramework.Controls.MetroLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.lblElapseTime = new MetroFramework.Controls.MetroLabel();
            this.lblElapseTimeToFill = new MetroFramework.Controls.MetroLabel();
            this.lblBytePendingMessage = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.cmbShipment = new System.Windows.Forms.ComboBox();
            this.tglModified = new MetroFramework.Controls.MetroCheckBox();
            this.btnGo = new MetroFramework.Controls.MetroButton();
            this.dash = new MetroFramework.Controls.MetroLabel();
            this.metroDateTime1To = new MetroFramework.Controls.MetroDateTime();
            this.metroDateTime1From = new MetroFramework.Controls.MetroDateTime();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskInOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(933, 195);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 36);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblManagerUIDToFill
            // 
            this.lblManagerUIDToFill.AutoSize = true;
            this.lblManagerUIDToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblManagerUIDToFill.Location = new System.Drawing.Point(620, 23);
            this.lblManagerUIDToFill.Name = "lblManagerUIDToFill";
            this.lblManagerUIDToFill.Size = new System.Drawing.Size(36, 15);
            this.lblManagerUIDToFill.TabIndex = 259;
            this.lblManagerUIDToFill.Text = "MUID";
            this.lblManagerUIDToFill.Visible = false;
            // 
            // lblTimeToFill
            // 
            this.lblTimeToFill.AutoSize = true;
            this.lblTimeToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTimeToFill.Location = new System.Drawing.Point(754, 23);
            this.lblTimeToFill.Name = "lblTimeToFill";
            this.lblTimeToFill.Size = new System.Drawing.Size(31, 15);
            this.lblTimeToFill.TabIndex = 258;
            this.lblTimeToFill.Text = "Time";
            this.lblTimeToFill.Visible = false;
            // 
            // lblManagerNameToFill
            // 
            this.lblManagerNameToFill.AutoSize = true;
            this.lblManagerNameToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblManagerNameToFill.Location = new System.Drawing.Point(662, 23);
            this.lblManagerNameToFill.Name = "lblManagerNameToFill";
            this.lblManagerNameToFill.Size = new System.Drawing.Size(86, 15);
            this.lblManagerNameToFill.TabIndex = 257;
            this.lblManagerNameToFill.Text = "NamagerName";
            this.lblManagerNameToFill.Visible = false;
            // 
            // lblUIDToFill
            // 
            this.lblUIDToFill.AutoSize = true;
            this.lblUIDToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUIDToFill.Location = new System.Drawing.Point(588, 23);
            this.lblUIDToFill.Name = "lblUIDToFill";
            this.lblUIDToFill.Size = new System.Drawing.Size(26, 15);
            this.lblUIDToFill.TabIndex = 256;
            this.lblUIDToFill.Text = "UID";
            this.lblUIDToFill.Visible = false;
            // 
            // txtFileName
            // 
            // 
            // 
            // 
            this.txtFileName.CustomButton.Image = null;
            this.txtFileName.CustomButton.Location = new System.Drawing.Point(291, 1);
            this.txtFileName.CustomButton.Name = "";
            this.txtFileName.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtFileName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFileName.CustomButton.TabIndex = 1;
            this.txtFileName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFileName.CustomButton.UseSelectable = true;
            this.txtFileName.CustomButton.Visible = false;
            this.txtFileName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtFileName.Lines = new string[0];
            this.txtFileName.Location = new System.Drawing.Point(136, 95);
            this.txtFileName.MaxLength = 32767;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.PasswordChar = '\0';
            this.txtFileName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFileName.SelectedText = "";
            this.txtFileName.SelectionLength = 0;
            this.txtFileName.SelectionStart = 0;
            this.txtFileName.ShortcutsEnabled = true;
            this.txtFileName.Size = new System.Drawing.Size(315, 25);
            this.txtFileName.TabIndex = 3;
            this.txtFileName.UseSelectable = true;
            this.txtFileName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFileName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtFileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFileName_KeyDown);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(60, 101);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(72, 19);
            this.lblFileName.TabIndex = 261;
            this.lblFileName.Text = "File Name:";
            // 
            // lblJobCode
            // 
            this.lblJobCode.AutoSize = true;
            this.lblJobCode.Location = new System.Drawing.Point(66, 133);
            this.lblJobCode.Name = "lblJobCode";
            this.lblJobCode.Size = new System.Drawing.Size(69, 19);
            this.lblJobCode.TabIndex = 262;
            this.lblJobCode.Text = "Job Code:";
            // 
            // txtJobCode
            // 
            // 
            // 
            // 
            this.txtJobCode.CustomButton.Image = null;
            this.txtJobCode.CustomButton.Location = new System.Drawing.Point(137, 1);
            this.txtJobCode.CustomButton.Name = "";
            this.txtJobCode.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtJobCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtJobCode.CustomButton.TabIndex = 1;
            this.txtJobCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtJobCode.CustomButton.UseSelectable = true;
            this.txtJobCode.CustomButton.Visible = false;
            this.txtJobCode.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtJobCode.Lines = new string[0];
            this.txtJobCode.Location = new System.Drawing.Point(136, 127);
            this.txtJobCode.MaxLength = 32767;
            this.txtJobCode.Name = "txtJobCode";
            this.txtJobCode.PasswordChar = '\0';
            this.txtJobCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtJobCode.SelectedText = "";
            this.txtJobCode.SelectionLength = 0;
            this.txtJobCode.SelectionStart = 0;
            this.txtJobCode.ShortcutsEnabled = true;
            this.txtJobCode.Size = new System.Drawing.Size(161, 25);
            this.txtJobCode.TabIndex = 4;
            this.txtJobCode.UseSelectable = true;
            this.txtJobCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtJobCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtJobCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobCode_KeyDown);
            // 
            // lblShipment
            // 
            this.lblShipment.AutoSize = true;
            this.lblShipment.Location = new System.Drawing.Point(65, 69);
            this.lblShipment.Name = "lblShipment";
            this.lblShipment.Size = new System.Drawing.Size(67, 19);
            this.lblShipment.TabIndex = 265;
            this.lblShipment.Text = "Shipment:";
            // 
            // lblTaskCode
            // 
            this.lblTaskCode.AutoSize = true;
            this.lblTaskCode.Location = new System.Drawing.Point(60, 168);
            this.lblTaskCode.Name = "lblTaskCode";
            this.lblTaskCode.Size = new System.Drawing.Size(71, 19);
            this.lblTaskCode.TabIndex = 266;
            this.lblTaskCode.Text = "Task Code:";
            // 
            // cmbtaskCode
            // 
            this.cmbtaskCode.FormattingEnabled = true;
            this.cmbtaskCode.ItemHeight = 23;
            this.cmbtaskCode.Location = new System.Drawing.Point(137, 160);
            this.cmbtaskCode.Name = "cmbtaskCode";
            this.cmbtaskCode.Size = new System.Drawing.Size(314, 29);
            this.cmbtaskCode.TabIndex = 5;
            this.cmbtaskCode.UseSelectable = true;
            this.cmbtaskCode.SelectedIndexChanged += new System.EventHandler(this.cmbtaskCode_SelectedIndexChanged);
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(71, 298);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(59, 19);
            this.lblFileSize.TabIndex = 268;
            this.lblFileSize.Text = "File Size:";
            // 
            // numericUpDownFileSize
            // 
            this.numericUpDownFileSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownFileSize.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownFileSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownFileSize.Location = new System.Drawing.Point(136, 288);
            this.numericUpDownFileSize.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.numericUpDownFileSize.Name = "numericUpDownFileSize";
            this.numericUpDownFileSize.Size = new System.Drawing.Size(160, 29);
            this.numericUpDownFileSize.TabIndex = 11;
            this.numericUpDownFileSize.ThousandsSeparator = true;
            // 
            // lblPagesKB
            // 
            this.lblPagesKB.AutoSize = true;
            this.lblPagesKB.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblPagesKB.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPagesKB.Location = new System.Drawing.Point(302, 296);
            this.lblPagesKB.Name = "lblPagesKB";
            this.lblPagesKB.Size = new System.Drawing.Size(60, 15);
            this.lblPagesKB.TabIndex = 270;
            this.lblPagesKB.Text = "Pages/KB";
            // 
            // lblTaskIn
            // 
            this.lblTaskIn.AutoSize = true;
            this.lblTaskIn.Location = new System.Drawing.Point(54, 223);
            this.lblTaskIn.Name = "lblTaskIn";
            this.lblTaskIn.Size = new System.Drawing.Size(76, 19);
            this.lblTaskIn.TabIndex = 271;
            this.lblTaskIn.Text = "Task In/Out:";
            // 
            // dateTimePickerTaskIn
            // 
            this.dateTimePickerTaskIn.AllowDrop = true;
            this.dateTimePickerTaskIn.Location = new System.Drawing.Point(136, 214);
            this.dateTimePickerTaskIn.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTimePickerTaskIn.Name = "dateTimePickerTaskIn";
            this.dateTimePickerTaskIn.Size = new System.Drawing.Size(212, 29);
            this.dateTimePickerTaskIn.TabIndex = 6;
            // 
            // dateTimePickerTaskOut
            // 
            this.dateTimePickerTaskOut.Location = new System.Drawing.Point(457, 214);
            this.dateTimePickerTaskOut.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTimePickerTaskOut.Name = "dateTimePickerTaskOut";
            this.dateTimePickerTaskOut.Size = new System.Drawing.Size(212, 29);
            this.dateTimePickerTaskOut.TabIndex = 8;
            // 
            // cmbTaskStatus
            // 
            this.cmbTaskStatus.FormattingEnabled = true;
            this.cmbTaskStatus.ItemHeight = 23;
            this.cmbTaskStatus.Items.AddRange(new object[] {
            "Pending",
            "Done",
            "On Hold"});
            this.cmbTaskStatus.Location = new System.Drawing.Point(136, 251);
            this.cmbTaskStatus.Name = "cmbTaskStatus";
            this.cmbTaskStatus.Size = new System.Drawing.Size(161, 29);
            this.cmbTaskStatus.TabIndex = 10;
            this.cmbTaskStatus.UseSelectable = true;
            this.cmbTaskStatus.SelectedIndexChanged += new System.EventHandler(this.cmbTaskStatus_SelectedIndexChanged);
            // 
            // lblTaskStatus
            // 
            this.lblTaskStatus.AutoSize = true;
            this.lblTaskStatus.Location = new System.Drawing.Point(57, 261);
            this.lblTaskStatus.Name = "lblTaskStatus";
            this.lblTaskStatus.Size = new System.Drawing.Size(73, 19);
            this.lblTaskStatus.TabIndex = 276;
            this.lblTaskStatus.Text = "Task Status:";
            // 
            // dataGridViewTaskInOut
            // 
            this.dataGridViewTaskInOut.AllowUserToAddRows = false;
            this.dataGridViewTaskInOut.AllowUserToDeleteRows = false;
            this.dataGridViewTaskInOut.AllowUserToResizeRows = false;
            this.dataGridViewTaskInOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewTaskInOut.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTaskInOut.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTaskInOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTaskInOut.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewTaskInOut.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTaskInOut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTaskInOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaskInOut.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTaskInOut.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTaskInOut.EnableHeadersVisualStyles = false;
            this.dataGridViewTaskInOut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewTaskInOut.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTaskInOut.Location = new System.Drawing.Point(17, 340);
            this.dataGridViewTaskInOut.MultiSelect = false;
            this.dataGridViewTaskInOut.Name = "dataGridViewTaskInOut";
            this.dataGridViewTaskInOut.ReadOnly = true;
            this.dataGridViewTaskInOut.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTaskInOut.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTaskInOut.RowHeadersVisible = false;
            this.dataGridViewTaskInOut.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTaskInOut.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewTaskInOut.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewTaskInOut.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTaskInOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTaskInOut.Size = new System.Drawing.Size(1018, 257);
            this.dataGridViewTaskInOut.Style = MetroFramework.MetroColorStyle.Teal;
            this.dataGridViewTaskInOut.TabIndex = 14;
            this.dataGridViewTaskInOut.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewTaskInOut.UseCustomBackColor = true;
            this.dataGridViewTaskInOut.UseCustomForeColor = true;
            this.dataGridViewTaskInOut.UseStyleColors = true;
            this.dataGridViewTaskInOut.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewTaskInOut_CellFormatting);
            this.dataGridViewTaskInOut.Click += new System.EventHandler(this.dataGridViewTaskInOut_Click);
            // 
            // btnTaskIn
            // 
            this.btnTaskIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskIn.Location = new System.Drawing.Point(354, 214);
            this.btnTaskIn.Name = "btnTaskIn";
            this.btnTaskIn.Size = new System.Drawing.Size(55, 29);
            this.btnTaskIn.TabIndex = 7;
            this.btnTaskIn.Text = "Task In";
            this.btnTaskIn.UseSelectable = true;
            this.btnTaskIn.Click += new System.EventHandler(this.btnTaskIn_Click);
            // 
            // btnTaskOut
            // 
            this.btnTaskOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskOut.Location = new System.Drawing.Point(675, 214);
            this.btnTaskOut.Name = "btnTaskOut";
            this.btnTaskOut.Size = new System.Drawing.Size(55, 29);
            this.btnTaskOut.TabIndex = 9;
            this.btnTaskOut.Text = "Task Out";
            this.btnTaskOut.UseSelectable = true;
            this.btnTaskOut.Click += new System.EventHandler(this.btnTaskOut_Click);
            // 
            // lblTaskInMessage
            // 
            this.lblTaskInMessage.AutoSize = true;
            this.lblTaskInMessage.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTaskInMessage.Location = new System.Drawing.Point(210, 196);
            this.lblTaskInMessage.Name = "lblTaskInMessage";
            this.lblTaskInMessage.Size = new System.Drawing.Size(12, 15);
            this.lblTaskInMessage.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTaskInMessage.TabIndex = 280;
            this.lblTaskInMessage.Text = "-";
            this.lblTaskInMessage.UseStyleColors = true;
            this.lblTaskInMessage.Visible = false;
            // 
            // pBoxRefersh
            // 
            this.pBoxRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxRefersh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxRefersh.Image")));
            this.pBoxRefersh.Location = new System.Drawing.Point(17, 314);
            this.pBoxRefersh.Name = "pBoxRefersh";
            this.pBoxRefersh.Size = new System.Drawing.Size(22, 20);
            this.pBoxRefersh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRefersh.TabIndex = 282;
            this.pBoxRefersh.TabStop = false;
            this.pBoxRefersh.WaitOnLoad = true;
            this.pBoxRefersh.Click += new System.EventHandler(this.pBoxRefersh_Click);
            // 
            // cmbProject
            // 
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.ItemHeight = 23;
            this.cmbProject.Location = new System.Drawing.Point(136, 23);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(160, 29);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.UseSelectable = true;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(73, 33);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(57, 19);
            this.lblProject.TabIndex = 284;
            this.lblProject.Text = "Project: ";
            // 
            // lblTaskPendingMessage
            // 
            this.lblTaskPendingMessage.AutoSize = true;
            this.lblTaskPendingMessage.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTaskPendingMessage.Location = new System.Drawing.Point(457, 168);
            this.lblTaskPendingMessage.Name = "lblTaskPendingMessage";
            this.lblTaskPendingMessage.Size = new System.Drawing.Size(12, 15);
            this.lblTaskPendingMessage.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTaskPendingMessage.TabIndex = 285;
            this.lblTaskPendingMessage.Text = "-";
            this.lblTaskPendingMessage.UseStyleColors = true;
            this.lblTaskPendingMessage.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(933, 147);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 36);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblElapseTime
            // 
            this.lblElapseTime.AutoSize = true;
            this.lblElapseTime.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblElapseTime.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblElapseTime.Location = new System.Drawing.Point(524, 196);
            this.lblElapseTime.Name = "lblElapseTime";
            this.lblElapseTime.Size = new System.Drawing.Size(96, 15);
            this.lblElapseTime.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblElapseTime.TabIndex = 286;
            this.lblElapseTime.Text = "Task elapse time:";
            this.lblElapseTime.UseStyleColors = true;
            this.lblElapseTime.Visible = false;
            // 
            // lblElapseTimeToFill
            // 
            this.lblElapseTimeToFill.AutoSize = true;
            this.lblElapseTimeToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblElapseTimeToFill.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblElapseTimeToFill.Location = new System.Drawing.Point(616, 196);
            this.lblElapseTimeToFill.Name = "lblElapseTimeToFill";
            this.lblElapseTimeToFill.Size = new System.Drawing.Size(57, 15);
            this.lblElapseTimeToFill.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblElapseTimeToFill.TabIndex = 287;
            this.lblElapseTimeToFill.Text = "[00.00.00]";
            this.lblElapseTimeToFill.UseStyleColors = true;
            this.lblElapseTimeToFill.Visible = false;
            // 
            // lblBytePendingMessage
            // 
            this.lblBytePendingMessage.AutoSize = true;
            this.lblBytePendingMessage.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblBytePendingMessage.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblBytePendingMessage.Location = new System.Drawing.Point(304, 260);
            this.lblBytePendingMessage.Name = "lblBytePendingMessage";
            this.lblBytePendingMessage.Size = new System.Drawing.Size(12, 15);
            this.lblBytePendingMessage.Style = MetroFramework.MetroColorStyle.Black;
            this.lblBytePendingMessage.TabIndex = 288;
            this.lblBytePendingMessage.Text = "-";
            this.lblBytePendingMessage.UseStyleColors = true;
            this.lblBytePendingMessage.Visible = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(978, 289);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 299;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(994, 307);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(38, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 298;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // cmbShipment
            // 
            this.cmbShipment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbShipment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbShipment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShipment.FormattingEnabled = true;
            this.cmbShipment.Location = new System.Drawing.Point(137, 62);
            this.cmbShipment.Name = "cmbShipment";
            this.cmbShipment.Size = new System.Drawing.Size(315, 25);
            this.cmbShipment.TabIndex = 300;
            this.cmbShipment.SelectedIndexChanged += new System.EventHandler(this.cmbShipment_SelectedIndexChanged);
            // 
            // tglModified
            // 
            this.tglModified.AutoSize = true;
            this.tglModified.Location = new System.Drawing.Point(875, 319);
            this.tglModified.Name = "tglModified";
            this.tglModified.Size = new System.Drawing.Size(103, 15);
            this.tglModified.TabIndex = 303;
            this.tglModified.Text = "Show Modified";
            this.tglModified.UseSelectable = true;
            this.tglModified.CheckedChanged += new System.EventHandler(this.tglModified_CheckedChanged);
            // 
            // btnGo
            // 
            this.btnGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGo.Location = new System.Drawing.Point(821, 307);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(37, 29);
            this.btnGo.TabIndex = 307;
            this.btnGo.Text = "Filter";
            this.btnGo.UseSelectable = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // dash
            // 
            this.dash.AutoSize = true;
            this.dash.Location = new System.Drawing.Point(655, 312);
            this.dash.Name = "dash";
            this.dash.Size = new System.Drawing.Size(15, 19);
            this.dash.TabIndex = 306;
            this.dash.Text = "-";
            this.dash.UseCustomBackColor = true;
            // 
            // metroDateTime1To
            // 
            this.metroDateTime1To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime1To.Location = new System.Drawing.Point(675, 307);
            this.metroDateTime1To.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1To.Name = "metroDateTime1To";
            this.metroDateTime1To.Size = new System.Drawing.Size(135, 29);
            this.metroDateTime1To.TabIndex = 305;
            // 
            // metroDateTime1From
            // 
            this.metroDateTime1From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime1From.Location = new System.Drawing.Point(515, 307);
            this.metroDateTime1From.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1From.Name = "metroDateTime1From";
            this.metroDateTime1From.Size = new System.Drawing.Size(135, 29);
            this.metroDateTime1From.TabIndex = 304;
            // 
            // frm_TaskInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 613);
            this.ControlBox = false;
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.dash);
            this.Controls.Add(this.metroDateTime1To);
            this.Controls.Add(this.metroDateTime1From);
            this.Controls.Add(this.tglModified);
            this.Controls.Add(this.cmbShipment);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.pBoxExportExcel);
            this.Controls.Add(this.lblBytePendingMessage);
            this.Controls.Add(this.lblElapseTimeToFill);
            this.Controls.Add(this.lblElapseTime);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTaskPendingMessage);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.pBoxRefersh);
            this.Controls.Add(this.lblTaskInMessage);
            this.Controls.Add(this.btnTaskOut);
            this.Controls.Add(this.btnTaskIn);
            this.Controls.Add(this.dataGridViewTaskInOut);
            this.Controls.Add(this.lblTaskStatus);
            this.Controls.Add(this.cmbTaskStatus);
            this.Controls.Add(this.dateTimePickerTaskOut);
            this.Controls.Add(this.dateTimePickerTaskIn);
            this.Controls.Add(this.lblTaskIn);
            this.Controls.Add(this.lblPagesKB);
            this.Controls.Add(this.numericUpDownFileSize);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.cmbtaskCode);
            this.Controls.Add(this.lblTaskCode);
            this.Controls.Add(this.lblShipment);
            this.Controls.Add(this.txtJobCode);
            this.Controls.Add(this.lblJobCode);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblManagerUIDToFill);
            this.Controls.Add(this.lblTimeToFill);
            this.Controls.Add(this.lblManagerNameToFill);
            this.Controls.Add(this.lblUIDToFill);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Movable = false;
            this.Name = "frm_TaskInOut";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Activated += new System.EventHandler(this.frm_TaskInOut_Activated);
            this.Load += new System.EventHandler(this.frm_TaskInOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskInOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroLabel lblManagerUIDToFill;
        private MetroFramework.Controls.MetroLabel lblTimeToFill;
        private MetroFramework.Controls.MetroLabel lblManagerNameToFill;
        private MetroFramework.Controls.MetroLabel lblUIDToFill;
        private MetroFramework.Controls.MetroTextBox txtFileName;
        private MetroFramework.Controls.MetroLabel lblFileName;
        private MetroFramework.Controls.MetroLabel lblJobCode;
        private MetroFramework.Controls.MetroTextBox txtJobCode;
        private MetroFramework.Controls.MetroLabel lblShipment;
        private MetroFramework.Controls.MetroLabel lblTaskCode;
        private MetroFramework.Controls.MetroComboBox cmbtaskCode;
        private MetroFramework.Controls.MetroLabel lblFileSize;
        private System.Windows.Forms.NumericUpDown numericUpDownFileSize;
        private MetroFramework.Controls.MetroLabel lblPagesKB;
        private MetroFramework.Controls.MetroLabel lblTaskIn;
        private MetroFramework.Controls.MetroDateTime dateTimePickerTaskIn;
        private MetroFramework.Controls.MetroDateTime dateTimePickerTaskOut;
        private MetroFramework.Controls.MetroComboBox cmbTaskStatus;
        private MetroFramework.Controls.MetroLabel lblTaskStatus;
        private MetroFramework.Controls.MetroGrid dataGridViewTaskInOut;
        private MetroFramework.Controls.MetroButton btnTaskIn;
        private MetroFramework.Controls.MetroButton btnTaskOut;
        private MetroFramework.Controls.MetroLabel lblTaskInMessage;
        private System.Windows.Forms.PictureBox pBoxRefersh;
        private MetroFramework.Controls.MetroComboBox cmbProject;
        private MetroFramework.Controls.MetroLabel lblProject;
        private MetroFramework.Controls.MetroLabel lblTaskPendingMessage;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroLabel lblElapseTime;
        private MetroFramework.Controls.MetroLabel lblElapseTimeToFill;
        private MetroFramework.Controls.MetroLabel lblBytePendingMessage;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
        private System.Windows.Forms.ComboBox cmbShipment;
        private MetroFramework.Controls.MetroCheckBox tglModified;
        private MetroFramework.Controls.MetroButton btnGo;
        private MetroFramework.Controls.MetroLabel dash;
        private MetroFramework.Controls.MetroDateTime metroDateTime1To;
        private MetroFramework.Controls.MetroDateTime metroDateTime1From;
    }
}