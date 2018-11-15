namespace CITITO
{
    partial class frm_UserPCPPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserPCPPanel));
            this.btnIdleTask = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTaskInOut = new System.Windows.Forms.Button();
            this.lblUserTaskPanel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIdleTask
            // 
            this.btnIdleTask.BackColor = System.Drawing.Color.LightBlue;
            this.btnIdleTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIdleTask.FlatAppearance.BorderSize = 0;
            this.btnIdleTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdleTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIdleTask.ForeColor = System.Drawing.Color.Gray;
            this.btnIdleTask.Location = new System.Drawing.Point(126, 94);
            this.btnIdleTask.Name = "btnIdleTask";
            this.btnIdleTask.Size = new System.Drawing.Size(123, 31);
            this.btnIdleTask.TabIndex = 77;
            this.btnIdleTask.Text = "IDLE/PRE-IP";
            this.btnIdleTask.UseVisualStyleBackColor = false;
            this.btnIdleTask.Click += new System.EventHandler(this.btnIdleTask_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 632);
            this.panel1.TabIndex = 76;
            // 
            // btnTaskInOut
            // 
            this.btnTaskInOut.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTaskInOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskInOut.FlatAppearance.BorderSize = 0;
            this.btnTaskInOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskInOut.Location = new System.Drawing.Point(1, 94);
            this.btnTaskInOut.Name = "btnTaskInOut";
            this.btnTaskInOut.Size = new System.Drawing.Size(123, 31);
            this.btnTaskInOut.TabIndex = 74;
            this.btnTaskInOut.Text = "Task In && Out";
            this.btnTaskInOut.UseVisualStyleBackColor = false;
            this.btnTaskInOut.Click += new System.EventHandler(this.btnTaskInOut_Click);
            // 
            // lblUserTaskPanel
            // 
            this.lblUserTaskPanel.AutoSize = true;
            this.lblUserTaskPanel.BackColor = System.Drawing.Color.Transparent;
            this.lblUserTaskPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserTaskPanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblUserTaskPanel.Location = new System.Drawing.Point(154, 38);
            this.lblUserTaskPanel.Name = "lblUserTaskPanel";
            this.lblUserTaskPanel.Size = new System.Drawing.Size(216, 37);
            this.lblUserTaskPanel.TabIndex = 71;
            this.lblUserTaskPanel.Text = "User Task Panel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(586, 38);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(30, 19);
            this.metroLabel1.TabIndex = 78;
            this.metroLabel1.Text = "UID";
            // 
            // frm_UserPCPPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 757);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnIdleTask);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTaskInOut);
            this.Controls.Add(this.lblUserTaskPanel);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "frm_UserPCPPanel";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_UserPCPPanel_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_UserPCPPanel_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIdleTask;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTaskInOut;
        private System.Windows.Forms.Label lblUserTaskPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}