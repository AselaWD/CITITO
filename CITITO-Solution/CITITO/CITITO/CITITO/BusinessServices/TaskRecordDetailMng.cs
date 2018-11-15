using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CITITO.BusinessObjects;
using System.Data;
using System.Data.SqlClient;

namespace CITITO.BusinessServices
{
    class TaskRecordDetailMng
    {
        //TR_Index        bigint            Unchecked
        //TR_ID           varchar(50)       Unchecked
        //PCP_ID          varchar(50)       Unchecked
        //TR_Status       int               Unchecked /* 1 - On Hold, 2 - Pending, 3 - Done*/
        //TR_InDate       datetime          Unchecked
        //TR_OutDate      datetime          Unchecked
        //TR_TaskStatus   int               Unchecked /* 0 - Fresh, 1 - Tasked In , 2 - Done */
        //TR_Shipment     varchar(1000)     Unchecked
        //TR_File         varchar(500)      Unchecked
        //TR_FileSize     bigint            Unchecked
        //TR_UOM          varchar(100)      Unchecked
        //TR_Quota        bigint            Unchecked//TR_UID          varchar(50)       Unchecked
        //TR_MID          varchar(50)       Unchecked
        //TR_PIC          varchar(50)       Unchecked
        //TR_Apporval     int               Unchecked /* 1 - Pending, 2 - Approved, 3 - Disapproved */
        //TR_ApprovalTime datetime          Unchecked
        //TR_Hours        float             Unchecked
        //TR_Productivity float             Unchecked
        //Task_ID         varchar(50)       Unchecked
        //TR_ActualTaskIn datetime          Checked

        SqlConnection mConnectionUser;

        //Default connection
        public TaskRecordDetailMng()
        {

        }

        //Constructor Overload
        public TaskRecordDetailMng(SqlConnection conn)
        {
            mConnectionUser = conn;

        }

