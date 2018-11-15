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
using CITITO.BusinessControls;
using CITITO.BusinessServices;
using System.Data.SqlClient;
using System.Security.Cryptography;
using MetroFramework.Forms;

namespace CITITO
{
    public partial class frm_ResetPassword : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_ResetPassword _instance;
        public static frm_ResetPassword GetInstance(string uID)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUserID = uID;

                _instance = new frm_ResetPassword(mUserID);

            }
            return _instance;

        }

        public frm_ResetPassword(string uID)
        {
            InitializeComponent();

            lblUID.Text = uID;
            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        private void frm_ResetPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (String.IsNullOrEmpty(txtOldPassword.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nOld Password field cannot be empty..!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOldPassword.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nNew Password field cannot be empty..!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(txtRePassword.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nRe-Password field cannot be empty..!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRePassword.Focus();
                    return;
                }
                if ((txtPassword.Text.Length) < 8)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPassword length should be more than 8 character.", "Invalid Password!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return;
                }
                if ((txtRePassword.Text.Length) < 8)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPassword length should be more than 8 character.", "Invalid Password!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRePassword.Focus();
                    return;
                }


                //Matching Pasword using MD5 Hash
                using (MD5 md5Hash = MD5.Create())
                {
                    PICDetail eLogin = new PICDetail();
                    ManagerHeader eMLogin = new ManagerHeader();
                    UserManagementHeader eULogin = new UserManagementHeader();

                    eLogin.PIC_UID = lblUID.Text;
                    eLogin.PIC_Password = ControlsHash.GetMd5Hash(md5Hash, txtOldPassword.Text);

                    eMLogin.M_UID = lblUID.Text;
                    eMLogin.M_Password = ControlsHash.GetMd5Hash(md5Hash, txtOldPassword.Text);
                    eMLogin.M_Availability = 1;

                    //User
                    eULogin.P_UID = lblUID.Text;
                    eULogin.P_Password = ControlsHash.GetMd5Hash(md5Hash, txtOldPassword.Text);
                    eULogin.P_Availability = 1;

                    if (ControlsHash.VerifyMd5Hash(md5Hash, txtOldPassword.Text, eLogin.PIC_Password) || ControlsHash.VerifyMd5Hash(md5Hash, txtOldPassword.Text, eMLogin.M_Password) || ControlsHash.VerifyMd5Hash(md5Hash, txtOldPassword.Text, eULogin.P_Password))
                    {
                        PICDetailMng mLogin = new PICDetailMng(conn);
                        ManagerHeaderMng mMLogin = new ManagerHeaderMng(conn);
                        UserManagementHeaderMng mULogin = new UserManagementHeaderMng(conn);

                        //Check User ID and Password
                        //PIC Password
                        if (mLogin.PICLogin(eLogin))
                        {
                            if (lblPasswordMessage.Text != "Matched!")
                            {
                                MetroFramework.MetroMessageBox.Show(this, "\nPasswords cannot be mismatched..!", "Mismatched Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.Focus();
                                return;
                            }
 
                            DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to reset your password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resulta == DialogResult.Yes)
                            {
                                PICDetailMng mPICDetailMng = new PICDetailMng(conn);
                                String mPassword = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);

                                if (mPICDetailMng.UpdatePICPassword(lblUID.Text,mPassword) > 0)
                                {
                                    MetroFramework.MetroMessageBox.Show(this, "\nPassword has been reset!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Application.OpenForms["frm_Login"].BringToFront();

                                    this.Close();

                                }
                            }
                        }
                        //Manager Password
                        else if (mMLogin.ManagerLogin(eMLogin))
                        {
                            if (lblPasswordMessage.Text != "Matched!")
                            {
                                MetroFramework.MetroMessageBox.Show(this, "\nPasswords cannot be mismatched..!", "Mismatched Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.Focus();
                                return;
                            }

                            DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to reset your password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resulta == DialogResult.Yes)
                            {
                                String mPassword = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);

                                if (mMLogin.UpdateManagerPassword(lblUID.Text, mPassword) > 0)
                                {
                                    MetroFramework.MetroMessageBox.Show(this, "\nPassword has been reset!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Application.OpenForms["frm_Login"].BringToFront();

                                    this.Close();

                                }
                            }

                        }
                        //User Password
                        else if (mULogin.UserLogin(eULogin))
                        {
                            if (lblPasswordMessage.Text != "Matched!")
                            {
                                MetroFramework.MetroMessageBox.Show(this, "\nPasswords cannot be mismatched..!", "Mismatched Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.Focus();
                                return;
                            }

                            DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to reset your password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resulta == DialogResult.Yes)
                            {
                                String mPassword = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);

                                if (mULogin.UpdateUserPassword(lblUID.Text, mPassword) > 0)
                                {
                                    MetroFramework.MetroMessageBox.Show(this, "\nPassword has been reset!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Application.OpenForms["frm_Login"].BringToFront();

                                    this.Close();

                                }
                            }

                        }


                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "\nEntered old password is incorrect Please check following reasons.\n - Check CAPSLOCK is off your Keyboard.\n - Remember password is Case-Sensitive.", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtOldPassword.Focus();
                        }
                    }                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_Login"].BringToFront();

            this.Close();
        }
    }
}
