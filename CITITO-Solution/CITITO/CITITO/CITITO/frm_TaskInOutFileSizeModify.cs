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

namespace CITITO
{
    public partial class frm_TaskInOutFileSizeModify : MetroForm
    {

        SqlConnection conn;
        int curTaskFileSize;
        int curTaskFileSizeTemp;
        float curTaskHours;
        float curTaskHoursTemp;

        //Start Pass insatance when form is already opend or not
        private static frm_TaskInOutFileSizeModify _instance;
        public static frm_TaskInOutFileSizeModify GetInstance(string uMID, string uTempPIC, string uPIC, string uUID, string uTRID, string uJOBCode, string uShipment, string uFileName, int uOutput, string uUOM, string uTask, int uJobStatus, DateTime uTaskIn, DateTime uTaskOut, float uTaskHours, int uQuota)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMID = uMID;
                String mTempPIC = uTempPIC;
                String mPIC = uPIC;
                String mUID = uUID;
                String mTRID = uTRID;
                String mJOBCode = uJOBCode;
                String mShipment = uShipment;
                String mFileName = uFileName;
                int mOutput = uOutput;
                String mUOM = uUOM;
                String mTask = uTask;
                int mJobStatus = uJobStatus;
                DateTime mTaskIn = uTaskIn;
                DateTime mTaskOut = uTaskOut;
                float mTaskHours = uTaskHours;
                int mQuota = uQuota;

