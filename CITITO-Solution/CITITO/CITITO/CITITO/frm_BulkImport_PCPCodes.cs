using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Configuration;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;
using ClosedXML.Excel;

namespace CITITO
{
    public partial class frm_BulkImport_PCPCodes : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_BulkImport_PCPCodes _instance;
        public static frm_BulkImport_PCPCodes GetInstance(string uUID)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUID = uUID;              


                _instance = new frm_BulkImport_PCPCodes(mUID);

            }
            return _instance;

        }

        public frm_BulkImport_PCPCodes(string uUID)
        {
            InitializeComponent();

            lblUID.Text = uUID;

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        /*CITITO Server Time*/
        public DateTime ServerDateTime()
        {
            ServerTime mServerTime = new ServerTime(this.conn);
            DateTime sDate = mServerTime.getServerTime();
            return sDate;
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_DCD"].BringToFront();
            this.Close();
        }

        //Close button
        private void pboxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //Minimize button
        private void pboxMinimize_Click(object sender, EventArgs e)
        {
            //Minimize Window
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// DEGUB: if Book Count file size update as 1
        /// DEBUG: Last record nnumber issue fixed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            //DialogBox for confirmation
            DialogResult result;
            result = MetroFramework.MetroMessageBox.Show(this, "Do you want to import PCP Codes at once?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            try
            {
                //Text for temp prompt            
                string outputStr = String.Empty;
                string coutputStr = String.Empty;
                string toutputStr = String.Empty;
                string toutputStr_ProcessCode = String.Empty;

                if (dataGridViewImportPCP.DataSource != null)
                {

                    if (result == DialogResult.Yes)
                    {
                        //Loop through check items
                        //bool isAnySelected = checkedListBoxTaskCode.CheckedIndices.Count > 0;

                        //DateTime
                        DateTime localDate = ServerDateTime();


                        //Loop until total Shipment File Count Registerd into the ShipmentDetails Tabele
                        for (int i = 0; i < dataGridViewImportPCP.Rows.Count; i++)
                        {

                            //Create Object From PCPDetail
                            PCPDetail mPCPDetail = new PCPDetail();
                            PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

                            //Create Object From PCPHeader
                            PCPHeader mPCPHeader = new PCPHeader();
                            PCPHeaderMng mPCPHeaderMng = new PCPHeaderMng(this.conn);
                            TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);

                            //Task Code from List                           
                            string sProjectName = dataGridViewImportPCP.Rows[i].Cells[0].Value.ToString();
                            string sShipment = dataGridViewImportPCP.Rows[i].Cells[1].Value.ToString();
                            string sFile = dataGridViewImportPCP.Rows[i].Cells[2].Value.ToString();
                            string tProcessCode = dataGridViewImportPCP.Rows[i].Cells[3].Value.ToString();
                            int sFileSize = int.Parse(dataGridViewImportPCP.Rows[i].Cells[4].Value.ToString());
                            string sPIC = new ManagerDetailMng(this.conn).GetManagerNameByUID(lblUID.Text);
                            int cLastRowCount = (mPCPDetailMng.GetLastRowCount(sProjectName));
                            int cNewInt = (cLastRowCount + 1);

                            if (!String.IsNullOrEmpty(sProjectName))
                            {
                                if (new ProjectDetailMng(this.conn).ProjectDetailIsExist(sProjectName, sPIC) == false)
                                {
                                    outputStr += (sProjectName + " , ").ToString();
                                    continue;
                                }
                                if (new ProcessCodeHeaderMng(this.conn).ProcessCodeIsExist2(tProcessCode) == false)
                                {
                                    coutputStr += (tProcessCode + " , ").ToString();
                                    continue;

                                }

                                else
                                {
                                    for (int j = 5; j < dataGridViewImportPCP.Columns.Count; j++)
                                    {
                                        if (!String.IsNullOrEmpty(dataGridViewImportPCP.Rows[i].Cells[j].Value.ToString()))
                                        {

                                            string uTaskCode = dataGridViewImportPCP.Rows[i].Cells[j].Value.ToString();

                                            //get UOM and Quota form Task Code
                                            string cUOM = mTaskDetailMng.GetUOMFromTaskCode(uTaskCode, tProcessCode);
                                            int cQuota = mTaskDetailMng.GetQuotaFromTaskCode(uTaskCode, tProcessCode);

                                            string cProject = uTaskCode.Substring(0, 3);
                                            string cMonthYear = ServerDateTime().ToString("MMyy");
                                            string cProcessCode = uTaskCode.Substring(4, 2);
                                            string cPCPCode = cProject + cMonthYear + cProcessCode + cNewInt;
                                            string cPCPCode_Same = mPCPDetailMng.GetPCPCodeByShipmentAndFileName_TaskInOut(sShipment, sFile);

                                            bool cPCPCode_Same_ProcessCode = mPCPDetailMng.GetPCPCodeByShipmentAndFileName(sShipment, sFile, tProcessCode);



                                            //Validate Task Code
                                            if (!new TaskHeaderMng(this.conn).TaskCodeIsExist(uTaskCode, tProcessCode, sProjectName))
                                            {
                                                MetroFramework.MetroMessageBox.Show(this, "\nUnregisterd task code [" + uTaskCode + "] found. Please check again.", "Task Code Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }

                                            //Validate Header Already Exist && Same Process Code
                                            if (new PCPHeaderMng(this.conn).IsExistHeader(cPCPCode_Same))
                                            {

                                                if (cPCPCode_Same_ProcessCode)
                                                {
                                                    //** DEBUG 2018-02-05 ** else if part **//

                                                    //Validate Detail Not Exist
                                                    if (!mPCPDetailMng.IsExistPCPRecord(uTaskCode, tProcessCode, sProjectName, sFile, sFileSize, cUOM, sShipment) || !mPCPDetailMng.IsExistHearedRecord(tProcessCode, sShipment, sFile, uTaskCode))
                                                    {
                                                        //Assign User Interface data to User Object
                                                        mPCPDetail.PCP_ID = cPCPCode_Same;
                                                        mPCPDetail.Task_ID = uTaskCode;
                                                        mPCPDetail.PCP_Project = sProjectName;
                                                        mPCPDetail.Task_UOM = cUOM;
                                                        mPCPDetail.Task_Quota = cQuota;
                                                        mPCPDetail.PC_ProcessCode = tProcessCode;
                                                        mPCPDetail.PCP_StartDate = localDate;
                                                        mPCPDetail.PCP_Status = 0; /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                                                                                   //mPCPDetail.PCP_EndDate = "NULL";
                                                        mPCPDetail.PCP_CreatorUID = lblUID.Text;
                                                        mPCPDetail.PCP_File = sFile;
                                                        //Update File to 1 if UOM is Book Count
                                                        if (cUOM == "Book Count")
                                                        {
                                                            mPCPDetail.PCP_FileSize = 1;
                                                        }
                                                        else
                                                        {
                                                            mPCPDetail.PCP_FileSize = sFileSize;
                                                        }

                                                        mPCPDetailMng.AddPCPDetail(mPCPDetail);

                                                    }
                                                    else
                                                    {
                                                        toutputStr += (uTaskCode + " - [" + sFile + " on Shipment " + sShipment + "]" + " , ").ToString();
                                                        //continue;

                                                    }
                                                }
                                                else
                                                {
                                                    toutputStr_ProcessCode += (tProcessCode + " - [" + sFile + " on Shipment " + sShipment + "]" + " , ").ToString();
                                                        continue;
                                                }

                                            }
                                            else if (mPCPDetailMng.IsExistPCPRecord(uTaskCode, tProcessCode, sProjectName, sFile, sFileSize, cUOM, sShipment) || mPCPDetailMng.IsExistHearedRecord(tProcessCode, sShipment, sFile, uTaskCode))
                                            {
                                                toutputStr += (uTaskCode + " - ["+ sFile+" on Shipment "+ sShipment + "]" + " , ").ToString();
                                                //continue;
                                            }
                                            else
                                            {

                                                //Initialize PCPHeader
                                                mPCPHeader.PCP_ID = cPCPCode;
                                                mPCPHeader.PCP_Shipment = sShipment;
                                                mPCPHeader.PC_ProcessCode = tProcessCode;
                                                //mPCPHeader.Task_ID = uTaskCode;


                                                //Assign User Interface data to User Object
                                                mPCPDetail.PCP_ID = cPCPCode;
                                                mPCPDetail.Task_ID = uTaskCode;
                                                mPCPDetail.PCP_Project = sProjectName;
                                                mPCPDetail.Task_UOM = cUOM;
                                                mPCPDetail.Task_Quota = cQuota;
                                                mPCPDetail.PC_ProcessCode = tProcessCode;
                                                mPCPDetail.PCP_StartDate = localDate;
                                                mPCPDetail.PCP_Status = 0; /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                                                                           //mPCPDetail.PCP_EndDate = "NULL";
                                                mPCPDetail.PCP_CreatorUID = lblUID.Text;
                                                mPCPDetail.PCP_File = sFile;

                                                //Update File to 1 if UOM is Book Count
                                                if (cUOM == "Book Count")
                                                {
                                                    mPCPDetail.PCP_FileSize = 1;
                                                }
                                                else
                                                {
                                                    mPCPDetail.PCP_FileSize = sFileSize;
                                                }


                                                if (mPCPHeaderMng.AddPCPHeader(mPCPHeader) > 0)
                                                {
                                                    mPCPDetailMng.AddPCPDetail(mPCPDetail);

                                                }

                                            }
                                            
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                            }
                        }

                        //Check ouput string status
                        if (outputStr != "" || coutputStr != "" || toutputStr != "" || toutputStr_ProcessCode != "")
                        {

                            //MessageBox.Show("Precess Complete! \nSome Item Codes are already exist in the Project Quota.\n\n" + outputStr, "Project Quota Registerd", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            string moutput = "Invalid Project Name(s) Found..!," + outputStr;
                            string mcoutputStr = "Invalid Process Code(s) Found..!," + coutputStr;
                            string mtoutputStr = "Task Code(s) Already Exist..!," + toutputStr;
                            string mtoutputStr_ProcessCode = "Already Registered File(s) Found with Different Process Codes..!," + toutputStr_ProcessCode;


                            frm_ExistBulkPCPMessage ExistFrom = new frm_ExistBulkPCPMessage(moutput, mcoutputStr, mtoutputStr, mtoutputStr_ProcessCode);
                            ExistFrom.Show();
                            this.Close();
                        }
                        else
                        {

                            MetroFramework.MetroMessageBox.Show(this, "Bulk PCP Code successfully imported..!", "PCP imported!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.OpenForms["frm_DCD"].BringToFront();
                            this.Close();

                        }

                    }
                    else
                    {
                        //.... Dialog No
                    }

                }
                else
                {

                    MetroFramework.MetroMessageBox.Show(this, "There is no PCP data to import! \nPlease import provided excel template.", "Empty PCP Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnImportSheet.Focus();
                }

            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233086)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nUnregistered process code found. Please check your template again.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //Import button
        private void btnImportSheet_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"Desktop\";
            openFileDialog1.Title = "Import New PCP Sheet";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "xls";
            openFileDialog1.Filter = "Excel files (*.xls)|*.xlsx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = false;


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string filePath = openFileDialog1.FileName;
                string extension = Path.GetExtension(filePath);
                string fNameOnly = Path.GetFileNameWithoutExtension(filePath);

                try
                {
                    using (XLWorkbook workBook = new XLWorkbook(filePath))
                    {
                        //Read the first Sheet from Excel file.
                        IXLWorksheet workSheet = workBook.Worksheet(1);

                        //Create a new DataTable.
                        DataTable dt = new DataTable();

                        //Loop through the Worksheet rows.
                        bool firstRow = true;
                        foreach (IXLRow row in workSheet.Rows())
                        {
                            //Use the first row to add columns to DataTable.
                            if (firstRow)
                            {
                                foreach (IXLCell cell in row.Cells())
                                {
                                    dt.Columns.Add(cell.Value.ToString());
                                }
                                firstRow = false;
                            }
                            else
                            {
                                //Add rows to DataTable.
                                dt.Rows.Add();
                                int i = 0;
                                foreach (IXLCell cell in row.Cells())
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                    i++;

                                }

                            }

                            dataGridViewImportPCP.DataSource = dt;
                            //dataGridViewImportUsers.DataBind();
                        }

                    }
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "File is already opened by another user.", "Running Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
        }

        //Start >> frm_BulkImport_PCPCodes enable move using mouse left down
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void frm_BulkImport_PCPCodes_MouseDown(object sender, MouseEventArgs e)
        {
            //Form movement

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void frm_BulkImport_PCPCodes_Load(object sender, EventArgs e)
        {

        }
        //End >> frm_BulkImport_PCPCodes enable move using mouse left down
    }
}
