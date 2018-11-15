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
    class TaskRecordHeaderMng
    {
        //TR_Index  bigint       Unchecked
        //TR_ID     varchar(50)  Unchecked
        //PCP_ID    varchar(50)  Unchecked
        //TR_UID    varchar(50)  Unchecked
        //TR_MID    varchar(50)  Unchecked
        //TR_PIC    varchar(50)  Unchecked

        SqlConnection mConnectionUser;

        //Default connection
        public TaskRecordHeaderMng()
        {

        }

        //Constructor Overload
        public TaskRecordHeaderMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddTaskRecordHeader(TaskRecordHeader mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;

            insetComm.Parameters.Add("@mTR_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPCP_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTR_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTR_MID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTR_PIC", SqlDbType.NVarChar);

            insetComm.Parameters["@mTR_ID"].Value = mDetail.TR_ID;
            insetComm.Parameters["@mPCP_ID"].Value = mDetail.PCP_ID;
            insetComm.Parameters["@mTR_UID"].Value = mDetail.TR_UID;
            insetComm.Parameters["@mTR_MID"].Value = mDetail.TR_MID;
            insetComm.Parameters["@mTR_PIC"].Value = mDetail.TR_PIC;

            insetComm.CommandText = "INSERT INTO tbl_TaskRecordHeader(TR_ID,PCP_ID,TR_UID,TR_MID,TR_PIC) VALUES(@mTR_ID,@mPCP_ID,@mTR_UID,@mTR_MID,@mTR_PIC)";
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

        public bool TaskRecordHeaderIsExist(String mTRID, String mPCPCode, String mUID) //Check Task Record Header is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mTR_ID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPCP_ID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mTR_UID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mTR_ID"].Value = mTRID;
            SelectCommand.Parameters["@mPCP_ID"].Value = mPCPCode;
            SelectCommand.Parameters["@mTR_UID"].Value = mUID;

            SelectCommand.CommandText = "SELECT TR_ID FROM tbl_TaskRecordHeader WHERE TR_ID=@mTR_ID AND PCP_ID=@mPCP_ID AND TR_UID=@mTR_UID";

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

        public int DeleteTaskRecordHeader(TaskRecordHeader mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mTRID", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mJobCode", SqlDbType.NVarChar);


            deleteComm.Parameters["@mTRID"].Value = mDetail.TR_ID;
            deleteComm.Parameters["@mJobCode"].Value = mDetail.PCP_ID;


            deleteComm.CommandText = "DELETE FROM tbl_TaskRecordHeader WHERE TR_ID = @mTRID AND PCP_ID = @mJobCode";

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

    }
}
