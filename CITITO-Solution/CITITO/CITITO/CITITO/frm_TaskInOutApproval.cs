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
    public partial class frm_TaskInOutApproval : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_TaskInOutApproval _instance;
        public static frm_TaskInOutApproval GetInstance(string uPIC, string uMUID)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mPIC = uPIC;
                String mMUID = uMUID;


                _instance = new frm_TaskInOutApproval(mPIC, mMUID);

            }
            return _instance;

        }

        public frm_TaskInOutApproval(string uPIC, string uMUID)
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

        //Refresh Object
        public void RefreshData()
        {
            string uMID =lblMUID.Text;
            string uPIC = lblPIC.Text;

            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                cmbMUID1.DataSource = new ManagerHeaderMng(this.conn).GetActiveManagerUIDByPIC(uPIC);
                cmbMUID1.SelectedIndex = -1;
                cmbMUID1.Enabled = true;
                btnModify.Enabled = false;

                //Fill Datagridview
                dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetPendingTaskInOutRecordByPIC(uPIC);

            }
            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMID))
            {
                cmbMUID1.Items.Add(uMID);
                cmbMUID1.SelectedIndex = 0;
                cmbMUID1.Enabled = false;
                btnModify.Enabled = true;

                dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetPendingTaskInOutRecordByManager(uMID);
            }

            headerCheckBox.Checked = false;
        }

        public void ClearFields()
        {
            RefreshData();
           
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }


        private void frm_TaskInOutApproval_Load(object sender, EventArgs e)
        {
            RefreshData();

            this.BindGrid();

            dataGridViewTaskInOutForApproval.Columns[0].Width = 30;
            dataGridViewTaskInOutForApproval.Columns[1].Width = 40;
            dataGridViewTaskInOutForApproval.Columns[5].Width = 105;
            dataGridViewTaskInOutForApproval.Columns[6].Width = 55;
            dataGridViewTaskInOutForApproval.Columns[12].Width = 50;

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

        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }


        private void cmbMUID1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uUID = cmbUserID.Text;
            string uMUID = cmbMUID1.Text;

            dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetPendingTaskInOutRecordByManager(uMUID);
        
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
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetPendingTaskInOutRecordByPICAndUID(uUID, uPIC);
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
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetPendingTaskInOutRecordByManagerAndUID(uUID, uMUID);
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
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetPendingTaskInOutRecordByPICAndPCPCode(uPCPCode, uPIC);
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
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetPendingTaskInOutRecordByManagerAndPCPCode(uPCPCode, uMUID);
                }
                else
                {
                    RefreshData();
                    ClearFields();
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
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetPendingTaskInOutRecordByPICAndFileName(uFileName, uPIC);
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
                    dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetPendingTaskInOutRecordByManagerAndFileName(uFileName, uMUID);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
            
        }

        //Check button with date filter
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string uMUID = lblMUID.Text;
            string uPIC = lblPIC.Text;
            DateTime uFrom = DateTime.Parse(dateTimePickerFrom.Value.ToString("MM-dd-yyyy 00:00:00"));
            DateTime uTo = DateTime.Parse(dateTimePickerTo.Value.ToString("MM-dd-yyyy 23:59:59"));

            if (cmbMUID1.Enabled)
            {
                dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetPCPRecordByDateRangeByPIC(uPIC, uFrom, uTo);
            }
            else
            {
                dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetPCPRecordByDateRange(uMUID, uFrom, uTo);
            }
                
        }

        
        //Export Excle
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

                                var ws = wb.Worksheets.Add(dt, "CITITO_" + lblMUID.Text + "_Pending Approvals");
                                ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                                wb.SaveAs(fs);
                                
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask pending approval records successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + lblMUID.Text + "_Pending Approvals");
                            ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask pending approval records successfully export to \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void dataGridViewTaskInOutForApproval_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set the background to red for negative values in the Balance column.
            if (dataGridViewTaskInOutForApproval.Rows.Count!=0)
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

        //Approve button
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
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to approve selected record(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //initialize Approval Details part 1 (Date Variable)
                mTaskRecordDetail.TR_ApprovalTime = ServerDateTime();

                for (int j = 0; j < dataGridViewTaskInOutForApproval.RowCount; j++)
                {
                    if (Convert.ToBoolean(dataGridViewTaskInOutForApproval[0, j].Value) == true)
                    {

                        //initialize Approval Details part 2
                        mTaskRecordDetail.TR_ID= dataGridViewTaskInOutForApproval[2, j].Value.ToString();
                        mTaskRecordDetail.PCP_ID = dataGridViewTaskInOutForApproval[3, j].Value.ToString();
                        mTaskRecordDetail.TR_Shipment = dataGridViewTaskInOutForApproval[4, j].Value.ToString();
                        mTaskRecordDetail.TR_File = dataGridViewTaskInOutForApproval[5, j].Value.ToString();
                        mTaskRecordDetail.TR_FileSize = int.Parse(dataGridViewTaskInOutForApproval[6, j].Value.ToString());
                        mTaskRecordDetail.Task_ID = dataGridViewTaskInOutForApproval[8, j].Value.ToString();
                        mTaskRecordDetail.TR_Status = int.Parse(dataGridViewTaskInOutForApproval[9, j].Value.ToString());
                        mTaskRecordDetail.TR_Apporval = 2;
                        
                        if (mTaskRecordDetailMng.UpdateTaskRecordDetailToAprroved(mTaskRecordDetail) > 0)
                        {

                        }

                    }
                }

                //Show Completed Message
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been Approved!", "Record(s) Approved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
                //ClearFields();

            }
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
           
            cmbUserID.Text = String.Empty;           
            cmbPCPCode.Text = String.Empty;
            cmbFileName.Text = String.Empty;

            dateTimePickerFrom.Value = ServerDateTime();
            dateTimePickerTo.Value = ServerDateTime();

            headerCheckBox.Checked = false;
        }

        //Disapprove button
        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            //Text for temp prompt     
            string outputStr = String.Empty;

            if (dataGridViewTaskInOutForApproval.Rows.Count == 0)
            {
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

            PCPDetail mPCPDetail = new PCPDetail();
            PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to disapprove selected record(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //initialize Approval Details part 1 (Date Variable)
                mTaskRecordDetail.TR_ApprovalTime = ServerDateTime();

                for (int j = 0; j < dataGridViewTaskInOutForApproval.RowCount; j++)
                {
                    
                    //initialize Approval Details part 2
                    mTaskRecordDetail.TR_ID = dataGridViewTaskInOutForApproval[2, j].Value.ToString();
                    mTaskRecordDetail.PCP_ID = dataGridViewTaskInOutForApproval[3, j].Value.ToString();
                    mTaskRecordDetail.TR_Shipment = dataGridViewTaskInOutForApproval[4, j].Value.ToString();
                    mTaskRecordDetail.TR_File = dataGridViewTaskInOutForApproval[5, j].Value.ToString();
                    mTaskRecordDetail.TR_FileSize = int.Parse(dataGridViewTaskInOutForApproval[6, j].Value.ToString());
                    mTaskRecordDetail.Task_ID = dataGridViewTaskInOutForApproval[8, j].Value.ToString();
                    mTaskRecordDetail.TR_Status = int.Parse(dataGridViewTaskInOutForApproval[9, j].Value.ToString());
                    mTaskRecordDetail.TR_Apporval = 3;

                    //Initialize PCPDetail
                    mPCPDetail.PCP_ID = dataGridViewTaskInOutForApproval[3, j].Value.ToString();
                    mPCPDetail.PCP_File = dataGridViewTaskInOutForApproval[5, j].Value.ToString();
                    mPCPDetail.Task_ID = dataGridViewTaskInOutForApproval[8, j].Value.ToString();                    
                    mPCPDetail.PCP_Project = mTaskRecordDetailMng.GetProjectNameByPCPID_TaskIDAndPCPFile(mPCPDetail.PCP_ID, mPCPDetail.Task_ID, mPCPDetail.PCP_File);
                    mPCPDetail.PC_ProcessCode = mTaskRecordDetailMng.GetProcessCodeNameByPCPID_TaskIDAndPCPFile(mPCPDetail.PCP_ID, mPCPDetail.Task_ID, mPCPDetail.PCP_File);

                    mPCPDetail.PCP_Status = 2; //If Done

                    if (Convert.ToBoolean(dataGridViewTaskInOutForApproval[0, j].Value) == true)
                    {

                        //Check first Done task is available for selected record
                        if (mTaskRecordDetail.TR_Status == 2 && mTaskRecordDetailMng.GetCountForTaskDoneFirlterByPCPAndTaskCode(mPCPDetail.PCP_ID, mPCPDetail.Task_ID, mPCPDetail.PCP_File) == 1)
                        {
                                                       
                            outputStr += ("--------- "+ mPCPDetail.PCP_File+ " ---------\n" + "Job Code: "+mPCPDetail.PCP_ID +"\nTask ID: "+ mPCPDetail.Task_ID + "\n-----------------------------------\n" + " , ").ToString();
                            continue;

                        }
                        else
                        {
                            //Done without pending records
                            if (mTaskRecordDetail.TR_Status == 3)
                            {
                                //Task Record Disapproved
                                if (mTaskRecordDetailMng.UpdateTaskRecordDetailToDisaprroved(mTaskRecordDetail) > 0)
                                {
                                    ////PCP Pending
                                    //mPCPDetail.PCP_Status = 0; //Fresh
                                    mPCPDetailMng.UpdatePCPDetailToPendingFromDisapproval(mPCPDetail);
                                }
                            }

                            //Pending with mutiple records
                            else if (mTaskRecordDetail.TR_Status == 2 && mTaskRecordDetailMng.GetCountForTaskPendingFirlterByPCPAndTaskCode(mPCPDetail.PCP_ID, mPCPDetail.Task_ID, mPCPDetail.PCP_File) > 1)
                            {
                                //Task Record Disapproved
                                if (mTaskRecordDetailMng.UpdateTaskRecordDetailToDisaprroved(mTaskRecordDetail) > 0)
                                {
                                    //PCP Pending
                                    mPCPDetailMng.UpdatePCPDetailToPendingFromDisapproval(mPCPDetail);
                                }
                            }

                            //
                            //Only pending record
                            else if (mTaskRecordDetail.TR_Status == 2 && mTaskRecordDetailMng.GetCountForTaskPendingFirlterByPCPAndTaskCode(mPCPDetail.PCP_ID, mPCPDetail.Task_ID, mPCPDetail.PCP_File) == 1)
                            {
                                mPCPDetail.PCP_Status = 0; //PCP Detail to Task Fresh

                                //Task Record Disapproved
                                if (mTaskRecordDetailMng.UpdateTaskRecordDetailToDisaprroved(mTaskRecordDetail) > 0)
                                {
                                    //PCP Fresh
                                    mPCPDetailMng.UpdatePCPDetailToPendingFromDisapproval(mPCPDetail);
                                }
                            }
                        }
                        
                    }
                    
                }

                //Check ouput string status
                if (outputStr != "")
                {
                    
                    string moutputProject = "Please disaprove status done record(s) first.," + outputStr;

                    frm_ExistDisapprovalMessage ExistFrom = new frm_ExistDisapprovalMessage(moutputProject);
                    RefreshData();
                    ClearFields();
                    ExistFrom.Show();
                }
                else
                {
                    //Show Completed Message
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been dispproved!", "Record(s) Dispproved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                    ClearFields();

                }
                
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

        //Time modify button
        private void btnTimeModify_Click(object sender, EventArgs e)
        {
            //Check if there any checkbox checked/unchecked in cloumn 0
            for (int j = 0; j < dataGridViewTaskInOutForApproval.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewTaskInOutForApproval[0, j].Value) == false)
                {

                    if ((dataGridViewTaskInOutForApproval.RowCount - 1) == j)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select a record first.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                else
                {
                    break;
                }
            }

            //Check if there any checkbox checked/unchecked in cloumn more than 1
            List<DataGridViewRow> selectedRows = (from row in dataGridViewTaskInOutForApproval.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells[0].Value) == true
                                                  select row).ToList();

            foreach (DataGridViewRow row in selectedRows)
            {
                if (selectedRows.Count > 1)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nMultiple selection cannot be modified at once. Please select one record.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            ////Get user Confirmation
            //DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to modify time on selected record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
                //Pass modify data to Modify form as parameters
                for (int j = 0; j < dataGridViewTaskInOutForApproval.RowCount; j++)
                {

                    if (Convert.ToBoolean(dataGridViewTaskInOutForApproval[0, j].Value) == true)
                    {
                        //Initialize PCP User Detail
                        String mUID = dataGridViewTaskInOutForApproval[1, j].Value.ToString();
                        String mTRID = dataGridViewTaskInOutForApproval[2, j].Value.ToString();
                        String mJOBCode = dataGridViewTaskInOutForApproval[3, j].Value.ToString();
                        String mShipment = dataGridViewTaskInOutForApproval[4, j].Value.ToString();
                        String mFileName = dataGridViewTaskInOutForApproval[5, j].Value.ToString();
                        int mOutput = int.Parse(dataGridViewTaskInOutForApproval[6, j].Value.ToString());
                        String mUOM = dataGridViewTaskInOutForApproval[7, j].Value.ToString();
                        String mTask = dataGridViewTaskInOutForApproval[8, j].Value.ToString();
                        int mJobStatus = int.Parse(dataGridViewTaskInOutForApproval[9, j].Value.ToString());
                        DateTime mTaskIn = DateTime.Parse(dataGridViewTaskInOutForApproval[10, j].Value.ToString());
                        DateTime mTaskOut = DateTime.Parse(dataGridViewTaskInOutForApproval[11, j].Value.ToString());
                        float mTaskHours = float.Parse(dataGridViewTaskInOutForApproval[12, j].Value.ToString());

                        frm_TaskInOutTimeModify form = frm_TaskInOutTimeModify.GetInstance(mUID, mTRID, mJOBCode, mShipment, mFileName, mOutput, mUOM, mTask, mJobStatus, mTaskIn, mTaskOut, mTaskHours);

                        if (!form.Visible)
                        {
                            form.Show();
                        }
                        else
                        {
                            form.BringToFront();
                        }
                    }

                }
           // }

        }

        //Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Text for temp prompt     
            string outputStrDelete = String.Empty;

            if (dataGridViewTaskInOutForApproval.Rows.Count == 0)
            {
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

            TaskRecordHeader mTaskRecordHeader = new TaskRecordHeader();
            TaskRecordHeaderMng mTaskRecordHeaderMng = new TaskRecordHeaderMng(this.conn);

            TaskRecordDetail mTaskRecordDetail = new TaskRecordDetail();
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            PCPDetail mPCPDetail = new PCPDetail();
            PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to delete selected record(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //initialize Approval Details part 1 (Date Variable)
                mTaskRecordDetail.TR_ApprovalTime = ServerDateTime();

                for (int j = 0; j < dataGridViewTaskInOutForApproval.RowCount; j++)
                {
                    //Initialize Taske Header
                    mTaskRecordHeader.TR_ID = dataGridViewTaskInOutForApproval[2, j].Value.ToString();
                    mTaskRecordHeader.PCP_ID = dataGridViewTaskInOutForApproval[3, j].Value.ToString();

                    //initialize Approval Details part 2
                    mTaskRecordDetail.TR_ID = dataGridViewTaskInOutForApproval[2, j].Value.ToString();
                    mTaskRecordDetail.PCP_ID = dataGridViewTaskInOutForApproval[3, j].Value.ToString();
                    mTaskRecordDetail.TR_Shipment = dataGridViewTaskInOutForApproval[4, j].Value.ToString();
                    mTaskRecordDetail.TR_File = dataGridViewTaskInOutForApproval[5, j].Value.ToString();
                    mTaskRecordDetail.TR_FileSize = int.Parse(dataGridViewTaskInOutForApproval[6, j].Value.ToString());
                    mTaskRecordDetail.Task_ID = dataGridViewTaskInOutForApproval[8, j].Value.ToString();
                    mTaskRecordDetail.TR_Status = int.Parse(dataGridViewTaskInOutForApproval[9, j].Value.ToString());
                    mTaskRecordDetail.TR_Apporval = 3;

                    //Initialize PCPDetail
                    mPCPDetail.PCP_ID = dataGridViewTaskInOutForApproval[3, j].Value.ToString();
                    mPCPDetail.PCP_File = dataGridViewTaskInOutForApproval[5, j].Value.ToString();
                    mPCPDetail.Task_ID = dataGridViewTaskInOutForApproval[8, j].Value.ToString();
                    mPCPDetail.PCP_Project = mTaskRecordDetailMng.GetProjectNameByPCPID_TaskIDAndPCPFile(mPCPDetail.PCP_ID, mPCPDetail.Task_ID, mPCPDetail.PCP_File);
                    mPCPDetail.PC_ProcessCode = mTaskRecordDetailMng.GetProcessCodeNameByPCPID_TaskIDAndPCPFile(mPCPDetail.PCP_ID, mPCPDetail.Task_ID, mPCPDetail.PCP_File);

                    mPCPDetail.PCP_Status = 2; //If Done

                    if (Convert.ToBoolean(dataGridViewTaskInOutForApproval[0, j].Value) == true)
                    {

                        //Check first Done task is available for selected record
                        if (mTaskRecordDetail.TR_Status == 2 && mTaskRecordDetailMng.GetCountForTaskDoneFirlterByPCPAndTaskCode(mPCPDetail.PCP_ID, mPCPDetail.Task_ID, mPCPDetail.PCP_File) == 1)
                        {

                            outputStrDelete += ("--------- " + mPCPDetail.PCP_File + " ---------\n" + "Job Code: " + mPCPDetail.PCP_ID + "\nTask ID: " + mPCPDetail.Task_ID + "\n-----------------------------------\n" + " , ").ToString();
                            continue;

                        }
                        else
                        {
                            //Only Done without pending records
                            if (mTaskRecordDetail.TR_Status == 3)
                            {
                                //Task Record Detail Delete
                                if (mTaskRecordDetailMng.DeleteTaskRecordDetail(mTaskRecordDetail) > 0)
                                {
                                    //Delete Header
                                    mTaskRecordHeaderMng.DeleteTaskRecordHeader(mTaskRecordHeader);


                                    ////PCP Pending
                                    //mPCPDetail.PCP_Status = 0; //Fresh
                                    mPCPDetailMng.UpdatePCPDetailToPendingFromDisapproval(mPCPDetail);
                                }
                            }

                            //Pending with mutiple records
                            else if (mTaskRecordDetail.TR_Status == 2 && mTaskRecordDetailMng.GetCountForTaskPendingFirlterByPCPAndTaskCode(mPCPDetail.PCP_ID, mPCPDetail.Task_ID, mPCPDetail.PCP_File) > 1)
                            {
                                //Task Record Disapproved
                                if (mTaskRecordDetailMng.DeleteTaskRecordDetail(mTaskRecordDetail) > 0)
                                {
                                    //PCP Pending
                                    mPCPDetailMng.UpdatePCPDetailToPendingFromDisapproval(mPCPDetail);
                                }
                            }


                            //Only pending record
                            else if (mTaskRecordDetail.TR_Status == 2 && mTaskRecordDetailMng.GetCountForTaskPendingFirlterByPCPAndTaskCode(mPCPDetail.PCP_ID, mPCPDetail.Task_ID, mPCPDetail.PCP_File) == 1)
                            {
                                mPCPDetail.PCP_Status = 0; //PCP Detail to Task Fresh

                                //Task Record Disapproved
                                if (mTaskRecordDetailMng.DeleteTaskRecordDetail(mTaskRecordDetail) > 0)
                                {
                                    //Delete Header
                                    mTaskRecordHeaderMng.DeleteTaskRecordHeader(mTaskRecordHeader);

                                    //PCP Fresh
                                    mPCPDetailMng.UpdatePCPDetailToPendingFromDisapproval(mPCPDetail);
                                }
                            }
                        }
                    }
                }

                //Check ouput string status
                if (outputStrDelete != "")
                {

                    string moutputDelete = "Please delete status done record(s) first.," + outputStrDelete;

                    frm_ExistDisapprovalMessage ExistFrom = new frm_ExistDisapprovalMessage(moutputDelete);
                    RefreshData();
                    ClearFields();
                    ExistFrom.Show();
                }
                else
                {
                    //Show Completed Message
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been deleted!", "Record(s) Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                    ClearFields();

                }

            }
        }

        //History button
        private void btnHistory_Click(object sender, EventArgs e)
        {

            String uPIC = lblPIC.Text;
            String uMUID = lblMUID.Text;

            frm_TaskInOutApprovalHistory myForm = frm_TaskInOutApprovalHistory.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;            
            frm_ApprovalTaskInOut form1 = (frm_ApprovalTaskInOut)Application.OpenForms["frm_ApprovalTaskInOut"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();
            

        }

        //Modify FileSize
        private void btnModify_Click(object sender, EventArgs e)
        {
            //Check if there any checkbox checked/unchecked in cloumn 0
            for (int j = 0; j < dataGridViewTaskInOutForApproval.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewTaskInOutForApproval[0, j].Value) == false)
                {

                    if ((dataGridViewTaskInOutForApproval.RowCount - 1) == j)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select a record first.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                else
                {
                    break;
                }
            }

            //Check if there any checkbox checked/unchecked in cloumn more than 1
            List<DataGridViewRow> selectedRows = (from row in dataGridViewTaskInOutForApproval.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells[0].Value) == true
                                                  select row).ToList();

            foreach (DataGridViewRow row in selectedRows)
            {
                if (selectedRows.Count > 1)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nMultiple selection cannot be modified at once. Please select one record.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Pass modify data to Modify form as parameters
            for (int j = 0; j < dataGridViewTaskInOutForApproval.RowCount; j++)
            {

                if (Convert.ToBoolean(dataGridViewTaskInOutForApproval[0, j].Value) == true)
                {
                    //Initialize PCP User Detail                
                    String mMID = lblMUID.Text;
                    String mTempPIC = lblPIC.Text;
                    String mPIC = new ManagerDetailMng(this.conn).GetManagerNameByUID(lblMUID.Text);
                    String mUID = dataGridViewTaskInOutForApproval[1, j].Value.ToString();
                    String mTRID = dataGridViewTaskInOutForApproval[2, j].Value.ToString();
                    String mJOBCode = dataGridViewTaskInOutForApproval[3, j].Value.ToString();
                    String mShipment = dataGridViewTaskInOutForApproval[4, j].Value.ToString();
                    String mFileName = dataGridViewTaskInOutForApproval[5, j].Value.ToString();
                    int mOutput = int.Parse(dataGridViewTaskInOutForApproval[6, j].Value.ToString());
                    String mUOM = dataGridViewTaskInOutForApproval[7, j].Value.ToString();
                    String mTask = dataGridViewTaskInOutForApproval[8, j].Value.ToString();
                    int mJobStatus = int.Parse(dataGridViewTaskInOutForApproval[9, j].Value.ToString());
                    DateTime mTaskIn = DateTime.Parse(dataGridViewTaskInOutForApproval[10, j].Value.ToString());
                    DateTime mTaskOut = DateTime.Parse(dataGridViewTaskInOutForApproval[11, j].Value.ToString());
                    float mTaskHours = float.Parse(dataGridViewTaskInOutForApproval[12, j].Value.ToString());                    
                    int mQuota = new TaskRecordDetailMng(this.conn).GetQuotaSize(mTask, mJOBCode, mUID);

                    if(new TaskRecordDetailMng(this.conn).IsModifiedTaskDoneRecordAvailableForTaskRecord(mUID, mTask, mJOBCode))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPending approval modified task is available for this record. Please get PIC approval before modify this record.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    frm_TaskInOutFileSizeModify form = frm_TaskInOutFileSizeModify.GetInstance(mMID, mTempPIC, mPIC, mUID, mTRID, mJOBCode, mShipment, mFileName, mOutput, mUOM, mTask, mJobStatus, mTaskIn, mTaskOut, mTaskHours, mQuota);

                    if (!form.Visible)
                    {
                        form.Show();
                    }
                    else
                    {
                        form.BringToFront();
                    }
                }

            }
        }
    }
}
