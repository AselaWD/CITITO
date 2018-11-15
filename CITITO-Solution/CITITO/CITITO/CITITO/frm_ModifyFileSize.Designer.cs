namespace CITITO
{
    partial class frm_ModifyFileSize
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
            this.lblPCPIndex = new MetroFramework.Controls.MetroLabel();
            this.lblMainPanel = new System.Windows.Forms.Label();
            this.btnModify = new MetroFramework.Controls.MetroButton();
            this.numericUpDownFileSize = new System.Windows.Forms.NumericUpDown();
            this.lblFileSize = new MetroFramework.Controls.MetroLabel();
            this.lblRowID = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPCPIndex
            // 
            this.lblPCPIndex.AutoSize = true;
            this.lblPCPIndex.Location = new System.Drawing.Point(113, 72);
            this.lblPCPIndex.Name = "lblPCPIndex";
            this.lblPCPIndex.Size = new System.Drawing.Size(65, 19);
            this.lblPCPIndex.TabIndex = 329;
            this.lblPCPIndex.Text = "PCPIndex";
            // 
            // lblMainPanel
            // 
            this.lblMainPanel.AutoSize = true;
            this.lblMainPanel.BackColor = System.Drawing.Color.Transparent;
            this.lblMainPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainPanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMainPanel.Location = new System.Drawing.Point(21, 24);
            this.lblMainPanel.Name = "lblMainPanel";
            this.lblMainPanel.Size = new System.Drawing.Size(144, 25);
            this.lblMainPanel.TabIndex = 328;
            this.lblMainPanel.Text = "File Size Modify";
            // 
            // btnModify
            // 
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.Location = new System.Drawing.Point(269, 144);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(66, 33);
            this.btnModify.TabIndex = 322;
            this.btnModify.Text = "Modify";
            this.btnModify.UseSelectable = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // numericUpDownFileSize
            // 
            this.numericUpDownFileSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownFileSize.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownFileSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownFileSize.Location = new System.Drawing.Point(100, 103);
            this.numericUpDownFileSize.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.numericUpDownFileSize.Name = "numericUpDownFileSize";
            this.numericUpDownFileSize.Size = new System.Drawing.Size(157, 29);
            this.numericUpDownFileSize.TabIndex = 330;
            this.numericUpDownFileSize.ThousandsSeparator = true;
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(35, 108);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(59, 19);
            this.lblFileSize.TabIndex = 331;
            this.lblFileSize.Text = "File Size:";
            // 
            // lblRowID
            // 
            this.lblRowID.AutoSize = true;
            this.lblRowID.Location = new System.Drawing.Point(41, 72);
            this.lblRowID.Name = "lblRowID";
            this.lblRowID.Size = new System.Drawing.Size(53, 19);
            this.lblRowID.TabIndex = 332;
            this.lblRowID.Text = "Row ID:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(100, 72);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(17, 19);
            this.metroLabel1.TabIndex = 333;
            this.metroLabel1.Text = "#";
            // 
            // frm_ModifyFileSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 200);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lblRowID);
            this.Controls.Add(this.numericUpDownFileSize);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.lblPCPIndex);
            this.Controls.Add(this.lblMainPanel);
            this.Controls.Add(this.btnModify);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ModifyFileSize";
            this.Resizable = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_ModifyFileSize_FormClosed);
            this.Load += new System.EventHandler(this.frm_ModifyFileSize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel lblPCPIndex;
        private System.Windows.Forms.Label lblMainPanel;
        private MetroFramework.Controls.MetroButton btnModify;
        private System.Windows.Forms.NumericUpDown numericUpDownFileSize;
        private MetroFramework.Controls.MetroLabel lblFileSize;
        private MetroFramework.Controls.MetroLabel lblRowID;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}