        public int AddTaskInDetail(TaskRecordDetail mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;
            insetComm.Parameters.Add("@mTR_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPCP_ID", SqlDbType.NVarChar);
            //insetComm.Parameters.Add("@mTR_Status", SqlDbType.Int); /* 2 - Pending, 3 - Done */
            insetComm.Parameters.Add("@mTR_InDate", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mTR_TaskStatus", SqlDbType.Int); /* 0 - Fresh, 1 - Tasked In , 2 - Done */
            insetComm.Parameters.Add("@mTR_Shipment", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTR_File", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTR_UOM", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTR_Quota", SqlDbType.BigInt);
            insetComm.Parameters.Add("@mTR_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTR_MID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTR_PIC", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTR_Apporval", SqlDbType.Int); /* 1 - Pending, 2 - Approved, 3 - Disapproved */
            insetComm.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTR_ActualTaskIn", SqlDbType.DateTime);

            insetComm.Parameters["@mTR_ID"].Value = mDetail.TR_ID;
            insetComm.Parameters["@mPCP_ID"].Value = mDetail.PCP_ID;
            //insetComm.Parameters["@mTR_Status"].Value = mDetail.TR_Status;
            insetComm.Parameters["@mTR_InDate"].Value = mDetail.TR_InDate;
            insetComm.Parameters["@mTR_TaskStatus"].Value = mDetail.TR_TaskStatus;
            insetComm.Parameters["@mTR_Shipment"].Value = mDetail.TR_Shipment;
            insetComm.Parameters["@mTR_File"].Value = mDetail.TR_File;
            insetComm.Parameters["@mTR_UOM"].Value = mDetail.TR_UOM;
            insetComm.Parameters["@mTR_Quota"].Value = mDetail.TR_Quota;
            insetComm.Parameters["@mTR_UID"].Value = mDetail.TR_UID;
            insetComm.Parameters["@mTR_MID"].Value = mDetail.TR_MID;
            insetComm.Parameters["@mTR_PIC"].Value = mDetail.TR_PIC;
            insetComm.Parameters["@mTR_Apporval"].Value = mDetail.TR_Apporval;
            insetComm.Parameters["@mTask_ID"].Value = mDetail.Task_ID;
            insetComm.Parameters["@mTR_ActualTaskIn"].Value = mDetail.TR_ActualTaskIn;


            insetComm.CommandText = "INSERT INTO tbl_TaskRecordDetail(TR_ID,PCP_ID,TR_InDate,TR_TaskStatus,TR_Shipment,TR_File, TR_UOM,TR_Quota,TR_UID,TR_MID,TR_PIC,TR_Apporval,Task_ID,TR_ActualTaskIn) VALUES(@mTR_ID,@mPCP_ID,@mTR_InDate,@mTR_TaskStatus,@mTR_Shipment,@mTR_File,@mTR_UOM,@mTR_Quota,@mTR_UID,@mTR_MID,@mTR_PIC,@mTR_Apporval,@mTask_ID,@mTR_ActualTaskIn)";
            int ans = insetComm.ExecuteNonQuery();
            if (ans > 0)
            {
                return ans;
            }
            else
            {
                return 0;
            }
        }

        public int UpdateTaskRecordDetailToTaskOut(TaskRecordDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mFile", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mShipment", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mFileSize", SqlDbType.BigInt);
            updateComm.Parameters.Add("@mOutTime", SqlDbType.DateTime);
            updateComm.Parameters.Add("@mHours", SqlDbType.Float);
            updateComm.Parameters.Add("@mProductivity", SqlDbType.Float);
            updateComm.Parameters.Add("@mTRApporval", SqlDbType.Int);

            updateComm.Parameters["@mFile"].Value = mDetail.TR_File;
            updateComm.Parameters["@mShipment"].Value = mDetail.TR_Shipment;
            updateComm.Parameters["@mTaskCode"].Value = mDetail.Task_ID;
            updateComm.Parameters["@mStatus"].Value = mDetail.TR_Status;
            updateComm.Parameters["@mFileSize"].Value = mDetail.TR_FileSize;
            updateComm.Parameters["@mOutTime"].Value = mDetail.TR_OutDate;
            updateComm.Parameters["@mHours"].Value = mDetail.TR_Hours;
            updateComm.Parameters["@mProductivity"].Value = mDetail.TR_Productivity;
            updateComm.Parameters["@mTRApporval"].Value = mDetail.TR_Apporval;

            updateComm.CommandText = "UPDATE tbl_TaskRecordDetail SET TR_Status = @mStatus, TR_FileSize = @mFileSize, TR_OutDate = @mOutTime, TR_TaskStatus = '0', TR_Hours = @mHours, TR_Productivity = @mProductivity, TR_Apporval=@mTRApporval WHERE Task_ID = @mTaskCode AND TR_File = @mFile AND TR_Shipment = @mShipment AND TR_TaskStatus = '1'";

            int ans = updateComm.ExecuteNonQuery();
            if (ans > 0)
            {
                return ans;
            }
            else
            {
                return 0;
            }
        }

        public int UpdateTaskRecordDetailToTaskOut_ActualTaskIn(TaskRecordDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mFile", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mShipment", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mFileSize", SqlDbType.BigInt);
            updateComm.Parameters.Add("@mTR_InDate", SqlDbType.DateTime);
            updateComm.Parameters.Add("@mOutTime", SqlDbType.DateTime);
            updateComm.Parameters.Add("@mHours", SqlDbType.Float);
            updateComm.Parameters.Add("@mProductivity", SqlDbType.Float);
            updateComm.Parameters.Add("@mTRApporval", SqlDbType.Int);

            updateComm.Parameters["@mFile"].Value = mDetail.TR_File;
            updateComm.Parameters["@mShipment"].Value = mDetail.TR_Shipment;
            updateComm.Parameters["@mTaskCode"].Value = mDetail.Task_ID;
            updateComm.Parameters["@mStatus"].Value = mDetail.TR_Status;
            updateComm.Parameters["@mFileSize"].Value = mDetail.TR_FileSize;
            updateComm.Parameters["@mTR_InDate"].Value = mDetail.TR_InDate;
            updateComm.Parameters["@mOutTime"].Value = mDetail.TR_OutDate;
            updateComm.Parameters["@mHours"].Value = mDetail.TR_Hours;
            updateComm.Parameters["@mProductivity"].Value = mDetail.TR_Productivity;
            updateComm.Parameters["@mTRApporval"].Value = mDetail.TR_Apporval;

            updateComm.CommandText = "UPDATE tbl_TaskRecordDetail SET TR_Status = @mStatus, TR_FileSize = @mFileSize, TR_InDate = @mTR_InDate, TR_OutDate = @mOutTime, TR_TaskStatus = '0', TR_Hours = @mHours, TR_Productivity = @mProductivity, TR_Apporval=@mTRApporval WHERE Task_ID = @mTaskCode AND TR_File = @mFile AND TR_Shipment = @mShipment AND TR_TaskStatus = '1'";

            int ans = updateComm.ExecuteNonQuery();
            if (ans > 0)
            {
                return ans;
            }
            else
            {
                return 0;
            }
        }

        public int UpdateTaskRecordDetailWithTimeModify(TaskRecordDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mUID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mTRID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mJobCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mFile", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mShipment", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mFileSize", SqlDbType.BigInt);
            updateComm.Parameters.Add("@mInTime", SqlDbType.DateTime);
            updateComm.Parameters.Add("@mOutTime", SqlDbType.DateTime);
            updateComm.Parameters.Add("@mHours", SqlDbType.Float);
            updateComm.Parameters.Add("@mProductivity", SqlDbType.Float);

            updateComm.Parameters["@mUID"].Value = mDetail.TR_UID;
            updateComm.Parameters["@mTRID"].Value = mDetail.TR_ID;
            updateComm.Parameters["@mJobCode"].Value = mDetail.PCP_ID;
            updateComm.Parameters["@mFile"].Value = mDetail.TR_File;
            updateComm.Parameters["@mShipment"].Value = mDetail.TR_Shipment;
            updateComm.Parameters["@mTaskCode"].Value = mDetail.Task_ID;
            updateComm.Parameters["@mStatus"].Value = mDetail.TR_Status;
            updateComm.Parameters["@mFileSize"].Value = mDetail.TR_FileSize;
            updateComm.Parameters["@mInTime"].Value = mDetail.TR_InDate;
            updateComm.Parameters["@mOutTime"].Value = mDetail.TR_OutDate;
            updateComm.Parameters["@mHours"].Value = mDetail.TR_Hours;
            updateComm.Parameters["@mProductivity"].Value = mDetail.TR_Productivity;

            updateComm.CommandText = "UPDATE tbl_TaskRecordDetail SET TR_InDate = @mInTime, TR_OutDate = @mOutTime, TR_Hours = @mHours, TR_Productivity = @mProductivity WHERE TR_UID =@mUID AND TR_ID =@mTRID AND Task_ID = @mTaskCode AND PCP_ID=@mJobCode AND TR_File = @mFile AND TR_Shipment = @mShipment AND TR_Status = @mStatus AND TR_FileSize = @mFileSize";

            int ans = updateComm.ExecuteNonQuery();
            if (ans > 0)
            {
                return ans;
            }
            else
            {
                return 0;
            }
        }

        public int UpdateTaskRecordDetailToAprroved(TaskRecordDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mTRID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mFile", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mShipment", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mJobCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mFileSize", SqlDbType.BigInt);
            updateComm.Parameters.Add("@mApprovalStatus", SqlDbType.Int); // 2 - Approved
            updateComm.Parameters.Add("@mApprovalTime", SqlDbType.DateTime);

            updateComm.Parameters["@mTRID"].Value = mDetail.TR_ID;
            updateComm.Parameters["@mFile"].Value = mDetail.TR_File;
            updateComm.Parameters["@mShipment"].Value = mDetail.TR_Shipment;
            updateComm.Parameters["@mJobCode"].Value = mDetail.PCP_ID;
            updateComm.Parameters["@mTaskCode"].Value = mDetail.Task_ID;
            updateComm.Parameters["@mStatus"].Value = mDetail.TR_Status;
            updateComm.Parameters["@mFileSize"].Value = mDetail.TR_FileSize;
            updateComm.Parameters["@mApprovalStatus"].Value = mDetail.TR_Apporval; // 2 - Approved
            updateComm.Parameters["@mApprovalTime"].Value = mDetail.TR_ApprovalTime;


            updateComm.CommandText = "UPDATE tbl_TaskRecordDetail SET TR_Apporval = @mApprovalStatus, TR_ApprovalTime = @mApprovalTime WHERE TR_ID = @mTRID AND TR_File = @mFile AND TR_Shipment = @mShipment AND PCP_ID = @mJobCode AND TR_Status = @mStatus AND Task_ID = @mTaskCode";

            int ans = updateComm.ExecuteNonQuery();
            if (ans > 0)
            {
                return ans;
            }
            else
            {
                return 0;
            }
        }

        public int UpdateTaskRecordDetailToRollback(TaskRecordDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mTRID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mFile", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mShipment", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mJobCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mFileSize", SqlDbType.BigInt);
            updateComm.Parameters.Add("@mApprovalStatus", SqlDbType.Int); // 1 - Pending
            updateComm.Parameters.Add("@mApprovalTime", SqlDbType.DateTime);

            updateComm.Parameters["@mTRID"].Value = mDetail.TR_ID;
            updateComm.Parameters["@mFile"].Value = mDetail.TR_File;
            updateComm.Parameters["@mShipment"].Value = mDetail.TR_Shipment;
            updateComm.Parameters["@mJobCode"].Value = mDetail.PCP_ID;
            updateComm.Parameters["@mTaskCode"].Value = mDetail.Task_ID;
            updateComm.Parameters["@mStatus"].Value = mDetail.TR_Status;
            updateComm.Parameters["@mFileSize"].Value = mDetail.TR_FileSize;
            updateComm.Parameters["@mApprovalStatus"].Value = mDetail.TR_Apporval; // 1 - Pending
            updateComm.Parameters["@mApprovalTime"].Value = mDetail.TR_ApprovalTime;


            updateComm.CommandText = "UPDATE tbl_TaskRecordDetail SET TR_Apporval = @mApprovalStatus, TR_ApprovalTime = NULL WHERE TR_ID = @mTRID AND TR_File = @mFile AND TR_Shipment = @mShipment AND PCP_ID = @mJobCode AND TR_Status = @mStatus AND Task_ID = @mTaskCode";

            int ans = updateComm.ExecuteNonQuery();
            if (ans > 0)
            {
                return ans;
            }
            else
            {
                return 0;
            }
        }

        public int UpdateTaskRecordDetailToDisaprroved(TaskRecordDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mTRID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mFile", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mShipment", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mJobCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mFileSize", SqlDbType.BigInt);
            updateComm.Parameters.Add("@mApprovalStatus", SqlDbType.Int); // 3 - Disapproved
            updateComm.Parameters.Add("@mApprovalTime", SqlDbType.DateTime);

            updateComm.Parameters["@mTRID"].Value = mDetail.TR_ID;
            updateComm.Parameters["@mFile"].Value = mDetail.TR_File;
            updateComm.Parameters["@mShipment"].Value = mDetail.TR_Shipment;
            updateComm.Parameters["@mJobCode"].Value = mDetail.PCP_ID;
            updateComm.Parameters["@mTaskCode"].Value = mDetail.Task_ID;
            updateComm.Parameters["@mStatus"].Value = mDetail.TR_Status;
            updateComm.Parameters["@mFileSize"].Value = mDetail.TR_FileSize;
            updateComm.Parameters["@mApprovalStatus"].Value = mDetail.TR_Apporval; // 3 - Disapproved
            updateComm.Parameters["@mApprovalTime"].Value = mDetail.TR_ApprovalTime;


            updateComm.CommandText = "UPDATE tbl_TaskRecordDetail SET TR_Apporval = @mApprovalStatus, TR_ApprovalTime = @mApprovalTime WHERE TR_ID = @mTRID AND TR_File = @mFile AND TR_Shipment = @mShipment AND PCP_ID = @mJobCode AND TR_Status = @mStatus AND Task_ID = @mTaskCode";

            int ans = updateComm.ExecuteNonQuery();
            if (ans > 0)
            {
                return ans;
            }
            else
            {
                return 0;
            }
        }

        public int UpdateTaskRecordDetailWithModifiedRecrodAndApprove(TaskRecordDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mTRID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mFile", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mFileSize", SqlDbType.BigInt);
            updateComm.Parameters.Add("@mTR_Productivity", SqlDbType.Float);
            updateComm.Parameters.Add("@mTR_Apporval", SqlDbType.Int); // 2 - Approved
            updateComm.Parameters.Add("@mTR_ApprovalTime", SqlDbType.DateTime);
            updateComm.Parameters.Add("@mTR_InDate", SqlDbType.DateTime);
            updateComm.Parameters.Add("@mTR_OutDate", SqlDbType.DateTime);
            updateComm.Parameters.Add("@mTR_Hours", SqlDbType.Float);


            updateComm.Parameters["@mTRID"].Value = mDetail.TR_ID;
            updateComm.Parameters["@mFile"].Value = mDetail.TR_File;
            updateComm.Parameters["@mFileSize"].Value = mDetail.TR_FileSize;
            updateComm.Parameters["@mTR_Productivity"].Value = mDetail.TR_Productivity;
            updateComm.Parameters["@mTR_Apporval"].Value = mDetail.TR_Apporval; // 2 - Approved
            updateComm.Parameters["@mTR_ApprovalTime"].Value = mDetail.TR_ApprovalTime;

            /*Added new Modified Task version 2.0 - (2018-08-06) */
            updateComm.Parameters["@mTR_InDate"].Value = mDetail.TR_InDate;
            updateComm.Parameters["@mTR_OutDate"].Value = mDetail.TR_OutDate;
            updateComm.Parameters["@mTR_Hours"].Value = mDetail.TR_Hours;

            updateComm.CommandText = "UPDATE tbl_TaskRecordDetail SET TR_Apporval= @mTR_Apporval, TR_ApprovalTime = @mTR_ApprovalTime, TR_FileSize = @mFileSize, TR_Productivity = @mTR_Productivity, TR_InDate = @mTR_InDate, TR_OutDate = @mTR_OutDate, TR_Hours = @mTR_Hours WHERE TR_ID = @mTRID AND TR_File = @mFile";

            //updateComm.CommandText = "UPDATE tbl_TaskRecordDetail SET TR_Apporval= @mTR_Apporval, TR_ApprovalTime = @mTR_ApprovalTime, TR_FileSize = @mFileSize, TR_Productivity = @mTR_Productivity WHERE TR_ID = @mTRID AND TR_File = @mFile";

            int ans = updateComm.ExecuteNonQuery();
            if (ans > 0)
            {
                return ans;
            }
            else
            {
                return 0;
            }
        }

        public int DeleteTaskRecordDetail(TaskRecordDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;


            deleteComm.Parameters.Add("@mTRID", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mFile", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mShipment", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mJobCode", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mStatus", SqlDbType.Int);
            deleteComm.Parameters.Add("@mFileSize", SqlDbType.BigInt);
            deleteComm.Parameters.Add("@mApprovalStatus", SqlDbType.Int); // 3 - Disapproved
            deleteComm.Parameters.Add("@mApprovalTime", SqlDbType.DateTime);

            deleteComm.Parameters["@mTRID"].Value = mDetail.TR_ID;
            deleteComm.Parameters["@mFile"].Value = mDetail.TR_File;
            deleteComm.Parameters["@mShipment"].Value = mDetail.TR_Shipment;
            deleteComm.Parameters["@mJobCode"].Value = mDetail.PCP_ID;
            deleteComm.Parameters["@mTaskCode"].Value = mDetail.Task_ID;
            deleteComm.Parameters["@mStatus"].Value = mDetail.TR_Status;
            deleteComm.Parameters["@mFileSize"].Value = mDetail.TR_FileSize;
            deleteComm.Parameters["@mApprovalStatus"].Value = mDetail.TR_Apporval; // 3 - Disapproved
            deleteComm.Parameters["@mApprovalTime"].Value = mDetail.TR_ApprovalTime;

            deleteComm.CommandText = "DELETE FROM tbl_TaskRecordDetail WHERE TR_ID = @mTRID AND TR_File = @mFile AND TR_Shipment = @mShipment AND PCP_ID = @mJobCode AND TR_Status = @mStatus AND Task_ID = @mTaskCode";

            int ans = deleteComm.ExecuteNonQuery();
            if (ans > 0)
            {
                return ans;
            }
            else
            {
                return 0;
            }
        }

        public bool TaskTaskInDetailIsExist(String mTask, String mPCPCode, String mUID ) //Check Task Record Header is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPCP_ID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mTR_UID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mTask_ID"].Value = mTask;
            SelectCommand.Parameters["@mPCP_ID"].Value = mPCPCode;
            SelectCommand.Parameters["@mTR_UID"].Value = mUID;

            /* 0 - Fresh, 1 - Tasked In , 2 - Done */

            SelectCommand.CommandText = "SELECT d.TR_ID FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON h.TR_ID = d.TR_ID WHERE d.Task_ID = '"+ mTask + "' AND h.PCP_ID = '"+ mPCPCode + "' AND d.TR_UID = '"+ mUID + "' AND d.TR_TaskStatus = '1'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            int rowCount = table.Rows.Count;

            if (rowCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string TaskTaskInDetailIsExistForDCDHoldCheckTaskedIn(String mTask, String mPCPCode) //Check Task Record Header is already exists
        {
            String uUID = "";

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPCP_ID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mTask_ID"].Value = mTask;
            SelectCommand.Parameters["@mPCP_ID"].Value = mPCPCode;


            /* 0 - Fresh, 1 - Tasked In , 2 - Done */

            SelectCommand.CommandText = "SELECT d.TR_File, d.TR_UID FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON h.TR_ID = d.TR_ID WHERE d.Task_ID = '" + mTask + "' AND h.PCP_ID = '" + mPCPCode + "' AND d.TR_TaskStatus = '1' GROUP BY d.TR_File, d.TR_UID";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            int rowCount = table.Rows.Count;

            if (rowCount > 0)
            {
                uUID= table.Rows[0][0].ToString()+ " ("+ table.Rows[0][1].ToString() + ")";
            }
            else
            {
                uUID = "";
            }
            return uUID;
        }

        public bool TaskTaskInDetailIsExistForDCDHold(String mTask, String mPCPCode) //Check Task Record Header is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPCP_ID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mTask_ID"].Value = mTask;
            SelectCommand.Parameters["@mPCP_ID"].Value = mPCPCode;
 

            /* 0 - Fresh, 1 - Tasked In , 2 - Done */

            SelectCommand.CommandText = "SELECT d.TR_ID FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON h.TR_ID = d.TR_ID WHERE d.Task_ID = '" + mTask + "' AND h.PCP_ID = '" + mPCPCode + "' AND TR_Status='2' AND d.TR_TaskStatus = '0'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            int rowCount = table.Rows.Count;

            if (rowCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetAllTaskDetailsByUserUID(String mUID)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "User_getAllTaskInAndOutDetails";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters["@mUID"].Value= mUID;

            //SelectCommand.CommandText = "SELECT d.TR_ID AS [#], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_UID = '" + mUID + "' AND TR_Status!='' ORDER BY d.TR_Index desc";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included


        public DataTable GetAllTaskDetailsByUserUIDAndFromTo(String mUID, DateTime mFrom, DateTime mTo)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "User_getAllTaskInAndOutDetailsFromTo";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //SelectCommand.CommandText = "SELECT d.TR_ID AS [#], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_UID = '" + mUID + "' AND TR_Status!='' ORDER BY d.TR_Index desc";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetPendingTaskInOutRecordByManager(String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            /* UPDATE: filter where record is not in modified record table */
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_MID = '" + mMUID + "' AND (TR_Status='2' OR TR_Status='3') AND d.TR_Apporval = 1 AND NOT EXISTS (SELECT md.[TRM_ID] FROM tbl_TaskRecordDetailModify md INNER JOIN tbl_TaskRecordHeaderModify mh ON mh.[TRM_ID] = md.[TRM_ID] INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = mh.PCP_ID WHERE md.TR_UID = d.TR_UID AND td.Task_ID = d.Task_ID AND mh.PCP_ID = d.PCP_ID AND md.TRM_Apporval = 1) ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByManagerStatusPending(String mMUID, DateTime mFrom, DateTime mTo) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_MID = '" + mMUID + "' AND TR_Status='2' AND d.TR_Apporval=4 AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_MID = '" + mMUID + "' AND TR_Status='2' AND d.TR_Apporval=4 AND d.TR_InDate BETWEEN dateadd(month,datediff(month,0,getdate()),0) AND dateadd(day,-1,dateadd(month,datediff(month,-1,getdate()),0)) ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByPIC(String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data

            /* UPDATE: filter where record is not in modified record table */
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS[UID], d.TR_ID AS[Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS[Shipment], d.TR_File AS[File Name],    d.TR_FileSize AS[Output], d.TR_UOM AS[OUM], d.Task_ID AS[Task], d.TR_Status AS[Job Status], d.TR_InDate AS[Task In Time], d.TR_OutDate AS[Task Out Time], d.TR_Hours AS[Task Hours], d.TR_Apporval As[Approval Status], d.TR_ApprovalTime As[Approval Time], d.TR_Productivity AS[Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_PIC = '"+ mPIC + "' AND (TR_Status='2' OR TR_Status='3') AND d.TR_Apporval = 1 AND NOT EXISTS (SELECT md.[TRM_ID] FROM tbl_TaskRecordDetailModify md INNER JOIN tbl_TaskRecordHeaderModify mh ON mh.[TRM_ID] = md.[TRM_ID] INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = mh.PCP_ID WHERE md.TR_UID = d.TR_UID AND td.Task_ID = d.Task_ID AND mh.PCP_ID = d.PCP_ID AND md.TRM_Apporval = 1) ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 ORDER BY d.TR_Index desc", this.mConnectionUser);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByPICStatusPending(String mPIC, DateTime mFrom, DateTime mTo) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data

            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_PIC = '"+ mPIC + "' AND TR_Status = '2' AND d.TR_Apporval = 4 AND d.TR_InDate BETWEEN '"+ mFrom +"' AND '"+ mTo +"' ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_PIC = '"+ mPIC + "' AND TR_Status='2' AND d.TR_Apporval=4 AND d.TR_InDate BETWEEN dateadd(month,datediff(month,0,getdate()),0) AND dateadd(day,-1,dateadd(month,datediff(month,-1,getdate()),0)) ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedTaskInOutRecordByManager(String mMUID, DateTime mFrom, DateTime mTo) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval!=1 AND d.TR_InDate BETWEEN '"+ mFrom + "' AND '"+ mTo + "' ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval!=1 ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedTaskInOutRecordByApprovedAndPIC(String mPIC, String mApproval) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval='" + mApproval + "' ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedTaskInOutRecordByApprovedAndManager(String mMUID, String mApproval) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval='" + mApproval + "' ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedTaskInOutRecordByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data

            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval!=1 AND d.TR_InDate BETWEEN '"+ mFrom + "' AND '"+ mTo + "' ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval!=1 ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByManagerAndUID(String mUID, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            /* UPDATE: filter where record is not in modified record table */
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_UID LIKE '%"+ mUID + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_UID LIKE '" + mUID + "%') AND NOT EXISTS (SELECT md.[TRM_ID] FROM tbl_TaskRecordDetailModify md INNER JOIN tbl_TaskRecordHeaderModify mh ON mh.[TRM_ID] = md.[TRM_ID] INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = mh.PCP_ID WHERE md.TR_UID = d.TR_UID AND td.Task_ID = d.Task_ID AND mh.PCP_ID = d.PCP_ID AND md.TRM_Apporval = 1) ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_UID LIKE '%"+ mUID + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_UID LIKE '" + mUID + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByManagerAndUIDStatusPending(String mUID, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_MID = '" + mMUID + "' AND TR_Status='2' AND d.TR_Apporval=4 AND d.TR_UID LIKE '%" + mUID + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='2' AND d.TR_Apporval=4 AND d.TR_UID LIKE '" + mUID + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByPICAndUID(String mUID, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            /* UPDATE: filter where record is not in modified record table */
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_UID LIKE '%" + mUID + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_UID LIKE '" + mUID + "%') AND NOT EXISTS (SELECT md.[TRM_ID] FROM tbl_TaskRecordDetailModify md INNER JOIN tbl_TaskRecordHeaderModify mh ON mh.[TRM_ID] = md.[TRM_ID] INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = mh.PCP_ID WHERE md.TR_UID = d.TR_UID AND td.Task_ID = d.Task_ID AND mh.PCP_ID = d.PCP_ID AND md.TRM_Apporval = 1) ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_UID LIKE '%" + mUID + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_UID LIKE '" + mUID + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByPICAndUIDStatusPending(String mUID, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_PIC = '" + mPIC + "' AND TR_Status='2' AND d.TR_Apporval=4 AND d.TR_UID LIKE '%" + mUID + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='2' AND d.TR_Apporval=4 AND d.TR_UID LIKE '" + mUID + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedTaskInOutRecordByPICAndUID(String mUID, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE ((d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=2 AND d.TR_UID LIKE '%" + mUID + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=2 AND d.TR_UID LIKE '" + mUID + "%')) OR ((d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=3 AND d.TR_UID LIKE '%" + mUID + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=3 AND d.TR_UID LIKE '" + mUID + "%')) ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedTaskInOutRecordByManagerAndUID(String mUID, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE ((d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=2 AND d.TR_UID LIKE '%" + mUID + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=2 AND d.TR_UID LIKE '" + mUID + "%')) OR ((d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=3 AND d.TR_UID LIKE '%" + mUID + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=3 AND d.TR_UID LIKE '" + mUID + "%')) ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByManagerAndPCPCode(String mPCPCode, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            /* UPDATE: filter where record is not in modified record table */
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND h.PCP_ID LIKE '" + mPCPCode + "%') AND NOT EXISTS (SELECT md.[TRM_ID] FROM tbl_TaskRecordDetailModify md INNER JOIN tbl_TaskRecordHeaderModify mh ON mh.[TRM_ID] = md.[TRM_ID] INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = mh.PCP_ID WHERE md.TR_UID = d.TR_UID AND td.Task_ID = d.Task_ID AND mh.PCP_ID = d.PCP_ID AND md.TRM_Apporval = 1) ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND h.PCP_ID LIKE '" + mPCPCode + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByManagerAndPCPCodeStatusPending(String mPCPCode, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_MID = '" + mMUID + "' AND TR_Status='2' AND d.TR_Apporval=4 AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='2' AND d.TR_Apporval=4 AND h.PCP_ID LIKE '" + mPCPCode + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByPICAndPCPCode(String mPCPCode, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            /* UPDATE: filter where record is not in modified record table */
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND h.PCP_ID LIKE '" + mPCPCode + "%') AND NOT EXISTS (SELECT md.[TRM_ID] FROM tbl_TaskRecordDetailModify md INNER JOIN tbl_TaskRecordHeaderModify mh ON mh.[TRM_ID] = md.[TRM_ID] INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = mh.PCP_ID WHERE md.TR_UID = d.TR_UID AND td.Task_ID = d.Task_ID AND mh.PCP_ID = d.PCP_ID AND md.TRM_Apporval = 1) ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND h.PCP_ID LIKE '" + mPCPCode + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByPICAndPCPCodeStatusPending(String mPCPCode, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_PIC = '" + mPIC + "' AND TR_Status='2' AND d.TR_Apporval=4 AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='2' AND d.TR_Apporval=4 AND h.PCP_ID LIKE '" + mPCPCode + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedTaskInOutRecordByPICAndPCPCode(String mPCPCode, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE ((d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=2 AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=2 AND h.PCP_ID LIKE '" + mPCPCode + "%')) OR ((d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=3 AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=3 AND h.PCP_ID LIKE '" + mPCPCode + "%')) ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedTaskInOutRecordByManagerAndPCPCode(String mPCPCode, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE ((d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=2 AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=2 AND h.PCP_ID LIKE '" + mPCPCode + "%')) OR ((d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=3 AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=3 AND h.PCP_ID LIKE '" + mPCPCode + "%')) ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedTaskInOutRecordByUIDAndPCPCodeAndTaskCode(String mPCPCode, String mTaskCode, String mUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand(" SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE  d.TR_UID = '"+ mUID +"' AND h.PCP_ID = '" + mPCPCode + "' AND d.Task_ID ='" + mTaskCode + "' AND d.TR_TaskStatus != 1 ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByManagerAndFileName(String mFileName, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            /* UPDATE: filter where record is not in modified record table */
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_File LIKE '%" + mFileName + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_File LIKE '" + mFileName + "%') AND NOT EXISTS (SELECT md.[TRM_ID] FROM tbl_TaskRecordDetailModify md INNER JOIN tbl_TaskRecordHeaderModify mh ON mh.[TRM_ID] = md.[TRM_ID] INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = mh.PCP_ID WHERE md.TR_UID = d.TR_UID AND td.Task_ID = d.Task_ID AND mh.PCP_ID = d.PCP_ID AND md.TRM_Apporval = 1) ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_File LIKE '%" + mFileName + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_File LIKE '" + mFileName + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByManagerAndFileNameStatusPending(String mFileName, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_MID = '" + mMUID + "' AND TR_Status='2' AND d.TR_Apporval=4 AND d.TR_File LIKE '%" + mFileName + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='2' AND d.TR_Apporval=4 AND d.TR_File LIKE '" + mFileName + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByPICAndFileName(String mFileName, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            /* UPDATE: filter where record is not in modified record table */
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_File LIKE '%" + mFileName + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_File LIKE '" + mFileName + "%') AND NOT EXISTS (SELECT md.[TRM_ID] FROM tbl_TaskRecordDetailModify md INNER JOIN tbl_TaskRecordHeaderModify mh ON mh.[TRM_ID] = md.[TRM_ID] INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = mh.PCP_ID WHERE md.TR_UID = d.TR_UID AND td.Task_ID = d.Task_ID AND mh.PCP_ID = d.PCP_ID AND md.TRM_Apporval = 1) ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_File LIKE '%" + mFileName + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND d.TR_File LIKE '" + mFileName + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingTaskInOutRecordByPICAndFileNameStatusPending(String mFileName, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_PIC = '" + mPIC + "' AND TR_Status='2' AND d.TR_Apporval=4 AND d.TR_File LIKE '%" + mFileName + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='2' AND d.TR_Apporval=4 AND d.TR_File LIKE '" + mFileName + "%') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedTaskInOutRecordByPICAndFileName(String mFileName, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE ((d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=2 AND d.TR_File LIKE '%" + mFileName + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=2 AND d.TR_File LIKE '" + mFileName + "%')) OR ((d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=3 AND d.TR_File LIKE '%" + mFileName + "') OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=3 AND d.TR_File LIKE '" + mFileName + "%')) ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedTaskInOutRecordByManagerAndFileName(String mFileName, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE ((d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=2 AND d.TR_File LIKE '%" + mFileName + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=2 AND d.TR_File LIKE '" + mFileName + "%')) OR ((d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=3 AND d.TR_File LIKE '%" + mFileName + "') OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=3 AND d.TR_File LIKE '" + mFileName + "%')) ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPCPRecordByDateRange(String mMUID, DateTime mFrom, DateTime mTo) //Find details from Department Name
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            /* UPDATE: filter where record is not in modified record table */
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND (d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "') AND NOT EXISTS (SELECT md.[TRM_ID] FROM tbl_TaskRecordDetailModify md INNER JOIN tbl_TaskRecordHeaderModify mh ON mh.[TRM_ID] = md.[TRM_ID] INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = mh.PCP_ID WHERE md.TR_UID = d.TR_UID AND td.Task_ID = d.Task_ID AND mh.PCP_ID = d.PCP_ID AND md.TRM_Apporval = 1) ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=1 AND (d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPCPRecordByDateRangeStatusPending(String mMUID, DateTime mFrom, DateTime mTo) //Find details from Department Name
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_MID = '" + mMUID + "' AND TR_Status='2' AND d.TR_Apporval=4 AND (d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "') ORDER BY d.TR_Index desc", this.mConnectionUser);


            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPCPRecordByDateRangeByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Find details from Department Name
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            /* UPDATE: filter where record is not in modified record table */
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND (d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "') AND NOT EXISTS (SELECT md.[TRM_ID] FROM tbl_TaskRecordDetailModify md INNER JOIN tbl_TaskRecordHeaderModify mh ON mh.[TRM_ID] = md.[TRM_ID] INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = mh.PCP_ID WHERE md.TR_UID = d.TR_UID AND td.Task_ID = d.Task_ID AND mh.PCP_ID = d.PCP_ID AND md.TRM_Apporval = 1) ORDER BY d.TR_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=1 AND (d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "') ORDER BY d.TR_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPCPRecordByDateRangeByPICStatusPending(String mPIC, DateTime mFrom, DateTime mTo) //Find details from Department Name
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE d.TR_PIC = '" + mPIC + "' AND TR_Status='2' AND d.TR_Apporval=4 AND (d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "') ORDER BY d.TR_Index desc", this.mConnectionUser);


            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedPCPRecordByDateRangeByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Find details from Department Name
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=2 AND (d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) OR (d.TR_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TR_Apporval=3 AND (d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) ORDER BY d.TR_Index desc", this.mConnectionUser);


            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedPCPRecordByDateRange(String mMUID, DateTime mFrom, DateTime mTo) //Find details from Department Name
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID WHERE (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=2 AND (d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) OR (d.TR_MID = '" + mMUID + "' AND TR_Status='3' AND d.TR_Apporval=3 AND (d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "'))ORDER BY d.TR_Index desc", this.mConnectionUser);


            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public int GetQuotaSize(String mTask, String mPCPCode, String mUID) //Get all Matrix details
        {
            int uQuotaSize = 0;
            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.TR_Quota FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID WHERE h.PCP_ID = '" + mPCPCode + "' AND d.Task_ID = '" + mTask + "' AND d.TR_UID = '" + mUID + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uQuotaSize = int.Parse(row[0].ToString());
            }
            return uQuotaSize;

        }

        public int GetActualFileSizeFroPending(String mPCPCode, String mTaskCode, String mFile) //Get all PCP details
        {

            int uActualFileSize = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT SUM(d.TR_FileSize) FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID WHERE h.PCP_ID = '" + mPCPCode + "' AND d.Task_ID = '" + mTaskCode + "' AND d.TR_Status = '2' AND d.TR_Apporval = '4' AND d.TR_File='"+ mFile + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    uActualFileSize = 0;
                }
                else
                {
                    uActualFileSize = int.Parse(row[0].ToString());
                }

            }
            return uActualFileSize;

        }

        public float GetActualHoursForPending(String mPCPCode, String mTaskCode, String mFile) //Get all PCP details
        {

            float ActualHours = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT SUM(d.TR_Hours) FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID WHERE h.PCP_ID = '" + mPCPCode + "' AND d.Task_ID = '" + mTaskCode + "' AND d.TR_Status = '2' AND d.TR_Apporval = '4' AND d.TR_File='" + mFile + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    ActualHours = 0;
                }
                else
                {
                    ActualHours = float.Parse(row[0].ToString());
                }

            }
            return ActualHours;

        }

        public float GetActualFileHours(String mPCPCode, String mTaskCode, String mUID) //Get all PCP details
        {

            float ActualHours = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT TR_Hours  FROM tbl_TaskRecordDetail  WHERE TR_UID='"+ mUID + "' AND PCP_ID='"+ mPCPCode + "' AND Task_ID='"+ mTaskCode + "' AND TR_Status=3", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    ActualHours = 0;
                }
                else
                {
                    ActualHours = float.Parse(row[0].ToString());
                }

            }
            return ActualHours;

        }

        public DateTime GetActualDoneFirstTaskIn(String mPCPCode, String mTaskCode, String mUID) //Get all PCP details
        {

            DateTime uActualDoneFirstTaskIn = DateTime.Parse("1/1/1753 ");

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT TR_InDate FROM tbl_TaskRecordDetail  WHERE TR_UID='" + mUID + "' AND PCP_ID='" + mPCPCode + "' AND Task_ID='" + mTaskCode + "' AND TR_Status=3", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    uActualDoneFirstTaskIn = DateTime.Parse("1/1/1753 ");
                }
                else
                {
                    uActualDoneFirstTaskIn = DateTime.Parse(row[0].ToString());
                }

            }
            return uActualDoneFirstTaskIn;

        }

        public int GetActualDoneCountFromRecord(String mPCPCode, String mTaskCode, String mUID) //Get all PCP details
        {

            int uActualDoneCount = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT TR_FileSize FROM tbl_TaskRecordDetail  WHERE TR_UID='" + mUID + "' AND PCP_ID='" + mPCPCode + "' AND Task_ID='" + mTaskCode + "' AND TR_Status=3", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    uActualDoneCount = 0;
                }
                else
                {
                    uActualDoneCount = int.Parse(row[0].ToString());
                }

            }
            return uActualDoneCount;

        }

        public DateTime GetActualTaskInForPending(String mPCPCode, String mTaskCode, String mFile) //Get all PCP details
        {

            DateTime uActualTaskIn = DateTime.Now;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT MIN(d.TR_InDate) FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID WHERE h.PCP_ID = '"+ mPCPCode + "' AND d.Task_ID = '"+ mTaskCode + "' AND d.TR_Status = '2' AND d.TR_Apporval = '4' AND d.TR_File = '" + mFile + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    uActualTaskIn = DateTime.Parse("1/1/1753 00:00:00 AM");
                }
                else
                {
                    uActualTaskIn = DateTime.Parse(row[0].ToString());
                }

            }
            return uActualTaskIn;

        }

