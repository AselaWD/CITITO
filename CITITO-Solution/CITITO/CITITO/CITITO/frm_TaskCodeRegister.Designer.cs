namespace CITITO
{
    partial class frm_TaskCodeRegister
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TaskCodeRegister));
            this.lblTaskCodeList = new MetroFramework.Controls.MetroLabel();
            this.dataGridViewTaskCodeList = new MetroFramework.Controls.MetroGrid();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnAddProcessCode = new MetroFramework.Controls.MetroButton();
            this.lblManagerName = new MetroFramework.Controls.MetroLabel();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.btnAddProject = new MetroFramework.Controls.MetroButton();
            this.dataGridViewTaskCodes = new MetroFramework.Controls.MetroGrid();
            this.lblProcessName = new MetroFramework.Controls.MetroLabel();
            this.lblProjectName = new MetroFramework.Controls.MetroLabel();
            this.cmbProjectName = new MetroFramework.Controls.MetroComboBox();
            this.cmbProcessCode = new MetroFramework.Controls.MetroComboBox();
            this.lblTaskCode = new MetroFramework.Controls.MetroLabel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.pBoxRefersh = new System.Windows.Forms.PictureBox();
            this.btnBulkImport = new MetroFramework.Controls.MetroButton();
            this.TaskCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.QuotaSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkipValidation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskCodeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTaskCodeList
            // 
            this.lblTaskCodeList.AutoSize = true;
            this.lblTaskCodeList.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTaskCodeList.Location = new System.Drawing.Point(161, 156);
            this.lblTaskCodeList.Name = "lblTaskCodeList";
            this.lblTaskCodeList.Size = new System.Drawing.Size(79, 15);
            this.lblTaskCodeList.TabIndex = 198;
            this.lblTaskCodeList.Text = "Task Code List:";
            // 
            // dataGridViewTaskCodeList
            // 
            this.dataGridViewTaskCodeList.AllowUserToAddRows = false;
            this.dataGridViewTaskCodeList.AllowUserToDeleteRows = false;
            this.dataGridViewTaskCodeList.AllowUserToResizeRows = false;
            this.dataGridViewTaskCodeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTaskCodeList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTaskCodeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTaskCodeList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewTaskCodeList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTaskCodeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTaskCodeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaskCodeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskCode,
            this.TaskDescription,
            this.UOM,
            this.QuotaSize,
            this.SkipValidation,
            this.Remove});
            this.dataGridViewTaskCodeList.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTaskCodeList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTaskCodeList.EnableHeadersVisualStyles = false;
            this.dataGridViewTaskCodeList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewTaskCodeList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTaskCodeList.Location = new System.Drawing.Point(161, 173);
            this.dataGridViewTaskCodeList.Name = "dataGridViewTaskCodeList";
            this.dataGridViewTaskCodeList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTaskCodeList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTaskCodeList.RowHeadersVisible = false;
            this.dataGridViewTaskCodeList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTaskCodeList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewTaskCodeList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewTaskCodeList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTaskCodeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTaskCodeList.Size = new System.Drawing.Size(757, 164);
            this.dataGridViewTaskCodeList.Style = MetroFramework.MetroColorStyle.Blue;
            this.dataGridViewTaskCodeList.TabIndex = 197;
            this.dataGridViewTaskCodeList.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewTaskCodeList.UseCustomBackColor = true;
            this.dataGridViewTaskCodeList.UseCustomForeColor = true;
            this.dataGridViewTaskCodeList.UseStyleColors = true;
            this.dataGridViewTaskCodeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTaskCodeList_CellClick);
            this.dataGridViewTaskCodeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTaskCodeList_CellContentClick);
            this.dataGridViewTaskCodeList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTaskCodeList_CellValueChanged);
            // 
            // metroButton1
            // 
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton1.Location = new System.Drawing.Point(873, 343);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(45, 25);
            this.metroButton1.TabIndex = 196;
            this.metroButton1.Text = "Clear All";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btnAddProcessCode
            // 
            this.btnAddProcessCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProcessCode.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnAddProcessCode.Location = new System.Drawing.Point(871, 144);
            this.btnAddProcessCode.Name = "btnAddProcessCode";
            this.btnAddProcessCode.Size = new System.Drawing.Size(47, 23);
            this.btnAddProcessCode.TabIndex = 195;
            this.btnAddProcessCode.Text = "Add";
            this.btnAddProcessCode.UseSelectable = true;
            this.btnAddProcessCode.Click += new System.EventHandler(this.btnAddProcessCode_Click);
            // 
            // lblManagerName
            // 
            this.lblManagerName.AutoSize = true;
            this.lblManagerName.Location = new System.Drawing.Point(851, 30);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(45, 19);
            this.lblManagerName.TabIndex = 200;
            this.lblManagerName.Text = "Name";
            this.lblManagerName.Visible = false;
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(815, 30);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(30, 19);
            this.lblUID.TabIndex = 199;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1099, 238);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 35);
            this.btnClear.TabIndex = 204;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1099, 193);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.TabIndex = 203;
            this.btnDelete.Text = "Delete by \r\nProcess Code";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1099, 148);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 35);
            this.btnUpdate.TabIndex = 202;
            this.btnUpdate.Text = "Modify";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(1099, 103);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(120, 35);
            this.btnAddProject.TabIndex = 201;
            this.btnAddProject.Text = "Add Task Codes";
            this.btnAddProject.UseSelectable = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // dataGridViewTaskCodes
            // 
            this.dataGridViewTaskCodes.AllowUserToAddRows = false;
            this.dataGridViewTaskCodes.AllowUserToDeleteRows = false;
            this.dataGridViewTaskCodes.AllowUserToResizeRows = false;
            this.dataGridViewTaskCodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTaskCodes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTaskCodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTaskCodes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewTaskCodes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTaskCodes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTaskCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaskCodes.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTaskCodes.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTaskCodes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewTaskCodes.EnableHeadersVisualStyles = false;
            this.dataGridViewTaskCodes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewTaskCodes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTaskCodes.Location = new System.Drawing.Point(20, 404);
            this.dataGridViewTaskCodes.MultiSelect = false;
            this.dataGridViewTaskCodes.Name = "dataGridViewTaskCodes";
            this.dataGridViewTaskCodes.ReadOnly = true;
            this.dataGridViewTaskCodes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTaskCodes.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTaskCodes.RowHeadersVisible = false;
            this.dataGridViewTaskCodes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTaskCodes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewTaskCodes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewTaskCodes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTaskCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTaskCodes.Size = new System.Drawing.Size(1199, 244);
            this.dataGridViewTaskCodes.Style = MetroFramework.MetroColorStyle.Teal;
            this.dataGridViewTaskCodes.TabIndex = 207;
            this.dataGridViewTaskCodes.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewTaskCodes.UseCustomBackColor = true;
            this.dataGridViewTaskCodes.UseCustomForeColor = true;
            this.dataGridViewTaskCodes.UseStyleColors = true;
            this.dataGridViewTaskCodes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTaskCodes_CellContentClick);
            this.dataGridViewTaskCodes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewTaskCodes_CellFormatting);
            this.dataGridViewTaskCodes.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridViewTaskCodes_SortCompare);
            // 
            // lblProcessName
            // 
            this.lblProcessName.AutoSize = true;
            this.lblProcessName.Location = new System.Drawing.Point(53, 122);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(92, 19);
            this.lblProcessName.TabIndex = 211;
            this.lblProcessName.Text = "Process Code:";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(52, 77);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(93, 19);
            this.lblProjectName.TabIndex = 210;
            this.lblProjectName.Text = "Project Name:";
            // 
            // cmbProjectName
            // 
            this.cmbProjectName.FormattingEnabled = true;
            this.cmbProjectName.ItemHeight = 23;
            this.cmbProjectName.Location = new System.Drawing.Point(161, 67);
            this.cmbProjectName.Name = "cmbProjectName";
            this.cmbProjectName.Size = new System.Drawing.Size(121, 29);
            this.cmbProjectName.TabIndex = 212;
            this.cmbProjectName.UseSelectable = true;
            this.cmbProjectName.SelectedIndexChanged += new System.EventHandler(this.cmbProjectName_SelectedIndexChanged);
            // 
            // cmbProcessCode
            // 
            this.cmbProcessCode.FormattingEnabled = true;
            this.cmbProcessCode.ItemHeight = 23;
            this.cmbProcessCode.Location = new System.Drawing.Point(161, 112);
            this.cmbProcessCode.Name = "cmbProcessCode";
            this.cmbProcessCode.Size = new System.Drawing.Size(121, 29);
            this.cmbProcessCode.TabIndex = 213;
            this.cmbProcessCode.UseSelectable = true;
            this.cmbProcessCode.SelectedIndexChanged += new System.EventHandler(this.cmbProcessCode_SelectedIndexChanged);
            // 
            // lblTaskCode
            // 
            this.lblTaskCode.AutoSize = true;
            this.lblTaskCode.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTaskCode.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTaskCode.Location = new System.Drawing.Point(20, 24);
            this.lblTaskCode.Name = "lblTaskCode";
            this.lblTaskCode.Size = new System.Drawing.Size(160, 25);
            this.lblTaskCode.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblTaskCode.TabIndex = 214;
            this.lblTaskCode.Text = "Task Code Register";
            this.lblTaskCode.UseStyleColors = true;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(1099, 285);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 36);
            this.btnExit.TabIndex = 252;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(1160, 353);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 255;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(1180, 371);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(36, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 254;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // pBoxRefersh
            // 
            this.pBoxRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxRefersh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxRefersh.Image")));
            this.pBoxRefersh.Location = new System.Drawing.Point(20, 378);
            this.pBoxRefersh.Name = "pBoxRefersh";
            this.pBoxRefersh.Size = new System.Drawing.Size(22, 20);
            this.pBoxRefersh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRefersh.TabIndex = 206;
            this.pBoxRefersh.TabStop = false;
            this.pBoxRefersh.WaitOnLoad = true;
            this.pBoxRefersh.Click += new System.EventHandler(this.pBoxRefersh_Click);
            // 
            // btnBulkImport
            // 
            this.btnBulkImport.Location = new System.Drawing.Point(1099, 58);
            this.btnBulkImport.Name = "btnBulkImport";
            this.btnBulkImport.Size = new System.Drawing.Size(120, 35);
            this.btnBulkImport.TabIndex = 256;
            this.btnBulkImport.Text = "Bulk Import";
            this.btnBulkImport.UseSelectable = true;
            this.btnBulkImport.Click += new System.EventHandler(this.btnBulkImport_Click);
            // 
            // TaskCode
            // 
            this.TaskCode.FillWeight = 111.9289F;
            this.TaskCode.HeaderText = "Task Code";
            this.TaskCode.Name = "TaskCode";
            // 
            // TaskDescription
            // 
            this.TaskDescription.FillWeight = 111.9289F;
            this.TaskDescription.HeaderText = "Description";
            this.TaskDescription.Name = "TaskDescription";
            // 
            // UOM
            // 
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            this.UOM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UOM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // QuotaSize
            // 
            this.QuotaSize.HeaderText = "Quota";
            this.QuotaSize.Name = "QuotaSize";
            // 
            // SkipValidation
            // 
            this.SkipValidation.HeaderText = "Skip User Output Validation";
            this.SkipValidation.Name = "SkipValidation";
            // 
            // Remove
            // 
            this.Remove.FillWeight = 76.14214F;
            this.Remove.HeaderText = "";
            this.Remove.Name = "Remove";
            this.Remove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Remove.Text = "Remove";
            this.Remove.ToolTipText = "Remove";
            // 
            // frm_TaskCodeRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 668);
            this.ControlBox = false;
            this.Controls.Add(this.btnBulkImport);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.pBoxExportExcel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTaskCode);
            this.Controls.Add(this.cmbProcessCode);
            this.Controls.Add(this.cmbProjectName);
            this.Controls.Add(this.lblProcessName);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.dataGridViewTaskCodes);
            this.Controls.Add(this.pBoxRefersh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.lblManagerName);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.lblTaskCodeList);
            this.Controls.Add(this.dataGridViewTaskCodeList);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnAddProcessCode);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "frm_TaskCodeRegister";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Load += new System.EventHandler(this.frm_TaskCodeRegister_Load);
            this.Enter += new System.EventHandler(this.frm_TaskCodeRegister_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskCodeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblTaskCodeList;
        private MetroFramework.Controls.MetroGrid dataGridViewTaskCodeList;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton btnAddProcessCode;
        private MetroFramework.Controls.MetroLabel lblManagerName;
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnUpdate;
        private MetroFramework.Controls.MetroButton btnAddProject;
        private MetroFramework.Controls.MetroGrid dataGridViewTaskCodes;
        private System.Windows.Forms.PictureBox pBoxRefersh;
        private MetroFramework.Controls.MetroLabel lblProcessName;
        private MetroFramework.Controls.MetroLabel lblProjectName;
        private MetroFramework.Controls.MetroComboBox cmbProjectName;
        private MetroFramework.Controls.MetroComboBox cmbProcessCode;
        private MetroFramework.Controls.MetroLabel lblTaskCode;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
        private MetroFramework.Controls.MetroButton btnBulkImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotaSize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SkipValidation;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
    }
}