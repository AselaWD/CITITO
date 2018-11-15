namespace CITITO
{
    partial class frm_TaskCodeModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TaskCodeModify));
            this.lblModifyTaskCode = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.lblTaskCode = new MetroFramework.Controls.MetroLabel();
            this.lblDescription = new MetroFramework.Controls.MetroLabel();
            this.lblUOM = new MetroFramework.Controls.MetroLabel();
            this.lblQuota = new MetroFramework.Controls.MetroLabel();
            this.txtTaskCode = new MetroFramework.Controls.MetroTextBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.cmbUOM = new System.Windows.Forms.ComboBox();
            this.numericUpDownQuota = new System.Windows.Forms.NumericUpDown();
            this.tmpTask = new MetroFramework.Controls.MetroLabel();
            this.tmpDes = new MetroFramework.Controls.MetroLabel();
            this.tmpUOM = new MetroFramework.Controls.MetroLabel();
            this.tmpQuota = new MetroFramework.Controls.MetroLabel();
            this.lbltmpSkip = new MetroFramework.Controls.MetroLabel();
            this.chkOutputValidation = new MetroFramework.Controls.MetroCheckBox();
            this.lbltmpProject = new MetroFramework.Controls.MetroLabel();
            this.lbltmpProcessCode = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuota)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModifyTaskCode
            // 
            this.lblModifyTaskCode.AutoSize = true;
            this.lblModifyTaskCode.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblModifyTaskCode.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblModifyTaskCode.Location = new System.Drawing.Point(102, 31);
            this.lblModifyTaskCode.Name = "lblModifyTaskCode";
            this.lblModifyTaskCode.Size = new System.Drawing.Size(154, 25);
            this.lblModifyTaskCode.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblModifyTaskCode.TabIndex = 188;
            this.lblModifyTaskCode.Text = "Modify Task Code";
            this.lblModifyTaskCode.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 187;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(522, 334);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(415, 334);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 32);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Modify";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTaskCode
            // 
            this.lblTaskCode.AutoSize = true;
            this.lblTaskCode.Location = new System.Drawing.Point(50, 105);
            this.lblTaskCode.Name = "lblTaskCode";
            this.lblTaskCode.Size = new System.Drawing.Size(71, 19);
            this.lblTaskCode.TabIndex = 191;
            this.lblTaskCode.Text = "Task Code:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(44, 138);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 19);
            this.lblDescription.TabIndex = 192;
            this.lblDescription.Text = "Description:";
            // 
            // lblUOM
            // 
            this.lblUOM.AutoSize = true;
            this.lblUOM.Location = new System.Drawing.Point(76, 215);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(44, 19);
            this.lblUOM.TabIndex = 193;
            this.lblUOM.Text = "UOM:";
            // 
            // lblQuota
            // 
            this.lblQuota.AutoSize = true;
            this.lblQuota.Location = new System.Drawing.Point(72, 250);
            this.lblQuota.Name = "lblQuota";
            this.lblQuota.Size = new System.Drawing.Size(49, 19);
            this.lblQuota.TabIndex = 194;
            this.lblQuota.Text = "Quota:";
            // 
            // txtTaskCode
            // 
            // 
            // 
            // 
            this.txtTaskCode.CustomButton.Image = null;
            this.txtTaskCode.CustomButton.Location = new System.Drawing.Point(101, 1);
            this.txtTaskCode.CustomButton.Name = "";
            this.txtTaskCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTaskCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTaskCode.CustomButton.TabIndex = 1;
            this.txtTaskCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTaskCode.CustomButton.UseSelectable = true;
            this.txtTaskCode.CustomButton.Visible = false;
            this.txtTaskCode.Enabled = false;
            this.txtTaskCode.Lines = new string[0];
            this.txtTaskCode.Location = new System.Drawing.Point(133, 101);
            this.txtTaskCode.MaxLength = 32767;
            this.txtTaskCode.Name = "txtTaskCode";
            this.txtTaskCode.PasswordChar = '\0';
            this.txtTaskCode.ReadOnly = true;
            this.txtTaskCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTaskCode.SelectedText = "";
            this.txtTaskCode.SelectionLength = 0;
            this.txtTaskCode.SelectionStart = 0;
            this.txtTaskCode.ShortcutsEnabled = true;
            this.txtTaskCode.Size = new System.Drawing.Size(123, 23);
            this.txtTaskCode.TabIndex = 1;
            this.txtTaskCode.UseSelectable = true;
            this.txtTaskCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTaskCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(206, 1);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(65, 65);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(133, 134);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(272, 67);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cmbUOM
            // 
            this.cmbUOM.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUOM.FormattingEnabled = true;
            this.cmbUOM.Items.AddRange(new object[] {
            "Byte Size",
            "Book Count",
            "Equations",
            "Image Count",
            "Page Count"});
            this.cmbUOM.Location = new System.Drawing.Point(133, 212);
            this.cmbUOM.Name = "cmbUOM";
            this.cmbUOM.Size = new System.Drawing.Size(124, 23);
            this.cmbUOM.TabIndex = 3;
            // 
            // numericUpDownQuota
            // 
            this.numericUpDownQuota.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownQuota.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownQuota.Location = new System.Drawing.Point(133, 246);
            this.numericUpDownQuota.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownQuota.Name = "numericUpDownQuota";
            this.numericUpDownQuota.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownQuota.TabIndex = 4;
            // 
            // tmpTask
            // 
            this.tmpTask.AutoSize = true;
            this.tmpTask.Location = new System.Drawing.Point(125, 60);
            this.tmpTask.Name = "tmpTask";
            this.tmpTask.Size = new System.Drawing.Size(56, 19);
            this.tmpTask.TabIndex = 195;
            this.tmpTask.Text = "tmpTask";
            this.tmpTask.Visible = false;
            // 
            // tmpDes
            // 
            this.tmpDes.AutoSize = true;
            this.tmpDes.Location = new System.Drawing.Point(187, 60);
            this.tmpDes.Name = "tmpDes";
            this.tmpDes.Size = new System.Drawing.Size(54, 19);
            this.tmpDes.TabIndex = 196;
            this.tmpDes.Text = "tmpDes";
            this.tmpDes.Visible = false;
            // 
            // tmpUOM
            // 
            this.tmpUOM.AutoSize = true;
            this.tmpUOM.Location = new System.Drawing.Point(247, 60);
            this.tmpUOM.Name = "tmpUOM";
            this.tmpUOM.Size = new System.Drawing.Size(65, 19);
            this.tmpUOM.TabIndex = 197;
            this.tmpUOM.Text = "tmpUOM";
            this.tmpUOM.Visible = false;
            // 
            // tmpQuota
            // 
            this.tmpQuota.AutoSize = true;
            this.tmpQuota.Location = new System.Drawing.Point(318, 60);
            this.tmpQuota.Name = "tmpQuota";
            this.tmpQuota.Size = new System.Drawing.Size(70, 19);
            this.tmpQuota.TabIndex = 198;
            this.tmpQuota.Text = "tmpQuota";
            this.tmpQuota.Visible = false;
            // 
            // lbltmpSkip
            // 
            this.lbltmpSkip.AutoSize = true;
            this.lbltmpSkip.Location = new System.Drawing.Point(571, 60);
            this.lbltmpSkip.Name = "lbltmpSkip";
            this.lbltmpSkip.Size = new System.Drawing.Size(57, 19);
            this.lbltmpSkip.TabIndex = 199;
            this.lbltmpSkip.Text = "tmpSkip";
            this.lbltmpSkip.Visible = false;
            // 
            // chkOutputValidation
            // 
            this.chkOutputValidation.AutoSize = true;
            this.chkOutputValidation.BackColor = System.Drawing.Color.Transparent;
            this.chkOutputValidation.Location = new System.Drawing.Point(133, 284);
            this.chkOutputValidation.Name = "chkOutputValidation";
            this.chkOutputValidation.Size = new System.Drawing.Size(260, 15);
            this.chkOutputValidation.TabIndex = 256;
            this.chkOutputValidation.Text = "Check if need to avoid user output validation";
            this.chkOutputValidation.UseCustomBackColor = true;
            this.chkOutputValidation.UseSelectable = true;
            // 
            // lbltmpProject
            // 
            this.lbltmpProject.AutoSize = true;
            this.lbltmpProject.Location = new System.Drawing.Point(387, 60);
            this.lbltmpProject.Name = "lbltmpProject";
            this.lbltmpProject.Size = new System.Drawing.Size(74, 19);
            this.lbltmpProject.TabIndex = 257;
            this.lbltmpProject.Text = "tmpProject";
            this.lbltmpProject.Visible = false;
            // 
            // lbltmpProcessCode
            // 
            this.lbltmpProcessCode.AutoSize = true;
            this.lbltmpProcessCode.Location = new System.Drawing.Point(459, 60);
            this.lbltmpProcessCode.Name = "lbltmpProcessCode";
            this.lbltmpProcessCode.Size = new System.Drawing.Size(109, 19);
            this.lbltmpProcessCode.TabIndex = 258;
            this.lbltmpProcessCode.Text = "tmpProcessCode";
            this.lbltmpProcessCode.Visible = false;
            // 
            // frm_TaskCodeModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 397);
            this.Controls.Add(this.lbltmpProcessCode);
            this.Controls.Add(this.lbltmpProject);
            this.Controls.Add(this.chkOutputValidation);
            this.Controls.Add(this.lbltmpSkip);
            this.Controls.Add(this.tmpQuota);
            this.Controls.Add(this.tmpUOM);
            this.Controls.Add(this.tmpDes);
            this.Controls.Add(this.tmpTask);
            this.Controls.Add(this.numericUpDownQuota);
            this.Controls.Add(this.cmbUOM);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTaskCode);
            this.Controls.Add(this.lblQuota);
            this.Controls.Add(this.lblUOM);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTaskCode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblModifyTaskCode);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_TaskCodeModify";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_TaskCodeModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblModifyTaskCode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnUpdate;
        private MetroFramework.Controls.MetroLabel lblTaskCode;
        private MetroFramework.Controls.MetroLabel lblDescription;
        private MetroFramework.Controls.MetroLabel lblUOM;
        private MetroFramework.Controls.MetroLabel lblQuota;
        private MetroFramework.Controls.MetroTextBox txtTaskCode;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbUOM;
        private System.Windows.Forms.NumericUpDown numericUpDownQuota;
        private MetroFramework.Controls.MetroLabel tmpTask;
        private MetroFramework.Controls.MetroLabel tmpDes;
        private MetroFramework.Controls.MetroLabel tmpUOM;
        private MetroFramework.Controls.MetroLabel tmpQuota;
        private MetroFramework.Controls.MetroLabel lbltmpSkip;
        private MetroFramework.Controls.MetroCheckBox chkOutputValidation;
        private MetroFramework.Controls.MetroLabel lbltmpProject;
        private MetroFramework.Controls.MetroLabel lbltmpProcessCode;
    }
}