                _instance = new frm_TaskInOutFileSizeModify(mMID, mTempPIC, mPIC, mUID, mTRID, mJOBCode, mShipment, mFileName, mOutput, mUOM, mTask, mJobStatus, mTaskIn, mTaskOut, mTaskHours, mQuota);

            }
            return _instance;

        }

        public frm_TaskInOutFileSizeModify(string uMID, string uTempPIC, string uPIC, string uUID, string uTRID, string uJOBCode, string uShipment, string uFileName, int uOutput, string uUOM, string uTask, int uJobStatus, DateTime uTaskIn, DateTime uTaskOut, float uTaskHours, int uQuota)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblMUID.Text = uMID;
            lblTempPIC.Text = uTempPIC;
            lblPIC.Text = uPIC;
            lblUID.Text = uUID;
            //lblTRID.Text = uTRID;
            lblJobCode.Text = uJOBCode;
            lblShipment.Text = uShipment; //--
            lblFileName.Text = uFileName;
            lblOutput.Text = uOutput.ToString();
            lblUOM.Text = uUOM;
            lblTask.Text = uTask; //--
            lblTaskInFill.Text = uTaskIn.ToString(); //Calculation for Productivity
            lblTaskOutFill.Text = uTaskOut.ToString(); //Calculation for Productivity
            lblHours.Text = uTaskHours.ToString(); //Calculation for Productivity
            lblJobStatus.Text = uJobStatus.ToString(); //--
            tmpFileSize.Text = uOutput.ToString();
            //numericUpDownFileSize.Value = uOutput;
            lblQuota.Text = uQuota.ToString();
            //lblPagesKB.Text = uUOM;
            lblPagesKB.Text = "--";
            //dateTimePickerTaskIn.Value = uTaskIn;
            //dateTimePickerTaskOut.Value = uTaskOut;
            //txtTaskHours.Text = uTaskHours.ToString();

            lblTRID.Text = "--";
            numericUpDownFileSize.Value = 0;
            dateTimePickerTaskIn.Value = ServerDateTime();
            dateTimePickerTaskOut.Value = ServerDateTime();
            txtTaskHours.Text = "0.000";

            //Select a row message
            if (lblTRID.Text == "--" || String.IsNullOrEmpty(lblTRID.Text))
            {
                lblSelectRecorMessage.Visible = true;
                btnModify.Enabled = false;
            }
            else
            {
                lblSelectRecorMessage.Visible = false;
                btnModify.Enabled = true;
            }

            


            dataGridViewTaskInOutForApproval.DataSource = new TaskRecordDetailMng(this.conn).GetApprovedTaskInOutRecordByUIDAndPCPCodeAndTaskCode(uJOBCode, uTask, uUID);

            // Initialize the button column.
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Text = "Edit";
            buttonColumn.AutoSizeMode =
            DataGridViewAutoSizeColumnMode.AllCells;

            // Use the Text property for the button text for all cells rather
            // than using each cell's value as the text for its own button.
            buttonColumn.UseColumnTextForButtonValue = true;

            // Add the button column to the control.
            dataGridViewTaskInOutForApproval.Columns.Insert(0, buttonColumn);


            //Change remove column to last-child
            DataGridViewColumnCollection columnCollection = dataGridViewTaskInOutForApproval.Columns;

            DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
            DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

            int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
            firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
            //lastVisibleColumn.DisplayIndex = firstColumn_sIndex;


        }

        /*CITITO Server Time*/
        public DateTime ServerDateTime()
        {
            ServerTime mServerTime = new ServerTime(this.conn);
            DateTime sDate = mServerTime.getServerTime();
            return sDate;
        }

        //Exit Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
            this.Close();
        }

        private void frm_TaskInOutFileSizeModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147023895)
                {
                    //Do nothing
                }
                else
                {
                    MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string TRMIDGenerate()
        {
            string cTRMID = "";
            TaskRecordDetailModifyMng mTaskRecordDetailModifyMng = new TaskRecordDetailModifyMng(this.conn);
            string uMID = lblMUID.Text;
            int cLastUserRecordNumber = mTaskRecordDetailModifyMng.GetLastRecordCount(uMID);
            int cNewInt = (cLastUserRecordNumber + 1);

            //Task Code from List part 02
            //string cTaskCode = cmbtaskCode.Text;
            //string cProject = cTaskCode.Substring(0, 3);
            string cMonthYear = ServerDateTime().ToString("ddMMyy");

            cTRMID = uMID + cMonthYear + "/" + cNewInt;

            return cTRMID;

        }


        //Modify button
        private void btnModify_Click(object sender, EventArgs e)
        {
            //Validation
            if (String.IsNullOrEmpty(txtTaskHours.Text) || float.Parse(txtTaskHours.Text) <= 0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask hours cannot be less than zero or empty.", "Invalid Task Hours!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerTaskOut.Focus();
                return;
            }

            //if (numericUpDownFileSize.Value==int.Parse(tmpFileSize.Text))
            //{
            //    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIt seems file size is not modified, please change file size.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    numericUpDownFileSize.Focus();
            //    return;
            //}


            if (numericUpDownFileSize.Value <= 0 || String.IsNullOrEmpty(numericUpDownFileSize.Text.ToString()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile size cannot be empty or zero. Please enter a value.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDownFileSize.Focus();
                return;
            }

            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to modify record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Create Objects                
                TaskRecordHeaderModify mTaskRecordHeaderModify = new TaskRecordHeaderModify();
                TaskRecordDetailModify mTaskRecordDetailModify = new TaskRecordDetailModify();
                IDLEDetail mIDLEDetail = new IDLEDetail();

                TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
                TaskRecordHeaderModifyMng mTaskRecordHeaderModifyMng = new TaskRecordHeaderModifyMng(this.conn);
                TaskRecordDetailModifyMng mTaskRecordDetailModifyMng = new TaskRecordDetailModifyMng(this.conn);
                IDLEDetailMng mIDLEDetailMng = new IDLEDetailMng(this.conn);
                PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

                ////Detail               
                String uUID = lblUID.Text;
                String uMID = lblMUID.Text;
                String uPIC = lblPIC.Text;
                DateTime uActualtaskIn = tmpActualTaskIn.Value;
                DateTime uActualtaskOut = tmpActualTaskOut.Value;
                String uJobCode = lblJobCode.Text;
                String uTaskCode = lblTask.Text;
                String uRecordID = lblTRID.Text;
                String uFileName = lblFileName.Text;
                int uOutput = int.Parse(numericUpDownFileSize.Value.ToString());

                //Check DoneSize is match to the Task history
                int ActualFileSize = mPCPDetailMng.GetActualFileSize(uJobCode, uTaskCode);
                int ActualFileSizeSkipVal = mTaskRecordDetailMng.GetActualDoneCountFromRecord(uJobCode, uTaskCode, uUID);
                float ActualFileHours = mTaskRecordDetailMng.GetActualFileHours(uJobCode, uTaskCode, uUID);
                DateTime ActualDoneFirstTaskIn = mTaskRecordDetailMng.GetActualDoneFirstTaskIn(uJobCode, uTaskCode, uUID);
                int PendingHistoryCount = mTaskRecordDetailMng.GetActualFileSizeFroPending(uJobCode, uTaskCode, uFileName);
                float PendingHistoryHours = mTaskRecordDetailMng.GetActualHoursForPending(uJobCode, uTaskCode, uFileName);                

                mIDLEDetail.IDLE_UID = uUID;
                mIDLEDetail.IDLE_InDate = dateTimePickerTaskIn.Value;
                mIDLEDetail.IDLE_OutDate = dateTimePickerTaskOut.Value;


                if (int.Parse(lblTmpSkippedValidation.Text) == 0)//Task Output Validation - yes
                {
                    
                    
                    //Validation Is overwrite other task records time.

                    // +---------------------------------------------
                    //   |  /* 1. Next record Task In */
                    //   |
                    //   |  //Task Out > Task Record Task In
                    //   |
                    //   |    //Message - "Modified Tasked Out time is overlaping next Tasked In record."   
                    // +---------------------------------------------

                    if (mTaskRecordDetailMng.GetRecordsCountForGivenPeriod(uUID, uActualtaskIn, uActualtaskOut) > 1 && mTaskRecordDetailMng.UserNextTaskInRecordIsOverlap(uUID, uActualtaskIn, uActualtaskOut, dateTimePickerTaskOut.Value, uRecordID))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nCannot modify task record due to following reasons.\n\t- Time is overlapping next Tasked In or AMS Logout.\n\t- Incomplete AMS Logins.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePickerTaskOut.Focus();
                        return;
                    }

                    // +---------------------------------------------
                    //   |  /* 2. Previous record Task Out */
                    //   |
                    //   |  //Task In < Task Record Task Out
                    //   |
                    //   |   //Message - "Modified Tasked In time is overlaping previous Tasked Out record."
                    // +---------------------------------------------

                    if (mTaskRecordDetailMng.GetRecordsCountForGivenPeriod(uUID, uActualtaskIn, uActualtaskOut) > 1 && mTaskRecordDetailMng.UserPreviousTaskInRecordIsOverlap(uUID, uActualtaskIn, uActualtaskOut, dateTimePickerTaskIn.Value, uRecordID))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nCannot modify task record due to following reasons.\n\t- Time is overlapping previous Tasked Out or AMS Login.\n\t- Incomplete AMS Logins.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePickerTaskIn.Focus();
                        return;
                    }

                    // +---------------------------------------------
                    //   |
                    //   | AMS Login validations
                    //   |
                    // +---------------------------------------------

                    /*Overlap AMS login*/
                    if (mTaskRecordDetailMng.GetRecordsCountForGivenPeriod(uUID, uActualtaskIn, uActualtaskOut) == 1 && mTaskRecordDetailMng.UserTaskInRecordIsAMSLoginOverlap(uUID, uActualtaskIn, uActualtaskOut, dateTimePickerTaskIn.Value))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nModified Tasked In time is overlaping AMS Login.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePickerTaskIn.Focus();
                        return;
                    }

                    /*Overlap AMS logut*/
                    if (mTaskRecordDetailMng.GetRecordsCountForGivenPeriod(uUID, uActualtaskIn, uActualtaskOut) == 1 && mTaskRecordDetailMng.UserTaskOutRecordIsAMSLogutOverlap(uUID, uActualtaskIn, uActualtaskOut, dateTimePickerTaskOut.Value))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nModified Tasked Out time is overlaping AMS Logout.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePickerTaskOut.Focus();
                        return;
                    }


                    // +---------------------------------------------
                    //   |    /* 1. Next IDLErecord Task In */
                    //   |
                    //   |    //Task Out > IDLE Record Task In
                    //   |
                    //   |    //Message - "Modified Tasked Out time is overlaping next IDLE In record."
                    //   |
                    //   |    /* 2. Previous IDLE record Task Out */
                    //   |
                    //   |    //Task In < IDLE Record Task Out
                    //   |
                    //   |   //Message - "Modified Tasked In time is overlaping previous IDLE Out record."
                    //   |
                    // +---------------------------------------------

                    //Validation Is overwrite IDLE records time.
                    if (mIDLEDetailMng.UserIDLERecordIsExist_taskModify(mIDLEDetail))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIDLE record is already exist for this time span! Please check again.", "IDLE Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //Status Pending
                    if (lblFillStatus.Text=="Pending") 
                    {
                        int ActualDoneCount = (ActualFileSize - PendingHistoryCount);
                        float ActualDoneHours = (ActualFileHours - PendingHistoryHours);
                        DateTime DoneRecordTaskIn = ActualDoneFirstTaskIn;
                        int TasksCountWithoutSelectedTask = ((PendingHistoryCount - curTaskFileSize) + ActualDoneCount);
                        float TasksHoursWithoutSelectedTask = ((PendingHistoryHours - curTaskHours) + ActualDoneHours);
                        
                        /* If Done Record available*/
                        if (mTaskRecordDetailMng.IsTaskDoneRecordAvailable(uUID, uTaskCode, uJobCode))
                        {
                            
                            //If not matching to Output
                            if (ActualFileSize != (PendingHistoryCount - curTaskFileSize) + (uOutput + ActualDoneCount))
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nEntered output is not matching to the Actual file size. Please Check again.\n\nActual File Size: " + ActualFileSize + "\nHistory of File Size: " + (PendingHistoryCount + ActualDoneCount - curTaskFileSize) + "\nAvailable File Size: [" + (ActualFileSize - TasksCountWithoutSelectedTask) + "]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                numericUpDownFileSize.Focus();
                                return;
                            }

                            /* Get Done Record Details*/
                            String uDoneRecordID = mTaskRecordDetailMng.GetTaskDoneRecordID(uUID, uTaskCode, uJobCode);
                            int uActualDoneCount = TasksCountWithoutSelectedTask + uOutput; //Initialized to updated Done record filesize 
                            float uActualDoneHours = TasksHoursWithoutSelectedTask + float.Parse(txtTaskHours.Text); //Initialized to updated Done record Hours 

                            
                            //FirstaskIn Check and update if ealier than existing done record
                            if (dateTimePickerTaskIn.Value < ActualDoneFirstTaskIn)
                            {
                                DoneRecordTaskIn = dateTimePickerTaskIn.Value;
                            }


                            /*Create Modified pending Record first*/

                            //Initialize Values
                            //Header
                            mTaskRecordHeaderModify.PCP_ID = uJobCode;
                            mTaskRecordHeaderModify.TR_ID = uRecordID;
                            mTaskRecordHeaderModify.TRM_ID = TRMIDGenerate();

                            //Detail
                            mTaskRecordDetailModify.TRM_ID = TRMIDGenerate();
                            mTaskRecordDetailModify.TR_UID = uUID;
                            mTaskRecordDetailModify.TRM_MID = uMID;
                            mTaskRecordDetailModify.TRM_PIC = uPIC;
                            mTaskRecordDetailModify.TR_File = uFileName;
                            mTaskRecordDetailModify.TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                            mTaskRecordDetailModify.TRM_ModifiedlTime = ServerDateTime();

                            //Status Pending
                            mTaskRecordDetailModify.TR_Status = 2;
                            
                            mTaskRecordDetailModify.TRM_InDate = dateTimePickerTaskIn.Value;
                            mTaskRecordDetailModify.TRM_OutDate = dateTimePickerTaskOut.Value;
                            mTaskRecordDetailModify.TRM_Hours = float.Parse(txtTaskHours.Text);
                            mTaskRecordDetailModify.TRM_Apporval = 1; /* 1 - Pending, 2 - Approved, 3 - Disapproved */
                            //mTaskRecordDetailModify.TRM_ApprovalTime = null;
                            mTaskRecordDetailModify.TR_UOM = lblPagesKB.Text;

                            //New Productivity calculate according to the modified file size     
                            float cPrductDivedeByQuota = float.Parse(numericUpDownFileSize.Value.ToString()) / int.Parse(lblQuota.Text);
                            float cPrductDivedeByTime = (9 / float.Parse(txtTaskHours.Text));

                            //Productivity = ((output/Quota) * (9/TaskHours)) * 100%
                            float cProductivity = (cPrductDivedeByQuota * cPrductDivedeByTime) * 100;

                            mTaskRecordDetailModify.TRM_Productivity = cProductivity;

                            if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                            {
                                if (mTaskRecordHeaderModifyMng.AddTModifiedHeader(mTaskRecordHeaderModify) > 0)
                                {
                                    //if pending details done write Done Hearder and Detail
                                    if (mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify) > 0)
                                    {
                                        /* Create Modified Done Record */

                                        //Initialize Values
                                        //Header
                                        mTaskRecordHeaderModify.PCP_ID = uJobCode;
                                        mTaskRecordHeaderModify.TR_ID = uDoneRecordID;
                                        mTaskRecordHeaderModify.TRM_ID = TRMIDGenerate();

                                        //Detail
                                        mTaskRecordDetailModify.TRM_ID = TRMIDGenerate();
                                        mTaskRecordDetailModify.TR_UID = uUID;
                                        mTaskRecordDetailModify.TRM_MID = uMID;
                                        mTaskRecordDetailModify.TRM_PIC = uPIC;
                                        mTaskRecordDetailModify.TR_File = uFileName;
                                        mTaskRecordDetailModify.TR_FileSize = uActualDoneCount; //Updated
                                        mTaskRecordDetailModify.TRM_ModifiedlTime = ServerDateTime();

                                        //Status Done
                                        mTaskRecordDetailModify.TR_Status = 3;

                                        mTaskRecordDetailModify.TRM_InDate = DoneRecordTaskIn;
                                        mTaskRecordDetailModify.TRM_OutDate = dateTimePickerTaskOut.Value;
                                        mTaskRecordDetailModify.TRM_Hours = uActualDoneHours;  //Updated
                                        mTaskRecordDetailModify.TRM_Apporval = 1; /* 1 - Pending, 2 - Approved, 3 - Disapproved */
                                        //mTaskRecordDetailModify.TRM_ApprovalTime = null;
                                        mTaskRecordDetailModify.TR_UOM = lblPagesKB.Text;

                                        //New Productivity calculate according to the modified file size     
                                        float cDonePrductDivedeByQuota = float.Parse(uActualDoneCount.ToString()) / int.Parse(lblQuota.Text);
                                        float cDonePrductDivedeByTime = (9 / float.Parse(uActualDoneHours.ToString()));

                                        //Productivity = ((output/Quota) * (9/TaskHours)) * 100%
                                        float cDoneProductivity = (cDonePrductDivedeByQuota * cDonePrductDivedeByTime) * 100;

                                        mTaskRecordDetailModify.TRM_Productivity = cDoneProductivity;
                                       

                                        if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                                        {
                                            if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                                            {
                                                if (mTaskRecordHeaderModifyMng.AddTModifiedHeader(mTaskRecordHeaderModify) > 0)
                                                {
                                                    mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);

                                                }
                                            }
                                        }
                                        else
                                        {
                                            mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                                        }

                                        //MessageBox Here An Exit from Function
                                        //Load Modified records          
                                        String uMUID = uMID;
                                        String uTempPIC = lblTempPIC.Text;

                                        frm_TaskInOutModifiedApproval myForm = frm_TaskInOutModifiedApproval.GetInstance(uTempPIC, uMUID);
                                        frm_ApprovalTaskInOut myForm1 = frm_ApprovalTaskInOut.GetInstance(uTempPIC, uMUID);

                                        myForm.TopLevel = false;
                                        myForm.TopMost = true;
                                        myForm.AutoScroll = false;
                                        myForm.Dock = DockStyle.Fill;
                                        frm_ApprovalTaskInOut form1 = (frm_ApprovalTaskInOut)Application.OpenForms["frm_ApprovalTaskInOut"];
                                        Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
                                        panel1.Controls.Add(myForm);

                                        if (new PICHeaderMng(this.conn).PICIsExist(uTempPIC))
                                        {
                                            myForm.btnApprove.Visible = true;
                                            myForm.btnDisapprove.Visible = true;
                                        }
                                        if (!new PICHeaderMng(this.conn).PICIsExist(uTempPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMUID))
                                        {
                                            myForm.btnApprove.Visible = false;
                                            myForm.btnDisapprove.Visible = false;
                                        }

                                        myForm.Show();
                                        myForm.BringToFront();
                                        myForm.RefreshData();
                                        myForm.ClearFields();

                                        //Call public methods of frm_ApprovalTaskInOut form to hover
                                        myForm1.panelHover.Height = myForm1.tileModifiedApproval.Height;
                                        myForm1.panelHover.Top = myForm1.tileModifiedApproval.Top + myForm1.line.Top + 2;


                                        //Show Completed Message
                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record has been modified!", "Record(s) Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
                                        this.Close();

                                    }
                                }
                            }
                            else
                            {
                                //if pending details done write Done Hearder and Detail
                                if (mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify) > 0)
                                {
                                    /* Create Modified Done Record */

                                    //Initialize Values
                                    //Header
                                    mTaskRecordHeaderModify.PCP_ID = uJobCode;
                                    mTaskRecordHeaderModify.TR_ID = uDoneRecordID;
                                    mTaskRecordHeaderModify.TRM_ID = TRMIDGenerate();

                                    //Detail
                                    mTaskRecordDetailModify.TRM_ID = TRMIDGenerate();
                                    mTaskRecordDetailModify.TR_UID = uUID;
                                    mTaskRecordDetailModify.TRM_MID = uMID;
                                    mTaskRecordDetailModify.TRM_PIC = uPIC;
                                    mTaskRecordDetailModify.TR_File = uFileName;
                                    mTaskRecordDetailModify.TR_FileSize = uActualDoneCount; //Updated
                                    mTaskRecordDetailModify.TRM_ModifiedlTime = ServerDateTime();

                                    //Status Done
                                    mTaskRecordDetailModify.TR_Status = 3;

                                    mTaskRecordDetailModify.TRM_InDate = DoneRecordTaskIn;
                                    mTaskRecordDetailModify.TRM_OutDate = dateTimePickerTaskOut.Value;
                                    mTaskRecordDetailModify.TRM_Hours = uActualDoneHours;  //Updated
                                    mTaskRecordDetailModify.TRM_Apporval = 1; /* 1 - Pending, 2 - Approved, 3 - Disapproved */
                                                                              //mTaskRecordDetailModify.TRM_ApprovalTime = null;
                                    mTaskRecordDetailModify.TR_UOM = lblPagesKB.Text;

                                    //New Productivity calculate according to the modified file size     
                                    float cDonePrductDivedeByQuota = float.Parse(uActualDoneCount.ToString()) / int.Parse(lblQuota.Text);
                                    float cDonePrductDivedeByTime = (9 / float.Parse(uActualDoneHours.ToString()));

                                    //Productivity = ((output/Quota) * (9/TaskHours)) * 100%
                                    float cDoneProductivity = (cDonePrductDivedeByQuota * cDonePrductDivedeByTime) * 100;

                                    mTaskRecordDetailModify.TRM_Productivity = cDoneProductivity;

    
                                    if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                                    {
                                        if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                                        {
                                            if (mTaskRecordHeaderModifyMng.AddTModifiedHeader(mTaskRecordHeaderModify) > 0)
                                            {
                                                mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                                    }

                                    //MessageBox Here An Exit from Function
                                    //Load Modified records          
                                    String uMUID = uMID;
                                    String uTempPIC = lblTempPIC.Text;

                                    frm_TaskInOutModifiedApproval myForm = frm_TaskInOutModifiedApproval.GetInstance(uTempPIC, uMUID);
                                    frm_ApprovalTaskInOut myForm1 = frm_ApprovalTaskInOut.GetInstance(uTempPIC, uMUID);

                                    myForm.TopLevel = false;
                                    myForm.TopMost = true;
                                    myForm.AutoScroll = false;
                                    myForm.Dock = DockStyle.Fill;
                                    frm_ApprovalTaskInOut form1 = (frm_ApprovalTaskInOut)Application.OpenForms["frm_ApprovalTaskInOut"];
                                    Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
                                    panel1.Controls.Add(myForm);

                                    if (new PICHeaderMng(this.conn).PICIsExist(uTempPIC))
                                    {
                                        myForm.btnApprove.Visible = true;
                                        myForm.btnDisapprove.Visible = true;
                                    }
                                    if (!new PICHeaderMng(this.conn).PICIsExist(uTempPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMUID))
                                    {
                                        myForm.btnApprove.Visible = false;
                                        myForm.btnDisapprove.Visible = false;
                                    }

                                    myForm.Show();
                                    myForm.BringToFront();
                                    myForm.RefreshData();
                                    myForm.ClearFields();

                                    //Call public methods of frm_ApprovalTaskInOut form to hover
                                    myForm1.panelHover.Height = myForm1.tileModifiedApproval.Height;
                                    myForm1.panelHover.Top = myForm1.tileModifiedApproval.Top + myForm1.line.Top + 2;


                                    //Show Completed Message
                                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record has been modified!", "Record(s) Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
                                    this.Close();
                                }
                            }

                           
                            //MessageBox.Show("Done Record Available + CHECK OUTPUT - YES + PENDING");
                        }

                        /* If needed please continue below  else part */
                        /*
                         Conclusion: Validate file output if there is not done status record.
                        */

                        //else
                        //{
                        //    //If exceeded output
                        //    if (ActualFileSize < (PendingHistoryCount - curTaskFileSize) + (uOutput))
                        //    {
                        //        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nEntered otput is exceeding Actual file size. Please Check again.\n\nActual File Size: " + ActualFileSize + "\nHistory of File Size: " + (PendingHistoryCount - curTaskFileSize) + "\nAvailable File Size: [" + (ActualFileSize - (PendingHistoryCount - curTaskFileSize)) + "]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        numericUpDownFileSize.Focus();
                        //        return;
                        //    }

                        //    MessageBox.Show("No Done Record + CHECK OUTPUT - YES + PENDING");
                        //}

                    }

                    //Status Done
                    if (lblFillStatus.Text == "Done") 
                    {
                        int ActualDoneCount = (ActualFileSize - PendingHistoryCount);   //Done Count         
                        float ActualDoneHours = (ActualFileHours - PendingHistoryHours); //Done Hours
                        DateTime DoneRecordTaskIn = ActualDoneFirstTaskIn; //Fisrt Task In
                        curTaskFileSizeTemp = ActualDoneCount;
                        curTaskFileSize = curTaskFileSizeTemp;
                        curTaskHoursTemp = ActualDoneHours;
                        curTaskHours = curTaskHoursTemp;


                        int TasksCountWithoutSelectedTask = ((PendingHistoryCount - curTaskFileSize) + ActualDoneCount);
                        float TasksHoursWithoutSelectedTask = ((PendingHistoryHours - curTaskHours) + ActualDoneHours);

                        //If not matching to Output
                        if (ActualDoneCount != uOutput)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nEntered output is not matching to the Actual file size. Please Check again.\n\nActual File Size: " + ActualFileSize + "\nHistory of File Size: " + (ActualFileSize - ActualDoneCount) + "\nAvailable File Size: [" + (ActualFileSize- (ActualFileSize - ActualDoneCount)) + "]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                numericUpDownFileSize.Focus();
                                return;
                        }

                        /* Get Done Record Details*/
                        int uActualDoneCount = TasksCountWithoutSelectedTask + uOutput; //Initialized to updated Done record filesize 
                        float uActualDoneHours = TasksHoursWithoutSelectedTask + float.Parse(txtTaskHours.Text); //Initialized to updated Done record Hours 

                        //FirstaskIn Check and update if ealier than existing done record
                        if (dateTimePickerTaskIn.Value < ActualDoneFirstTaskIn)
                        {
                            DoneRecordTaskIn = dateTimePickerTaskIn.Value;
                        }

                        //If only done record then update modified Actual task in
                        if (dateTimePickerTaskIn.Value > ActualDoneFirstTaskIn && TasksHoursWithoutSelectedTask == 0 && TasksCountWithoutSelectedTask == 0)
                        {
                            DoneRecordTaskIn = dateTimePickerTaskIn.Value;
                        }

                        ////MessageBox.Show("CHECK OUTPUT - YES + DONE");
                        //MessageBox.Show("DONE COUNT: "+ ActualDoneCount.ToString() + "\nDONE HOURS: " + ActualDoneHours.ToString() + "\nCOUNT WITHOUT CURRENT TASK: " + TasksCountWithoutSelectedTask.ToString()+ "\nHOURS WITHOUT CURRENT TASK: " + TasksHoursWithoutSelectedTask.ToString());


                        /* Create Modified Done Record */

                        //Initialize Values
                        //Header
                        mTaskRecordHeaderModify.PCP_ID = uJobCode;
                        mTaskRecordHeaderModify.TR_ID = uRecordID;
                        mTaskRecordHeaderModify.TRM_ID = TRMIDGenerate();

                        //Detail
                        mTaskRecordDetailModify.TRM_ID = TRMIDGenerate();
                        mTaskRecordDetailModify.TR_UID = uUID;
                        mTaskRecordDetailModify.TRM_MID = uMID;
                        mTaskRecordDetailModify.TRM_PIC = uPIC;
                        mTaskRecordDetailModify.TR_File = uFileName;
                        mTaskRecordDetailModify.TR_FileSize = uActualDoneCount; //Updated
                        mTaskRecordDetailModify.TRM_ModifiedlTime = ServerDateTime();

                        //Status Done
                        mTaskRecordDetailModify.TR_Status = 3;

                        mTaskRecordDetailModify.TRM_InDate = DoneRecordTaskIn;
                        mTaskRecordDetailModify.TRM_OutDate = dateTimePickerTaskOut.Value;
                        mTaskRecordDetailModify.TRM_Hours = uActualDoneHours;  //Updated
                        mTaskRecordDetailModify.TRM_Apporval = 1; /* 1 - Pending, 2 - Approved, 3 - Disapproved */
                                                                  //mTaskRecordDetailModify.TRM_ApprovalTime = null;
                        mTaskRecordDetailModify.TR_UOM = lblPagesKB.Text;

                        //New Productivity calculate according to the modified file size     
                        float cDonePrductDivedeByQuota = float.Parse(uActualDoneCount.ToString()) / int.Parse(lblQuota.Text);
                        float cDonePrductDivedeByTime = (9 / float.Parse(uActualDoneHours.ToString()));

                        //Productivity = ((output/Quota) * (9/TaskHours)) * 100%
                        float cDoneProductivity = (cDonePrductDivedeByQuota * cDonePrductDivedeByTime) * 100;

                        mTaskRecordDetailModify.TRM_Productivity = cDoneProductivity;


                        if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                        {
                            if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                            {
                                if (mTaskRecordHeaderModifyMng.AddTModifiedHeader(mTaskRecordHeaderModify) > 0)
                                {
                                    mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                                }
                            }
                        }
                        else
                        {
                            mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                        }

                        //MessageBox Here An Exit from Function
                        //Load Modified records          
                        String uMUID = uMID;
                        String uTempPIC = lblTempPIC.Text;

                        frm_TaskInOutModifiedApproval myForm = frm_TaskInOutModifiedApproval.GetInstance(uTempPIC, uMUID);
                        frm_ApprovalTaskInOut myForm1 = frm_ApprovalTaskInOut.GetInstance(uTempPIC, uMUID);

                        myForm.TopLevel = false;
                        myForm.TopMost = true;
                        myForm.AutoScroll = false;
                        myForm.Dock = DockStyle.Fill;
                        frm_ApprovalTaskInOut form1 = (frm_ApprovalTaskInOut)Application.OpenForms["frm_ApprovalTaskInOut"];
                        Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
                        panel1.Controls.Add(myForm);

                        if (new PICHeaderMng(this.conn).PICIsExist(uTempPIC))
                        {
                            myForm.btnApprove.Visible = true;
                            myForm.btnDisapprove.Visible = true;
                        }
                        if (!new PICHeaderMng(this.conn).PICIsExist(uTempPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMUID))
                        {
                            myForm.btnApprove.Visible = false;
                            myForm.btnDisapprove.Visible = false;
                        }

                        myForm.Show();
                        myForm.BringToFront();
                        myForm.RefreshData();
                        myForm.ClearFields();

                        //Call public methods of frm_ApprovalTaskInOut form to hover
                        myForm1.panelHover.Height = myForm1.tileModifiedApproval.Height;
                        myForm1.panelHover.Top = myForm1.tileModifiedApproval.Top + myForm1.line.Top + 2;


                        //Show Completed Message
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record has been modified!", "Record(s) Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
                        this.Close();


                    }
                    
                }

                else if (int.Parse(lblTmpSkippedValidation.Text) == 1) //Task Output Validation - no
                {
                    //Validation Is overwrite other task records time.

                    // +---------------------------------------------
                    //   |  /* 1. Next record Task In */
                    //   |
                    //   |  //Task Out > Task Record Task In
                    //   |
                    //   |    //Message - "Modified Tasked Out time is overlaping next Tasked In record."   
                    // +---------------------------------------------

                    if (mTaskRecordDetailMng.GetRecordsCountForGivenPeriod(uUID, uActualtaskIn, uActualtaskOut) > 1 && mTaskRecordDetailMng.UserNextTaskInRecordIsOverlap(uUID, uActualtaskIn, uActualtaskOut, dateTimePickerTaskOut.Value, uRecordID))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nModified Tasked Out time is overlaping next Tasked In record or AMS Logout.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePickerTaskOut.Focus();
                        return;
                    }

                    // +---------------------------------------------
                    //   |  /* 2. Previous record Task Out */
                    //   |
                    //   |  //Task In < Task Record Task Out
                    //   |
                    //   |   //Message - "Modified Tasked In time is overlaping previous Tasked Out record."
                    // +---------------------------------------------

                    if (mTaskRecordDetailMng.GetRecordsCountForGivenPeriod(uUID, uActualtaskIn, uActualtaskOut) > 1 && mTaskRecordDetailMng.UserPreviousTaskInRecordIsOverlap(uUID, uActualtaskIn, uActualtaskOut, dateTimePickerTaskIn.Value, uRecordID))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nModified Tasked In time is overlaping previous Tasked Out record or AMS Login.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePickerTaskIn.Focus();
                        return;
                    }

                    // +---------------------------------------------
                    //   |
                    //   | AMS Login validations
                    //   |
                    // +---------------------------------------------

                    /*Overlap AMS login*/
                    if (mTaskRecordDetailMng.GetRecordsCountForGivenPeriod(uUID, uActualtaskIn, uActualtaskOut) == 1 && mTaskRecordDetailMng.UserTaskInRecordIsAMSLoginOverlap(uUID, uActualtaskIn, uActualtaskOut, dateTimePickerTaskIn.Value))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nModified Tasked In time is overlaping AMS Login.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePickerTaskIn.Focus();
                        return;
                    }

                    /*Overlap AMS logut*/
                    if (mTaskRecordDetailMng.GetRecordsCountForGivenPeriod(uUID, uActualtaskIn, uActualtaskOut) == 1 && mTaskRecordDetailMng.UserTaskOutRecordIsAMSLogutOverlap(uUID, uActualtaskIn, uActualtaskOut, dateTimePickerTaskOut.Value))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nModified Tasked Out time is overlaping AMS Logout.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePickerTaskOut.Focus();
                        return;
                    }

                    // +---------------------------------------------
                    //   |    /* 1. Next IDLErecord Task In */
                    //   |
                    //   |    //Task Out > IDLE Record Task In
                    //   |
                    //   |    //Message - "Modified Tasked Out time is overlaping next IDLE In record."
                    //   |
                    //   |    /* 2. Previous IDLE record Task Out */
                    //   |
                    //   |    //Task In < IDLE Record Task Out
                    //   |
                    //   |   //Message - "Modified Tasked In time is overlaping previous IDLE Out record."
                    //   |
                    // +---------------------------------------------

                    //Validation Is overwrite IDLE records time.
                    if (mIDLEDetailMng.UserIDLERecordIsExist_taskModify(mIDLEDetail))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIDLE record is already exist for this time span! Please check again.", "IDLE Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //Status Pending
                    if (lblFillStatus.Text == "Pending") 
                    {
                        //MessageBox.Show("CHECK OUTPUT - NO + PENDING");

                        int ActualDoneCount = (ActualFileSizeSkipVal - PendingHistoryCount);
                        float ActualDoneHours = (ActualFileHours - PendingHistoryHours);
                        DateTime DoneRecordTaskIn = ActualDoneFirstTaskIn;
                        int TasksCountWithoutSelectedTask = ((PendingHistoryCount - curTaskFileSize) + ActualDoneCount);
                        float TasksHoursWithoutSelectedTask = ((PendingHistoryHours - curTaskHours) + ActualDoneHours);

                        /* If Done Record available*/
                        if (mTaskRecordDetailMng.IsTaskDoneRecordAvailable(uUID, uTaskCode, uJobCode))
                        {

                            /* Get Done Record Details*/
                            String uDoneRecordID = mTaskRecordDetailMng.GetTaskDoneRecordID(uUID, uTaskCode, uJobCode);
                            int uActualDoneCount = TasksCountWithoutSelectedTask + uOutput; //Initialized to updated Done record filesize 
                            float uActualDoneHours = TasksHoursWithoutSelectedTask + float.Parse(txtTaskHours.Text); //Initialized to updated Done record Hours 


                            //FirstaskIn Check and update if ealier than existing done record
                            if (dateTimePickerTaskIn.Value < ActualDoneFirstTaskIn)
                            {
                                DoneRecordTaskIn = dateTimePickerTaskIn.Value;
                            }


                            /*Create Modified pending Record first*/

                            //Initialize Values
                            //Header
                            mTaskRecordHeaderModify.PCP_ID = uJobCode;
                            mTaskRecordHeaderModify.TR_ID = uRecordID;
                            mTaskRecordHeaderModify.TRM_ID = TRMIDGenerate();

                            //Detail
                            mTaskRecordDetailModify.TRM_ID = TRMIDGenerate();
                            mTaskRecordDetailModify.TR_UID = uUID;
                            mTaskRecordDetailModify.TRM_MID = uMID;
                            mTaskRecordDetailModify.TRM_PIC = uPIC;
                            mTaskRecordDetailModify.TR_File = uFileName;
                            mTaskRecordDetailModify.TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                            mTaskRecordDetailModify.TRM_ModifiedlTime = ServerDateTime();

                            //Status Pending
                            mTaskRecordDetailModify.TR_Status = 2;

                            mTaskRecordDetailModify.TRM_InDate = dateTimePickerTaskIn.Value;
                            mTaskRecordDetailModify.TRM_OutDate = dateTimePickerTaskOut.Value;
                            mTaskRecordDetailModify.TRM_Hours = float.Parse(txtTaskHours.Text);
                            mTaskRecordDetailModify.TRM_Apporval = 1; /* 1 - Pending, 2 - Approved, 3 - Disapproved */
                            //mTaskRecordDetailModify.TRM_ApprovalTime = null;
                            mTaskRecordDetailModify.TR_UOM = lblPagesKB.Text;

                            //New Productivity calculate according to the modified file size     
                            float cPrductDivedeByQuota = float.Parse(numericUpDownFileSize.Value.ToString()) / int.Parse(lblQuota.Text);
                            float cPrductDivedeByTime = (9 / float.Parse(txtTaskHours.Text));

                            //Productivity = ((output/Quota) * (9/TaskHours)) * 100%
                            float cProductivity = (cPrductDivedeByQuota * cPrductDivedeByTime) * 100;

                            mTaskRecordDetailModify.TRM_Productivity = cProductivity;

                            if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                            {
                                if (mTaskRecordHeaderModifyMng.AddTModifiedHeader(mTaskRecordHeaderModify) > 0)
                                {
                                    //if pending details done write Done Hearder and Detail
                                    if (mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify) > 0)
                                    {
                                        /* Create Modified Done Record */

                                        //Initialize Values
                                        //Header
                                        mTaskRecordHeaderModify.PCP_ID = uJobCode;
                                        mTaskRecordHeaderModify.TR_ID = uDoneRecordID;
                                        mTaskRecordHeaderModify.TRM_ID = TRMIDGenerate();

                                        //Detail
                                        mTaskRecordDetailModify.TRM_ID = TRMIDGenerate();
                                        mTaskRecordDetailModify.TR_UID = uUID;
                                        mTaskRecordDetailModify.TRM_MID = uMID;
                                        mTaskRecordDetailModify.TRM_PIC = uPIC;
                                        mTaskRecordDetailModify.TR_File = uFileName;
                                        mTaskRecordDetailModify.TR_FileSize = uActualDoneCount; //Updated
                                        mTaskRecordDetailModify.TRM_ModifiedlTime = ServerDateTime();

                                        //Status Done
                                        mTaskRecordDetailModify.TR_Status = 3;

                                        mTaskRecordDetailModify.TRM_InDate = DoneRecordTaskIn;
                                        mTaskRecordDetailModify.TRM_OutDate = dateTimePickerTaskOut.Value;
                                        mTaskRecordDetailModify.TRM_Hours = uActualDoneHours;  //Updated
                                        mTaskRecordDetailModify.TRM_Apporval = 1; /* 1 - Pending, 2 - Approved, 3 - Disapproved */
                                        //mTaskRecordDetailModify.TRM_ApprovalTime = null;
                                        mTaskRecordDetailModify.TR_UOM = lblPagesKB.Text;

                                        //New Productivity calculate according to the modified file size     
                                        float cDonePrductDivedeByQuota = float.Parse(uActualDoneCount.ToString()) / int.Parse(lblQuota.Text);
                                        float cDonePrductDivedeByTime = (9 / float.Parse(uActualDoneHours.ToString()));

                                        //Productivity = ((output/Quota) * (9/TaskHours)) * 100%
                                        float cDoneProductivity = (cDonePrductDivedeByQuota * cDonePrductDivedeByTime) * 100;

                                        mTaskRecordDetailModify.TRM_Productivity = cDoneProductivity;


                                        if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                                        {
                                            if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                                            {
                                                if (mTaskRecordHeaderModifyMng.AddTModifiedHeader(mTaskRecordHeaderModify) > 0)
                                                {
                                                    mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);

                                                }
                                            }
                                        }
                                        else
                                        {
                                            mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                                        }

                                        //MessageBox Here An Exit from Function
                                        //Load Modified records          
                                        String uMUID = uMID;
                                        String uTempPIC = lblTempPIC.Text;

                                        frm_TaskInOutModifiedApproval myForm = frm_TaskInOutModifiedApproval.GetInstance(uTempPIC, uMUID);
                                        frm_ApprovalTaskInOut myForm1 = frm_ApprovalTaskInOut.GetInstance(uTempPIC, uMUID);

                                        myForm.TopLevel = false;
                                        myForm.TopMost = true;
                                        myForm.AutoScroll = false;
                                        myForm.Dock = DockStyle.Fill;
                                        frm_ApprovalTaskInOut form1 = (frm_ApprovalTaskInOut)Application.OpenForms["frm_ApprovalTaskInOut"];
                                        Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
                                        panel1.Controls.Add(myForm);

                                        if (new PICHeaderMng(this.conn).PICIsExist(uTempPIC))
                                        {
                                            myForm.btnApprove.Visible = true;
                                            myForm.btnDisapprove.Visible = true;
                                        }
                                        if (!new PICHeaderMng(this.conn).PICIsExist(uTempPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMUID))
                                        {
                                            myForm.btnApprove.Visible = false;
                                            myForm.btnDisapprove.Visible = false;
                                        }

                                        myForm.Show();
                                        myForm.BringToFront();
                                        myForm.RefreshData();
                                        myForm.ClearFields();

                                        //Call public methods of frm_ApprovalTaskInOut form to hover
                                        myForm1.panelHover.Height = myForm1.tileModifiedApproval.Height;
                                        myForm1.panelHover.Top = myForm1.tileModifiedApproval.Top + myForm1.line.Top + 2;


                                        //Show Completed Message
                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record has been modified!", "Record(s) Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
                                        this.Close();

                                    }
                                }
                            }
                            else
                            {
                                //if pending details done write Done Hearder and Detail
                                if (mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify) > 0)
                                {
                                    /* Create Modified Done Record */

                                    //Initialize Values
                                    //Header
                                    mTaskRecordHeaderModify.PCP_ID = uJobCode;
                                    mTaskRecordHeaderModify.TR_ID = uDoneRecordID;
                                    mTaskRecordHeaderModify.TRM_ID = TRMIDGenerate();

                                    //Detail
                                    mTaskRecordDetailModify.TRM_ID = TRMIDGenerate();
                                    mTaskRecordDetailModify.TR_UID = uUID;
                                    mTaskRecordDetailModify.TRM_MID = uMID;
                                    mTaskRecordDetailModify.TRM_PIC = uPIC;
                                    mTaskRecordDetailModify.TR_File = uFileName;
                                    mTaskRecordDetailModify.TR_FileSize = uActualDoneCount; //Updated
                                    mTaskRecordDetailModify.TRM_ModifiedlTime = ServerDateTime();

                                    //Status Done
                                    mTaskRecordDetailModify.TR_Status = 3;

                                    mTaskRecordDetailModify.TRM_InDate = DoneRecordTaskIn;
                                    mTaskRecordDetailModify.TRM_OutDate = dateTimePickerTaskOut.Value;
                                    mTaskRecordDetailModify.TRM_Hours = uActualDoneHours;  //Updated
                                    mTaskRecordDetailModify.TRM_Apporval = 1; /* 1 - Pending, 2 - Approved, 3 - Disapproved */
                                                                              //mTaskRecordDetailModify.TRM_ApprovalTime = null;
                                    mTaskRecordDetailModify.TR_UOM = lblPagesKB.Text;

                                    //New Productivity calculate according to the modified file size     
                                    float cDonePrductDivedeByQuota = float.Parse(uActualDoneCount.ToString()) / int.Parse(lblQuota.Text);
                                    float cDonePrductDivedeByTime = (9 / float.Parse(uActualDoneHours.ToString()));

                                    //Productivity = ((output/Quota) * (9/TaskHours)) * 100%
                                    float cDoneProductivity = (cDonePrductDivedeByQuota * cDonePrductDivedeByTime) * 100;

                                    mTaskRecordDetailModify.TRM_Productivity = cDoneProductivity;


                                    if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                                    {
                                        if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                                        {
                                            if (mTaskRecordHeaderModifyMng.AddTModifiedHeader(mTaskRecordHeaderModify) > 0)
                                            {
                                                mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                                    }

                                    //MessageBox Here An Exit from Function
                                    //Load Modified records          
                                    String uMUID = uMID;
                                    String uTempPIC = lblTempPIC.Text;

                                    frm_TaskInOutModifiedApproval myForm = frm_TaskInOutModifiedApproval.GetInstance(uTempPIC, uMUID);
                                    frm_ApprovalTaskInOut myForm1 = frm_ApprovalTaskInOut.GetInstance(uTempPIC, uMUID);

                                    myForm.TopLevel = false;
                                    myForm.TopMost = true;
                                    myForm.AutoScroll = false;
                                    myForm.Dock = DockStyle.Fill;
                                    frm_ApprovalTaskInOut form1 = (frm_ApprovalTaskInOut)Application.OpenForms["frm_ApprovalTaskInOut"];
                                    Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
                                    panel1.Controls.Add(myForm);

                                    if (new PICHeaderMng(this.conn).PICIsExist(uTempPIC))
                                    {
                                        myForm.btnApprove.Visible = true;
                                        myForm.btnDisapprove.Visible = true;
                                    }
                                    if (!new PICHeaderMng(this.conn).PICIsExist(uTempPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMUID))
                                    {
                                        myForm.btnApprove.Visible = false;
                                        myForm.btnDisapprove.Visible = false;
                                    }

                                    myForm.Show();
                                    myForm.BringToFront();
                                    myForm.RefreshData();
                                    myForm.ClearFields();

                                    //Call public methods of frm_ApprovalTaskInOut form to hover
                                    myForm1.panelHover.Height = myForm1.tileModifiedApproval.Height;
                                    myForm1.panelHover.Top = myForm1.tileModifiedApproval.Top + myForm1.line.Top + 2;


                                    //Show Completed Message
                                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record has been modified!", "Record(s) Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
                                    this.Close();
                                }
                            }

                        }

                    }

                    //Status Done
                    if (lblFillStatus.Text == "Done") 
                    {
                        //MessageBox.Show("CHECK OUTPUT - NO + DONE");

                        int ActualDoneCount = (ActualFileSizeSkipVal - PendingHistoryCount);   //Done Count         
                        float ActualDoneHours = (ActualFileHours - PendingHistoryHours); //Done Hours
                        DateTime DoneRecordTaskIn = ActualDoneFirstTaskIn; //Fisrt Task In
                        curTaskFileSizeTemp = ActualDoneCount;
                        curTaskFileSize = curTaskFileSizeTemp;
                        curTaskHoursTemp = ActualDoneHours;
                        curTaskHours = curTaskHoursTemp;

                        int TasksCountWithoutSelectedTask = ((PendingHistoryCount - curTaskFileSize) + ActualDoneCount);
                        float TasksHoursWithoutSelectedTask = ((PendingHistoryHours - curTaskHours) + ActualDoneHours);

                        /* Get Done Record Details*/
                        int uActualDoneCount = TasksCountWithoutSelectedTask + uOutput; //Initialized to updated Done record filesize 
                        float uActualDoneHours = TasksHoursWithoutSelectedTask + float.Parse(txtTaskHours.Text); //Initialized to updated Done record Hours 

                        //FirstaskIn Check and update if ealier than existing done record
                        if (dateTimePickerTaskIn.Value < ActualDoneFirstTaskIn)
                        {
                            DoneRecordTaskIn = dateTimePickerTaskIn.Value;
                        }

                        //If only done record then update modified Actual task in
                        if (dateTimePickerTaskIn.Value > ActualDoneFirstTaskIn && TasksHoursWithoutSelectedTask == 0 && TasksCountWithoutSelectedTask == 0)
                        {
                            DoneRecordTaskIn = dateTimePickerTaskIn.Value;
                        }

                        ////MessageBox.Show("CHECK OUTPUT - YES + DONE");
                        //MessageBox.Show("DONE COUNT: "+ ActualDoneCount.ToString() + "\nDONE HOURS: " + ActualDoneHours.ToString() + "\nCOUNT WITHOUT CURRENT TASK: " + TasksCountWithoutSelectedTask.ToString()+ "\nHOURS WITHOUT CURRENT TASK: " + TasksHoursWithoutSelectedTask.ToString());


                        /* Create Modified Done Record */

                        //Initialize Values
                        //Header
                        mTaskRecordHeaderModify.PCP_ID = uJobCode;
                        mTaskRecordHeaderModify.TR_ID = uRecordID;
                        mTaskRecordHeaderModify.TRM_ID = TRMIDGenerate();

                        //Detail
                        mTaskRecordDetailModify.TRM_ID = TRMIDGenerate();
                        mTaskRecordDetailModify.TR_UID = uUID;
                        mTaskRecordDetailModify.TRM_MID = uMID;
                        mTaskRecordDetailModify.TRM_PIC = uPIC;
                        mTaskRecordDetailModify.TR_File = uFileName;
                        mTaskRecordDetailModify.TR_FileSize = uActualDoneCount; //Updated
                        mTaskRecordDetailModify.TRM_ModifiedlTime = ServerDateTime();

                        //Status Done
                        mTaskRecordDetailModify.TR_Status = 3;

                        mTaskRecordDetailModify.TRM_InDate = DoneRecordTaskIn;
                        mTaskRecordDetailModify.TRM_OutDate = dateTimePickerTaskOut.Value;
                        mTaskRecordDetailModify.TRM_Hours = uActualDoneHours;  //Updated
                        mTaskRecordDetailModify.TRM_Apporval = 1; /* 1 - Pending, 2 - Approved, 3 - Disapproved */
                                                                  //mTaskRecordDetailModify.TRM_ApprovalTime = null;
                        mTaskRecordDetailModify.TR_UOM = lblPagesKB.Text;

                        //New Productivity calculate according to the modified file size     
                        float cDonePrductDivedeByQuota = float.Parse(uActualDoneCount.ToString()) / int.Parse(lblQuota.Text);
                        float cDonePrductDivedeByTime = (9 / float.Parse(uActualDoneHours.ToString()));

                        //Productivity = ((output/Quota) * (9/TaskHours)) * 100%
                        float cDoneProductivity = (cDonePrductDivedeByQuota * cDonePrductDivedeByTime) * 100;

                        mTaskRecordDetailModify.TRM_Productivity = cDoneProductivity;


                        if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                        {
                            if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                            {
                                if (mTaskRecordHeaderModifyMng.AddTModifiedHeader(mTaskRecordHeaderModify) > 0)
                                {
                                    mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                                }
                            }
                        }
                        else
                        {
                            mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                        }

                        //MessageBox Here An Exit from Function
                        //Load Modified records          
                        String uMUID = uMID;
                        String uTempPIC = lblTempPIC.Text;

                        frm_TaskInOutModifiedApproval myForm = frm_TaskInOutModifiedApproval.GetInstance(uTempPIC, uMUID);
                        frm_ApprovalTaskInOut myForm1 = frm_ApprovalTaskInOut.GetInstance(uTempPIC, uMUID);

                        myForm.TopLevel = false;
                        myForm.TopMost = true;
                        myForm.AutoScroll = false;
                        myForm.Dock = DockStyle.Fill;
                        frm_ApprovalTaskInOut form1 = (frm_ApprovalTaskInOut)Application.OpenForms["frm_ApprovalTaskInOut"];
                        Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
                        panel1.Controls.Add(myForm);

                        if (new PICHeaderMng(this.conn).PICIsExist(uTempPIC))
                        {
                            myForm.btnApprove.Visible = true;
                            myForm.btnDisapprove.Visible = true;
                        }
                        if (!new PICHeaderMng(this.conn).PICIsExist(uTempPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMUID))
                        {
                            myForm.btnApprove.Visible = false;
                            myForm.btnDisapprove.Visible = false;
                        }

                        myForm.Show();
                        myForm.BringToFront();
                        myForm.RefreshData();
                        myForm.ClearFields();

                        //Call public methods of frm_ApprovalTaskInOut form to hover
                        myForm1.panelHover.Height = myForm1.tileModifiedApproval.Height;
                        myForm1.panelHover.Top = myForm1.tileModifiedApproval.Top + myForm1.line.Top + 2;


                        //Show Completed Message
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record has been modified!", "Record(s) Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
                        this.Close();
                    }
                    
                }

                ////Initialize Values
                ////Header
                //mTaskRecordHeaderModify.PCP_ID = lblJobCode.Text;
                //mTaskRecordHeaderModify.TR_ID = lblTRID.Text;
                //mTaskRecordHeaderModify.TRM_ID = TRMIDGenerate();

                ////Detail
                //mTaskRecordDetailModify.TRM_ID = TRMIDGenerate();
                //mTaskRecordDetailModify.TR_UID = lblUID.Text;
                //mTaskRecordDetailModify.TRM_MID = lblMUID.Text;
                //mTaskRecordDetailModify.TRM_PIC = lblPIC.Text;
                //mTaskRecordDetailModify.TR_File = lblFileName.Text;
                //mTaskRecordDetailModify.TR_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                //mTaskRecordDetailModify.TRM_ModifiedlTime = ServerDateTime();                
                //mTaskRecordDetailModify.TR_Status = int.Parse(lblJobStatus.Text);
                //mTaskRecordDetailModify.TRM_InDate = dateTimePickerTaskIn.Value;
                //mTaskRecordDetailModify.TRM_OutDate= dateTimePickerTaskOut.Value;
                //mTaskRecordDetailModify.TRM_Hours = float.Parse(txtTaskHours.Text);
                //mTaskRecordDetailModify.TRM_Apporval = 1; /* 1 - Pending, 2 - Approved, 3 - Disapproved */
                ////mTaskRecordDetailModify.TRM_ApprovalTime = null;
                //mTaskRecordDetailModify.TR_UOM = lblUOM.Text;

                ////New Productivity calculate according to the modified file size                

                //float cPrductDivedeByQuota = float.Parse(numericUpDownFileSize.Value.ToString()) / int.Parse(lblQuota.Text);
                //float cPrductDivedeByTime = (9 / float.Parse(txtTaskHours.Text));

                ////Productivity = ((output/Quota) * (9/TaskHours)) * 100%
                //float cProductivity = (cPrductDivedeByQuota * cPrductDivedeByTime) * 100;

                //mTaskRecordDetailModify.TRM_Productivity = cProductivity;

                //if (!mTaskRecordHeaderModifyMng.IsExistHeader(mTaskRecordDetailModify.TRM_ID))
                //{
                //    if (mTaskRecordHeaderModifyMng.AddTModifiedHeader(mTaskRecordHeaderModify)>0)
                //    {
                //        mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                //    }
                //}
                //else
                //{
                //    mTaskRecordDetailModifyMng.AddTModifiedDetail(mTaskRecordDetailModify);
                //}

                ////Load Modified records
                //String uPIC = lblPIC.Text;
                //String uMUID = lblMUID.Text;
                //String uTempPIC = lblTempPIC.Text;

                //frm_TaskInOutModifiedApproval myForm = frm_TaskInOutModifiedApproval.GetInstance(uTempPIC, uMUID);
                //frm_ApprovalTaskInOut myForm1 = frm_ApprovalTaskInOut.GetInstance(uTempPIC, uMUID);

                //myForm.TopLevel = false;
                //myForm.TopMost = true;
                //myForm.AutoScroll = false;
                //myForm.Dock = DockStyle.Fill;
                //frm_ApprovalTaskInOut form1 = (frm_ApprovalTaskInOut)Application.OpenForms["frm_ApprovalTaskInOut"];
                //Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
                //panel1.Controls.Add(myForm);

                //if (new PICHeaderMng(this.conn).PICIsExist(uTempPIC))
                //{
                //    myForm.btnApprove.Visible = true;
                //    myForm.btnDisapprove.Visible = true;
                //}
                //if (!new PICHeaderMng(this.conn).PICIsExist(uTempPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMUID))
                //{
                //    myForm.btnApprove.Visible = false;
                //    myForm.btnDisapprove.Visible = false;
                //}

                //myForm.Show();
                //myForm.BringToFront();
                //myForm.RefreshData();
                //myForm.ClearFields();

                ////Call public methods of frm_ApprovalTaskInOut form to hover
                //myForm1.panelHover.Height = myForm1.tileModifiedApproval.Height;
                //myForm1.panelHover.Top = myForm1.tileModifiedApproval.Top + myForm1.line.Top + 2;


                ////Show Completed Message
                //MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record has been modified!", "Record(s) Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
                //this.Close();

            }
            //else
            //{
            //    Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
            //    this.Close();
            //}
        }

        private void frm_TaskInOutFileSizeModify_Load(object sender, EventArgs e)
        {
            // Set the Format type and the CustomFormat string.
            dateTimePickerTaskIn.Format = DateTimePickerFormat.Custom;
            dateTimePickerTaskIn.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            dateTimePickerTaskIn.ShowUpDown = false;

            dateTimePickerTaskOut.Format = DateTimePickerFormat.Custom;
            dateTimePickerTaskOut.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            dateTimePickerTaskOut.ShowUpDown = false;
        }

        private void dateTimePickerTaskIn_ValueChanged(object sender, EventArgs e)
        {
            //Time Calculation
            TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;

            double hours = diff.TotalHours;

            txtTaskHours.Text = Math.Round(hours, 3).ToString();
        }

        private void dateTimePickerTaskOut_ValueChanged(object sender, EventArgs e)
        {
            //Time Calculation
            TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;

            double hours = diff.TotalHours;

            txtTaskHours.Text = Math.Round(hours, 3).ToString();
        }

        private void txtTaskHours_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(txtTaskHours.Text) <= 0)
                {

                    lblIDLEMessage.Visible = true;
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

        private void dataGridViewTaskInOutForApproval_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewTaskInOutForApproval.Columns[e.ColumnIndex].Index == 0)
            {
                String mTaskrecord = dataGridViewTaskInOutForApproval.CurrentRow.Cells[2].Value.ToString();
                String mJobCode = dataGridViewTaskInOutForApproval.CurrentRow.Cells[3].Value.ToString();
                String mFile = dataGridViewTaskInOutForApproval.CurrentRow.Cells[5].Value.ToString();
                int mOutput = int.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[6].Value.ToString());
                String mUOM = dataGridViewTaskInOutForApproval.CurrentRow.Cells[7].Value.ToString();
                String mTaskCode= dataGridViewTaskInOutForApproval.CurrentRow.Cells[8].Value.ToString();
                int mStatus = int.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[9].Value.ToString());
                DateTime mTaskIn = DateTime.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[10].Value.ToString());
                DateTime mTaskOut = DateTime.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[11].Value.ToString());
                float mTaskHours = float.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[12].Value.ToString());
                int mApproval = int.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[13].Value.ToString());
                curTaskFileSize = mOutput;
                curTaskHours = mTaskHours;

                lblTRID.Text = mTaskrecord;
                lblTask.Text = mTaskCode;

                //check task validation skipped or allowed
                PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);
                TaskHeaderMng mTaskHeaderMng = new TaskHeaderMng(this.conn);
                TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

                String mProcessCode = mPCPDetailMng.GetProcessCodeByPCPCode(mTaskCode, mJobCode);
                String mProject = mPCPDetailMng.GetProjectByPCPCode(mJobCode);

                //Disable BookCount Edit
                //if (mUOM=="Book Count")
                //{
                //    numericUpDownFileSize.Enabled = false;
                //}
                //else
                //{
                //    numericUpDownFileSize.Enabled = true;
                //}

                int mSkipValidation = mTaskHeaderMng.CheckTaskCodeSkipValidation(mTaskCode, mProject, mProcessCode);

                if (mSkipValidation == 0) //Task Output Validation - yes
                {
                    //Task Pending
                    if (mStatus==2)
                    {
                        lblTmpSkippedValidation.Text = (0).ToString();
                        dateTimePickerTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                        dateTimePickerTaskOut.Value = mTaskOut;
                        tmpActualTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                        tmpActualTaskOut.Value = mTaskRecordDetailMng.GetActualTaskOutByRecordID(mTaskrecord);
                        txtTaskHours.Text = mTaskHours.ToString("0.###");
                        numericUpDownFileSize.Value = mOutput;
                        lblPagesKB.Text = mUOM;
                        lblFillStatus.Text = "Pending";
                    }

                    //Task Done
                    if (mStatus == 3)
                    {
                        lblTmpSkippedValidation.Text = (0).ToString();
                        dateTimePickerTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                        dateTimePickerTaskOut.Value = mTaskOut;
                        tmpActualTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                        tmpActualTaskOut.Value = mTaskRecordDetailMng.GetActualTaskOutByRecordID(mTaskrecord);
                        txtTaskHours.Text = TimeDiff(mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord), mTaskOut).ToString();
                        numericUpDownFileSize.Value =(mOutput - mTaskRecordDetailMng.GetActualFileSizeFroPending(mJobCode, mTaskCode, mFile));
                        lblPagesKB.Text = mUOM;
                        lblFillStatus.Text = "Done";

                    }
                }
                else //Task Output Validation - No
                {
                    //Task Pending
                    if (mStatus == 2)
                    {
                        lblTmpSkippedValidation.Text = (1).ToString();
                        dateTimePickerTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                        dateTimePickerTaskOut.Value = mTaskOut;
                        tmpActualTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                        tmpActualTaskOut.Value = mTaskRecordDetailMng.GetActualTaskOutByRecordID(mTaskrecord);
                        txtTaskHours.Text = mTaskHours.ToString("0.###");
                        numericUpDownFileSize.Value = mOutput;
                        lblPagesKB.Text = mUOM;
                        lblFillStatus.Text = "Pending";

                    }

                    //Task Done
                    if (mStatus == 3)
                    {
                        lblTmpSkippedValidation.Text = (1).ToString();
                        dateTimePickerTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                        dateTimePickerTaskOut.Value = mTaskOut;
                        tmpActualTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                        tmpActualTaskOut.Value = mTaskRecordDetailMng.GetActualTaskOutByRecordID(mTaskrecord);
                        txtTaskHours.Text = TimeDiff(mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord), mTaskOut).ToString();
                        numericUpDownFileSize.Value = (mOutput - mTaskRecordDetailMng.GetActualFileSizeFroPending(mJobCode, mTaskCode, mFile));
                        lblPagesKB.Text = mUOM;
                        lblFillStatus.Text = "Done";

                    }
                }

            }
        }

        //Time difference calculation object
        public double TimeDiff(DateTime First, DateTime Last)
        {
            //Time Calculation
            TimeSpan diff = Last - First;
            double hours = diff.TotalHours;

            return double.Parse(hours.ToString("0.###"));
        }

        private void lblTRID_TextChanged(object sender, EventArgs e)
        {
             if (lblTRID.Text == "--" || String.IsNullOrEmpty(lblTRID.Text))
            {
                lblSelectRecorMessage.Visible = true;
                btnModify.Enabled = false;
            }
            else
            {
                lblSelectRecorMessage.Visible = false;
                btnModify.Enabled = true;
            }
        }

        private void dataGridViewTaskInOutForApproval_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
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
                    else if ((int)e.Value == 4)
                    {
                        e.Value = "Skipped";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");
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

        private void dataGridViewTaskInOutForApproval_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String mTaskrecord = dataGridViewTaskInOutForApproval.CurrentRow.Cells[2].Value.ToString();
            String mJobCode = dataGridViewTaskInOutForApproval.CurrentRow.Cells[3].Value.ToString();
            String mFile = dataGridViewTaskInOutForApproval.CurrentRow.Cells[5].Value.ToString();
            int mOutput = int.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[6].Value.ToString());
            String mUOM = dataGridViewTaskInOutForApproval.CurrentRow.Cells[7].Value.ToString();
            String mTaskCode = dataGridViewTaskInOutForApproval.CurrentRow.Cells[8].Value.ToString();
            int mStatus = int.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[9].Value.ToString());
            DateTime mTaskIn = DateTime.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[10].Value.ToString());
            DateTime mTaskOut = DateTime.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[11].Value.ToString());
            float mTaskHours = float.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[12].Value.ToString());
            int mApproval = int.Parse(dataGridViewTaskInOutForApproval.CurrentRow.Cells[13].Value.ToString());
            curTaskFileSize = mOutput;
            curTaskHours = mTaskHours;

            lblTRID.Text = mTaskrecord;

            //check task validation skipped or allowed
            PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);
            TaskHeaderMng mTaskHeaderMng = new TaskHeaderMng(this.conn);
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            String mProcessCode = mPCPDetailMng.GetProcessCodeByPCPCode(mTaskCode, mJobCode);
            String mProject = mPCPDetailMng.GetProjectByPCPCode(mJobCode);

            //Disable BookCount Edit
            //if (mUOM == "Book Count")
            //{
            //    numericUpDownFileSize.Enabled = false;
            //}
            //else
            //{
            //    numericUpDownFileSize.Enabled = true;
            //}

            int mSkipValidation = mTaskHeaderMng.CheckTaskCodeSkipValidation(mTaskCode, mProject, mProcessCode);

            if (mSkipValidation == 0) //Task Output Validation - yes
            {
                //Task Pending
                if (mStatus == 2)
                {
                    lblTmpSkippedValidation.Text = (0).ToString();
                    dateTimePickerTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                    dateTimePickerTaskOut.Value = mTaskOut;
                    tmpActualTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                    tmpActualTaskOut.Value = mTaskRecordDetailMng.GetActualTaskOutByRecordID(mTaskrecord);
                    txtTaskHours.Text = mTaskHours.ToString("0.###");
                    numericUpDownFileSize.Value = mOutput;
                    lblPagesKB.Text = mUOM;
                    lblFillStatus.Text = "Pending";
                }

                //Task Done
                if (mStatus == 3)
                {
                    lblTmpSkippedValidation.Text = (0).ToString();
                    dateTimePickerTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                    dateTimePickerTaskOut.Value = mTaskOut;
                    tmpActualTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                    tmpActualTaskOut.Value = mTaskRecordDetailMng.GetActualTaskOutByRecordID(mTaskrecord);
                    txtTaskHours.Text = TimeDiff(mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord), mTaskOut).ToString();
                    numericUpDownFileSize.Value = (mOutput - mTaskRecordDetailMng.GetActualFileSizeFroPending(mJobCode, mTaskCode, mFile));
                    lblPagesKB.Text = mUOM;
                    lblFillStatus.Text = "Done";

                }
            }
            else //Task Output Validation - No
            {
                //Task Pending
                if (mStatus == 2)
                {
                    lblTmpSkippedValidation.Text = (1).ToString();
                    dateTimePickerTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                    dateTimePickerTaskOut.Value = mTaskOut;
                    tmpActualTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                    tmpActualTaskOut.Value = mTaskRecordDetailMng.GetActualTaskOutByRecordID(mTaskrecord);
                    txtTaskHours.Text = mTaskHours.ToString("0.###");
                    numericUpDownFileSize.Value = mOutput;
                    lblPagesKB.Text = mUOM;
                    lblFillStatus.Text = "Pending";

                }

                //Task Done
                if (mStatus == 3)
                {
                    lblTmpSkippedValidation.Text = (1).ToString();
                    dateTimePickerTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                    dateTimePickerTaskOut.Value = mTaskOut;
                    tmpActualTaskIn.Value = mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord);
                    tmpActualTaskOut.Value = mTaskRecordDetailMng.GetActualTaskOutByRecordID(mTaskrecord);
                    txtTaskHours.Text = TimeDiff(mTaskRecordDetailMng.GetActualTaskInByRecordID(mTaskrecord), mTaskOut).ToString();
                    numericUpDownFileSize.Value = (mOutput - mTaskRecordDetailMng.GetActualFileSizeFroPending(mJobCode, mTaskCode, mFile));
                    lblPagesKB.Text = mUOM;
                    lblFillStatus.Text = "Done";

                }
            }

        }
    }
}
