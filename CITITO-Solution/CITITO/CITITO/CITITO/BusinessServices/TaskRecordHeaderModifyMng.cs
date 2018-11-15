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
    class TaskRecordHeaderModifyMng
    {
        //TRMH_Index	bigint	    Unchecked
        //TR_ID         varchar(50) Unchecked
        //PCP_ID        varchar(50) Unchecked
        //TRM_ID        varchar(50) Unchecked

        SqlConnection mConnectionUser;

        //Default connection
        public TaskRecordHeaderModifyMng()
        {

        }

        //Constructor Overload
        public TaskRecordHeaderModifyMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public bool IsExistHeader(String mTModifiedID)
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT TRM_ID FROM tbl_TaskRecordHeaderModify WHERE TRM_ID='" + mTModifiedID + "'";

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

        public bool TaskRecordmodifiedHeaderIsExist(String mTRID) //Check Task Record Header is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mTR_ID", SqlDbType.NVarChar);


            SelectCommand.Parameters["@mTR_ID"].Value = mTRID;


            SelectCommand.CommandText = "SELECT TR_ID FROM tbl_TaskRecordHeaderModify WHERE TR_ID=@mTR_ID";

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

        public int AddTModifiedHeader(TaskRecordHeaderModify mTaskRecordHeaderModify) //Add new PCP Record to the system
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;

            insetComm.Parameters.Add("@mTR_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPCP_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTRM_ID", SqlDbType.NVarChar);

            insetComm.Parameters["@mTR_ID"].Value = mTaskRecordHeaderModify.TR_ID;
            insetComm.Parameters["@mPCP_ID"].Value = mTaskRecordHeaderModify.PCP_ID;
            insetComm.Parameters["@mTRM_ID"].Value = mTaskRecordHeaderModify.TRM_ID;

            insetComm.CommandText = "insert into tbl_TaskRecordHeaderModify(TR_ID,PCP_ID,TRM_ID)values(@mTR_ID,@mPCP_ID,@mTRM_ID)";
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

        public int DeleteTaskModifiedRecordHeader(TaskRecordHeaderModify mTaskRecordHeaderModify) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mTRM_ID", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mTR_ID", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mPCP_ID", SqlDbType.NVarChar);

            deleteComm.Parameters["@mTRM_ID"].Value = mTaskRecordHeaderModify.TRM_ID;
            deleteComm.Parameters["@mTR_ID"].Value = mTaskRecordHeaderModify.TR_ID;
            deleteComm.Parameters["@mPCP_ID"].Value = mTaskRecordHeaderModify.PCP_ID;

            deleteComm.CommandText = "DELETE FROM tbl_TaskRecordHeaderModify WHERE TRM_ID = @mTRM_ID AND TR_ID = @mTR_ID AND PCP_ID = @mPCP_ID";

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
