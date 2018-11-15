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
    public partial class frm_IDLETask : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_IDLETask _instance;
        public static frm_IDLETask GetInstance(string uUID, string uMUID, string uMName, DateTime uLogTime)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUID = uUID;
                String mMUID = uMUID;
                String mName = uMName;
                DateTime mLogTime = uLogTime;

                _instance = new frm_IDLETask(mUID, mMUID, mName, uLogTime);

            }
            return _instance;

        }

        /*CITITO Server Time*/
        public DateTime ServerDateTime()
        {
            ServerTime mServerTime = new ServerTime(this.conn);
            DateTime sDate = mServerTime.getServerTime();
            return sDate;
        }

        public frm_IDLETask(string uUID, string uMUID, string uMName, DateTime uLogTime)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblUIDToFill.Text = uUID;
            lblManagerUIDToFill.Text = uMUID;
            lblManagerNameToFill.Text = uMName;
            lblTimeToFill.Text = uLogTime.ToString();

        }
        private void frm_IDLETask_Load(object sender, EventArgs e)
        {
            //Refresh data fields
            RefreshData();

            //Clear All Fields when Load
            ClearFields();

            // Set the Format type and the CustomFormat string.
            dateTimePickerTaskIn.Format = DateTimePickerFormat.Custom;
            dateTimePickerTaskIn.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            dateTimePickerTaskIn.ShowUpDown = false;




            dateTimePickerTaskOut.Format = DateTimePickerFormat.Custom;
            dateTimePickerTaskOut.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            dateTimePickerTaskOut.ShowUpDown = false;
    
        }

        //Refresh Object
        private void RefreshData()
        {
            string uUID = lblUIDToFill.Text;
            string l = lblManagerUIDToFill.Text;
            cmbProject.DataSource = new UserManagementDetailMng(this.conn).ListAllActiveProjectsByUser(uUID);
            cmbReason.DataSource = new IDLEReasonMng(this.conn).GetIdleRreason();
            dataGridViewIDLERecord.DataSource = new IDLEDetailMng(this.conn).GetAllIDLEDetailsByUserUID(uUID);


        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();

            //Clear All Fields when Load
            cmbProject.SelectedIndex = -1;
            cmbReason.SelectedIndex = -1;
            
            cmbReason.Enabled = false;
            txtRemark.Enabled = false;


            dateTimePickerTaskIn.Enabled = false;
            dateTimePickerTaskOut.Enabled = false;
            txtIDLEHours.Enabled = false;
            dateTimePickerTaskIn.Value = ServerDateTime();
            dateTimePickerTaskOut.Value = ServerDateTime();

            txtIDLEHours.Text = "0";
            lblIDLEMessage.Visible = false;
            txtRemark.Text = String.Empty;

        }

        public string Create_IDLE_ID()
        {
            string cIDLEID = "";
            IDLEDetailMng mIDLEDetailMng = new IDLEDetailMng(this.conn);
            string uID = lblUIDToFill.Text;
            int cLastUserRecordNumber = mIDLEDetailMng.GetUserLastRecordCount(uID);
            int cNewInt = (cLastUserRecordNumber + 1);

            //IDLE Code from List part 02
            //string cTaskCode = cmbtaskCode.Text;
            //string cProject = cTaskCode.Substring(0, 3);
            string cIDLE = "IDLE";
            string cMonthYear = ServerDateTime().ToString("ddMMyy");

            cIDLEID = uID + cMonthYear + cIDLE +cNewInt;

            return cIDLEID;

        }

        //Refrest button
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbReason.Enabled = true;
            dateTimePickerTaskIn.Enabled = true;
            dateTimePickerTaskOut.Enabled = true;
            txtRemark.Enabled = true;
        }

        //Exit button
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

        //File task
        private void btnFileTask_Click(object sender, EventArgs e)
        {
            //Validate fields



            if (DateTime.Parse(dateTimePickerTaskIn.Value.AddDays(5).ToShortDateString())<= DateTime.Parse(ServerDateTime().ToShortDateString()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIDLE In time exceeded in 5 days.", "5 Days Exceeded!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerTaskIn.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cmbProject.Text))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject Code cannot be empty.", "Invalid Project Code!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProject.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cmbReason.Text))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nReason cannot be empty.", "Invalid Reason!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbReason.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtIDLEHours.Text) || float.Parse(txtIDLEHours.Text) <= 0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIdle hours cannot be less than zero or empty.", "Invalid Idle Hours!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerTaskOut.Focus();
                return;
            }

            if (lblIDLEMessage.Visible)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease fix the IDLE task in/out error!", "Invalid Idle!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerTaskOut.Focus();
                return;
            }

            //Get user Confirmation
            //DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to apply idle hours?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
                string cIDLEID = Create_IDLE_ID();
                string cUID = lblUIDToFill.Text;
                string cMID = lblManagerUIDToFill.Text;
                string cPID = new ManagerDetailMng(this.conn).GetManagerNameByUID(cMID);

                //Time Calculation
                TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;
                double hours = diff.TotalHours;

                //Current Time
                DateTime mNow = ServerDateTime();

                //Productivity
                //float PrductDivedeByTime = (float.Parse(hours.ToString()) / 9);
                //float mProductivity = (PrductDivedeByTime) * 100;

                //Create Object From IdleUserDetail
                IDLEHeader mIDLEHeader = new IDLEHeader();
                IDLEHeaderMng mIDLEHeaderMng = new IDLEHeaderMng(this.conn);

                IDLEDetail mIDLEDetail = new IDLEDetail();
                IDLEDetailMng mIDLEDetailMng = new IDLEDetailMng(this.conn);

                //Initialize object values

                //Header
                mIDLEHeader.IDLE_ID = cIDLEID;
                mIDLEHeader.IDLE_Project = cmbProject.Text;
                mIDLEHeader.IDLE_UID = cUID;
                mIDLEHeader.IDLE_MID = cMID;
                mIDLEHeader.IDLE_PIC = cPID;

                //Detail
                mIDLEDetail.IDLE_ID = cIDLEID;
                mIDLEDetail.IDLE_InDate = dateTimePickerTaskIn.Value;
                mIDLEDetail.IDLE_OutDate = dateTimePickerTaskOut.Value;
                mIDLEDetail.IDLE_Reason = cmbReason.Text;
                mIDLEDetail.IDLE_UID = cUID;
                mIDLEDetail.IDLE_MID = cMID;
                mIDLEDetail.IDLE_PIC = cPID;
                mIDLEDetail.IDLE_Apporval = 1;  /* 0 - No Status, 1 - Pending , 2 - Approved, 3 - Disapproved */
                //mIDLEDetail.IDLE_ApprovalTime = ServerDateTime();
                mIDLEDetail.IDLE_Hours = float.Parse(hours.ToString());
                mIDLEDetail.IDLE_LogCreateTime = ServerDateTime();
                mIDLEDetail.IDLE_Remark = txtRemark.Text;

                //Tasked-In and If apply future date
                if (mIDLEDetailMng.UserIDLETaskRecordActiveTaskIsExist(mIDLEDetail))
                {

                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou can't apply IDLE for future time while you're Tasked-In.", "IDLE Record Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                //Tasked-In and If overlap tasked in time date
                if (!String.IsNullOrEmpty(mIDLEDetailMng.UserIDLEActiveTaskIsExist(mIDLEDetail)) && DateTime.Parse(mIDLEDetailMng.UserIDLEActiveTaskIsExist(mIDLEDetail).ToString())< mIDLEDetail.IDLE_OutDate)
                {

                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIDLE out time exceed your Tasked-In.", "IDLE Record Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerTaskOut.Focus();
                    return;

                }

                //!Tasked-In and If apply future date
                if (mIDLEDetailMng.UserIDLETaskRecordActiveTaskIsExist(mIDLEDetail)==false && ServerDateTime()<mIDLEDetail.IDLE_InDate)
                {

                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou can't apply IDLE for future time.", "IDLE Record Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerTaskIn.Focus();
                    return;

                }

                //IDLE record overlap Task Record
                if (mIDLEDetailMng.UserIDLETaskRecordIsExist(mIDLEDetail))
                {

                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask record is already exist for this time span! Please check again.", "Task Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (mIDLEDetailMng.UserIDLERecordIsExist(mIDLEDetail, cmbProject.Text))
                {

                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIDLE record is already exist for this time span! Please check again.", "IDLE Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                else
                {
                    if (!mIDLEHeaderMng.IDLERecordHeaderIsExist(cIDLEID, cUID))
                    {
                        if (mIDLEHeaderMng.AddIDLERecordHeader(mIDLEHeader) > 0)
                        {
                            if (mIDLEDetailMng.AddIDLEDetail(mIDLEDetail) > 0)
                            {
                                //Show Completed Message
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nYour IDLE record successfully filed..!", "IDLE Record Filed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshData();
                                ClearFields();
                            }

                        }

                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIDLE Record is already exists!", "IDLE Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            //}
        }

        //DateTime picker change value update
        private void dateTimePickerTaskIn_ValueChanged(object sender, EventArgs e)
        {
            //Time Calculation
            TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;

            double hours = diff.TotalHours;

            txtIDLEHours.Text = Math.Round(hours, 3).ToString();

            if (dateTimePickerTaskIn.Value.ToString("dd/MM/yyyy") != dateTimePickerTaskOut.Value.ToString("dd/MM/yyyy"))
            {

                lblIDLEMessage.Visible = true;
                lblIDLEMessage.Text = "IDLE task in/out should be in same date!";

            }
            else
            {

                lblIDLEMessage.Visible = false;
                lblIDLEMessage.Text = "";
            }
        }

        private void dateTimePickerTaskOut_ValueChanged(object sender, EventArgs e)
        {
            //Time Calculation
            TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;

            double hours = diff.TotalHours;

            txtIDLEHours.Text = Math.Round(hours, 3).ToString();

            if (dateTimePickerTaskIn.Value.ToString("dd/MM/yyyy")!= dateTimePickerTaskOut.Value.ToString("dd/MM/yyyy"))
            {
                
                lblIDLEMessage.Visible = true;
                lblIDLEMessage.Text = "IDLE task in/out should be in same date!";

            }
            else
            {

                lblIDLEMessage.Visible = false;
                lblIDLEMessage.Text = "";
            }
            
        }

        //DateTime picker change value message update
        private void txtIDLEHours_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(txtIDLEHours.Text) <= 0)
                {
                    
                    lblIDLEMessage.Visible=true;
                    lblIDLEMessage.Text = "Your task out time is earlier than task in time. Please correct!";

                }
                else
                {

                    lblIDLEMessage.Visible = false;
                    lblIDLEMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233033)
                {
                    //Skip
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridViewIDLERecord_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (e.ColumnIndex == 6)
            {
                if ((int)e.Value == 0)
                {
                    e.Value = "No Status";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                }
                else if ((int)e.Value == 1)
                {
                    e.Value = "Pending";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");
                }
                else if ((int)e.Value == 2)
                {
                    e.Value = "Approved";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9FEB");
                }
                else if ((int)e.Value == 3)
                {
                    e.Value = "Disapproved";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FD7C66");
                }
            }

            //Round Up
            if (e.ColumnIndex == 5)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("0.###");

            }

        }

        //Export Details
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewIDLERecord.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewIDLERecord.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {
                        if (i == 5)
                        {
                            dt.Rows[dt.Rows.Count - 1][5] = double.Parse(row.Cells[5].Value.ToString()).ToString("0.###");

                        }
                        else if (i == 6)
                        {

                            if ((Int32)row.Cells[6].Value == 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][6] = "No Status";
                            }
                            else if ((Int32)row.Cells[6].Value == 1)
                            {
                                dt.Rows[dt.Rows.Count - 1][6] = "Pending";
                            }
                            else if ((Int32)row.Cells[6].Value == 2)
                            {
                                dt.Rows[dt.Rows.Count - 1][6] = "Approved";
                            }
                            else if ((Int32)row.Cells[6].Value == 3)
                            {
                                dt.Rows[dt.Rows.Count - 1][6] = "Disapproved";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][6] = row.Cells[6].Value.ToString();
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

                //foreach (DataGridViewCell cell in row.Cells)
                //{
                //    try
                //    {
                //        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                //    }
                //    catch (Exception ex)
                //    {
                //        if (ex.HResult == -2147024809)
                //        {
                //            //cell.Value = DateTime.ParseExact(cell.Value.ToString(), "dd MM yyyy hh:mm:ss tt", null);
                //        }

                //    }


                //}
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
                try
                {
                    string fileName = saveFileDialog1.FileName;

                    //Exporting to Excel           

                    if (!System.IO.File.Exists(fileName))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(fileName))
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                var ws = wb.Worksheets.Add(dt, "CITITO_" + lblUIDToFill.Text + "_IDLE Records");
                                ws.Range("F2:F1048576").CellsUsed().SetDataType(XLDataType.Number);

                                ws.Columns().AdjustToContents();
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIDLE Records successfully export to \"" + fileName + "\".", "IDLE Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + lblUIDToFill.Text + "_IDLE Records");
                            ws.Range("F2:F1048576").CellsUsed().SetDataType(XLDataType.Number);

                            ws.Columns().AdjustToContents();
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIDLE records successfully export to \"" + fileName + "\" path.", "IDLE Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        MessageBox.Show("Message: "+ ex.Message, "Exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                


            }
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        //Text Count checker
        private void txtRemark_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRemark.Text))
            {
                lblLength.Text = "(20 characters left)";
            }
            else
            {
                int lenght = (20 - txtRemark.Text.Length);

                if (lenght==1)
                {
                    lblLength.Text = "(01 character left)";
                }
                else if (lenght == 0)
                {
                    lblLength.Text = "(no characters left)";
                }
                else
                {
                    lblLength.Text = "("+ (lenght).ToString("00") + " characters left)";
                }
            }
        }
    }
}
