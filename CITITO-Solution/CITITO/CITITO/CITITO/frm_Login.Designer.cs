namespace CITITO
{
    partial class frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pBoxMessage = new System.Windows.Forms.PictureBox();
            this.lblMessage = new MetroFramework.Controls.MetroLabel();
            this.lnkResetPassword = new MetroFramework.Controls.MetroLink();
            this.txtUname = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(71, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Login";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(94, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogin.Location = new System.Drawing.Point(66, 328);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(159, 49);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(204, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 9);
            this.label2.TabIndex = 6;
            this.label2.Text = "UID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(184, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 9);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password:";
            // 
            // pBoxMessage
            // 
            this.pBoxMessage.Image = ((System.Drawing.Image)(resources.GetObject("pBoxMessage.Image")));
            this.pBoxMessage.Location = new System.Drawing.Point(84, 274);
            this.pBoxMessage.Name = "pBoxMessage";
            this.pBoxMessage.Size = new System.Drawing.Size(27, 23);
            this.pBoxMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxMessage.TabIndex = 10;
            this.pBoxMessage.TabStop = false;
            this.pBoxMessage.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.ForestGreen;
            this.lblMessage.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblMessage.Location = new System.Drawing.Point(111, 276);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 0);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.UseCustomForeColor = true;
            this.lblMessage.UseStyleColors = true;
            // 
            // lnkResetPassword
            // 
            this.lnkResetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkResetPassword.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.lnkResetPassword.Location = new System.Drawing.Point(66, 394);
            this.lnkResetPassword.Name = "lnkResetPassword";
            this.lnkResetPassword.Size = new System.Drawing.Size(158, 20);
            this.lnkResetPassword.Style = MetroFramework.MetroColorStyle.Blue;
            this.lnkResetPassword.TabIndex = 12;
            this.lnkResetPassword.Text = "Reset Password";
            this.lnkResetPassword.UseSelectable = true;
            this.lnkResetPassword.UseStyleColors = true;
            this.lnkResetPassword.Click += new System.EventHandler(this.lnkResetPassword_Click);
            // 
            // txtUname
            // 
            this.txtUname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // 
            // 
            this.txtUname.CustomButton.Image = null;
            this.txtUname.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.txtUname.CustomButton.Name = "";
            this.txtUname.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtUname.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUname.CustomButton.TabIndex = 1;
            this.txtUname.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUname.CustomButton.UseSelectable = true;
            this.txtUname.CustomButton.Visible = false;
            this.txtUname.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtUname.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtUname.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txtUname.Lines = new string[0];
            this.txtUname.Location = new System.Drawing.Point(69, 165);
            this.txtUname.MaxLength = 32767;
            this.txtUname.Name = "txtUname";
            this.txtUname.PasswordChar = '\0';
            this.txtUname.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUname.SelectedText = "";
            this.txtUname.SelectionLength = 0;
            this.txtUname.SelectionStart = 0;
            this.txtUname.ShortcutsEnabled = true;
            this.txtUname.Size = new System.Drawing.Size(158, 33);
            this.txtUname.TabIndex = 1;
            this.txtUname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUname.UseCustomBackColor = true;
            this.txtUname.UseCustomForeColor = true;
            this.txtUname.UseSelectable = true;
            this.txtUname.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUname.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtUname.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUname_KeyUp);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtPassword.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtPassword.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(69, 211);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(158, 33);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.UseCustomBackColor = true;
            this.txtPassword.UseCustomForeColor = true;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 425);
            this.Controls.Add(this.lnkResetPassword);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pBoxMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Login";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Login_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Login_FormClosed);
            this.Load += new System.EventHandler(this.frm_Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_Login_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pBoxMessage;
        private MetroFramework.Controls.MetroLabel lblMessage;
        private MetroFramework.Controls.MetroLink lnkResetPassword;
        private MetroFramework.Controls.MetroTextBox txtUname;
        private MetroFramework.Controls.MetroTextBox txtPassword;
    }
}

