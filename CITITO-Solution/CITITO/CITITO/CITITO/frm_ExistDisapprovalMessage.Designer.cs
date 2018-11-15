namespace CITITO
{
    partial class frm_ExistDisapprovalMessage
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
            this.btnOK = new MetroFramework.Controls.MetroButton();
            this.richTextBoxExistCodes = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Location = new System.Drawing.Point(311, 293);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 36);
            this.btnOK.TabIndex = 238;
            this.btnOK.Text = "Ok";
            this.btnOK.UseSelectable = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // richTextBoxExistCodes
            // 
            this.richTextBoxExistCodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxExistCodes.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxExistCodes.Location = new System.Drawing.Point(16, 90);
            this.richTextBoxExistCodes.Name = "richTextBoxExistCodes";
            this.richTextBoxExistCodes.Size = new System.Drawing.Size(397, 197);
            this.richTextBoxExistCodes.TabIndex = 237;
            this.richTextBoxExistCodes.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 236;
            this.label2.Text = "Process Completed.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 34);
            this.label1.TabIndex = 235;
            this.label1.Text = "\r\nHence following error detail(s), record(s) not disapproved.";
            // 
            // frm_ExistDisapprovalMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 347);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.richTextBoxExistCodes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frm_ExistDisapprovalMessage";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_ExistDisapprovalMessage_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnOK;
        private System.Windows.Forms.RichTextBox richTextBoxExistCodes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}