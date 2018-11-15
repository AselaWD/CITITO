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
using MetroFramework;
using MetroFramework.Forms;

namespace CITITO
{
    public partial class frm_SubDashboardTeamDetails_Managers : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_SubDashboardTeamDetails_Managers _instance;
        public static frm_SubDashboardTeamDetails_Managers GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_SubDashboardTeamDetails_Managers(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_SubDashboardTeamDetails_Managers(string uMUID, string uPIC)
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

        private void frm_SubDashboardTeamDetails_Managers_Load(object sender, EventArgs e)
        {

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uMUID = cmbMUID.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);
            ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);
            UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);
            UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            DateTime uFrom = startDate;
            DateTime uTo = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            //Dropdown
            cmbProject.DataSource = mProjectDetailMng.GetListOfProjectNamesByManager(uPIC, uMUID);
            cmbProject.SelectedIndex = -1;
            //cmbMUID.DataSource = mManagerHeaderMng.GetActiveManagerUIDByPIC(uPIC);
            //cmbMUID.SelectedIndex = -1;
            cmbUID.DataSource = mUserManagementDetailMng.ListActiveUIDByManager(uPIC, uMUID);
            cmbUID.SelectedIndex = -1;

            //DataGridView
            dataGridViewTeamDetails.DataSource = mTaskRecordDetailMng.DboardActiveTeamDetailByPIC_FilterByManager(uPIC, uMUID);
            dataGridViewCurrentUtilization.DataSource = mTaskRecordDetailMng.DboardCurrentTeamUtilizationByPIC_FilterByManager(uPIC, uMUID);
            dataGridViewUtilizationDetailbyUID.DataSource = mTaskRecordDetailMng.DboardCurrentUtilizationDetailUIDByPIC_FilterByManager(uPIC, uMUID);

            RefreshData();
        }

        //Refresh Object
        private void RefreshData()
        {
            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uMUID = cmbMUID.Text; 
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;

            //DataGridView
            dataGridViewTeamDetails.DataSource = mTaskRecordDetailMng.DboardActiveTeamDetailByPIC_FilterByManager(uPIC, uMUID);
            dataGridViewCurrentUtilization.DataSource = mTaskRecordDetailMng.DboardCurrentTeamUtilizationByPIC_FilterByManager(uPIC, uMUID);
            dataGridViewUtilizationDetailbyUID.DataSource = mTaskRecordDetailMng.DboardCurrentUtilizationDetailUIDByPIC_FilterByManager(uPIC, uMUID);

        }

        //Clear Object
        private void ClearFields()
        {
            dataGridViewTeamDetails.DataSource = null;
            dataGridViewCurrentUtilization.DataSource = null;
            dataGridViewUtilizationDetailbyUID.DataSource = null;
        }

        //Exoprt Data
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewTeamDetails.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewTeamDetails.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {

                        dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Value.ToString();


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

            //Adding the Columns
            foreach (DataGridViewColumn column1 in dataGridViewCurrentUtilization.Columns)
            {
                dt1.Columns.Add(column1.HeaderText);
                //dt1.Columns.Add(column1.HeaderText, column1.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row1 in dataGridViewCurrentUtilization.Rows)
            {
                dt1.Rows.Add();

                for (int i = 0; i < row1.Cells.Count; i++)
                {
                    try
                    {

                        dt1.Rows[dt1.Rows.Count - 1][i] = row1.Cells[i].Value.ToString();


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

            //Adding the Columns
            foreach (DataGridViewColumn column2 in dataGridViewUtilizationDetailbyUID.Columns)
            {
                dt2.Columns.Add(column2.HeaderText);
                //dt2.Columns.Add(column2.HeaderText, column2.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row2 in dataGridViewUtilizationDetailbyUID.Rows)
            {
                dt2.Rows.Add();

                for (int i = 0; i < row2.Cells.Count; i++)
                {
                    try
                    {

                        dt2.Rows[dt2.Rows.Count - 1][i] = row2.Cells[i].Value.ToString();


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

                try
                {
                    //Exporting to Excel           

                    if (!System.IO.File.Exists(fileName))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(fileName))
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "CITITO_" + lblPICToFill.Text + "_Team Details");
                                wb.Worksheets.Add(dt1, "CITITO_" + lblPICToFill.Text + "_Team utilization");
                                wb.Worksheets.Add(dt2, "CITITO_" + lblPICToFill.Text + "_User utilization");
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "CITITO_" + lblPICToFill.Text + "_Team Details");
                            wb.Worksheets.Add(dt1, "CITITO_" + lblPICToFill.Text + "_Team utilization");
                            wb.Worksheets.Add(dt2, "CITITO_" + lblPICToFill.Text + "_User utilization");
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            cmbUID.SelectedIndex = -1;
        }

        private void cmbUID_MouseClick(object sender, MouseEventArgs e)
        {
            cmbProject.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();

            cmbProject.SelectedIndex = -1;
            //cmbMUID.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }

        //Filter by Project
        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uMUID = cmbMUID.Text;
            string uProject = cmbProject.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uProject))
            {

                //DataGridView
                dataGridViewTeamDetails.DataSource = mTaskRecordDetailMng.DboardActiveTeamDetailByPIC_FilterByProjectAndManager(uPIC, uProject, uMUID);
                dataGridViewCurrentUtilization.DataSource = mTaskRecordDetailMng.DboardCurrentTeamUtilizationByPIC_FilterByProjectAndManager(uPIC, uProject, uMUID);
                dataGridViewUtilizationDetailbyUID.DataSource = mTaskRecordDetailMng.DboardCurrentUtilizationDetailUIDByPIC_FilterByProjctAndManager(uPIC, uProject, uMUID);

            }
        }

        //Filter By User
        private void cmbUID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uMUID = cmbMUID.Text;
            string uUID = cmbUID.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uUID))
            {

                //DataGridView
                //dataGridViewTeamDetails.DataSource = mTaskRecordDetailMng.DboardActiveTeamDetailByPIC_FilterByUser(uPIC, uUID);
                dataGridViewUtilizationDetailbyUID.DataSource = mTaskRecordDetailMng.DboardCurrentTeamUtilizationByPIC_FilterByUserAndManager(uPIC, uUID, uMUID);
                dataGridViewCurrentUtilization.DataSource = mTaskRecordDetailMng.DboardCurrentUtilizationDetailUIDByPIC_FilterByUserAndManager(uPIC, uUID, uMUID);

            }
        }
    }
}
