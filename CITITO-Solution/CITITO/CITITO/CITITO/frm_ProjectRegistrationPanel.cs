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
    public partial class frm_ProjectRegistrationPanel : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_ProjectRegistrationPanel _instance;
        public static frm_ProjectRegistrationPanel GetInstance(string mUID, string mName, DateTime mTime)
        {


            if (_instance == null || _instance.IsDisposed)
            {
                String uUID = mUID;
                String uName = mName;
                DateTime uTime = mTime;

                _instance = new frm_ProjectRegistrationPanel(uUID, uName, uTime);


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_ProjectRegistrationPanel(string mUID, string mName, DateTime mTime)
        {
            InitializeComponent();

            lblUID.Text = mUID;
            lblManagerName.Text = mName;
            lblTime.Text = mTime.ToString();


            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        private void frm_ProjectRegistrationPanel_Load(object sender, EventArgs e)
        {
            hoverPanel.Left = tileProject.Left;
            hoverPanel.Width = tileProject.Width;
            hoverPanel.Top = tileProject.Top;

            String uUID = lblUID.Text;
            String uName = lblManagerName.Text;

            panelRegistration.Controls.Clear();

            frm_ProjectRegisterPanel myForm = frm_ProjectRegisterPanel.GetInstance(uUID, uName);

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

        private void tileProject_Click(object sender, EventArgs e)
        {
            hoverPanel.Left = tileProject.Left;
            hoverPanel.Width = tileProject.Width;
            hoverPanel.Top = tileProject.Top;

            String uUID = lblUID.Text;
            String uName = lblManagerName.Text;

            panelRegistration.Controls.Clear();

            frm_ProjectRegisterPanel myForm = frm_ProjectRegisterPanel.GetInstance(uUID, uName);

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

        private void tileTaskCodes_Click(object sender, EventArgs e)
        {
            hoverPanel.Left = tileTaskCodes.Left;
            hoverPanel.Width = tileTaskCodes.Width;
            hoverPanel.Top = tileTaskCodes.Top;

            String uUID = lblUID.Text;
            String uName = lblManagerName.Text;

            panelRegistration.Controls.Clear();

            frm_TaskCodeRegister myForm = frm_TaskCodeRegister.GetInstance(uUID, uName);

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
