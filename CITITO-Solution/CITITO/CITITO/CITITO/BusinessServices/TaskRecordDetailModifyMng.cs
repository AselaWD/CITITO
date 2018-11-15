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
    class TaskRecordDetailModifyMng
    {
        //TRM_Index             bigint          Unchecked
        //TRM_ID                varchar(50)     Unchecked
        //TR_FileSize           bigint          Checked
        //TR_File               varchar(500)    Unchecked
        //TRM_ModifiedlTime     datetime        Unchecked
        //TRM_ApprovalTime      datetime        Checked
        //TRM_Apporval          int             Unchecked /* 1 - Pending, 2 - Approved, 3 - Disapproved */
        //TR_UID	            varchar(50)	    Unchecked
        //TRM_PIC               varchar(50)     Unchecked
        //TRM_MID	            varchar(50)	    Unchecked
        //TRM_Hours	            float	        Checked
        //TRM_Productivity      float           Checked
        //TRM_OutDate           datetime        Checked
        //TRM_InDate            datetime        Unchecked
        //TR_Status             int             Checked
        //TR_UOM	            varchar(100)	Unchecked

        SqlConnection mConnectionUser;

        //Default connection
        public TaskRecordDetailModifyMng()
        {

        }

        //Constructor Overload
        public TaskRecordDetailModifyMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddTModifiedDetail(TaskRecordDetailModify mTaskRecordDetailModify) //Add new PCP Record to the system
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;

            insetComm.Parameters.Add("@mTRM_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTR_FileSize", SqlDbType.BigInt);
            insetComm.Parameters.Add("@mTR_File", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTRM_ModifiedlTime", SqlDbType.DateTime);
            //insetComm.Parameters.Add("@mTRM_ApprovalTime", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mTRM_Apporval", SqlDbType.Int); /* 1 - Pending, 2 - Approved, 3 - Disapproved */
            insetComm.Parameters.Add("@mTR_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTRM_PIC", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTRM_MID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTRM_Hours", SqlDbType.Float);
            insetComm.Parameters.Add("@mTRM_Productivity", SqlDbType.Float);
            insetComm.Parameters.Add("@mTRM_OutDate", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mTRM_InDate", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mTR_Status", SqlDbType.Int);
            insetComm.Parameters.Add("@mTR_UOM", SqlDbType.NVarChar);


            insetComm.Parameters["@mTRM_ID"].Value = mTaskRecordDetailModify.TRM_ID;
            insetComm.Parameters["@mTR_FileSize"].Value = mTaskRecordDetailModify.TR_FileSize;
            insetComm.Parameters["@mTR_File"].Value = mTaskRecordDetailModify.TR_File;
            insetComm.Parameters["@mTRM_ModifiedlTime"].Value = mTaskRecordDetailModify.TRM_ModifiedlTime;
            //insetComm.Parameters["@mTRM_ApprovalTime"].Value = mTaskRecordDetailModify.TRM_ApprovalTime;
            insetComm.Parameters["@mTRM_Apporval"].Value = mTaskRecordDetailModify.TRM_Apporval;
            insetComm.Parameters["@mTR_UID"].Value = mTaskRecordDetailModify.TR_UID;
            insetComm.Parameters["@mTRM_PIC"].Value = mTaskRecordDetailModify.TRM_PIC;
            insetComm.Parameters["@mTRM_MID"].Value = mTaskRecordDetailModify.TRM_MID;
            insetComm.Parameters["@mTRM_Hours"].Value = mTaskRecordDetailModify.TRM_Hours;
            insetComm.Parameters["@mTRM_Productivity"].Value = mTaskRecordDetailModify.TRM_Productivity;
            insetComm.Parameters["@mTRM_OutDate"].Value = mTaskRecordDetailModify.TRM_OutDate;
            insetComm.Parameters["@mTRM_InDate"].Value = mTaskRecordDetailModify.TRM_InDate;
            insetComm.Parameters["@mTR_Status"].Value = mTaskRecordDetailModify.TR_Status;
            insetComm.Parameters["@mTR_UOM"].Value = mTaskRecordDetailModify.TR_UOM;


            insetComm.CommandText = "insert into tbl_TaskRecordDetailModify(TRM_ID,TR_FileSize,TR_File,TRM_ModifiedlTime,TRM_Apporval,TR_UID,TRM_PIC,TRM_MID,TRM_Hours,TRM_Productivity,TRM_OutDate,TRM_InDate,TR_Status,TR_UOM)values(@mTRM_ID,@mTR_FileSize,@mTR_File,@mTRM_ModifiedlTime,@mTRM_Apporval,@mTR_UID,@mTRM_PIC,@mTRM_MID,@mTRM_Hours,@mTRM_Productivity,@mTRM_OutDate,@mTRM_InDate,@mTR_Status,@mTR_UOM)";
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

        public int DeleteTaskModifiedRecordDetail(TaskRecordDetailModify mTaskRecordDetailModify) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mTRM_ID", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mTR_File", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mTR_Status", SqlDbType.Int);

            deleteComm.Parameters["@mTRM_ID"].Value = mTaskRecordDetailModify.TRM_ID;
            deleteComm.Parameters["@mTR_File"].Value = mTaskRecordDetailModify.TR_File;
            deleteComm.Parameters["@mTR_Status"].Value = mTaskRecordDetailModify.TR_Status;

            deleteComm.CommandText = "DELETE FROM tbl_TaskRecordDetailModify WHERE TRM_ID = @mTRM_ID AND TR_File = @mTR_File AND TR_Status = @mTR_Status AND TRM_Apporval=1";

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

        public int UpdateModifiedTaskRecordDetailToAprroved(TaskRecordDetailModify mTaskRecordDetailModify) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mTRM_ID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mFile", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mFileSize", SqlDbType.BigInt);
            updateComm.Parameters.Add("@mTRM_Apporval", SqlDbType.Int); // 2 - Approved
            updateComm.Parameters.Add("@mTRM_ApprovalTime", SqlDbType.DateTime);

            updateComm.Parameters["@mTRM_ID"].Value = mTaskRecordDetailModify.TRM_ID;
            updateComm.Parameters["@mFile"].Value = mTaskRecordDetailModify.TR_File;
            updateComm.Parameters["@mStatus"].Value = mTaskRecordDetailModify.TR_Status;
            updateComm.Parameters["@mFileSize"].Value = mTaskRecordDetailModify.TR_FileSize;
            updateComm.Parameters["@mTRM_Apporval"].Value = mTaskRecordDetailModify.TRM_Apporval; // 2 - Approved
            updateComm.Parameters["@mTRM_ApprovalTime"].Value = mTaskRecordDetailModify.TRM_ApprovalTime;


            updateComm.CommandText = "UPDATE tbl_TaskRecordDetailModify SET TRM_Apporval = @mTRM_Apporval, TRM_ApprovalTime = @mTRM_ApprovalTime WHERE TRM_ID = @mTRM_ID AND TR_File = @mFile AND TR_Status = @mStatus AND TR_FileSize = @mFileSize";

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

        public int UpdateModifiedTaskRecordDetailToDisprroved(TaskRecordDetailModify mTaskRecordDetailModify) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mTRM_ID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mFile", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mFileSize", SqlDbType.BigInt);
            updateComm.Parameters.Add("@mTRM_Apporval", SqlDbType.Int); // 3 - Disapproved
            updateComm.Parameters.Add("@mTRM_ApprovalTime", SqlDbType.DateTime);

            updateComm.Parameters["@mTRM_ID"].Value = mTaskRecordDetailModify.TRM_ID;
            updateComm.Parameters["@mFile"].Value = mTaskRecordDetailModify.TR_File;
            updateComm.Parameters["@mStatus"].Value = mTaskRecordDetailModify.TR_Status;
            updateComm.Parameters["@mFileSize"].Value = mTaskRecordDetailModify.TR_FileSize;
            updateComm.Parameters["@mTRM_Apporval"].Value = mTaskRecordDetailModify.TRM_Apporval; // 3 - Disapproved
            updateComm.Parameters["@mTRM_ApprovalTime"].Value = mTaskRecordDetailModify.TRM_ApprovalTime;


            updateComm.CommandText = "UPDATE tbl_TaskRecordDetailModify SET TRM_Apporval = @mTRM_Apporval, TRM_ApprovalTime = @mTRM_ApprovalTime WHERE TRM_ID = @mTRM_ID AND TR_File = @mFile AND TR_Status = @mStatus AND TR_FileSize = @mFileSize";

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

        public int GetLastRecordCount(String mMID) //Get Actuall Last PCP ID details
        {
            int uItemCode = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT MAX(TRM_Index), CAST(RIGHT(MAX(TRM_ID) , LEN(MAX(TRM_ID)) -10) AS INT) AS [TRMID] FROM tbl_TaskRecordDetailModify WHERE(TRM_MID = '" + mMID + "' AND TRM_Index = (SELECT MAX(TRM_Index) FROM tbl_TaskRecordDetailModify)) OR(TRM_MID = '" + mMID + "') GROUP BY TRM_Index ORDER BY[TRMID] DESC", this.mConnectionUser);

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

        public DataTable GetPendingModifiedTaskRecordByPIC(String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE d.TRM_PIC = '" + mPIC + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval = 1 ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingModifiedTaskRecordByManager(String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE d.TRM_MID = '" + mMUID + "' AND (TR_Status = '2' OR TR_Status = '3') ORDER BY d.TRM_Index desc", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE d.TRM_MID = '" + mMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = 1 ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }


        //Filters

        public DataTable GetModifiedTaskInOutRecordByApprovedAndPIC(String mPIC, String mApproval) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE d.TRM_PIC = '" + mPIC + "' AND TR_Status = '3' AND d.TRM_Apporval = 1 ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetModifiedTaskInOutRecordByApprovedAndManager(String mMUID, String mApproval) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE d.TRM_MID = '" + mMUID + "' AND TR_Status = '3' AND TRM_Apporval ='" + mApproval + "' ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetModifiedTaskInOutRecordByPICAndUID(String mUID, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data 
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE (d.TRM_PIC = '" + mPIC + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND d.TR_UID LIKE '%" + mUID + "') OR d.TRM_PIC = '" + mPIC + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND d.TR_UID LIKE '" + mUID + "%' ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetModifiedTaskInOutRecordByManagerAndUID(String mUID, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE ((d.TRM_MID = '" + mMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND d.TR_UID LIKE '%" + mUID + "') OR (d.TRM_MID = '" + mMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND d.TR_UID LIKE '" + mUID + "%')) OR ((d.TRM_MID = '" + mMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '2' AND d.TR_UID LIKE '%" + mUID + "') OR (d.TRM_MID = '" + mMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '2' AND d.TR_UID LIKE '" + mUID + "%')) OR ((d.TRM_MID = '" + mMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '3' AND d.TR_UID LIKE '%" + mUID + "') OR (d.TRM_MID = '" + mMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '3' AND d.TR_UID LIKE '" + mUID + "%')) ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetModifiedTaskInOutRecordByPICAndPCPCode(String mPCPCode, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE (d.TRM_PIC = '" + mPIC + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND h.PCP_ID LIKE '%" + mPCPCode + "') OR d.TRM_PIC = '" + mPIC + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND h.PCP_ID LIKE '" + mPCPCode + "%' ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetModifiedTaskInOutRecordByManagerAndPCPCode(String mPCPCode, String uMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE ((d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND h.PCP_ID LIKE '" + mPCPCode + "%')) OR ((d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '2' AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '2' AND h.PCP_ID LIKE '" + mPCPCode + "%')) OR ((d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '3' AND h.PCP_ID LIKE '%" + mPCPCode + "') OR (d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '3' AND h.PCP_ID LIKE '" + mPCPCode + "%')) ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetModifiedTaskInOutRecordByPICAndFileName(String mFileName, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE (d.TRM_PIC = '" + mPIC + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND d.TR_File LIKE '%" + mFileName + "') OR d.TRM_PIC = '" + mPIC + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND d.TR_File LIKE '" + mFileName + "%' ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }


        public DataTable GetModifiedTaskInOutRecordByManagerAndFileName(String mFileName, String uMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE ((d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND d.TR_File LIKE '%" + mFileName + "') OR (d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND d.TR_File LIKE '" + mFileName + "%')) OR ((d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '2' AND d.TR_File LIKE '%" + mFileName + "') OR (d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '2' AND d.TR_File LIKE '" + mFileName + "%')) OR ((d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '3' AND d.TR_File LIKE '%" + mFileName + "') OR (d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '3' AND d.TR_File LIKE '" + mFileName + "%')) ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetModifiedPCPRecordByDateRangeByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Find details from Department Name
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE (d.TRM_PIC = '" + mPIC + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND (d.TRM_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) OR (d.TRM_PIC = '" + mPIC + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND (d.TRM_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) ORDER BY d.TRM_Index desc", this.mConnectionUser);


            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetModifiedPCPRecordByDateRange(String uMUID, DateTime mFrom, DateTime mTo) //Find details from Department Name
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data          
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE (d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND (d.TRM_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) OR (d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '2' AND (d.TRM_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) OR (d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '3' AND (d.TRM_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) ORDER BY d.TRM_Index desc", this.mConnectionUser);


            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }


        //History Records
        public DataTable GetHistoryModifiedTaskRecordByPIC(String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE d.TRM_PIC = '" + mPIC + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval != 1 ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetHistoryModifiedTaskRecordByPICANDManager(String mPIC, String mManager) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE d.TRM_PIC = '" + mPIC + "' AND TRM_MID='"+ mManager + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval != 1 ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetHistoryModifiedTaskRecordByPICAndApprovals(String mPIC, String mApproval) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE d.TRM_PIC = '" + mPIC + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval = '" + mApproval + "' ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetHistoryTaskInOutRecordByPICAndUID(String mUID, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data 
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE (d.TRM_PIC = '" + mPIC + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval != '1' AND d.TR_UID LIKE '%" + mUID + "') OR d.TRM_PIC = '" + mPIC + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval != '1' AND d.TR_UID LIKE '" + mUID + "%' ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetHistoryTaskInOutRecordByPICAndPCPCode(String mPCPCode, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE (d.TRM_PIC = '" + mPIC + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval != '1' AND h.PCP_ID LIKE '%" + mPCPCode + "') OR d.TRM_PIC = '" + mPIC + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval != '1' AND h.PCP_ID LIKE '" + mPCPCode + "%' ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetHistoryTaskInOutRecordByPICAndFileName(String mFileName, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE (d.TRM_PIC = '" + mPIC + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval != '1' AND d.TR_File LIKE '%" + mFileName + "') OR d.TRM_PIC = '" + mPIC + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval != '1' AND d.TR_File LIKE '" + mFileName + "%' ORDER BY d.TRM_Index desc", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetHistoryPCPRecordByDateRangeByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Find details from Department Name
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID WHERE (d.TRM_PIC = '" + mPIC + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval != '1' AND (d.TRM_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) OR (d.TRM_PIC = '" + mPIC + "' AND (TR_Status = '2' OR TR_Status = '3') AND d.TRM_Apporval != '1' AND (d.TRM_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) ORDER BY d.TRM_Index desc", this.mConnectionUser);


            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
    }
}
