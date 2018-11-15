using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using ClosedXML.Excel;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;
using MetroFramework.Animation;

namespace CITITO
{
    public partial class frm_SubDashboardWorkLoad_Summary : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_SubDashboardWorkLoad_Summary _instance;
        public static frm_SubDashboardWorkLoad_Summary GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_SubDashboardWorkLoad_Summary(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_SubDashboardWorkLoad_Summary(string uMUID, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

            lblUIDToFill.Text = uMUID;
            lblPICToFill.Text = uPIC;
            //lblPICToFill.Text = "ZDQ"; /*ZDQ, 16V, EC4, AV1, LR3, TL6, 36W, 23S*/

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            DateTime uFrom = startDate;
            DateTime uTo = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        private void frm_SubDashboardWorkLoad_Summary_Load(object sender, EventArgs e)
        {
            //Common Initialization
            string uPIC = lblPICToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            DateTime uFrom = startDate;
            DateTime uTo = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            //DataGridView
            dataGridViewWorkloadSummary.DataSource = mTaskRecordDetailMng.DboardWorkLoadSummary(uPIC);


            ///* Fresh */
            //// Initialize the button column.
            //DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            //buttonColumn.Text = "View Records";
            //buttonColumn.AutoSizeMode =
            //DataGridViewAutoSizeColumnMode.AllCells;

            //// Use the Text property for the button text for all cells rather
            //// than using each cell's value as the text for its own button.
            //buttonColumn.UseColumnTextForButtonValue = true;

            //// Add the button column to the control.
            //dataGridViewWorkloadSummary.Columns.Insert(0, buttonColumn);


            ////Change remove column to last-child
            //DataGridViewColumnCollection columnCollection = dataGridViewWorkloadSummary.Columns;

            //DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
            //DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

            //int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
            //firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
            ////lastVisibleColumn.DisplayIndex = firstColumn_sIndex;

            //Dropdown
            cmbProject.DataSource = mProjectDetailMng.GetListOfProjectNamesByPIC(uPIC);
            cmbProject.SelectedIndex = -1;

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
            dataGridViewWorkloadSummary.DataSource = mTaskRecordDetailMng.DboardWorkLoadSummary(uPIC);

            ////Change remove column to last-child
            //DataGridViewColumnCollection columnCollection = dataGridViewWorkloadSummary.Columns;

            //DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
            //DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

            //int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
            //firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
            ////lastVisibleColumn.DisplayIndex = firstColumn_sIndex;

            //////DataGridvew Alignmnet
            ////this.dataGridViewWorkloadSummary.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ////this.dataGridViewWorkloadSummary.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            ////this.dataGridViewWorkloadSummary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ////this.dataGridViewWorkloadSummary.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        //Clear Object
        private void ClearFields()
        {
            dataGridViewWorkloadSummary.DataSource = null;
        }

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
                dataGridViewWorkloadSummary.DataSource = mTaskRecordDetailMng.DboardWorkLoadSummary_FilterByProject(uPIC, uProject);


                ////Change remove column to last-child
                //DataGridViewColumnCollection columnCollection = dataGridViewWorkloadSummary.Columns;

                //DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
                //DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

                //int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
                //firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
                ////lastVisibleColumn.DisplayIndex = firstColumn_sIndex;

                //////DataGridvew Alignmnet
                ////this.dataGridViewWorkloadSummary.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                ////this.dataGridViewWorkloadSummary.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                ////this.dataGridViewWorkloadSummary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ////this.dataGridViewWorkloadSummary.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();

            cmbProject.SelectedIndex = -1;

            ////Header Panel
            //DateTime now = DateTime.Now;
            //var startDate = new DateTime(now.Year, now.Month, 1);
            //var endDate = startDate.AddMonths(1).AddDays(-1);

            //metroDateTime1From.Value = startDate;
            //metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshData();
        }

        private void btnClrAll_Click(object sender, EventArgs e)
        {
            ClearFields();

            cmbProject.SelectedIndex = -1;

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }

        

        //Export Excel
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Common Initialization
            string mPIC = lblPICToFill.Text;

            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewWorkloadSummary.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewWorkloadSummary.Rows)
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
                                var ws = wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_Work Load Summary");
                               
                                ws.Range("B2:F1048576").CellsUsed().SetDataType(XLDataType.Number);


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
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_Work Load Summary");

                            ws.Range("B2:F1048576").CellsUsed().SetDataType(XLDataType.Number);

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
        private void btnViewDataSet_Click(object sender, EventArgs e)
        {
            string uPIC = lblPICToFill.Text;
            string uMUID = lblUIDToFill.Text;

            frm_SubDashboardWorkLoadDataSet myForm = frm_SubDashboardWorkLoadDataSet.GetInstance(uPIC, uMUID);

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
    }
}
