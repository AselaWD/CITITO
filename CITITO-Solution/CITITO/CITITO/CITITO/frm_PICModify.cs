using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;
using System.Security.Cryptography;

namespace CITITO
{
    public partial class frm_PICModify : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_PICModify _instance;
        public static frm_PICModify GetInstance(String uID)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUserID = uID;

                _instance = new frm_PICModify(mUserID);

            }
            return _instance;

        }

        public frm_PICModify(String uID)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            //Get project name by Parameter
            lblManagerUID.Text = uID;
            txtCurrentName.Text = new PICDetailMng(this.conn).GetAllPICNameByUID(lblManagerUID.Text);


        }

        //Close button
        private void pboxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_PICRegisterPanel"].BringToFront();

            this.Close();
        }

        //Modify button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNewName.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPlease enter new manager name.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewName.Focus();
                return;
            }

            if (txtCurrentName.Text == txtNewName.Text)
            {
                MetroFramework.MetroMessageBox.Show(this, "\nBoth manager names are same!", "Manager Names Same!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewName.Focus();
                return;
            }

            DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify manager?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                PICDetailMng mPICDetailMng = new PICDetailMng(conn);

                if (chkModifyPassword.Checked == true)
                {
                    if (lblPasswordMessage.Text != "Matched!")
                    {
                        MetroFramework.MetroMessageBox.Show(this, "\nPasswords cannot be mismatched..!", "Mismatched Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Focus();
                        return;
                    }

                    using (MD5 md5Hash = MD5.Create())
                    {
                        String mPassword = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);

                        if (mPICDetailMng.UpdatePICNameWithPassword(lblManagerUID.Text, txtNewName.Text, mPassword) > 0)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "\n Manager details has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);     

                            
                            Application.OpenForms["frm_PICRegisterPanel"].BringToFront();
                            
                            this.Close();

                        }
                    }
                }
                else
                {
                    if (mPICDetailMng.UpdatePICName(lblManagerUID.Text, txtNewName.Text) > 0)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "\nManager details has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Application.OpenForms["frm_PICRegisterPanel"].BringToFront();
                        
                        this.Close();
                    }
                }

            }
            else
            {
                Application.OpenForms["frm_PICRegisterPanel"].BringToFront();
                this.Close();
            }
        }



        private void frm_ManagerModify_Load(object sender, EventArgs e)
        {
            lblPassword.Enabled = false;
            lblRePassword.Enabled = false;
            txtPassword.Enabled = false;
            txtRePassword.Enabled = false;
            

        }

        //Checkbox - Password Change
        private void chkModifyPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModifyPassword.Checked==true)
            {
                lblPassword.Enabled = true;
                lblRePassword.Enabled = true;
                txtPassword.Enabled = true;
                txtRePassword.Enabled = true;

            }
            else
            {
                lblPassword.Enabled = false;
                lblRePassword.Enabled = false;
                txtPassword.Enabled = false;
                txtRePassword.Enabled = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length <= 7)
            {
                pBoxCorrect.Visible = false;
                pBoxError.Visible = true;
                lblPasswordMessage.Visible = true;
                lblPasswordMessage.Text = "Length should be at least 8 Characters!";
                lblPasswordMessage.ForeColor = Color.Red;
            }
            else
            {
                lblPasswordMessage.Visible = false;
                pBoxCorrect.Visible = false;
                pBoxError.Visible = false;
            }
        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                pBoxCorrect.Visible = false;
                pBoxError.Visible = true;
                lblPasswordMessage.Visible = true;
                lblPasswordMessage.Text = "Password cannot be empty!";
                lblPasswordMessage.ForeColor = Color.Red;
            }
            else
            {
                if (txtPassword.Text.Length.Equals(txtRePassword.Text.Length))
                {
                    if (txtPassword.Text == txtRePassword.Text)
                    {
                        pBoxCorrect.Visible = true;
                        pBoxError.Visible = false;
                        lblPasswordMessage.Visible = true;
                        lblPasswordMessage.Text = "Matched!";
                        lblPasswordMessage.ForeColor = Color.Green;
                    }
                    else
                    {
                        pBoxCorrect.Visible = false;
                        pBoxError.Visible = true;
                        lblPasswordMessage.Visible = true;
                        lblPasswordMessage.Text = "Mismatched!";
                        lblPasswordMessage.ForeColor = Color.Red;
                    }
                }

                else if (txtPassword.Text.Length < txtRePassword.Text.Length)
                {
                    pBoxCorrect.Visible = false;
                    pBoxError.Visible = true;
                    lblPasswordMessage.Visible = true;
                    lblPasswordMessage.Text = "Mismatched!";
                    lblPasswordMessage.ForeColor = Color.Red;
                }
                else
                {
                    lblPasswordMessage.Visible = false;
                    pBoxCorrect.Visible = false;
                    pBoxError.Visible = false;
                }
            }
        }
    }
}
