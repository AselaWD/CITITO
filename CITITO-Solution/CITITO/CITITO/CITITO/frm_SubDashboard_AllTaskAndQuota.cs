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
    public partial class frm_SubDashboard_AllTaskAndQuota : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_SubDashboard_AllTaskAndQuota _instance;
        public static frm_SubDashboard_AllTaskAndQuota GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_SubDashboard_AllTaskAndQuota(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_SubDashboard_AllTaskAndQuota(string uMUID, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

            lblUIDToFill.Text = uMUID;
            lblPICToFill.Text = uPIC;
            //lblPICToFill.Text = "ZDQ"; /*ZDQ, 16V, EC4, AV1, LR3, TL6, 36W, 23S*/
        }

        private void frm_SubDashboard_AllTaskAndQuota_Load(object sender, EventArgs e)
        {
            //Common Initialization
            string uPIC = lblPICToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);
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
            dataGridViewTaskAndQuotaDataSet.DataSource = mTaskRecordDetailMng.DboardPICTaskAndQuotaDataset(uPIC, uFrom, uTo);

            //DataGridvew Alignmnet
            this.dataGridViewTaskAndQuotaDataSet.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskAndQuotaDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            this.dataGridViewTaskAndQuotaDataSet.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskAndQuotaDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Dropdown
            cmbProject.DataSource = mProjectDetailMng.GetListOfProjectNamesByPIC(uPIC);
            cmbProject.SelectedIndex = -1;
            cmbItemCode.DataSource = mProcessCodeHeaderMng.GetListProcessCodesByPIC(uPIC);
            cmbItemCode.SelectedIndex = -1;
            cmbTaskCode.DataSource = mTaskDetailMng.GetAllTaskCodeDetailsByPIC(uPIC);
            cmbTaskCode.SelectedIndex = -1;

            RefreshData();

        }

        //Refresh Object
        private void RefreshData()
        {
            //Common Initialization
            string uPIC = lblPICToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;

            //DataGridView
            dataGridViewTaskAndQuotaDataSet.DataSource = mTaskRecordDetailMng.DboardPICTaskAndQuotaDataset(uPIC, uFrom, uTo);

            //DataGridvew Alignmnet
            this.dataGridViewTaskAndQuotaDataSet.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskAndQuotaDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            this.dataGridViewTaskAndQuotaDataSet.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTaskAndQuotaDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        //Clear Object
        private void ClearFields()
        {
            dataGridViewTaskAndQuotaDataSet.DataSource = null;
        }

        private void btnBackToTask_Click(object sender, EventArgs e)
        {
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboard_TaskAndQuota myForm = frm_SubDashboard_TaskAndQuota.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_MainReportDashboard form1 = (frm_MainReportDashboard)Application.OpenForms["frm_MainReportDashboard"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();
        }

        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewTaskAndQuotaDataSet.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewTaskAndQuotaDataSet.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {

                        if (i == 8)
                        {
                            dt.Rows[dt.Rows.Count - 1][8] = double.Parse(row.Cells[8].Value.ToString()).ToString("0.###") + "%";
                        }                        
                        else
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Value.ToString();
                        }

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
                                wb.Worksheets.Add(dt, "CITITO_" + lblPICToFill.Text + "_Task & Quota-DataSet");
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "CITITO_" + lblPICToFill.Text + "_Task & Quota-DataSet");
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

        private void dataGridViewTaskAndQuotaDataSet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("0.##");
            }
            if (e.ColumnIndex == 8)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("0.##");
            }
        }

        //Filter by project
        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uProject = cmbProject.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uProject))
            {

                //DataGridView
                dataGridViewTaskAndQuotaDataSet.DataSource = mTaskRecordDetailMng.DboardPICTaskAndQuotaDataset_FilterByProject(uPIC, uFrom, uTo, uProject);

                //DataGridvew Alignmnet
                this.dataGridViewTaskAndQuotaDataSet.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskAndQuotaDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                this.dataGridViewTaskAndQuotaDataSet.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskAndQuotaDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

        //Filter by item Code
        private void cmbItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uItemCode = cmbItemCode.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uItemCode))
            {

                //DataGridView
                dataGridViewTaskAndQuotaDataSet.DataSource = mTaskRecordDetailMng.DboardPICTaskAndQuotaDataset_FilterByItemCode(uPIC, uFrom, uTo, uItemCode);

                //DataGridvew Alignmnet
                this.dataGridViewTaskAndQuotaDataSet.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskAndQuotaDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                this.dataGridViewTaskAndQuotaDataSet.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskAndQuotaDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

        //Filter by Task Code
        private void cmbTaskCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uTaskCode = cmbTaskCode.Text;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uTaskCode))
            {

                //DataGridView
                dataGridViewTaskAndQuotaDataSet.DataSource = mTaskRecordDetailMng.DboardPICTaskAndQuotaDataset_FilterByTaskCode(uPIC, uFrom, uTo, uTaskCode);

                //DataGridvew Alignmnet
                this.dataGridViewTaskAndQuotaDataSet.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskAndQuotaDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                this.dataGridViewTaskAndQuotaDataSet.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewTaskAndQuotaDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

        //Clear Filter button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();

            cmbProject.SelectedIndex = -1;
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

        //Go button
        private void btnGo_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshData();
        }

        private void cmbProject_MouseClick(object sender, MouseEventArgs e)
        {
            cmbItemCode.SelectedIndex = -1;
            cmbTaskCode.SelectedIndex = -1;
        }

        private void cmbItemCode_MouseClick(object sender, MouseEventArgs e)
        {
            cmbProject.SelectedIndex = -1;
            cmbTaskCode.SelectedIndex = -1;
        }

        private void cmbTaskCode_MouseClick(object sender, MouseEventArgs e)
        {
            cmbItemCode.SelectedIndex = -1;
            cmbProject.SelectedIndex = -1;
        }

        private void btnClrAll_Click(object sender, EventArgs e)
        {
            ClearFields();

            cmbProject.SelectedIndex = -1;
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
