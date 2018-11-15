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
    public partial class frm_BulkImport_Quota : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_BulkImport_Quota _instance;
        public static frm_BulkImport_Quota GetInstance(string uUID)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUID = uUID;


                _instance = new frm_BulkImport_Quota(mUID);

            }
            return _instance;

        }

        public frm_BulkImport_Quota(string uUID)
        {
            InitializeComponent();

            lblUID.Text = uUID;

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }


        //Import button
        private void btnImportSheet_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"Desktop\";
            openFileDialog1.Title = "Import New Quota Sheet";

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

                            dataGridViewImportQuota.DataSource = dt;
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

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
            this.Close();
        }

        //Save button
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridViewImportQuota.Rows.Count == 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nThere is no data to import! \nPlease import provided excel template.", "Empty Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnImportSheet.Focus();
                }

                //DialogBox for confirmation
                DialogResult result;
                result = MetroFramework.MetroMessageBox.Show(this, "Do you want to register quota at once?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //Text for temp prompt     
                string outputStr = String.Empty;
                string coutputStr = String.Empty;                
                string outputStrUTaskCode = String.Empty;
                string outputStrUDescription = String.Empty;
                string outputStrUUOM = String.Empty;
                string outputStrUQuota = String.Empty;                
                

                if (dataGridViewImportQuota.DataSource != null)
                {

                    if (result == DialogResult.Yes)
                    {
                        
                        //Loop until total Shipment File Count Registerd into the ShipmentDetails Tabele
                        for (int i = 0; i < dataGridViewImportQuota.Rows.Count; i++)
                        {
                            //datageid view
                            string cProjectName = dataGridViewImportQuota.Rows[i].Cells[0].Value.ToString();
                            string cProcessCode = dataGridViewImportQuota.Rows[i].Cells[1].Value.ToString();

                            string SplitProjectName = cProjectName.Substring(0, 3);
                            string SplitProcessCode = cProcessCode.Substring(3, 2);

                            string ChunkCode = SplitProjectName + "_" + SplitProcessCode;

                            //Check Count of Exists Task IDs
                            String uCount = new TaskHeaderMng(this.conn).TaskCodeExisltMAXCount(ChunkCode, cProcessCode, cProjectName);

                            if (!String.IsNullOrEmpty(cProjectName))
                            {
                                //Create Object
                                TaskHeader mTaskHeader = new TaskHeader();
                                TaskDetail mTaskDetail = new TaskDetail();
                                TaskHeaderMng mTaskHeaderMng = new TaskHeaderMng(this.conn);
                                TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);

                                //If Task Code ID not exists
                                if (String.IsNullOrEmpty(uCount))
                                {
                                    String mTask_Code = ChunkCode + 1;
                                    String mProject = cProjectName;
                                    String mProcessCode = cProcessCode;
                                    String mDescription = dataGridViewImportQuota.Rows[i].Cells[2].Value.ToString();
                                    String mUOM = dataGridViewImportQuota.Rows[i].Cells[3].Value.ToString();
                                    String mQuota = dataGridViewImportQuota.Rows[i].Cells[4].Value.ToString();
                                    String sPIC = lblUID.Text;

                                    if (new ProjectDetailMng(this.conn).ProjectDetailIsExist(mProject, sPIC) == false)
                                    {
                                        outputStr += (mProject + " , ").ToString();
                                        continue;
                                    }
                                    if (new ProcessCodeHeaderMng(this.conn).ProcessCodeIsExist2(mProcessCode) == false)
                                    {
                                        coutputStr += (mProcessCode + " , ").ToString();
                                        continue;

                                    }

                                    if (new TaskDetailMng(this.conn).TaskCodeDetailIsExixts(mDescription, mUOM, mQuota, mProcessCode))
                                    {
                                        outputStrUTaskCode += (mDescription + "/" + mUOM + "/" + mQuota + "/" + mProcessCode + " , ").ToString();
                                        continue;
                                    }

                                    if (String.IsNullOrEmpty(mDescription))
                                    {
                                        outputStrUDescription += (mProject + "-" + mProcessCode + " , ").ToString();
                                        continue;
                                    }

                                    if (String.IsNullOrEmpty(mUOM))
                                    {
                                        outputStrUUOM += (mProject + "-" + mProcessCode + " , ").ToString();
                                        continue;

                                    }
                                    if (String.IsNullOrEmpty(mQuota) || mQuota == "0")
                                    {
                                        outputStrUQuota += (mProject + "-" + mProcessCode + " , ").ToString();
                                        continue;

                                    }

                                    //Assign ProcessCodeHeader Interface data
                                    //Header
                                    mTaskHeader.Task_ID = mTask_Code;
                                    mTaskHeader.PIC_Project = mProject;
                                    mTaskHeader.PC_ProcessCode = mProcessCode;

                                    //Detail
                                    mTaskDetail.Task_ID = mTask_Code;
                                    mTaskDetail.Task_Description = mDescription;
                                    mTaskDetail.Task_UOM = mUOM;
                                    mTaskDetail.Task_Quota = int.Parse(mQuota);
                                    mTaskDetail.PC_ProcessCode = mProcessCode;
                                    mTaskDetail.PIC_Project = mProject;

                                    if (mTaskHeaderMng.AddTaskCode(mTaskHeader) > 0)
                                    {
                                        if (mTaskDetailMng.AddTaskDetail(mTaskDetail) > 0)
                                        {

                                        }

                                    }

                                }
                                else
                                {

                                    String mTask_Code = ChunkCode + (int.Parse(uCount) + 1);
                                    String mProject = cProjectName;
                                    String mProcessCode = cProcessCode;
                                    String mDescription = dataGridViewImportQuota.Rows[i].Cells[2].Value.ToString();
                                    String mUOM = dataGridViewImportQuota.Rows[i].Cells[3].Value.ToString();
                                    String mQuota = dataGridViewImportQuota.Rows[i].Cells[4].Value.ToString();
                                    String sPIC = lblUID.Text;

                                    if (new ProjectDetailMng(this.conn).ProjectDetailIsExist(mProject, sPIC) == false)
                                    {
                                        outputStr += (mProject + " , ").ToString();
                                        continue;
                                    }
                                    if (new ProcessCodeHeaderMng(this.conn).ProcessCodeIsExist2(mProcessCode) == false)
                                    {
                                        coutputStr += (mProcessCode + " , ").ToString();
                                        continue;

                                    }

                                    if (new TaskDetailMng(this.conn).TaskCodeDetailIsExixts(mDescription, mUOM, mQuota, mProcessCode))
                                    {
                                        outputStrUTaskCode += (mDescription + "/" + mUOM + "/" + mQuota + "/" + mProcessCode + " , ").ToString();
                                        continue;
                                    }

                                    if (String.IsNullOrEmpty(mDescription))
                                    {
                                        outputStrUDescription += (mProject + "-" + mProcessCode + " , ").ToString();
                                        continue;
                                    }

                                    if (String.IsNullOrEmpty(mUOM))
                                    {
                                        outputStrUUOM += (mProject + "-" + mProcessCode + " , ").ToString();
                                        continue;

                                    }
                                    if (String.IsNullOrEmpty(mQuota) || mQuota == "0")
                                    {
                                        outputStrUQuota += (mProject + "-" + mProcessCode + " , ").ToString();
                                        continue;

                                    }

                                    //Header
                                    mTaskHeader.Task_ID = mTask_Code;
                                    mTaskHeader.PIC_Project = mProject;
                                    mTaskHeader.PC_ProcessCode = mProcessCode;

                                    //Detail
                                    mTaskDetail.Task_ID = mTask_Code;
                                    mTaskDetail.Task_Description = mDescription;
                                    mTaskDetail.Task_UOM = mUOM;
                                    mTaskDetail.Task_Quota = int.Parse(mQuota);
                                    mTaskDetail.PC_ProcessCode = mProcessCode;
                                    mTaskDetail.PIC_Project = mProject;


                                    if (mTaskHeaderMng.AddTaskCode(mTaskHeader) > 0)
                                    {
                                        if (mTaskDetailMng.AddTaskDetail(mTaskDetail) > 0)
                                        {

                                        }

                                    }
                                }
                            }

                        }

                        //Check ouput string status
                        if (outputStr != "" || coutputStr != "" || outputStrUTaskCode != "" || outputStrUDescription != "" || outputStrUUOM != "" || outputStrUQuota != "")
                        {

                            //MessageBox.Show("Precess Complete! \nSome Item Codes are already exist in the Project Quota.\n\n" + outputStr, "Project Quota Registerd", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            string moutputProject = "Invalid Project Name(s) Found..!," + outputStr;
                            string moutputProcess = "Invalid Process Code(s) Found..!," + coutputStr;
                            string moutputTaskCode = "Task Code Already Exist For Following Details..!," + outputStrUTaskCode;
                            string moutputDescritopn = "Description Cannot Be Empty..!," + outputStrUDescription;
                            string moutputUOM = "UOM Cannot Be Empty..!," + outputStrUUOM;
                            string moutputQuota = "Quota Cannot Be Empty..!," + outputStrUQuota;

                            frm_ExistBulkQuotaMessage ExistFrom = new frm_ExistBulkQuotaMessage(moutputProject, moutputProcess, moutputTaskCode, moutputDescritopn, moutputUOM, moutputQuota);
                            ExistFrom.Show();
                            this.Close();
                        }
                        else
                        {
                             
                            MetroFramework.MetroMessageBox.Show(this, "\nQuota bulk successfully imported..!", "Quota Imported!", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                            Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
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

                    MetroFramework.MetroMessageBox.Show(this, "\nThere is no data to import! \nPlease import provided excel template.", "Empty Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnImportSheet.Focus();
                }

            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233086)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nUnregistered project name found. Please check your template again.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Message: " + ex.HResult, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
