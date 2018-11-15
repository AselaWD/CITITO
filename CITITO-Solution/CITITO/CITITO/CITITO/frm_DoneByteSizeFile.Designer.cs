namespace CITITO
{
    partial class frm_DoneByteSizeFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DoneByteSizeFile));
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnTaskOut = new MetroFramework.Controls.MetroButton();
            this.dataGridViewTaskInOut = new MetroFramework.Controls.MetroGrid();
            this.lblUserMessage = new MetroFramework.Controls.MetroLabel();
            this.lblHistory = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtSubTotal = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lblPCP = new MetroFramework.Controls.MetroLabel();
            this.lblTask = new MetroFramework.Controls.MetroLabel();
            this.lblFileName = new MetroFramework.Controls.MetroLabel();
            this.lblShipment = new MetroFramework.Controls.MetroLabel();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.lblFileSize2 = new MetroFramework.Controls.MetroLabel();
            this.lblTaskOut = new MetroFramework.Controls.MetroLabel();
            this.lblHours = new MetroFramework.Controls.MetroLabel();
            this.lblProductivity = new MetroFramework.Controls.MetroLabel();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.lblMID = new MetroFramework.Controls.MetroLabel();
            this.lblPIC = new MetroFramework.Controls.MetroLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtPath = new MetroFramework.Controls.MetroTextBox();
            this.btnBrowse = new MetroFramework.Controls.MetroButton();
            this.lblBrowse = new MetroFramework.Controls.MetroLabel();
            this.groupBoxFile = new System.Windows.Forms.GroupBox();
            this.groupBoxFolder = new System.Windows.Forms.GroupBox();
            this.lblBrowseFolder = new MetroFramework.Controls.MetroLabel();
            this.txtPathFolder = new MetroFramework.Controls.MetroTextBox();
            this.btnBrowseFolder = new MetroFramework.Controls.MetroButton();
            this.metroRadioButtonFolder = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButtonFile = new MetroFramework.Controls.MetroRadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskInOut)).BeginInit();
            this.groupBoxFile.SuspendLayout();
            this.groupBoxFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(554, 135);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 36);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(554, 186);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 36);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTaskOut
            // 
            this.btnTaskOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskOut.Location = new System.Drawing.Point(554, 85);
            this.btnTaskOut.Name = "btnTaskOut";
            this.btnTaskOut.Size = new System.Drawing.Size(93, 36);
            this.btnTaskOut.TabIndex = 3;
            this.btnTaskOut.Text = "Task Out";
            this.btnTaskOut.UseSelectable = true;
            this.btnTaskOut.Click += new System.EventHandler(this.btnTaskOut_Click);
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
            this.dataGridViewTaskInOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewTaskInOut.EnableHeadersVisualStyles = false;
            this.dataGridViewTaskInOut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewTaskInOut.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTaskInOut.Location = new System.Drawing.Point(20, 244);
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
            this.dataGridViewTaskInOut.Size = new System.Drawing.Size(630, 180);
            this.dataGridViewTaskInOut.Style = MetroFramework.MetroColorStyle.Teal;
            this.dataGridViewTaskInOut.TabIndex = 304;
            this.dataGridViewTaskInOut.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewTaskInOut.UseCustomBackColor = true;
            this.dataGridViewTaskInOut.UseCustomForeColor = true;
            this.dataGridViewTaskInOut.UseStyleColors = true;
            this.dataGridViewTaskInOut.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewTaskInOut_CellFormatting);
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.AutoSize = true;
            this.lblUserMessage.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblUserMessage.Location = new System.Drawing.Point(50, 31);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(403, 19);
            this.lblUserMessage.TabIndex = 305;
            this.lblUserMessage.Text = "To finalize your task please select your folder/file to get byte size.";
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblHistory.Location = new System.Drawing.Point(20, 226);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(49, 15);
            this.lblHistory.TabIndex = 306;
            this.lblHistory.Text = "History: ";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(280, 173);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(38, 15);
            this.metroLabel2.TabIndex = 309;
            this.metroLabel2.Text = "Bytes";
            // 
            // txtSubTotal
            // 
            // 
            // 
            // 
            this.txtSubTotal.CustomButton.Image = null;
            this.txtSubTotal.CustomButton.Location = new System.Drawing.Point(135, 1);
            this.txtSubTotal.CustomButton.Name = "";
            this.txtSubTotal.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtSubTotal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSubTotal.CustomButton.TabIndex = 1;
            this.txtSubTotal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSubTotal.CustomButton.UseSelectable = true;
            this.txtSubTotal.CustomButton.Visible = false;
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtSubTotal.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtSubTotal.Lines = new string[0];
            this.txtSubTotal.Location = new System.Drawing.Point(114, 163);
            this.txtSubTotal.MaxLength = 32767;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.PasswordChar = '\0';
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSubTotal.SelectedText = "";
            this.txtSubTotal.SelectionLength = 0;
            this.txtSubTotal.SelectionStart = 0;
            this.txtSubTotal.ShortcutsEnabled = true;
            this.txtSubTotal.Size = new System.Drawing.Size(159, 25);
            this.txtSubTotal.TabIndex = 2;
            this.txtSubTotal.UseSelectable = true;
            this.txtSubTotal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSubTotal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(20, 168);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(85, 15);
            this.metroLabel3.TabIndex = 308;
            this.metroLabel3.Text = "Total File Size:";
            // 
            // lblPCP
            // 
            this.lblPCP.AutoSize = true;
            this.lblPCP.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblPCP.Location = new System.Drawing.Point(399, 140);
            this.lblPCP.Name = "lblPCP";
            this.lblPCP.Size = new System.Drawing.Size(28, 15);
            this.lblPCP.TabIndex = 310;
            this.lblPCP.Text = "PCP";
            this.lblPCP.Visible = false;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTask.Location = new System.Drawing.Point(399, 156);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(27, 15);
            this.lblTask.TabIndex = 311;
            this.lblTask.Text = "Task";
            this.lblTask.Visible = false;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblFileName.Location = new System.Drawing.Point(399, 171);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(70, 15);
            this.lblFileName.TabIndex = 312;
            this.lblFileName.Text = "FileFileName";
            this.lblFileName.Visible = false;
            // 
            // lblShipment
            // 
            this.lblShipment.AutoSize = true;
            this.lblShipment.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblShipment.Location = new System.Drawing.Point(399, 186);
            this.lblShipment.Name = "lblShipment";
            this.lblShipment.Size = new System.Drawing.Size(54, 15);
            this.lblShipment.TabIndex = 313;
            this.lblShipment.Text = "Shipment";
            this.lblShipment.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblStatus.Location = new System.Drawing.Point(399, 201);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 15);
            this.lblStatus.TabIndex = 314;
            this.lblStatus.Text = "Status";
            this.lblStatus.Visible = false;
            // 
            // lblFileSize2
            // 
            this.lblFileSize2.AutoSize = true;
            this.lblFileSize2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblFileSize2.Location = new System.Drawing.Point(399, 217);
            this.lblFileSize2.Name = "lblFileSize2";
            this.lblFileSize2.Size = new System.Drawing.Size(43, 15);
            this.lblFileSize2.TabIndex = 315;
            this.lblFileSize2.Text = "FileSize";
            this.lblFileSize2.Visible = false;
            // 
            // lblTaskOut
            // 
            this.lblTaskOut.AutoSize = true;
            this.lblTaskOut.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTaskOut.Location = new System.Drawing.Point(479, 140);
            this.lblTaskOut.Name = "lblTaskOut";
            this.lblTaskOut.Size = new System.Drawing.Size(46, 15);
            this.lblTaskOut.TabIndex = 316;
            this.lblTaskOut.Text = "TaskOut";
            this.lblTaskOut.Visible = false;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblHours.Location = new System.Drawing.Point(479, 155);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(37, 15);
            this.lblHours.TabIndex = 317;
            this.lblHours.Text = "Hours";
            this.lblHours.Visible = false;
            // 
            // lblProductivity
            // 
            this.lblProductivity.AutoSize = true;
            this.lblProductivity.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblProductivity.Location = new System.Drawing.Point(479, 170);
            this.lblProductivity.Name = "lblProductivity";
            this.lblProductivity.Size = new System.Drawing.Size(65, 15);
            this.lblProductivity.TabIndex = 318;
            this.lblProductivity.Text = "Productivity";
            this.lblProductivity.Visible = false;
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUID.Location = new System.Drawing.Point(479, 185);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(26, 15);
            this.lblUID.TabIndex = 319;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // lblMID
            // 
            this.lblMID.AutoSize = true;
            this.lblMID.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblMID.Location = new System.Drawing.Point(479, 200);
            this.lblMID.Name = "lblMID";
            this.lblMID.Size = new System.Drawing.Size(28, 15);
            this.lblMID.TabIndex = 320;
            this.lblMID.Text = "MID";
            this.lblMID.Visible = false;
            // 
            // lblPIC
            // 
            this.lblPIC.AutoSize = true;
            this.lblPIC.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblPIC.Location = new System.Drawing.Point(479, 215);
            this.lblPIC.Name = "lblPIC";
            this.lblPIC.Size = new System.Drawing.Size(24, 15);
            this.lblPIC.TabIndex = 321;
            this.lblPIC.Text = "PIC";
            this.lblPIC.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtPath
            // 
            // 
            // 
            // 
            this.txtPath.CustomButton.Image = null;
            this.txtPath.CustomButton.Location = new System.Drawing.Point(255, 1);
            this.txtPath.CustomButton.Name = "";
            this.txtPath.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPath.CustomButton.TabIndex = 1;
            this.txtPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPath.CustomButton.UseSelectable = true;
            this.txtPath.CustomButton.Visible = false;
            this.txtPath.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPath.Lines = new string[0];
            this.txtPath.Location = new System.Drawing.Point(75, 25);
            this.txtPath.MaxLength = 32767;
            this.txtPath.Name = "txtPath";
            this.txtPath.PasswordChar = '\0';
            this.txtPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPath.SelectedText = "";
            this.txtPath.SelectionLength = 0;
            this.txtPath.SelectionStart = 0;
            this.txtPath.ShortcutsEnabled = true;
            this.txtPath.Size = new System.Drawing.Size(279, 25);
            this.txtPath.TabIndex = 7;
            this.txtPath.UseSelectable = true;
            this.txtPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPath_KeyDown);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Location = new System.Drawing.Point(360, 22);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(50, 31);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseSelectable = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblBrowse
            // 
            this.lblBrowse.AutoSize = true;
            this.lblBrowse.Location = new System.Drawing.Point(11, 28);
            this.lblBrowse.Name = "lblBrowse";
            this.lblBrowse.Size = new System.Drawing.Size(58, 19);
            this.lblBrowse.TabIndex = 324;
            this.lblBrowse.Text = "Browse: ";
            // 
            // groupBoxFile
            // 
            this.groupBoxFile.Controls.Add(this.lblBrowse);
            this.groupBoxFile.Controls.Add(this.txtPath);
            this.groupBoxFile.Controls.Add(this.btnBrowse);
            this.groupBoxFile.Location = new System.Drawing.Point(40, 86);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(429, 69);
            this.groupBoxFile.TabIndex = 325;
            this.groupBoxFile.TabStop = false;
            this.groupBoxFile.Text = "Select a File:";
            // 
            // groupBoxFolder
            // 
            this.groupBoxFolder.Controls.Add(this.lblBrowseFolder);
            this.groupBoxFolder.Controls.Add(this.txtPathFolder);
            this.groupBoxFolder.Controls.Add(this.btnBrowseFolder);
            this.groupBoxFolder.Location = new System.Drawing.Point(40, 86);
            this.groupBoxFolder.Name = "groupBoxFolder";
            this.groupBoxFolder.Size = new System.Drawing.Size(429, 69);
            this.groupBoxFolder.TabIndex = 326;
            this.groupBoxFolder.TabStop = false;
            this.groupBoxFolder.Text = "Select Folder:";
            // 
            // lblBrowseFolder
            // 
            this.lblBrowseFolder.AutoSize = true;
            this.lblBrowseFolder.Location = new System.Drawing.Point(11, 28);
            this.lblBrowseFolder.Name = "lblBrowseFolder";
            this.lblBrowseFolder.Size = new System.Drawing.Size(58, 19);
            this.lblBrowseFolder.TabIndex = 324;
            this.lblBrowseFolder.Text = "Browse: ";
            // 
            // txtPathFolder
            // 
            // 
            // 
            // 
            this.txtPathFolder.CustomButton.Image = null;
            this.txtPathFolder.CustomButton.Location = new System.Drawing.Point(255, 1);
            this.txtPathFolder.CustomButton.Name = "";
            this.txtPathFolder.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPathFolder.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPathFolder.CustomButton.TabIndex = 1;
            this.txtPathFolder.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPathFolder.CustomButton.UseSelectable = true;
            this.txtPathFolder.CustomButton.Visible = false;
            this.txtPathFolder.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPathFolder.Lines = new string[0];
            this.txtPathFolder.Location = new System.Drawing.Point(75, 25);
            this.txtPathFolder.MaxLength = 32767;
            this.txtPathFolder.Name = "txtPathFolder";
            this.txtPathFolder.PasswordChar = '\0';
            this.txtPathFolder.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPathFolder.SelectedText = "";
            this.txtPathFolder.SelectionLength = 0;
            this.txtPathFolder.SelectionStart = 0;
            this.txtPathFolder.ShortcutsEnabled = true;
            this.txtPathFolder.Size = new System.Drawing.Size(279, 25);
            this.txtPathFolder.TabIndex = 7;
            this.txtPathFolder.UseSelectable = true;
            this.txtPathFolder.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPathFolder.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPathFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPathFolder_KeyDown);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseFolder.Location = new System.Drawing.Point(360, 22);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(50, 31);
            this.btnBrowseFolder.TabIndex = 1;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseSelectable = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // metroRadioButtonFolder
            // 
            this.metroRadioButtonFolder.AutoSize = true;
            this.metroRadioButtonFolder.Location = new System.Drawing.Point(157, 63);
            this.metroRadioButtonFolder.Name = "metroRadioButtonFolder";
            this.metroRadioButtonFolder.Size = new System.Drawing.Size(56, 15);
            this.metroRadioButtonFolder.TabIndex = 326;
            this.metroRadioButtonFolder.Text = "Folder";
            this.metroRadioButtonFolder.UseSelectable = true;
            this.metroRadioButtonFolder.CheckedChanged += new System.EventHandler(this.metroRadioButtonFolder_CheckedChanged);
            // 
            // metroRadioButtonFile
            // 
            this.metroRadioButtonFile.AutoSize = true;
            this.metroRadioButtonFile.Location = new System.Drawing.Point(330, 63);
            this.metroRadioButtonFile.Name = "metroRadioButtonFile";
            this.metroRadioButtonFile.Size = new System.Drawing.Size(89, 15);
            this.metroRadioButtonFile.TabIndex = 327;
            this.metroRadioButtonFile.Text = "File (default)";
            this.metroRadioButtonFile.UseSelectable = true;
            this.metroRadioButtonFile.CheckedChanged += new System.EventHandler(this.metroRadioButtonFile_CheckedChanged);
            // 
            // frm_DoneByteSizeFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 444);
            this.Controls.Add(this.groupBoxFolder);
            this.Controls.Add(this.metroRadioButtonFile);
            this.Controls.Add(this.metroRadioButtonFolder);
            this.Controls.Add(this.groupBoxFile);
            this.Controls.Add(this.lblPIC);
            this.Controls.Add(this.lblMID);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.lblProductivity);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.lblTaskOut);
            this.Controls.Add(this.lblFileSize2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblShipment);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.lblPCP);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.dataGridViewTaskInOut);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnTaskOut);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DoneByteSizeFile";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frm_DoneByteSizeFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskInOut)).EndInit();
            this.groupBoxFile.ResumeLayout(false);
            this.groupBoxFile.PerformLayout();
            this.groupBoxFolder.ResumeLayout(false);
            this.groupBoxFolder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnTaskOut;
        private MetroFramework.Controls.MetroGrid dataGridViewTaskInOut;
        private MetroFramework.Controls.MetroLabel lblUserMessage;
        private MetroFramework.Controls.MetroLabel lblHistory;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtSubTotal;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lblPCP;
        private MetroFramework.Controls.MetroLabel lblTask;
        private MetroFramework.Controls.MetroLabel lblFileName;
        private MetroFramework.Controls.MetroLabel lblShipment;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private MetroFramework.Controls.MetroLabel lblFileSize2;
        private MetroFramework.Controls.MetroLabel lblTaskOut;
        private MetroFramework.Controls.MetroLabel lblHours;
        private MetroFramework.Controls.MetroLabel lblProductivity;
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroLabel lblMID;
        private MetroFramework.Controls.MetroLabel lblPIC;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroTextBox txtPath;
        private MetroFramework.Controls.MetroButton btnBrowse;
        private MetroFramework.Controls.MetroLabel lblBrowse;
        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.GroupBox groupBoxFolder;
        private MetroFramework.Controls.MetroLabel lblBrowseFolder;
        private MetroFramework.Controls.MetroTextBox txtPathFolder;
        private MetroFramework.Controls.MetroButton btnBrowseFolder;
        private MetroFramework.Controls.MetroRadioButton metroRadioButtonFolder;
        private MetroFramework.Controls.MetroRadioButton metroRadioButtonFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}