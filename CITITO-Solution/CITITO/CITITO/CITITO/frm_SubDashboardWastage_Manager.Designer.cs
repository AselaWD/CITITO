namespace CITITO
{
    partial class frm_SubDashboardWastage_Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SubDashboardWastage_Manager));
            this.dataGridViewUserWastageSummary = new MetroFramework.Controls.MetroGrid();
            this.pnlHeader = new MetroFramework.Controls.MetroPanel();
            this.btnClrAll = new MetroFramework.Controls.MetroButton();
            this.cmbMUID = new MetroFramework.Controls.MetroComboBox();
            this.btnGo = new MetroFramework.Controls.MetroButton();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.dash = new MetroFramework.Controls.MetroLabel();
            this.cmbUID = new MetroFramework.Controls.MetroComboBox();
            this.metroDateTime1To = new MetroFramework.Controls.MetroDateTime();
            this.metroDateTime1From = new MetroFramework.Controls.MetroDateTime();
            this.lblPICToFill = new MetroFramework.Controls.MetroLabel();
            this.lblUIDToFill = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnViewAll = new MetroFramework.Controls.MetroButton();
            this.lblTaskAndQuotaDes = new MetroFramework.Controls.MetroLabel();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserWastageSummary)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUserWastageSummary
            // 
            this.dataGridViewUserWastageSummary.AllowUserToAddRows = false;
            this.dataGridViewUserWastageSummary.AllowUserToDeleteRows = false;
            this.dataGridViewUserWastageSummary.AllowUserToResizeRows = false;
            this.dataGridViewUserWastageSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUserWastageSummary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewUserWastageSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUserWastageSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewUserWastageSummary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUserWastageSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewUserWastageSummary.ColumnHeadersHeight = 30;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUserWastageSummary.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewUserWastageSummary.EnableHeadersVisualStyles = false;
            this.dataGridViewUserWastageSummary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewUserWastageSummary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewUserWastageSummary.Location = new System.Drawing.Point(17, 76);
            this.dataGridViewUserWastageSummary.MultiSelect = false;
            this.dataGridViewUserWastageSummary.Name = "dataGridViewUserWastageSummary";
            this.dataGridViewUserWastageSummary.ReadOnly = true;
            this.dataGridViewUserWastageSummary.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUserWastageSummary.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewUserWastageSummary.RowHeadersVisible = false;
            this.dataGridViewUserWastageSummary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewUserWastageSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserWastageSummary.Size = new System.Drawing.Size(1152, 679);
            this.dataGridViewUserWastageSummary.Style = MetroFramework.MetroColorStyle.Blue;
            this.dataGridViewUserWastageSummary.TabIndex = 337;
            this.dataGridViewUserWastageSummary.UseCustomBackColor = true;
            this.dataGridViewUserWastageSummary.UseCustomForeColor = true;
            this.dataGridViewUserWastageSummary.UseStyleColors = true;
            this.dataGridViewUserWastageSummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUserWastageSummary_CellContentClick);
            this.dataGridViewUserWastageSummary.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUserWastageSummary_CellDoubleClick);
            this.dataGridViewUserWastageSummary.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewUserWastageSummary_CellFormatting);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.btnClrAll);
            this.pnlHeader.Controls.Add(this.cmbMUID);
            this.pnlHeader.Controls.Add(this.btnGo);
            this.pnlHeader.Controls.Add(this.btnClear);
            this.pnlHeader.Controls.Add(this.dash);
            this.pnlHeader.Controls.Add(this.cmbUID);
            this.pnlHeader.Controls.Add(this.metroDateTime1To);
            this.pnlHeader.Controls.Add(this.metroDateTime1From);
            this.pnlHeader.Controls.Add(this.lblPICToFill);
            this.pnlHeader.Controls.Add(this.lblUIDToFill);
            this.pnlHeader.HorizontalScrollbarBarColor = true;
            this.pnlHeader.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlHeader.HorizontalScrollbarSize = 10;
            this.pnlHeader.Location = new System.Drawing.Point(-3, -1);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1300, 32);
            this.pnlHeader.TabIndex = 336;
            this.pnlHeader.UseCustomBackColor = true;
            this.pnlHeader.VerticalScrollbarBarColor = true;
            this.pnlHeader.VerticalScrollbarHighlightOnWheel = false;
            this.pnlHeader.VerticalScrollbarSize = 10;
            // 
            // btnClrAll
            // 
            this.btnClrAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClrAll.Location = new System.Drawing.Point(1219, 2);
            this.btnClrAll.Name = "btnClrAll";
            this.btnClrAll.Size = new System.Drawing.Size(76, 29);
            this.btnClrAll.Style = MetroFramework.MetroColorStyle.Red;
            this.btnClrAll.TabIndex = 203;
            this.btnClrAll.Text = "Clear All";
            this.btnClrAll.UseSelectable = true;
            this.btnClrAll.UseStyleColors = true;
            this.btnClrAll.Click += new System.EventHandler(this.btnClrAll_Click);
            // 
            // cmbMUID
            // 
            this.cmbMUID.Enabled = false;
            this.cmbMUID.FormattingEnabled = true;
            this.cmbMUID.ItemHeight = 23;
            this.cmbMUID.Location = new System.Drawing.Point(62, 2);
            this.cmbMUID.Name = "cmbMUID";
            this.cmbMUID.PromptText = "Team";
            this.cmbMUID.Size = new System.Drawing.Size(104, 29);
            this.cmbMUID.TabIndex = 1;
            this.cmbMUID.UseSelectable = true;
            // 
            // btnGo
            // 
            this.btnGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGo.Location = new System.Drawing.Point(918, 2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(37, 29);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseSelectable = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(306, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 29);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear Filter";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dash
            // 
            this.dash.AutoSize = true;
            this.dash.Location = new System.Drawing.Point(758, 7);
            this.dash.Name = "dash";
            this.dash.Size = new System.Drawing.Size(15, 19);
            this.dash.TabIndex = 189;
            this.dash.Text = "-";
            this.dash.UseCustomBackColor = true;
            // 
            // cmbUID
            // 
            this.cmbUID.FormattingEnabled = true;
            this.cmbUID.ItemHeight = 23;
            this.cmbUID.Location = new System.Drawing.Point(184, 2);
            this.cmbUID.Name = "cmbUID";
            this.cmbUID.PromptText = "User";
            this.cmbUID.Size = new System.Drawing.Size(104, 29);
            this.cmbUID.TabIndex = 2;
            this.cmbUID.UseSelectable = true;
            this.cmbUID.SelectedIndexChanged += new System.EventHandler(this.cmbUID_SelectedIndexChanged);
            // 
            // metroDateTime1To
            // 
            this.metroDateTime1To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime1To.Location = new System.Drawing.Point(777, 2);
            this.metroDateTime1To.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1To.Name = "metroDateTime1To";
            this.metroDateTime1To.Size = new System.Drawing.Size(135, 29);
            this.metroDateTime1To.TabIndex = 5;
            // 
            // metroDateTime1From
            // 
            this.metroDateTime1From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime1From.Location = new System.Drawing.Point(618, 2);
            this.metroDateTime1From.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1From.Name = "metroDateTime1From";
            this.metroDateTime1From.Size = new System.Drawing.Size(135, 29);
            this.metroDateTime1From.TabIndex = 4;
            // 
            // lblPICToFill
            // 
            this.lblPICToFill.AutoSize = true;
            this.lblPICToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblPICToFill.Location = new System.Drawing.Point(8, 0);
            this.lblPICToFill.Name = "lblPICToFill";
            this.lblPICToFill.Size = new System.Drawing.Size(24, 15);
            this.lblPICToFill.TabIndex = 183;
            this.lblPICToFill.Text = "PIC";
            this.lblPICToFill.Visible = false;
            // 
            // lblUIDToFill
            // 
            this.lblUIDToFill.AutoSize = true;
            this.lblUIDToFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUIDToFill.Location = new System.Drawing.Point(9, 15);
            this.lblUIDToFill.Name = "lblUIDToFill";
            this.lblUIDToFill.Size = new System.Drawing.Size(26, 15);
            this.lblUIDToFill.TabIndex = 182;
            this.lblUIDToFill.Text = "UID";
            this.lblUIDToFill.Visible = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(1228, 43);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 340;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewAll.Location = new System.Drawing.Point(1175, 363);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(102, 36);
            this.btnViewAll.Style = MetroFramework.MetroColorStyle.Green;
            this.btnViewAll.TabIndex = 335;
            this.btnViewAll.Text = "View Data Set";
            this.btnViewAll.UseSelectable = true;
            this.btnViewAll.UseStyleColors = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // lblTaskAndQuotaDes
            // 
            this.lblTaskAndQuotaDes.AutoSize = true;
            this.lblTaskAndQuotaDes.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTaskAndQuotaDes.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTaskAndQuotaDes.Location = new System.Drawing.Point(17, 48);
            this.lblTaskAndQuotaDes.Name = "lblTaskAndQuotaDes";
            this.lblTaskAndQuotaDes.Size = new System.Drawing.Size(257, 25);
            this.lblTaskAndQuotaDes.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblTaskAndQuotaDes.TabIndex = 338;
            this.lblTaskAndQuotaDes.Text = "Summary of IDLE && Wastage";
            this.lblTaskAndQuotaDes.UseStyleColors = true;
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.BackColor = System.Drawing.Color.Transparent;
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(1248, 61);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(36, 29);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 339;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.Tag = "Export As Excel";
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // frm_SubDashboardWastage_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 755);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewUserWastageSummary);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.pBoxExportExcel);
            this.Controls.Add(this.lblTaskAndQuotaDes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Movable = false;
            this.Name = "frm_SubDashboardWastage_Manager";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Load += new System.EventHandler(this.frm_SubDashboardWastage_Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserWastageSummary)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid dataGridViewUserWastageSummary;
        private MetroFramework.Controls.MetroPanel pnlHeader;
        private MetroFramework.Controls.MetroButton btnClrAll;
        private MetroFramework.Controls.MetroComboBox cmbMUID;
        private MetroFramework.Controls.MetroButton btnGo;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroLabel dash;
        private MetroFramework.Controls.MetroComboBox cmbUID;
        private MetroFramework.Controls.MetroDateTime metroDateTime1To;
        private MetroFramework.Controls.MetroDateTime metroDateTime1From;
        private MetroFramework.Controls.MetroLabel lblPICToFill;
        private MetroFramework.Controls.MetroLabel lblUIDToFill;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnViewAll;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
        private MetroFramework.Controls.MetroLabel lblTaskAndQuotaDes;
    }
}