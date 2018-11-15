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
    public partial class frm_UserManagementPanel : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_UserManagementPanel _instance;
        public static frm_UserManagementPanel GetInstance(string mMUID, string mPIC, string mName, DateTime mTime)
        {


            if (_instance == null || _instance.IsDisposed)
            {
                String uMUID = mMUID;
                String uPIC = mPIC;
                String uName = mName;
                DateTime uTime = mTime;

                _instance = new frm_UserManagementPanel(uMUID, uPIC, uName, uTime);


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_UserManagementPanel(string mMUID, string mPIC, string mName, DateTime mTime)
        {
            InitializeComponent();

            lblMUID.Text = mMUID;
            lblPIC.Text = mPIC;
            lblManagerName.Text = mName;
            lblTime.Text = mTime.ToString();


            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        //Form Load
        private void frm_UserManagementPanel_Load(object sender, EventArgs e)
        {
            hoverPanel.Left = tileUser.Left;
            hoverPanel.Width = tileUser.Width;
            hoverPanel.Top = tileUser.Top;

            String uMUID = lblMUID.Text;
            String uUID = lblMUID.Text;
            String uName = lblManagerName.Text;
            DateTime uTime = DateTime.Parse(lblTime.Text);

            if (new PICHeaderMng(this.conn).PICIsExist(uUID))
            {
                tileManager.Visible = true;
                tileUser.Visible = true;

                panelRegistration.Controls.Clear();

                frm_UserRegistrationPanel myForm = frm_UserRegistrationPanel.GetInstance(uUID);

                myForm.TopLevel = false;
                myForm.AutoScroll = false;
                myForm.Dock = DockStyle.Fill;
                panelRegistration.Controls.Add(myForm);


                if (!myForm.Visible)
                {

                    myForm.Show();
                }
                else
                {
                    myForm.BringToFront();
                }
            }
            else
            {
                tileUser.Visible = true;
                tileManager.Visible = false;

                panelRegistration.Controls.Clear();

                frm_UserRegistrationPanel myForm = frm_UserRegistrationPanel.GetInstance(uUID);

                myForm.TopLevel = false;
                myForm.AutoScroll = false;
                myForm.Dock = DockStyle.Fill;
                panelRegistration.Controls.Add(myForm);


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

        //User Registration
        private void tileUser_Click(object sender, EventArgs e)
        {
            hoverPanel.Left = tileUser.Left;
            hoverPanel.Width = tileUser.Width;
            hoverPanel.Top = tileUser.Top;

            String uMUID = lblMUID.Text;
            String uUID = lblMUID.Text;
            String uName = lblManagerName.Text;
            DateTime uTime = DateTime.Parse(lblTime.Text);

            panelRegistration.Controls.Clear();

            frm_UserRegistrationPanel myForm = frm_UserRegistrationPanel.GetInstance(uUID);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            panelRegistration.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }
        }

        //Manager Registration
        private void tileManager_Click(object sender, EventArgs e)
        {
            hoverPanel.Left = tileManager.Left;
            hoverPanel.Width = tileManager.Width;
            hoverPanel.Top = tileManager.Top;

            String uMUID = lblMUID.Text;
            String uUID = lblMUID.Text;
            String uName = lblManagerName.Text;
            DateTime uTime = DateTime.Parse(lblTime.Text);

            panelRegistration.Controls.Clear();

            frm_ManagerRegisterPanel myForm = frm_ManagerRegisterPanel.GetInstance(uUID, uName, uTime);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            panelRegistration.Controls.Add(myForm);


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
