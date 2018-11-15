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

    public partial class frm_TaskInOutX3 : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_TaskInOutX3 _instance;
        public static frm_TaskInOutX3 GetInstance(string uUID, string uMUID, string uMName, DateTime uLogTime)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUID = uUID;
                String mMUID = uMUID;
                String mName = uMName;
                DateTime mLogTime = uLogTime;

                _instance = new frm_TaskInOutX3(mUID, mMUID, mName, uLogTime);

            }
            return _instance;

        }

        public frm_TaskInOutX3(string uUID, string uMUID, string uMName, DateTime uLogTime)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

            lblMUIDToFill.Text = uMUID;
            lblTRUIDToFill.Text = uUID;

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to exit from CITITO?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                Application.Exit();


            }
            else
            {
                //...
            }
        }

        private void frm_TaskInOutX3_Load(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uUID = lblTRUIDToFill.Text;
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
            cmbProject.DataSource = mTaskDetailMng.GetAllTaskCodeDetailsByPIC(uUID);
            cmbProject.SelectedIndex = -1;

            //DataGridView
            dataGridViewUserX3Summary.DataSource = mTaskRecordDetailMng.DboardPerformanceX3User_UID(uUID, uFrom, uTo);
            dataGridViewDataSetUID.DataSource = mTaskRecordDetailMng.DboardPerformanceX3UserAllDataSet_ByUser(uUID, uFrom, uTo);

            //DataGridvew Alignmnet
            this.dataGridViewUserX3Summary.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewUserX3Summary.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridViewUserX3Summary.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewUserX3Summary.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            RefreshData();
        }

        //Refresh Object
        private void RefreshData()
        {
            //Common Initialization
            string uUID = lblTRUIDToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);
            ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);
            UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);
            UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;


            //DataGridView
            dataGridViewUserX3Summary.DataSource = mTaskRecordDetailMng.DboardPerformanceX3User_UID(uUID, uFrom, uTo);
            dataGridViewDataSetUID.DataSource = mTaskRecordDetailMng.DboardPerformanceX3UserAllDataSet_ByUser(uUID, uFrom, uTo);

            //DataGridvew Alignmnet
            this.dataGridViewUserX3Summary.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewUserX3Summary.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridViewUserX3Summary.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewUserX3Summary.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewUserX3Summary.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        //Clear Object
        private void ClearFields()
        {
            //dataGridViewX3TeamWise.DataSource = null;
            //dataGridViewX3TaskWise.DataSource = null;
            dataGridViewUserX3Summary.DataSource = null;
            dataGridViewDataSetUID.DataSource = null;
        }

        //Clear button
        private void btnClrAll_Click(object sender, EventArgs e)
        {
            ClearFields();


            //cmbProject.SelectedIndex = -1;
            //cmbMUID.SelectedIndex = -1;
            cmbProject.SelectedIndex = -1;

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
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
            //Common Initialization
            string mUID = lblTRUIDToFill.Text;

            //Creating DataTable
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewUserX3Summary.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }
            foreach (DataGridViewColumn column1 in dataGridViewDataSetUID.Columns)
            {
                dt2.Columns.Add(column1.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewUserX3Summary.Rows)
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

            //Adding the Rows
            foreach (DataGridViewRow row2 in dataGridViewDataSetUID.Rows)
            {
                dt2.Rows.Add();

                for (int i = 0; i < row2.Cells.Count; i++)
                {
                    try
                    {

                        if (i == 11)
                        {
                            if ((Int32)row2.Cells[11].Value == 0)
                            {
                                dt2.Rows[dt2.Rows.Count - 1][11] = "Fresh";
                            }
                            else if ((Int32)row2.Cells[11].Value == 1)
                            {
                                dt2.Rows[dt2.Rows.Count - 1][11] = "On Hold";
                            }
                            else if ((Int32)row2.Cells[11].Value == 2)
                            {
                                dt2.Rows[dt2.Rows.Count - 1][11] = "Pending";
                            }
                            else if ((Int32)row2.Cells[11].Value == 3)
                            {
                                dt2.Rows[dt2.Rows.Count - 1][11] = "Done";
                            }
                            else
                            {
                                dt2.Rows[dt2.Rows.Count - 1][11] = row2.Cells[11].Value.ToString();
                            }

                        }
                        else if (i == 12)
                        {

                            if ((Int32)row2.Cells[12].Value == 0)
                            {
                                dt2.Rows[dt2.Rows.Count - 1][12] = "No Status";
                            }
                            else if ((Int32)row2.Cells[12].Value == 1)
                            {
                                dt2.Rows[dt2.Rows.Count - 1][12] = "Pending";
                            }
                            else if ((Int32)row2.Cells[12].Value == 2)
                            {
                                dt2.Rows[dt2.Rows.Count - 1][12] = "Approved";
                            }
                            else if ((Int32)row2.Cells[12].Value == 3)
                            {
                                dt2.Rows[dt2.Rows.Count - 1][12] = "Disapproved";
                            }
                            else if ((Int32)row2.Cells[12].Value == 4)
                            {
                                dt2.Rows[dt2.Rows.Count - 1][12] = "Skipped";
                            }
                            else
                            {
                                dt2.Rows[dt2.Rows.Count - 1][12] = row2.Cells[12].Value.ToString();
                            }

                        }

                        else
                        {
                            dt2.Rows[dt2.Rows.Count - 1][i] = row2.Cells[i].Value.ToString();
                        }

                        //dt2.Rows[dt2.Rows.Count - 1][i] = row2.Cells[i].Value.ToString();


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
                                wb.Worksheets.Add(dt, "CITITO_" + mUID + "_X3 Summary");
                                wb.Worksheets.Add(dt2, "CITITO_" + mUID + "_X3 Details");
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "CITITO_" + mUID + "_X3 Summary");
                            wb.Worksheets.Add(dt2, "CITITO_" + mUID + "_X3 Details");
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

        private void dataGridViewDataSetUID_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
    }
}
