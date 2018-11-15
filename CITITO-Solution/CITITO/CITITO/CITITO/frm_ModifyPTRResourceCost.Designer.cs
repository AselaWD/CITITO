namespace CITITO
{
    partial class frm_ModifyPTRResourceCost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ModifyPTRResourceCost));
            this.lblMainPanel = new System.Windows.Forms.Label();
            this.btnModify = new MetroFramework.Controls.MetroButton();
            this.lblResourceID = new MetroFramework.Controls.MetroLabel();
            this.lblResourceIDtoFill = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblMainPanel
            // 
            this.lblMainPanel.AutoSize = true;
            this.lblMainPanel.BackColor = System.Drawing.Color.Transparent;
            this.lblMainPanel.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainPanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMainPanel.Location = new System.Drawing.Point(23, 23);
            this.lblMainPanel.Name = "lblMainPanel";
            this.lblMainPanel.Size = new System.Drawing.Size(195, 25);
            this.lblMainPanel.TabIndex = 329;
            this.lblMainPanel.Text = "Resource Cost Modify";
            // 
            // btnModify
            // 
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.Location = new System.Drawing.Point(701, 444);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(76, 38);
            this.btnModify.TabIndex = 330;
            this.btnModify.Text = "Modify";
            this.btnModify.UseSelectable = true;
            // 
            // lblResourceID
            // 
            this.lblResourceID.AutoSize = true;
            this.lblResourceID.Location = new System.Drawing.Point(26, 70);
            this.lblResourceID.Name = "lblResourceID";
            this.lblResourceID.Size = new System.Drawing.Size(81, 19);
            this.lblResourceID.TabIndex = 334;
            this.lblResourceID.Text = "Resource ID:";
            // 
            // lblResourceIDtoFill
            // 
            this.lblResourceIDtoFill.AutoSize = true;
            this.lblResourceIDtoFill.Location = new System.Drawing.Point(112, 70);
            this.lblResourceIDtoFill.Name = "lblResourceIDtoFill";
            this.lblResourceIDtoFill.Size = new System.Drawing.Size(23, 19);
            this.lblResourceIDtoFill.TabIndex = 333;
            this.lblResourceIDtoFill.Text = "{-}";
            // 
            // frm_ModifyPTRResourceCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.lblResourceID);
            this.Controls.Add(this.lblResourceIDtoFill);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.lblMainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_ModifyPTRResourceCost";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMainPanel;
        private MetroFramework.Controls.MetroButton btnModify;
        private MetroFramework.Controls.MetroLabel lblResourceID;
        private MetroFramework.Controls.MetroLabel lblResourceIDtoFill;
    }
}