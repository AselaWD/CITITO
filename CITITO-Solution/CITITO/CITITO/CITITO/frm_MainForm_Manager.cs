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
    public partial class frm_MainForm_Manager : MetroForm
    {
        SqlConnection conn;
        String mMUID;

        //Start Pass insatance when form is already opend or not
        private static frm_MainForm_Manager _instance;
        public static frm_MainForm_Manager GetInstance(string mUserID, string mUserCName, DateTime mLoggedTime)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String uUID = mUserID;
                String uName = mUserCName;
                DateTime uTime = mLoggedTime;

                _instance = new frm_MainForm_Manager(uUID, uName, uTime);

            }
            return _instance;

        }
        public frm_MainForm_Manager(string mUserID, string mUserCName, DateTime mLoggedTime)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            PICDetailMng mPICDetailMng = new PICDetailMng(this.conn);
            mMUID = mPICDetailMng.GetPICUIDByMUID(mUserID);
            string mName = mPICDetailMng.GetPICNamByMUID(mUserID);

            lblUIDToFill.Text = mUserID;
            lblUserNameToFill.Text = mUserCName;
            lblTimeToFill.Text = mLoggedTime.ToString();
            lblPICToFill.Text = mName + " (" + mMUID + ")";



        }

        //User Registration
        private void tileUserRegistration_Click(object sender, EventArgs e)
        {
            String uUID = lblUIDToFill.Text;
            String uPIC = lblUIDToFill.Text;
            String uName= lblUserNameToFill.Text;
            DateTime uTime = DateTime.Parse(lblTimeToFill.Text);

            frm_UserManagementPanel form = frm_UserManagementPanel.GetInstance(uUID,uPIC,uName,uTime);
            if (!form.Visible)
            {

                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }

        //Exit button
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

        //Logout
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

                        form.Show();
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

        //Task Approval
        private void tielTaskApproval_Click(object sender, EventArgs e)
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
            for (int i = 0; i <= 200; i++)
            {
                Thread.Sleep(4);//Simulator
            }
        }

        private void tileReports_Click(object sender, EventArgs e)
        {
            String uPIC = lblUIDToFill.Text;
            String uMUID = mMUID;

            frm_Loading frm = new frm_Loading(GerenateData);
            frm_MainReportDashboard_Manager form = frm_MainReportDashboard_Manager.GetInstance(uMUID, uPIC);
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

        private void frm_MainForm_Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void frm_MainForm_Manager_Load(object sender, EventArgs e)
        {

        }
    }
}
