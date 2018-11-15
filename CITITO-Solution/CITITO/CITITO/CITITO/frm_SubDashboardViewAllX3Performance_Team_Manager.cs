using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using ClosedXML.Excel;
using System.Windows.Forms;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;

namespace CITITO
{
    public partial class frm_SubDashboardViewAllX3Performance_Team_Manager : MetroForm
    {

        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_SubDashboardViewAllX3Performance_Team_Manager _instance;
        public static frm_SubDashboardViewAllX3Performance_Team_Manager GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_SubDashboardViewAllX3Performance_Team_Manager(mMUID, mPIC);

            }
            return _instance;

        }


        public frm_SubDashboardViewAllX3Performance_Team_Manager(string uMUID, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

            lblUIDToFill.Text = uMUID;
            lblPICToFill.Text = uPIC;

            cmbMUID.Items.Add(uMUID);
            cmbMUID.SelectedIndex = 0;
            cmbMUID.Enabled = false;


        }

        private void frm_SubDashboardViewAllX3Performance_Team_Manager_Load(object sender, EventArgs e)
        {
            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uMUID = cmbMUID.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);
            ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);
            UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);
            UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);
            ProcessCodeHeaderMng mProcessCodeHeaderMng = new ProcessCodeHeaderMng(this.conn);
            TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            DateTime uFrom = startDate;
            DateTime uTo = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            //DataGridView
            dataGridViewX3PerformanceDataSet.DataSource = mTaskRecordDetailMng.DboardPerformanceX3UserAllDataSet_ByPICAndManager(uPIC, uFrom, uTo, uMUID);

            //DataGridvew Alignmnet
            this.dataGridViewX3PerformanceDataSet.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //this.dataGridViewX3PerformanceDataSet.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridViewX3PerformanceDataSet.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //this.dataGridViewX3PerformanceDataSet.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Dropdown
            cmbProject.DataSource = mProjectDetailMng.GetListOfProjectNamesByManager(uPIC, uMUID);
            cmbProject.SelectedIndex = -1;
            cmbItemCode.DataSource = mProcessCodeHeaderMng.GetListProcessCodesByManager(uPIC, uMUID);
            cmbItemCode.SelectedIndex = -1;
            cmbTaskCode.DataSource = mTaskDetailMng.GetAllTaskCodeDetailsByManager(uPIC, uMUID);
            cmbTaskCode.SelectedIndex = -1;
            //cmbMUID.DataSource = mManagerHeaderMng.GetActiveManagerUIDByPIC(uPIC);
            //cmbMUID.SelectedIndex = -1;
            cmbUID.DataSource = mUserManagementDetailMng.ListActiveUIDByManager(uPIC, uMUID);
            cmbUID.SelectedIndex = -1;

            RefreshData();
        }

        //Refresh Object
        private void RefreshData()
        {
            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uMUID = lblUIDToFill.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;

            //DataGridView
            dataGridViewX3PerformanceDataSet.DataSource = mTaskRecordDetailMng.DboardPerformanceX3UserAllDataSet_ByPICAndManager(uPIC, uFrom, uTo, uMUID);

            //DataGridvew Alignmnet
            this.dataGridViewX3PerformanceDataSet.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //this.dataGridViewX3PerformanceDataSet.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridViewX3PerformanceDataSet.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewX3PerformanceDataSet.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //this.dataGridViewX3PerformanceDataSet.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewX3PerformanceDataSet.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        //Clear Object
        private void ClearFields()
        {
            dataGridViewX3PerformanceDataSet.DataSource = null;
        }

        //Back to X3
        private void btnBackToTask_Click(object sender, EventArgs e)
        {

            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboardX3ByTeam_Manager myForm = frm_SubDashboardX3ByTeam_Manager.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_MainReportDashboard_Manager form1 = (frm_MainReportDashboard_Manager)Application.OpenForms["frm_MainReportDashboard_Manager"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();
        }

        private void dataGridViewX3PerformanceDataSet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {

                if ((int)e.Value == 2)
                {
                    e.Value = "Pending";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");

                }
                else if ((int)e.Value == 3)
                {
                    e.Value = "Done";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9FEB");
                    //e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                }
            }
            if (e.ColumnIndex == 12)
            {
                if ((int)e.Value == 0)
                {
                    e.Value = "No Status";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                }
                else if ((int)e.Value == 1)
                {
                    e.Value = "Pending";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");
                }
                else if ((int)e.Value == 2)
                {
                    e.Value = "Approved";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9FEB");
                    //e.CellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                }
                else if ((int)e.Value == 3)
                {
                    e.Value = "Disapproved";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FD7C66");
                }
                else if ((int)e.Value == 4)
                {
                    e.Value = "Skipped";
                    //e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");
                }
            }
            //Round Up
            if (e.ColumnIndex == 10)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.###");
                }

            }

            if (e.ColumnIndex == 18)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.###");
                }

            }

            if (e.ColumnIndex == 19)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.###");
                }

            }

            if (e.ColumnIndex == 20)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.###");
                }

            }
        }

        //Filter by Project
        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uProject = cmbProject.Text;
            string uMUID = lblUIDToFill.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uProject))
            {

                //DataGridView
                dataGridViewX3PerformanceDataSet.DataSource = mTaskRecordDetailMng.DboardPerformanceX3UserAllDataSet_ByPICAndProjectAndManager(uPIC, uFrom, uTo, uProject, uMUID);

                //DataGridvew Alignmnet
                this.dataGridViewX3PerformanceDataSet.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                //this.dataGridViewX3PerformanceDataSet.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridViewX3PerformanceDataSet.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //this.dataGridViewX3PerformanceDataSet.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();


            cmbProject.SelectedIndex = -1;
            //cmbMUID.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;
            cmbItemCode.SelectedIndex = -1;
            cmbTaskCode.SelectedIndex = -1;

            ////Header Panel
            //DateTime now = DateTime.Now;
            //var startDate = new DateTime(now.Year, now.Month, 1);
            //var endDate = startDate.AddMonths(1).AddDays(-1);

            //metroDateTime1From.Value = startDate;
            //metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }

        //Filter by User
        private void cmbUID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uUID = cmbUID.Text;
            string uMUID = lblUIDToFill.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uUID))
            {

                //DataGridView
                dataGridViewX3PerformanceDataSet.DataSource = mTaskRecordDetailMng.DboardPerformanceX3UserAllDataSet_ByPICAndUserAndManager(uPIC, uFrom, uTo, uUID, uMUID);

                //DataGridvew Alignmnet
                this.dataGridViewX3PerformanceDataSet.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                //this.dataGridViewX3PerformanceDataSet.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridViewX3PerformanceDataSet.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //this.dataGridViewX3PerformanceDataSet.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            }
        }

        //Filter by Item Code
        private void cmbItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uItemCode = cmbItemCode.Text;
            string uMUID = lblUIDToFill.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uItemCode))
            {

                //DataGridView
                dataGridViewX3PerformanceDataSet.DataSource = mTaskRecordDetailMng.DboardPerformanceX3UserAllDataSet_ByPICAndItemCodeAndManager(uPIC, uFrom, uTo, uItemCode, uMUID);

                //DataGridvew Alignmnet
                this.dataGridViewX3PerformanceDataSet.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                //this.dataGridViewX3PerformanceDataSet.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridViewX3PerformanceDataSet.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //this.dataGridViewX3PerformanceDataSet.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            }
        }

        //Filter by Task Code
        private void cmbTaskCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uTaskCode = cmbTaskCode.Text;
            string uMUID = lblUIDToFill.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uTaskCode))
            {

                //DataGridView
                dataGridViewX3PerformanceDataSet.DataSource = mTaskRecordDetailMng.DboardPerformanceX3UserAllDataSet_ByPICAndTaskCodeAndManager(uPIC, uFrom, uTo, uTaskCode, uMUID);

                //DataGridvew Alignmnet
                this.dataGridViewX3PerformanceDataSet.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                //this.dataGridViewX3PerformanceDataSet.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridViewX3PerformanceDataSet.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewX3PerformanceDataSet.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //this.dataGridViewX3PerformanceDataSet.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewX3PerformanceDataSet.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            }
        }

        //Click Go
        private void btnGo_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshData();
        }

        //Export Excel
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Common Initialization
            string mPIC = lblUIDToFill.Text;

            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewX3PerformanceDataSet.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewX3PerformanceDataSet.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {

                        if (i == 11)
                        {
                            if ((Int32)row.Cells[11].Value == 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][11] = "Fresh";
                            }
                            else if ((Int32)row.Cells[11].Value == 1)
                            {
                                dt.Rows[dt.Rows.Count - 1][11] = "On Hold";
                            }
                            else if ((Int32)row.Cells[11].Value == 2)
                            {
                                dt.Rows[dt.Rows.Count - 1][11] = "Pending";
                            }
                            else if ((Int32)row.Cells[11].Value == 3)
                            {
                                dt.Rows[dt.Rows.Count - 1][11] = "Done";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][11] = row.Cells[11].Value.ToString();
                            }

                        }
                        else if (i == 12)
                        {

                            if ((Int32)row.Cells[12].Value == 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][12] = "No Status";
                            }
                            else if ((Int32)row.Cells[12].Value == 1)
                            {
                                dt.Rows[dt.Rows.Count - 1][12] = "Pending";
                            }
                            else if ((Int32)row.Cells[12].Value == 2)
                            {
                                dt.Rows[dt.Rows.Count - 1][12] = "Approved";
                            }
                            else if ((Int32)row.Cells[12].Value == 3)
                            {
                                dt.Rows[dt.Rows.Count - 1][12] = "Disapproved";
                            }
                            else if ((Int32)row.Cells[12].Value == 4)
                            {
                                dt.Rows[dt.Rows.Count - 1][12] = "Skipped";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][12] = row.Cells[12].Value.ToString();
                            }

                        }

                        else
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Value.ToString();
                        }

                        //dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Value.ToString();


                    }
                    catch (Exception ex)
                    {
                        if (ex.HResult == -2147024809)
                        {
                            //cell.Value = DateTime.ParseExact(cell.Value.ToString(), "dd MM yyyy hh:mm:ss tt", null);
                        }

                    }


                }

            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.Title = "Export Excel Files";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = false;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "All files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;

                //Exporting to Excel           

                try
                {

                    if (!System.IO.File.Exists(fileName))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(fileName))
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                var ws = wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_X3 DataSet");
                                ws.Range("I2:J1048576").CellsUsed().SetDataType(XLDataType.DateTime);
                                ws.Range("K2:K1048576").CellsUsed().SetDataType(XLDataType.Number);
                                ws.Range("P2:Q1048576").CellsUsed().SetDataType(XLDataType.Number);
                                ws.Range("S2:U1048576").CellsUsed().SetDataType(XLDataType.Number);

                                ws.Columns().AdjustToContents();
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_X3 DataSet");
                            ws.Range("I2:J1048576").CellsUsed().SetDataType(XLDataType.DateTime);
                            ws.Range("K2:K1048576").CellsUsed().SetDataType(XLDataType.Number);
                            ws.Range("P2:Q1048576").CellsUsed().SetDataType(XLDataType.Number);
                            ws.Range("S2:U1048576").CellsUsed().SetDataType(XLDataType.Number);

                            ws.Columns().AdjustToContents();
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to  \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2147024864)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile is already opened in another programme.", "Application Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void cmbProject_MouseClick(object sender, MouseEventArgs e)
        {
            //cmbMUID.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;
            cmbItemCode.SelectedIndex = -1;
            cmbTaskCode.SelectedIndex = -1;
        }

        private void cmbItemCode_MouseClick(object sender, MouseEventArgs e)
        {
            //cmbMUID.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;
            cmbProject.SelectedIndex = -1;
            cmbTaskCode.SelectedIndex = -1;
        }

        private void cmbTaskCode_MouseClick(object sender, MouseEventArgs e)
        {
            //cmbMUID.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;
            cmbProject.SelectedIndex = -1;
            cmbItemCode.SelectedIndex = -1;
        }

        private void cmbUID_MouseClick(object sender, MouseEventArgs e)
        {
            cmbTaskCode.SelectedIndex = -1;
            //cmbMUID.SelectedIndex = -1;
            cmbProject.SelectedIndex = -1;
            cmbItemCode.SelectedIndex = -1;
        }

        //Clear All button
        private void btnClrAll_Click(object sender, EventArgs e)
        {
            ClearFields();


            cmbProject.SelectedIndex = -1;
            //cmbMUID.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;
            cmbItemCode.SelectedIndex = -1;
            cmbTaskCode.SelectedIndex = -1;

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }
    }
}
