namespace CITITO
{
    partial class frm_UserPCPModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserPCPModify));
            this.btnModify = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblUserPCPModify = new System.Windows.Forms.Label();
            this.pictureBoxWarning = new System.Windows.Forms.PictureBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.txtTaskHours = new System.Windows.Forms.TextBox();
            this.lblTaskOut = new System.Windows.Forms.Label();
            this.dateTimePickerTaskOut = new System.Windows.Forms.DateTimePicker();
            this.lblTaskIn = new System.Windows.Forms.Label();
            this.dateTimePickerTaskIn = new System.Windows.Forms.DateTimePicker();
            this.lblTaskHours = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblPCPCode = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblPCPStatus = new System.Windows.Forms.Label();
            this.lblUID = new System.Windows.Forms.Label();
            this.lblOldTaskCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModify
            // 
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(392, 219);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(98, 35);
            this.btnModify.TabIndex = 5;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(517, 219);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 35);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblUserPCPModify
            // 
            this.lblUserPCPModify.AutoSize = true;
            this.lblUserPCPModify.BackColor = System.Drawing.Color.Transparent;
            this.lblUserPCPModify.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserPCPModify.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblUserPCPModify.Location = new System.Drawing.Point(12, 9);
            this.lblUserPCPModify.Name = "lblUserPCPModify";
            this.lblUserPCPModify.Size = new System.Drawing.Size(273, 32);
            this.lblUserPCPModify.TabIndex = 123;
            this.lblUserPCPModify.Text = "User PCP Time Modify";
            // 
            // pictureBoxWarning
            // 
            this.pictureBoxWarning.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxWarning.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBoxWarning.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWarning.Image")));
            this.pictureBoxWarning.Location = new System.Drawing.Point(261, 80);
            this.pictureBoxWarning.Name = "pictureBoxWarning";
            this.pictureBoxWarning.Size = new System.Drawing.Size(22, 20);
            this.pictureBoxWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWarning.TabIndex = 133;
            this.pictureBoxWarning.TabStop = false;
            this.pictureBoxWarning.Visible = false;
            this.pictureBoxWarning.WaitOnLoad = true;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.BackColor = System.Drawing.Color.Red;
            this.lblWarning.Cursor = System.Windows.Forms.Cursors.No;
            this.lblWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.SystemColors.Info;
            this.lblWarning.Location = new System.Drawing.Point(287, 83);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Padding = new System.Windows.Forms.Padding(1);
            this.lblWarning.Size = new System.Drawing.Size(2, 15);
            this.lblWarning.TabIndex = 132;
            this.lblWarning.Visible = false;
            // 
            // txtTaskHours
            // 
            this.txtTaskHours.BackColor = System.Drawing.SystemColors.Control;
            this.txtTaskHours.Enabled = false;
            this.txtTaskHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskHours.Location = new System.Drawing.Point(115, 142);
            this.txtTaskHours.Name = "txtTaskHours";
            this.txtTaskHours.ReadOnly = true;
            this.txtTaskHours.Size = new System.Drawing.Size(131, 22);
            this.txtTaskHours.TabIndex = 4;
            this.txtTaskHours.TextChanged += new System.EventHandler(this.txtIdleHours_TextChanged);
            // 
            // lblTaskOut
            // 
            this.lblTaskOut.AutoSize = true;
            this.lblTaskOut.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskOut.ForeColor = System.Drawing.Color.Navy;
            this.lblTaskOut.Location = new System.Drawing.Point(324, 106);
            this.lblTaskOut.Name = "lblTaskOut";
            this.lblTaskOut.Size = new System.Drawing.Size(65, 16);
            this.lblTaskOut.TabIndex = 131;
            this.lblTaskOut.Text = "Task Out:";
            // 
            // dateTimePickerTaskOut
            // 
            this.dateTimePickerTaskOut.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dateTimePickerTaskOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTaskOut.Location = new System.Drawing.Point(399, 103);
            this.dateTimePickerTaskOut.Name = "dateTimePickerTaskOut";
            this.dateTimePickerTaskOut.Size = new System.Drawing.Size(195, 22);
            this.dateTimePickerTaskOut.TabIndex = 3;
            this.dateTimePickerTaskOut.ValueChanged += new System.EventHandler(this.dateTimePickerTaskOut_ValueChanged);
            // 
            // lblTaskIn
            // 
            this.lblTaskIn.AutoSize = true;
            this.lblTaskIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskIn.ForeColor = System.Drawing.Color.Navy;
            this.lblTaskIn.Location = new System.Drawing.Point(55, 106);
            this.lblTaskIn.Name = "lblTaskIn";
            this.lblTaskIn.Size = new System.Drawing.Size(55, 16);
            this.lblTaskIn.TabIndex = 130;
            this.lblTaskIn.Text = "Task In:";
            // 
            // dateTimePickerTaskIn
            // 
            this.dateTimePickerTaskIn.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dateTimePickerTaskIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTaskIn.Location = new System.Drawing.Point(116, 103);
            this.dateTimePickerTaskIn.Name = "dateTimePickerTaskIn";
            this.dateTimePickerTaskIn.Size = new System.Drawing.Size(202, 22);
            this.dateTimePickerTaskIn.TabIndex = 2;
            this.dateTimePickerTaskIn.ValueChanged += new System.EventHandler(this.dateTimePickerTaskIn_ValueChanged);
            // 
            // lblTaskHours
            // 
            this.lblTaskHours.AutoSize = true;
            this.lblTaskHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskHours.ForeColor = System.Drawing.Color.Navy;
            this.lblTaskHours.Location = new System.Drawing.Point(29, 145);
            this.lblTaskHours.Name = "lblTaskHours";
            this.lblTaskHours.Size = new System.Drawing.Size(81, 16);
            this.lblTaskHours.TabIndex = 129;
            this.lblTaskHours.Text = "Task Hours:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Navy;
            this.lblID.Location = new System.Drawing.Point(49, 64);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 16);
            this.lblID.TabIndex = 134;
            this.lblID.Text = "ID";
            this.lblID.Visible = false;
            // 
            // lblPCPCode
            // 
            this.lblPCPCode.AutoSize = true;
            this.lblPCPCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCPCode.ForeColor = System.Drawing.Color.Navy;
            this.lblPCPCode.Location = new System.Drawing.Point(113, 64);
            this.lblPCPCode.Name = "lblPCPCode";
            this.lblPCPCode.Size = new System.Drawing.Size(68, 16);
            this.lblPCPCode.TabIndex = 135;
            this.lblPCPCode.Text = "PCPCode";
            this.lblPCPCode.Visible = false;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.ForeColor = System.Drawing.Color.Navy;
            this.lblSize.Location = new System.Drawing.Point(258, 64);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(34, 16);
            this.lblSize.TabIndex = 136;
            this.lblSize.Text = "Size";
            this.lblSize.Visible = false;
            // 
            // lblPCPStatus
            // 
            this.lblPCPStatus.AutoSize = true;
            this.lblPCPStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCPStatus.ForeColor = System.Drawing.Color.Navy;
            this.lblPCPStatus.Location = new System.Drawing.Point(298, 64);
            this.lblPCPStatus.Name = "lblPCPStatus";
            this.lblPCPStatus.Size = new System.Drawing.Size(72, 16);
            this.lblPCPStatus.TabIndex = 137;
            this.lblPCPStatus.Text = "PCPStatus";
            this.lblPCPStatus.Visible = false;
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUID.ForeColor = System.Drawing.Color.Navy;
            this.lblUID.Location = new System.Drawing.Point(76, 64);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(31, 16);
            this.lblUID.TabIndex = 134;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // lblOldTaskCode
            // 
            this.lblOldTaskCode.AutoSize = true;
            this.lblOldTaskCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldTaskCode.ForeColor = System.Drawing.Color.Navy;
            this.lblOldTaskCode.Location = new System.Drawing.Point(187, 64);
            this.lblOldTaskCode.Name = "lblOldTaskCode";
            this.lblOldTaskCode.Size = new System.Drawing.Size(72, 16);
            this.lblOldTaskCode.TabIndex = 138;
            this.lblOldTaskCode.Text = "TaskCode";
            this.lblOldTaskCode.Visible = false;
            // 
            // frm_UserPCPModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 278);
            this.Controls.Add(this.lblOldTaskCode);
            this.Controls.Add(this.lblPCPStatus);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblPCPCode);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.pictureBoxWarning);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.txtTaskHours);
            this.Controls.Add(this.lblTaskOut);
            this.Controls.Add(this.dateTimePickerTaskOut);
            this.Controls.Add(this.lblTaskIn);
            this.Controls.Add(this.dateTimePickerTaskIn);
            this.Controls.Add(this.lblTaskHours);
            this.Controls.Add(this.lblUserPCPModify);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnExit);
            this.MaximizeBox = false;
            this.Name = "frm_UserPCPModify";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_UserPCPModify_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_UserPCPModify_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblUserPCPModify;
        private System.Windows.Forms.PictureBox pictureBoxWarning;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.TextBox txtTaskHours;
        private System.Windows.Forms.Label lblTaskOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskOut;
        private System.Windows.Forms.Label lblTaskIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskIn;
        private System.Windows.Forms.Label lblTaskHours;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblPCPCode;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblPCPStatus;
        private System.Windows.Forms.Label lblUID;
        private System.Windows.Forms.Label lblOldTaskCode;
    }
}