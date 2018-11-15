namespace CITITO
{
    partial class frm_BulkImport_PCPCodes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BulkImport_PCPCodes));
            this.lblPCPCodeImport = new MetroFramework.Controls.MetroLabel();
            this.dataGridViewImportPCP = new MetroFramework.Controls.MetroGrid();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnImportSheet = new MetroFramework.Controls.MetroButton();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportPCP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPCPCodeImport
            // 
            this.lblPCPCodeImport.AutoSize = true;
            this.lblPCPCodeImport.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPCPCodeImport.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPCPCodeImport.Location = new System.Drawing.Point(116, 45);
            this.lblPCPCodeImport.Name = "lblPCPCodeImport";
            this.lblPCPCodeImport.Size = new System.Drawing.Size(138, 25);
            this.lblPCPCodeImport.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblPCPCodeImport.TabIndex = 96;
            this.lblPCPCodeImport.Text = "Bulk Job Import";
            this.lblPCPCodeImport.UseStyleColors = true;
            // 
            // dataGridViewImportPCP
            // 
            this.dataGridViewImportPCP.AllowUserToAddRows = false;
            this.dataGridViewImportPCP.AllowUserToDeleteRows = false;
            this.dataGridViewImportPCP.AllowUserToResizeRows = false;
            this.dataGridViewImportPCP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewImportPCP.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewImportPCP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewImportPCP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewImportPCP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImportPCP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewImportPCP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImportPCP.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImportPCP.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewImportPCP.EnableHeadersVisualStyles = false;
            this.dataGridViewImportPCP.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewImportPCP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewImportPCP.Location = new System.Drawing.Point(20, 165);
            this.dataGridViewImportPCP.Name = "dataGridViewImportPCP";
            this.dataGridViewImportPCP.ReadOnly = true;
            this.dataGridViewImportPCP.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImportPCP.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewImportPCP.RowHeadersVisible = false;
            this.dataGridViewImportPCP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewImportPCP.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewImportPCP.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewImportPCP.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewImportPCP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewImportPCP.Size = new System.Drawing.Size(587, 418);
            this.dataGridViewImportPCP.Style = MetroFramework.MetroColorStyle.Teal;
            this.dataGridViewImportPCP.TabIndex = 227;
            this.dataGridViewImportPCP.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewImportPCP.UseCustomBackColor = true;
            this.dataGridViewImportPCP.UseCustomForeColor = true;
            this.dataGridViewImportPCP.UseStyleColors = true;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(505, 599);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 36);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(377, 599);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 36);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImportSheet
            // 
            this.btnImportSheet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportSheet.Location = new System.Drawing.Point(505, 113);
            this.btnImportSheet.Name = "btnImportSheet";
            this.btnImportSheet.Size = new System.Drawing.Size(102, 36);
            this.btnImportSheet.TabIndex = 1;
            this.btnImportSheet.Text = "Import Sheet";
            this.btnImportSheet.UseSelectable = true;
            this.btnImportSheet.Click += new System.EventHandler(this.btnImportSheet_Click);
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUID.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblUID.Location = new System.Drawing.Point(377, 122);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(26, 15);
            this.lblUID.TabIndex = 228;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // frm_BulkImport_PCPCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 655);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnImportSheet);
            this.Controls.Add(this.dataGridViewImportPCP);
            this.Controls.Add(this.lblPCPCodeImport);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_BulkImport_PCPCodes";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_BulkImport_PCPCodes_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_BulkImport_PCPCodes_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportPCP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel lblPCPCodeImport;
        private MetroFramework.Controls.MetroGrid dataGridViewImportPCP;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnImportSheet;
        private MetroFramework.Controls.MetroLabel lblUID;
    }
}