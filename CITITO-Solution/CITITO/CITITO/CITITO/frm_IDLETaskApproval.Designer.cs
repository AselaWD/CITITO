namespace CITITO
{
    partial class frm_IDLETaskApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_IDLETaskApproval));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbMUID1 = new MetroFramework.Controls.MetroComboBox();
            this.lblMUID = new MetroFramework.Controls.MetroLabel();
            this.lblPIC = new MetroFramework.Controls.MetroLabel();
            this.cmbUserID = new MetroFramework.Controls.MetroTextBox();
            this.lblTaskIn = new MetroFramework.Controls.MetroLabel();
            this.btnCheck = new MetroFramework.Controls.MetroButton();
            this.dateTimePickerTo = new MetroFramework.Controls.MetroDateTime();
            this.dateTimePickerFrom = new MetroFramework.Controls.MetroDateTime();
            this.lblTaskOut = new System.Windows.Forms.Label();
            this.btnHistory = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnTimeModify = new MetroFramework.Controls.MetroButton();
            this.btnDisapprove = new MetroFramework.Controls.MetroButton();
            this.btnApprove = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.pBoxRefersh = new System.Windows.Forms.PictureBox();
            this.dataGridViewIDLEForApproval = new MetroFramework.Controls.MetroGrid();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.txtProject = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIDLEForApproval)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMUID1
            // 
            this.cmbMUID1.FormattingEnabled = true;
            this.cmbMUID1.ItemHeight = 23;
            this.cmbMUID1.Location = new System.Drawing.Point(68, 60);
            this.cmbMUID1.Name = "cmbMUID1";
            this.cmbMUID1.PromptText = "Manager";
            this.cmbMUID1.Size = new System.Drawing.Size(89, 29);
            this.cmbMUID1.TabIndex = 333;
            this.cmbMUID1.UseSelectable = true;
            this.cmbMUID1.SelectedIndexChanged += new System.EventHandler(this.cmbMUID1_SelectedIndexChanged);
            // 
            // lblMUID
            // 
            this.lblMUID.AutoSize = true;
            this.lblMUID.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblMUID.Location = new System.Drawing.Point(428, 19);
            this.lblMUID.Name = "lblMUID";
            this.lblMUID.Size = new System.Drawing.Size(36, 15);
            this.lblMUID.TabIndex = 347;
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
            this.lblPIC.TabIndex = 346;
            this.lblPIC.Text = "PIC";
            this.lblPIC.Visible = false;
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
            this.cmbUserID.Location = new System.Drawing.Point(174, 63);
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
            this.cmbUserID.TabIndex = 334;
            this.cmbUserID.UseSelectable = true;
            this.cmbUserID.WaterMark = "User ID";
            this.cmbUserID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbUserID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.cmbUserID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbUserID_KeyUp);
            // 
            // lblTaskIn
            // 
            this.lblTaskIn.AutoSize = true;
            this.lblTaskIn.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTaskIn.Location = new System.Drawing.Point(654, 69);
            this.lblTaskIn.Name = "lblTaskIn";
            this.lblTaskIn.Size = new System.Drawing.Size(69, 15);
            this.lblTaskIn.TabIndex = 345;
            this.lblTaskIn.Text = "Date Range:";
            this.lblTaskIn.UseCustomBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.Location = new System.Drawing.Point(1011, 60);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(48, 29);
            this.btnCheck.TabIndex = 339;
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
            this.dateTimePickerTo.TabIndex = 338;
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
            this.dateTimePickerFrom.TabIndex = 337;
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
            this.lblTaskOut.TabIndex = 344;
            this.lblTaskOut.Text = "-";
            // 
            // btnHistory
            // 
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistory.Location = new System.Drawing.Point(1169, 153);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(102, 36);
            this.btnHistory.Style = MetroFramework.MetroColorStyle.Green;
            this.btnHistory.TabIndex = 332;
            this.btnHistory.Text = "History";
            this.btnHistory.UseSelectable = true;
            this.btnHistory.UseStyleColors = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(1169, 340);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 36);
            this.btnDelete.TabIndex = 329;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnTimeModify
            // 
            this.btnTimeModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimeModify.Location = new System.Drawing.Point(1169, 499);
            this.btnTimeModify.Name = "btnTimeModify";
            this.btnTimeModify.Size = new System.Drawing.Size(102, 36);
            this.btnTimeModify.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnTimeModify.TabIndex = 328;
            this.btnTimeModify.Text = "Modify Time";
            this.btnTimeModify.UseSelectable = true;
            this.btnTimeModify.UseStyleColors = true;
            this.btnTimeModify.Visible = false;
            // 
            // btnDisapprove
            // 
            this.btnDisapprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisapprove.Location = new System.Drawing.Point(1169, 293);
            this.btnDisapprove.Name = "btnDisapprove";
            this.btnDisapprove.Size = new System.Drawing.Size(102, 36);
            this.btnDisapprove.TabIndex = 327;
            this.btnDisapprove.Text = "Disapprove";
            this.btnDisapprove.UseSelectable = true;
            this.btnDisapprove.Click += new System.EventHandler(this.btnDisapprove_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApprove.Location = new System.Drawing.Point(1169, 246);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(102, 36);
            this.btnApprove.TabIndex = 326;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseSelectable = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
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
            this.metroLabel3.TabIndex = 343;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(1114, 62);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(38, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 342;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(1169, 387);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 36);
            this.btnClear.TabIndex = 330;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pBoxRefersh
            // 
            this.pBoxRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxRefersh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxRefersh.Image")));
            this.pBoxRefersh.Location = new System.Drawing.Point(13, 69);
            this.pBoxRefersh.Name = "pBoxRefersh";
            this.pBoxRefersh.Size = new System.Drawing.Size(22, 20);
            this.pBoxRefersh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRefersh.TabIndex = 341;
            this.pBoxRefersh.TabStop = false;
            this.pBoxRefersh.WaitOnLoad = true;
            this.pBoxRefersh.Click += new System.EventHandler(this.pBoxRefersh_Click);
            // 
            // dataGridViewIDLEForApproval
            // 
            this.dataGridViewIDLEForApproval.AllowUserToAddRows = false;
            this.dataGridViewIDLEForApproval.AllowUserToDeleteRows = false;
            this.dataGridViewIDLEForApproval.AllowUserToResizeColumns = false;
            this.dataGridViewIDLEForApproval.AllowUserToResizeRows = false;
            this.dataGridViewIDLEForApproval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIDLEForApproval.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewIDLEForApproval.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewIDLEForApproval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewIDLEForApproval.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewIDLEForApproval.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle25.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewIDLEForApproval.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewIDLEForApproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIDLEForApproval.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewIDLEForApproval.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridViewIDLEForApproval.EnableHeadersVisualStyles = false;
            this.dataGridViewIDLEForApproval.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewIDLEForApproval.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewIDLEForApproval.Location = new System.Drawing.Point(13, 95);
            this.dataGridViewIDLEForApproval.Name = "dataGridViewIDLEForApproval";
            this.dataGridViewIDLEForApproval.ReadOnly = true;
            this.dataGridViewIDLEForApproval.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewIDLEForApproval.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridViewIDLEForApproval.RowHeadersVisible = false;
            this.dataGridViewIDLEForApproval.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewIDLEForApproval.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewIDLEForApproval.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewIDLEForApproval.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewIDLEForApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIDLEForApproval.Size = new System.Drawing.Size(1142, 605);
            this.dataGridViewIDLEForApproval.Style = MetroFramework.MetroColorStyle.Blue;
            this.dataGridViewIDLEForApproval.TabIndex = 340;
            this.dataGridViewIDLEForApproval.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewIDLEForApproval.UseCustomBackColor = true;
            this.dataGridViewIDLEForApproval.UseCustomForeColor = true;
            this.dataGridViewIDLEForApproval.UseStyleColors = true;
            this.dataGridViewIDLEForApproval.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIDLEForApproval_CellContentClick);
            this.dataGridViewIDLEForApproval.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewIDLEForApproval_CellFormatting);
            this.dataGridViewIDLEForApproval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewIDLEForApproval_KeyDown);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(1169, 434);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 36);
            this.btnExit.TabIndex = 331;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtProject
            // 
            // 
            // 
            // 
            this.txtProject.CustomButton.Image = null;
            this.txtProject.CustomButton.Location = new System.Drawing.Point(72, 2);
            this.txtProject.CustomButton.Name = "";
            this.txtProject.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtProject.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProject.CustomButton.TabIndex = 1;
            this.txtProject.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProject.CustomButton.UseSelectable = true;
            this.txtProject.CustomButton.Visible = false;
            this.txtProject.Lines = new string[0];
            this.txtProject.Location = new System.Drawing.Point(266, 63);
            this.txtProject.MaxLength = 32767;
            this.txtProject.Name = "txtProject";
            this.txtProject.PasswordChar = '\0';
            this.txtProject.PromptText = "Project";
            this.txtProject.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProject.SelectedText = "";
            this.txtProject.SelectionLength = 0;
            this.txtProject.SelectionStart = 0;
            this.txtProject.ShortcutsEnabled = true;
            this.txtProject.Size = new System.Drawing.Size(94, 24);
            this.txtProject.TabIndex = 348;
            this.txtProject.UseSelectable = true;
            this.txtProject.WaterMark = "Project";
            this.txtProject.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProject.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtProject.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProject_KeyUp);
            // 
            // frm_IDLETaskApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 705);
            this.ControlBox = false;
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.cmbMUID1);
            this.Controls.Add(this.lblMUID);
            this.Controls.Add(this.lblPIC);
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
            this.Controls.Add(this.dataGridViewIDLEForApproval);
            this.Controls.Add(this.btnExit);
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "frm_IDLETaskApproval";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Load += new System.EventHandler(this.frm_IDLETaskApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIDLEForApproval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cmbMUID1;
        private MetroFramework.Controls.MetroLabel lblMUID;
        private MetroFramework.Controls.MetroLabel lblPIC;
        private MetroFramework.Controls.MetroTextBox cmbUserID;
        private MetroFramework.Controls.MetroLabel lblTaskIn;
        private MetroFramework.Controls.MetroButton btnCheck;
        private MetroFramework.Controls.MetroDateTime dateTimePickerTo;
        private MetroFramework.Controls.MetroDateTime dateTimePickerFrom;
        private System.Windows.Forms.Label lblTaskOut;
        private MetroFramework.Controls.MetroButton btnHistory;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnTimeModify;
        private MetroFramework.Controls.MetroButton btnDisapprove;
        private MetroFramework.Controls.MetroButton btnApprove;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
        private MetroFramework.Controls.MetroButton btnClear;
        private System.Windows.Forms.PictureBox pBoxRefersh;
        private MetroFramework.Controls.MetroGrid dataGridViewIDLEForApproval;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroTextBox txtProject;
    }
}