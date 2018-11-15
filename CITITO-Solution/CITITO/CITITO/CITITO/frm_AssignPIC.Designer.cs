namespace CITITO
{
    partial class frm_AssignPIC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AssignPIC));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtCurrentOIC = new MetroFramework.Controls.MetroTextBox();
            this.lblCurrentName = new MetroFramework.Controls.MetroLabel();
            this.lblManagerUID = new MetroFramework.Controls.MetroLabel();
            this.lblAssignPIC = new MetroFramework.Controls.MetroLabel();
            this.cmbAssignPIC = new MetroFramework.Controls.MetroComboBox();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnAssign = new MetroFramework.Controls.MetroButton();
            this.lblName = new MetroFramework.Controls.MetroLabel();
            this.lblPass = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(102, 36);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(205, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 188;
            this.metroLabel1.Text = "Assign Project In Charge";
            this.metroLabel1.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 187;
            this.pictureBox1.TabStop = false;
            // 
            // txtCurrentOIC
            // 
            // 
            // 
            // 
            this.txtCurrentOIC.CustomButton.Image = null;
            this.txtCurrentOIC.CustomButton.Location = new System.Drawing.Point(101, 1);
            this.txtCurrentOIC.CustomButton.Name = "";
            this.txtCurrentOIC.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCurrentOIC.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrentOIC.CustomButton.TabIndex = 1;
            this.txtCurrentOIC.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrentOIC.CustomButton.UseSelectable = true;
            this.txtCurrentOIC.CustomButton.Visible = false;
            this.txtCurrentOIC.Enabled = false;
            this.txtCurrentOIC.Lines = new string[0];
            this.txtCurrentOIC.Location = new System.Drawing.Point(120, 100);
            this.txtCurrentOIC.MaxLength = 32767;
            this.txtCurrentOIC.Name = "txtCurrentOIC";
            this.txtCurrentOIC.PasswordChar = '\0';
            this.txtCurrentOIC.ReadOnly = true;
            this.txtCurrentOIC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrentOIC.SelectedText = "";
            this.txtCurrentOIC.SelectionLength = 0;
            this.txtCurrentOIC.SelectionStart = 0;
            this.txtCurrentOIC.ShortcutsEnabled = true;
            this.txtCurrentOIC.Size = new System.Drawing.Size(123, 23);
            this.txtCurrentOIC.TabIndex = 1;
            this.txtCurrentOIC.UseSelectable = true;
            this.txtCurrentOIC.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrentOIC.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCurrentName
            // 
            this.lblCurrentName.AutoSize = true;
            this.lblCurrentName.Location = new System.Drawing.Point(34, 104);
            this.lblCurrentName.Name = "lblCurrentName";
            this.lblCurrentName.Size = new System.Drawing.Size(80, 19);
            this.lblCurrentName.TabIndex = 190;
            this.lblCurrentName.Text = "Current PIC:";
            // 
            // lblManagerUID
            // 
            this.lblManagerUID.AutoSize = true;
            this.lblManagerUID.Location = new System.Drawing.Point(227, 61);
            this.lblManagerUID.Name = "lblManagerUID";
            this.lblManagerUID.Size = new System.Drawing.Size(83, 19);
            this.lblManagerUID.TabIndex = 191;
            this.lblManagerUID.Text = "ManagerUID";
            this.lblManagerUID.Visible = false;
            // 
            // lblAssignPIC
            // 
            this.lblAssignPIC.AutoSize = true;
            this.lblAssignPIC.Location = new System.Drawing.Point(41, 144);
            this.lblAssignPIC.Name = "lblAssignPIC";
            this.lblAssignPIC.Size = new System.Drawing.Size(73, 19);
            this.lblAssignPIC.TabIndex = 192;
            this.lblAssignPIC.Text = "Assign PIC:";
            // 
            // cmbAssignPIC
            // 
            this.cmbAssignPIC.FormattingEnabled = true;
            this.cmbAssignPIC.ItemHeight = 23;
            this.cmbAssignPIC.Location = new System.Drawing.Point(120, 134);
            this.cmbAssignPIC.Name = "cmbAssignPIC";
            this.cmbAssignPIC.Size = new System.Drawing.Size(121, 29);
            this.cmbAssignPIC.TabIndex = 2;
            this.cmbAssignPIC.UseSelectable = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(334, 207);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(227, 207);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(80, 32);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseSelectable = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(313, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 19);
            this.lblName.TabIndex = 193;
            this.lblName.Text = "mName";
            this.lblName.Visible = false;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(376, 61);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(45, 19);
            this.lblPass.TabIndex = 194;
            this.lblPass.Text = "mPass";
            this.lblPass.Visible = false;
            // 
            // frm_AssignPIC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 265);
            this.ControlBox = false;
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.cmbAssignPIC);
            this.Controls.Add(this.lblAssignPIC);
            this.Controls.Add(this.lblManagerUID);
            this.Controls.Add(this.txtCurrentOIC);
            this.Controls.Add(this.lblCurrentName);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_AssignPIC";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_AssignPIC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox txtCurrentOIC;
        private MetroFramework.Controls.MetroLabel lblCurrentName;
        private MetroFramework.Controls.MetroLabel lblManagerUID;
        private MetroFramework.Controls.MetroLabel lblAssignPIC;
        private MetroFramework.Controls.MetroComboBox cmbAssignPIC;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnAssign;
        private MetroFramework.Controls.MetroLabel lblName;
        private MetroFramework.Controls.MetroLabel lblPass;
    }
}