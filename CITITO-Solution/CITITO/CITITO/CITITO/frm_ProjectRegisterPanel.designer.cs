namespace CITITO
{
    partial class frm_ProjectRegisterPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProjectRegisterPanel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pBoxRefersh = new System.Windows.Forms.PictureBox();
            this.dataGridViewDepartmentRegister = new MetroFramework.Controls.MetroGrid();
            this.lblProjectName = new MetroFramework.Controls.MetroLabel();
            this.cmbProjectName = new MetroFramework.Controls.MetroTextBox();
            this.btnAddProject = new MetroFramework.Controls.MetroButton();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.lblManagerName = new MetroFramework.Controls.MetroLabel();
            this.btnAddProcessCode = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.dataGridViewProcessCode = new MetroFramework.Controls.MetroGrid();
            this.ProcessNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProcessName = new MetroFramework.Controls.MetroTextBox();
            this.lblProcessName = new MetroFramework.Controls.MetroLabel();
            this.lblProcessCodeList = new MetroFramework.Controls.MetroLabel();
            this.lblTaskCode = new MetroFramework.Controls.MetroLabel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.chkQA = new MetroFramework.Controls.MetroCheckBox();
            this.pnlValidation = new MetroFramework.Controls.MetroPanel();
            this.chkOutputValidation = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartmentRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcessCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            this.pnlValidation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBoxRefersh
            // 
            this.pBoxRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxRefersh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxRefersh.Image")));
            this.pBoxRefersh.Location = new System.Drawing.Point(23, 361);
            this.pBoxRefersh.Name = "pBoxRefersh";
            this.pBoxRefersh.Size = new System.Drawing.Size(22, 20);
            this.pBoxRefersh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRefersh.TabIndex = 103;
            this.pBoxRefersh.TabStop = false;
            this.pBoxRefersh.WaitOnLoad = true;
            this.pBoxRefersh.Click += new System.EventHandler(this.pBoxRefersh_Click);
            // 
            // dataGridViewDepartmentRegister
            // 
            this.dataGridViewDepartmentRegister.AllowUserToAddRows = false;
            this.dataGridViewDepartmentRegister.AllowUserToDeleteRows = false;
            this.dataGridViewDepartmentRegister.AllowUserToResizeRows = false;
            this.dataGridViewDepartmentRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDepartmentRegister.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewDepartmentRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDepartmentRegister.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewDepartmentRegister.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDepartmentRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDepartmentRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDepartmentRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDepartmentRegister.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDepartmentRegister.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewDepartmentRegister.EnableHeadersVisualStyles = false;
            this.dataGridViewDepartmentRegister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewDepartmentRegister.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewDepartmentRegister.Location = new System.Drawing.Point(20, 387);
            this.dataGridViewDepartmentRegister.Name = "dataGridViewDepartmentRegister";
            this.dataGridViewDepartmentRegister.ReadOnly = true;
            this.dataGridViewDepartmentRegister.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDepartmentRegister.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewDepartmentRegister.RowHeadersVisible = false;
            this.dataGridViewDepartmentRegister.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewDepartmentRegister.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewDepartmentRegister.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewDepartmentRegister.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewDepartmentRegister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDepartmentRegister.Size = new System.Drawing.Size(1199, 261);
            this.dataGridViewDepartmentRegister.Style = MetroFramework.MetroColorStyle.Teal;
            this.dataGridViewDepartmentRegister.TabIndex = 146;
            this.dataGridViewDepartmentRegister.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewDepartmentRegister.UseCustomBackColor = true;
            this.dataGridViewDepartmentRegister.UseCustomForeColor = true;
            this.dataGridViewDepartmentRegister.UseStyleColors = true;
            this.dataGridViewDepartmentRegister.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDepartmentRegister_CellContentClick);            
            this.dataGridViewDepartmentRegister.Click += new System.EventHandler(this.dataGridViewDepartmentRegister_Click);
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(49, 83);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(93, 19);
            this.lblProjectName.TabIndex = 147;
            this.lblProjectName.Text = "Project Name:";
            // 
            // cmbProjectName
            // 
            // 
            // 
            // 
            this.cmbProjectName.CustomButton.Image = null;
            this.cmbProjectName.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.cmbProjectName.CustomButton.Name = "";
            this.cmbProjectName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.cmbProjectName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.cmbProjectName.CustomButton.TabIndex = 1;
            this.cmbProjectName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cmbProjectName.CustomButton.UseSelectable = true;
            this.cmbProjectName.CustomButton.Visible = false;
            this.cmbProjectName.Lines = new string[0];
            this.cmbProjectName.Location = new System.Drawing.Point(148, 83);
            this.cmbProjectName.MaxLength = 32767;
            this.cmbProjectName.Name = "cmbProjectName";
            this.cmbProjectName.PasswordChar = '\0';
            this.cmbProjectName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cmbProjectName.SelectedText = "";
            this.cmbProjectName.SelectionLength = 0;
            this.cmbProjectName.SelectionStart = 0;
            this.cmbProjectName.ShortcutsEnabled = true;
            this.cmbProjectName.Size = new System.Drawing.Size(122, 23);
            this.cmbProjectName.TabIndex = 1;
            this.cmbProjectName.UseSelectable = true;
            this.cmbProjectName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbProjectName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.cmbProjectName.TextChanged += new System.EventHandler(this.cmbProjectName_TextChanged);
            this.cmbProjectName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbProjectName_KeyUp);
            this.cmbProjectName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbProjectName_MouseClick);
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(1099, 91);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(120, 35);
            this.btnAddProject.TabIndex = 4;
            this.btnAddProject.Text = "Add Project/Item";
            this.btnAddProject.UseSelectable = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1099, 136);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 35);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Modify";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1099, 182);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete Project";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1099, 228);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 35);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(861, 30);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(30, 19);
            this.lblUID.TabIndex = 187;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // lblManagerName
            // 
            this.lblManagerName.AutoSize = true;
            this.lblManagerName.Location = new System.Drawing.Point(897, 30);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(45, 19);
            this.lblManagerName.TabIndex = 188;
            this.lblManagerName.Text = "Name";
            this.lblManagerName.Visible = false;
            // 
            // btnAddProcessCode
            // 
            this.btnAddProcessCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProcessCode.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnAddProcessCode.Location = new System.Drawing.Point(276, 131);
            this.btnAddProcessCode.Name = "btnAddProcessCode";
            this.btnAddProcessCode.Size = new System.Drawing.Size(47, 23);
            this.btnAddProcessCode.TabIndex = 3;
            this.btnAddProcessCode.Text = "Add";
            this.btnAddProcessCode.UseSelectable = true;
            this.btnAddProcessCode.Click += new System.EventHandler(this.btnAddProcessCode_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton1.Location = new System.Drawing.Point(647, 199);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(45, 25);
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "Clear All";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // dataGridViewProcessCode
            // 
            this.dataGridViewProcessCode.AllowUserToAddRows = false;
            this.dataGridViewProcessCode.AllowUserToDeleteRows = false;
            this.dataGridViewProcessCode.AllowUserToResizeRows = false;
            this.dataGridViewProcessCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProcessCode.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewProcessCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProcessCode.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewProcessCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProcessCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewProcessCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcessCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessNumber,
            this.ProcessName,
            this.Remove});
            this.dataGridViewProcessCode.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProcessCode.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewProcessCode.EnableHeadersVisualStyles = false;
            this.dataGridViewProcessCode.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewProcessCode.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewProcessCode.Location = new System.Drawing.Point(148, 199);
            this.dataGridViewProcessCode.Name = "dataGridViewProcessCode";
            this.dataGridViewProcessCode.ReadOnly = true;
            this.dataGridViewProcessCode.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProcessCode.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewProcessCode.RowHeadersVisible = false;
            this.dataGridViewProcessCode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewProcessCode.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewProcessCode.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewProcessCode.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewProcessCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProcessCode.Size = new System.Drawing.Size(477, 138);
            this.dataGridViewProcessCode.Style = MetroFramework.MetroColorStyle.Blue;
            this.dataGridViewProcessCode.TabIndex = 191;
            this.dataGridViewProcessCode.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewProcessCode.UseCustomBackColor = true;
            this.dataGridViewProcessCode.UseCustomForeColor = true;
            this.dataGridViewProcessCode.UseStyleColors = true;
            this.dataGridViewProcessCode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProcessCode_CellContentClick);
            // 
            // ProcessNumber
            // 
            this.ProcessNumber.FillWeight = 111.9289F;
            this.ProcessNumber.HeaderText = "#";
            this.ProcessNumber.Name = "ProcessNumber";
            this.ProcessNumber.ReadOnly = true;
            // 
            // ProcessName
            // 
            this.ProcessName.FillWeight = 111.9289F;
            this.ProcessName.HeaderText = "Process Code";
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.ReadOnly = true;
            // 
            // Remove
            // 
            this.Remove.FillWeight = 76.14214F;
            this.Remove.HeaderText = "";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Remove.Text = "Remove";
            this.Remove.ToolTipText = "Remove";
            // 
            // txtProcessName
            // 
            // 
            // 
            // 
            this.txtProcessName.CustomButton.Image = null;
            this.txtProcessName.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.txtProcessName.CustomButton.Name = "";
            this.txtProcessName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtProcessName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProcessName.CustomButton.TabIndex = 1;
            this.txtProcessName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProcessName.CustomButton.UseSelectable = true;
            this.txtProcessName.CustomButton.Visible = false;
            this.txtProcessName.Lines = new string[0];
            this.txtProcessName.Location = new System.Drawing.Point(148, 131);
            this.txtProcessName.MaxLength = 32767;
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.PasswordChar = '\0';
            this.txtProcessName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProcessName.SelectedText = "";
            this.txtProcessName.SelectionLength = 0;
            this.txtProcessName.SelectionStart = 0;
            this.txtProcessName.ShortcutsEnabled = true;
            this.txtProcessName.Size = new System.Drawing.Size(122, 23);
            this.txtProcessName.TabIndex = 2;
            this.txtProcessName.UseSelectable = true;
            this.txtProcessName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProcessName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtProcessName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProcessName_KeyDown);
            this.txtProcessName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProcessName_KeyUp);
            // 
            // lblProcessName
            // 
            this.lblProcessName.AutoSize = true;
            this.lblProcessName.Location = new System.Drawing.Point(68, 133);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(74, 19);
            this.lblProcessName.TabIndex = 193;
            this.lblProcessName.Text = "Item Code:";
            // 
            // lblProcessCodeList
            // 
            this.lblProcessCodeList.AutoSize = true;
            this.lblProcessCodeList.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblProcessCodeList.Location = new System.Drawing.Point(146, 181);
            this.lblProcessCodeList.Name = "lblProcessCodeList";
            this.lblProcessCodeList.Size = new System.Drawing.Size(82, 15);
            this.lblProcessCodeList.TabIndex = 194;
            this.lblProcessCodeList.Text = "Item Code List:";
            // 
            // lblTaskCode
            // 
            this.lblTaskCode.AutoSize = true;
            this.lblTaskCode.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTaskCode.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTaskCode.Location = new System.Drawing.Point(20, 24);
            this.lblTaskCode.Name = "lblTaskCode";
            this.lblTaskCode.Size = new System.Drawing.Size(134, 25);
            this.lblTaskCode.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblTaskCode.TabIndex = 215;
            this.lblTaskCode.Text = "Project Register";
            this.lblTaskCode.UseStyleColors = true;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(1099, 274);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 36);
            this.btnExit.TabIndex = 251;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(1160, 336);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 253;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(1180, 354);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(36, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 252;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // chkQA
            // 
            this.chkQA.AutoSize = true;
            this.chkQA.BackColor = System.Drawing.Color.Transparent;
            this.chkQA.Location = new System.Drawing.Point(16, 15);
            this.chkQA.Name = "chkQA";
            this.chkQA.Size = new System.Drawing.Size(210, 15);
            this.chkQA.TabIndex = 254;
            this.chkQA.Text = "Check if project is registered for QA";
            this.chkQA.UseCustomBackColor = true;
            this.chkQA.UseSelectable = true;
            // 
            // pnlValidation
            // 
            this.pnlValidation.BackColor = System.Drawing.Color.LightGreen;
            this.pnlValidation.Controls.Add(this.chkOutputValidation);
            this.pnlValidation.Controls.Add(this.chkQA);
            this.pnlValidation.HorizontalScrollbarBarColor = true;
            this.pnlValidation.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlValidation.HorizontalScrollbarSize = 10;
            this.pnlValidation.Location = new System.Drawing.Point(340, 83);
            this.pnlValidation.Name = "pnlValidation";
            this.pnlValidation.Size = new System.Drawing.Size(285, 71);
            this.pnlValidation.Style = MetroFramework.MetroColorStyle.Green;
            this.pnlValidation.TabIndex = 255;
            this.pnlValidation.UseCustomBackColor = true;
            this.pnlValidation.UseStyleColors = true;
            this.pnlValidation.VerticalScrollbarBarColor = true;
            this.pnlValidation.VerticalScrollbarHighlightOnWheel = false;
            this.pnlValidation.VerticalScrollbarSize = 10;
            // 
            // chkOutputValidation
            // 
            this.chkOutputValidation.AutoSize = true;
            this.chkOutputValidation.BackColor = System.Drawing.Color.Transparent;
            this.chkOutputValidation.Location = new System.Drawing.Point(16, 41);
            this.chkOutputValidation.Name = "chkOutputValidation";
            this.chkOutputValidation.Size = new System.Drawing.Size(260, 15);
            this.chkOutputValidation.TabIndex = 255;
            this.chkOutputValidation.Text = "Check if need to avoid user output validation";
            this.chkOutputValidation.UseCustomBackColor = true;
            this.chkOutputValidation.UseSelectable = true;
            // 
            // frm_ProjectRegisterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 668);
            this.ControlBox = false;
            this.Controls.Add(this.pnlValidation);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.pBoxExportExcel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTaskCode);
            this.Controls.Add(this.lblProcessCodeList);
            this.Controls.Add(this.lblProcessName);
            this.Controls.Add(this.txtProcessName);
            this.Controls.Add(this.dataGridViewProcessCode);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnAddProcessCode);
            this.Controls.Add(this.lblManagerName);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.cmbProjectName);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.dataGridViewDepartmentRegister);
            this.Controls.Add(this.pBoxRefersh);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "frm_ProjectRegisterPanel";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Activated += new System.EventHandler(this.frm_ProjectRegisterPanel_Activated);
            this.Load += new System.EventHandler(this.frm_DepartmentRegisterPanel_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_DepartmentRegisterPanel_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartmentRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcessCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            this.pnlValidation.ResumeLayout(false);
            this.pnlValidation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxRefersh;
        private MetroFramework.Controls.MetroGrid dataGridViewDepartmentRegister;
        private MetroFramework.Controls.MetroLabel lblProjectName;
        private MetroFramework.Controls.MetroTextBox cmbProjectName;
        private MetroFramework.Controls.MetroButton btnAddProject;
        private MetroFramework.Controls.MetroButton btnUpdate;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroLabel lblManagerName;
        private MetroFramework.Controls.MetroButton btnAddProcessCode;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroGrid dataGridViewProcessCode;
        private MetroFramework.Controls.MetroTextBox txtProcessName;
        private MetroFramework.Controls.MetroLabel lblProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private MetroFramework.Controls.MetroLabel lblProcessCodeList;
        private MetroFramework.Controls.MetroLabel lblTaskCode;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
        private MetroFramework.Controls.MetroCheckBox chkQA;
        private MetroFramework.Controls.MetroPanel pnlValidation;
        private MetroFramework.Controls.MetroCheckBox chkOutputValidation;
    }
}