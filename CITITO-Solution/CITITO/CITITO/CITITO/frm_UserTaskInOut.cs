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

namespace CITITO
{
    public partial class frm_UserTaskInOut : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_UserTaskInOut _instance;
        public static frm_UserTaskInOut GetInstance(string uUID, string uName, string uAccess, DateTime uLogTime)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUID = uUID;
                String mName = uName;
                String mAccess = uAccess;
                DateTime mLogTime = uLogTime;

                _instance = new frm_UserTaskInOut(mUID, mName, mAccess, uLogTime);

            }
            return _instance;

        }
        
        public frm_UserTaskInOut(string uUID, string uName, string uAccess, DateTime uLogTime)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            string mM_UID = new UserManagementDetailMng(this.conn).GetManagerUIDByUserID(uUID);

            lblUIDToFill.Text = uUID;
            lblUserNameToFill.Text = uName;
            lblTimeToFill.Text = uLogTime.ToString();
            lblManagerToFill.Text = new ManagerHeaderMng(this.conn).GetManagerNameByMUID(mM_UID) + " (" + mM_UID + ")";
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

        private void tglLogut_CheckedChanged(object sender, EventArgs e)
        {
            if (tglLogut.Checked == false)
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

        private void tileTaskInOut_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileTaskInOut.Height;
            panelHover.Top = tileTaskInOut.Top + line.Top + 3;

            String uUID = lblUIDToFill.Text;
            string mM_UID = new UserManagementDetailMng(this.conn).GetManagerUIDByUserID(uUID);                    

            String uMUID = mM_UID;
            String uMName = lblManagerToFill.Text;
            DateTime uTime = DateTime.Parse(lblTimeToFill.Text);

            pnlMain.Controls.Clear();

            frm_TaskInOut myForm = frm_TaskInOut.GetInstance(uUID, uMUID, uMName, uTime);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }
        }

        private void tileIDLE_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileIDLE.Height;
            panelHover.Top = tileIDLE.Top + line.Top+ 3;

            String uUID = lblUIDToFill.Text;
            string mM_UID = new UserManagementDetailMng(this.conn).GetManagerUIDByUserID(uUID);

            String uMUID = mM_UID;
            String uMName = lblManagerToFill.Text;
            DateTime uTime = DateTime.Parse(lblTimeToFill.Text);

            pnlMain.Controls.Clear();

            frm_IDLETask myForm = frm_IDLETask.GetInstance(uUID, uMUID, uMName, uTime);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }

        }

        private void frm_UserTaskInOut_Load(object sender, EventArgs e)
        {
            panelHover.Height = tileTaskInOut.Height;
            panelHover.Top = tileTaskInOut.Top + line.Top + 3;

            String uUID = lblUIDToFill.Text;
            string mM_UID = new UserManagementDetailMng(this.conn).GetManagerUIDByUserID(uUID);

            String uMUID = mM_UID;
            String uMName = lblManagerToFill.Text;
            DateTime uTime = DateTime.Parse(lblTimeToFill.Text);

            pnlMain.Controls.Clear();

            frm_TaskInOut myForm = frm_TaskInOut.GetInstance(uUID, uMUID, uMName, uTime);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }
        }

        private void frm_UserTaskInOut_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.CITITONotification.BalloonTipTitle = "CITITO Minimized";
                this.CITITONotification.BalloonTipText = "CITITO running in background. Double click on this icon to maximize.";
                this.CITITONotification.Visible = true;
                this.CITITONotification.ShowBalloonTip(5);
            }

        }

        private void CITITONotification_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.CITITONotification.Visible = false;
        }

        private void frm_UserTaskInOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void tileX3_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileX3.Height;
            panelHover.Top = tileX3.Top + line.Top + 3;

            String uUID = lblUIDToFill.Text;
            string mM_UID = new UserManagementDetailMng(this.conn).GetManagerUIDByUserID(uUID);

            String uMUID = mM_UID;
            String uMName = lblManagerToFill.Text;
            DateTime uTime = DateTime.Parse(lblTimeToFill.Text);

            pnlMain.Controls.Clear();

            frm_TaskInOutX3 myForm = frm_TaskInOutX3.GetInstance(uUID, uMUID, uMName, uTime);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }
        }
    }
    
}
