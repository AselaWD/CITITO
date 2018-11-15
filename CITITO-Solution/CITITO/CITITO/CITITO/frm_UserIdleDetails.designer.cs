namespace CITITO
{
    partial class frm_UserIdleDetails
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserIdleDetails));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblTaskOut = new System.Windows.Forms.Label();
            this.dateTimePickerTaskOut = new System.Windows.Forms.DateTimePicker();
            this.lblTaskIn = new System.Windows.Forms.Label();
            this.dateTimePickerTaskIn = new System.Windows.Forms.DateTimePicker();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pBoxRefersh = new System.Windows.Forms.PictureBox();
            this.lblTaskCode = new System.Windows.Forms.Label();
            this.dataGridViewUserIdleDetails = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFileTask = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbProjectCode = new System.Windows.Forms.ComboBox();
            this.txtIdleHours = new System.Windows.Forms.TextBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.pictureBoxWarning = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserIdleDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.SystemColors.Control;
            this.txtUserID.Enabled = false;
            this.txtUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(129, 50);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(75, 22);
            this.txtUserID.TabIndex = 1;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.Navy;
            this.lblUserID.Location = new System.Drawing.Point(67, 53);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(56, 16);
            this.lblUserID.TabIndex = 113;
            this.lblUserID.Text = "User ID:";
            // 
            // lblTaskOut
            // 
            this.lblTaskOut.AutoSize = true;
            this.lblTaskOut.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskOut.ForeColor = System.Drawing.Color.Navy;
            this.lblTaskOut.Location = new System.Drawing.Point(336, 135);
            this.lblTaskOut.Name = "lblTaskOut";
            this.lblTaskOut.Size = new System.Drawing.Size(65, 16);
            this.lblTaskOut.TabIndex = 110;
            this.lblTaskOut.Text = "Task Out:";
            // 
            // dateTimePickerTaskOut
            // 
            this.dateTimePickerTaskOut.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dateTimePickerTaskOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTaskOut.Location = new System.Drawing.Point(411, 132);
            this.dateTimePickerTaskOut.Name = "dateTimePickerTaskOut";
            this.dateTimePickerTaskOut.Size = new System.Drawing.Size(195, 22);
            this.dateTimePickerTaskOut.TabIndex = 4;
            this.dateTimePickerTaskOut.ValueChanged += new System.EventHandler(this.dateTimePickerTaskOut_ValueChanged);
            // 
            // lblTaskIn
            // 
            this.lblTaskIn.AutoSize = true;
            this.lblTaskIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskIn.ForeColor = System.Drawing.Color.Navy;
            this.lblTaskIn.Location = new System.Drawing.Point(67, 135);
            this.lblTaskIn.Name = "lblTaskIn";
            this.lblTaskIn.Size = new System.Drawing.Size(55, 16);
            this.lblTaskIn.TabIndex = 109;
            this.lblTaskIn.Text = "Task In:";
            // 
            // dateTimePickerTaskIn
            // 
            this.dateTimePickerTaskIn.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dateTimePickerTaskIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTaskIn.Location = new System.Drawing.Point(128, 132);
            this.dateTimePickerTaskIn.Name = "dateTimePickerTaskIn";
            this.dateTimePickerTaskIn.Size = new System.Drawing.Size(202, 22);
            this.dateTimePickerTaskIn.TabIndex = 3;
            this.dateTimePickerTaskIn.ValueChanged += new System.EventHandler(this.dateTimePickerTaskIn_ValueChanged);
            // 
            // cmbReason
            // 
            this.cmbReason.BackColor = System.Drawing.SystemColors.Control;
            this.cmbReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Location = new System.Drawing.Point(128, 170);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(285, 24);
            this.cmbReason.TabIndex = 5;
            this.cmbReason.TextChanged += new System.EventHandler(this.cmbReason_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(34, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 108;
            this.label1.Text = "Project Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(51, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 107;
            this.label2.Text = "Idle Hours:";
            // 
            // pBoxRefersh
            // 
            this.pBoxRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxRefersh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxRefersh.Image")));
            this.pBoxRefersh.Location = new System.Drawing.Point(20, 313);
            this.pBoxRefersh.Name = "pBoxRefersh";
            this.pBoxRefersh.Size = new System.Drawing.Size(22, 20);
            this.pBoxRefersh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRefersh.TabIndex = 106;
            this.pBoxRefersh.TabStop = false;
            this.pBoxRefersh.WaitOnLoad = true;
            this.pBoxRefersh.Click += new System.EventHandler(this.pBoxRefersh_Click);
            // 
            // lblTaskCode
            // 
            this.lblTaskCode.AutoSize = true;
            this.lblTaskCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskCode.ForeColor = System.Drawing.Color.Navy;
            this.lblTaskCode.Location = new System.Drawing.Point(63, 173);
            this.lblTaskCode.Name = "lblTaskCode";
            this.lblTaskCode.Size = new System.Drawing.Size(59, 16);
            this.lblTaskCode.TabIndex = 105;
            this.lblTaskCode.Text = "Reason:";
            // 
            // dataGridViewUserIdleDetails
            // 
            this.dataGridViewUserIdleDetails.AllowUserToAddRows = false;
            this.dataGridViewUserIdleDetails.AllowUserToDeleteRows = false;
            this.dataGridViewUserIdleDetails.AllowUserToOrderColumns = true;
            this.dataGridViewUserIdleDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUserIdleDetails.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewUserIdleDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUserIdleDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewUserIdleDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserIdleDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUserIdleDetails.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewUserIdleDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewUserIdleDetails.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridViewUserIdleDetails.Location = new System.Drawing.Point(20, 339);
            this.dataGridViewUserIdleDetails.MultiSelect = false;
            this.dataGridViewUserIdleDetails.Name = "dataGridViewUserIdleDetails";
            this.dataGridViewUserIdleDetails.ReadOnly = true;
            this.dataGridViewUserIdleDetails.RowHeadersVisible = false;
            this.dataGridViewUserIdleDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewUserIdleDetails.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewUserIdleDetails.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewUserIdleDetails.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewUserIdleDetails.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewUserIdleDetails.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewUserIdleDetails.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUserIdleDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserIdleDetails.Size = new System.Drawing.Size(892, 273);
            this.dataGridViewUserIdleDetails.TabIndex = 103;
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(800, 141);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 35);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFileTask
            // 
            this.btnFileTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFileTask.FlatAppearance.BorderSize = 0;
            this.btnFileTask.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFileTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileTask.Location = new System.Drawing.Point(800, 88);
            this.btnFileTask.Name = "btnFileTask";
            this.btnFileTask.Size = new System.Drawing.Size(98, 35);
            this.btnFileTask.TabIndex = 7;
            this.btnFileTask.Text = "File Task";
            this.btnFileTask.UseVisualStyleBackColor = true;
            this.btnFileTask.Click += new System.EventHandler(this.btnFileTask_Click);
            // 
            // cmbProjectCode
            // 
            this.cmbProjectCode.BackColor = System.Drawing.SystemColors.Control;
            this.cmbProjectCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProjectCode.FormattingEnabled = true;
            this.cmbProjectCode.Location = new System.Drawing.Point(129, 89);
            this.cmbProjectCode.Name = "cmbProjectCode";
            this.cmbProjectCode.Size = new System.Drawing.Size(130, 24);
            this.cmbProjectCode.TabIndex = 2;
            this.cmbProjectCode.SelectedIndexChanged += new System.EventHandler(this.cmbProjectCode_SelectedIndexChanged);
            this.cmbProjectCode.TextChanged += new System.EventHandler(this.cmbProjectCode_TextChanged);
            // 
            // txtIdleHours
            // 
            this.txtIdleHours.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdleHours.Enabled = false;
            this.txtIdleHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdleHours.Location = new System.Drawing.Point(128, 211);
            this.txtIdleHours.Name = "txtIdleHours";
            this.txtIdleHours.ReadOnly = true;
            this.txtIdleHours.Size = new System.Drawing.Size(131, 22);
            this.txtIdleHours.TabIndex = 6;
            this.txtIdleHours.TextChanged += new System.EventHandler(this.txtIdleHours_TextChanged);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.BackColor = System.Drawing.Color.Red;
            this.lblWarning.Cursor = System.Windows.Forms.Cursors.No;
            this.lblWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.SystemColors.Info;
            this.lblWarning.Location = new System.Drawing.Point(299, 112);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Padding = new System.Windows.Forms.Padding(1);
            this.lblWarning.Size = new System.Drawing.Size(2, 15);
            this.lblWarning.TabIndex = 114;
            this.lblWarning.Visible = false;
            // 
            // pictureBoxWarning
            // 
            this.pictureBoxWarning.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxWarning.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBoxWarning.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWarning.Image")));
            this.pictureBoxWarning.Location = new System.Drawing.Point(273, 109);
            this.pictureBoxWarning.Name = "pictureBoxWarning";
            this.pictureBoxWarning.Size = new System.Drawing.Size(22, 20);
            this.pictureBoxWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWarning.TabIndex = 115;
            this.pictureBoxWarning.TabStop = false;
            this.pictureBoxWarning.Visible = false;
            this.pictureBoxWarning.WaitOnLoad = true;
            // 
            // frm_UserIdleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 632);
            this.Controls.Add(this.pictureBoxWarning);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.txtIdleHours);
            this.Controls.Add(this.cmbProjectCode);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.lblTaskOut);
            this.Controls.Add(this.dateTimePickerTaskOut);
            this.Controls.Add(this.lblTaskIn);
            this.Controls.Add(this.dateTimePickerTaskIn);
            this.Controls.Add(this.cmbReason);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pBoxRefersh);
            this.Controls.Add(this.lblTaskCode);
            this.Controls.Add(this.dataGridViewUserIdleDetails);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFileTask);
            this.MaximizeBox = false;
            this.Name = "frm_UserIdleDetails";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_UserIdleDetails_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_UserIdleDetails_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserIdleDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblTaskOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskOut;
        private System.Windows.Forms.Label lblTaskIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskIn;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pBoxRefersh;
        private System.Windows.Forms.Label lblTaskCode;
        private System.Windows.Forms.DataGridView dataGridViewUserIdleDetails;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFileTask;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbProjectCode;
        private System.Windows.Forms.TextBox txtIdleHours;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.PictureBox pictureBoxWarning;
    }
}