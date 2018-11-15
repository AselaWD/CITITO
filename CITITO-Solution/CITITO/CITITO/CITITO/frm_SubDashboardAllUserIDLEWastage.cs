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
    public partial class frm_SubDashboardAllUserIDLEWastage : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_SubDashboardAllUserIDLEWastage _instance;
        public static frm_SubDashboardAllUserIDLEWastage GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_SubDashboardAllUserIDLEWastage(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_SubDashboardAllUserIDLEWastage(string uMUID, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

            lblUIDToFill.Text = uMUID;
            lblPICToFill.Text = uPIC;
            //lblPICToFill.Text = "ZDQ"; /*ZDQ, 16V, EC4, AV1, LR3, TL6, 36W, 23S*/
        }

        private void frm_SubDashboardAllUserIDLEWastage_Load(object sender, EventArgs e)
        {

            //Common Initialization
            string uPIC = lblPICToFill.Text;
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
            dataGridViewUserIDLEAndWastageDataSet.DataSource = mTaskRecordDetailMng.DboardUserIDLEAndWastageAllDataSet_ByPIC(uPIC, uFrom, uTo);

            //DataGridvew Alignmnet

            this.dataGridViewUserIDLEAndWastageDataSet.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridViewUserIDLEAndWastageDataSet.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Dropdown
            cmbMUID.DataSource = mManagerHeaderMng.GetActiveManagerUIDByPIC(uPIC);
            cmbMUID.SelectedIndex = -1;
            cmbUID.DataSource = mUserManagementDetailMng.ListActiveUIDByPIC(uPIC);
            cmbUID.SelectedIndex = -1;

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
            dataGridViewUserIDLEAndWastageDataSet.DataSource = mTaskRecordDetailMng.DboardUserIDLEAndWastageAllDataSet_ByPIC(uPIC, uFrom, uTo);

            //DataGridvew Alignmnet

            this.dataGridViewUserIDLEAndWastageDataSet.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridViewUserIDLEAndWastageDataSet.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserIDLEAndWastageDataSet.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        //Clear Object
        private void ClearFields()
        {
            dataGridViewUserIDLEAndWastageDataSet.DataSource = null;
        }

        //Go Back button
        private void btnBackToTask_Click(object sender, EventArgs e)
        {
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboardWastage myForm = frm_SubDashboardWastage.GetInstance(uPIC, uMUID);

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

        private void dataGridViewUserIDLEAndWastageDataSet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Round Up
            if (e.ColumnIndex == 5)
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
            if (e.ColumnIndex == 8)
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

            if (e.ColumnIndex == 9)
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

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            

            cmbMUID.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;


            ////Header Panel
            //DateTime now = DateTime.Now;
            //var startDate = new DateTime(now.Year, now.Month, 1);
            //var endDate = startDate.AddMonths(1).AddDays(-1);

            //metroDateTime1From.Value = startDate;
            //metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }

        private void cmbMUID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uMUID = cmbMUID.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);
            ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);
            UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);
            UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uMUID))
            {

                //DataGridView
                dataGridViewUserIDLEAndWastageDataSet.DataSource = mTaskRecordDetailMng.DboardUserIDLEAndWastageAllDataSet_ByPIC_FilterByManager(uPIC, uFrom, uTo, uMUID);


                //DataGridvew Alignmnet

                this.dataGridViewUserIDLEAndWastageDataSet.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridViewUserIDLEAndWastageDataSet.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

        private void cmbUID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            string uUID = cmbUID.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);
            ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);
            UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);
            UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            if (!String.IsNullOrEmpty(uUID))
            {

                //DataGridView
                dataGridViewUserIDLEAndWastageDataSet.DataSource = mTaskRecordDetailMng.DboardUserIDLEAndWastageAllDataSet_ByPIC_FilterByUser(uPIC, uFrom, uTo, uUID);

                //DataGridvew Alignmnet

                this.dataGridViewUserIDLEAndWastageDataSet.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridViewUserIDLEAndWastageDataSet.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridViewUserIDLEAndWastageDataSet.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

        //Go button
        private void btnGo_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshData();
        }

        //Export Excel
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewUserIDLEAndWastageDataSet.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewUserIDLEAndWastageDataSet.Rows)
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
                                var ws = wb.Worksheets.Add(dt, "CITITO_" + lblPICToFill.Text + "_IDLE+Wastage DataSet");

                                ws.Range("A2:A1048576").CellsUsed().SetDataType(XLDataType.DateTime);
                                ws.Range("D2:E1048576").CellsUsed().SetDataType(XLDataType.DateTime);
                                ws.Range("F2:F1048576").CellsUsed().SetDataType(XLDataType.Number);
                                ws.Range("G2:H1048576").CellsUsed().SetDataType(XLDataType.DateTime);
                                ws.Range("I2:K1048576").CellsUsed().SetDataType(XLDataType.Number);

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
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + lblPICToFill.Text + "_IDLE+Wastage DataSet");

                            ws.Range("A2:A1048576").CellsUsed().SetDataType(XLDataType.DateTime);
                            ws.Range("D2:E1048576").CellsUsed().SetDataType(XLDataType.DateTime);
                            ws.Range("F2:F1048576").CellsUsed().SetDataType(XLDataType.Number);
                            ws.Range("G2:H1048576").CellsUsed().SetDataType(XLDataType.DateTime);
                            ws.Range("I2:K1048576").CellsUsed().SetDataType(XLDataType.Number);

                            ws.Columns().AdjustToContents();
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

        private void cmbMUID_MouseClick(object sender, MouseEventArgs e)
        {
            cmbUID.SelectedIndex = -1;

        }

        private void cmbUID_MouseClick(object sender, MouseEventArgs e)
        {
            cmbMUID.SelectedIndex = -1;
        }

        private void btnClrAll_Click(object sender, EventArgs e)
        {
            ClearFields();


            cmbMUID.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;


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
