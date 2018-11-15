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
    class IDLEHeaderMng
    {
        //IDLE_Index    bigint      Unchecked
        //IDLE_ID       varchar(50) Unchecked    
        //IDLE_Project	varchar(50)	Unchecked
        //IDLE_UID      varchar(50) Unchecked
        //IDLE_MID      varchar(50) Unchecked
        //IDLE_PIC      varchar(50) Unchecked

        SqlConnection mConnectionUser;

        //Default connection
        public IDLEHeaderMng()
        {

        }

        //Constructor Overload
        public IDLEHeaderMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddIDLERecordHeader(IDLEHeader mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;

            insetComm.Parameters.Add("@mIDLE_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mIDLE_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mIDLE_Project", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mIDLE_MID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mIDLE_PIC", SqlDbType.NVarChar);

            insetComm.Parameters["@mIDLE_ID"].Value = mDetail.IDLE_ID;
            insetComm.Parameters["@mIDLE_UID"].Value = mDetail.IDLE_UID;
            insetComm.Parameters["@mIDLE_Project"].Value = mDetail.IDLE_Project;
            insetComm.Parameters["@mIDLE_MID"].Value = mDetail.IDLE_MID;
            insetComm.Parameters["@mIDLE_PIC"].Value = mDetail.IDLE_PIC;

            insetComm.CommandText = "INSERT INTO tbl_IDLEHeader(IDLE_ID,IDLE_UID,IDLE_Project,IDLE_MID,IDLE_PIC) VALUES(@mIDLE_ID,@mIDLE_UID,@mIDLE_Project,@mIDLE_MID,@mIDLE_PIC)";
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

        public bool IDLERecordHeaderIsExist(String mIDLEID, String mUID) //Check Task Record Header is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mIDLE_ID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mIDLE_UID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mIDLE_ID"].Value = mIDLEID;
            SelectCommand.Parameters["@mIDLE_UID"].Value = mUID;

            SelectCommand.CommandText = "SELECT IDLE_ID FROM tbl_IDLEHeader WHERE IDLE_ID=@mIDLE_ID AND IDLE_UID=@mIDLE_UID";

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

        public int DeleteIDLERecordHeader(IDLEHeader mDetail) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mIDLE_ID", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mIDLE_UID", SqlDbType.NVarChar);

            deleteComm.Parameters["@mIDLE_ID"].Value = mDetail.IDLE_ID;
            deleteComm.Parameters["@mIDLE_UID"].Value = mDetail.IDLE_UID;

            deleteComm.CommandText = "DELETE FROM tbl_IDLEHeader WHERE IDLE_ID = @mIDLE_ID AND IDLE_UID = @mIDLE_UID";

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
