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
    public partial class frm_ApprovalTaskInOut : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_ApprovalTaskInOut _instance;
        public static frm_ApprovalTaskInOut GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_ApprovalTaskInOut(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_ApprovalTaskInOut(string uMUID, string uPIC)
        {
            InitializeComponent();

            panelHover.Height = tileIDLEApproval.Height;
            panelHover.Top = tileIDLEApproval.Top + line.Top + 2;

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblUIDToFill.Text = uMUID;
            lblPICToFill.Text = uPIC;


            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                tileModifiedApproval.Visible = true;
                tileModifiedRecords.Visible = false;

            }
            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMUID))
            {
                tileModifiedApproval.Visible = false;
                tileModifiedRecords.Visible = true;
            }


        }

        private void tileIDLEApproval_Click(object sender, EventArgs e)
        {          

            panelHover.Height = tileIDLEApproval.Height;
            panelHover.Top = tileIDLEApproval.Top + line.Top + 2;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;


            panelLoadUserTasks.Controls.Clear();

            frm_IDLETaskApproval myForm = frm_IDLETaskApproval.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            panelLoadUserTasks.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }
        }

        private void tileTaskInOutApproval_Click_1(object sender, EventArgs e)
        {
            panelHover.Height = tileTaskInOutApproval.Height;
            panelHover.Top = tileTaskInOutApproval.Top + line.Top + 2;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_TaskInOutApproval myForm = frm_TaskInOutApproval.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            panelLoadUserTasks.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }
        }

        private void frm_ApprovalTaskInOut_Load(object sender, EventArgs e)
        {
            panelHover.Height = tileTaskInOutApproval.Height;
            panelHover.Top = tileTaskInOutApproval.Top + line.Top + 2;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;


            panelLoadUserTasks.Controls.Clear();

            frm_TaskInOutApproval myForm = frm_TaskInOutApproval.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            panelLoadUserTasks.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }
        }

        //Task Modified Approvals (PIC)
        private void tileModifiedApproval_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileModifiedApproval.Height;
            panelHover.Top = tileModifiedApproval.Top + line.Top + 2;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;
            
            panelLoadUserTasks.Controls.Clear();

            frm_TaskInOutModifiedApproval myForm = frm_TaskInOutModifiedApproval.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            panelLoadUserTasks.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }
        }

        //Task Modified Records (Manager)
        private void tileModifiedRecords_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileModifiedRecords.Height;
            panelHover.Top = tileModifiedRecords.Top + line.Top + 2;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_TaskInOutModifiedApproval myForm = frm_TaskInOutModifiedApproval.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            panelLoadUserTasks.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }

        }

        //Pending Records (Read Only)
        private void metroTile1_Click(object sender, EventArgs e)
        {
            panelHover.Height = tilePendingRecords.Height;
            panelHover.Top = tilePendingRecords.Top + line.Top + 2;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_TaskInOutPending myForm = frm_TaskInOutPending.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            panelLoadUserTasks.Controls.Add(myForm);


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
