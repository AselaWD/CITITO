namespace CITITO
{
    partial class frm_PCPDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PCPDelete));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbPCPStatus = new System.Windows.Forms.ComboBox();
            this.cmbPCPCode = new System.Windows.Forms.ComboBox();
            this.cmbTaskCode = new System.Windows.Forms.ComboBox();
            this.lblMainPanel = new System.Windows.Forms.Label();
            this.lblPCPCode = new MetroFramework.Controls.MetroLabel();
            this.lblTaskCode = new MetroFramework.Controls.MetroLabel();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.checkBoxAllTasks = new MetroFramework.Controls.MetroCheckBox();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // cmbPCPStatus
            // 
            this.cmbPCPStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPCPStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPCPStatus.BackColor = System.Drawing.SystemColors.Control;
            this.cmbPCPStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbPCPStatus.ForeColor = System.Drawing.Color.Black;
            this.cmbPCPStatus.FormattingEnabled = true;
            this.cmbPCPStatus.Location = new System.Drawing.Point(114, 168);
            this.cmbPCPStatus.Name = "cmbPCPStatus";
            this.cmbPCPStatus.Size = new System.Drawing.Size(147, 24);
            this.cmbPCPStatus.TabIndex = 21;
            this.cmbPCPStatus.TextChanged += new System.EventHandler(this.cmbPCPStatus_TextChanged);
            // 
            // cmbPCPCode
            // 
            this.cmbPCPCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPCPCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPCPCode.BackColor = System.Drawing.SystemColors.Control;
            this.cmbPCPCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPCPCode.ForeColor = System.Drawing.Color.Black;
            this.cmbPCPCode.FormattingEnabled = true;
            this.cmbPCPCode.Location = new System.Drawing.Point(114, 91);
            this.cmbPCPCode.Name = "cmbPCPCode";
            this.cmbPCPCode.Size = new System.Drawing.Size(147, 24);
            this.cmbPCPCode.TabIndex = 19;
            this.cmbPCPCode.SelectedIndexChanged += new System.EventHandler(this.cmbPCPCode_SelectedIndexChanged);
            this.cmbPCPCode.TextChanged += new System.EventHandler(this.cmbPCPCode_TextChanged);
            this.cmbPCPCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbPCPCode_MouseClick);
            // 
            // cmbTaskCode
            // 
            this.cmbTaskCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTaskCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTaskCode.BackColor = System.Drawing.SystemColors.Control;
            this.cmbTaskCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbTaskCode.ForeColor = System.Drawing.Color.Black;
            this.cmbTaskCode.FormattingEnabled = true;
            this.cmbTaskCode.Location = new System.Drawing.Point(114, 130);
            this.cmbTaskCode.Name = "cmbTaskCode";
            this.cmbTaskCode.Size = new System.Drawing.Size(147, 24);
            this.cmbTaskCode.TabIndex = 20;
            this.cmbTaskCode.SelectedIndexChanged += new System.EventHandler(this.cmbTaskCode_SelectedIndexChanged);
            this.cmbTaskCode.TextChanged += new System.EventHandler(this.cmbTaskCode_TextChanged);
            this.cmbTaskCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbTaskCode_MouseClick);
            // 
            // lblMainPanel
            // 
            this.lblMainPanel.AutoSize = true;
            this.lblMainPanel.BackColor = System.Drawing.Color.Transparent;
            this.lblMainPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainPanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMainPanel.Location = new System.Drawing.Point(94, 29);
            this.lblMainPanel.Name = "lblMainPanel";
            this.lblMainPanel.Size = new System.Drawing.Size(110, 30);
            this.lblMainPanel.TabIndex = 138;
            this.lblMainPanel.Text = "Delete Job";
            // 
            // lblPCPCode
            // 
            this.lblPCPCode.AutoSize = true;
            this.lblPCPCode.Location = new System.Drawing.Point(39, 96);
            this.lblPCPCode.Name = "lblPCPCode";
            this.lblPCPCode.Size = new System.Drawing.Size(69, 19);
            this.lblPCPCode.TabIndex = 149;
            this.lblPCPCode.Text = "Job Code:";
            // 
            // lblTaskCode
            // 
            this.lblTaskCode.AutoSize = true;
            this.lblTaskCode.Location = new System.Drawing.Point(37, 135);
            this.lblTaskCode.Name = "lblTaskCode";
            this.lblTaskCode.Size = new System.Drawing.Size(71, 19);
            this.lblTaskCode.TabIndex = 150;
            this.lblTaskCode.Text = "Task Code:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(57, 168);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 19);
            this.lblStatus.TabIndex = 151;
            this.lblStatus.Text = "Status:";
            // 
            // checkBoxAllTasks
            // 
            this.checkBoxAllTasks.AutoSize = true;
            this.checkBoxAllTasks.Location = new System.Drawing.Point(267, 100);
            this.checkBoxAllTasks.Name = "checkBoxAllTasks";
            this.checkBoxAllTasks.Size = new System.Drawing.Size(68, 15);
            this.checkBoxAllTasks.TabIndex = 152;
            this.checkBoxAllTasks.Text = "All Tasks";
            this.checkBoxAllTasks.UseSelectable = true;
            this.checkBoxAllTasks.CheckedChanged += new System.EventHandler(this.checkBoxAllTasks_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(359, 177);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 34);
            this.btnExit.TabIndex = 155;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(359, 128);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 34);
            this.btnClear.TabIndex = 154;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(359, 79);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 34);
            this.btnDelete.TabIndex = 153;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(286, 40);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(30, 19);
            this.lblUID.TabIndex = 156;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // frm_PCPDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 266);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.checkBoxAllTasks);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTaskCode);
            this.Controls.Add(this.lblPCPCode);
            this.Controls.Add(this.lblMainPanel);
            this.Controls.Add(this.cmbPCPStatus);
            this.Controls.Add(this.cmbPCPCode);
            this.Controls.Add(this.cmbTaskCode);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_PCPDelete";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_PCPDelete_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_PCPDelete_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbPCPStatus;
        private System.Windows.Forms.ComboBox cmbPCPCode;
        private System.Windows.Forms.ComboBox cmbTaskCode;
        private System.Windows.Forms.Label lblMainPanel;
        private MetroFramework.Controls.MetroLabel lblPCPCode;
        private MetroFramework.Controls.MetroLabel lblTaskCode;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private MetroFramework.Controls.MetroCheckBox checkBoxAllTasks;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroLabel lblUID;
    }
}