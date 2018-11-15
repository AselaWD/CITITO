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
    public partial class frm_TaskInOutApprovalHistory : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_TaskInOutApprovalHistory _instance;
        public static frm_TaskInOutApprovalHistory GetInstance(string uPIC, string uMUID)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mPIC = uPIC;
                String mMUID = uMUID;


                _instance = new frm_TaskInOutApprovalHistory(mPIC, mMUID);

            }
            return _instance;

        }

        public frm_TaskInOutApprovalHistory(string uPIC, string uMUID)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblMUID.Text = uMUID;
            lblPIC.Text = uPIC;
        }

        /*CITITO Server Time*/
        public DateTime ServerDateTime()
        {
            ServerTime mServerTime = new ServerTime(this.conn);
            DateTime sDate = mServerTime.getServerTime();
            return sDate;
        }

        private void frm_TaskInOutApprovalHistory_Load(object sender, EventArgs e)
        {
            string uMID = lblMUID.Text;
            string uPIC = lblPIC.Text;
            DateTime uFrom = DateTime.Parse(dateTimePickerFrom.Value.ToString("MM-dd-yyyy 00:00:00"));
            DateTime uTo = DateTime.Parse(dateTimePickerTo.Value.ToString("MM-dd-yyyy 23:59:59"));

            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                cmbMUID1.DataSource = new ManagerHeaderMng(this.conn).GetActiveManagerUIDByPIC(uPIC);
                cmbMUID1.SelectedIndex = -1;
                cmbMUID1.Enabled = true;

                //Fill Datagridview
                dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByPIC(uPIC, uFrom, uTo);

            }
            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMID))
            {
                cmbMUID1.Items.Add(uMID);
                cmbMUID1.SelectedIndex = 0;
                cmbMUID1.Enabled = false;

                dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByManager(uMID, uFrom, uTo);

            }

            this.BindGrid();

            dataGridViewTaskInOutForApproval.Columns[0].Width = 30;
            dataGridViewTaskInOutForApproval.Columns[1].Width = 40;
            dataGridViewTaskInOutForApproval.Columns[5].Width = 105;
            dataGridViewTaskInOutForApproval.Columns[6].Width = 55;
            dataGridViewTaskInOutForApproval.Columns[12].Width = 50;
        }

        private void RefreshData()
        {
            string uMID = lblMUID.Text;
            string uPIC = lblPIC.Text;
            DateTime uFrom = DateTime.Parse(dateTimePickerFrom.Value.ToString("MM-dd-yyyy 00:00:00"));
            DateTime uTo = DateTime.Parse(dateTimePickerTo.Value.ToString("MM-dd-yyyy 23:59:59"));

            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                cmbMUID1.DataSource = new ManagerHeaderMng(this.conn).GetActiveManagerUIDByPIC(uPIC);
                cmbMUID1.SelectedIndex = -1;
                cmbMUID1.Enabled = true;

                //Fill Datagridview
                dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByPIC(uPIC, uFrom, uTo);

            }
            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMID))
            {
                cmbMUID1.Items.Add(uMID);
                cmbMUID1.SelectedIndex = 0;
                cmbMUID1.Enabled = false;

                dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByManager(uMID, uFrom, uTo);

            }
            headerCheckBox.Checked = false;
        }

        private void ClearFields()
        {
            RefreshData();

        }

        CheckBox headerCheckBox = new CheckBox();

        private void BindGrid()
        {
            //Add a CheckBox Column to the DataGridView Header Cell.

            //Find the Location of Header Cell.
            Point headerCellLocation = this.dataGridViewTaskInOutForApproval.GetCellDisplayRectangle(0, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 20);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dataGridViewTaskInOutForApproval.Controls.Add(headerCheckBox);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridViewTaskInOutForApproval.Columns.Insert(0, checkBoxColumn);

            //Assign Click event to the DataGridView Cell.
            dataGridViewTaskInOutForApproval.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dataGridViewTaskInOutForApproval.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dataGridViewTaskInOutForApproval.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        //Go Back button
        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewTaskInOutForApproval_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewTaskInOutForApproval.SelectedRows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                if (isSelected)
                {
                    row.Cells[0].Value = false;

                    //Loop to verify whether all row CheckBoxes are checked or not.
                    bool isChecked = true;
                    foreach (DataGridViewRow row2 in dataGridViewTaskInOutForApproval.Rows)
                    {
                        if (Convert.ToBoolean(row2.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                        {
                            isChecked = false;

                        }

                    }
                    headerCheckBox.Checked = isChecked;

                }
                else
                {
                    row.Cells[0].Value = true;

                    //Loop to verify whether all row CheckBoxes are checked or not.
                    bool isChecked = true;
                    foreach (DataGridViewRow row2 in dataGridViewTaskInOutForApproval.Rows)
                    {
                        if (Convert.ToBoolean(row2.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                        {
                            isChecked = false;

                        }

                    }
                    headerCheckBox.Checked = isChecked;


                }

            }
        }

        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewTaskInOutForApproval.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewTaskInOutForApproval.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {
                        if (i == 0)
                        {

                        }
                        else if (i == 9)
                        {
                            if ((Int32)row.Cells[9].Value == 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][9] = "Fresh";
                            }
                            else if ((Int32)row.Cells[9].Value == 1)
                            {
                                dt.Rows[dt.Rows.Count - 1][9] = "Hold";
                            }
                            else if ((Int32)row.Cells[9].Value == 2)
                            {
                                dt.Rows[dt.Rows.Count - 1][9] = "Pending";
                            }
                            else if ((Int32)row.Cells[9].Value == 3)
                            {
                                dt.Rows[dt.Rows.Count - 1][9] = "Done";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][9] = row.Cells[9].Value.ToString();
                            }

                        }
                        else if (i == 12)
                        {
                            dt.Rows[dt.Rows.Count - 1][12] = double.Parse(row.Cells[12].Value.ToString()).ToString("0.###");

                        }
                        else if (i == 13)
                        {

                            if ((Int32)row.Cells[13].Value == 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][13] = "No Status";
                            }
                            else if ((Int32)row.Cells[13].Value == 1)
                            {
                                dt.Rows[dt.Rows.Count - 1][13] = "Pending";
                            }
                            else if ((Int32)row.Cells[13].Value == 2)
                            {
                                dt.Rows[dt.Rows.Count - 1][13] = "Approved";
                            }
                            else if ((Int32)row.Cells[13].Value == 3)
                            {
                                dt.Rows[dt.Rows.Count - 1][13] = "Disapproved";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][13] = row.Cells[13].Value.ToString();
                            }

                        }
                        else if (i == 15)
                        {
                            //MessageBox.Show(row.Cells[15].Value.ToString(), "---");

                            if (row.Cells[15].Value.ToString() == "0")
                            {
                                dt.Rows[dt.Rows.Count - 1][15] = "Not Calcutated";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][15] = double.Parse(row.Cells[15].Value.ToString()).ToString("0.###") + "%";
                            }
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

                //Exporting to Excel           

                try
                {

                    if (!System.IO.File.Exists(fileName))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(fileName))
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {

                                var ws = wb.Worksheets.Add(dt, "CITITO_" + lblMUID.Text + "_Approals History");
                                ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask approval history records successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + lblMUID.Text + "_Approals History");
                            ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask approval history records successfully export to \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();

            cmbUserID.Text = String.Empty;
            cmbFApproved.Text = String.Empty;
            cmbPCPCode.Text = String.Empty;
            cmbFileName.Text = String.Empty;

            dateTimePickerFrom.Value = ServerDateTime();
            dateTimePickerTo.Value = ServerDateTime();
        }


        //Refersh button
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridViewTaskInOutForApproval_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set the background to red for negative values in the Balance column.
            if (dataGridViewTaskInOutForApproval.Rows.Count != 0)
            {


                if (dataGridViewTaskInOutForApproval.Columns[e.ColumnIndex].Index == 9)
                {

                    if (e.Value.ToString() != "")
                    {
                        if (e.Value.ToString() == "0")
                        {
                            e.Value = "Fresh";
                            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                        }
                        else if (e.Value.ToString() == "1")
                        {
                            e.Value = "Hold";
                            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FD7C66");
                        }
                        else if (e.Value.ToString() == "2")
                        {
                            e.Value = "Pending";
                            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");
                        }
                        else if (e.Value.ToString() == "3")
                        {
                            e.Value = "Done";
                            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9FEB");
                        }
                    }
                }
                if (dataGridViewTaskInOutForApproval.Columns[e.ColumnIndex].Index == 12)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.###");
                }

                if (dataGridViewTaskInOutForApproval.Columns[e.ColumnIndex].Index == 13)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "No Status";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                    }
                    else if (e.Value.ToString() == "1")
                    {
                        e.Value = "Pending";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");
                    }
                    else if (e.Value.ToString() == "2")
                    {
                        e.Value = "Approved";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9FEB");
                    }
                    else if (e.Value.ToString() == "3")
                    {
                        e.Value = "Disapproved";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FD7C66");
                    }
                }

                if (dataGridViewTaskInOutForApproval.Columns[e.ColumnIndex].Index == 15)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.###") + "%";

                    if (d == 0)
                    {
                        e.Value = "Not Calcutated";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");
                    }
                }

            }
        }

        //Filters
        private void cmbMUID1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uUID = cmbUserID.Text;
            string uMUID = cmbMUID1.Text;
            DateTime uFrom = DateTime.Parse(dateTimePickerFrom.Value.ToString("MM-dd-yyyy 00:00:00"));
            DateTime uTo = DateTime.Parse(dateTimePickerTo.Value.ToString("MM-dd-yyyy 23:59:59"));

            dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByManager(uMUID, uFrom, uTo);
        }        

        private void cmbFApproved_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uApproval = cmbFApproved.Text;
            string uMUID = cmbMUID1.Text;
            string uPIC = lblPIC.Text;
            
            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                if (uApproval == "Approved")
                {
                    uApproval = "2";
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByApprovedAndPIC(uPIC, uApproval);
                }
                if (uApproval == "Disapproved")
                {
                    uApproval = "3";
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByApprovedAndPIC(uPIC, uApproval);
                }

            }

            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMUID))
            {

                if (uApproval == "Approved")
                {
                    uApproval = "2";
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByApprovedAndManager(uMUID, uApproval);
                }
                if (uApproval == "Disapproved")
                {
                    uApproval = "3";
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByApprovedAndManager(uMUID, uApproval);
                }
            }



        }


        private void cmbUserID_KeyUp(object sender, KeyEventArgs e)
        {
            string uUID = cmbUserID.Text;
            string uMUID = cmbMUID1.Text;
            string uPIC = lblPIC.Text;

            if (cmbMUID1.Enabled)
            {
                if (!String.IsNullOrEmpty(uUID))
                {
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByPICAndUID(uUID, uPIC);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(uUID))
                {
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByManagerAndUID(uUID, uMUID);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
        }

        private void cmbPCPCode_KeyUp(object sender, KeyEventArgs e)
        {
            string uPCPCode = cmbPCPCode.Text;
            string uMUID = cmbMUID1.Text;
            string uPIC = lblPIC.Text;

            if (cmbMUID1.Enabled)
            {
                if (!String.IsNullOrEmpty(uPCPCode))
                {
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByPICAndPCPCode(uPCPCode, uPIC);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(uPCPCode))
                {
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByManagerAndPCPCode(uPCPCode, uMUID);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
        }

        private void cmbFileName_KeyUp(object sender, KeyEventArgs e)
        {
            string uFileName = cmbFileName.Text;
            string uMUID = cmbMUID1.Text;
            string uPIC = lblPIC.Text;

            if (cmbMUID1.Enabled)
            {
                if (!String.IsNullOrEmpty(uFileName))
                {
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByPICAndFileName(uFileName, uPIC);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(uFileName))
                {
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByManagerAndFileName(uFileName, uMUID);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string uMUID = lblMUID.Text;
            string uPIC = lblPIC.Text;
            DateTime uFrom = DateTime.Parse(dateTimePickerFrom.Value.ToString("MM-dd-yyyy 00:00:00"));
            DateTime uTo = DateTime.Parse(dateTimePickerTo.Value.ToString("MM-dd-yyyy 23:59:59"));

            if (cmbMUID1.Enabled)
            {
                dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedPCPRecordByDateRangeByPIC(uPIC, uFrom, uTo);
            }
            else
            {
                dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedPCPRecordByDateRange(uMUID, uFrom, uTo);
            }
        }

        //Rollback button
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dataGridViewTaskInOutForApproval.Rows.Count == 0)
            {
                //MessageBox.Show("There is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //Check if there any checkbox checked/unchecked in cloumn 0
            for (int j = 0; j < dataGridViewTaskInOutForApproval.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewTaskInOutForApproval[0, j].Value) == false)
                {
                    if ((dataGridViewTaskInOutForApproval.RowCount - 1) == j)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select at least one record.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    break;
                }
            }

            TaskRecordDetail mTaskRecordDetail = new TaskRecordDetail();
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);


            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to rollback selected record(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //initialize Approval Details part 1 (Date Variable)
                mTaskRecordDetail.TR_ApprovalTime = ServerDateTime();

                for (int j = 0; j < dataGridViewTaskInOutForApproval.RowCount; j++)
                {
                    if (Convert.ToBoolean(dataGridViewTaskInOutForApproval[0, j].Value) == true)
                    {

                        //initialize Approval Details part 2
                        mTaskRecordDetail.TR_ID = dataGridViewTaskInOutForApproval[2, j].Value.ToString();
                        mTaskRecordDetail.PCP_ID = dataGridViewTaskInOutForApproval[3, j].Value.ToString();
                        mTaskRecordDetail.TR_Shipment = dataGridViewTaskInOutForApproval[4, j].Value.ToString();
                        mTaskRecordDetail.TR_File = dataGridViewTaskInOutForApproval[5, j].Value.ToString();
                        mTaskRecordDetail.TR_FileSize = int.Parse(dataGridViewTaskInOutForApproval[6, j].Value.ToString());
                        mTaskRecordDetail.Task_ID = dataGridViewTaskInOutForApproval[8, j].Value.ToString();
                        mTaskRecordDetail.TR_Status = int.Parse(dataGridViewTaskInOutForApproval[9, j].Value.ToString());
                        mTaskRecordDetail.TR_Apporval = 1;

                        if (mTaskRecordDetailMng.UpdateTaskRecordDetailToRollback(mTaskRecordDetail) > 0)
                        {

                        }

                    }
                }

                //Show Completed Message
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been rollback!", "Record(s) Rollback!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
                //ClearFields();

                //Refresh frm_TaskInOutApproval Form
                String uPIC = lblPIC.Text;
                String uMUID = lblMUID.Text;

                frm_TaskInOutApproval myForm = frm_TaskInOutApproval.GetInstance(uPIC, uMUID);

                myForm.RefreshData();
                myForm.ClearFields();

            }
        }

        private void dataGridViewTaskInOutForApproval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                foreach (DataGridViewRow row in dataGridViewTaskInOutForApproval.SelectedRows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                    if (isSelected)
                    {
                        row.Cells[0].Value = false;

                        //Loop to verify whether all row CheckBoxes are checked or not.
                        bool isChecked = true;
                        foreach (DataGridViewRow row2 in dataGridViewTaskInOutForApproval.Rows)
                        {
                            if (Convert.ToBoolean(row2.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                            {
                                isChecked = false;

                            }

                        }
                        headerCheckBox.Checked = isChecked;

                    }
                    else
                    {
                        row.Cells[0].Value = true;

                        //Loop to verify whether all row CheckBoxes are checked or not.
                        bool isChecked = true;
                        foreach (DataGridViewRow row2 in dataGridViewTaskInOutForApproval.Rows)
                        {
                            if (Convert.ToBoolean(row2.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                            {
                                isChecked = false;

                            }

                        }
                        headerCheckBox.Checked = isChecked;


                    }

                }
            }
        }
    }
}
