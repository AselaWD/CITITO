using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;
using System.IO;

namespace CITITO
{
    public partial class frm_DoneByteSizeFile : MetroForm
    {
        SqlConnection conn;


        //Start Pass insatance when form is already opend or not
        private static frm_DoneByteSizeFile _instance;
        public static frm_DoneByteSizeFile GetInstance(string mPCPCode, string mTask_ID, string mTR_File, string mTR_Shipment, int mTR_Status, int mTR_FileSize, DateTime mTR_OutDate, float mTR_Hours, float mTR_Productivity, string mUID, string mMID, string mPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                string PCPCode = mPCPCode;
                string Task_ID = mTask_ID;
                string TR_File = mTR_File;
                string TR_Shipment = mTR_Shipment;
                int TR_Status = mTR_Status; /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                int TR_FileSize = mTR_FileSize;
                DateTime TR_OutDate = mTR_OutDate;
                float TR_Hours = mTR_Hours;
                float TR_Productivity = mTR_Productivity;
                string cUID = mUID;
                string cMUID = mMID;
                string cPIC = mPIC;


                _instance = new frm_DoneByteSizeFile(PCPCode, Task_ID, TR_File, TR_Shipment, TR_Status, TR_FileSize, TR_OutDate, TR_Hours, TR_Productivity, cUID, cMUID, cPIC);

            }
            return _instance;

        }


        public frm_DoneByteSizeFile(string mPCPCode, string mTask_ID, string mTR_File, string mTR_Shipment, int mTR_Status, int mTR_FileSize, DateTime mTR_OutDate, float mTR_Hours, float mTR_Productivity, string mUID, string mMID, string mPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            //Initialize Lables
            lblPCP.Text = mPCPCode;
            lblTask.Text = mTask_ID;
            lblFileName.Text = mTR_File;
            lblShipment.Text= mTR_Shipment;
            lblStatus.Text = mTR_Status.ToString(); /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
            lblFileSize2.Text = mTR_FileSize.ToString();
            lblTaskOut.Text= mTR_OutDate.ToString();
            lblHours.Text= mTR_Hours.ToString();
            lblProductivity.Text= mTR_Productivity.ToString();
            lblUID.Text= mUID;
            lblMID.Text= mMID;
            lblPIC.Text= mPIC;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn); 
            
            string PCPCode = mPCPCode;
            string Task_ID = mTask_ID;
            int TR_FileSize = mTR_FileSize;
            string cUID = mUID;

