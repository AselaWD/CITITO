namespace CITITO
{
    partial class frm_SubDashboardWorkLoadDataSet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SubDashboardWorkLoadDataSet));
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dataGridViewWorkloadSummary = new MetroFramework.Controls.MetroGrid();
            this.btnClrAll = new MetroFramework.Controls.MetroButton();
            this.btnGo = new MetroFramework.Controls.MetroButton();
            this.lblPICToFill = new MetroFramework.Controls.MetroLabel();
            this.lblUIDToFill = new MetroFramework.Controls.MetroLabel();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.lblWorkLoadDes = new MetroFramework.Controls.MetroLabel();
            this.dash = new MetroFramework.Controls.MetroLabel();
            this.metroDateTime1To = new MetroFramework.Controls.MetroDateTime();
            this.metroDateTime1From = new MetroFramework.Controls.MetroDateTime();
            this.pnlHeader = new MetroFramework.Controls.MetroPanel();
            this.btnFilterGo = new MetroFramework.Controls.MetroButton();
            this.cmbStatus = new MetroFramework.Controls.MetroComboBox();
            this.txtFileName = new MetroFramework.Controls.MetroTextBox();
            this.txtShipment = new MetroFramework.Controls.MetroTextBox();
            this.cmbProject = new MetroFramework.Controls.MetroComboBox();
            this.btnBackToWL = new MetroFramework.Controls.MetroButton();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkloadSummary)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(1232, 41);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 334;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            // 
            // dataGridViewWorkloadSummary
            // 
            this.dataGridViewWorkloadSummary.AllowUserToAddRows = false;
            this.dataGridViewWorkloadSummary.AllowUserToDeleteRows = false;
            this.dataGridViewWorkloadSummary.AllowUserToResizeRows = false;
            this.dataGridViewWorkloadSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWorkloadSummary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewWorkloadSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewWorkloadSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewWorkloadSummary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewWorkloadSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewWorkloadSummary.ColumnHeadersHeight = 40;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewWorkloadSummary.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewWorkloadSummary.EnableHeadersVisualStyles = false;
            this.dataGridViewWorkloadSummary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewWorkloadSummary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewWorkloadSummary.Location = new System.Drawing.Point(14, 78);
            this.dataGridViewWorkloadSummary.Name = "dataGridViewWorkloadSummary";
            this.dataGridViewWorkloadSummary.ReadOnly = true;
            this.dataGridViewWorkloadSummary.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewWorkloadSummary.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewWorkloadSummary.RowHeadersVisible = false;
            this.dataGridViewWorkloadSummary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewWorkloadSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWorkloadSummary.Size = new System.Drawing.Size(1142, 665);
            this.dataGridViewWorkloadSummary.Style = MetroFramework.MetroColorStyle.Teal;
            this.dataGridViewWorkloadSummary.TabIndex = 332;
            this.dataGridViewWorkloadSummary.UseCustomBackColor = true;
            this.dataGridViewWorkloadSummary.UseCustomForeColor = true;
            this.dataGridViewWorkloadSummary.UseStyleColors = true;
            this.dataGridViewWorkloadSummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWorkloadSummary_CellContentClick);
            this.dataGridViewWorkloadSummary.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWorkloadSummary_CellDoubleClick);
            this.dataGridViewWorkloadSummary.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewWorkloadSummary_CellFormatting);
            // 
            // btnClrAll
            // 
            this.btnClrAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClrAll.Location = new System.Drawing.Point(1218, 2);
            this.btnClrAll.Name = "btnClrAll";
            this.btnClrAll.Size = new System.Drawing.Size(76, 29);
            this.btnClrAll.Style = MetroFramework.MetroColorStyle.Red;
            this.btnClrAll.TabIndex = 196;
            this.btnClrAll.Text = "Clear All";
            this.btnClrAll.UseSelectable = true;
            this.btnClrAll.UseStyleColors = true;
            this.btnClrAll.Click += new System.EventHandler(this.btnClrAll_Click);
            // 
            // btnGo
            // 
            this.btnGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGo.Location = new System.Drawing.Point(1151, 2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(37, 29);
            this.btnGo.TabIndex = 195;
            this.btnGo.Text = "Go";
            this.btnGo.UseSelectable = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblPICToFill
            // 
            this.lblPICToFill.AutoSize = true;
            this.lblPICToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblPICToFill.Location = new System.Drawing.Point(12, 0);
            this.lblPICToFill.Name = "lblPICToFill";
            this.lblPICToFill.Size = new System.Drawing.Size(24, 15);
            this.lblPICToFill.TabIndex = 192;
            this.lblPICToFill.Text = "PIC";
            this.lblPICToFill.Visible = false;
            // 
            // lblUIDToFill
            // 
            this.lblUIDToFill.AutoSize = true;
            this.lblUIDToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUIDToFill.Location = new System.Drawing.Point(13, 15);
            this.lblUIDToFill.Name = "lblUIDToFill";
            this.lblUIDToFill.Size = new System.Drawing.Size(26, 15);
            this.lblUIDToFill.TabIndex = 191;
            this.lblUIDToFill.Text = "UID";
            this.lblUIDToFill.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(712, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 29);
            this.btnClear.TabIndex = 190;
            this.btnClear.Text = "Clear Filter";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblWorkLoadDes
            // 
            this.lblWorkLoadDes.AutoSize = true;
            this.lblWorkLoadDes.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblWorkLoadDes.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblWorkLoadDes.Location = new System.Drawing.Point(11, 50);
            this.lblWorkLoadDes.Name = "lblWorkLoadDes";
            this.lblWorkLoadDes.Size = new System.Drawing.Size(181, 25);
            this.lblWorkLoadDes.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblWorkLoadDes.TabIndex = 335;
            this.lblWorkLoadDes.Text = "Workload (DataSet)";
            this.lblWorkLoadDes.UseStyleColors = true;
            // 
            // dash
            // 
            this.dash.AutoSize = true;
            this.dash.Location = new System.Drawing.Point(991, 7);
            this.dash.Name = "dash";
            this.dash.Size = new System.Drawing.Size(15, 19);
            this.dash.TabIndex = 189;
            this.dash.Text = "-";
            this.dash.UseCustomBackColor = true;
            // 
            // metroDateTime1To
            // 
            this.metroDateTime1To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime1To.Location = new System.Drawing.Point(1010, 2);
            this.metroDateTime1To.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1To.Name = "metroDateTime1To";
            this.metroDateTime1To.Size = new System.Drawing.Size(135, 29);
            this.metroDateTime1To.TabIndex = 185;
            // 
            // metroDateTime1From
            // 
            this.metroDateTime1From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime1From.Location = new System.Drawing.Point(851, 2);
            this.metroDateTime1From.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1From.Name = "metroDateTime1From";
            this.metroDateTime1From.Size = new System.Drawing.Size(135, 29);
            this.metroDateTime1From.TabIndex = 184;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.btnFilterGo);
            this.pnlHeader.Controls.Add(this.cmbStatus);
            this.pnlHeader.Controls.Add(this.txtFileName);
            this.pnlHeader.Controls.Add(this.txtShipment);
            this.pnlHeader.Controls.Add(this.btnClrAll);
            this.pnlHeader.Controls.Add(this.btnGo);
            this.pnlHeader.Controls.Add(this.lblPICToFill);
            this.pnlHeader.Controls.Add(this.lblUIDToFill);
            this.pnlHeader.Controls.Add(this.btnClear);
            this.pnlHeader.Controls.Add(this.dash);
            this.pnlHeader.Controls.Add(this.cmbProject);
            this.pnlHeader.Controls.Add(this.metroDateTime1To);
            this.pnlHeader.Controls.Add(this.metroDateTime1From);
            this.pnlHeader.HorizontalScrollbarBarColor = true;
            this.pnlHeader.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlHeader.HorizontalScrollbarSize = 10;
            this.pnlHeader.Location = new System.Drawing.Point(-3, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1300, 32);
            this.pnlHeader.TabIndex = 331;
            this.pnlHeader.UseCustomBackColor = true;
            this.pnlHeader.VerticalScrollbarBarColor = true;
            this.pnlHeader.VerticalScrollbarHighlightOnWheel = false;
            this.pnlHeader.VerticalScrollbarSize = 10;
            // 
            // btnFilterGo
            // 
            this.btnFilterGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterGo.Location = new System.Drawing.Point(632, 2);
            this.btnFilterGo.Name = "btnFilterGo";
            this.btnFilterGo.Size = new System.Drawing.Size(58, 29);
            this.btnFilterGo.TabIndex = 200;
            this.btnFilterGo.Text = "Filter";
            this.btnFilterGo.UseSelectable = true;
            this.btnFilterGo.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.ItemHeight = 23;
            this.cmbStatus.Items.AddRange(new object[] {
            "",
            "Fresh",
            "In-Process",
            "Done",
            "Hold"});
            this.cmbStatus.Location = new System.Drawing.Point(521, 2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.PromptText = "Status";
            this.cmbStatus.Size = new System.Drawing.Size(104, 29);
            this.cmbStatus.TabIndex = 199;
            this.cmbStatus.UseSelectable = true;
            // 
            // txtFileName
            // 
            // 
            // 
            // 
            this.txtFileName.CustomButton.Image = null;
            this.txtFileName.CustomButton.Location = new System.Drawing.Point(145, 1);
            this.txtFileName.CustomButton.Name = "";
            this.txtFileName.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtFileName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFileName.CustomButton.TabIndex = 1;
            this.txtFileName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFileName.CustomButton.UseSelectable = true;
            this.txtFileName.CustomButton.Visible = false;
            this.txtFileName.Lines = new string[0];
            this.txtFileName.Location = new System.Drawing.Point(341, 2);
            this.txtFileName.MaxLength = 32767;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.PasswordChar = '\0';
            this.txtFileName.PromptText = "File Name";
            this.txtFileName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFileName.SelectedText = "";
            this.txtFileName.SelectionLength = 0;
            this.txtFileName.SelectionStart = 0;
            this.txtFileName.ShortcutsEnabled = true;
            this.txtFileName.Size = new System.Drawing.Size(173, 29);
            this.txtFileName.TabIndex = 198;
            this.txtFileName.UseSelectable = true;
            this.txtFileName.WaterMark = "File Name";
            this.txtFileName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFileName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFileName_KeyDown);
            this.txtFileName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtFileName_MouseClick);
            // 
            // txtShipment
            // 
            // 
            // 
            // 
            this.txtShipment.CustomButton.Image = null;
            this.txtShipment.CustomButton.Location = new System.Drawing.Point(145, 1);
            this.txtShipment.CustomButton.Name = "";
            this.txtShipment.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtShipment.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtShipment.CustomButton.TabIndex = 1;
            this.txtShipment.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtShipment.CustomButton.UseSelectable = true;
            this.txtShipment.CustomButton.Visible = false;
            this.txtShipment.Lines = new string[0];
            this.txtShipment.Location = new System.Drawing.Point(161, 2);
            this.txtShipment.MaxLength = 32767;
            this.txtShipment.Name = "txtShipment";
            this.txtShipment.PasswordChar = '\0';
            this.txtShipment.PromptText = "Shipment";
            this.txtShipment.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtShipment.SelectedText = "";
            this.txtShipment.SelectionLength = 0;
            this.txtShipment.SelectionStart = 0;
            this.txtShipment.ShortcutsEnabled = true;
            this.txtShipment.Size = new System.Drawing.Size(173, 29);
            this.txtShipment.TabIndex = 197;
            this.txtShipment.UseSelectable = true;
            this.txtShipment.WaterMark = "Shipment";
            this.txtShipment.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtShipment.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShipment_KeyDown);
            this.txtShipment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtShipment_MouseClick);
            // 
            // cmbProject
            // 
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.ItemHeight = 23;
            this.cmbProject.Location = new System.Drawing.Point(50, 2);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.PromptText = "Project";
            this.cmbProject.Size = new System.Drawing.Size(104, 29);
            this.cmbProject.TabIndex = 187;
            this.cmbProject.UseSelectable = true;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            this.cmbProject.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbProject_MouseClick);
            // 
            // btnBackToWL
            // 
            this.btnBackToWL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToWL.Location = new System.Drawing.Point(1168, 366);
            this.btnBackToWL.Name = "btnBackToWL";
            this.btnBackToWL.Size = new System.Drawing.Size(115, 36);
            this.btnBackToWL.Style = MetroFramework.MetroColorStyle.Green;
            this.btnBackToWL.TabIndex = 336;
            this.btnBackToWL.Text = "Back to Workload";
            this.btnBackToWL.UseSelectable = true;
            this.btnBackToWL.UseStyleColors = true;
            this.btnBackToWL.Click += new System.EventHandler(this.btnBackToWL_Click);
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(1250, 59);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(38, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 333;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // frm_SubDashboardWorkLoadDataSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 755);
            this.ControlBox = false;
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.dataGridViewWorkloadSummary);
            this.Controls.Add(this.lblWorkLoadDes);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnBackToWL);
            this.Controls.Add(this.pBoxExportExcel);
            this.Movable = false;
            this.Name = "frm_SubDashboardWorkLoadDataSet";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Load += new System.EventHandler(this.frm_SubDashboardWorkLoadDataSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkloadSummary)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroGrid dataGridViewWorkloadSummary;
        private MetroFramework.Controls.MetroButton btnClrAll;
        private MetroFramework.Controls.MetroButton btnGo;
        private MetroFramework.Controls.MetroLabel lblPICToFill;
        private MetroFramework.Controls.MetroLabel lblUIDToFill;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroLabel lblWorkLoadDes;
        private MetroFramework.Controls.MetroLabel dash;
        private MetroFramework.Controls.MetroDateTime metroDateTime1To;
        private MetroFramework.Controls.MetroDateTime metroDateTime1From;
        private MetroFramework.Controls.MetroPanel pnlHeader;
        private MetroFramework.Controls.MetroComboBox cmbProject;
        private MetroFramework.Controls.MetroButton btnBackToWL;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
        private MetroFramework.Controls.MetroTextBox txtFileName;
        private MetroFramework.Controls.MetroTextBox txtShipment;
        private MetroFramework.Controls.MetroComboBox cmbStatus;
        private MetroFramework.Controls.MetroButton btnFilterGo;
    }
}