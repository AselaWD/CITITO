namespace CITITO
{
    partial class frm_BulkImport_Quota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BulkImport_Quota));
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnImportSheet = new MetroFramework.Controls.MetroButton();
            this.dataGridViewImportQuota = new MetroFramework.Controls.MetroGrid();
            this.lblPCPCodeImport = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportQuota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUID.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblUID.Location = new System.Drawing.Point(376, 115);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(26, 15);
            this.lblUID.TabIndex = 235;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(504, 592);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 36);
            this.btnExit.TabIndex = 231;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(376, 592);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 36);
            this.btnSave.TabIndex = 230;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImportSheet
            // 
            this.btnImportSheet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportSheet.Location = new System.Drawing.Point(504, 106);
            this.btnImportSheet.Name = "btnImportSheet";
            this.btnImportSheet.Size = new System.Drawing.Size(102, 36);
            this.btnImportSheet.TabIndex = 229;
            this.btnImportSheet.Text = "Import Sheet";
            this.btnImportSheet.UseSelectable = true;
            this.btnImportSheet.Click += new System.EventHandler(this.btnImportSheet_Click);
            // 
            // dataGridViewImportQuota
            // 
            this.dataGridViewImportQuota.AllowUserToAddRows = false;
            this.dataGridViewImportQuota.AllowUserToDeleteRows = false;
            this.dataGridViewImportQuota.AllowUserToResizeRows = false;
            this.dataGridViewImportQuota.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewImportQuota.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewImportQuota.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewImportQuota.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewImportQuota.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImportQuota.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewImportQuota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImportQuota.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImportQuota.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewImportQuota.EnableHeadersVisualStyles = false;
            this.dataGridViewImportQuota.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewImportQuota.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewImportQuota.Location = new System.Drawing.Point(19, 158);
            this.dataGridViewImportQuota.Name = "dataGridViewImportQuota";
            this.dataGridViewImportQuota.ReadOnly = true;
            this.dataGridViewImportQuota.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImportQuota.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewImportQuota.RowHeadersVisible = false;
            this.dataGridViewImportQuota.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewImportQuota.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewImportQuota.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewImportQuota.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewImportQuota.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewImportQuota.Size = new System.Drawing.Size(587, 418);
            this.dataGridViewImportQuota.Style = MetroFramework.MetroColorStyle.Teal;
            this.dataGridViewImportQuota.TabIndex = 234;
            this.dataGridViewImportQuota.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewImportQuota.UseCustomBackColor = true;
            this.dataGridViewImportQuota.UseCustomForeColor = true;
            this.dataGridViewImportQuota.UseStyleColors = true;
            // 
            // lblPCPCodeImport
            // 
            this.lblPCPCodeImport.AutoSize = true;
            this.lblPCPCodeImport.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPCPCodeImport.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPCPCodeImport.Location = new System.Drawing.Point(115, 38);
            this.lblPCPCodeImport.Name = "lblPCPCodeImport";
            this.lblPCPCodeImport.Size = new System.Drawing.Size(160, 25);
            this.lblPCPCodeImport.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblPCPCodeImport.TabIndex = 233;
            this.lblPCPCodeImport.Text = "Bulk Quota Import";
            this.lblPCPCodeImport.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 232;
            this.pictureBox1.TabStop = false;
            // 
            // frm_BulkImport_Quota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 651);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnImportSheet);
            this.Controls.Add(this.dataGridViewImportQuota);
            this.Controls.Add(this.lblPCPCodeImport);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "frm_BulkImport_Quota";
            this.Resizable = false;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportQuota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnImportSheet;
        private MetroFramework.Controls.MetroGrid dataGridViewImportQuota;
        private MetroFramework.Controls.MetroLabel lblPCPCodeImport;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}