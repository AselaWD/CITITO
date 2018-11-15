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
    public partial class frm_SubDashboardX3ByTask_Manager : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_SubDashboardX3ByTask_Manager _instance;
        public static frm_SubDashboardX3ByTask_Manager GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_SubDashboardX3ByTask_Manager(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_SubDashboardX3ByTask_Manager(string uMUID, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

            lblUIDToFill.Text = uMUID;
            lblPICToFill.Text = uPIC;
            //lblPICToFill.Text = "ZDQ"; /*ZDQ, 16V, EC4, AV1, LR3, TL6, 36W, 23S*/

            //Common Initialization
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            DateTime uFrom = startDate;
            DateTime uTo = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        private void frm_SubDashboardX3ByTask_Manager_Load(object sender, EventArgs e)
        {
            //ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uMUID = lblUIDToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);
            ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);
            UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);
            UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);
            TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            DateTime uFrom = startDate;
            DateTime uTo = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            //Dropdown
            cmbTask.DataSource = mTaskDetailMng.GetAllTaskCodeDetailsByManager(uPIC, uMUID);
            cmbTask.SelectedIndex = -1;

            //DataGridView
            dataGridViewTaskX3Summary.DataSource = mTaskRecordDetailMng.DboardPerformanceX3Task_RankedAndManager(uPIC, uFrom, uTo, uMUID);

            //DataGridvew Alignmnet
            this.dataGridViewTaskX3Summary.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTaskX3Summary.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridViewTaskX3Summary.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTaskX3Summary.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //RefreshData();
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();


            //cmbProject.SelectedIndex = -1;
            cmbTask.SelectedIndex = -1;


            ////Header Panel
            //DateTime now = DateTime.Now;
            //var startDate = new DateTime(now.Year, now.Month, 1);
            //var endDate = startDate.AddMonths(1).AddDays(-1);

            //metroDateTime1From.Value = startDate;
            //metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }

        //Refresh Object
        private void RefreshData()
        {
            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uMUID = lblUIDToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);
            ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);
            UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);
            UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;

            //DataGridView
            dataGridViewTaskX3Summary.DataSource = mTaskRecordDetailMng.DboardPerformanceX3Task_RankedAndManager(uPIC, uFrom, uTo, uMUID);

            //DataGridvew Alignmnet
            this.dataGridViewTaskX3Summary.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTaskX3Summary.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridViewTaskX3Summary.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTaskX3Summary.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskX3Summary.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        //Clear Object
        private void ClearFields()
        {
            dataGridViewTaskX3Summary.DataSource = null;
        }

        //Filter by task
        private void cmbTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uTask = cmbTask.Text;
            string uMUID = lblUIDToFill.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);
            ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);
            UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);
            UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uTask))
            {

                //DataGridView
                dataGridViewTaskX3Summary.DataSource = mTaskRecordDetailMng.DboardPerformanceX3Task_Ranked_FilterByTaskAndManger(uPIC, uFrom, uTo, uTask, uMUID);


                //DataGridvew Alignmnet
                this.dataGridViewTaskX3Summary.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridViewTaskX3Summary.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskX3Summary.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskX3Summary.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskX3Summary.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskX3Summary.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dataGridViewTaskX3Summary.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridViewTaskX3Summary.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskX3Summary.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskX3Summary.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskX3Summary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskX3Summary.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            foreach (DataGridViewColumn column in dataGridViewTaskX3Summary.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewTaskX3Summary.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {

                        dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Value.ToString();

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
                                var ws = wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_Task X3");
                                ws.Range("E2:J1048576").CellsUsed().SetDataType(XLDataType.Number);

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
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_Task X3");
                            ws.Range("E2:J1048576").CellsUsed().SetDataType(XLDataType.Number);

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

        //View DataSet
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboardViewAllX3Performance_Task_Manager myForm = frm_SubDashboardViewAllX3Performance_Task_Manager.GetInstance(uMUID, uPIC);

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

        //Clear All button
        private void btnClrAll_Click(object sender, EventArgs e)
        {
            ClearFields();


            //cmbProject.SelectedIndex = -1;
            cmbTask.SelectedIndex = -1;


            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }

        private void dataGridViewTaskX3Summary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Round Up
            if (e.ColumnIndex == 4)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.##");
                }

            }
            if (e.ColumnIndex == 5)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.##");
                }

            }
            if (e.ColumnIndex == 6)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.##");
                }

            }
            if (e.ColumnIndex == 7)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.##");
                }

            }

            if (e.ColumnIndex == 8)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.##");
                }

            }

            if (e.ColumnIndex == 9)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.##");
                }

            }
        }
    }
}
