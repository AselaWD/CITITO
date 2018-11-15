namespace CITITO
{
    partial class frm_ExistBulkPTRCodesMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ExistBulkPTRCodesMessage));
            this.btnOK = new MetroFramework.Controls.MetroButton();
            this.richTextBoxExistCodes = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Location = new System.Drawing.Point(307, 303);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 36);
            this.btnOK.TabIndex = 234;
            this.btnOK.Text = "Ok";
            this.btnOK.UseSelectable = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // richTextBoxExistCodes
            // 
            this.richTextBoxExistCodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxExistCodes.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxExistCodes.Location = new System.Drawing.Point(12, 100);
            this.richTextBoxExistCodes.Name = "richTextBoxExistCodes";
            this.richTextBoxExistCodes.Size = new System.Drawing.Size(397, 197);
            this.richTextBoxExistCodes.TabIndex = 233;
            this.richTextBoxExistCodes.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 232;
            this.label2.Text = "Process Completed.";
            // 
            // frm_ExistBulkPTRCodesMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 351);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.richTextBoxExistCodes);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_ExistBulkPTRCodesMessage";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_ExistBulkPTRCodesMessage_FormClosing);
            this.Load += new System.EventHandler(this.frm_ExistBulkPTRCodesMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnOK;
        private System.Windows.Forms.RichTextBox richTextBoxExistCodes;
        private System.Windows.Forms.Label label2;
    }
}