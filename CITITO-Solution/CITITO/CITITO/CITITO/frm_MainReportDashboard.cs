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
using LiveCharts.WinForms;
using LiveCharts;
using LiveCharts.Wpf;

namespace CITITO
{
    public partial class frm_MainReportDashboard : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_MainReportDashboard _instance;
        public static frm_MainReportDashboard GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_MainReportDashboard(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_MainReportDashboard(string uMUID, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();


            lblUIDToFill.Text = uMUID;
            lblPICToFill.Text = uPIC;
        }

        private void frm_MainReportDashboard_Load(object sender, EventArgs e)
        {

            panelHover.Height = tileDashboard.Height;
            panelHover.Top = tileDashboard.Top + line.Top + 2;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboard1 myForm = frm_SubDashboard1.GetInstance(uPIC, uMUID);

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
    

        private void tileDashboard_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileDashboard.Height;
            panelHover.Top = tileDashboard.Top + line.Top + 2;
            panelHover.Location = new Point(tileDashboard.Width + 1, line.Top + 2);

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboard1 myForm = frm_SubDashboard1.GetInstance(uPIC, uMUID);

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileDashboard.Height;
            panelHover.Top = tileDashboard.Top + line.Top + 2;
            panelHover.Location = new Point(tileDashboard.Width + 1, line.Top + 2);

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboard1 myForm = frm_SubDashboard1.GetInstance(uPIC, uMUID);

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

        //Task & Quota Tab
        private void tileTaskwise_Click(object sender, EventArgs e)
        {
            //panelHover.Height = tileTaskwise.Height;
            //panelHover.Top = tileTaskwise.Top + line.Top + 2;
            //panelHover.Location = new Point(tileTaskwise.Width + 2, tileTaskwise.Height + line.Top + 7);
            panelHover.Height = tileTaskwise.Height;
            panelHover.Top = tileTaskwise.Top + line.Top + 3;


            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboard_TaskAndQuota myForm = frm_SubDashboard_TaskAndQuota.GetInstance(uPIC, uMUID);

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

        //X3 Tab
        private void tileX3_Click(object sender, EventArgs e)
        {
            


        }

        //X3 User tab
        private void tileX3User_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileX3User.Height;
            panelHover.Top = tileX3User.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardX3Performance myForm = frm_SubDashboardX3Performance.GetInstance(uPIC, uMUID);

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

        //X3 User Project Wise tab
        private void sub_X3UserWise_Click(object sender, EventArgs e)
        {
            panelHover.Height = sub_X3UserWise.Height;
            panelHover.Top = sub_X3UserWise.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardX3UserProjectWise myForm = frm_SubDashboardX3UserProjectWise.GetInstance(uPIC, uMUID);

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

        //X3 team tab
        private void tileX3Team_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileX3Team.Height;
            panelHover.Top = tileX3Team.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardX3ByTeam myForm = frm_SubDashboardX3ByTeam.GetInstance(uPIC, uMUID);

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

        private void metroTile1_Click(object sender, EventArgs e)
        {
            panelHover.Height = metroTile1.Height;
            panelHover.Top = metroTile1.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardTeamDetails myForm = frm_SubDashboardTeamDetails.GetInstance(uPIC, uMUID);

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

        private void tileX3Project_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileX3Project.Height;
            panelHover.Top = tileX3Project.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardX3ByProject myForm = frm_SubDashboardX3ByProject.GetInstance(uPIC, uMUID);

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

        private void tileWasteUser_Click(object sender, EventArgs e)
        {
            
        }

        private void tileIDLEUser_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "\nThe function is under construction.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tileOperators_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "\nThe function is under construction.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tileProjects_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "\nThe function is under construction.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //panelHover.Height = tileProjects.Height;
            //panelHover.Top = tileProjects.Top + line.Top + 3;

            //String uPIC = lblPICToFill.Text;
            //String uMUID = lblUIDToFill.Text;

            //panelLoadUserTasks.Controls.Clear();

            //frm_SubDashboardProjects myForm = frm_SubDashboardProjects.GetInstance(uPIC, uMUID);

            //myForm.TopLevel = false;
            //myForm.AutoScroll = false;
            //myForm.Dock = DockStyle.Fill;
            //panelLoadUserTasks.Controls.Add(myForm);


            //if (!myForm.Visible)
            //{

            //    myForm.Show();
            //}
            //else
            //{
            //    myForm.BringToFront();
            //}

        }

        private void tileWorkLoad_Click(object sender, EventArgs e)
        {
            //MetroFramework.MetroMessageBox.Show(this, "\nThe function is under construction.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            panelHover.Height = tileWorkLoad.Height;
            panelHover.Top = tileWorkLoad.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardWorkLoad_Summary myForm = frm_SubDashboardWorkLoad_Summary.GetInstance(uPIC, uMUID);

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

        private void tileX3Tasks_Click(object sender, EventArgs e)
        {
            //MetroFramework.MetroMessageBox.Show(this, "\nThe function is under construction.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            panelHover.Height = tileX3Tasks.Height;
            panelHover.Top = tileX3Tasks.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardX3ByTask myForm = frm_SubDashboardX3ByTask.GetInstance(uPIC, uMUID);

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

        private void tileIDLEAndwastage_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileIDLEAndwastage.Height;
            panelHover.Top = tileIDLEAndwastage.Top;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardWastage myForm = frm_SubDashboardWastage.GetInstance(uPIC, uMUID);

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

        private void tilePTR_Click(object sender, EventArgs e)
        {
            panelHover.Height = tilePTR.Height;
            panelHover.Top = tilePTR.Top;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardPTR myForm = frm_SubDashboardPTR.GetInstance(uPIC, uMUID);

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

        //Cost        
        private void tileCost_Click_1(object sender, EventArgs e)
        {
            panelHover.Height = tileCost.Height;
            panelHover.Top = tilePTR.Bottom+2;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardCost myForm = frm_SubDashboardCost.GetInstance(uPIC, uMUID);

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
