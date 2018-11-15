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

    public partial class frm_TaskInOut : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_TaskInOut _instance;
        public static frm_TaskInOut GetInstance(string uUID, string uMUID, string uMName, DateTime uLogTime)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUID = uUID;
                String mMUID = uMUID;
                String mName = uMName;
                DateTime mLogTime = uLogTime;

                _instance = new frm_TaskInOut(mUID, mMUID, mName, uLogTime);

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


        //public int fo
        //{
        //    get { return cmbProject.SelectedIndex; }
        //    set { cmbProject.SelectedIndex = value; }

        //}



        public frm_TaskInOut(string uUID, string uMUID, string uMName, DateTime uLogTime)
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

        private void frm_TaskInOut_Load(object sender, EventArgs e)
        {
            string uUID = lblUIDToFill.Text;
            string mMUID = lblManagerUIDToFill.Text;

            DataTable mTaskrecord = new TaskRecordDetailMng(this.conn).GetTaskedInRecordByUser(uUID);

            if (mTaskrecord.Rows.Count!=0)
            {
                Check_TaskIn();

            }            
            else
            {
                lblPagesKB.Visible = false;

                timer1.Enabled = true;
                timer1.Interval = 1000;

                //Refresh data fields
                RefreshData();

                //Clear All Fields when Load
                ClearFields();

                // Set the Format type and the CustomFormat string.
                dateTimePickerTaskIn.Format = DateTimePickerFormat.Custom;
                dateTimePickerTaskIn.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
                dateTimePickerTaskIn.ShowUpDown = true;

                dateTimePickerTaskOut.Format = DateTimePickerFormat.Custom;
                dateTimePickerTaskOut.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
                dateTimePickerTaskOut.ShowUpDown = true;

                lblElapseTime.Visible = false;
                lblElapseTimeToFill.Visible = false;

                cmbShipment.Text = String.Empty;
            }

        }


        //Refresh Object
        private void RefreshData()
        {
            string uUID = lblUIDToFill.Text;
            string mMUID = lblManagerUIDToFill.Text;
            int mTaskRecordStatus = new TaskRecordDetailMng(this.conn).GetTaskStatusByPCPCode(txtJobCode.Text, uUID);

            if (mTaskRecordStatus == 1)
            {
                dataGridViewTaskInOut.DataSource = new TaskRecordDetailMng(this.conn).GetAllTaskDetailsByUserUID(uUID);
            }
            else
            {
                cmbProject.DataSource = new UserManagementDetailMng(this.conn).ListAllActiveProjectsByUser(uUID);
                dataGridViewTaskInOut.DataSource = new TaskRecordDetailMng(this.conn).GetAllTaskDetailsByUserUID(uUID);
            }

        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();

            //Clear All Fields when Load
            cmbProject.SelectedIndex = -1;
            cmbShipment.SelectedIndex = -1;
            cmbtaskCode.SelectedIndex = -1;
            cmbTaskStatus.SelectedIndex = -1;
            
            txtFileName.Text = String.Empty;
            txtJobCode.Text = String.Empty;
            cmbShipment.Text = String.Empty;

            numericUpDownFileSize.Value = 0;

            cmbProject.Enabled = true;
            cmbtaskCode.Enabled = false;
            numericUpDownFileSize.Enabled = false;
            dateTimePickerTaskIn.Enabled = false;
            btnTaskIn.Enabled = false;
            dateTimePickerTaskOut.Enabled = false;
            btnTaskOut.Enabled = false;
            cmbTaskStatus.Enabled = false;
            lblTaskInMessage.Visible = false;
            dateTimePickerTaskIn.Value = ServerDateTime();
            txtFileName.Enabled = true;
            txtJobCode.Enabled = true;
        }

        public string Create_TR_ID()
        {
            string cTRID = "";
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            string uID = lblUIDToFill.Text;
            int cLastUserRecordNumber = mTaskRecordDetailMng.GetUserLastRecordCount(uID);            
            int cNewInt = (cLastUserRecordNumber + 1);

            //Task Code from List part 02
            string cTaskCode = cmbtaskCode.Text;
            string cProject = cTaskCode.Substring(0, 3);
            //string cMonthYear = ServerDateTime().ToString("ddMMyy");

            cTRID = uID  + cProject + cNewInt;

            return cTRID;

        }
        /// <summary>
        /// DEBUG: Get Last Row count error fixed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFileName_KeyDown(object sender, KeyEventArgs e)
        {
            string uUID = lblUIDToFill.Text;
            if (e.KeyCode == Keys.Enter)
            {
                //Validate fields
                if (string.IsNullOrEmpty(cmbShipment.Text))
                {
                    MetroMessageBox.Show(MetroForm.ActiveForm, "\nShipment cannot be empty.", "Shipment Not Entered!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbShipment.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtFileName.Text))
                {
                    MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile name cannot be empty.", "Invalid File Name!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFileName.Focus();
                    return;
                }

                /*
                 As requested by Production teams, PCP hidden to develop validation to exact task validate.
                 */

                //string cJobCode = new PCPDetailMng(this.conn).GetPCPCodeByShipmentAndFileName(cmbShipment.Text, txtFileName.Text);

                //int mTaskRecordStatus = new TaskRecordDetailMng(this.conn).GetTaskStatusByPCPCode(cJobCode);

                //if (mTaskRecordStatus==1)
                //{
                //    DataTable TaskedInUsers = new TaskRecordDetailMng(this.conn).GetTaskInUsersByPCPCode(cJobCode);

                        
                //    if (TaskedInUsers.Rows[0][0].ToString() != uUID)
                //    {
                //        MetroMessageBox.Show(MetroForm.ActiveForm, "\nAnother user (" + TaskedInUsers.Rows[0][0].ToString() + ") is currently tasked in for this file. Please wait untill user task out or check your filename.", "Active Process!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        txtFileName.Focus();
                //        return;

                //    }

                //}
                


                try
                {
                    if (new PCPDetailMng(this.conn).IsExistFileName(cmbShipment.Text, txtFileName.Text) == false)
                    {
                        MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile name not found. Please check filename or shipment again.", "Invalid File Name!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFileName.Focus();
                        return;

                    }
                    else
                    {
                        ////Validate task Done
                        if (new PCPDetailMng(this.conn).GetTaskCodeByFileAndStatusNotDoneOrHold(cmbProject.Text, cmbShipment.Text ,txtFileName.Text).Count() == 0)
                        {
                            MetroMessageBox.Show(MetroForm.ActiveForm, "\nAll the tasks for the file \"" + txtFileName.Text + "\" are done.\nPlease enter a new file.", "Invalid PCP Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtFileName.Focus();
                            return;
                        }
                        else
                        {
                            //Activate fileds
                            cmbtaskCode.Enabled = true;
                            numericUpDownFileSize.Enabled = true;
                            //dateTimePickerTaskIn.Enabled = true;
                            btnTaskIn.Enabled = true;
                            //dateTimePickerTaskOut.Enabled = true;
                            btnTaskOut.Enabled = true;
                            txtFileName.Enabled = false;
                            txtJobCode.Enabled = false;

                            //Next to be fill
                            cmbtaskCode.Focus();
                          


                            //Update fields with PCP Code                        
                            txtJobCode.Text = new PCPDetailMng(this.conn).GetPCPCodeByShipmentAndFileName_TaskInOut(cmbShipment.Text,txtFileName.Text);
                            
                        if (!String.IsNullOrEmpty(txtJobCode.Text))
                        {
                            //Update Task Codes
                            
                            cmbtaskCode.DataSource = new PCPDetailMng(this.conn).GetTaskCodeByPCPCodeAndStatusNotDoneOrHold(txtJobCode.Text);
                            string mPendingTask = new PCPDetailMng(this.conn).GetPendingTaskByPCPCode(txtJobCode.Text, lblUIDToFill.Text);
                            

                            //Pending task Message
                            if (!String.IsNullOrEmpty(mPendingTask))
                            {
                                lblTaskPendingMessage.Visible = true;
                                lblTaskPendingMessage.Text = "[Pending Stage]: " + mPendingTask;
                            }
                            else
                            {
                                lblTaskPendingMessage.Visible = false;
                            }

                                //--------------------
                                //Task Validation label update move to cmbIndec changed by task
                                //--------------------

                                //if (mTaskRecordStatus == 1)  /* 0-TaskedOut, 1- TaskedIn*/
                                //{

                                //    lblTaskInMessage.Visible = true;
                                //    lblTaskInMessage.Text = "Currenlty you are tasked in! ";

                                //    dateTimePickerTaskIn.Enabled = false;
                                //    btnTaskIn.Enabled = false;
                                //    //dateTimePickerTaskOut.Enabled = true;
                                //    btnTaskOut.Enabled = true;
                                //    numericUpDownFileSize.Enabled = true;
                                //    cmbTaskStatus.Enabled = true;

                                //    //Get tasked In Datetime
                                //    dateTimePickerTaskIn.Value = new TaskRecordDetailMng(this.conn).GetTaskedInDateTime(txtJobCode.Text);


                                //}

                                //else
                                //{
                                //    lblTaskInMessage.Visible = false;
                                //    //dateTimePickerTaskIn.Enabled = true;
                                //    btnTaskIn.Enabled = true;
                                //    dateTimePickerTaskOut.Enabled = false;
                                //    btnTaskOut.Enabled = false;
                                //    numericUpDownFileSize.Enabled = false;
                                //    cmbTaskStatus.Enabled = false;
                                //    dateTimePickerTaskIn.Value = ServerDateTime();
                                //}

                            }

                        //Clear Fileds
                        cmbtaskCode.SelectedIndex = -1;
                        cmbTaskStatus.SelectedIndex = -1;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Message: "+ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbProject.Text))
            {
                string mMUID = lblManagerUIDToFill.Text;
                cmbShipment.DataSource = new PCPDetailMng(this.conn).ListAllActiveShipmentsByManagerUID(mMUID, cmbProject.Text);

                if (String.IsNullOrEmpty(txtJobCode.Text))
                {
                    cmbShipment.SelectedIndex = -1;
                    cmbtaskCode.SelectedIndex = -1;
                    cmbTaskStatus.SelectedIndex = -1;
                    txtFileName.Text = String.Empty;
                    //txtJobCode.Text = String.Empty;
                    lblTaskPendingMessage.Text = String.Empty;

                    numericUpDownFileSize.Value = 0;
                    lblTaskPendingMessage.Visible = false;

                    cmbtaskCode.Enabled = false;
                    cmbShipment.Enabled = true;
                    txtJobCode.Enabled = true;
                    numericUpDownFileSize.Enabled = false;
                    dateTimePickerTaskIn.Enabled = false;
                    lblTaskInMessage.Visible = false;
                    btnTaskIn.Enabled = false;
                    dateTimePickerTaskOut.Enabled = false;
                    btnTaskOut.Enabled = false;
                    cmbTaskStatus.Enabled = false;
                    dateTimePickerTaskIn.Value = ServerDateTime();
                }
                else
                {

                    //cmbShipment.SelectedIndex = -1;
                    //cmbtaskCode.SelectedIndex = -1;
                    //cmbTaskStatus.SelectedIndex = -1;
                    //txtFileName.Text = String.Empty;
                    //txtJobCode.Text = String.Empty;
                    lblTaskPendingMessage.Text = String.Empty;

                    numericUpDownFileSize.Value = 0;
                    lblTaskPendingMessage.Visible = false;

                    //cmbtaskCode.Enabled = false;
                    //numericUpDownFileSize.Enabled = false;
                    dateTimePickerTaskIn.Enabled = false;
                    lblTaskInMessage.Visible = false;
                    //btnTaskIn.Enabled = false;
                    dateTimePickerTaskOut.Enabled = false;
                    //btnTaskOut.Enabled = false;
                    cmbTaskStatus.Enabled = false;
                    dateTimePickerTaskIn.Value = ServerDateTime();
                }

                AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
                DataTable sug = new PCPDetailMng(this.conn).ListAllActiveShipmentsByManagerUID_SuggestBox(mMUID, cmbProject.Text);

                if (sug.Rows.Count != 0 && String.IsNullOrEmpty(cmbShipment.Text))
                {
                    foreach (DataRow row in sug.Rows)
                    {
                        namesCollection.Add(row[0].ToString());
                    }

                    cmbShipment.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmbShipment.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cmbShipment.AutoCompleteCustomSource = namesCollection;

                }
                else
                {
                    cmbShipment.AutoCompleteCustomSource = null;
                }
            }

        }

        //Task Index Changed
        private void cmbtaskCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);

            //Create Task Code by splitting details
            string source = cmbtaskCode.Text;
            string[] stringSeparators = new string[] { " - " };
            string[] result;
            result = source.Split(stringSeparators, StringSplitOptions.None);
            string cTaskCode = result[0].ToString();
            
            //get UOM and Quota form Task Code
            string cProcessCode = new PCPDetailMng(this.conn).GetProcessCodeByPCPCode(cTaskCode, txtJobCode.Text);
            string cUOM = mTaskDetailMng.GetUOMFromTaskCode(cTaskCode, cProcessCode);


            if (!String.IsNullOrEmpty(cUOM))
            {
                lblPagesKB.Visible = true;
                lblPagesKB.Text = cUOM;
            }
            else
            {
                lblPagesKB.Visible = false;
            }


        }

        //Task In button
        private void btnTaskIn_Click(object sender, EventArgs e)
        {
            //Show Mdofied false
            tglModified.Checked = false;

            //Validate fields
            if (string.IsNullOrEmpty(cmbShipment.Text))
            {
                MetroMessageBox.Show(MetroForm.ActiveForm, "\nShipment cannot be empty.", "Shipment Not Entered!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbShipment.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile name cannot be empty.", "Invalid File Name!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFileName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cmbtaskCode.Text))
            {
                MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select a task.", "Task Not Entered!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbtaskCode.Focus();
                return;
            }

            if (lblTaskPendingMessage.Visible)
            {
                //Create Task Code by splitting details
                string sourcea = lblTaskPendingMessage.Text;
                string[] stringSeparatorsa = new string[] { "Stage]: " };
                string[] resultu;
                resultu = sourcea.Split(stringSeparatorsa, StringSplitOptions.None);

                string cTaskCodea = resultu[1].ToString();

                if (cTaskCodea != cmbtaskCode.Text)
                {
                    MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select correct pending task.\n" + cTaskCodea, "Invalid Pending Task!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbtaskCode.Focus();
                    return;
                }
            }


            //Create Task Code by splitting details
            string sourceu = cmbtaskCode.Text;
            string[] stringSeparatorst = new string[] { " - " };
            string[] resultt;
            resultt = sourceu.Split(stringSeparatorst, StringSplitOptions.None);
            string cTaskCodeu = resultt[0].ToString();

            string cJobCode = new PCPDetailMng(this.conn).GetPCPCodeByShipmentAndFileName_TaskInOut(cmbShipment.Text, txtFileName.Text);

            int mTaskRecordStatus = new TaskRecordDetailMng(this.conn).GetTaskStatusByPCPCodeAndTaskCode(cJobCode, cTaskCodeu);

            if (mTaskRecordStatus == 1)
            {
                DataTable TaskedInUsers = new TaskRecordDetailMng(this.conn).GetTaskInUsersByPCPCodeAndTaskCode(cJobCode, cTaskCodeu);

                if (TaskedInUsers.Rows[0][0].ToString() != lblUIDToFill.Text)
                {
                    MetroMessageBox.Show(MetroForm.ActiveForm, "\nAnother user (" + TaskedInUsers.Rows[0][0].ToString() + ") is currently tasked in for this task.", "Active Task!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFileName.Focus();
                    return;

                }

            }


            TaskRecordHeader mTaskRecordHeader = new TaskRecordHeader();
            TaskRecordHeaderMng mTaskRecordHeaderMng = new TaskRecordHeaderMng(this.conn);

            TaskRecordDetail mTaskRecordDetail = new TaskRecordDetail();
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);

            PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

            //
            string cTRID = Create_TR_ID();
            string cPCPCode = txtJobCode.Text;
            string cUID = lblUIDToFill.Text;
            string cMID = lblManagerUIDToFill.Text;
            string cPID = new ManagerDetailMng(this.conn).GetManagerNameByUID(cMID);

            //Create Task Code by splitting details
            string source = cmbtaskCode.Text;
            string[] stringSeparators = new string[] { " - " };
            string[] result;
            result = source.Split(stringSeparators, StringSplitOptions.None);
            string cTaskCode = result[0].ToString();
            string cTaskCodeName = result[1].ToString();


            //get UOM and Quota form Task Code
            string cProcessCode = new PCPDetailMng(this.conn).GetProcessCodeByPCPCode(cTaskCode, cPCPCode);
            string cUOM = mTaskDetailMng.GetUOMFromTaskCode(cTaskCode, cProcessCode);
            int cQuota = mTaskDetailMng.GetQuotaFromTaskCode(cTaskCode, cProcessCode);

            //Header
            mTaskRecordHeader.TR_ID = cTRID;
            mTaskRecordHeader.PCP_ID = cPCPCode;
            mTaskRecordHeader.TR_UID = cUID;
            mTaskRecordHeader.TR_MID = cMID;
            mTaskRecordHeader.TR_PIC = cPID;

            //Detail
            mTaskRecordDetail.TR_ID = cTRID;
            mTaskRecordDetail.PCP_ID = cPCPCode;
            //mTaskRecordDetail.TR_Status = 2; /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
            mTaskRecordDetail.TR_InDate = ServerDateTime(); 
            mTaskRecordDetail.TR_TaskStatus = 1; /* 0 - Fresh, 1 - Tasked In , 2 - Done */
            mTaskRecordDetail.TR_Shipment = cmbShipment.Text;
            mTaskRecordDetail.TR_File = txtFileName.Text;
            mTaskRecordDetail.TR_UOM = cUOM;
            mTaskRecordDetail.TR_Quota = cQuota;
            mTaskRecordDetail.TR_Apporval = 4; /* 0-No Status,  1 - Pending, 2- Approved, 3- Disapproved, 4- Skipped */
            mTaskRecordDetail.TR_UID = cUID;
            mTaskRecordDetail.TR_MID = cMID;
            mTaskRecordDetail.TR_PIC = cPID;
            mTaskRecordDetail.Task_ID = cTaskCode;
            mTaskRecordDetail.TR_ActualTaskIn = ServerDateTime();

            //Update Task In dateTime
            dateTimePickerTaskIn.Value = ServerDateTime();


            //PCP Detail
            int cStatus = 2;
            DateTime cDateTime = ServerDateTime();

            //Get user Confirmation
            DialogResult resultc = MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to task in to \""+ cTaskCodeName + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultc == DialogResult.Yes)
            {
                if (!mTaskRecordHeaderMng.TaskRecordHeaderIsExist(cTRID, cPCPCode, cUID))
                {
                    if (mTaskRecordHeaderMng.AddTaskRecordHeader(mTaskRecordHeader) > 0)
                    {
                        if (mTaskRecordDetailMng.AddTaskInDetail(mTaskRecordDetail) > 0)
                        {
                            mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cStatus, cDateTime);


                            //Enable Task Out button
                            dateTimePickerTaskIn.Enabled = false;
                            btnTaskIn.Enabled = false;
                            //dateTimePickerTaskOut.Enabled = true;
                            btnTaskOut.Enabled = true;
                            numericUpDownFileSize.Enabled = true;
                            cmbTaskStatus.Enabled = true;

                            //Project
                            cmbProject.Enabled = false;
                            cmbShipment.Enabled = false;
                            txtFileName.Enabled = false;
                            cmbtaskCode.Enabled = false;


                            MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are tasked in to " + cmbtaskCode.Text, "Tasked In!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Check_TaskIn();
                            RefreshData();
                            //ClearFields();
                        }

                    }

                }
                else
                {
                    if (!mTaskRecordDetailMng.TaskTaskInDetailIsExist(cTaskCode, cPCPCode, cUID))
                    {
                        if (mTaskRecordDetailMng.AddTaskInDetail(mTaskRecordDetail) > 0)
                        {
                            mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cStatus, cDateTime);

                            //Enable Task Out button
                            dateTimePickerTaskIn.Enabled = false;
                            btnTaskIn.Enabled = false;
                            //dateTimePickerTaskOut.Enabled = true;
                            btnTaskOut.Enabled = true;
                            numericUpDownFileSize.Enabled = true;

                            //Project
                            cmbProject.Enabled = false;
                            cmbShipment.Enabled = false;
                            txtFileName.Enabled = false;
                            cmbtaskCode.Enabled = false;



                            MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are task in to " + cmbtaskCode.Text, "Task In!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Check_TaskIn();
                            RefreshData();
                            //ClearFields();
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou cannot tasked in at the moment. Please check your task is correct or already tasked in.", "Task In Abort!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbtaskCode.Focus();
                        return;
                    }

                }
            }

            //Check if already tasked in same id else add


            //get task in time
            //Record create
            //Ask do you wan to minimize app
            //enable task out date and button
            //enable file size and status

        }

        //Task Out
        private void btnTaskOut_Click(object sender, EventArgs e)
        {
            //Show Mdofied false
            tglModified.Checked = false;

            //Validate fields
            if (string.IsNullOrEmpty(cmbShipment.Text))
            {
                MetroMessageBox.Show(MetroForm.ActiveForm, "\nShipment cannot be empty.", "Shipment Not Entered!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbShipment.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile name cannot be empty.", "Invalid File Name!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFileName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cmbtaskCode.Text))
            {
                MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select a task.", "Task Not Entered!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbtaskCode.Focus();
                return;
            }
            if ((String.IsNullOrEmpty(numericUpDownFileSize.Text) && (lblPagesKB.Text != "Byte Size" && lblPagesKB.Text != "Book Count") || numericUpDownFileSize.Value == 0 && (lblPagesKB.Text != "Byte Size" && lblPagesKB.Text != "Book Count")))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile size cannot be zero or empty.", "File Size Not Enterd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDownFileSize.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cmbTaskStatus.Text))
            {
                MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select a status of your task.", "Status Not Entered!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTaskStatus.Focus();
                return;
            }
            if (lblTaskPendingMessage.Visible)
            {
                //Create Task Code by splitting details
                string sourcea = lblTaskPendingMessage.Text;
                string[] stringSeparatorsa = new string[] { "Stage]: " };
                string[] resultc;
                resultc = sourcea.Split(stringSeparatorsa, StringSplitOptions.None);

                string cTaskCodea = resultc[1].ToString();

                if (cTaskCodea != cmbtaskCode.Text)
                {
                    MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select correct pending task.\n" + cTaskCodea, "Invalid Pending Task!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbtaskCode.Focus();
                    return;
                }
            }

            //Initialization
            string cPCPCode = txtJobCode.Text;
            string cUID = lblUIDToFill.Text;
            string cMID = lblManagerUIDToFill.Text;
            string cPID = new ManagerDetailMng(this.conn).GetManagerNameByUID(cMID);
            int cPCPStatus = 0 ;
            DateTime cDateTime = ServerDateTime();

            //Create Task Code by splitting details
            string source = cmbtaskCode.Text;
            string[] stringSeparators = new string[] { " - " };
            string[] result;
            result = source.Split(stringSeparators, StringSplitOptions.None);
            string cTaskCode = result[0].ToString();

            //Get user Confirmation
            DialogResult resultb = MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to task out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultb == DialogResult.Yes)
            {
                string uUID = lblUIDToFill.Text;
                string mMUID = lblManagerUIDToFill.Text;

                //Object Create
                TaskRecordHeader mTaskRecordHeader = new TaskRecordHeader();
                TaskRecordHeaderMng mTaskRecordHeaderMng = new TaskRecordHeaderMng(this.conn);

                TaskRecordDetail mTaskRecordDetail = new TaskRecordDetail();
                TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

                TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);
                PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

                //Initialize Task Record
                mTaskRecordDetail.TR_File = txtFileName.Text;
                mTaskRecordDetail.TR_Shipment = cmbShipment.Text;
                mTaskRecordDetail.Task_ID = cTaskCode;

                if (cmbTaskStatus.Text == "Pending")
                {
                    mTaskRecordDetail.TR_Status = 2;/* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                    cPCPStatus = 2;                    
                }
                if (cmbTaskStatus.Text == "Done")
                {
                    mTaskRecordDetail.TR_Status = 3;/* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                    cPCPStatus = 3;
                }
                if (cmbTaskStatus.Text == "On Hold")
                {
                    mTaskRecordDetail.TR_Status = 1;/* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                    cPCPStatus = 1;
                }
                mTaskRecordDetail.TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                mTaskRecordDetail.TR_OutDate = dateTimePickerTaskOut.Value;

                //Time Calculation
                TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;
                double hours = diff.TotalHours;

                mTaskRecordDetail.TR_Hours = float.Parse(hours.ToString());


                //Productivity Calculate
                int QuotaSize = mTaskRecordDetailMng.GetQuotaSize(cTaskCode, cPCPCode, uUID);

                float PrductDivedeByQuota = float.Parse(numericUpDownFileSize.Value.ToString()) / QuotaSize;
                float PrductDivedeByTime = (9 / float.Parse(hours.ToString()));

                float mProductivity = (PrductDivedeByQuota * PrductDivedeByTime) * 100;

                mTaskRecordDetail.TR_Productivity = mProductivity;

                //Check DoneSize is match to the Task history
                int ActualFileSize = mPCPDetailMng.GetActualFileSize(cPCPCode, cTaskCode);
                int PendingHistoryCount = mTaskRecordDetailMng.GetActualFileSizeFroPending(cPCPCode, cTaskCode, txtFileName.Text);
                DateTime FisrtPendingHistoryTaskIn = mTaskRecordDetailMng.GetActualTaskInForPending(cPCPCode, cTaskCode, txtFileName.Text);
                DataTable mTaskrecord = new TaskRecordDetailMng(this.conn).GetTaskedInRecordByUser(uUID);

                if (lblPagesKB.Visible)
                {

                    //DataTable TaskedInUsers = new TaskRecordDetailMng(this.conn).GetTaskInUsersByPCPCode(txtJobCode.Text);
                    //int TaskedInUsersCount = new TaskRecordDetailMng(this.conn).GetTaskInUsersCountByPCPCode(txtJobCode.Text);

                    //for (int i = 0; i < TaskedInUsers.Rows.Count; i++)
                    //{
                    //    if (TaskedInUsers.Rows[i][0].ToString() == uUID)
                    //    {
                    //        //Reduce current user
                    //        TaskedInUsersCount = TaskedInUsersCount - 1;


                    //        lblTaskInMessage.Visible = true;
                    //        lblTaskInMessage.Text = "Currenlty you are tasked in! ";

                    //        dateTimePickerTaskIn.Enabled = false;
                    //        btnTaskIn.Enabled = false;
                    //        //dateTimePickerTaskOut.Enabled = true;
                    //        btnTaskOut.Enabled = true;
                    //        numericUpDownFileSize.Enabled = true;
                    //        cmbTaskStatus.Enabled = true;

                    //        //Get tasked In Datetime
                    //        dateTimePickerTaskIn.Value = new TaskRecordDetailMng(this.conn).GetTaskedInDateTime(txtJobCode.Text);
                    //    }
                    //}



                    if (lblPagesKB.Text == "Byte Size" && cmbTaskStatus.Text=="Done")
                    {
                        string mPCPCode = txtJobCode.Text;
                        string mTask_ID = cTaskCode;
                        string mTR_File = txtFileName.Text;
                        string mTR_Shipment = cmbShipment.Text;
                        int mTR_Status = mTaskRecordDetail.TR_Status; /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                        int mTR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                        DateTime mTR_OutDate = dateTimePickerTaskOut.Value;
                        float mTR_Hours = float.Parse(hours.ToString());
                        float mTR_Productivity = mProductivity;


                        string mUID = uUID;
                        string mMID = mMUID;
                        string mPIC = cPID;


                        frm_DoneByteSizeFile form = frm_DoneByteSizeFile.GetInstance(mPCPCode, mTask_ID, mTR_File, mTR_Shipment, mTR_Status, mTR_FileSize, mTR_OutDate, mTR_Hours, mTR_Productivity, mUID, mMID, mPIC);
                        if (!form.Visible)
                        {

                            form.Show();
                            lblElapseTime.Visible = false;
                            lblElapseTimeToFill.Visible = false;
                        }
                        else
                        {
                            form.BringToFront();
                        }

                    }
                    else if (lblPagesKB.Text == "Byte Size" && cmbTaskStatus.Text == "Pending")
                    {
                        //Cast Task Details
                        mTaskRecordDetail.TR_Productivity = 0;
                        mTaskRecordDetail.TR_Apporval = 4;

                        //Is task record Exist
                        if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(cTaskCode, cPCPCode, uUID))
                        {
                            if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut(mTaskRecordDetail) > 0)
                            {
                                mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                //TaskIn Date reset to Current Datetime
                                dateTimePickerTaskIn.Value = ServerDateTime();

                                //Enable Task Out button
                                //dateTimePickerTaskIn.Enabled = true;
                                cmbProject.Enabled = true;
                                cmbShipment.Enabled = true;
                                txtFileName.Enabled = true;
                                btnTaskIn.Enabled = true;


                                dateTimePickerTaskOut.Enabled = false;
                                btnTaskOut.Enabled = false;
                                numericUpDownFileSize.Enabled = false;
                                cmbTaskStatus.Enabled = false;
                                lblElapseTime.Visible = false;
                                lblElapseTimeToFill.Visible = false;

                                MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + cmbtaskCode.Text, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                RefreshData();
                                ClearFields();
                            }
                        }

                    }
                    //QR - Book Count - Pending
                    else if (lblPagesKB.Text == "Book Count" && cmbTaskStatus.Text == "Pending")
                    {
                        //Cast Task Details
                        mTaskRecordDetail.TR_Productivity = 0;
                        mTaskRecordDetail.TR_Apporval = 4;

                        //Is task record Exist
                        if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(cTaskCode, cPCPCode, uUID))
                        {
                            if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut(mTaskRecordDetail) > 0)
                            {
                                mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                //TaskIn Date reset to Current Datetime
                                dateTimePickerTaskIn.Value = ServerDateTime();

                                //Enable Task Out button
                                //dateTimePickerTaskIn.Enabled = true;
                                cmbProject.Enabled = true;
                                cmbShipment.Enabled = true;
                                txtFileName.Enabled = true;
                                btnTaskIn.Enabled = true;


                                dateTimePickerTaskOut.Enabled = false;
                                btnTaskOut.Enabled = false;
                                numericUpDownFileSize.Enabled = false;
                                cmbTaskStatus.Enabled = false;
                                lblElapseTime.Visible = false;
                                lblElapseTimeToFill.Visible = false;

                                MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + cmbtaskCode.Text, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                RefreshData();
                                ClearFields();
                            }
                        }

                    }                   

                    else
                    {
                        string cProcessCode = new PCPDetailMng(this.conn).GetProcessCodeByPCPCode(cTaskCode, cPCPCode);
                        int cCheckSkipped = new ProjectDetailMng(this.conn).GetProjectOutputValidation(cmbProject.Text, cPID);                        
                        int cCheckSkippedTask = new TaskHeaderMng(this.conn).CheckTaskCodeSkipValidation(cTaskCode, cmbProject.Text, cProcessCode);

                        if (cCheckSkipped==0 && cCheckSkippedTask == 0) /* Skip User output validation by Project */
                        {
                            
                            //Validate from PCP Details table
                            if (ActualFileSize < numericUpDownFileSize.Value)
                            {

                                MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile size exceeded actual file size.\n\nActual File Size: " + ActualFileSize + "\nEntered File Size: " + numericUpDownFileSize.Value, "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                numericUpDownFileSize.Focus();
                                return;

                            }

                            //Validate from User PCP Details history
                            if (ActualFileSize < numericUpDownFileSize.Value + PendingHistoryCount)
                            {

                                MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile size exceeded actual file size.\n\nActual File Size: " + ActualFileSize + "\nHistory of File Size: " + PendingHistoryCount + "\nRest File Size: [" + (ActualFileSize - PendingHistoryCount) + "]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                numericUpDownFileSize.Focus();
                                return;

                            }

                            //Pending validate
                            if (ActualFileSize == numericUpDownFileSize.Value + PendingHistoryCount && cmbTaskStatus.Text == "Pending")
                            {

                                MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile size is matching to Actual file size on \"Pending\" category.\nPlease reduce the file size or select task \"Done\".\nActual File Size: " + ActualFileSize + "\nHistory of File Size: " + PendingHistoryCount + "\nRest File Size: [" + (ActualFileSize - PendingHistoryCount) + "]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                numericUpDownFileSize.Focus();
                                return;

                            }

                            //Done validate
                            if (ActualFileSize != numericUpDownFileSize.Value + PendingHistoryCount && cmbTaskStatus.Text == "Done")
                            {

                                MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile size is not matching to Actual file size on \"Done\" category.\nPlease verify your file size to the actual page count.\n\nActual File Size: " + ActualFileSize + "\nHistory of File Size: " + PendingHistoryCount + "\nRest File Size: [" + (ActualFileSize - PendingHistoryCount) + "]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                numericUpDownFileSize.Focus();
                                return;

                            }

                            //QR - Book Count - Done
                            if (lblPagesKB.Text == "Book Count" && cmbTaskStatus.Text == "Done")
                            {

                                string PCPCode = txtJobCode.Text;
                                string Task_ID = cTaskCode;
                                string TR_File = txtFileName.Text;
                                string TR_Shipment = cmbShipment.Text;
                                int TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                                DateTime TR_OutDate = dateTimePickerTaskOut.Value;

                                //Actual TaskIn
                                if (FisrtPendingHistoryTaskIn == DateTime.Parse("1/1/1753 00:00:00 AM") || FisrtPendingHistoryTaskIn == null)
                                {
                                    mTaskRecordDetail.TR_InDate = DateTime.Parse(mTaskrecord.Rows[0][5].ToString());
                                }
                                else
                                {
                                    mTaskRecordDetail.TR_InDate = FisrtPendingHistoryTaskIn;
                                }

                                //Initialize Task Record
                                mTaskRecordDetail.TR_File = TR_File;
                                mTaskRecordDetail.TR_Shipment = TR_Shipment;
                                mTaskRecordDetail.Task_ID = Task_ID;
                                mTaskRecordDetail.TR_Status = 3;/* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                                cPCPStatus = 3;
                                mTaskRecordDetail.TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                                mTaskRecordDetail.TR_OutDate = TR_OutDate;
                                mTaskRecordDetail.TR_Apporval = 1;

                                //Time Calcuation for Done Record
                                float PendingHistoryHoursCount = mTaskRecordDetailMng.GetActualHoursCountForPending(PCPCode, Task_ID, TR_File);

                                //Time Calculation
                                double qrhours = hours + PendingHistoryHoursCount;

                                mTaskRecordDetail.TR_Hours = float.Parse(qrhours.ToString());

                                //Productivity Calculate
                                float cPrductDivedeByQuota = float.Parse(numericUpDownFileSize.Value.ToString()) / QuotaSize;
                                float cPrductDivedeByTime = (9 / float.Parse(qrhours.ToString()));

                                float cProductivity = (cPrductDivedeByQuota * cPrductDivedeByTime) * 100;

                                mTaskRecordDetail.TR_Productivity = cProductivity;

                                //Is task record Exist
                                if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(Task_ID, PCPCode, uUID))
                                {
                                    if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut_ActualTaskIn(mTaskRecordDetail) > 0)
                                    {
                                        mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                        //TaskIn Date reset to Current Datetime
                                        dateTimePickerTaskIn.Value = ServerDateTime();

                                        //Enable Task Out button
                                        //dateTimePickerTaskIn.Enabled = true;
                                        cmbProject.Enabled = true;
                                        cmbShipment.Enabled = true;
                                        txtFileName.Enabled = true;
                                        btnTaskIn.Enabled = true;

                                        dateTimePickerTaskOut.Enabled = false;
                                        btnTaskOut.Enabled = false;
                                        numericUpDownFileSize.Enabled = false;
                                        cmbTaskStatus.Enabled = false;
                                        lblElapseTime.Visible = false;
                                        lblElapseTimeToFill.Visible = false;

                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + Task_ID, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        RefreshData();
                                        ClearFields();
                                    }
                                }

                            }

                            //On Hold
                            else if (cmbTaskStatus.Text == "On Hold")
                            {
                                //Cast Task Details
                                mTaskRecordDetail.TR_Productivity = 0;
                                mTaskRecordDetail.TR_Apporval = 4;

                                //Is task record Exist
                                if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(cTaskCode, cPCPCode, uUID))
                                {
                                    if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut(mTaskRecordDetail) > 0)
                                    {
                                        mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                        mPCPDetailMng.UpdatePCPDetailToOnhold(cPCPCode, cPCPStatus, cDateTime); //On hold other pending tsaks On same PCP Code

                                        //TaskIn Date reset to Current Datetime
                                        dateTimePickerTaskIn.Value = ServerDateTime();

                                        //Enable Task Out button
                                        //dateTimePickerTaskIn.Enabled = true;
                                        cmbProject.Enabled = true;
                                        cmbShipment.Enabled = true;
                                        txtFileName.Enabled = true;
                                        btnTaskIn.Enabled = true;


                                        dateTimePickerTaskOut.Enabled = false;
                                        btnTaskOut.Enabled = false;
                                        numericUpDownFileSize.Enabled = false;
                                        cmbTaskStatus.Enabled = false;
                                        lblElapseTime.Visible = false;
                                        lblElapseTimeToFill.Visible = false;

                                        MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + cmbtaskCode.Text, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        RefreshData();
                                        ClearFields();
                                    }
                                }
                            }

                            else if (cmbTaskStatus.Text == "Done" || (cmbTaskStatus.Text == "Done" && lblPagesKB.Text != "Book Count") || (cmbTaskStatus.Text == "Done" && lblPagesKB.Text != "Byte Size"))
                            {
                                string PCPCode = txtJobCode.Text;
                                string Task_ID = cTaskCode;
                                string TR_File = txtFileName.Text;
                                string TR_Shipment = cmbShipment.Text;
                                int TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                                DateTime TR_OutDate = dateTimePickerTaskOut.Value;

                                //Initialize Task Record
                                mTaskRecordDetail.TR_File = TR_File;
                                mTaskRecordDetail.TR_Shipment = TR_Shipment;
                                mTaskRecordDetail.Task_ID = Task_ID;
                                mTaskRecordDetail.TR_Status = 3;/* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                                cPCPStatus = 3;
                                mTaskRecordDetail.TR_OutDate = TR_OutDate;
                                mTaskRecordDetail.TR_Apporval = 1;


                                //Update Done record with pending fize size
                                mTaskRecordDetail.TR_FileSize = (int.Parse(numericUpDownFileSize.Value.ToString()) + PendingHistoryCount);

                                //Time Calcuation for Done Record
                                float PendingHistoryHoursCount = mTaskRecordDetailMng.GetActualHoursCountForPending(PCPCode, Task_ID, TR_File);

                                //Time Calculation
                                double qrhours = hours + PendingHistoryHoursCount;

                                mTaskRecordDetail.TR_Hours = float.Parse(qrhours.ToString());

                                //Actual TaskIn
                                if (FisrtPendingHistoryTaskIn == DateTime.Parse("1/1/1753 00:00:00 AM") || FisrtPendingHistoryTaskIn == null)
                                {
                                    mTaskRecordDetail.TR_InDate = DateTime.Parse(mTaskrecord.Rows[0][5].ToString());
                                }
                                else
                                {
                                    mTaskRecordDetail.TR_InDate = FisrtPendingHistoryTaskIn;
                                }

                                //Productivity Calculate
                                float cPrductDivedeByQuota = (float.Parse(numericUpDownFileSize.Value.ToString()) + PendingHistoryCount) / QuotaSize;
                                float cPrductDivedeByTime = (9 / float.Parse(qrhours.ToString()));

                                float cProductivity = (cPrductDivedeByQuota * cPrductDivedeByTime) * 100;

                                mTaskRecordDetail.TR_Productivity = cProductivity;

                                //Is task record Exist
                                if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(Task_ID, PCPCode, uUID))
                                {
                                    if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut_ActualTaskIn(mTaskRecordDetail) > 0)
                                    {
                                        mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                        //TaskIn Date reset to Current Datetime
                                        dateTimePickerTaskIn.Value = ServerDateTime();

                                        //Enable Task Out button
                                        //dateTimePickerTaskIn.Enabled = true;
                                        cmbProject.Enabled = true;
                                        cmbShipment.Enabled = true;
                                        txtFileName.Enabled = true;
                                        btnTaskIn.Enabled = true;

                                        dateTimePickerTaskOut.Enabled = false;
                                        btnTaskOut.Enabled = false;
                                        numericUpDownFileSize.Enabled = false;
                                        cmbTaskStatus.Enabled = false;
                                        lblElapseTime.Visible = false;
                                        lblElapseTimeToFill.Visible = false;

                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + Task_ID, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        RefreshData();
                                        ClearFields();
                                    }
                                }
                            }

                            //Is task record Exist
                            else if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(cTaskCode, cPCPCode, uUID))
                            {
                                mTaskRecordDetail.TR_Apporval = 4;

                                if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut(mTaskRecordDetail) > 0)
                                {

                                    mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                    //TaskIn Date reset to Current Datetime
                                    dateTimePickerTaskIn.Value = ServerDateTime();

                                    //Enable Task Out button
                                    //dateTimePickerTaskIn.Enabled = true;
                                    cmbProject.Enabled = true;
                                    cmbShipment.Enabled = true;
                                    txtFileName.Enabled = true;
                                    btnTaskIn.Enabled = true;

                                    dateTimePickerTaskOut.Enabled = false;
                                    btnTaskOut.Enabled = false;
                                    numericUpDownFileSize.Enabled = false;
                                    cmbTaskStatus.Enabled = false;
                                    lblElapseTime.Visible = false;
                                    lblElapseTimeToFill.Visible = false;

                                    MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + cmbtaskCode.Text, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    RefreshData();
                                    ClearFields();
                                }
                            }
                        }

                        else if (cCheckSkippedTask == 0) /* Skip User output validation by task Code */
                        {

                            //Validate from PCP Details table
                            if (ActualFileSize < numericUpDownFileSize.Value)
                            {

                                MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile size exceeded actual file size.\n\nActual File Size: " + ActualFileSize + "\nEntered File Size: " + numericUpDownFileSize.Value, "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                numericUpDownFileSize.Focus();
                                return;

                            }

                            //Validate from User PCP Details history
                            if (ActualFileSize < numericUpDownFileSize.Value + PendingHistoryCount)
                            {

                                MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile size exceeded actual file size.\n\nActual File Size: " + ActualFileSize + "\nHistory of File Size: " + PendingHistoryCount + "\nRest File Size: [" + (ActualFileSize - PendingHistoryCount) + "]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                numericUpDownFileSize.Focus();
                                return;

                            }

                            //Pending validate
                            if (ActualFileSize == numericUpDownFileSize.Value + PendingHistoryCount && cmbTaskStatus.Text == "Pending")
                            {

                                MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile size is matching to Actual file size on \"Pending\" category.\nPlease reduce the file size or select task \"Done\".\nActual File Size: " + ActualFileSize + "\nHistory of File Size: " + PendingHistoryCount + "\nRest File Size: [" + (ActualFileSize - PendingHistoryCount) + "]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                numericUpDownFileSize.Focus();
                                return;

                            }

                            //Done validate
                            if (ActualFileSize != numericUpDownFileSize.Value + PendingHistoryCount && cmbTaskStatus.Text == "Done")
                            {

                                MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile size is not matching to Actual file size on \"Done\" category.\nPlease verify your file size to the actual page count.\n\nActual File Size: " + ActualFileSize + "\nHistory of File Size: " + PendingHistoryCount + "\nRest File Size: [" + (ActualFileSize - PendingHistoryCount) + "]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                numericUpDownFileSize.Focus();
                                return;

                            }

                            //QR - Book Count - Done
                            if (lblPagesKB.Text == "Book Count" && cmbTaskStatus.Text == "Done")
                            {

                                string PCPCode = txtJobCode.Text;
                                string Task_ID = cTaskCode;
                                string TR_File = txtFileName.Text;
                                string TR_Shipment = cmbShipment.Text;
                                int TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                                DateTime TR_OutDate = dateTimePickerTaskOut.Value;

                                //Actual TaskIn
                                if (FisrtPendingHistoryTaskIn == DateTime.Parse("1/1/1753 00:00:00 AM") || FisrtPendingHistoryTaskIn == null)
                                {
                                    mTaskRecordDetail.TR_InDate = DateTime.Parse(mTaskrecord.Rows[0][5].ToString());
                                }
                                else
                                {
                                    mTaskRecordDetail.TR_InDate = FisrtPendingHistoryTaskIn;
                                }

                                //Initialize Task Record
                                mTaskRecordDetail.TR_File = TR_File;
                                mTaskRecordDetail.TR_Shipment = TR_Shipment;
                                mTaskRecordDetail.Task_ID = Task_ID;
                                mTaskRecordDetail.TR_Status = 3;/* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                                cPCPStatus = 3;
                                mTaskRecordDetail.TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                                mTaskRecordDetail.TR_OutDate = TR_OutDate;
                                mTaskRecordDetail.TR_Apporval = 1;

                                //Time Calcuation for Done Record
                                float PendingHistoryHoursCount = mTaskRecordDetailMng.GetActualHoursCountForPending(PCPCode, Task_ID, TR_File);

                                //Time Calculation
                                double qrhours = hours + PendingHistoryHoursCount;

                                mTaskRecordDetail.TR_Hours = float.Parse(qrhours.ToString());

                                //Productivity Calculate
                                float cPrductDivedeByQuota = float.Parse(numericUpDownFileSize.Value.ToString()) / QuotaSize;
                                float cPrductDivedeByTime = (9 / float.Parse(qrhours.ToString()));

                                float cProductivity = (cPrductDivedeByQuota * cPrductDivedeByTime) * 100;

                                mTaskRecordDetail.TR_Productivity = cProductivity;

                                //Is task record Exist
                                if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(Task_ID, PCPCode, uUID))
                                {
                                    if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut_ActualTaskIn(mTaskRecordDetail) > 0)
                                    {
                                        mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                        //TaskIn Date reset to Current Datetime
                                        dateTimePickerTaskIn.Value = ServerDateTime();

                                        //Enable Task Out button
                                        //dateTimePickerTaskIn.Enabled = true;
                                        cmbProject.Enabled = true;
                                        cmbShipment.Enabled = true;
                                        txtFileName.Enabled = true;
                                        btnTaskIn.Enabled = true;

                                        dateTimePickerTaskOut.Enabled = false;
                                        btnTaskOut.Enabled = false;
                                        numericUpDownFileSize.Enabled = false;
                                        cmbTaskStatus.Enabled = false;
                                        lblElapseTime.Visible = false;
                                        lblElapseTimeToFill.Visible = false;

                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + Task_ID, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        RefreshData();
                                        ClearFields();
                                    }
                                }

                            }

                            //On Hold
                            else if (cmbTaskStatus.Text == "On Hold")
                            {
                                //Cast Task Details
                                mTaskRecordDetail.TR_Productivity = 0;
                                mTaskRecordDetail.TR_Apporval = 4;

                                //Is task record Exist
                                if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(cTaskCode, cPCPCode, uUID))
                                {
                                    if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut(mTaskRecordDetail) > 0)
                                    {
                                        mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                        mPCPDetailMng.UpdatePCPDetailToOnhold(cPCPCode, cPCPStatus, cDateTime); //On hold other pending tsaks On same PCP Code

                                        //TaskIn Date reset to Current Datetime
                                        dateTimePickerTaskIn.Value = ServerDateTime();

                                        //Enable Task Out button
                                        //dateTimePickerTaskIn.Enabled = true;
                                        cmbProject.Enabled = true;
                                        cmbShipment.Enabled = true;
                                        txtFileName.Enabled = true;
                                        btnTaskIn.Enabled = true;


                                        dateTimePickerTaskOut.Enabled = false;
                                        btnTaskOut.Enabled = false;
                                        numericUpDownFileSize.Enabled = false;
                                        cmbTaskStatus.Enabled = false;
                                        lblElapseTime.Visible = false;
                                        lblElapseTimeToFill.Visible = false;

                                        MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + cmbtaskCode.Text, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        RefreshData();
                                        ClearFields();
                                    }
                                }
                            }

                            else if (cmbTaskStatus.Text == "Done" || (cmbTaskStatus.Text == "Done" && lblPagesKB.Text != "Book Count") || (cmbTaskStatus.Text == "Done" && lblPagesKB.Text != "Byte Size"))
                            {
                                string PCPCode = txtJobCode.Text;
                                string Task_ID = cTaskCode;
                                string TR_File = txtFileName.Text;
                                string TR_Shipment = cmbShipment.Text;
                                int TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                                DateTime TR_OutDate = dateTimePickerTaskOut.Value;

                                //Initialize Task Record
                                mTaskRecordDetail.TR_File = TR_File;
                                mTaskRecordDetail.TR_Shipment = TR_Shipment;
                                mTaskRecordDetail.Task_ID = Task_ID;
                                mTaskRecordDetail.TR_Status = 3;/* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                                cPCPStatus = 3;
                                mTaskRecordDetail.TR_OutDate = TR_OutDate;
                                mTaskRecordDetail.TR_Apporval = 1;


                                //Update Done record with pending fize size
                                mTaskRecordDetail.TR_FileSize = (int.Parse(numericUpDownFileSize.Value.ToString()) + PendingHistoryCount);

                                //Time Calcuation for Done Record
                                float PendingHistoryHoursCount = mTaskRecordDetailMng.GetActualHoursCountForPending(PCPCode, Task_ID, TR_File);

                                //Time Calculation
                                double qrhours = hours + PendingHistoryHoursCount;

                                mTaskRecordDetail.TR_Hours = float.Parse(qrhours.ToString());

                                //Actual TaskIn
                                if (FisrtPendingHistoryTaskIn == DateTime.Parse("1/1/1753 00:00:00 AM") || FisrtPendingHistoryTaskIn == null)
                                {
                                    mTaskRecordDetail.TR_InDate = DateTime.Parse(mTaskrecord.Rows[0][5].ToString());
                                }
                                else
                                {
                                    mTaskRecordDetail.TR_InDate = FisrtPendingHistoryTaskIn;
                                }

                                //Productivity Calculate
                                float cPrductDivedeByQuota = (float.Parse(numericUpDownFileSize.Value.ToString()) + PendingHistoryCount) / QuotaSize;
                                float cPrductDivedeByTime = (9 / float.Parse(qrhours.ToString()));

                                float cProductivity = (cPrductDivedeByQuota * cPrductDivedeByTime) * 100;

                                mTaskRecordDetail.TR_Productivity = cProductivity;

                                //Is task record Exist
                                if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(Task_ID, PCPCode, uUID))
                                {
                                    if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut_ActualTaskIn(mTaskRecordDetail) > 0)
                                    {
                                        mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                        //TaskIn Date reset to Current Datetime
                                        dateTimePickerTaskIn.Value = ServerDateTime();

                                        //Enable Task Out button
                                        //dateTimePickerTaskIn.Enabled = true;
                                        cmbProject.Enabled = true;
                                        cmbShipment.Enabled = true;
                                        txtFileName.Enabled = true;
                                        btnTaskIn.Enabled = true;

                                        dateTimePickerTaskOut.Enabled = false;
                                        btnTaskOut.Enabled = false;
                                        numericUpDownFileSize.Enabled = false;
                                        cmbTaskStatus.Enabled = false;
                                        lblElapseTime.Visible = false;
                                        lblElapseTimeToFill.Visible = false;

                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + Task_ID, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        RefreshData();
                                        ClearFields();
                                    }
                                }
                            }

                            //Is task record Exist
                            else if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(cTaskCode, cPCPCode, uUID))
                            {
                                mTaskRecordDetail.TR_Apporval = 4;

                                if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut(mTaskRecordDetail) > 0)
                                {

                                    mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                    //TaskIn Date reset to Current Datetime
                                    dateTimePickerTaskIn.Value = ServerDateTime();

                                    //Enable Task Out button
                                    //dateTimePickerTaskIn.Enabled = true;
                                    cmbProject.Enabled = true;
                                    cmbShipment.Enabled = true;
                                    txtFileName.Enabled = true;
                                    btnTaskIn.Enabled = true;

                                    dateTimePickerTaskOut.Enabled = false;
                                    btnTaskOut.Enabled = false;
                                    numericUpDownFileSize.Enabled = false;
                                    cmbTaskStatus.Enabled = false;
                                    lblElapseTime.Visible = false;
                                    lblElapseTimeToFill.Visible = false;

                                    MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + cmbtaskCode.Text, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    RefreshData();
                                    ClearFields();
                                }
                            }
                        }
                        else
                        {
                            //QR - Book Count - Done
                            if (lblPagesKB.Text == "Book Count" && cmbTaskStatus.Text == "Done")
                            {

                                string PCPCode = txtJobCode.Text;
                                string Task_ID = cTaskCode;
                                string TR_File = txtFileName.Text;
                                string TR_Shipment = cmbShipment.Text;
                                int TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                                DateTime TR_OutDate = dateTimePickerTaskOut.Value;

                                //Actual TaskIn
                                if (FisrtPendingHistoryTaskIn == DateTime.Parse("1/1/1753 00:00:00 AM") || FisrtPendingHistoryTaskIn == null)
                                {
                                    mTaskRecordDetail.TR_InDate = DateTime.Parse(mTaskrecord.Rows[0][5].ToString());
                                }
                                else
                                {
                                    mTaskRecordDetail.TR_InDate = FisrtPendingHistoryTaskIn;
                                }

                                //Initialize Task Record
                                mTaskRecordDetail.TR_File = TR_File;
                                mTaskRecordDetail.TR_Shipment = TR_Shipment;
                                mTaskRecordDetail.Task_ID = Task_ID;
                                mTaskRecordDetail.TR_Status = 3;/* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                                cPCPStatus = 3;
                                mTaskRecordDetail.TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                                mTaskRecordDetail.TR_OutDate = TR_OutDate;
                                mTaskRecordDetail.TR_Apporval = 1;

                                //Time Calcuation for Done Record
                                float PendingHistoryHoursCount = mTaskRecordDetailMng.GetActualHoursCountForPending(PCPCode, Task_ID, TR_File);

                                //Time Calculation
                                double qrhours = hours + PendingHistoryHoursCount;

                                mTaskRecordDetail.TR_Hours = float.Parse(qrhours.ToString());

                                //Productivity Calculate
                                float cPrductDivedeByQuota = float.Parse(numericUpDownFileSize.Value.ToString()) / QuotaSize;
                                float cPrductDivedeByTime = (9 / float.Parse(qrhours.ToString()));

                                float cProductivity = (cPrductDivedeByQuota * cPrductDivedeByTime) * 100;

                                mTaskRecordDetail.TR_Productivity = cProductivity;

                                //Is task record Exist
                                if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(Task_ID, PCPCode, uUID))
                                {
                                    if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut_ActualTaskIn(mTaskRecordDetail) > 0)
                                    {
                                        mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                        //TaskIn Date reset to Current Datetime
                                        dateTimePickerTaskIn.Value = ServerDateTime();

                                        //Enable Task Out button
                                        //dateTimePickerTaskIn.Enabled = true;
                                        cmbProject.Enabled = true;
                                        cmbShipment.Enabled = true;
                                        txtFileName.Enabled = true;
                                        btnTaskIn.Enabled = true;

                                        dateTimePickerTaskOut.Enabled = false;
                                        btnTaskOut.Enabled = false;
                                        numericUpDownFileSize.Enabled = false;
                                        cmbTaskStatus.Enabled = false;
                                        lblElapseTime.Visible = false;
                                        lblElapseTimeToFill.Visible = false;

                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + Task_ID, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        RefreshData();
                                        ClearFields();
                                    }
                                }

                            }

                            //On Hold
                            else if (cmbTaskStatus.Text == "On Hold")
                            {
                                //Cast Task Details
                                mTaskRecordDetail.TR_Productivity = 0;
                                mTaskRecordDetail.TR_Apporval = 4;

                                //Is task record Exist
                                if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(cTaskCode, cPCPCode, uUID))
                                {
                                    if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut(mTaskRecordDetail) > 0)
                                    {
                                        mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                        mPCPDetailMng.UpdatePCPDetailToOnhold(cPCPCode, cPCPStatus, cDateTime); //On hold other pending tsaks On same PCP Code

                                        //TaskIn Date reset to Current Datetime
                                        dateTimePickerTaskIn.Value = ServerDateTime();

                                        //Enable Task Out button
                                        //dateTimePickerTaskIn.Enabled = true;
                                        cmbProject.Enabled = true;
                                        cmbShipment.Enabled = true;
                                        txtFileName.Enabled = true;
                                        btnTaskIn.Enabled = true;


                                        dateTimePickerTaskOut.Enabled = false;
                                        btnTaskOut.Enabled = false;
                                        numericUpDownFileSize.Enabled = false;
                                        cmbTaskStatus.Enabled = false;
                                        lblElapseTime.Visible = false;
                                        lblElapseTimeToFill.Visible = false;

                                        MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + cmbtaskCode.Text, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        RefreshData();
                                        ClearFields();
                                    }
                                }
                            }

                            else if (cmbTaskStatus.Text == "Done" || (cmbTaskStatus.Text == "Done" && lblPagesKB.Text != "Book Count") || (cmbTaskStatus.Text == "Done" && lblPagesKB.Text != "Byte Size"))
                            {
                                string PCPCode = txtJobCode.Text;
                                string Task_ID = cTaskCode;
                                string TR_File = txtFileName.Text;
                                string TR_Shipment = cmbShipment.Text;
                                int TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                                DateTime TR_OutDate = dateTimePickerTaskOut.Value;

                                //Initialize Task Record
                                mTaskRecordDetail.TR_File = TR_File;
                                mTaskRecordDetail.TR_Shipment = TR_Shipment;
                                mTaskRecordDetail.Task_ID = Task_ID;
                                mTaskRecordDetail.TR_Status = 3;/* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                                cPCPStatus = 3;
                                mTaskRecordDetail.TR_OutDate = TR_OutDate;
                                mTaskRecordDetail.TR_Apporval = 1;


                                //Update Done record with pending fize size
                                mTaskRecordDetail.TR_FileSize = (int.Parse(numericUpDownFileSize.Value.ToString()) + PendingHistoryCount);

                                //Time Calcuation for Done Record
                                float PendingHistoryHoursCount = mTaskRecordDetailMng.GetActualHoursCountForPending(PCPCode, Task_ID, TR_File);

                                //Time Calculation
                                double qrhours = hours + PendingHistoryHoursCount;

                                mTaskRecordDetail.TR_Hours = float.Parse(qrhours.ToString());

                                //Actual TaskIn
                                if (FisrtPendingHistoryTaskIn == DateTime.Parse("1/1/1753 00:00:00 AM") || FisrtPendingHistoryTaskIn == null)
                                {
                                    mTaskRecordDetail.TR_InDate = DateTime.Parse(mTaskrecord.Rows[0][5].ToString());
                                }
                                else
                                {
                                    mTaskRecordDetail.TR_InDate = FisrtPendingHistoryTaskIn;
                                }

                                //Productivity Calculate
                                float cPrductDivedeByQuota = (float.Parse(numericUpDownFileSize.Value.ToString()) + PendingHistoryCount) / QuotaSize;
                                float cPrductDivedeByTime = (9 / float.Parse(qrhours.ToString()));

                                float cProductivity = (cPrductDivedeByQuota * cPrductDivedeByTime) * 100;

                                mTaskRecordDetail.TR_Productivity = cProductivity;

                                //Is task record Exist
                                if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(Task_ID, PCPCode, uUID))
                                {
                                    if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut_ActualTaskIn(mTaskRecordDetail) > 0)
                                    {
                                        mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                        //TaskIn Date reset to Current Datetime
                                        dateTimePickerTaskIn.Value = ServerDateTime();

                                        //Enable Task Out button
                                        //dateTimePickerTaskIn.Enabled = true;
                                        cmbProject.Enabled = true;
                                        cmbShipment.Enabled = true;
                                        txtFileName.Enabled = true;
                                        btnTaskIn.Enabled = true;

                                        dateTimePickerTaskOut.Enabled = false;
                                        btnTaskOut.Enabled = false;
                                        numericUpDownFileSize.Enabled = false;
                                        cmbTaskStatus.Enabled = false;
                                        lblElapseTime.Visible = false;
                                        lblElapseTimeToFill.Visible = false;

                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + Task_ID, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        RefreshData();
                                        ClearFields();
                                    }
                                }
                            }

                            //Is task record Exist
                            else if (mTaskRecordDetailMng.TaskTaskInDetailIsExist(cTaskCode, cPCPCode, uUID))
                            {
                                mTaskRecordDetail.TR_Apporval = 4;

                                if (mTaskRecordDetailMng.UpdateTaskRecordDetailToTaskOut(mTaskRecordDetail) > 0)
                                {

                                    mPCPDetailMng.UpdatePCPDetailToPending(cPCPCode, cTaskCode, cPCPStatus, cDateTime); //Update PCP status with user task status

                                    //TaskIn Date reset to Current Datetime
                                    dateTimePickerTaskIn.Value = ServerDateTime();

                                    //Enable Task Out button
                                    //dateTimePickerTaskIn.Enabled = true;
                                    cmbProject.Enabled = true;
                                    cmbShipment.Enabled = true;
                                    txtFileName.Enabled = true;
                                    btnTaskIn.Enabled = true;

                                    dateTimePickerTaskOut.Enabled = false;
                                    btnTaskOut.Enabled = false;
                                    numericUpDownFileSize.Enabled = false;
                                    cmbTaskStatus.Enabled = false;
                                    lblElapseTime.Visible = false;
                                    lblElapseTimeToFill.Visible = false;

                                    MetroMessageBox.Show(MetroForm.ActiveForm, "\nYou are sucessfully task out from " + cmbtaskCode.Text, "Task Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    RefreshData();
                                    ClearFields();
                                }
                            }
                        }

                    }

                }

            }
            else
            {
                return;
            }

        }

        //Refresh button
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            string uUID = lblUIDToFill.Text;
            string mMUID = lblManagerUIDToFill.Text;
            int mTaskRecordStatus = new TaskRecordDetailMng(this.conn).GetTaskStatusByPCPCode(txtJobCode.Text, uUID);

            if (mTaskRecordStatus == 1)
            {
                RefreshData();
            }
            else
            {
                RefreshData();
                ClearFields();
            }

        }

        //Run Timer TaskOut
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            dateTimePickerTaskOut.Text = ServerDateTime().ToLongTimeString();

            //Elapse Time
            TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;
            double hours = diff.TotalHours;

            lblElapseTimeToFill.Text = "[" + diff.Hours.ToString("0#") + ":" + diff.Minutes.ToString("0#") + ":" +diff.Seconds.ToString("0#")+"]";
        }


        private void tglModified_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridViewTaskInOut_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string uUID = lblUIDToFill.Text;

            if (tglModified.Checked)
            {
                if (e.ColumnIndex == 0)
                {
                    if (!String.IsNullOrEmpty((string)e.Value))
                    {
                        string mTRID = e.Value.ToString();

                        bool mModifiedRecord = new TaskRecordHeaderModifyMng(this.conn).TaskRecordmodifiedHeaderIsExist(mTRID);

                        if (mModifiedRecord)
                        {
                            // Get a reference to the cell
                            DataGridViewCell cell = this.dataGridViewTaskInOut.Rows[e.RowIndex].Cells[e.ColumnIndex];

                            // Set the tooltip text
                            cell.ToolTipText = "[Modified Record]: Please check Task Hours & Productivity fields.";
                            e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#e2da00");
                        }
                    }
                }

            }
            else
            {
                if (e.ColumnIndex == 0)
                {
                    if (!String.IsNullOrEmpty((string)e.Value))
                    {
                        // Get a reference to the cell
                        DataGridViewCell cell = this.dataGridViewTaskInOut.Rows[e.RowIndex].Cells[e.ColumnIndex];

                        // Set the tooltip text
                        cell.ToolTipText = null;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");

                    }
                }

                
                
            }
            

            /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
            if (e.ColumnIndex == 7)
            {
                if ((int)e.Value == 0)
                {
                    e.Value = "Fresh";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                }
                else if ((int)e.Value == 1)
                {
                    e.Value = "On Hold";
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

            
            if (e.ColumnIndex == 11)
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
                else if ((int)e.Value == 4)
                {
                    e.Value = "Skipped";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");
                }
            }

            //Round Up
            if (e.ColumnIndex == 10)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("0.###");

            }

            if (e.ColumnIndex == 13)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("0.###")+"%";

                if (d == 0)
                {
                    e.Value = "Not Calcutated";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");
                }
            }

            
            

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

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            //Show Mdofied false
            tglModified.Checked = false;

            int mTaskRecordStatus = new TaskRecordDetailMng(this.conn).GetTaskStatusByPCPCode(txtJobCode.Text, lblUIDToFill.Text);
            if (mTaskRecordStatus == 1)
            {
                cmbTaskStatus.SelectedIndex = -1;
                numericUpDownFileSize.Value = 0;
            }
            else
            {
                ClearFields();
            }
           
        }

        //Activated window
        private void frm_TaskInOut_Activated(object sender, EventArgs e)
        {
            string uUID = lblUIDToFill.Text;           

            dataGridViewTaskInOut.DataSource = new TaskRecordDetailMng(this.conn).GetAllTaskDetailsByUserUID(uUID);
        }

        //TaskIn Check
        public void Check_TaskIn()
        {
            string uUID = lblUIDToFill.Text;
            string mMUID = lblManagerUIDToFill.Text;

            DataTable mTaskrecord = new TaskRecordDetailMng(this.conn).GetTaskedInRecordByUser(uUID);

            if (mTaskrecord.Rows.Count != 0)
            {
                lblPagesKB.Visible = false;

                timer1.Enabled = true;
                timer1.Interval = 1000;


                cmbProject.Enabled = false;
                cmbShipment.Enabled = false;
                cmbtaskCode.Enabled = false;
                txtFileName.Enabled = false;
                lblElapseTime.Visible = true;
                lblElapseTimeToFill.Visible = true;
                cmbProject.DataSource = null;
                cmbShipment.DataSource = null;
                cmbtaskCode.DataSource = null;

                // Set the Format type and the CustomFormat string.
                dateTimePickerTaskIn.Format = DateTimePickerFormat.Custom;
                dateTimePickerTaskIn.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
                dateTimePickerTaskIn.ShowUpDown = true;
                dateTimePickerTaskIn.Enabled = false;
                btnTaskIn.Enabled = false;

                dateTimePickerTaskOut.Format = DateTimePickerFormat.Custom;
                dateTimePickerTaskOut.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
                dateTimePickerTaskOut.ShowUpDown = true;
                dateTimePickerTaskOut.Enabled = false;

                cmbProject.Items.Add(mTaskrecord.Rows[0][0].ToString());
                cmbProject.SelectedIndex = 0;
                cmbShipment.Text = mTaskrecord.Rows[0][1].ToString();
                txtFileName.Text = mTaskrecord.Rows[0][2].ToString();
                txtJobCode.Text = mTaskrecord.Rows[0][3].ToString();
                cmbtaskCode.Items.Add(mTaskrecord.Rows[0][4].ToString());
                cmbtaskCode.SelectedIndex = 0;
                dateTimePickerTaskIn.Value = DateTime.Parse(mTaskrecord.Rows[0][5].ToString());

                string mPendingTask = new PCPDetailMng(this.conn).GetPendingTaskByPCPCode(txtJobCode.Text, lblUIDToFill.Text);


                //Pending task Message
                if (!String.IsNullOrEmpty(mPendingTask))
                {
                    lblTaskPendingMessage.Visible = true;
                    lblTaskPendingMessage.Text = "[Pending Stage]: " + mPendingTask;
                }
                else
                {
                    lblTaskPendingMessage.Visible = false;
                }

                //Tasked in Message
                lblTaskInMessage.Visible = true;
                lblTaskInMessage.Text = "Currenlty you are tasked in! ";

                //dateTimePickerTaskOut.Enabled = true;
                btnTaskOut.Enabled = true;
                numericUpDownFileSize.Enabled = true;
                cmbTaskStatus.Enabled = true;

                RefreshData();

            }
            else
            {
                lblPagesKB.Visible = false;

               
                //Refresh data fields
                RefreshData();

                //Clear All Fields when Load
                ClearFields();

                // Set the Format type and the CustomFormat string.
                dateTimePickerTaskIn.Format = DateTimePickerFormat.Custom;
                dateTimePickerTaskIn.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
                dateTimePickerTaskIn.ShowUpDown = true;

                dateTimePickerTaskOut.Format = DateTimePickerFormat.Custom;
                dateTimePickerTaskOut.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
                dateTimePickerTaskOut.ShowUpDown = true;

                lblElapseTime.Visible = false;
                lblElapseTimeToFill.Visible = false;
            }
        }

        private void cmbTaskStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTaskStatus.Text=="Pending" && lblPagesKB.Text== "Byte Size")
            {
                lblBytePendingMessage.Visible = true;
                lblBytePendingMessage.Text = "[You can apply file size when you are done the file. Otherwise you can not fill file size on \"Pending\" stage.]";

                numericUpDownFileSize.Enabled = false;
                btnTaskOut.Focus();
            }
            else if (cmbTaskStatus.Text == "Done" && lblPagesKB.Text == "Byte Size")
            {
                lblBytePendingMessage.Visible = true;
                lblBytePendingMessage.Text = "[Please click task out button to get your file size.]";

                numericUpDownFileSize.Enabled = false;
                btnTaskOut.Focus();
            }
            else if (cmbTaskStatus.Text == "Pending" && lblPagesKB.Text == "Book Count")
            {
                lblBytePendingMessage.Visible = true;
                lblBytePendingMessage.Text = "[You can apply file size when you are done the file. Otherwise you can not fill file size on \"Pending\" stage.]";

                numericUpDownFileSize.Enabled = false;
                btnTaskOut.Focus();
            }
            else
            {
                lblBytePendingMessage.Visible = false;
                numericUpDownFileSize.Enabled = true;
            }
        }

        //Export Details
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
                        
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewTaskInOut.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewTaskInOut.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {
                        if (i == 7)
                        {
                            if ((Int32)row.Cells[7].Value == 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][7] = "Fresh";
                            }
                            else if ((Int32)row.Cells[7].Value == 1)
                            {
                                dt.Rows[dt.Rows.Count - 1][7] = "On Hold";
                            }
                            else if ((Int32)row.Cells[7].Value == 2)
                            {
                                dt.Rows[dt.Rows.Count - 1][7] = "Pending";
                            }
                            else if ((Int32)row.Cells[7].Value == 3)
                            {
                                dt.Rows[dt.Rows.Count - 1][7] = "Done";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][7] = row.Cells[7].Value.ToString();
                            }

                        }
                        else if (i == 10)
                        {
                            dt.Rows[dt.Rows.Count - 1][10] = double.Parse(row.Cells[10].Value.ToString()).ToString("0.###");

                        }
                        else if (i == 11)
                        {

                            if ((Int32)row.Cells[11].Value == 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][11] = "No Status";
                            }
                            else if ((Int32)row.Cells[11].Value == 1)
                            {
                                dt.Rows[dt.Rows.Count - 1][11] = "Pending";
                            }
                            else if ((Int32)row.Cells[11].Value == 2)
                            {
                                dt.Rows[dt.Rows.Count - 1][11] = "Approved";
                            }
                            else if ((Int32)row.Cells[11].Value == 3)
                            {
                                dt.Rows[dt.Rows.Count - 1][11] = "Disapproved";
                            }
                            else if ((Int32)row.Cells[11].Value == 4)
                            {
                                dt.Rows[dt.Rows.Count - 1][11] = "Skipped";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][11] = row.Cells[11].Value.ToString();
                            }

                        }
                        else if (i == 13)
                        {
                            if ((Int32)row.Cells[11].Value == 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][13] = "Not Calcutated";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][13] = double.Parse(row.Cells[13].Value.ToString()).ToString("0.###") + "%";
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
                                var ws = wb.Worksheets.Add(dt, "CITITO_" + lblUIDToFill.Text + "_Task Records");
                                ws.Range("E2:E1048576").CellsUsed().SetDataType(XLDataType.Number);
                                ws.Range("K2:K1048576").CellsUsed().SetDataType(XLDataType.Number);
                                ws.Range("N2:N1048576").CellsUsed().SetDataType(XLDataType.Number);

                                ws.Columns().AdjustToContents();
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask In/Out Records successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + lblUIDToFill.Text + "_Task Records");
                            ws.Range("E2:E1048576").CellsUsed().SetDataType(XLDataType.Number);
                            ws.Range("K2:K1048576").CellsUsed().SetDataType(XLDataType.Number);
                            ws.Range("N2:N1048576").CellsUsed().SetDataType(XLDataType.Number);

                            ws.Columns().AdjustToContents();
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask In/Out Records successfully export to  \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        //Auto update fields user click cell
        private void dataGridViewTaskInOut_Click(object sender, EventArgs e)
        {
            if (dataGridViewTaskInOut.Rows.Count!=0 && lblTaskInMessage.Visible==false && String.IsNullOrEmpty(txtJobCode.Text))
            {
                string uProject = new PCPDetailMng(this.conn).GetProjectByPCPCode(dataGridViewTaskInOut.SelectedRows[0].Cells[1].Value.ToString());
                cmbProject.SelectedItem = uProject;
                cmbShipment.Text = dataGridViewTaskInOut.SelectedRows[0].Cells[2].Value.ToString();
                txtFileName.Text = dataGridViewTaskInOut.SelectedRows[0].Cells[3].Value.ToString();
                txtFileName.Focus();
                //txtFileName.KeyDown += new KeyEventHandler(txtFileName_KeyDown);
            }
            
        }

        //Sugesstion box for fresh files
        private void cmbShipment_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(cmbShipment.Text))
            {
                AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
                DataTable drt = new PCPDetailMng(this.conn).ListAllFreshFilesByProjectAndShipment(lblManagerUIDToFill.Text, cmbProject.Text, cmbShipment.Text);

                if (drt.Rows.Count != 0 && !String.IsNullOrEmpty(cmbShipment.Text))
                {
                    for (int i = 0; i < drt.Rows.Count; i++)
                    {
                        namesCollection.Add(drt.Rows[i][0].ToString());
                    }
                    txtFileName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtFileName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtFileName.AutoCompleteCustomSource = namesCollection;
                }
                else
                {
                    txtFileName.AutoCompleteCustomSource = null;
                }
            }

        }

        private void txtJobCode_KeyDown(object sender, KeyEventArgs e)
        {
            string uUID = lblUIDToFill.Text;
            if (e.KeyCode == Keys.Enter)
            {
                
                try
                {
                    if (new PCPDetailMng(this.conn).IsExistPCPCode(txtJobCode.Text) == false)
                    {
                        MetroMessageBox.Show(MetroForm.ActiveForm, "\nJob code is not found. Please check job code again.", "Invalid Job Code!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFileName.Focus();
                        return;

                    }
                    else
                    {
                        ////Validate task Done
                        if (new PCPDetailMng(this.conn).GetTaskCodeByPCPCodeAndStatusNotDoneOrHold(txtJobCode.Text).Count() == 0)
                        {
                            MetroMessageBox.Show(MetroForm.ActiveForm, "\nAll the tasks for the file \"" + txtJobCode.Text + "\" are done.\nPlease enter a new job code.", "Invalid Job Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtFileName.Focus();
                            return;
                        }
                        else
                        {
                            //Activate fileds
                            
                            //dateTimePickerTaskIn.Enabled = true;
                            btnTaskIn.Enabled = true;
                            //dateTimePickerTaskOut.Enabled = true;
                            btnTaskOut.Enabled = true;
                            txtFileName.Enabled = false;
                            cmbShipment.Enabled = false;
                            txtJobCode.Enabled = false;
                            cmbtaskCode.Enabled = true;
                            numericUpDownFileSize.Enabled = true;

                            //Next to be fill
                            cmbtaskCode.Focus();



                            //Update fields with PCP Code 
                            cmbProject.SelectedItem = new PCPDetailMng(this.conn).GetProjectByPCPCode_TaskInOut(txtJobCode.Text).ToString();
                            cmbShipment.Text = new PCPDetailMng(this.conn).GetShipmentByPCPCode_TaskInOut(txtJobCode.Text);
                            txtFileName.Text = new PCPDetailMng(this.conn).GetFileNameByPCPCode_TaskInOut(txtJobCode.Text);
                           
                            

                            if (!String.IsNullOrEmpty(txtJobCode.Text))
                            {
                                //Update Task Codes

                                cmbtaskCode.DataSource = new PCPDetailMng(this.conn).GetTaskCodeByPCPCodeAndStatusNotDoneOrHold(txtJobCode.Text);
                                string mPendingTask = new PCPDetailMng(this.conn).GetPendingTaskByPCPCode(txtJobCode.Text, lblUIDToFill.Text);


                                //Pending task Message
                                if (!String.IsNullOrEmpty(mPendingTask))
                                {
                                    lblTaskPendingMessage.Visible = true;
                                    lblTaskPendingMessage.Text = "[Pending Stage]: " + mPendingTask;
                                }
                                else
                                {
                                    lblTaskPendingMessage.Visible = false;
                                }

                            }

                            //Clear Fileds
                            cmbtaskCode.SelectedIndex = -1;
                            cmbTaskStatus.SelectedIndex = -1;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string uUID = lblUIDToFill.Text;

            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;

            dataGridViewTaskInOut.DataSource = new TaskRecordDetailMng(this.conn).GetAllTaskDetailsByUserUIDAndFromTo(uUID, uFrom, uTo);
        }
    }
}
