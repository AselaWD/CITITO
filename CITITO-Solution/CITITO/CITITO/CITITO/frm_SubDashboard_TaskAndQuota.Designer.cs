namespace CITITO
{
    partial class frm_SubDashboard_TaskAndQuota
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SubDashboard_TaskAndQuota));
            this.pnlHeader = new MetroFramework.Controls.MetroPanel();
            this.btnGo = new MetroFramework.Controls.MetroButton();
            this.lblPICToFill = new MetroFramework.Controls.MetroLabel();
            this.lblUIDToFill = new MetroFramework.Controls.MetroLabel();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.dash = new MetroFramework.Controls.MetroLabel();
            this.cmbTaskCode = new MetroFramework.Controls.MetroComboBox();
            this.cmbProject = new MetroFramework.Controls.MetroComboBox();
            this.cmbItemCode = new MetroFramework.Controls.MetroComboBox();
            this.metroDateTime1To = new MetroFramework.Controls.MetroDateTime();
            this.metroDateTime1From = new MetroFramework.Controls.MetroDateTime();
            this.dataGridViewTaskAndQuota = new MetroFramework.Controls.MetroGrid();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lblTaskAndQuotaDes = new MetroFramework.Controls.MetroLabel();
            this.btnViewAll = new MetroFramework.Controls.MetroButton();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.btnClrAll = new MetroFramework.Controls.MetroButton();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskAndQuota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.btnClrAll);
            this.pnlHeader.Controls.Add(this.btnGo);
            this.pnlHeader.Controls.Add(this.lblPICToFill);
            this.pnlHeader.Controls.Add(this.lblUIDToFill);
            this.pnlHeader.Controls.Add(this.btnClear);
            this.pnlHeader.Controls.Add(this.dash);
            this.pnlHeader.Controls.Add(this.cmbTaskCode);
            this.pnlHeader.Controls.Add(this.cmbProject);
            this.pnlHeader.Controls.Add(this.cmbItemCode);
            this.pnlHeader.Controls.Add(this.metroDateTime1To);
            this.pnlHeader.Controls.Add(this.metroDateTime1From);
            this.pnlHeader.HorizontalScrollbarBarColor = true;
            this.pnlHeader.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlHeader.HorizontalScrollbarSize = 10;
            this.pnlHeader.Location = new System.Drawing.Point(0, -1);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1300, 32);
            this.pnlHeader.TabIndex = 186;
            this.pnlHeader.UseCustomBackColor = true;
            this.pnlHeader.VerticalScrollbarBarColor = true;
            this.pnlHeader.VerticalScrollbarHighlightOnWheel = false;
            this.pnlHeader.VerticalScrollbarSize = 10;
            // 
            // btnGo
            // 
            this.btnGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGo.Location = new System.Drawing.Point(981, 2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(37, 29);
            this.btnGo.TabIndex = 193;
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
            this.btnClear.Location = new System.Drawing.Point(427, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 29);
            this.btnClear.TabIndex = 190;
            this.btnClear.Text = "Clear Filter";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dash
            // 
            this.dash.AutoSize = true;
            this.dash.Location = new System.Drawing.Point(808, 7);
            this.dash.Name = "dash";
            this.dash.Size = new System.Drawing.Size(15, 19);
            this.dash.TabIndex = 189;
            this.dash.Text = "-";
            this.dash.UseCustomBackColor = true;
            // 
            // cmbTaskCode
            // 
            this.cmbTaskCode.FormattingEnabled = true;
            this.cmbTaskCode.ItemHeight = 23;
            this.cmbTaskCode.Location = new System.Drawing.Point(304, 2);
            this.cmbTaskCode.Name = "cmbTaskCode";
            this.cmbTaskCode.PromptText = "Task Code";
            this.cmbTaskCode.Size = new System.Drawing.Size(104, 29);
            this.cmbTaskCode.TabIndex = 188;
            this.cmbTaskCode.UseSelectable = true;
            this.cmbTaskCode.SelectedIndexChanged += new System.EventHandler(this.cmbTaskCode_SelectedIndexChanged);
            this.cmbTaskCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbTaskCode_MouseClick);
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
            // cmbItemCode
            // 
            this.cmbItemCode.FormattingEnabled = true;
            this.cmbItemCode.ItemHeight = 23;
            this.cmbItemCode.Location = new System.Drawing.Point(177, 2);
            this.cmbItemCode.Name = "cmbItemCode";
            this.cmbItemCode.PromptText = "Item Code";
            this.cmbItemCode.Size = new System.Drawing.Size(104, 29);
            this.cmbItemCode.TabIndex = 186;
            this.cmbItemCode.UseSelectable = true;
            this.cmbItemCode.SelectedIndexChanged += new System.EventHandler(this.cmbItemCode_SelectedIndexChanged);
            this.cmbItemCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbItemCode_MouseClick);
            // 
            // metroDateTime1To
            // 
            this.metroDateTime1To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime1To.Location = new System.Drawing.Point(827, 2);
            this.metroDateTime1To.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1To.Name = "metroDateTime1To";
            this.metroDateTime1To.Size = new System.Drawing.Size(135, 29);
            this.metroDateTime1To.TabIndex = 185;
            // 
            // metroDateTime1From
            // 
            this.metroDateTime1From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime1From.Location = new System.Drawing.Point(668, 2);
            this.metroDateTime1From.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1From.Name = "metroDateTime1From";
            this.metroDateTime1From.Size = new System.Drawing.Size(135, 29);
            this.metroDateTime1From.TabIndex = 184;
            // 
            // dataGridViewTaskAndQuota
            // 
            this.dataGridViewTaskAndQuota.AllowUserToAddRows = false;
            this.dataGridViewTaskAndQuota.AllowUserToDeleteRows = false;
            this.dataGridViewTaskAndQuota.AllowUserToResizeRows = false;
            this.dataGridViewTaskAndQuota.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTaskAndQuota.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTaskAndQuota.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTaskAndQuota.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewTaskAndQuota.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTaskAndQuota.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTaskAndQuota.ColumnHeadersHeight = 40;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTaskAndQuota.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTaskAndQuota.EnableHeadersVisualStyles = false;
            this.dataGridViewTaskAndQuota.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewTaskAndQuota.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTaskAndQuota.Location = new System.Drawing.Point(12, 91);
            this.dataGridViewTaskAndQuota.Name = "dataGridViewTaskAndQuota";
            this.dataGridViewTaskAndQuota.ReadOnly = true;
            this.dataGridViewTaskAndQuota.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTaskAndQuota.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTaskAndQuota.RowHeadersVisible = false;
            this.dataGridViewTaskAndQuota.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTaskAndQuota.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTaskAndQuota.Size = new System.Drawing.Size(1156, 665);
            this.dataGridViewTaskAndQuota.Style = MetroFramework.MetroColorStyle.Blue;
            this.dataGridViewTaskAndQuota.TabIndex = 234;
            this.dataGridViewTaskAndQuota.UseCustomBackColor = true;
            this.dataGridViewTaskAndQuota.UseCustomForeColor = true;
            this.dataGridViewTaskAndQuota.UseStyleColors = true;
            this.dataGridViewTaskAndQuota.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTaskAndQuota_CellContentClick);
            this.dataGridViewTaskAndQuota.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTaskAndQuota_CellDoubleClick);
            this.dataGridViewTaskAndQuota.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewTaskAndQuota_CellFormatting);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(1218, 40);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 301;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            // 
            // lblTaskAndQuotaDes
            // 
            this.lblTaskAndQuotaDes.AutoSize = true;
            this.lblTaskAndQuotaDes.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTaskAndQuotaDes.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTaskAndQuotaDes.Location = new System.Drawing.Point(14, 49);
            this.lblTaskAndQuotaDes.Name = "lblTaskAndQuotaDes";
            this.lblTaskAndQuotaDes.Size = new System.Drawing.Size(149, 25);
            this.lblTaskAndQuotaDes.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblTaskAndQuotaDes.TabIndex = 302;
            this.lblTaskAndQuotaDes.Text = "Task and Quota ";
            this.lblTaskAndQuotaDes.UseStyleColors = true;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewAll.Location = new System.Drawing.Point(1181, 383);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(102, 36);
            this.btnViewAll.Style = MetroFramework.MetroColorStyle.Green;
            this.btnViewAll.TabIndex = 303;
            this.btnViewAll.Text = "View Data Set";
            this.btnViewAll.UseSelectable = true;
            this.btnViewAll.UseStyleColors = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(1236, 58);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(38, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 300;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // btnClrAll
            // 
            this.btnClrAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClrAll.Location = new System.Drawing.Point(1210, 2);
            this.btnClrAll.Name = "btnClrAll";
            this.btnClrAll.Size = new System.Drawing.Size(76, 29);
            this.btnClrAll.Style = MetroFramework.MetroColorStyle.Red;
            this.btnClrAll.TabIndex = 194;
            this.btnClrAll.Text = "Clear All";
            this.btnClrAll.UseSelectable = true;
            this.btnClrAll.UseStyleColors = true;
            this.btnClrAll.Click += new System.EventHandler(this.btnClrAll_Click);
            // 
            // frm_SubDashboard_TaskAndQuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 755);
            this.ControlBox = false;
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.lblTaskAndQuotaDes);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.pBoxExportExcel);
            this.Controls.Add(this.dataGridViewTaskAndQuota);
            this.Controls.Add(this.pnlHeader);
            this.Movable = false;
            this.Name = "frm_SubDashboard_TaskAndQuota";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Load += new System.EventHandler(this.frm_SubDashboard_TaskAndQuota_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskAndQuota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlHeader;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroLabel dash;
        private MetroFramework.Controls.MetroComboBox cmbTaskCode;
        private MetroFramework.Controls.MetroComboBox cmbProject;
        private MetroFramework.Controls.MetroComboBox cmbItemCode;
        private MetroFramework.Controls.MetroDateTime metroDateTime1To;
        private MetroFramework.Controls.MetroDateTime metroDateTime1From;
        private MetroFramework.Controls.MetroLabel lblPICToFill;
        private MetroFramework.Controls.MetroLabel lblUIDToFill;
        private MetroFramework.Controls.MetroGrid dataGridViewTaskAndQuota;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
        private MetroFramework.Controls.MetroLabel lblTaskAndQuotaDes;
        private MetroFramework.Controls.MetroButton btnViewAll;
        private MetroFramework.Controls.MetroButton btnGo;
        private MetroFramework.Controls.MetroButton btnClrAll;
    }
}