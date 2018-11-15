namespace CITITO
{
    partial class frm_UserPCPDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserPCPDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numericUpDownFileSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pBoxRefersh = new System.Windows.Forms.PictureBox();
            this.lblTaskCode = new System.Windows.Forms.Label();
            this.lblComplexity = new System.Windows.Forms.Label();
            this.dataGridViewUserPCPDetails = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFileTask = new System.Windows.Forms.Button();
            this.lblShipment = new System.Windows.Forms.Label();
            this.txtPCPCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShipment = new System.Windows.Forms.TextBox();
            this.txtComplexcity = new System.Windows.Forms.TextBox();
            this.cmbtaskCode = new System.Windows.Forms.ComboBox();
            this.dateTimePickerTaskIn = new System.Windows.Forms.DateTimePicker();
            this.lblTaskIn = new System.Windows.Forms.Label();
            this.lblTaskOut = new System.Windows.Forms.Label();
            this.dateTimePickerTaskOut = new System.Windows.Forms.DateTimePicker();
            this.lblTaskStatus = new System.Windows.Forms.Label();
            this.cmbTaskStatus = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblPagesKB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserPCPDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownFileSize
            // 
            this.numericUpDownFileSize.BackColor = System.Drawing.SystemColors.Control;
            this.numericUpDownFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownFileSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownFileSize.Location = new System.Drawing.Point(129, 232);
            this.numericUpDownFileSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownFileSize.Name = "numericUpDownFileSize";
            this.numericUpDownFileSize.Size = new System.Drawing.Size(131, 22);
            this.numericUpDownFileSize.TabIndex = 5;
            this.numericUpDownFileSize.ValueChanged += new System.EventHandler(this.numericUpDownFileSize_ValueChanged);
            this.numericUpDownFileSize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numericUpDownFileSize_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(61, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 75;
            this.label2.Text = "File Size:";
            // 
            // pBoxRefersh
            // 
            this.pBoxRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBoxRefersh.Image = ((System.Drawing.Image)(resources.GetObject("pBoxRefersh.Image")));
            this.pBoxRefersh.Location = new System.Drawing.Point(20, 326);
            this.pBoxRefersh.Name = "pBoxRefersh";
            this.pBoxRefersh.Size = new System.Drawing.Size(22, 20);
            this.pBoxRefersh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRefersh.TabIndex = 74;
            this.pBoxRefersh.TabStop = false;
            this.pBoxRefersh.WaitOnLoad = true;
            this.pBoxRefersh.Click += new System.EventHandler(this.pBoxRefersh_Click);
            // 
            // lblTaskCode
            // 
            this.lblTaskCode.AutoSize = true;
            this.lblTaskCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskCode.ForeColor = System.Drawing.Color.Navy;
            this.lblTaskCode.Location = new System.Drawing.Point(44, 198);
            this.lblTaskCode.Name = "lblTaskCode";
            this.lblTaskCode.Size = new System.Drawing.Size(78, 16);
            this.lblTaskCode.TabIndex = 73;
            this.lblTaskCode.Text = "Task Code:";
            // 
            // lblComplexity
            // 
            this.lblComplexity.AutoSize = true;
            this.lblComplexity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplexity.ForeColor = System.Drawing.Color.Navy;
            this.lblComplexity.Location = new System.Drawing.Point(45, 163);
            this.lblComplexity.Name = "lblComplexity";
            this.lblComplexity.Size = new System.Drawing.Size(77, 16);
            this.lblComplexity.TabIndex = 72;
            this.lblComplexity.Text = "Complexity:";
            // 
            // dataGridViewUserPCPDetails
            // 
            this.dataGridViewUserPCPDetails.AllowUserToAddRows = false;
            this.dataGridViewUserPCPDetails.AllowUserToDeleteRows = false;
            this.dataGridViewUserPCPDetails.AllowUserToOrderColumns = true;
            this.dataGridViewUserPCPDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUserPCPDetails.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewUserPCPDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUserPCPDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewUserPCPDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserPCPDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUserPCPDetails.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewUserPCPDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewUserPCPDetails.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridViewUserPCPDetails.Location = new System.Drawing.Point(20, 351);
            this.dataGridViewUserPCPDetails.MultiSelect = false;
            this.dataGridViewUserPCPDetails.Name = "dataGridViewUserPCPDetails";
            this.dataGridViewUserPCPDetails.ReadOnly = true;
            this.dataGridViewUserPCPDetails.RowHeadersVisible = false;
            this.dataGridViewUserPCPDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewUserPCPDetails.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewUserPCPDetails.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewUserPCPDetails.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewUserPCPDetails.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewUserPCPDetails.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewUserPCPDetails.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUserPCPDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserPCPDetails.Size = new System.Drawing.Size(892, 261);
            this.dataGridViewUserPCPDetails.TabIndex = 70;
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(796, 139);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 35);
            this.btnClear.TabIndex = 66;
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
            this.btnFileTask.Location = new System.Drawing.Point(796, 86);
            this.btnFileTask.Name = "btnFileTask";
            this.btnFileTask.Size = new System.Drawing.Size(98, 35);
            this.btnFileTask.TabIndex = 63;
            this.btnFileTask.Text = "File Task";
            this.btnFileTask.UseVisualStyleBackColor = true;
            this.btnFileTask.Click += new System.EventHandler(this.btnFileTask_Click);
            // 
            // lblShipment
            // 
            this.lblShipment.AutoSize = true;
            this.lblShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipment.ForeColor = System.Drawing.Color.Navy;
            this.lblShipment.Location = new System.Drawing.Point(29, 128);
            this.lblShipment.Name = "lblShipment";
            this.lblShipment.Size = new System.Drawing.Size(93, 16);
            this.lblShipment.TabIndex = 69;
            this.lblShipment.Text = "Shipment/File:";
            // 
            // txtPCPCode
            // 
            this.txtPCPCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtPCPCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCPCode.Location = new System.Drawing.Point(129, 90);
            this.txtPCPCode.Name = "txtPCPCode";
            this.txtPCPCode.Size = new System.Drawing.Size(161, 22);
            this.txtPCPCode.TabIndex = 1;
            this.txtPCPCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPCPCode_MouseClick);
            this.txtPCPCode.TextChanged += new System.EventHandler(this.txtPCPCode_TextChanged);
            this.txtPCPCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPCPCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(48, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 77;
            this.label1.Text = "PCP Code:";
            // 
            // txtShipment
            // 
            this.txtShipment.BackColor = System.Drawing.SystemColors.Control;
            this.txtShipment.Enabled = false;
            this.txtShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipment.Location = new System.Drawing.Point(128, 125);
            this.txtShipment.Name = "txtShipment";
            this.txtShipment.ReadOnly = true;
            this.txtShipment.Size = new System.Drawing.Size(161, 22);
            this.txtShipment.TabIndex = 2;
            // 
            // txtComplexcity
            // 
            this.txtComplexcity.BackColor = System.Drawing.SystemColors.Control;
            this.txtComplexcity.Enabled = false;
            this.txtComplexcity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComplexcity.Location = new System.Drawing.Point(128, 160);
            this.txtComplexcity.Name = "txtComplexcity";
            this.txtComplexcity.ReadOnly = true;
            this.txtComplexcity.Size = new System.Drawing.Size(161, 22);
            this.txtComplexcity.TabIndex = 3;
            // 
            // cmbtaskCode
            // 
            this.cmbtaskCode.BackColor = System.Drawing.SystemColors.Control;
            this.cmbtaskCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtaskCode.FormattingEnabled = true;
            this.cmbtaskCode.Location = new System.Drawing.Point(128, 195);
            this.cmbtaskCode.Name = "cmbtaskCode";
            this.cmbtaskCode.Size = new System.Drawing.Size(132, 24);
            this.cmbtaskCode.TabIndex = 4;
            this.cmbtaskCode.TextChanged += new System.EventHandler(this.cmbtaskCode_TextChanged);
            // 
            // dateTimePickerTaskIn
            // 
            this.dateTimePickerTaskIn.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dateTimePickerTaskIn.Enabled = false;
            this.dateTimePickerTaskIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTaskIn.Location = new System.Drawing.Point(128, 269);
            this.dateTimePickerTaskIn.Name = "dateTimePickerTaskIn";
            this.dateTimePickerTaskIn.Size = new System.Drawing.Size(202, 22);
            this.dateTimePickerTaskIn.TabIndex = 6;
            // 
            // lblTaskIn
            // 
            this.lblTaskIn.AutoSize = true;
            this.lblTaskIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskIn.ForeColor = System.Drawing.Color.Navy;
            this.lblTaskIn.Location = new System.Drawing.Point(67, 272);
            this.lblTaskIn.Name = "lblTaskIn";
            this.lblTaskIn.Size = new System.Drawing.Size(55, 16);
            this.lblTaskIn.TabIndex = 79;
            this.lblTaskIn.Text = "Task In:";
            // 
            // lblTaskOut
            // 
            this.lblTaskOut.AutoSize = true;
            this.lblTaskOut.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskOut.ForeColor = System.Drawing.Color.Navy;
            this.lblTaskOut.Location = new System.Drawing.Point(336, 272);
            this.lblTaskOut.Name = "lblTaskOut";
            this.lblTaskOut.Size = new System.Drawing.Size(65, 16);
            this.lblTaskOut.TabIndex = 81;
            this.lblTaskOut.Text = "Task Out:";
            // 
            // dateTimePickerTaskOut
            // 
            this.dateTimePickerTaskOut.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dateTimePickerTaskOut.Enabled = false;
            this.dateTimePickerTaskOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTaskOut.Location = new System.Drawing.Point(411, 269);
            this.dateTimePickerTaskOut.Name = "dateTimePickerTaskOut";
            this.dateTimePickerTaskOut.Size = new System.Drawing.Size(195, 22);
            this.dateTimePickerTaskOut.TabIndex = 7;
            // 
            // lblTaskStatus
            // 
            this.lblTaskStatus.AutoSize = true;
            this.lblTaskStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskStatus.ForeColor = System.Drawing.Color.Navy;
            this.lblTaskStatus.Location = new System.Drawing.Point(40, 307);
            this.lblTaskStatus.Name = "lblTaskStatus";
            this.lblTaskStatus.Size = new System.Drawing.Size(82, 16);
            this.lblTaskStatus.TabIndex = 82;
            this.lblTaskStatus.Text = "Task Status:";
            // 
            // cmbTaskStatus
            // 
            this.cmbTaskStatus.BackColor = System.Drawing.SystemColors.Control;
            this.cmbTaskStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaskStatus.FormattingEnabled = true;
            this.cmbTaskStatus.Location = new System.Drawing.Point(128, 304);
            this.cmbTaskStatus.Name = "cmbTaskStatus";
            this.cmbTaskStatus.Size = new System.Drawing.Size(161, 24);
            this.cmbTaskStatus.TabIndex = 8;
            this.cmbTaskStatus.TextChanged += new System.EventHandler(this.cmbTaskStatus_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.SystemColors.Control;
            this.txtUserID.Enabled = false;
            this.txtUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(129, 51);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(75, 22);
            this.txtUserID.TabIndex = 83;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.Navy;
            this.lblUserID.Location = new System.Drawing.Point(67, 54);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(56, 16);
            this.lblUserID.TabIndex = 84;
            this.lblUserID.Text = "User ID:";
            // 
            // lblPagesKB
            // 
            this.lblPagesKB.AutoSize = true;
            this.lblPagesKB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagesKB.ForeColor = System.Drawing.Color.Navy;
            this.lblPagesKB.Location = new System.Drawing.Point(267, 234);
            this.lblPagesKB.Name = "lblPagesKB";
            this.lblPagesKB.Size = new System.Drawing.Size(69, 16);
            this.lblPagesKB.TabIndex = 85;
            this.lblPagesKB.Text = "Pages/KB";
            // 
            // frm_UserPCPDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 632);
            this.Controls.Add(this.lblPagesKB);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.cmbTaskStatus);
            this.Controls.Add(this.lblTaskStatus);
            this.Controls.Add(this.lblTaskOut);
            this.Controls.Add(this.dateTimePickerTaskOut);
            this.Controls.Add(this.lblTaskIn);
            this.Controls.Add(this.dateTimePickerTaskIn);
            this.Controls.Add(this.cmbtaskCode);
            this.Controls.Add(this.txtComplexcity);
            this.Controls.Add(this.txtShipment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPCPCode);
            this.Controls.Add(this.numericUpDownFileSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pBoxRefersh);
            this.Controls.Add(this.lblTaskCode);
            this.Controls.Add(this.lblComplexity);
            this.Controls.Add(this.dataGridViewUserPCPDetails);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFileTask);
            this.Controls.Add(this.lblShipment);
            this.MaximizeBox = false;
            this.Name = "frm_UserPCPDetail";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_UserPCPDetail_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_UserPCPDetail_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRefersh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserPCPDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownFileSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pBoxRefersh;
        private System.Windows.Forms.Label lblTaskCode;
        private System.Windows.Forms.Label lblComplexity;
        private System.Windows.Forms.DataGridView dataGridViewUserPCPDetails;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFileTask;
        private System.Windows.Forms.Label lblShipment;
        private System.Windows.Forms.TextBox txtPCPCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShipment;
        private System.Windows.Forms.TextBox txtComplexcity;
        private System.Windows.Forms.ComboBox cmbtaskCode;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskIn;
        private System.Windows.Forms.Label lblTaskIn;
        private System.Windows.Forms.Label lblTaskOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskOut;
        private System.Windows.Forms.Label lblTaskStatus;
        private System.Windows.Forms.ComboBox cmbTaskStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblPagesKB;
    }
}