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

namespace CITITO
{
    public partial class frm_MainForm_Admin : MetroForm
    {

        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_MainForm_Admin _instance;
        public static frm_MainForm_Admin GetInstance(string mUserID, string mUserCName, DateTime mLoggedTime)
        {


            if (_instance == null || _instance.IsDisposed)
            {
                String uUID = mUserID;
                String uName = mUserCName;
                DateTime uTime = mLoggedTime;

                _instance = new frm_MainForm_Admin(uUID, uName, uTime);


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_MainForm_Admin(string mUserID, string mUserCName, DateTime mLoggedTime)
        {
            InitializeComponent();
            lblUIDToFill.Text = mUserID;
            lblUserNameToFill.Text = mUserCName;
            lblTimeToFill.Text = mLoggedTime.ToString();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        private void frm_MainForm_Admin_Load(object sender, EventArgs e)
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

        private void tilePICRegistration_Click(object sender, EventArgs e)
        {
            
            frm_PICRegisterPanel form = frm_PICRegisterPanel.GetInstance();
            if (!form.Visible)
            {

                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }


        private void tileChangePICToProject_Click(object sender, EventArgs e)
        {
            frm_AssignPICToProject form = frm_AssignPICToProject.GetInstance();
            if (!form.Visible)
            {

                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }

        private void frm_MainForm_Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Login fMain = new frm_Login();
            fMain.Show();
        }

        private void frm_MainForm_Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        //PTR Cost resource Update
        private void tilePTRCostResource_Click(object sender, EventArgs e)
        {
            frm_ResourceCostTable form = frm_ResourceCostTable.GetInstance();
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
