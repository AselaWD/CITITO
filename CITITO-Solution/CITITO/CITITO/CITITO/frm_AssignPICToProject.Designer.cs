namespace CITITO
{
    partial class frm_AssignPICToProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AssignPICToProject));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblAssignPIC = new MetroFramework.Controls.MetroLabel();
            this.lblManagerName = new MetroFramework.Controls.MetroLabel();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.lblAssignProjectPIC = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblProjectName = new MetroFramework.Controls.MetroLabel();
            this.lblCurrectPIC = new MetroFramework.Controls.MetroLabel();
            this.cmbProjectName = new MetroFramework.Controls.MetroComboBox();
            this.cmbAssignPIC = new MetroFramework.Controls.MetroComboBox();
            this.txtCurrentPIC = new MetroFramework.Controls.MetroTextBox();
            this.dataGridViewAssignProject = new MetroFramework.Controls.MetroGrid();
            this.pBoxRefersh = new System.Windows.Forms.PictureBox();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnAssign = new MetroFramework.Controls.MetroButton();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.pBoxExportExcel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssignProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAssignPIC
            // 
            this.lblAssignPIC.AutoSize = true;
            this.lblAssignPIC.Location = new System.Drawing.Point(47, 175);
            this.lblAssignPIC.Name = "lblAssignPIC";
            this.lblAssignPIC.Size = new System.Drawing.Size(73, 19);
            this.lblAssignPIC.TabIndex = 200;
            this.lblAssignPIC.Text = "Assign PIC:";
            // 
            // lblManagerName
            // 
            this.lblManagerName.AutoSize = true;
            this.lblManagerName.Location = new System.Drawing.Point(420, 43);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(45, 19);
            this.lblManagerName.TabIndex = 199;
            this.lblManagerName.Text = "Name";
            this.lblManagerName.Visible = false;
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(384, 43);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(30, 19);
            this.lblUID.TabIndex = 198;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // lblAssignProjectPIC
            // 
            this.lblAssignProjectPIC.AutoSize = true;
            this.lblAssignProjectPIC.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAssignProjectPIC.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAssignProjectPIC.Location = new System.Drawing.Point(106, 37);
            this.lblAssignProjectPIC.Name = "lblAssignProjectPIC";
            this.lblAssignProjectPIC.Size = new System.Drawing.Size(155, 25);
            this.lblAssignProjectPIC.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblAssignProjectPIC.TabIndex = 197;
            this.lblAssignProjectPIC.Text = "Assign Project PIC";
            this.lblAssignProjectPIC.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 196;
            this.pictureBox1.TabStop = false;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(27, 132);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(93, 19);
            this.lblProjectName.TabIndex = 195;
            this.lblProjectName.Text = "Project Name:";
            // 
            // lblCurrectPIC
            // 
            this.lblCurrectPIC.AutoSize = true;
            this.lblCurrectPIC.Location = new System.Drawing.Point(307, 132);
            this.lblCurrectPIC.Name = "lblCurrectPIC";
            this.lblCurrectPIC.Size = new System.Drawing.Size(79, 19);
            this.lblCurrectPIC.TabIndex = 201;
            this.lblCurrectPIC.Text = "Currect PIC:";
            // 
            // cmbProjectName
            // 
            this.cmbProjectName.FormattingEnabled = true;
            this.cmbProjectName.ItemHeight = 23;
            this.cmbProjectName.Location = new System.Drawing.Point(126, 122);
            this.cmbProjectName.Name = "cmbProjectName";
            this.cmbProjectName.Size = new System.Drawing.Size(136, 29);
            this.cmbProjectName.TabIndex = 1;
            this.cmbProjectName.UseSelectable = true;
            this.cmbProjectName.SelectedIndexChanged += new System.EventHandler(this.cmbProjectName_SelectedIndexChanged);
            // 
            // cmbAssignPIC
            // 
            this.cmbAssignPIC.FormattingEnabled = true;
            this.cmbAssignPIC.ItemHeight = 23;
            this.cmbAssignPIC.Location = new System.Drawing.Point(126, 165);
            this.cmbAssignPIC.Name = "cmbAssignPIC";
            this.cmbAssignPIC.Size = new System.Drawing.Size(102, 29);
            this.cmbAssignPIC.TabIndex = 203;
            this.cmbAssignPIC.UseSelectable = true;
            // 
            // txtCurrentPIC
            // 
            // 
            // 
            // 
            this.txtCurrentPIC.CustomButton.Image = null;
            this.txtCurrentPIC.CustomButton.Location = new System.Drawing.Point(48, 1);
            this.txtCurrentPIC.CustomButton.Name = "";
            this.txtCurrentPIC.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCurrentPIC.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrentPIC.CustomButton.TabIndex = 1;
            this.txtCurrentPIC.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrentPIC.CustomButton.UseSelectable = true;
            this.txtCurrentPIC.CustomButton.Visible = false;
            this.txtCurrentPIC.Enabled = false;
            this.txtCurrentPIC.Lines = new string[0];
            this.txtCurrentPIC.Location = new System.Drawing.Point(392, 128);
            this.txtCurrentPIC.MaxLength = 32767;
            this.txtCurrentPIC.Name = "txtCurrentPIC";
            this.txtCurrentPIC.PasswordChar = '\0';
            this.txtCurrentPIC.ReadOnly = true;
            this.txtCurrentPIC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrentPIC.SelectedText = "";
            this.txtCurrentPIC.SelectionLength = 0;
            this.txtCurrentPIC.SelectionStart = 0;
            this.txtCurrentPIC.ShortcutsEnabled = true;
            this.txtCurrentPIC.Size = new System.Drawing.Size(70, 23);
            this.txtCurrentPIC.TabIndex = 204;
            this.txtCurrentPIC.UseSelectable = true;
            this.txtCurrentPIC.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrentPIC.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dataGridViewAssignProject
            // 
            this.dataGridViewAssignProject.AllowUserToAddRows = false;
            this.dataGridViewAssignProject.AllowUserToDeleteRows = false;
            this.dataGridViewAssignProject.AllowUserToResizeRows = false;
            this.dataGridViewAssignProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAssignProject.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewAssignProject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAssignProject.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewAssignProject.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAssignProject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAssignProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAssignProject.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAssignProject.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAssignProject.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewAssignProject.EnableHeadersVisualStyles = false;
            this.dataGridViewAssignProject.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewAssignProject.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewAssignProject.Location = new System.Drawing.Point(20, 287);
            this.dataGridViewAssignProject.Name = "dataGridViewAssignProject";
            this.dataGridViewAssignProject.ReadOnly = true;
            this.dataGridViewAssignProject.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAssignProject.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAssignProject.RowHeadersVisible = false;
            this.dataGridViewAssignProject.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewAssignProject.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dataGridViewAssignProject.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewAssignProject.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewAssignProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAssignProject.Size = new System.Drawing.Size(581, 240);
            this.dataGridViewAssignProject.Style = MetroFramework.MetroColorStyle.Teal;
            this.dataGridViewAssignProject.TabIndex = 206;
            this.dataGridViewAssignProject.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dataGridViewAssignProject.UseCustomBackColor = true;
            this.dataGridViewAssignProject.UseCustomForeColor = true;
            this.dataGridViewAssignProject.UseStyleColors = true;
            // 
            // pBoxRefersh
            // 
            this.pBoxRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxRefersh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxRefersh.Image")));
            this.pBoxRefersh.Location = new System.Drawing.Point(23, 261);
            this.pBoxRefersh.Name = "pBoxRefersh";
            this.pBoxRefersh.Size = new System.Drawing.Size(22, 20);
            this.pBoxRefersh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRefersh.TabIndex = 205;
            this.pBoxRefersh.TabStop = false;
            this.pBoxRefersh.WaitOnLoad = true;
            this.pBoxRefersh.Click += new System.EventHandler(this.pBoxRefersh_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(518, 187);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 32);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(518, 95);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(83, 32);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseSelectable = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(518, 141);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 32);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(542, 236);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 235;
            this.metroLabel3.Text = "Export As";
            this.metroLabel3.UseStyleColors = true;
            // 
            // pBoxExportExcel
            // 
            this.pBoxExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExportExcel.Image")));
            this.pBoxExportExcel.Location = new System.Drawing.Point(562, 254);
            this.pBoxExportExcel.Name = "pBoxExportExcel";
            this.pBoxExportExcel.Size = new System.Drawing.Size(36, 27);
            this.pBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxExportExcel.TabIndex = 234;
            this.pBoxExportExcel.TabStop = false;
            this.pBoxExportExcel.WaitOnLoad = true;
            this.pBoxExportExcel.Click += new System.EventHandler(this.pBoxExportExcel_Click);
            // 
            // frm_AssignPICToProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 547);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.pBoxExportExcel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.dataGridViewAssignProject);
            this.Controls.Add(this.pBoxRefersh);
            this.Controls.Add(this.txtCurrentPIC);
            this.Controls.Add(this.cmbAssignPIC);
            this.Controls.Add(this.cmbProjectName);
            this.Controls.Add(this.lblCurrectPIC);
            this.Controls.Add(this.lblAssignPIC);
            this.Controls.Add(this.lblManagerName);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.lblAssignProjectPIC);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblProjectName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_AssignPICToProject";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_AssignPICToProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssignProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExportExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblAssignPIC;
        private MetroFramework.Controls.MetroLabel lblManagerName;
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroLabel lblAssignProjectPIC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel lblProjectName;
        private MetroFramework.Controls.MetroLabel lblCurrectPIC;
        private MetroFramework.Controls.MetroComboBox cmbProjectName;
        private MetroFramework.Controls.MetroComboBox cmbAssignPIC;
        private MetroFramework.Controls.MetroTextBox txtCurrentPIC;
        private MetroFramework.Controls.MetroGrid dataGridViewAssignProject;
        private System.Windows.Forms.PictureBox pBoxRefersh;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnAssign;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pBoxExportExcel;
    }
}