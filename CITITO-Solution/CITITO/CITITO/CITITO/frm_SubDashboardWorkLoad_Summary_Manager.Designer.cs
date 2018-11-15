namespace CITITO
{
    partial class frm_SubDashboardWorkLoad_Summary_Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SubDashboardWorkLoad_Summary_Manager));
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
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
            this.cmbProject = new MetroFramework.Controls.MetroComboBox();
            this.btnViewDataSet = new MetroFramework.Controls.MetroButton();
            this.dataGridViewWorkloadSummary = new MetroFramework.Controls.MetroGrid();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkloadSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(1232, 40);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 334;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
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
            this.btnClrAll.Visible = false;
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
            this.btnGo.Visible = false;
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
            this.btnClear.Location = new System.Drawing.Point(179, 2);
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
            this.lblWorkLoadDes.Location = new System.Drawing.Point(11, 49);
            this.lblWorkLoadDes.Name = "lblWorkLoadDes";
            this.lblWorkLoadDes.Size = new System.Drawing.Size(181, 25);
            this.lblWorkLoadDes.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblWorkLoadDes.TabIndex = 335;
            this.lblWorkLoadDes.Text = "Workload Summary";
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
            this.dash.Visible = false;
            // 
            // metroDateTime1To
            // 
            this.metroDateTime1To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime1To.Location = new System.Drawing.Point(1010, 2);
            this.metroDateTime1To.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1To.Name = "metroDateTime1To";
            this.metroDateTime1To.Size = new System.Drawing.Size(135, 29);
            this.metroDateTime1To.TabIndex = 185;
            this.metroDateTime1To.Visible = false;
            // 
            // metroDateTime1From
            // 
            this.metroDateTime1From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.metroDateTime1From.Location = new System.Drawing.Point(851, 2);
            this.metroDateTime1From.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1From.Name = "metroDateTime1From";
            this.metroDateTime1From.Size = new System.Drawing.Size(135, 29);
            this.metroDateTime1From.TabIndex = 184;
            this.metroDateTime1From.Visible = false;
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
            this.pnlHeader.Controls.Add(this.cmbProject);
            this.pnlHeader.Controls.Add(this.metroDateTime1To);
            this.pnlHeader.Controls.Add(this.metroDateTime1From);
            this.pnlHeader.HorizontalScrollbarBarColor = true;
            this.pnlHeader.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlHeader.HorizontalScrollbarSize = 10;
            this.pnlHeader.Location = new System.Drawing.Point(-3, -1);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1300, 32);
            this.pnlHeader.TabIndex = 331;
            this.pnlHeader.UseCustomBackColor = true;
            this.pnlHeader.VerticalScrollbarBarColor = true;
            this.pnlHeader.VerticalScrollbarHighlightOnWheel = false;
            this.pnlHeader.VerticalScrollbarSize = 10;
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
            // 
            // btnViewDataSet
            // 
            this.btnViewDataSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewDataSet.Location = new System.Drawing.Point(1173, 365);
            this.btnViewDataSet.Name = "btnViewDataSet";
            this.btnViewDataSet.Size = new System.Drawing.Size(98, 36);
            this.btnViewDataSet.Style = MetroFramework.MetroColorStyle.Green;
            this.btnViewDataSet.TabIndex = 336;
            this.btnViewDataSet.Text = "View Data Set";
            this.btnViewDataSet.UseSelectable = true;
            this.btnViewDataSet.UseStyleColors = true;
            this.btnViewDataSet.Click += new System.EventHandler(this.btnViewDataSet_Click);
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
            this.dataGridViewWorkloadSummary.Location = new System.Drawing.Point(14, 77);
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
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(1250, 58);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(38, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 333;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // frm_SubDashboardWorkLoad_Summary_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 755);
            this.ControlBox = false;
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.pBoxExportExcel);
            this.Controls.Add(this.lblWorkLoadDes);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnViewDataSet);
            this.Controls.Add(this.dataGridViewWorkloadSummary);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Movable = false;
            this.Name = "frm_SubDashboardWorkLoad_Summary_Manager";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Load += new System.EventHandler(this.frm_SubDashboardWorkLoad_Summary_Manager_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkloadSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
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
        private MetroFramework.Controls.MetroButton btnViewDataSet;
        private MetroFramework.Controls.MetroGrid dataGridViewWorkloadSummary;
    }
}