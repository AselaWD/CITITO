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
    public partial class frm_MainReportDashboard_Manager : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_MainReportDashboard_Manager _instance;
        public static frm_MainReportDashboard_Manager GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_MainReportDashboard_Manager(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_MainReportDashboard_Manager(string uMUID, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();


            lblUIDToFill.Text = uMUID;
            lblPICToFill.Text = uPIC;
        }

        private void frm_MainReportDashboard_Manager_Load(object sender, EventArgs e)
        {

            panelHover.Height = tileDashboard.Height;
            panelHover.Top = tileDashboard.Top + line.Top + 2;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboard1_Manager myForm = frm_SubDashboard1_Manager.GetInstance(uPIC, uMUID);

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

        //Daashboard Click
        private void tileDashboard_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileDashboard.Height;
            panelHover.Top = tileDashboard.Top + line.Top + 2;
            panelHover.Location = new Point(tileDashboard.Width + 1, line.Top + 2);

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboard1_Manager myForm = frm_SubDashboard1_Manager.GetInstance(uPIC, uMUID);

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

        //Team Details Click
        private void metroTile1_Click(object sender, EventArgs e)
        {
            panelHover.Height = metroTile1.Height;
            panelHover.Top = metroTile1.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardTeamDetails_Managers myForm = frm_SubDashboardTeamDetails_Managers.GetInstance(uPIC, uMUID);

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
        
        //Workload Click
        private void tileWorkLoad_Click(object sender, EventArgs e)
        {
            //MetroFramework.MetroMessageBox.Show(this, "\nThe function is under construction.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            panelHover.Height = tileWorkLoad.Height;
            panelHover.Top = tileWorkLoad.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardWorkLoad_Summary_Manager myForm = frm_SubDashboardWorkLoad_Summary_Manager.GetInstance(uPIC, uMUID);

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

        //X3 Project Click
        private void tileX3Project_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileX3Project.Height;
            panelHover.Top = tileX3Project.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardX3ByProject_Manager myForm = frm_SubDashboardX3ByProject_Manager.GetInstance(uPIC, uMUID);

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

        //X3 by Team
        private void tileX3Team_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileX3Team.Height;
            panelHover.Top = tileX3Team.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardX3ByTeam_Manager myForm = frm_SubDashboardX3ByTeam_Manager.GetInstance(uPIC, uMUID);

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

        //X3 by User
        private void tileX3User_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileX3User.Height;
            panelHover.Top = tileX3User.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardX3Performance_Manager myForm = frm_SubDashboardX3Performance_Manager.GetInstance(uPIC, uMUID);

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

        //X3 User Projectwise
        private void subX3UserProjectwise_Click(object sender, EventArgs e)
        {
            panelHover.Height = subX3UserProjectwise.Height;
            panelHover.Top = subX3UserProjectwise.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardX3UserProjectWise_Manager myForm = frm_SubDashboardX3UserProjectWise_Manager.GetInstance(uPIC, uMUID);

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

        //X3 by Task
        private void tileX3Tasks_Click(object sender, EventArgs e)
        {
            //MetroFramework.MetroMessageBox.Show(this, "\nThe function is under construction.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            panelHover.Height = tileX3Tasks.Height;
            panelHover.Top = tileX3Tasks.Top + line.Top + 3;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardX3ByTask_Manager myForm = frm_SubDashboardX3ByTask_Manager.GetInstance(uPIC, uMUID);

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

        //IDLE And Wastage
        private void tileIDLEAndwastage_Click(object sender, EventArgs e)
        {
            panelHover.Height = tileIDLEAndwastage.Height;
            panelHover.Top = tileIDLEAndwastage.Top;

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            panelLoadUserTasks.Controls.Clear();

            frm_SubDashboardWastage_Manager myForm = frm_SubDashboardWastage_Manager.GetInstance(uPIC, uMUID);

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
