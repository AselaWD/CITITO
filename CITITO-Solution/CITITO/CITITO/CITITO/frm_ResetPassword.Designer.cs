namespace CITITO
{
    partial class frm_ResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ResetPassword));
            this.lblUID = new MetroFramework.Controls.MetroLabel();
            this.lblResetPassword = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pBoxCorrect = new System.Windows.Forms.PictureBox();
            this.lblPasswordMessage = new MetroFramework.Controls.MetroLabel();
            this.txtRePassword = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.lblRePassword = new MetroFramework.Controls.MetroLabel();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.pBoxError = new System.Windows.Forms.PictureBox();
            this.txtOldPassword = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCorrect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxError)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(602, 26);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(30, 19);
            this.lblUID.TabIndex = 192;
            this.lblUID.Text = "UID";
            this.lblUID.Visible = false;
            // 
            // lblResetPassword
            // 
            this.lblResetPassword.AutoSize = true;
            this.lblResetPassword.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblResetPassword.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblResetPassword.Location = new System.Drawing.Point(117, 45);
            this.lblResetPassword.Name = "lblResetPassword";
            this.lblResetPassword.Size = new System.Drawing.Size(134, 25);
            this.lblResetPassword.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblResetPassword.TabIndex = 194;
            this.lblResetPassword.Text = "Reset Password";
            this.lblResetPassword.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 193;
            this.pictureBox1.TabStop = false;
            // 
            // pBoxCorrect
            // 
            this.pBoxCorrect.Image = ((System.Drawing.Image)(resources.GetObject("pBoxCorrect.Image")));
            this.pBoxCorrect.Location = new System.Drawing.Point(334, 177);
            this.pBoxCorrect.Name = "pBoxCorrect";
            this.pBoxCorrect.Size = new System.Drawing.Size(22, 19);
            this.pBoxCorrect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxCorrect.TabIndex = 202;
            this.pBoxCorrect.TabStop = false;
            this.pBoxCorrect.Visible = false;
            // 
            // lblPasswordMessage
            // 
            this.lblPasswordMessage.AutoSize = true;
            this.lblPasswordMessage.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPasswordMessage.Location = new System.Drawing.Point(356, 177);
            this.lblPasswordMessage.Name = "lblPasswordMessage";
            this.lblPasswordMessage.Size = new System.Drawing.Size(22, 19);
            this.lblPasswordMessage.TabIndex = 201;
            this.lblPasswordMessage.Text = "M";
            this.lblPasswordMessage.UseCustomForeColor = true;
            this.lblPasswordMessage.Visible = false;
            // 
            // txtRePassword
            // 
            // 
            // 
            // 
            this.txtRePassword.CustomButton.Image = null;
            this.txtRePassword.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtRePassword.CustomButton.Name = "";
            this.txtRePassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRePassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRePassword.CustomButton.TabIndex = 1;
            this.txtRePassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRePassword.CustomButton.UseSelectable = true;
            this.txtRePassword.CustomButton.Visible = false;
            this.txtRePassword.Lines = new string[0];
            this.txtRePassword.Location = new System.Drawing.Point(129, 194);
            this.txtRePassword.MaxLength = 32767;
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '●';
            this.txtRePassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRePassword.SelectedText = "";
            this.txtRePassword.SelectionLength = 0;
            this.txtRePassword.SelectionStart = 0;
            this.txtRePassword.ShortcutsEnabled = true;
            this.txtRePassword.Size = new System.Drawing.Size(199, 23);
            this.txtRePassword.TabIndex = 3;
            this.txtRePassword.UseCustomBackColor = true;
            this.txtRePassword.UseSelectable = true;
            this.txtRePassword.UseSystemPasswordChar = true;
            this.txtRePassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRePassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtRePassword.TextChanged += new System.EventHandler(this.txtRePassword_TextChanged);
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(129, 156);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(199, 23);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseCustomBackColor = true;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblRePassword
            // 
            this.lblRePassword.AutoSize = true;
            this.lblRePassword.Location = new System.Drawing.Point(36, 198);
            this.lblRePassword.Name = "lblRePassword";
            this.lblRePassword.Size = new System.Drawing.Size(87, 19);
            this.lblRePassword.TabIndex = 199;
            this.lblRePassword.Text = "Re-Password:";
            this.lblRePassword.UseCustomBackColor = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(27, 160);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(96, 19);
            this.lblPassword.TabIndex = 200;
            this.lblPassword.Text = "New Password:";
            this.lblPassword.UseCustomBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(552, 274);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 198;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(445, 274);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 32);
            this.btnUpdate.TabIndex = 197;
            this.btnUpdate.Text = "Modify";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pBoxError
            // 
            this.pBoxError.Image = ((System.Drawing.Image)(resources.GetObject("pBoxError.Image")));
            this.pBoxError.Location = new System.Drawing.Point(334, 177);
            this.pBoxError.Name = "pBoxError";
            this.pBoxError.Size = new System.Drawing.Size(22, 19);
            this.pBoxError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxError.TabIndex = 203;
            this.pBoxError.TabStop = false;
            this.pBoxError.Visible = false;
            // 
            // txtOldPassword
            // 
            // 
            // 
            // 
            this.txtOldPassword.CustomButton.Image = null;
            this.txtOldPassword.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtOldPassword.CustomButton.Name = "";
            this.txtOldPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOldPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOldPassword.CustomButton.TabIndex = 1;
            this.txtOldPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOldPassword.CustomButton.UseSelectable = true;
            this.txtOldPassword.CustomButton.Visible = false;
            this.txtOldPassword.Lines = new string[0];
            this.txtOldPassword.Location = new System.Drawing.Point(129, 118);
            this.txtOldPassword.MaxLength = 32767;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '●';
            this.txtOldPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOldPassword.SelectedText = "";
            this.txtOldPassword.SelectionLength = 0;
            this.txtOldPassword.SelectionStart = 0;
            this.txtOldPassword.ShortcutsEnabled = true;
            this.txtOldPassword.Size = new System.Drawing.Size(199, 23);
            this.txtOldPassword.TabIndex = 1;
            this.txtOldPassword.UseCustomBackColor = true;
            this.txtOldPassword.UseSelectable = true;
            this.txtOldPassword.UseSystemPasswordChar = true;
            this.txtOldPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOldPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(31, 122);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(92, 19);
            this.metroLabel1.TabIndex = 205;
            this.metroLabel1.Text = "Old Password:";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // frm_ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 331);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pBoxError);
            this.Controls.Add(this.pBoxCorrect);
            this.Controls.Add(this.lblPasswordMessage);
            this.Controls.Add(this.txtRePassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblRePassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblResetPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblUID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_ResetPassword";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_ResetPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCorrect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblUID;
        private MetroFramework.Controls.MetroLabel lblResetPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pBoxCorrect;
        private MetroFramework.Controls.MetroLabel lblPasswordMessage;
        private MetroFramework.Controls.MetroTextBox txtRePassword;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroLabel lblRePassword;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnUpdate;
        private System.Windows.Forms.PictureBox pBoxError;
        private MetroFramework.Controls.MetroTextBox txtOldPassword;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}