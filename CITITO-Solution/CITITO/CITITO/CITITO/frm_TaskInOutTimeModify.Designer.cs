namespace CITITO
{
    partial class frm_TaskInOutTimeModify
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
            this.dateTimePickerTaskOut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTaskIn = new System.Windows.Forms.DateTimePicker();
            this.lblIDLEMessage = new MetroFramework.Controls.MetroLabel();
            this.txtTaskHours = new MetroFramework.Controls.MetroTextBox();
            this.lblTaskHours = new MetroFramework.Controls.MetroLabel();
            this.lblTaskOut = new MetroFramework.Controls.MetroLabel();
            this.lblTaskIn = new MetroFramework.Controls.MetroLabel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnModify = new MetroFramework.Controls.MetroButton();
            this.lblMainPanel = new System.Windows.Forms.Label();
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.lblTRID = new MetroFramework.Controls.MetroLabel();
            this.lblJobCode = new MetroFramework.Controls.MetroLabel();
            this.lblShipment = new MetroFramework.Controls.MetroLabel();
            this.lblFileName = new MetroFramework.Controls.MetroLabel();
            this.lblOutput = new MetroFramework.Controls.MetroLabel();
            this.lblUOM = new MetroFramework.Controls.MetroLabel();
            this.lblTask = new MetroFramework.Controls.MetroLabel();
            this.lblJobStatus = new MetroFramework.Controls.MetroLabel();
            this.lblTaskInFill = new MetroFramework.Controls.MetroLabel();
            this.lblTaskOutFill = new MetroFramework.Controls.MetroLabel();
            this.lblHours = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // dateTimePickerTaskOut
            // 
            this.dateTimePickerTaskOut.CalendarFont = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerTaskOut.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePickerTaskOut.Font = new System.Drawing.Font("Segoe UI", 10.9F);
            this.dateTimePickerTaskOut.Location = new System.Drawing.Point(392, 119);
            this.dateTimePickerTaskOut.MinimumSize = new System.Drawing.Size(4, 29);
            this.dateTimePickerTaskOut.Name = "dateTimePickerTaskOut";
            this.dateTimePickerTaskOut.Size = new System.Drawing.Size(212, 29);
            this.dateTimePickerTaskOut.TabIndex = 2;
            this.dateTimePickerTaskOut.ValueChanged += new System.EventHandler(this.dateTimePickerTaskOut_ValueChanged);
            // 
            // dateTimePickerTaskIn
            // 
            this.dateTimePickerTaskIn.CalendarFont = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerTaskIn.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePickerTaskIn.Font = new System.Drawing.Font("Segoe UI", 10.9F);
            this.dateTimePickerTaskIn.Location = new System.Drawing.Point(101, 119);
            this.dateTimePickerTaskIn.MinimumSize = new System.Drawing.Size(4, 29);
            this.dateTimePickerTaskIn.Name = "dateTimePickerTaskIn";
            this.dateTimePickerTaskIn.Size = new System.Drawing.Size(212, 29);
            this.dateTimePickerTaskIn.TabIndex = 1;
            this.dateTimePickerTaskIn.ValueChanged += new System.EventHandler(this.dateTimePickerTaskIn_ValueChanged);
            // 
            // lblIDLEMessage
            // 
            this.lblIDLEMessage.AutoSize = true;
            this.lblIDLEMessage.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblIDLEMessage.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblIDLEMessage.Location = new System.Drawing.Point(192, 96);
            this.lblIDLEMessage.Name = "lblIDLEMessage";
            this.lblIDLEMessage.Size = new System.Drawing.Size(12, 15);
            this.lblIDLEMessage.Style = MetroFramework.MetroColorStyle.Red;
            this.lblIDLEMessage.TabIndex = 302;
            this.lblIDLEMessage.Text = "-";
            this.lblIDLEMessage.UseStyleColors = true;
            this.lblIDLEMessage.Visible = false;
            // 
            // txtTaskHours
            // 
            // 
            // 
            // 
            this.txtTaskHours.CustomButton.Image = null;
            this.txtTaskHours.CustomButton.Location = new System.Drawing.Point(82, 1);
            this.txtTaskHours.CustomButton.Name = "";
            this.txtTaskHours.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtTaskHours.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTaskHours.CustomButton.TabIndex = 1;
            this.txtTaskHours.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTaskHours.CustomButton.UseSelectable = true;
            this.txtTaskHours.CustomButton.Visible = false;
            this.txtTaskHours.Enabled = false;
            this.txtTaskHours.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTaskHours.Lines = new string[0];
            this.txtTaskHours.Location = new System.Drawing.Point(101, 170);
            this.txtTaskHours.MaxLength = 32767;
            this.txtTaskHours.Name = "txtTaskHours";
            this.txtTaskHours.PasswordChar = '\0';
            this.txtTaskHours.ReadOnly = true;
            this.txtTaskHours.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTaskHours.SelectedText = "";
            this.txtTaskHours.SelectionLength = 0;
            this.txtTaskHours.SelectionStart = 0;
            this.txtTaskHours.ShortcutsEnabled = true;
            this.txtTaskHours.Size = new System.Drawing.Size(106, 25);
            this.txtTaskHours.TabIndex = 3;
            this.txtTaskHours.UseSelectable = true;
            this.txtTaskHours.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTaskHours.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtTaskHours.TextChanged += new System.EventHandler(this.txtIDLEHours_TextChanged);
            // 
            // lblTaskHours
            // 
            this.lblTaskHours.AutoSize = true;
            this.lblTaskHours.Location = new System.Drawing.Point(22, 176);
            this.lblTaskHours.Name = "lblTaskHours";
            this.lblTaskHours.Size = new System.Drawing.Size(73, 19);
            this.lblTaskHours.TabIndex = 301;
            this.lblTaskHours.Text = "Task Hours:";
            // 
            // lblTaskOut
            // 
            this.lblTaskOut.AutoSize = true;
            this.lblTaskOut.Location = new System.Drawing.Point(325, 127);
            this.lblTaskOut.Name = "lblTaskOut";
            this.lblTaskOut.Size = new System.Drawing.Size(61, 19);
            this.lblTaskOut.TabIndex = 300;
            this.lblTaskOut.Text = "Task Out:";
            // 
            // lblTaskIn
            // 
            this.lblTaskIn.AutoSize = true;
            this.lblTaskIn.Location = new System.Drawing.Point(46, 127);
            this.lblTaskIn.Name = "lblTaskIn";
            this.lblTaskIn.Size = new System.Drawing.Size(49, 19);
            this.lblTaskIn.TabIndex = 299;
            this.lblTaskIn.Text = "Task In:";
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(514, 244);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 36);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnModify
            // 
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.Location = new System.Drawing.Point(392, 244);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(102, 36);
            this.btnModify.TabIndex = 4;
            this.btnModify.Text = "Modify";
            this.btnModify.UseSelectable = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // lblMainPanel
            // 
            this.lblMainPanel.AutoSize = true;
            this.lblMainPanel.BackColor = System.Drawing.Color.Transparent;
            this.lblMainPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainPanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMainPanel.Location = new System.Drawing.Point(23, 29);
            this.lblMainPanel.Name = "lblMainPanel";
            this.lblMainPanel.Size = new System.Drawing.Size(243, 30);
            this.lblMainPanel.TabIndex = 305;
            this.lblMainPanel.Text = "Task In/Out Time Modify";
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUID.Location = new System.Drawing.Point(28, 69);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(26, 15);
            this.lblUID.TabIndex = 306;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // lblTRID
            // 
            this.lblTRID.AutoSize = true;
            this.lblTRID.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTRID.Location = new System.Drawing.Point(60, 69);
            this.lblTRID.Name = "lblTRID";
            this.lblTRID.Size = new System.Drawing.Size(31, 15);
            this.lblTRID.TabIndex = 307;
            this.lblTRID.Text = "TRID";
            this.lblTRID.Visible = false;
            // 
            // lblJobCode
            // 
            this.lblJobCode.AutoSize = true;
            this.lblJobCode.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblJobCode.Location = new System.Drawing.Point(97, 69);
            this.lblJobCode.Name = "lblJobCode";
            this.lblJobCode.Size = new System.Drawing.Size(55, 15);
            this.lblJobCode.TabIndex = 308;
            this.lblJobCode.Text = "Job Code";
            this.lblJobCode.Visible = false;
            // 
            // lblShipment
            // 
            this.lblShipment.AutoSize = true;
            this.lblShipment.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblShipment.Location = new System.Drawing.Point(153, 69);
            this.lblShipment.Name = "lblShipment";
            this.lblShipment.Size = new System.Drawing.Size(54, 15);
            this.lblShipment.TabIndex = 309;
            this.lblShipment.Text = "Shipment";
            this.lblShipment.Visible = false;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblFileName.Location = new System.Drawing.Point(209, 69);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(57, 15);
            this.lblFileName.TabIndex = 310;
            this.lblFileName.Text = "File Name";
            this.lblFileName.Visible = false;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblOutput.Location = new System.Drawing.Point(270, 69);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(43, 15);
            this.lblOutput.TabIndex = 311;
            this.lblOutput.Text = "Output";
            this.lblOutput.Visible = false;
            // 
            // lblUOM
            // 
            this.lblUOM.AutoSize = true;
            this.lblUOM.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUOM.Location = new System.Drawing.Point(312, 69);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(34, 15);
            this.lblUOM.TabIndex = 313;
            this.lblUOM.Text = "UOM";
            this.lblUOM.Visible = false;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTask.Location = new System.Drawing.Point(349, 69);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(27, 15);
            this.lblTask.TabIndex = 314;
            this.lblTask.Text = "Task";
            this.lblTask.Visible = false;
            // 
            // lblJobStatus
            // 
            this.lblJobStatus.AutoSize = true;
            this.lblJobStatus.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblJobStatus.Location = new System.Drawing.Point(379, 69);
            this.lblJobStatus.Name = "lblJobStatus";
            this.lblJobStatus.Size = new System.Drawing.Size(59, 15);
            this.lblJobStatus.TabIndex = 315;
            this.lblJobStatus.Text = "Job Status";
            this.lblJobStatus.Visible = false;
            // 
            // lblTaskInFill
            // 
            this.lblTaskInFill.AutoSize = true;
            this.lblTaskInFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTaskInFill.Location = new System.Drawing.Point(435, 69);
            this.lblTaskInFill.Name = "lblTaskInFill";
            this.lblTaskInFill.Size = new System.Drawing.Size(39, 15);
            this.lblTaskInFill.TabIndex = 316;
            this.lblTaskInFill.Text = "Task In";
            this.lblTaskInFill.Visible = false;
            // 
            // lblTaskOutFill
            // 
            this.lblTaskOutFill.AutoSize = true;
            this.lblTaskOutFill.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTaskOutFill.Location = new System.Drawing.Point(480, 69);
            this.lblTaskOutFill.Name = "lblTaskOutFill";
            this.lblTaskOutFill.Size = new System.Drawing.Size(49, 15);
            this.lblTaskOutFill.TabIndex = 317;
            this.lblTaskOutFill.Text = "Task Out";
            this.lblTaskOutFill.Visible = false;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblHours.Location = new System.Drawing.Point(535, 69);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(37, 15);
            this.lblHours.TabIndex = 318;
            this.lblHours.Text = "Hours";
            this.lblHours.Visible = false;
            // 
            // frm_TaskInOutTimeModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 303);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.lblTaskOutFill);
            this.Controls.Add(this.lblTaskInFill);
            this.Controls.Add(this.lblJobStatus);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.lblUOM);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblShipment);
            this.Controls.Add(this.lblJobCode);
            this.Controls.Add(this.lblTRID);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.lblMainPanel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.dateTimePickerTaskOut);
            this.Controls.Add(this.dateTimePickerTaskIn);
            this.Controls.Add(this.lblIDLEMessage);
            this.Controls.Add(this.txtTaskHours);
            this.Controls.Add(this.lblTaskHours);
            this.Controls.Add(this.lblTaskOut);
            this.Controls.Add(this.lblTaskIn);
            this.MaximizeBox = false;
            this.Name = "frm_TaskInOutTimeModify";
            this.Resizable = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_TaskInOutTimeModify_FormClosed);
            this.Load += new System.EventHandler(this.frm_TaskInOutTimeModify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerTaskOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskIn;
        private MetroFramework.Controls.MetroLabel lblIDLEMessage;
        private MetroFramework.Controls.MetroTextBox txtTaskHours;
        private MetroFramework.Controls.MetroLabel lblTaskHours;
        private MetroFramework.Controls.MetroLabel lblTaskOut;
        private MetroFramework.Controls.MetroLabel lblTaskIn;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnModify;
        private System.Windows.Forms.Label lblMainPanel;
        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroLabel lblTRID;
        private MetroFramework.Controls.MetroLabel lblJobCode;
        private MetroFramework.Controls.MetroLabel lblShipment;
        private MetroFramework.Controls.MetroLabel lblFileName;
        private MetroFramework.Controls.MetroLabel lblOutput;
        private MetroFramework.Controls.MetroLabel lblUOM;
        private MetroFramework.Controls.MetroLabel lblTask;
        private MetroFramework.Controls.MetroLabel lblJobStatus;
        private MetroFramework.Controls.MetroLabel lblTaskInFill;
        private MetroFramework.Controls.MetroLabel lblTaskOutFill;
        private MetroFramework.Controls.MetroLabel lblHours;
    }
}