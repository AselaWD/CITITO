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
    class IDLEDetailMng
    {
        //IDLE_Index            bigint          Unchecked
        //IDLE_ID               varchar(50)     Unchecked
        //IDLE_InDate           datetime        Unchecked
        //IDLE_OutDate          datetime        Checked
        //IDLE_Reason           varchar(800)    Unchecked
        //IDLE_UID              varchar(50)     Unchecked
        //IDLE_MID              varchar(50)     Unchecked
        //IDLE_PIC              varchar(50)     Unchecked
        //IDLE_Apporval         int             Unchecked /*1 - Pending, 2 - Approved, 3 - Disapproved*/
        //IDLE_ApprovalTime     datetime        Checked
        //IDLE_Hours            float           Checked
        //IDLE_LogCreateTime    datetime        Unchecked
        //IDLE_Remark           varchar(800)    Checked

        SqlConnection mConnectionUser;

        //Default connection
        public IDLEDetailMng()
        {

        }

        //Constructor Overload
        public IDLEDetailMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddIDLEDetail(IDLEDetail mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;
            insetComm.Parameters.Add("@mIDLE_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mIDLE_InDate", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mIDLE_OutDate", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mIDLE_Reason", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mIDLE_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mIDLE_MID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mIDLE_PIC", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mIDLE_Apporval", SqlDbType.Int); /* 1 - Pending, 2 - Approved, 3 - Disapproved */
            //insetComm.Parameters.Add("@mIDLE_ApprovalTime", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mIDLE_Hours", SqlDbType.Float);
            insetComm.Parameters.Add("@mIDLE_LogCreateTime", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mIDLE_Remark", SqlDbType.NVarChar);


            insetComm.Parameters["@mIDLE_ID"].Value = mDetail.IDLE_ID;
            insetComm.Parameters["@mIDLE_InDate"].Value = mDetail.IDLE_InDate;
            insetComm.Parameters["@mIDLE_OutDate"].Value = mDetail.IDLE_OutDate;
            insetComm.Parameters["@mIDLE_Reason"].Value = mDetail.IDLE_Reason;
            insetComm.Parameters["@mIDLE_UID"].Value = mDetail.IDLE_UID;
            insetComm.Parameters["@mIDLE_MID"].Value = mDetail.IDLE_MID;
            insetComm.Parameters["@mIDLE_PIC"].Value = mDetail.IDLE_PIC;
            insetComm.Parameters["@mIDLE_Apporval"].Value = mDetail.IDLE_Apporval; /* 1 - Pending, 2 - Approved, 3 - Disapproved */
            //insetComm.Parameters["@mIDLE_ApprovalTime"].Value = mDetail.IDLE_ApprovalTime;
            insetComm.Parameters["@mIDLE_Hours"].Value = mDetail.IDLE_Hours;
            insetComm.Parameters["@mIDLE_LogCreateTime"].Value = mDetail.IDLE_LogCreateTime;
            insetComm.Parameters["@mIDLE_Remark"].Value = mDetail.IDLE_Remark;


            insetComm.CommandText = "INSERT INTO tbl_IDLEDetail(IDLE_ID,IDLE_InDate,IDLE_OutDate,IDLE_Reason,IDLE_UID, IDLE_MID,IDLE_PIC,IDLE_Apporval,IDLE_Hours,IDLE_LogCreateTime,IDLE_Remark) VALUES(@mIDLE_ID,@mIDLE_InDate,@mIDLE_OutDate,@mIDLE_Reason,@mIDLE_UID,@mIDLE_MID,@mIDLE_PIC,@mIDLE_Apporval,@mIDLE_Hours,@mIDLE_LogCreateTime,@mIDLE_Remark)";
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

        public bool TaskTaskInDetailIsExist(String mIDLEID, String mUID) //Check Task Record Header is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            /* 0 - Fresh, 1 - Tasked In , 2 - Done */

            SelectCommand.CommandText = "SELECT d.IDLE_ID FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID = d.IDLE_ID WHERE d.IDLE_ID = '" + mIDLEID + "' AND d.IDLE_UID = '" + mUID + "'";

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

        public int UpdateIDLERecordDetailToAprroved(IDLEDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mIDLE_ID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mIDLE_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mIDLE_Apporval", SqlDbType.Int); // 2 - Approved
            updateComm.Parameters.Add("@mIDLE_ApprovalTime", SqlDbType.DateTime);

            updateComm.Parameters["@mIDLE_ID"].Value = mDetail.IDLE_ID;
            updateComm.Parameters["@mIDLE_UID"].Value = mDetail.IDLE_UID;
            updateComm.Parameters["@mIDLE_Apporval"].Value = mDetail.IDLE_Apporval; // 2 - Approved
            updateComm.Parameters["@mIDLE_ApprovalTime"].Value = mDetail.IDLE_ApprovalTime;


            updateComm.CommandText = "UPDATE tbl_IDLEDetail SET IDLE_Apporval = @mIDLE_Apporval, IDLE_ApprovalTime = @mIDLE_ApprovalTime WHERE IDLE_ID = @mIDLE_ID AND IDLE_UID = @mIDLE_UID";

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

        public int UpdateIDLERecordDetailToDisaprroved(IDLEDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mIDLE_ID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mIDLE_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mIDLE_Apporval", SqlDbType.Int); // 3 - Disapproved
            updateComm.Parameters.Add("@mIDLE_ApprovalTime", SqlDbType.DateTime);

            updateComm.Parameters["@mIDLE_ID"].Value = mDetail.IDLE_ID;
            updateComm.Parameters["@mIDLE_UID"].Value = mDetail.IDLE_UID;
            updateComm.Parameters["@mIDLE_Apporval"].Value = mDetail.IDLE_Apporval; // 3 - Disapproved
            updateComm.Parameters["@mIDLE_ApprovalTime"].Value = mDetail.IDLE_ApprovalTime;


            updateComm.CommandText = "UPDATE tbl_IDLEDetail SET IDLE_Apporval = @mIDLE_Apporval, IDLE_ApprovalTime = @mIDLE_ApprovalTime WHERE IDLE_ID = @mIDLE_ID AND IDLE_UID = @mIDLE_UID";

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

        public int UpdateIDLERecordDetailToRollback(IDLEDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mIDLE_ID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mIDLE_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mIDLE_Apporval", SqlDbType.Int); // rollback value


            updateComm.Parameters["@mIDLE_ID"].Value = mDetail.IDLE_ID;
            updateComm.Parameters["@mIDLE_UID"].Value = mDetail.IDLE_UID;
            updateComm.Parameters["@mIDLE_Apporval"].Value = mDetail.IDLE_Apporval; // rollback value



            updateComm.CommandText = "UPDATE tbl_IDLEDetail SET IDLE_Apporval = 1, IDLE_ApprovalTime = NULL WHERE IDLE_ID = @mIDLE_ID AND IDLE_UID = @mIDLE_UID AND IDLE_Apporval=@mIDLE_Apporval";

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

        public int DeleteIDLERecordDetail(IDLEDetail mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mIDLE_ID", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mIDLE_UID", SqlDbType.NVarChar);

            deleteComm.Parameters["@mIDLE_ID"].Value = mDetail.IDLE_ID;
            deleteComm.Parameters["@mIDLE_UID"].Value = mDetail.IDLE_UID;

            deleteComm.CommandText = "DELETE FROM tbl_IDLEDetail WHERE IDLE_ID = @mIDLE_ID AND IDLE_UID = @mIDLE_UID";

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

        public DataTable GetAllIDLEDetailsByUserUID(String mUID)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT d.IDLE_ID AS [#], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.IDLE_Remark [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE d.IDLE_UID = '" + mUID + "' ORDER BY d.IDLE_Index DESC";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetPendingIDLERecordByManager(String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval = 1 ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingIDLERecordByManagerAndUID(String mUID, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();
   
            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE (d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval = 1 AND d.IDLE_UID LIKE '%" + mUID + "') OR (d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval = 1 AND d.IDLE_UID LIKE '" + mUID + "%') ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingIDLERecordByPICAndUID(String mUID, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE (d.IDLE_PIC = '" + mPIC + "' AND IDLE_Apporval = 1 AND d.IDLE_UID LIKE '%" + mUID + "') OR (d.IDLE_PIC = '" + mPIC + "' AND IDLE_Apporval = 1 AND d.IDLE_UID LIKE '" + mUID + "%') ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingIDLERecordByManagerAndProject(String mProject, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE (d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval = 1 AND h.IDLE_Project LIKE '%" + mProject + "') OR (d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval = 1 AND h.IDLE_Project LIKE '" + mProject + "%') ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetPendingIDLERecordByPICAndProject(String mProject, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE (d.IDLE_PIC = '" + mPIC + "' AND IDLE_Apporval = 1 AND h.IDLE_Project LIKE '%" + mProject + "') OR (d.IDLE_PIC = '" + mPIC + "' AND IDLE_Apporval = 1 AND h.IDLE_Project LIKE '" + mProject + "%') ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetIDLERecordByDateRange(String mMUID, DateTime mFrom, DateTime mTo) //Find details from Department Name
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval = 1 AND (d.IDLE_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "') ORDER BY d.IDLE_Index desc", this.mConnectionUser);


            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetIDLERecordByDateRangeByPIC(String mPIC, DateTime mFrom, DateTime mTo) //Find details from Department Name
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE d.IDLE_PIC = '" + mPIC + "' AND IDLE_Apporval = 1 AND (d.IDLE_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "') ORDER BY d.IDLE_Index desc", this.mConnectionUser);


            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }        

        public DataTable GetPendingIDLERecordByPIC(String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE d.IDLE_PIC = '" + mPIC + "' AND IDLE_Apporval = 1 ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedIDLERecordByPIC(String mPIC, DateTime uFrom, DateTime uTo) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data

            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE(d.IDLE_PIC = '" + mPIC + "' AND IDLE_Apporval = 2) OR(d.IDLE_PIC = '" + mPIC + "' AND IDLE_Apporval = 3) AND d.IDLE_InDate BETWEEN '" + uFrom + "' AND '" + uTo + "' ORDER BY d.IDLE_ID DESC", this.mConnectionUser);
            //da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE (d.IDLE_PIC = '" + mPIC + "' AND IDLE_Apporval = 2) OR (d.IDLE_PIC = '" + mPIC + "' AND IDLE_Apporval = 3)  ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedIDLERecordByManager(String mMUID, DateTime uFrom, DateTime uTo) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data

            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE (d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval = 2) OR (d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval = 3) AND d.IDLE_InDate BETWEEN '" + uFrom + "' AND '" + uTo + "' ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE (d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval = 2) OR (d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval = 3)  ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedIDLERecordByApprovedAndPIC(String mPIC, String mApproval) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE (d.IDLE_PIC = '" + mPIC + "' AND IDLE_Apporval = '"+ mApproval + "') ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedIDLERecordByApprovedAndManager(String mMUID, String mApproval) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE (d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval = '" + mApproval + "') ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedIDLERecordByPICAndUID(String mUID, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE ((d.IDLE_PIC = '" + mPIC + "' AND d.IDLE_UID LIKE '" + mUID + "%' AND IDLE_Apporval = 2) OR (d.IDLE_PIC= '" + mPIC + "' AND d.IDLE_UID LIKE '%" + mUID + "' AND IDLE_Apporval = 3)) OR ((d.IDLE_PIC = '" + mPIC + "' AND d.IDLE_UID LIKE '" + mUID + "%' AND IDLE_Apporval = 2) OR (d.IDLE_PIC = '" + mPIC + "' AND d.IDLE_UID LIKE '" + mUID + "%' AND IDLE_Apporval = 3))  ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedIDLERecordByManagerAndUID(String mUID, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE ((d.IDLE_MID = '" + mMUID + "' AND d.IDLE_UID LIKE '" + mUID + "%' AND IDLE_Apporval = 2) OR (d.IDLE_MID = '" + mMUID + "' AND d.IDLE_UID LIKE '%" + mUID + "' AND IDLE_Apporval = 3)) OR ((d.IDLE_MID = '" + mMUID + "' AND d.IDLE_UID LIKE '" + mUID + "%' AND IDLE_Apporval = 2) OR (d.IDLE_MID = '" + mMUID + "' AND d.IDLE_UID LIKE '" + mUID + "%' AND IDLE_Apporval = 3))  ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedIDLERecordByPICAndProject(String mProject, String mPIC) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE ((d.IDLE_PIC = '" + mPIC + "' AND h.IDLE_Project LIKE '" + mProject + "%' AND IDLE_Apporval = 2) OR (d.IDLE_PIC = '" + mPIC + "' AND h.IDLE_Project LIKE '%" + mProject + "' AND IDLE_Apporval = 3)) OR ((d.IDLE_PIC = '" + mPIC + "' AND h.IDLE_Project LIKE '" + mProject + "%' AND IDLE_Apporval = 2) OR (d.IDLE_PIC = '" + mPIC + "' AND h.IDLE_Project LIKE '" + mProject + "%' AND IDLE_Apporval = 3))  ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetApprovedIDLERecordByManagerAndProject(String mProject, String mMUID) //Find details from UserImmediateReporter
        {
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT d.IDLE_ID AS [#], d.IDLE_UID AS [UID], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time], d.[IDLE_Remark] AS [Remark] FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE ((d.IDLE_MID = '" + mMUID + "' AND h.IDLE_Project LIKE '" + mProject + "%' AND IDLE_Apporval = 2) OR (d.IDLE_MID = '" + mMUID + "' AND h.IDLE_Project LIKE '%" + mProject + "' AND IDLE_Apporval = 3)) OR ((d.IDLE_MID = '" + mMUID + "' AND h.IDLE_Project LIKE '" + mProject + "%' AND IDLE_Apporval = 2) OR (d.IDLE_MID = '" + mMUID + "' AND h.IDLE_Project LIKE '" + mProject + "%' AND IDLE_Apporval = 3))  ORDER BY d.IDLE_ID DESC", this.mConnectionUser);

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
            //da.SelectCommand = new SqlCommand("SELECT RIGHT(MAX(IDLE_ID) , LEN(MAX(IDLE_ID)) -13) FROM tbl_IDLEDetail WHERE IDLE_UID='" + mUID + "'", this.mConnectionUser);
            da.SelectCommand = new SqlCommand("SELECT MAX(IDLE_Index), CAST(RIGHT(MAX(IDLE_ID) , LEN(MAX(IDLE_ID)) -13) AS INT) AS [IDLEID] FROM tbl_IDLEDetail WHERE(IDLE_UID = '" + mUID + "' AND IDLE_Index = (SELECT MAX(IDLE_Index) FROM tbl_IDLEDetail)) OR(IDLE_UID = '" + mUID + "') GROUP BY IDLE_Index ORDER BY[IDLEID] DESC", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count==0)
            {
                uItemCode = 0;
            }
            else
            {
                uItemCode = int.Parse(table.Rows[0][1].ToString());
            }

            
            return uItemCode;

        }

        public bool UserIDLERecordIsExist(IDLEDetail mDetail, String mProject) //Check Item Code is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DILE_checkTimeSpanOnIDLERecord";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.VarChar);
            //SelectCommand.Parameters.Add("@mProject", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@mIdleIn", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mIdleOut", SqlDbType.DateTime);
            //SelectCommand.Parameters.Add("@mReason", SqlDbType.VarChar);

            SelectCommand.Parameters["@mUID"].Value = mDetail.IDLE_UID;
            //SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mIdleIn"].Value = mDetail.IDLE_InDate;
            SelectCommand.Parameters["@mIdleOut"].Value = mDetail.IDLE_OutDate;
            //SelectCommand.Parameters["@mReason"].Value = mDetail.IDLE_Reason;


            //SelectCommand.CommandText = "SELECT d.IDLE_UID, h.IDLE_Project,  d.IDLE_InDate, d.IDLE_OutDate FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE d.IDLE_UID = @mUID AND h.IDLE_Project = @mProject AND((d.IDLE_InDate BETWEEN @mIdleIn AND @mIdleOut) OR (d.IDLE_OutDate BETWEEN @mIdleIn AND @mIdleOut))";

           // SelectCommand.CommandText = "SELECT d.IDLE_UID, h.IDLE_Project, d.IDLE_InDate, d.IDLE_OutDate FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE d.IDLE_UID = @mUID AND h.IDLE_Project = @mProject AND ((d.IDLE_InDate BETWEEN @mIdleIn AND @mIdleOut OR d.IDLE_OutDate BETWEEN @mIdleIn AND @mIdleOut) OR (@mIdleIn < d.IDLE_InDate OR d.IDLE_InDate > @mIdleOut) OR (@mIdleIn < d.IDLE_OutDate OR d.IDLE_OutDate > @mIdleOut))";


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

        public bool UserIDLERecordIsExist_taskModify(IDLEDetail mDetail) //Check Item Code is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DILE_checkTimeSpanOnIDLERecord";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@mIdleIn", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mIdleOut", SqlDbType.DateTime);

            SelectCommand.Parameters["@mUID"].Value = mDetail.IDLE_UID;
            SelectCommand.Parameters["@mIdleIn"].Value = mDetail.IDLE_InDate;
            SelectCommand.Parameters["@mIdleOut"].Value = mDetail.IDLE_OutDate;

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


        public bool UserIDLETaskRecordIsExist(IDLEDetail mDetail) //Check Item Code is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DILE_checkTimeSpanOnTaskRecord";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.VarChar);
            //SelectCommand.Parameters.Add("@mProject", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@mIdleIn", SqlDbType.DateTime);
            SelectCommand.Parameters.Add("@mIdleOut", SqlDbType.DateTime);
            //SelectCommand.Parameters.Add("@mReason", SqlDbType.VarChar);

            SelectCommand.Parameters["@mUID"].Value = mDetail.IDLE_UID;
            //SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mIdleIn"].Value = mDetail.IDLE_InDate;
            SelectCommand.Parameters["@mIdleOut"].Value = mDetail.IDLE_OutDate;
            //SelectCommand.Parameters["@mReason"].Value = mDetail.IDLE_Reason;


            //SelectCommand.CommandText = "SELECT d.IDLE_UID, h.IDLE_Project,  d.IDLE_InDate, d.IDLE_OutDate FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE d.IDLE_UID = @mUID AND h.IDLE_Project = @mProject AND((d.IDLE_InDate BETWEEN @mIdleIn AND @mIdleOut) OR (d.IDLE_OutDate BETWEEN @mIdleIn AND @mIdleOut))";

            // SelectCommand.CommandText = "SELECT d.IDLE_UID, h.IDLE_Project, d.IDLE_InDate, d.IDLE_OutDate FROM tbl_IDLEDetail d INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID WHERE d.IDLE_UID = @mUID AND h.IDLE_Project = @mProject AND ((d.IDLE_InDate BETWEEN @mIdleIn AND @mIdleOut OR d.IDLE_OutDate BETWEEN @mIdleIn AND @mIdleOut) OR (@mIdleIn < d.IDLE_InDate OR d.IDLE_InDate > @mIdleOut) OR (@mIdleIn < d.IDLE_OutDate OR d.IDLE_OutDate > @mIdleOut))";


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


        public bool UserIDLETaskRecordActiveTaskIsExist(IDLEDetail mDetail) //Check Item Code is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DILE_checkTimeSpanOnTaskRecordActiveTaskIn";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@mIdleIn", SqlDbType.DateTime);
            //SelectCommand.Parameters.Add("@mIdleOut", SqlDbType.DateTime);

            SelectCommand.Parameters["@mUID"].Value = mDetail.IDLE_UID;
            SelectCommand.Parameters["@mIdleIn"].Value = mDetail.IDLE_InDate;
            //SelectCommand.Parameters["@mIdleOut"].Value = mDetail.IDLE_OutDate;


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

        public String UserIDLEActiveTaskIsExist(IDLEDetail mDetail) //Check Item Code is already exists
        {
            String time;
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DILE_checkActiveTaskInTime";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.VarChar);

            SelectCommand.Parameters["@mUID"].Value = mDetail.IDLE_UID;
            

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            int rowCount = table.Rows.Count;

            if (rowCount > 0)
            {
                time = table.Rows[0][0].ToString();
            }
            else
            {
                time = "";
            }

            return time;
        }

    }
}