        public DateTime GetActualTaskInByRecordID(String mRecordID) //Get all PCP details
        {

            DateTime uActualTaskIn = DateTime.Now;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT d.TR_ActualTaskIn FROM tbl_TaskRecordDetail d WHERE d.TR_ID = '"+ mRecordID +"'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    uActualTaskIn = DateTime.Parse("1/1/1753 00:00:00 AM");
                }
                else
                {
                    uActualTaskIn = DateTime.Parse(row[0].ToString());
                }

            }
            return uActualTaskIn;

        }

        public DateTime GetActualTaskOutByRecordID(String mRecordID) //Get all PCP details
        {

            DateTime uActualTaskIn = DateTime.Now;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT d.TR_OutDate FROM tbl_TaskRecordDetail d WHERE d.TR_ID = '" + mRecordID + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    uActualTaskIn = DateTime.Parse("1/1/1753 00:00:00 AM");
                }
                else
                {
                    uActualTaskIn = DateTime.Parse(row[0].ToString());
                }

            }
            return uActualTaskIn;

        }

        public DataTable GetAllGetActualFileSizeFroPending(String mPCPCode, String mTaskCode, String mUID)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT d.TR_ID AS [#], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Map Size], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours] FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID WHERE h.PCP_ID = '" + mPCPCode + "' AND d.Task_ID = '" + mTaskCode + "' AND d.TR_Status = '2' AND d.TR_Apporval = '1' AND d.TR_UID='" + mUID + "'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public float GetActualHoursCountForPending(String mPCPCode, String mTaskCode, String mFile) //Get all PCP details
        {

            float uActualFileSize = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT SUM(d.TR_Hours) FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID WHERE h.PCP_ID = '" + mPCPCode + "' AND d.Task_ID = '" + mTaskCode + "' AND d.TR_Status = '2' AND d.TR_Apporval = '4' AND d.TR_File='" + mFile + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    uActualFileSize = 0;
                }
                else
                {
                    uActualFileSize = float.Parse(row[0].ToString());
                }

            }
            return uActualFileSize;

        }

        public List<String> GetTaskCodeByPCPCodeAndStatusNotDoneOrHold(String mPCPCode) //Get task codes by PCP Code where not Done status
        {

            List<String> uTaskCode = new List<string>();

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT TaskCode FROM PCPDetail WHERE PCPCode='" + mPCPCode + "' AND PCPStatus!='Done' AND PCPStatus!='On Hold'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uTaskCode.Add(row[0].ToString());
            }
            return uTaskCode;

        }

        public DateTime GetTaskedInDateTime(String mPCPCode) //Get Shipment Name by PCP Code
        {

            DateTime uInDateTime = DateTime.Now;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT td.TR_InDate FROM tbl_PCPDetail pd INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID WHERE pd.PCP_ID = '" + mPCPCode + "' AND pd.PCP_Status = '2' AND td.TR_TaskStatus='1'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (String.IsNullOrEmpty(row[0].ToString()))
                {
                    uInDateTime = DateTime.Now;
                }
                else
                {
                    uInDateTime = DateTime.Parse(row[0].ToString());
                }
            }
            return uInDateTime;

        }

        public int GetTaskStatusByPCPCode(String mPCPCode, String mUID) //Get Shipment Name by PCP Code
        {

            int uStatus = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT td.TR_TaskStatus FROM tbl_PCPDetail pd INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID WHERE pd.PCP_ID = '"+ mPCPCode + "' AND td.TR_UID = '" + mUID + "' AND pd.PCP_Status = '2' AND td.TR_TaskStatus = '1'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (String.IsNullOrEmpty(row[0].ToString()))
                {
                    uStatus = 0;
                }
                else
                {
                    uStatus = int.Parse(row[0].ToString());
                }
            }
            return uStatus;

        }

        public int GetTaskStatusByPCPCodeAndTaskCode(String mPCPCode, String mTaskCode) //Get Shipment Name by PCP Code
        {

            int uStatus = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT td.TR_TaskStatus FROM tbl_PCPDetail pd INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID WHERE pd.PCP_ID = '" + mPCPCode + "' AND td.Task_ID = '" + mTaskCode + "' AND pd.PCP_Status = '2' AND td.TR_TaskStatus = '1'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (String.IsNullOrEmpty(row[0].ToString()))
                {
                    uStatus = 0;
                }
                else
                {
                    uStatus = int.Parse(row[0].ToString());
                }
            }
            return uStatus;

        }

        public DataTable GetTaskInUsersByPCPCode(String mPCPCode, String mTaskCode) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT td.TR_UID FROM tbl_PCPDetail pd INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID WHERE pd.PCP_ID = '"+mPCPCode+ "' AND pd.PCP_Status = '2' AND td.TR_TaskStatus = '1' AND td.Task_ID='"+ mTaskCode + "'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetTaskInUsersByPCPCodeAndTaskCode(String mPCPCode, String mTaskCode) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT td.TR_UID FROM tbl_PCPDetail pd INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID WHERE pd.PCP_ID = '" + mPCPCode + "' AND td.Task_ID = '" + mTaskCode + "' AND pd.PCP_Status = '2' AND td.TR_TaskStatus = '1'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public int GetTaskInUsersCountByPCPCode(String mPCPCode) //Get Actuall Last PCP ID details
        {
            int uItemCode = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT COUNT(td.TR_UID) FROM tbl_PCPDetail pd INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID WHERE pd.PCP_ID = '" + mPCPCode + "' AND pd.PCP_Status = '2' AND td.TR_TaskStatus = '1'", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT RIGHT(MAX(TR_ID) , LEN(MAX(TR_ID)) -6) FROM tbl_TaskRecordDetail WHERE TR_UID='" + mUID + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count == 0)
            {
                uItemCode = 0;
            }
            else
            {
                uItemCode = int.Parse(table.Rows[0][1].ToString());
            }

            return uItemCode;

        }

        public DataTable GetTaskedInRecordByUser(String mUID) //Get Shipment Name by PCP Code
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            //SelectCommand.CommandText = "SELECT pd.PCP_Project, td.TR_Shipment, td.TR_File, th.PCP_ID, td.Task_ID +' - '+ tsd.Task_Description AS [Task Code], td.TR_InDate FROM tbl_PCPDetail pd INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID INNER JOIN tbl_TaskDetail tsd ON tsd.Task_ID = td.Task_ID WHERE td.TR_UID = '" + mUID + "' AND pd.PCP_Status = '2' AND td.TR_TaskStatus = '1'";

            SelectCommand.CommandText = "SELECT pd.PCP_Project, td.TR_Shipment, td.TR_File, th.PCP_ID, td.Task_ID +' - '+ tsd.Task_Description AS [Task Code], td.TR_InDate  FROM tbl_PCPDetail pd INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID INNER JOIN tbl_TaskDetail tsd ON tsd.Task_ID = td.Task_ID  AND tsd.PC_ProcessCode = pd.PC_ProcessCode WHERE td.TR_UID = '" + mUID + "' AND pd.PCP_Status = '2' AND td.TR_TaskStatus = '1' GROUP BY pd.PCP_Project, td.TR_Shipment, td.TR_File, th.PCP_ID, td.Task_ID + ' - ' + tsd.Task_Description, td.TR_InDate";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        /// <summary>
        /// DEBUG: Last row count getting issue.
        /// </summary>
        /// <param name="mUID"></param>
        /// <returns></returns>
        public int GetUserLastRecordCount(String mUID) //Get Actuall Last PCP ID details
        {
            int uItemCode = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT MAX(TR_Index), CAST(RIGHT(MAX(TR_ID) , LEN(MAX(TR_ID)) -6) AS INT) AS [TRID] FROM tbl_TaskRecordDetail WHERE(TR_UID = '" + mUID + "' AND TR_Index = (SELECT MAX(TR_Index) FROM tbl_TaskRecordDetail)) OR(TR_UID = '" + mUID + "') GROUP BY TR_Index ORDER BY[TRID] DESC", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT RIGHT(MAX(TR_ID) , LEN(MAX(TR_ID)) -6) FROM tbl_TaskRecordDetail WHERE TR_UID='" + mUID + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count == 0)
            {
                uItemCode = 0;
            }
            else
            {
                uItemCode = int.Parse(table.Rows[0][1].ToString());
            }

            return uItemCode;

        }

        public String GetProjectNameByPCPID_TaskIDAndPCPFile(String mPCPCode, String mTaskCode, String mFileName)
        {
            String uProject = "";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT PCP_Project FROM tbl_PCPDetail WHERE PCP_ID = '" + mPCPCode + "' AND Task_ID = '" + mTaskCode + "' AND PCP_File = '" + mFileName + "' GROUP BY PCP_Project", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProject = row[0].ToString();
            }
            return uProject;
        }
        public String GetProcessCodeNameByPCPID_TaskIDAndPCPFile(String mPCPCode, String mTaskCode, String mFileName)
        {
            String uProject = "";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT PC_ProcessCode FROM tbl_PCPDetail WHERE PCP_ID = '" + mPCPCode + "' AND Task_ID = '" + mTaskCode + "' AND PCP_File = '" + mFileName + "' GROUP BY PC_ProcessCode", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProject = row[0].ToString();
            }
            return uProject;
        }

        /*Disapproval*/

        public int GetCountForTaskDoneFirlterByPCPAndTaskCode(String mPCPCode, String mTaskCode, String mFileName) //Get Count for pending records in given PCP and Task Code details
        {

            int uPendiongCont = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT COUNT(PCP_ID) FROM tbl_TaskRecordDetail WHERE PCP_ID = '" + mPCPCode + "' AND Task_ID = '" + mTaskCode + "' AND TR_Status=3 AND TR_File = '" + mFileName + "' AND TR_Apporval=1 GROUP BY PCP_ID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    uPendiongCont = 0;
                }
                else
                {
                    uPendiongCont = int.Parse(row[0].ToString());
                }

            }
            return uPendiongCont;

        }

        public int GetCountForTaskPendingFirlterByPCPAndTaskCode(String mPCPCode, String mTaskCode, String mFileName) //Get Count for pending records in given PCP and Task Code details
        {

            int uPendiongCont = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT COUNT(PCP_ID) FROM tbl_TaskRecordDetail WHERE PCP_ID = '" + mPCPCode + "' AND Task_ID = '" + mTaskCode + "' AND TR_Status=2 AND TR_File = '" + mFileName + "' AND TR_Apporval=1 GROUP BY PCP_ID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    uPendiongCont = 0;
                }
                else
                {
                    uPendiongCont = int.Parse(row[0].ToString());
                }

            }
            return uPendiongCont;

        }


        /* Reports */

        public DataTable GetProjectProductivityByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_Ranked_Chart";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            
            //SelectCommand.CommandText = "DECLARE @TempProjectProductivity_@mPIC  TABLE (Project nvarchar(100), Productivity float); DECLARE @TotalProductivity int; INSERT INTO @TempProjectProductivity_@mPIC SELECT PCPDetail.PCP_Project, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '"+ mPIC + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '"+ mFrom + "' AND '"+ mTo + "' GROUP BY PCPDetail.PCP_Project set @TotalProductivity = (select sum(Productivity) from @TempProjectProductivity_@mPIC) SELECT Project, ROUND(((Productivity / @TotalProductivity) * 100), 2) AS Productivity FROM @TempProjectProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable CurrentCapacityPIC(String mPIC) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentCapacity";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public DataTable CurrentCapacityMID(String mPIC, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentCapacity_MID";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public DataTable WorkLoadPIC(String mPIC) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public DataTable WorkLoadMID(String mPIC, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoadMID";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public DataTable GetProjectProductivityByPICAndProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_RankedByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //SelectCommand.CommandText = "DECLARE @TempProjectProductivity_@mPIC  TABLE (Project nvarchar(100), Productivity float); DECLARE @TotalProductivity int; INSERT INTO @TempProjectProductivity_@mPIC SELECT PCPDetail.PCP_Project, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND PCPDetail.PCP_Project='"+ mProject + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY PCPDetail.PCP_Project set @TotalProductivity = (select sum(Productivity) from @TempProjectProductivity_@mPIC) SELECT Project, ROUND(((Productivity / @TotalProductivity) * 100), 2) AS Productivity FROM @TempProjectProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetProjectProductivityByPICAndProjectAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mProject, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_RankedByProjectAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //SelectCommand.CommandText = "DECLARE @TempProjectProductivity_@mPIC  TABLE (Project nvarchar(100), Productivity float); DECLARE @TotalProductivity int; INSERT INTO @TempProjectProductivity_@mPIC SELECT PCPDetail.PCP_Project, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND PCPDetail.PCP_Project='"+ mProject + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY PCPDetail.PCP_Project set @TotalProductivity = (select sum(Productivity) from @TempProjectProductivity_@mPIC) SELECT Project, ROUND(((Productivity / @TotalProductivity) * 100), 2) AS Productivity FROM @TempProjectProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetProjectProductivityByPICAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mManager) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_RankedByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMID"].Value = mManager;

            //SelectCommand.CommandText = "DECLARE @TempManagerProductivity_@mPIC TABLE (Project nvarchar(100), Productivity float); DECLARE @TotalProductivity int; INSERT INTO @TempManagerProductivity_@mPIC SELECT PCPDetail.PCP_Project, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND d.TR_MID='" + mManager + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY PCPDetail.PCP_Project set @TotalProductivity = (select sum(Productivity) from @TempManagerProductivity_@mPIC) SELECT Project, ROUND(((Productivity / @TotalProductivity) * 100), 2) AS Productivity FROM @TempManagerProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetProjectProductivityByPICAndUID(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_RankedByUID";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);


            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //SelectCommand.CommandText = "DECLARE @TempManagerProductivity_@mPIC TABLE (Project nvarchar(100), Productivity float); DECLARE @TotalProductivity int; INSERT INTO @TempManagerProductivity_@mPIC SELECT PCPDetail.PCP_Project, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND d.TR_UID='" + mUID + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY PCPDetail.PCP_Project set @TotalProductivity = (select sum(Productivity) from @TempManagerProductivity_@mPIC) SELECT Project, ROUND(((Productivity / @TotalProductivity) * 100), 2) AS Productivity FROM @TempManagerProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetProjectProductivityByPICAndUIDAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mUID, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_RankedByUIDAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);


            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //SelectCommand.CommandText = "DECLARE @TempManagerProductivity_@mPIC TABLE (Project nvarchar(100), Productivity float); DECLARE @TotalProductivity int; INSERT INTO @TempManagerProductivity_@mPIC SELECT PCPDetail.PCP_Project, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND d.TR_UID='" + mUID + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY PCPDetail.PCP_Project set @TotalProductivity = (select sum(Productivity) from @TempManagerProductivity_@mPIC) SELECT Project, ROUND(((Productivity / @TotalProductivity) * 100), 2) AS Productivity FROM @TempManagerProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetTeamProductivityByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_Ranked_Chart";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
  

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            

            //SelectCommand.CommandText = "DECLARE @TempTeamProductivity_@mPIC  TABLE (Project nvarchar(100), Productivity float); DECLARE @TeamProductivity int; INSERT INTO @TempTeamProductivity_@mPIC SELECT d.TR_MID, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '"+ mPIC + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '"+ mFrom + "' AND '"+ mTo + "' GROUP BY d.TR_MID set @TeamProductivity = (select sum(Productivity) from @TempTeamProductivity_@mPIC) SELECT Project, ROUND(((Productivity / @TeamProductivity) * 100), 2) AS Productivity FROM @TempTeamProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetTeamProductivityByPICAndProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_RankedByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //SelectCommand.CommandText = "DECLARE @TempTeamProductivity_@mPIC  TABLE (Project nvarchar(100), Productivity float); DECLARE @TeamProductivity int; INSERT INTO @TempTeamProductivity_@mPIC SELECT d.TR_MID, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND PCPDetail.PCP_Project='" + mProject + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY d.TR_MID set @TeamProductivity = (select sum(Productivity) from @TempTeamProductivity_@mPIC) SELECT Project, ROUND(((Productivity / @TeamProductivity) * 100), 2) AS Productivity FROM @TempTeamProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetTeamProductivityByPICAndProjectAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mProject, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_RankedByProjectAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mMUID"].Value = mPIC;

            //SelectCommand.CommandText = "DECLARE @TempTeamProductivity_@mPIC  TABLE (Project nvarchar(100), Productivity float); DECLARE @TeamProductivity int; INSERT INTO @TempTeamProductivity_@mPIC SELECT d.TR_MID, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND PCPDetail.PCP_Project='" + mProject + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY d.TR_MID set @TeamProductivity = (select sum(Productivity) from @TempTeamProductivity_@mPIC) SELECT Project, ROUND(((Productivity / @TeamProductivity) * 100), 2) AS Productivity FROM @TempTeamProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetTeamProductivityByPICAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mManager) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_RankedByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMID"].Value = mManager;

            //SelectCommand.CommandText = "DECLARE @TempTeamProductivity_@mPIC  TABLE (Project nvarchar(100), Productivity float); DECLARE @TeamProductivity int; INSERT INTO @TempTeamProductivity_@mPIC SELECT d.TR_MID, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND d.TR_MID='" + mManager + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY d.TR_MID set @TeamProductivity = (select sum(Productivity) from @TempTeamProductivity_@mPIC) SELECT Project, ROUND(((Productivity / @TeamProductivity) * 100), 2) AS Productivity FROM @TempTeamProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetTeamProductivityByPICAndUID(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_RankedByUID";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //SelectCommand.CommandText = "DECLARE @TempTeamProductivity_@mPIC  TABLE (Project nvarchar(100), Productivity float); DECLARE @TeamProductivity int; INSERT INTO @TempTeamProductivity_@mPIC SELECT d.TR_MID, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND d.TR_UID='" + mUID + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY d.TR_MID set @TeamProductivity = (select sum(Productivity) from @TempTeamProductivity_@mPIC) SELECT Project, ROUND(((Productivity / @TeamProductivity) * 100), 2) AS Productivity FROM @TempTeamProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetTeamProductivityByPICAndUIDAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mUID, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_RankedByUIDAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;
            
            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetUserProductivityByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_Ranked_Chart";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);


            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //SelectCommand.CommandText = "DECLARE @TempUserProductivity_@mPIC TABLE(UserID nvarchar(100), Productivity float); DECLARE @UserProductivity int; INSERT INTO @TempUserProductivity_@mPIC SELECT d.TR_UID, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_PIC = '"+ mPIC +"' AND d.TR_InDate BETWEEN '"+ mFrom +"' AND '"+ mTo +"' GROUP BY d.TR_UID set @UserProductivity = (select sum(Productivity) from @TempUserProductivity_@mPIC) SELECT UserID, ROUND(((Productivity / @UserProductivity) * 100), 2) AS Productivity FROM @TempUserProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;


            DataTable table = new DataTable();
            da.Fill(table);
            return table;


        }

        public DataTable GetUserProductivityByPICAndProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_Ranked_ChartByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);


            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //SelectCommand.CommandText = "DECLARE @TempUserProductivity_@mPIC TABLE(UserID nvarchar(100), Productivity float); DECLARE @UserProductivity int; INSERT INTO @TempUserProductivity_@mPIC SELECT d.TR_UID, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_PIC = '" + mPIC + "' AND PCPDetail.PCP_Project='" + mProject + "' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY d.TR_UID set @UserProductivity = (select sum(Productivity) from @TempUserProductivity_@mPIC) SELECT UserID, ROUND(((Productivity / @UserProductivity) * 100), 2) AS Productivity FROM @TempUserProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetUserProductivityByPICAndProjectAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mProject, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_Ranked_ChartByProjectAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);


            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //SelectCommand.CommandText = "DECLARE @TempUserProductivity_@mPIC TABLE(UserID nvarchar(100), Productivity float); DECLARE @UserProductivity int; INSERT INTO @TempUserProductivity_@mPIC SELECT d.TR_UID, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_PIC = '" + mPIC + "' AND PCPDetail.PCP_Project='" + mProject + "' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY d.TR_UID set @UserProductivity = (select sum(Productivity) from @TempUserProductivity_@mPIC) SELECT UserID, ROUND(((Productivity / @UserProductivity) * 100), 2) AS Productivity FROM @TempUserProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetUserProductivityByPICAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mManager) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_Ranked_ChartByUIDAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMID", SqlDbType.NVarChar);


            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMID"].Value = mManager;

            // SelectCommand.CommandText = "DECLARE @TempUserProductivity_@mPIC TABLE(UserID nvarchar(100), Productivity float); DECLARE @UserProductivity int; INSERT INTO @TempUserProductivity_@mPIC SELECT d.TR_UID, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_PIC = '" + mPIC + "' AND d.TR_MID='" + mManager + "' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY d.TR_UID set @UserProductivity = (select sum(Productivity) from @TempUserProductivity_@mPIC) SELECT UserID, ROUND(((Productivity / @UserProductivity) * 100), 2) AS Productivity FROM @TempUserProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetUserProductivityByPICAndUID(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {
           
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_Ranked_ChartByUID";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);


            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //SelectCommand.CommandText = "DECLARE @TempUserProductivity_@mPIC TABLE(UserID nvarchar(100), Productivity float); DECLARE @UserProductivity int; INSERT INTO @TempUserProductivity_@mPIC SELECT d.TR_UID, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_PIC = '" + mPIC + "' AND d.TR_UID='" + mUID + "' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY d.TR_UID set @UserProductivity = (select sum(Productivity) from @TempUserProductivity_@mPIC) SELECT UserID, ROUND(((Productivity / @UserProductivity) * 100), 2) AS Productivity FROM @TempUserProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetUserProductivityByPICAndUIDAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mUID, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_Ranked_ChartByUIDWithManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);


            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetTaskWiseProductivityByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            SelectCommand.CommandText = "DECLARE @TempProductivity_@mPIC  TABLE ( Task nvarchar(100), Productivity float ); DECLARE @TotalAge int; INSERT INTO @TempProductivity_@mPIC SELECT TaskDetail.Task_Description, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY TaskDetail.Task_Description set @TotalAge = (select sum(Productivity) from @TempProductivity_@mPIC) SELECT Task,ROUND(((Productivity/@TotalAge)*100),2) AS Productivity FROM @TempProductivity_@mPIC ORDER BY Productivity DESC";

            //SelectCommand.CommandText = "SELECT TaskDetail.Task_Description, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '"+ mPIC + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY TaskDetail.Task_Description";
            //SelectCommand.CommandText = "SELECT tskd.Task_Description, SUM(trd.TR_Productivity) FROM tbl_TaskRecordDetail trd INNER JOIN tbl_TaskDetail tskd ON tskd.Task_ID = trd.Task_ID WHERE trd.TR_InDate BETWEEN '12-01-2017 00:00:00' AND '12-31-2017 23:59:59' AND trd.TR_PIC = '"+ mPIC + "' AND trd.TR_Apporval = 2 GROUP BY tskd.Task_Description";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetTaskWiseProductivityByPICAndProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            SelectCommand.CommandText = "DECLARE @TempProductivity_@mPIC  TABLE ( Task nvarchar(100), Productivity float ); DECLARE @TotalAge int; INSERT INTO @TempProductivity_@mPIC SELECT TaskDetail.Task_Description, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND PCPDetail.PCP_Project='" + mProject + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY TaskDetail.Task_Description set @TotalAge = (select sum(Productivity) from @TempProductivity_@mPIC) SELECT Task,ROUND(((Productivity/@TotalAge)*100),2) AS Productivity FROM @TempProductivity_@mPIC ORDER BY Productivity DESC";

            //SelectCommand.CommandText = "SELECT TaskDetail.Task_Description, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '"+ mPIC + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY TaskDetail.Task_Description";
            //SelectCommand.CommandText = "SELECT tskd.Task_Description, SUM(trd.TR_Productivity) FROM tbl_TaskRecordDetail trd INNER JOIN tbl_TaskDetail tskd ON tskd.Task_ID = trd.Task_ID WHERE trd.TR_InDate BETWEEN '12-01-2017 00:00:00' AND '12-31-2017 23:59:59' AND trd.TR_PIC = '"+ mPIC + "' AND trd.TR_Apporval = 2 GROUP BY tskd.Task_Description";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetTaskWiseProductivityByPICAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mManager) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            SelectCommand.CommandText = "DECLARE @TempProductivity_@mPIC  TABLE ( Task nvarchar(100), Productivity float ); DECLARE @TotalAge int; INSERT INTO @TempProductivity_@mPIC SELECT TaskDetail.Task_Description, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND d.TR_MID='" + mManager + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY TaskDetail.Task_Description set @TotalAge = (select sum(Productivity) from @TempProductivity_@mPIC) SELECT Task,ROUND(((Productivity/@TotalAge)*100),2) AS Productivity FROM @TempProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetTaskWiseProductivityByPICAndUID(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            SelectCommand.CommandText = "DECLARE @TempProductivity_@mPIC  TABLE ( Task nvarchar(100), Productivity float ); DECLARE @TotalAge int; INSERT INTO @TempProductivity_@mPIC SELECT TaskDetail.Task_Description, SUM(d.TR_Productivity) FROM tbl_TaskRecordDetail d INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode WHERE d.TR_PIC = '" + mPIC + "' AND d.TR_UID='" + mUID + "' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY TaskDetail.Task_Description set @TotalAge = (select sum(Productivity) from @TempProductivity_@mPIC) SELECT Task,ROUND(((Productivity/@TotalAge)*100),2) AS Productivity FROM @TempProductivity_@mPIC ORDER BY Productivity DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetUsersProductivityExceeded15ByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_ExceedProductivity150";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;


            //SelectCommand.CommandText = "SELECT TR_UID AS [UID], TR_InDate [Task In],TR_Productivity AS [Productivity] FROM tbl_TaskRecordDetail WHERE TR_Apporval = 2 AND TR_Productivity> 150 AND TR_PIC = '"+ mPIC + "' AND TR_InDate BETWEEN '"+ mFrom +"' AND '"+ mTo +"' ORDER BY TR_UID desc";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetUsersProductivityExceeded15ByPICAndProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_ExceedProductivity150ByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //SelectCommand.CommandText = "SELECT td.TR_UID AS [UID], td.TR_InDate [Task In],td.TR_Productivity AS [Productivity] FROM tbl_TaskRecordDetail td INNER JOIN tbl_PCPDetail pd ON td.PCP_ID = td.PCP_ID AND td.Task_ID = pd.Task_ID WHERE td.TR_Apporval = 2 AND td.TR_Productivity > 150 AND td.TR_PIC = '" + mPIC + "' AND pd.PCP_Project = '" + mProject + "' AND td.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' ORDER BY td.TR_UID desc";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public DataTable GetUsersProductivityExceeded15ByPICAndProjectAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mProject, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_ExceedProductivity150ByProjectAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //SelectCommand.CommandText = "SELECT td.TR_UID AS [UID], td.TR_InDate [Task In],td.TR_Productivity AS [Productivity] FROM tbl_TaskRecordDetail td INNER JOIN tbl_PCPDetail pd ON td.PCP_ID = td.PCP_ID AND td.Task_ID = pd.Task_ID WHERE td.TR_Apporval = 2 AND td.TR_Productivity > 150 AND td.TR_PIC = '" + mPIC + "' AND pd.PCP_Project = '" + mProject + "' AND td.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' ORDER BY td.TR_UID desc";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public DataTable GetUsersProductivityExceeded15ByPICAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mManager) //Get Shipment Name by PCP Code
        {
            
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_ExceedProductivity150PICAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMID"].Value = mManager;


            //SelectCommand.CommandText = "SELECT td.TR_UID AS [UID], td.TR_InDate [Task In],td.TR_Productivity AS [Productivity] FROM tbl_TaskRecordDetail td WHERE td.TR_Apporval = 2 AND td.TR_Productivity > 150 AND td.TR_PIC = '" + mPIC + "' AND td.TR_MID = '" + mManager + "' AND td.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' ORDER BY td.TR_UID desc";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetUsersProductivityExceeded15ByPICAndUID(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.CommandText = "Dboard_ExceedProductivity150PICAndUID";

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;


            //SelectCommand.CommandText = "SELECT td.TR_UID AS [UID], td.TR_InDate [Task In],td.TR_Productivity AS [Productivity] FROM tbl_TaskRecordDetail td WHERE td.TR_Apporval = 2 AND td.TR_Productivity > 150 AND td.TR_PIC = '" + mPIC + "' AND td.TR_UID = '" + mUID + "' AND td.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' ORDER BY td.TR_UID desc";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetUsersProductivityExceeded15ByPICAndUIDAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mUID, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.CommandText = "Dboard_ExceedProductivity150PICAndUIDAndManager";

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //SelectCommand.CommandText = "SELECT td.TR_UID AS [UID], td.TR_InDate [Task In],td.TR_Productivity AS [Productivity] FROM tbl_TaskRecordDetail td WHERE td.TR_Apporval = 2 AND td.TR_Productivity > 150 AND td.TR_PIC = '" + mPIC + "' AND td.TR_UID = '" + mUID + "' AND td.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' ORDER BY td.TR_UID desc";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetProjectTaskedInExceed5minByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_Exceed5Mins";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //SelectCommand.CommandText = "DECLARE @TempLateLogin_@mPIC TABLE(cDATE date, cUID nvarchar(100), cFLOGIN datetime, cTASKIN datetime ); INSERT INTO @TempLateLogin_@mPIC SELECT CAST(td.TR_InDate AS date) AS[DATE], td.TR_UID AS[UID], li.[LOGIN] AS[FLOGIN], MIN(td.TR_InDate) AS[TASKIN] FROM tbl_TaskRecordDetail td INNER JOIN LILO li ON td.TR_UID=li.USERID AND CAST(li.[LOGIN] AS date)=CAST(td.TR_InDate AS date) WHERE td.TR_Apporval = 2 AND td.TR_PIC = '"+ mPIC +"' AND td.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY CAST(td.TR_InDate AS date), td.TR_UID, li.[LOGIN] ORDER BY CAST(td.TR_InDate AS date) SELECT cDATE AS[DATE], cUID AS[UID], cFLOGIN AS[FIRST LOGIN],cTASKIN AS[FIRST TASKED - IN], ((DATEDIFF(minute, cFLOGIN, cTASKIN) / 60)) AS[DELAYED HOURS] FROM @TempLateLogin_@mPIC WHERE(DATEDIFF(minute, cFLOGIN, cTASKIN))>120";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public DataTable GetProjectTaskedInExceed5minByPICAndProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_Exceed5MinsByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //SelectCommand.CommandText = "DECLARE @TempLateLogin_@mPIC TABLE(cDATE date, cUID nvarchar(100), cFLOGIN datetime, cTASKIN datetime ); INSERT INTO @TempLateLogin_@mPIC SELECT CAST(td.TR_InDate AS date) AS[DATE], td.TR_UID AS[UID], li.[LOGIN] AS[FLOGIN], MIN(td.TR_InDate) AS[TASKIN]  FROM tbl_TaskRecordDetail td INNER JOIN LILO li ON td.TR_UID=li.USERID AND CAST(li.[LOGIN] AS date)=CAST(td.TR_InDate AS date) INNER JOIN tbl_PCPDetail pd ON pd.PCP_ID=td.PCP_ID AND pd.Task_ID= td.Task_ID WHERE td.TR_Apporval = 2 AND td.TR_PIC = '" + mPIC + "' AND pd.PCP_Project= '" + mProject + "' AND td.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY CAST(td.TR_InDate AS date), td.TR_UID, li.[LOGIN] ORDER BY CAST(td.TR_InDate AS date) SELECT cDATE AS[DATE], cUID AS[UID], cFLOGIN AS[FIRST LOGIN],cTASKIN AS[FIRST TASKED - IN], ((DATEDIFF(minute, cFLOGIN, cTASKIN) / 60)) AS[DELAYED HOURS] FROM @TempLateLogin_@mPIC WHERE(DATEDIFF(minute, cFLOGIN, cTASKIN))>120";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

            

        }

        public DataTable GetProjectTaskedInExceed5minByPICAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mManager) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_Exceed5MinsByPICAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMID"].Value = mManager;

            //SelectCommand.CommandText = "DECLARE @TempLateLogin_@mPIC TABLE(cDATE date, cUID nvarchar(100), cFLOGIN datetime, cTASKIN datetime); INSERT INTO @TempLateLogin_@mPIC SELECT CAST(td.TR_InDate AS date) AS[DATE], td.TR_UID AS[UID], li.[LOGIN] AS[FLOGIN], MIN(td.TR_InDate) AS[TASKIN] FROM tbl_TaskRecordDetail td INNER JOIN LILO li ON td.TR_UID=li.USERID AND CAST(li.[LOGIN] AS date)=CAST(td.TR_InDate AS date) WHERE td.TR_Apporval = 2 AND td.TR_PIC = '" + mPIC + "' AND td.TR_MID= '" + mManager + "' AND td.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY CAST(td.TR_InDate AS date), td.TR_UID, li.[LOGIN] ORDER BY CAST(td.TR_InDate AS date) SELECT cDATE AS[DATE], cUID AS[UID], cFLOGIN AS[FIRST LOGIN],cTASKIN AS[FIRST TASKED - IN], ((DATEDIFF(minute, cFLOGIN, cTASKIN) / 60)) AS[DELAYED HOURS] FROM @TempLateLogin_@mPIC WHERE(DATEDIFF(minute, cFLOGIN, cTASKIN))>120";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetProjectTaskedInExceed5minByPICAndUID(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.CommandText = "Dboard_Exceed5MinsByPICAndUID";

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //SelectCommand.CommandText = "DECLARE @TempLateLogin_@mPIC TABLE(cDATE date, cUID nvarchar(100), cFLOGIN datetime, cTASKIN datetime); INSERT INTO @TempLateLogin_@mPIC SELECT CAST(td.TR_InDate AS date) AS[DATE], td.TR_UID AS[UID], li.[LOGIN] AS[FLOGIN], MIN(td.TR_InDate) AS[TASKIN] FROM tbl_TaskRecordDetail td INNER JOIN LILO li ON td.TR_UID=li.USERID AND CAST(li.[LOGIN] AS date)=CAST(td.TR_InDate AS date) WHERE td.TR_Apporval = 2 AND td.TR_PIC = '" + mPIC + "' AND td.TR_UID= '" + mUID + "' AND td.TR_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "' GROUP BY CAST(td.TR_InDate AS date), td.TR_UID, li.[LOGIN] ORDER BY CAST(td.TR_InDate AS date) SELECT cDATE AS[DATE], cUID AS[UID], cFLOGIN AS[FIRST LOGIN],cTASKIN AS[FIRST TASKED - IN], ((DATEDIFF(minute, cFLOGIN, cTASKIN) / 60)) AS[DELAYED HOURS] FROM @TempLateLogin_@mPIC WHERE(DATEDIFF(minute, cFLOGIN, cTASKIN))>120";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }


        //Dashboard details

            /// <summary>
            /// Update Query task And Quota
            /// </summary>
            /// <param name="mPIC"></param>
            /// <param name="mFrom"></param>
            /// <param name="mTo"></param>
            /// <returns></returns>
        public DataTable DboardPICTaskAndQuota(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_TasksAndQuota";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPICTaskAndQuotaFilterByProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_TasksAndQuota_FilterByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPICTaskAndQuotaFilterByItemCode(String mPIC, DateTime mFrom, DateTime mTo, String mItemCode) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_TasksAndQuota_FilterByItemCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mItemCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mItemCode"].Value = mItemCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPICTaskAndQuotaFilterByTaskCode(String mPIC, DateTime mFrom, DateTime mTo, String mTaskCode) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_TasksAndQuota_FilterByTaskCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mTaskCode"].Value = mTaskCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPICTaskAndQuotaDataset(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_AllTasksAndQuota";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPICTaskAndQuotaDataset_FilterByProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_AllTasksAndQuota_FilterByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPICTaskAndQuotaDataset_FilterByTaskCode(String mPIC, DateTime mFrom, DateTime mTo, String mTaskCode) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_AllTasksAndQuota_FilterByTaskCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mTaskCode"].Value = mTaskCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPICTaskAndQuotaDataset_FilterByItemCode(String mPIC, DateTime mFrom, DateTime mTo, String mItemCode) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_AllTasksAndQuota_FilterByItemCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mItemCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mItemCode"].Value = mItemCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPICTaskAndQuotaRecords(String mPIC, DateTime mFrom, DateTime mTo, String mProject, String mProcessCode, String mTaskCode, String mTaskDesc) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_TasksAndQuotaByViewRecords";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProcessCode", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mTaskDesc", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mProcessCode"].Value = mProcessCode;
            SelectCommand.Parameters["@mTaskCode"].Value = mTaskCode;
            SelectCommand.Parameters["@mTaskDesc"].Value = mTaskDesc;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3ByUser(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_Ranked";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3ByUserAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_RankedAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3ByUser_FilterByProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_Ranked_FilterByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3ByUser_FilterByManager(String mPIC, DateTime mFrom, DateTime mTo, String mMID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_Ranked_FilterByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMID"].Value = mMID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3ByUser_FilterByUser(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_Ranked_FilterByUser";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3ByUser_FilterByUserAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mUID, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_Ranked_FilterByUserAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3ByUserProjectWise(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUserProjectWise";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3ByUserProjectWiseAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUserProjectWiseAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3ByUserProjectWise_FilterByUser(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUserProjectWise_FilterByUser";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3ByUserProjectWiseAndManager_FilterByUser(String mPIC, DateTime mFrom, DateTime mTo, String mUID, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUserProjectWiseAndManager_FilterByUser";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        public DataTable DboardPerformanceX3Project_User(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_User";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Project_User_FilterByProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_User_FilterByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Project_User_FilterByManager(String mPIC, DateTime mFrom, DateTime mTo, String mMID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_User_FilterByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMID"].Value = mMID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Project_User_FilterByUser(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_User_FilterByUser";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Team_User(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_User";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Team_User_FilterByProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_User_FilterByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Team_User_FilterByManager(String mPIC, DateTime mFrom, DateTime mTo, String mMID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_User_FilterByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMID"].Value = mMID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Team_User_FilterByUser(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_User_FilterByUser";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Task_User(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTask_User";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Task_User_FilterByProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTask_User_FilterByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Task_User_FilterByManager(String mPIC, DateTime mFrom, DateTime mTo, String mMID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTask_User_FilterByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMID"].Value = mMID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Task_User_FilterByUser(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTask_User_FilterByUser";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboradWastageGraphDatewise(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WasteByDateGraph";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboradWastageGraphDatewiseByManager(String mPIC, DateTime mFrom, DateTime mTo, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WasteByDateGraphByMID";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Team_Ranked(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_Ranked";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Team_RankedByManager(String mPIC, DateTime mFrom, DateTime mTo, String mManager) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTeam_RankedPICByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mManager", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mManager"].Value = mManager;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardActiveTeamDetailByPIC(String mPIC) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_ActiveTeamDetailByPIC";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardActiveTeamDetailByPIC_FilterByProject(String mPIC, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_ActiveTeamDetailByPIC_FilterByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardActiveTeamDetailByPIC_FilterByProjectAndManager(String mPIC, String mProject, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_ActiveTeamDetailByPIC_FilterByProjectAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardActiveTeamDetailByPIC_FilterByManager(String mPIC, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_ActiveTeamDetailByPIC_FilterByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }


        public DataTable DboardCurrentTeamUtilizationByPIC(String mPIC) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacityByPIC";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCurrentTeamUtilizationByPIC_FilterByProject(String mPIC, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacityByPIC_FilterByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCurrentTeamUtilizationByPIC_FilterByProjectAndManager(String mPIC, String mProject, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacityByPIC_FilterByProjectAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCurrentTeamUtilizationByPIC_FilterByManager(String mPIC, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacityByPIC_FilterByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCurrentTeamUtilizationByPIC_FilterByUser(String mPIC, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacityByPIC_FilterByUser";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mUID"].Value = mUID;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCurrentTeamUtilizationByPIC_FilterByUserAndManager(String mPIC, String mUID, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacityByPIC_FilterByUserAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCurrentUtilizationDetailUIDByPIC(String mPIC) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacity_DetailedByPIC";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCurrentUtilizationDetailUIDByPIC_FilterByProjct(String mPIC, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByProjct";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCurrentUtilizationDetailUIDByPIC_FilterByProjctAndManager(String mPIC, String mProject, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByProjctAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCurrentUtilizationDetailUIDByPIC_FilterByManager(String mPIC, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCurrentUtilizationDetailUIDByPIC_FilterByUser(String mPIC, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByUser";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCurrentUtilizationDetailUIDByPIC_FilterByUserAndManager(String mPIC, String mUID, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CurrentTeamCapacity_DetailedByPIC_FilterByUserAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3UserAllDataSet_ByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_AllDataSet";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3UserAllDataSet_ByPICAndProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_AllDataSetFilteredByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3UserAllDataSet_ByPICAndProjectAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mProject, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_AllDataSetFilteredByProjectAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3UserAllDataSet_ByPICAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mManager) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_AllDataSetFilteredByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mManager", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mManager"].Value = mManager;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }


        public DataTable DboardPerformanceX3UserAllDataSet_ByPICAndUser(String mPIC, DateTime mFrom, DateTime mTo, String mUser) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_AllDataSetFilteredByUser";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUser", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUser"].Value = mUser;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3UserAllDataSet_ByPICAndUserAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mUser, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_AllDataSetFilteredByUserAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUser", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mMUID"].Value = mMUID;
            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUser"].Value = mUser;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3UserAllDataSet_ByPICAndItemCode(String mPIC, DateTime mFrom, DateTime mTo, String mItemCode) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_AllDataSetFilteredByItemCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mItemCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mItemCode"].Value = mItemCode;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3UserAllDataSet_ByPICAndItemCodeAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mItemCode, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_AllDataSetFilteredByItemCodeAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mItemCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mItemCode"].Value = mItemCode;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3UserAllDataSet_ByPICAndTaskCode(String mPIC, DateTime mFrom, DateTime mTo, String mTaskCode) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_AllDataSetFilteredByTaskCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mTaskCode"].Value = mTaskCode;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3UserAllDataSet_ByPICAndTaskCodeAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mTaskCode, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_AllDataSetFilteredByTaskCodeAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mTaskCode"].Value = mTaskCode;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Project_Ranked(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_Ranked";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Project_RankedByManager(String mPIC, DateTime mFrom, DateTime mTo, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_RankedAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Project_Ranked_FilterByProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_Ranked_FilterByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Project_Ranked_FilterByProjectAndProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byProject_Ranked_FilterByProjectAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboradUserWastageByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_UserWastage_ByPIC";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboradUserWastageByPIC_FilterByUser(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_UserWastage_ByPIC_FilterByUser";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboradUserWastageByPIC_FilterByUserAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mUID, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_UserWastage_ByPIC_FilterByUserAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboradUserWastageByPIC_FilterByTeam(String mPIC, DateTime mFrom, DateTime mTo, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_UserWastage_ByPIC_FilterByMID";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        public int DboardIDLEkAndWastageCount(String mPIC, DateTime mFrom, DateTime mTo) 
        {

            int uPIC = 0;

            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_UserWastage_CountByPIC";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            //foreach (DataRow row in table.Rows)
            //{
            //    uPIC = int.Parse(row[0].ToString());
            //}
            uPIC = int.Parse(table.Rows.Count.ToString());
            return uPIC;

        }

        public DataTable DboardIDLEAndWastageRecords(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_IDLEAndWastageViewRecordsByUID";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);


            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardUserIDLEAndWastageAllDataSet_ByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_AllUserWastage_ByPIC";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardUserIDLEAndWastageAllDataSet_ByPIC_FilterByManager(String mPIC, DateTime mFrom, DateTime mTo, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_AllUserWastage_ByPIC_FilterByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMID"].Value = mMUID;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardUserIDLEAndWastageAllDataSet_ByPIC_FilterByUser(String mPIC, DateTime mFrom, DateTime mTo, String mUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_AllUserWastage_ByPIC_FilterByUser";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardUserIDLEAndWastageAllDataSet_ByPIC_FilterByUserAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mUID, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_AllUserWastage_ByPIC_FilterByUserAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;


            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Task_Ranked(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTask_Ranked";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Task_RankedAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byTask_RankedAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Task_Ranked_FilterByTask(String mPIC, DateTime mFrom, DateTime mTo, String mTask) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DboardPerformanceX3Task_Ranked_FilterByTask";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTask", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mTask"].Value = mTask;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3Task_Ranked_FilterByTaskAndManger(String mPIC, DateTime mFrom, DateTime mTo, String mTask, String mMUID) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DboardPerformanceX3Task_Ranked_FilterByTaskAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTask", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mTask"].Value = mTask;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3User_UID(String mUID, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_User";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mUID"].Value = mUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardPerformanceX3UserAllDataSet_ByUser(String mUID, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_X3byUser_AllDataSetFilteredByUser_User";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboradPTRByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_PTRdetails";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadFresTitlesByProject(String mPIC, String mProject) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_FreshTitlesByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadFresViewTitlesByProjectAndPCP(String mPIC, String mProject, String mPCPCode) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_ViewFreshTitlesByProjectAndPCPCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPCPCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mPCPCode"].Value = mPCPCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadFresTitlesDataSet(String mPIC) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_FreshTitlesDataSet";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadFresTitlesDataSetByProject(String mPIC, String mProject) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_FreshTitlesDataSetByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadFresTitlesDataSetByItemCode(String mPIC, String mItemCode) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_FreshTitlesDataSetByItemCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mItemCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mItemCode"].Value = mItemCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadFresTitlesDataSetByCreatedDate(String mPIC, DateTime mFrom, DateTime mTo) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_FreshTitlesDataSetByCreatedDate";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadPendingTitlesByProject(String mPIC, String mProject) //Get PendingTitles by PIC
        {
            //initialize connection
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_PendingTitlesByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }


        public DataTable DboardWorkLoadPendingViewTitlesByProjectAndPCP(String mPIC, String mProject, String mPCPCode) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_ViewPendingTitlesByProjectAndPCPCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPCPCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mPCPCode"].Value = mPCPCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadPendingTitlesDataSet(String mPIC) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_PendingTitlesDataSet";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadPendingTitlesDataSetByProject(String mPIC, String mProject) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_PendingTitlesDataSetByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadPendingTitlesDataSetByItemCode(String mPIC, String mItemCode) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_PendingTitlesDataSetByItemCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mItemCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mItemCode"].Value = mItemCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        public DataTable DboardWorkLoadPendingTitlesDataSetByCreatedDate(String mPIC, DateTime mFrom, DateTime mTo) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_PendingTitlesDataSetByCreatedDate";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadHoldTitlesByProject(String mPIC, String mProject)
        {
            //initialize connection
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_HoldTitlesByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public DataTable DboardWorkLoadHoldViewTitlesByProjectAndPCP(String mPIC, String mProject, String mPCPCode) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_ViewHoldTitlesByProjectAndPCPCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPCPCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mPCPCode"].Value = mPCPCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDoneTitlesByProject(String mPIC, String mProject)
        {
            //initialize connection
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DoneTitlesByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }
        public DataTable DboardWorkLoadDoneTitlesByItemCode(String mPIC, String mItemCode)
        {
            //initialize connection
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DoneTitlesDataSetByItemCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mItemCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mItemCode"].Value = mItemCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public DataTable DboardWorkLoadDoneTitlesDataSetByCPICAndDate(String mPIC, DateTime mFrom, DateTime mTo) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DoneTitlesDataSetByPICAndDate";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDoneTitlesDataSetByCreatedDate(String mPIC, DateTime mFrom, DateTime mTo) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DoneTitlesDataSetByCreatedDate";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDoneViewTitlesByProjectAndPCP(String mPIC, String mProject, String mPCPCode) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_ViewDoneTitlesByProjectAndPCPCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPCPCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mPCPCode"].Value = mPCPCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDoneTitlesDataSet(String mPIC) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DoneTitlesDataSet";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDoneTitlesDataSetByProject(String mPIC, String mProject) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DoneTitlesDataSetByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadHoldTitlesDataSet(String mPIC) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_HoldTitlesDataSet";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadHoldTitlesDataSetByProject(String mPIC, String mProject) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_HoldTitlesDataSetByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadHoldTitlesDataSetByItemCode(String mPIC, String mItemCode) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_HoldTitlesDataSetByItemCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mItemCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mItemCode"].Value = mItemCode;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadHoldTitlesDataSetByCreatedDate(String mPIC, DateTime mFrom, DateTime mTo) //Get FresTitles DataSet by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_HoldTitlesDataSetByCreatedDate";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadSummary(String mPIC) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_WorkLoadSummary";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadSummaryByManager(String mPIC, String mMUID) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_WorkLoadSummaryByManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadSummary_FilterByProject(String mPIC, String mProject) //Get FresTitles by PIC, Project
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_WorkLoadSummary_FilterByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadSummary_FilterByProjectAndManager(String mPIC, String mProject, String mMUID) //Get FresTitles by PIC, Project
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DBoard_WorkLoadSummary_FilterByProjectAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoad_ExportAllDataSetByProject(String mPIC, String mProject) //Get FresTitles by PIC, Project
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_ExportAllDataSetByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDataSetTitlesByPIC(String mPIC) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DataSetByPIC";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDataSetTitlesByMID(String mPIC, String mMUID) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DataSetByMID";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDataSetTitlesByPICAndDate(String mPIC, DateTime mFrom, DateTime mTo) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DataSetByPICAndDate";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDataSetTitlesByPICAndDateAndManager(String mPIC, DateTime mFrom, DateTime mTo, String mMUID) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DataSetByPICAndDateAndManager";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mMUID", SqlDbType.NVarChar);            

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mMUID"].Value = mMUID;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDataSetTitlesByPICAndProject(String mPIC, String mProject) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DataSetByPICAndProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mProject"].Value = mProject;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDataSetTitlesByPICAndShipment(String mPIC, String mShipment) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DataSetByPICAndShipment";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mShipment", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mShipment"].Value = mShipment;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDataSetTitlesByPICAndFileName(String mPIC, String mFileName) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DataSetByPICAndFileName";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFileName", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFileName"].Value = mFileName;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDataSetTitlesByPICAndPCPCode(String mPIC, String mPCPCode) //Get FresTitles by PIC
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DataSetByPICAndPCPCode";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPCPCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mPCPCode"].Value = mPCPCode;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDataSetFitersByCustomized(String mcustomQuery) //Get FresTitles by PIC
        {

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand(mcustomQuery, this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardWorkLoadDataSetFitersByCustomized1(String mPIC, String mWhere) //Get FresTitles by PIC
                {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_WorkLoad_DataSetByCustomeQuery";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mWhere", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mWhere"].Value = mWhere;


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboradCostCutoffprojectSummaryByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CostCutoffProjectSummary";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboradCostprojectSummaryByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CostProjectSummary";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        public DataTable DboradCostprojectSummaryByPICFilterByProject(String mPIC, DateTime mFrom, DateTime mTo, String mProject) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CostProjectSummaryFiterByProject";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;
            SelectCommand.Parameters["@mProject"].Value = mProject;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCostAppliedPTRByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_CostAppliedPTR";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mFrom", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTo", SqlDbType.DateTime);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;
            SelectCommand.Parameters["@mFrom"].Value = mFrom;
            SelectCommand.Parameters["@mTo"].Value = mTo;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable DboardCostAppliedPTRByPICTest() //Get Shipment Name by PCP Code
        {

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Test";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }



        /*  ################################################# START - Task Modification Validation ###############################################  */
        public int GetRecordsCountForGivenPeriod(String mUID, DateTime mActualTaskIn, DateTime mActualTaskOut) //Get Count for pending records in given PCP and Task Code details
        {

            int uCont = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT COUNT(d.TR_UID) AS[RECORD_COUNT] FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID    WHERE d.TR_UID = '"+ mUID + "' AND(d.TR_ActualTaskIn BETWEEN CONVERT(DATE, '"+ mActualTaskIn + "') AND DATEADD(day, 1, CONVERT(DATE, '"+ mActualTaskOut + "')))", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uCont = int.Parse(row[0].ToString());

            }
            return uCont;

        }

        public int GetPreviousRecordsCountForGivenPeriod(String mUID, DateTime mTaskIn, DateTime mTaskOut) //Get Count for pending records in given PCP and Task Code details
        {

            int uCont = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT COUNT(d.TR_UID) AS[RECORD_COUNT] FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID    WHERE d.TR_UID = '"+ mUID + "' AND (d.TR_ActualTaskIn BETWEEN CONVERT(DATE, '"+ mTaskIn + "') AND DATEADD(day, 1, CONVERT(DATE, '" + mTaskOut + "')))", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uCont = int.Parse(row[0].ToString());

            }
            return uCont;

        }

        public int GetNextRecordsCountForGivenPeriod(String mUID, DateTime mTaskIn, DateTime mTaskOut) //Get Count for pending records in given PCP and Task Code details
        {

            int uCont = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT COUNT(d.TR_UID) AS [RECORD_COUNT] FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID    WHERE d.TR_UID = '"+ mUID + "' AND (d.TR_ActualTaskIn BETWEEN CONVERT(DATE, '"+ mTaskIn + "') AND DATEADD(day, 1, CONVERT(DATE, '" + mTaskOut + "')))", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {

                uCont = int.Parse(row[0].ToString());

            }
            return uCont;

        }

        /*Task Record*/
            public bool UserNextTaskInRecordIsOverlap(String mUID, DateTime mActualTaskIn, DateTime mActualTaskOut, DateTime mTaskOut, String mRecordID) /* 1. Next Task In record is overlapping*/

            {
                //insert databse values
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.Connection = this.mConnectionUser;
                SelectCommand.CommandText = "VALIDATION_NextTaskRecordOverlap";
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add("@mUID", SqlDbType.VarChar);
                SelectCommand.Parameters.Add("@mRecordID", SqlDbType.VarChar);
                SelectCommand.Parameters.Add("@mActualTaskIn", SqlDbType.DateTime);
                SelectCommand.Parameters.Add("@mActualTaskOut", SqlDbType.DateTime);
                SelectCommand.Parameters.Add("@mTaskOut", SqlDbType.DateTime);


                SelectCommand.Parameters["@mUID"].Value = mUID;
                SelectCommand.Parameters["@mRecordID"].Value = mRecordID;
                SelectCommand.Parameters["@mActualTaskIn"].Value = mActualTaskIn;
                SelectCommand.Parameters["@mActualTaskOut"].Value = mActualTaskOut;
                SelectCommand.Parameters["@mTaskOut"].Value = mTaskOut;



                //Data adapter with select command
                SqlDataAdapter da = new SqlDataAdapter();

                //Cast Table Data
                da.SelectCommand = SelectCommand;

                DataTable table = new DataTable();
                da.Fill(table);

                int rowCount = table.Rows.Count;

                if (rowCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool UserPreviousTaskInRecordIsOverlap(String mUID, DateTime mActualTaskIn, DateTime mActualTaskOut, DateTime mTaskIn, String mRecordID) /* 1. Previous Task out record is overlapping*/

            {
                //insert databse values
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.Connection = this.mConnectionUser;
                SelectCommand.CommandText = "VALIDATION_PreviousTaskRecordOverlap";
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add("@mUID", SqlDbType.VarChar);
                SelectCommand.Parameters.Add("@mRecordID", SqlDbType.VarChar);
                SelectCommand.Parameters.Add("@mActualTaskIn", SqlDbType.DateTime);
                SelectCommand.Parameters.Add("@mActualTaskOut", SqlDbType.DateTime);
                SelectCommand.Parameters.Add("@mTaskIn", SqlDbType.DateTime);


                SelectCommand.Parameters["@mUID"].Value = mUID;
                SelectCommand.Parameters["@mRecordID"].Value = mRecordID;
                SelectCommand.Parameters["@mActualTaskIn"].Value = mActualTaskIn;
                SelectCommand.Parameters["@mActualTaskOut"].Value = mActualTaskOut;
                SelectCommand.Parameters["@mTaskIn"].Value = mTaskIn;



                //Data adapter with select command
                SqlDataAdapter da = new SqlDataAdapter();

                //Cast Table Data
                da.SelectCommand = SelectCommand;

                DataTable table = new DataTable();
                da.Fill(table);

                int rowCount = table.Rows.Count;

                if (rowCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        /*AMS Record*/

        public bool UserTaskInRecordIsAMSLoginOverlap(String mUID, DateTime mActualTaskIn, DateTime mActualTaskOut, DateTime mTaskIn) /* 1. Previous Task out record is overlapping*/

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "VALIDATION_TaskInRecordIsAMSLogutOverlap";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@mActualTaskIn", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mActualTaskOut", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTaskIn", SqlDbType.DateTime);


            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mActualTaskIn"].Value = mActualTaskIn;
            SelectCommand.Parameters["@mActualTaskOut"].Value = mActualTaskOut;
            SelectCommand.Parameters["@mTaskIn"].Value = mTaskIn;



            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            int rowCount = table.Rows.Count;

            if (rowCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UserTaskOutRecordIsAMSLogutOverlap(String mUID, DateTime mActualTaskIn, DateTime mActualTaskOut, DateTime mTaskOut) /* 1. Next Task In record is overlapping*/

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "VALIDATION_TaskOutRecordIsAMSLogutOverlap";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@mActualTaskIn", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mActualTaskOut", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mTaskOut", SqlDbType.DateTime);

            SelectCommand.Parameters["@mUID"].Value = mUID;
            SelectCommand.Parameters["@mActualTaskIn"].Value = mActualTaskIn;
            SelectCommand.Parameters["@mActualTaskOut"].Value = mActualTaskOut;
            SelectCommand.Parameters["@mTaskOut"].Value = mTaskOut;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            int rowCount = table.Rows.Count;

            if (rowCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Is Done Record Available*/

        public bool IsTaskDoneRecordAvailable(String mUID, String mTaskCode, String mJobCode) /* Is Task Done Available*/
        {


            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;
            
            SelectCommand.CommandText = "SELECT TR_Index  FROM tbl_TaskRecordDetail  WHERE TR_UID='" + mUID + "' AND PCP_ID='" + mJobCode + "' AND Task_ID='" + mTaskCode + "' AND TR_Status=3";


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            int rowCount = table.Rows.Count;

            if (rowCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public String GetTaskDoneRecordID(String mUID, String mTaskCode, String mJobCode) /* Get Task Done Record ID from JobCoe, UID and task Code*/
        {
            String uDoneRecordID="";

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;
            
            SelectCommand.CommandText = "SELECT TR_ID  FROM tbl_TaskRecordDetail  WHERE TR_UID='"+ mUID + "' AND PCP_ID='"+ mJobCode + "' AND Task_ID='"+ mTaskCode + "' AND TR_Status=3";


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            int rowCount = table.Rows.Count;

            if (rowCount > 0)
            {
                uDoneRecordID = table.Rows[0][0].ToString();
            }
            else
            {
                uDoneRecordID = "";
            }
            return uDoneRecordID;


        }

        public bool IsModifiedTaskDoneRecordAvailableForTaskRecord(String mUID, String mTaskCode, String mJobCode) /* Is Task Done Available*/
        {


            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;
            
            SelectCommand.CommandText = "SELECT d.[TRM_ID] FROM tbl_TaskRecordDetailModify d INNER JOIN tbl_TaskRecordHeaderModify h ON h.[TRM_ID] = d.[TRM_ID] INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = h.PCP_ID WHERE d.TR_UID = '" + mUID + "' AND td.Task_ID = '" + mTaskCode + "' AND h.PCP_ID = '" + mJobCode + "' AND d.TRM_Apporval=1";


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            int rowCount = table.Rows.Count;

            if (rowCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        /*  ################################################# END - Task Modification Validation ###############################################    */
    }
}
