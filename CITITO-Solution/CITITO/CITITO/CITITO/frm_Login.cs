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

    public partial class frm_Login : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_Login _instance;
        public static frm_Login GetInstance()
        {

            if (_instance == null || _instance.IsDisposed)
            {

                _instance = new frm_Login();

            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_Login()
        {
            InitializeComponent();
            
                try
            {
                //Global Variables
                conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232060)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is an issue on database connection. Please contact your Technical Assistant.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        /*CITITO Server Time*/
        public DateTime ServerDateTime()
        {
            ServerTime mServerTime = new ServerTime(this.conn);
            DateTime sDate = mServerTime.getServerTime();
            return sDate;
        }

        //Login button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Validate User ID
            if (string.IsNullOrEmpty(txtUname.Text))
            {
               MetroFramework.MetroMessageBox.Show(this, "\nPlease enter user ID", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUname.Focus();
                return;
            }

            if ((txtPassword.Text.Length) < 8)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPassword length should be more than 8 character. Please enter correct lengthed password or reset your password.", "Invalid Password!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            string uManmeAdmin = txtUname.Text;
            if (uManmeAdmin == "admin" && txtPassword.Text== "CadminTITO@159")
            {
                //UserID,UserName,UserImmediateReporter,UserDepartment,UserSystemAccessLevel
                string mPICUserID = "Admin";
                string mPICName = "Admin";
                DateTime mLoggedTime = ServerDateTime();

                //Form Open by PIC System Access Level
                FiledClearUnAndPass();

                frm_MainForm_Admin form = frm_MainForm_Admin.GetInstance(mPICUserID, mPICName, mLoggedTime);
                if (!form.Visible)
                {
                    this.Hide();
                    form.Show();

                    ////Splash Close
                    //SplashScreen spalsh = SplashScreen.GetInstance();
                    //if (!spalsh.Visible)
                    //{
                    //    spalsh.Close();
                    //}
                    //else
                    //{
                    //    spalsh.Close();
                    //}

                    Application.OpenForms["frm_Login"].Hide();

                }
                else
                {
                    form.BringToFront();

                    ////Splash Close
                    //SplashScreen spalsh = SplashScreen.GetInstance();
                    //if (!spalsh.Visible)
                    //{
                    //    spalsh.Close();
                    //}
                    //else
                    //{
                    //    spalsh.Close();
                    //}

                    Application.OpenForms["frm_Login"].Hide();
                }
            }
            else
            {
                try
                {
                    //Matching Pasword using MD5 Hash
                    using (MD5 md5Hash = MD5.Create())
                    {
                        PICDetail eLogin = new PICDetail();
                        ManagerHeader eMLogin = new ManagerHeader();
                        UserManagementHeader eULogin = new UserManagementHeader();

                        //PIC
                        eLogin.PIC_UID = txtUname.Text;
                        eLogin.PIC_Password = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);

                        //Manager
                        eMLogin.M_UID = txtUname.Text;
                        eMLogin.M_Password = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);
                        eMLogin.M_Availability = 1;

                        //User
                        eULogin.P_UID = txtUname.Text;
                        eULogin.P_Password = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);
                        eULogin.P_Availability = 1;
                        

                        //PIC Login
                        if (ControlsHash.VerifyMd5Hash(md5Hash, txtPassword.Text, eLogin.PIC_Password) == true || ControlsHash.VerifyMd5Hash(md5Hash, txtPassword.Text, eMLogin.M_Password) == true || ControlsHash.VerifyMd5Hash(md5Hash, txtPassword.Text, eULogin.P_Password) == true)
                        {
                            PICDetailMng mLogin = new PICDetailMng(conn);


                            //Check User ID and Password
                            if (mLogin.PICLogin(eLogin) == true)
                            {
                                //MessageBox.Show("You have been successfully logged in.", "Log in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Pass Employee Details to the Main Form
                                if (mLogin.GetPICLoginDetails(eLogin).Rows.Count == 1)
                                {
                                    //UserID,UserName,UserImmediateReporter,UserDepartment,UserSystemAccessLevel
                                    string mPICUserID = mLogin.GetPICLoginDetails(eLogin).Rows[0][0].ToString();
                                    string mPICName = mLogin.GetPICLoginDetails(eLogin).Rows[0][1].ToString();
                                    DateTime mLoggedTime = ServerDateTime();

                                    //Form Open by PIC System Access Level
                                    FiledClearUnAndPass();

                                    frm_MainForm_PIC form = frm_MainForm_PIC.GetInstance(mPICUserID, mPICName, mLoggedTime);
                                    if (!form.Visible)
                                    {
                                        this.Hide();
                                        form.Show();

                                        ////Splash Close
                                        //SplashScreen spalsh = SplashScreen.GetInstance();
                                        //if (!spalsh.Visible)
                                        //{
                                        //    spalsh.Close();
                                        //}
                                        //else
                                        //{
                                        //    spalsh.Close();
                                        //}

                                        Application.OpenForms["frm_Login"].Hide();

                                    }
                                    else
                                    {
                                        form.BringToFront();

                                        ////Splash Close
                                        //SplashScreen spalsh = SplashScreen.GetInstance();
                                        //if (!spalsh.Visible)
                                        //{
                                        //    spalsh.Close();
                                        //}
                                        //else
                                        //{
                                        //    spalsh.Close();
                                        //}

                                        Application.OpenForms["frm_Login"].Hide();
                                    }

                                }
                                return;
                            }

                            //Check User ID and Password
                            ManagerHeaderMng mMLogin = new ManagerHeaderMng(this.conn);
                            if (mMLogin.ManagerLogin(eMLogin) == true)
                            {
                                //MessageBox.Show("You have been successfully logged in.", "Log in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Pass Employee Details to the Main Form
                                if (mMLogin.GetManagerLoginDetails(eMLogin).Rows.Count == 1)
                                {
                                    //UserID,UserName,UserImmediateReporter,UserDepartment,UserSystemAccessLevel
                                    string mMUserID = mMLogin.GetManagerLoginDetails(eMLogin).Rows[0][0].ToString();
                                    string mMName = mMLogin.GetManagerLoginDetails(eMLogin).Rows[0][1].ToString();
                                    string mMAccessLevel = mMLogin.GetManagerLoginDetails(eMLogin).Rows[0][3].ToString();
                                    DateTime mMLoggedTime = ServerDateTime();

                                    //Form Open by Manager and DCD System Access Level                                   
                                    if (mMAccessLevel== "Immediate Manager")
                                    {
                                        FiledClearUnAndPass();

                                        frm_MainForm_Manager form = frm_MainForm_Manager.GetInstance(mMUserID, mMName, mMLoggedTime);
                                        if (!form.Visible)
                                        {
                                            this.Hide();
                                            form.Show();

                                            ////Splash Close
                                            //SplashScreen spalsh = SplashScreen.GetInstance();
                                            //if (!spalsh.Visible)
                                            //{
                                            //    spalsh.Close();
                                            //}
                                            //else
                                            //{
                                            //    spalsh.Close();
                                            //}

                                            Application.OpenForms["frm_Login"].Hide();

                                        }
                                        else
                                        {
                                            form.BringToFront();

                                            ////Splash Close
                                            //SplashScreen spalsh = SplashScreen.GetInstance();
                                            //if (!spalsh.Visible)
                                            //{
                                            //    spalsh.Close();
                                            //}
                                            //else
                                            //{
                                            //    spalsh.Close();
                                            //}

                                            Application.OpenForms["frm_Login"].Hide();
                                        }
                                    }
                                    if (mMAccessLevel == "DCD")
                                    {
                                        FiledClearUnAndPass();

                                        frm_DCD form = frm_DCD.GetInstance(mMUserID, mMName, mMAccessLevel, mMLoggedTime);
                                        if (!form.Visible)
                                        {
                                            this.Hide();
                                            form.Show();

                                            ////Splash Close
                                            //SplashScreen spalsh = SplashScreen.GetInstance();
                                            //if (!spalsh.Visible)
                                            //{
                                            //    spalsh.Close();
                                            //}
                                            //else
                                            //{
                                            //    spalsh.Close();
                                            //}

                                            Application.OpenForms["frm_Login"].Hide();

                                        }
                                        else
                                        {
                                            form.BringToFront();

                                            ////Splash Close
                                            //SplashScreen spalsh = SplashScreen.GetInstance();
                                            //if (!spalsh.Visible)
                                            //{
                                            //    spalsh.Close();
                                            //}
                                            //else
                                            //{
                                            //    spalsh.Close();
                                            //}

                                            Application.OpenForms["frm_Login"].Hide();
                                        }
                                    }

                                }
                                return;
                            }

                            //Check User ID and Password
                            UserManagementHeaderMng mULogin = new UserManagementHeaderMng(this.conn);
                            if (mULogin.UserLogin(eULogin) == true)
                            {
                                //MessageBox.Show("You have been successfully logged in.", "Log in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Pass Employee Details to the Main Form
                                if (mULogin.GetUserLoginDetails(eULogin).Rows.Count == 1)
                                {
                                    //UserID,UserName,UserImmediateReporter,UserDepartment,UserSystemAccessLevel
                                    string mUUserID = mULogin.GetUserLoginDetails(eULogin).Rows[0][0].ToString();
                                    string mUName = mULogin.GetUserLoginDetails(eULogin).Rows[0][1].ToString();
                                    string mUAccessLevel = mULogin.GetUserLoginDetails(eULogin).Rows[0][3].ToString();

                                    DateTime mMLoggedTime = ServerDateTime();

                                    //Form Open by PIC System Access Level
                                    
                                    if (mUAccessLevel == "Common User")
                                    {
                                        //MessageBox.Show("You have been successfully logged in as Common User.", "Log in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        FiledClearUnAndPass();

                                        frm_UserTaskInOut form = frm_UserTaskInOut.GetInstance(mUUserID, mUName, mUAccessLevel, mMLoggedTime);
                                        if (!form.Visible)
                                        {
                                            this.Hide();
                                            form.Show();

                                            ////Splash Close
                                            //SplashScreen spalsh = SplashScreen.GetInstance();
                                            //if (!spalsh.Visible)
                                            //{
                                            //    spalsh.Close();
                                            //}
                                            //else
                                            //{
                                            //    spalsh.Close();
                                            //}

                                            Application.OpenForms["frm_Login"].Hide();

                                        }
                                        else
                                        {
                                            form.BringToFront();

                                            ////Splash Close
                                            //SplashScreen spalsh = SplashScreen.GetInstance();
                                            //if (!spalsh.Visible)
                                            //{
                                            //    spalsh.Close();
                                            //}
                                            //else
                                            //{
                                            //    spalsh.Close();
                                            //}

                                            Application.OpenForms["frm_Login"].Hide();
                                        }
                                    }                                    

                                }
                                return;
                            }

                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "\nYour Login is incorrect.\n\n - Check Your User ID.\n - Check CAPSLOCK is off your Keyboard.\n - Remember password is Case-Sensitive.", "Log in Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.Focus();
                            }
                        }

                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "\nYour Login is incorrect.\n\n - Check Your User ID.\n - Check CAPSLOCK is off your Keyboard.\n - Remember password is Case-Sensitive.", "Log in Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Focus();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //Key press "Enter" to login to the System
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Validate User ID
                if (string.IsNullOrEmpty(txtUname.Text))
                {
                   MetroFramework.MetroMessageBox.Show(this, "\nPlease enter user ID", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUname.Focus();
                    return;
                }


                if ((txtPassword.Text.Length) < 8)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPassword length should be more than 8 character. Please enter correct length password or reset your password.", "Invalid Password!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return;
                }

                string uManmeAdmin = txtUname.Text;
                if (uManmeAdmin == "admin" && txtPassword.Text == "CadminTITO@159")
                {
                    //UserID,UserName,UserImmediateReporter,UserDepartment,UserSystemAccessLevel
                    string mPICUserID = "Admin";
                    string mPICName = "Admin";
                    DateTime mLoggedTime = ServerDateTime();

                    //Form Open by PIC System Access Level
                    FiledClearUnAndPass();

                    frm_MainForm_Admin form = frm_MainForm_Admin.GetInstance(mPICUserID, mPICName, mLoggedTime);
                    if (!form.Visible)
                    {
                        this.Hide();
                        form.Show();

                        ////Splash Close
                        //SplashScreen spalsh = SplashScreen.GetInstance();
                        //if (!spalsh.Visible)
                        //{
                        //    spalsh.Close();
                        //}
                        //else
                        //{
                        //    spalsh.Close();
                        //}

                        Application.OpenForms["frm_Login"].Hide();

                    }
                    else
                    {
                        form.BringToFront();

                        ////Splash Close
                        //SplashScreen spalsh = SplashScreen.GetInstance();
                        //if (!spalsh.Visible)
                        //{
                        //    spalsh.Close();
                        //}
                        //else
                        //{
                        //    spalsh.Close();
                        //}

                        Application.OpenForms["frm_Login"].Hide();
                    }
                }
                else
                {
                    try
                    {
                        //Matching Pasword using MD5 Hash
                        using (MD5 md5Hash = MD5.Create())
                        {
                            PICDetail eLogin = new PICDetail();
                            ManagerHeader eMLogin = new ManagerHeader();
                            UserManagementHeader eULogin = new UserManagementHeader();

                            //PIC
                            eLogin.PIC_UID = txtUname.Text;
                            eLogin.PIC_Password = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);

                            //Manager
                            eMLogin.M_UID = txtUname.Text;
                            eMLogin.M_Password = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);
                            eMLogin.M_Availability = 1;

                            //User
                            eULogin.P_UID = txtUname.Text;
                            eULogin.P_Password = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);
                            eULogin.P_Availability = 1;


                            //PIC Login
                            if (ControlsHash.VerifyMd5Hash(md5Hash, txtPassword.Text, eLogin.PIC_Password) == true || ControlsHash.VerifyMd5Hash(md5Hash, txtPassword.Text, eMLogin.M_Password) == true || ControlsHash.VerifyMd5Hash(md5Hash, txtPassword.Text, eULogin.P_Password) == true)
                            {
                                PICDetailMng mLogin = new PICDetailMng(conn);


                                //Check User ID and Password
                                if (mLogin.PICLogin(eLogin) == true)
                                {
                                    //MessageBox.Show("You have been successfully logged in.", "Log in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //Pass Employee Details to the Main Form
                                    if (mLogin.GetPICLoginDetails(eLogin).Rows.Count == 1)
                                    {
                                        //UserID,UserName,UserImmediateReporter,UserDepartment,UserSystemAccessLevel
                                        string mPICUserID = mLogin.GetPICLoginDetails(eLogin).Rows[0][0].ToString();
                                        string mPICName = mLogin.GetPICLoginDetails(eLogin).Rows[0][1].ToString();
                                        DateTime mLoggedTime = ServerDateTime();

                                        //Form Open by PIC System Access Level
                                        FiledClearUnAndPass();

                                        frm_MainForm_PIC form = frm_MainForm_PIC.GetInstance(mPICUserID, mPICName, mLoggedTime);
                                        if (!form.Visible)
                                        {
                                            this.Hide();
                                            form.Show();

                                            ////Splash Close
                                            //SplashScreen spalsh = SplashScreen.GetInstance();
                                            //if (!spalsh.Visible)
                                            //{
                                            //    spalsh.Close();
                                            //}
                                            //else
                                            //{
                                            //    spalsh.Close();
                                            //}

                                            Application.OpenForms["frm_Login"].Hide();

                                        }
                                        else
                                        {
                                            form.BringToFront();

                                            ////Splash Close
                                            //SplashScreen spalsh = SplashScreen.GetInstance();
                                            //if (!spalsh.Visible)
                                            //{
                                            //    spalsh.Close();
                                            //}
                                            //else
                                            //{
                                            //    spalsh.Close();
                                            //}

                                            Application.OpenForms["frm_Login"].Hide();
                                        }


                                    }
                                    return;
                                }

                                //Check User ID and Password
                                ManagerHeaderMng mMLogin = new ManagerHeaderMng(this.conn);
                                if (mMLogin.ManagerLogin(eMLogin) == true)
                                {
                                    //MessageBox.Show("You have been successfully logged in.", "Log in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //Pass Employee Details to the Main Form
                                    if (mMLogin.GetManagerLoginDetails(eMLogin).Rows.Count == 1)
                                    {
                                        //UserID,UserName,UserImmediateReporter,UserDepartment,UserSystemAccessLevel
                                        string mMUserID = mMLogin.GetManagerLoginDetails(eMLogin).Rows[0][0].ToString();
                                        string mMName = mMLogin.GetManagerLoginDetails(eMLogin).Rows[0][1].ToString();
                                        string mMAccessLevel = mMLogin.GetManagerLoginDetails(eMLogin).Rows[0][3].ToString();
                                        DateTime mMLoggedTime = ServerDateTime();

                                        //Form Open by Manager and DCD System Access Level                                   
                                        if (mMAccessLevel == "Immediate Manager")
                                        {
                                            FiledClearUnAndPass();

                                            frm_MainForm_Manager form = frm_MainForm_Manager.GetInstance(mMUserID, mMName, mMLoggedTime);
                                            if (!form.Visible)
                                            {
                                                this.Hide();
                                                form.Show();

                                                ////Splash Close
                                                //SplashScreen spalsh = SplashScreen.GetInstance();
                                                //if (!spalsh.Visible)
                                                //{
                                                //    spalsh.Close();
                                                //}
                                                //else
                                                //{
                                                //    spalsh.Close();
                                                //}

                                                Application.OpenForms["frm_Login"].Hide();

                                            }
                                            else
                                            {
                                                form.BringToFront();

                                                ////Splash Close
                                                //SplashScreen spalsh = SplashScreen.GetInstance();
                                                //if (!spalsh.Visible)
                                                //{
                                                //    spalsh.Close();
                                                //}
                                                //else
                                                //{
                                                //    spalsh.Close();
                                                //}

                                                Application.OpenForms["frm_Login"].Hide();
                                            }
                                        }
                                        if (mMAccessLevel == "DCD")
                                        {
                                            FiledClearUnAndPass();

                                            frm_DCD form = frm_DCD.GetInstance(mMUserID, mMName, mMAccessLevel, mMLoggedTime);
                                            if (!form.Visible)
                                            {
                                                this.Hide();
                                                form.Show();

                                                ////Splash Close
                                                //SplashScreen spalsh = SplashScreen.GetInstance();
                                                //if (!spalsh.Visible)
                                                //{
                                                //    spalsh.Close();
                                                //}
                                                //else
                                                //{
                                                //    spalsh.Close();
                                                //}

                                                Application.OpenForms["frm_Login"].Hide();

                                            }
                                            else
                                            {
                                                form.BringToFront();

                                                ////Splash Close
                                                //SplashScreen spalsh = SplashScreen.GetInstance();
                                                //if (!spalsh.Visible)
                                                //{
                                                //    spalsh.Close();
                                                //}
                                                //else
                                                //{
                                                //    spalsh.Close();
                                                //}

                                                Application.OpenForms["frm_Login"].Hide();
                                            }
                                        }

                                    }
                                    return;
                                }

                                //Check User ID and Password
                                UserManagementHeaderMng mULogin = new UserManagementHeaderMng(this.conn);
                                if (mULogin.UserLogin(eULogin) == true)
                                {
                                    //MessageBox.Show("You have been successfully logged in.", "Log in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //Pass Employee Details to the Main Form
                                    if (mULogin.GetUserLoginDetails(eULogin).Rows.Count == 1)
                                    {
                                        //UserID,UserName,UserImmediateReporter,UserDepartment,UserSystemAccessLevel
                                        string mUUserID = mULogin.GetUserLoginDetails(eULogin).Rows[0][0].ToString();
                                        string mUName = mULogin.GetUserLoginDetails(eULogin).Rows[0][1].ToString();
                                        string mUAccessLevel = mULogin.GetUserLoginDetails(eULogin).Rows[0][3].ToString();

                                        DateTime mMLoggedTime = ServerDateTime();

                                        //Form Open by User System Access Level                                                                            
                                        if (mUAccessLevel == "Common User")
                                        {
                                            //MessageBox.Show("You have been successfully logged in as Common User.", "Log in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            FiledClearUnAndPass();

                                            frm_UserTaskInOut form = frm_UserTaskInOut.GetInstance(mUUserID, mUName, mUAccessLevel, mMLoggedTime);
                                            if (!form.Visible)
                                            {
                                                this.Hide();
                                                form.Show();
                                                

                                                ////Splash Close
                                                //SplashScreen spalsh = SplashScreen.GetInstance();
                                                //if (!spalsh.Visible)
                                                //{
                                                //    spalsh.Close();
                                                //}
                                                //else
                                                //{
                                                //    spalsh.Close();
                                                //}

                                                Application.OpenForms["frm_Login"].Hide();
                                            }
                                            else
                                            {
                                                this.Hide();
                                                form.BringToFront();                                               
                                               
                                                ////Splash Close
                                                //SplashScreen spalsh = SplashScreen.GetInstance();
                                                //if (!spalsh.Visible)
                                                //{
                                                //    spalsh.Close();
                                                //}
                                                //else
                                                //{
                                                //    spalsh.Close();
                                                //}
                                                Application.OpenForms["frm_Login"].Hide();
                                            }
                                        }

                                    }
                                    return;
                                }

                                else
                                {
                                    MetroFramework.MetroMessageBox.Show(this, "\nYour Login is incorrect.\n\n - Check Your User ID.\n - Check CAPSLOCK is off your Keyboard.\n - Remember password is Case-Sensitive.", "Log in Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtPassword.Focus();
                                }
                            }

                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "\nYour Login is incorrect.\n\n - Check Your User ID.\n - Check CAPSLOCK is off your Keyboard.\n - Remember password is Case-Sensitive.", "Log in Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.Focus();
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                
            }
            else
            {
                //..
            }
        }

        public void FiledClearUnAndPass()
        {
            txtPassword.Text = String.Empty;
            txtUname.Text = String.Empty;
            txtUname.Focus();
        }
        //Start >> frm_UserManagement enable move using mouse left down
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void frm_Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //End >> frm_UserManagement enable move using mouse left down

        //Close button
        private void pboxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        //Start >> CapsLock key Manage
        private void txtUname_KeyUp(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                pBoxMessage.Visible = true;
                lblMessage.Text = "Caps Lock On";
            }
            else
            {
                pBoxMessage.Visible = false;
                lblMessage.Text = "";
            }
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            txtPassword.AutoSize = false;
            

            this.BringToFront();

            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                pBoxMessage.Visible = true;
                lblMessage.Text = "Caps Lock On";
            }
            else
            {
                pBoxMessage.Visible = false;
                lblMessage.Text = "";
            }
            
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                pBoxMessage.Visible = true;
                lblMessage.Text = "Caps Lock On";
            }
            else
            {
                pBoxMessage.Visible = false;
                lblMessage.Text = "";
            }
        }

        //End >> CapsLock key Manage

        private void frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frm_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Reset Password
        private void lnkResetPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUname.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPlease enter user ID.", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUname.Focus();
                return;
            }

            string uManmeAdmin = txtUname.Text;
            if (uManmeAdmin == "admin")
            {
                MetroFramework.MetroMessageBox.Show(this, "\nYou have no privileges to modify \"Admin\" password.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUname.Focus();
                return;
            }

            string mUID = txtUname.Text;

            if (!new PICHeaderMng(this.conn).PICIsExist(mUID)&&!new ManagerHeaderMng(this.conn).ManagerIsExist(mUID)&& !new UserManagementHeaderMng(this.conn).UserIsExist(mUID))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nUID " + mUID + " is not registered!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }


            else
            {
                string mPICUserID = txtUname.Text;
                frm_ResetPassword form = frm_ResetPassword.GetInstance(mPICUserID);
                if (!form.Visible)
                {

                    form.Show();

                }
                else
                {
                    form.BringToFront();
                }
            }
            
        }

    }
}
