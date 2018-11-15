namespace CITITO
{
    partial class frm_UserAssignDeleteFromProjectPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserAssignDeleteFromProjectPanel));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelUserAssignDeleteFromProject = new MetroFramework.Controls.MetroPanel();
            this.tileDelete = new MetroFramework.Controls.MetroTile();
            this.tileAssign = new MetroFramework.Controls.MetroTile();
            this.lblPIC = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(107, 37);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(265, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 186;
            this.metroLabel1.Text = "User Assign/Delete from Project";
            this.metroLabel1.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 185;
            this.pictureBox1.TabStop = false;
            // 
            // panelUserAssignDeleteFromProject
            // 
            this.panelUserAssignDeleteFromProject.HorizontalScrollbarBarColor = true;
            this.panelUserAssignDeleteFromProject.HorizontalScrollbarHighlightOnWheel = false;
            this.panelUserAssignDeleteFromProject.HorizontalScrollbarSize = 10;
            this.panelUserAssignDeleteFromProject.Location = new System.Drawing.Point(0, 132);
            this.panelUserAssignDeleteFromProject.Name = "panelUserAssignDeleteFromProject";
            this.panelUserAssignDeleteFromProject.Size = new System.Drawing.Size(545, 670);
            this.panelUserAssignDeleteFromProject.TabIndex = 187;
            this.panelUserAssignDeleteFromProject.VerticalScrollbarBarColor = true;
            this.panelUserAssignDeleteFromProject.VerticalScrollbarHighlightOnWheel = false;
            this.panelUserAssignDeleteFromProject.VerticalScrollbarSize = 10;
            // 
            // tileDelete
            // 
            this.tileDelete.ActiveControl = null;
            this.tileDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileDelete.Location = new System.Drawing.Point(131, 90);
            this.tileDelete.Name = "tileDelete";
            this.tileDelete.Size = new System.Drawing.Size(125, 42);
            this.tileDelete.Style = MetroFramework.MetroColorStyle.Green;
            this.tileDelete.TabIndex = 189;
            this.tileDelete.Text = "Delete Users";
            this.tileDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileDelete.UseSelectable = true;
            this.tileDelete.Click += new System.EventHandler(this.tileDelete_Click);
            // 
            // tileAssign
            // 
            this.tileAssign.ActiveControl = null;
            this.tileAssign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileAssign.Location = new System.Drawing.Point(0, 90);
            this.tileAssign.Name = "tileAssign";
            this.tileAssign.Size = new System.Drawing.Size(125, 42);
            this.tileAssign.Style = MetroFramework.MetroColorStyle.Teal;
            this.tileAssign.TabIndex = 188;
            this.tileAssign.Text = "Assign Users";
            this.tileAssign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileAssign.UseSelectable = true;
            this.tileAssign.Click += new System.EventHandler(this.tileAssign_Click);
            // 
            // lblPIC
            // 
            this.lblPIC.AutoSize = true;
            this.lblPIC.Location = new System.Drawing.Point(449, 43);
            this.lblPIC.Name = "lblPIC";
            this.lblPIC.Size = new System.Drawing.Size(29, 19);
            this.lblPIC.TabIndex = 190;
            this.lblPIC.Text = "PIC";
            this.lblPIC.Visible = false;
            // 
            // frm_UserAssignDeleteFromProjectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 803);
            this.Controls.Add(this.lblPIC);
            this.Controls.Add(this.tileDelete);
            this.Controls.Add(this.tileAssign);
            this.Controls.Add(this.panelUserAssignDeleteFromProject);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_UserAssignDeleteFromProjectPanel";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frm_UserAssignDeleteFromProjectPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroPanel panelUserAssignDeleteFromProject;
        private MetroFramework.Controls.MetroTile tileDelete;
        private MetroFramework.Controls.MetroTile tileAssign;
        private MetroFramework.Controls.MetroLabel lblPIC;
    }
}