            //History Calculation
            int PendingHistoryCount = mTaskRecordDetailMng.GetActualFileSizeFroPending(PCPCode, Task_ID, mTR_File);
            dataGridViewTaskInOut.DataSource = mTaskRecordDetailMng.GetAllGetActualFileSizeFroPending(PCPCode, Task_ID, cUID);



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_UserTaskInOut"].BringToFront();
            this.Close();
        }

        private void frm_DoneByteSizeFile_Load(object sender, EventArgs e)
        {
            metroRadioButtonFolder.Checked = false;
            metroRadioButtonFile.Checked = true;
            groupBoxFolder.Visible = false;
            groupBoxFile.Visible = true;
            
        }

        //
        private void dataGridViewTaskInOut_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */

            if (e.ColumnIndex == 6)
            {
                if ((int)e.Value == 0)
                {
                    e.Value = "Fresh";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                }
                else if ((int)e.Value == 1)
                {
                    e.Value = "Hold";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FD7C66");
                }
                else if ((int)e.Value == 2)
                {
                    e.Value = "Pending";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");
                }
                else if ((int)e.Value == 3)
                {
                    e.Value = "Done";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9FEB");
                }
            }

            //Round Up
            if (e.ColumnIndex == 9)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("0.###");

            }

            if (e.ColumnIndex == 13)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("0.###");

            }
        }


        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPath.Text = String.Empty;
            txtSubTotal.Text = String.Empty;
        }

        //Task Out button
        private void btnTaskOut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubTotal.Text))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nBytesize is empty. Please select a different file.", "Invalid File!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnBrowse.Focus();
                return;
            }


            //Get user Confirmation
            DialogResult resultb = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to task out with selected file size?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultb == DialogResult.Yes)
            {
                string PCPCode = lblPCP.Text;
                string Task_ID = lblTask.Text;
                string TR_File = lblFileName.Text;
                string TR_Shipment = lblShipment.Text;
                int TR_Status = int.Parse(lblStatus.Text); /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                int TR_FileSize = int.Parse(lblFileSize2.Text);
                DateTime TR_OutDate = DateTime.Parse(lblTaskOut.Text);
                float TR_Hours = float.Parse(lblHours.Text);
                float TR_Productivity = float.Parse(lblProductivity.Text);
                string cUID = lblUID.Text;
                string cMUID = lblMID.Text;
                string cPIC = lblPIC.Text;

                int cPCPStatus = 0;
                int cTotalFile = int.Parse(txtSubTotal.Text);

                string uUID = cUID;
                string mMUID = cMUID;

                //Object Create
                TaskRecordHeader mTaskRecordHeader = new TaskRecordHeader();
                TaskRecordHeaderMng mTaskRecordHeaderMng = new TaskRecordHeaderMng(this.conn);

                TaskRecordDetail mTaskRecordDetail = new TaskRecordDetail();
                TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

                TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);

                PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

                //Initialize Task Record
                mTaskRecordDetail.TR_File = TR_File;
                mTaskRecordDetail.TR_Shipment = TR_Shipment;
                mTaskRecordDetail.Task_ID = Task_ID;

                mTaskRecordDetail.TR_Status = 3;/* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                cPCPStatus = 3;

                mTaskRecordDetail.TR_FileSize = int.Parse(txtSubTotal.Text.ToString());
                mTaskRecordDetail.TR_OutDate = TR_OutDate;
                mTaskRecordDetail.TR_Apporval = 1;



                //Time Calcuation for Done Record
                float PendingHistoryHoursCount = mTaskRecordDetailMng.GetActualHoursCountForPending(PCPCode, Task_ID, TR_File);
                DateTime FisrtPendingHistoryTaskIn = mTaskRecordDetailMng.GetActualTaskInForPending(PCPCode, Task_ID, TR_File);
                DataTable mTaskrecord = new TaskRecordDetailMng(this.conn).GetTaskedInRecordByUser(uUID);

                //Time Calculation
                double hours = TR_Hours + PendingHistoryHoursCount;

                mTaskRecordDetail.TR_Hours = float.Parse(hours.ToString());


                //Productivity Calculate
                int QuotaSize = mTaskRecordDetailMng.GetQuotaSize(Task_ID, PCPCode, uUID);

                float PrductDivedeByQuota = float.Parse(txtSubTotal.Text.ToString()) / QuotaSize;
                float PrductDivedeByTime = (9 / float.Parse(hours.ToString()));

                float mProductivity = (PrductDivedeByQuota * PrductDivedeByTime) * 100;

                mTaskRecordDetail.TR_Productivity = mProductivity;

                //Actual TaskIn
                if (FisrtPendingHistoryTaskIn == DateTime.Parse("1/1/1753 00:00:00 AM") || FisrtPendingHistoryTaskIn== null)
                {
                    mTaskRecordDetail.TR_InDate =  DateTime.Parse(mTaskrecord.Rows[0][5].ToString());
                }
                else
                {
                    mTaskRecordDetail.TR_InDate = FisrtPendingHistoryTaskIn;
                }
                

                //Is task record Exist
                if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(Task_ID, PCPCode, uUID))
                {
                    if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut_ActualTaskIn(mTaskRecordDetail) > 0)
                    {

                        mPCPDetailMng.UpdatePCPDetailToPendingByteSize(PCPCode, Task_ID, cPCPStatus, cTotalFile); //Update PCP status with user task status

                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + Task_ID, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        //frm_TaskInOut f2 = new frm_TaskInOut(uUID, mMUID, mMUID, TR_OutDate);
                        //f2.fo = -1;                        

                        Application.OpenForms["frm_UserTaskInOut"].BringToFront();
                        this.Close();
                    }
                }

            }
            else
            {
                return;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();



            openFileDialog1.InitialDirectory = @"Desktop";
            openFileDialog1.Title = "Browse Your File";
            

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = false;



            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {

                txtPath.Text = openFileDialog1.FileName;

                var size = new FileInfo(openFileDialog1.FileName).Length;

                if (size==0)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nBytesize is empty. Please select a different file.", "Invalid File!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnBrowse.Focus();
                    return;
                }
                else
                {
                    txtSubTotal.Text = size.ToString();
                }
                

            }

        }

        //Manually enter path
        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (File.Exists(txtPath.Text))
                {
                    var size = new FileInfo(txtPath.Text).Length;

                    if (size == 0)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nBytesize is empty. Please select a different file.", "Invalid File!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnBrowse.Focus();
                        return;
                    }
                    else
                    {
                        txtSubTotal.Text = size.ToString();
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile not found. Please enter correct path.", "Invalid Path!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPath.Focus();
                    return;
                }
                
            }
        }


        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)

            {

                txtPathFolder.Text = folderBrowserDialog1.SelectedPath;

                var size = GetDirectorySize(txtPathFolder.Text);

                if (size == 0)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nBytesize is empty. Please select a different folder.", "Invalid Folder!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnBrowse.Focus();
                    return;
                }
                else
                {
                    txtSubTotal.Text = size.ToString();
                }

                Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;

            }

        }

        static long GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return b;
        }

        private void txtPathFolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (File.Exists(txtPathFolder.Text))
                {
                    var size = GetDirectorySize(txtPathFolder.Text);

                    if (size == 0)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nBytesize is empty. Please select a different folder.", "Invalid Folder!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnBrowse.Focus();
                        return;
                    }
                    else
                    {
                        txtSubTotal.Text = size.ToString();
                    }

                    Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;

                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nFolder not found. Please enter correct path.", "Invalid Path!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPath.Focus();
                    return;
                }

            }
        }

        private void metroRadioButtonFolder_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxFolder.Visible = true;
            groupBoxFile.Visible = false;
            txtSubTotal.Text = String.Empty;
            txtPath.Text = String.Empty;
        }

        private void metroRadioButtonFile_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxFile.Visible = true;
            groupBoxFolder.Visible = false;
            txtSubTotal.Text = String.Empty;
            txtPathFolder.Text = String.Empty;
        }
    }
}
