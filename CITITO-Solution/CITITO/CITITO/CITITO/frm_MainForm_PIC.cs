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
using MetroFramework.Forms;
using System.Threading;

namespace CITITO
{
    public partial class frm_MainForm_PIC : MetroForm
    {

        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_MainForm_PIC _instance;
        public static frm_MainForm_PIC GetInstance(string mUserID, string mUserCName, DateTime mLoggedTime)
        {


            if (_instance == null || _instance.IsDisposed)
            {
                String uUID = mUserID;
                String uName = mUserCName;
                DateTime uTime = mLoggedTime;

                _instance = new frm_MainForm_PIC(uUID, uName, uTime);


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        
        public frm_MainForm_PIC(string mUserID, string mUserCName, DateTime mLoggedTime)
        {
            InitializeComponent();
            lblUIDToFill.Text = mUserID;
            lblUserNameToFill.Text = mUserCName;
            lblTimeToFill.Text = mLoggedTime.ToString();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        private void frm_MainForm_PIC_Load(object sender, EventArgs e)
        {
            Activate();
        }


        private void metroTile3_Click(object sender, EventArgs e)
        {
            String uUID = lblUIDToFill.Text;
            String uName = lblUserNameToFill.Text;
            DateTime uTime = DateTime.Parse(lblTimeToFill.Text);

            frm_ProjectRegistrationPanel form = frm_ProjectRegistrationPanel.GetInstance(uUID, uName, uTime);
            if (!form.Visible)
            {

                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }

          private void btnExit_Click(object sender, EventArgs e)
        {
            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to exit from CITITO?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                Application.Exit();

            }
            else
            {
                //...
            }
        }

        /// <summary>
        /// DEBUG Login form duplicate issue fixed
        /// </summary>
        /// <param name="sender">Logout clicked</param>
        /// <param name="e"></param>
        private void tglLogut_CheckedChanged(object sender, EventArgs e)
        {
            if (tglLogut.Checked==false)
            {
                ////Get user Confirmation
                //DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to LogOut from CITITO?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == DialogResult.Yes)
                //{


                    frm_Login form = frm_Login.GetInstance();
                    if (!form.Visible)
                    {

                        form.Activate();
                        this.Close();
                    }
                    else
                    {
                        form.BringToFront();
                    }
                    
                    
                //}
                //else
                //{
                //    tglLogut.Checked = true;
                //}
            }
        }

        //Project Registration
        private void tileProjectRegister_Click(object sender, EventArgs e)
        {
            String uUID = lblUIDToFill.Text;
            String uName = lblUserNameToFill.Text;
            DateTime uTime = DateTime.Parse(lblTimeToFill.Text);

            frm_ProjectRegistrationPanel form = frm_ProjectRegistrationPanel.GetInstance(uUID, uName, uTime);
            if (!form.Visible)
            {

                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }

        private void frm_MainForm_PIC_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Login fMain = new frm_Login();
            fMain.Show();
        }

        //Manager Registration
        private void tileManagerRegistration_Click(object sender, EventArgs e)
        {
            String uUID = lblUIDToFill.Text;
            String uName = lblUserNameToFill.Text;
            DateTime uTime = DateTime.Parse(lblTimeToFill.Text);

            frm_ManagerRegisterPanel form = frm_ManagerRegisterPanel.GetInstance(uUID, uName, uTime);
            if (!form.Visible)
            {

                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }
        //Bulk Assing Delete Project
        private void tilebulkAssignDelete_Click(object sender, EventArgs e)
        {
            String uUID = lblUIDToFill.Text;

            frm_UserAssignDeleteFromProjectPanel form = frm_UserAssignDeleteFromProjectPanel.GetInstance(uUID);
            if (!form.Visible)
            {

                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }

        private void tileUserRegistration_Click(object sender, EventArgs e)
        {
            String uUID = lblUIDToFill.Text;

            frm_UserRegistrationPanel form = frm_UserRegistrationPanel.GetInstance(uUID);
            if (!form.Visible)
            {

                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }

        //User Management Panel
        private void tileUserRegirationPanel_Click(object sender, EventArgs e)
        {
            String uMUID = lblUIDToFill.Text;
            String uPIC = lblUIDToFill.Text;
            String uName = lblUserNameToFill.Text;
            DateTime uTime = DateTime.Parse(lblTimeToFill.Text);

            frm_UserManagementPanel form = frm_UserManagementPanel.GetInstance(uMUID, uPIC, uName, uTime);
            if (!form.Visible)
            {

                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lblLoggedTime_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeToFill_Click(object sender, EventArgs e)
        {

        }

        private void tileTaskApproval_Click(object sender, EventArgs e)
        {
            String uMUID = lblUIDToFill.Text;
            String uPIC = lblUIDToFill.Text;

            frm_ApprovalTaskInOut form = frm_ApprovalTaskInOut.GetInstance(uMUID, uPIC);
            if (!form.Visible)
            {

                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }

        void GerenateData()
        {
            for(int i=0; i<=200; i++)
            {
                Thread.Sleep(4);//Simulator
            }
        }

        private void tileReports_Click(object sender, EventArgs e)
        {
            String uMUID = lblUIDToFill.Text;
            String uPIC = lblUIDToFill.Text;

            frm_Loading frm = new frm_Loading(GerenateData);
            frm_MainReportDashboard form = frm_MainReportDashboard.GetInstance(uMUID, uPIC);

            if (!form.Visible)
            {
                frm.ShowDialog();
                form.Show();
            }
            else
            {
               form.BringToFront();
            }

        }


        private void lblAbout_Click(object sender, EventArgs e)
        {
            AboutCITITO form = new AboutCITITO();
            form.Show();
        }

        private void frm_MainForm_PIC_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }
    }
}
