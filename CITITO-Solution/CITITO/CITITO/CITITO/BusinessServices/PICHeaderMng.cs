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
    class PICHeaderMng
    {
        //PIC_UID           varchar(50) Unchecked
        //PIC_AccessLevel   varchar(50) Checked

        SqlConnection mConnectionUser;

        //Default connection
        public PICHeaderMng()
        {

        }

        //Constructor Overload
        public PICHeaderMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }
        public int AddPICHeader(PICHeader mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;
            insetComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPIC_AccessLevel", SqlDbType.NVarChar);


            insetComm.Parameters["@mPIC_UID"].Value = mDetail.PIC_UID;
            insetComm.Parameters["@mPIC_AccessLevel"].Value = mDetail.PIC_AccessLevel;

            insetComm.CommandText = "INSERT INTO tbl_PICHeader(PIC_UID,PIC_AccessLevel) VALUES(@mPIC_UID,@mPIC_AccessLevel)";
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

        public int DeletePICHeader(PICHeader mDetail)
        {

            //insert databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);
            
            deleteComm.Parameters["@mPIC_UID"].Value = mDetail.PIC_UID;

            deleteComm.CommandText = "DELETE FROM tbl_PICHeader WHERE PIC_UID=@mPIC_UID";
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

        public bool PICIsExist(String mDetail) //Check PIC is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC_UID"].Value = mDetail;


            SelectCommand.CommandText = "SELECT PIC_UID FROM tbl_PICHeader WHERE PIC_UID=@mPIC_UID";

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

        public List<String> GetPICListExceptSentUID(String mUID) //List all details from UserImmediateReporter
        {
            List<String> uPICUID = new List<string>();

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT PIC_UID FROM tbl_PICHeader WHERE PIC_UID!='" + mUID + "' ORDER BY PIC_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uPICUID.Add(row[0].ToString());
            }
            return uPICUID;

        }

        public List<String> GetListOfPICs() //Get Project Names
        {

            List<String> uPICUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT PIC_UID FROM tbl_PICHeader ORDER BY PIC_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uPICUID.Add(row[0].ToString());
            }
            return uPICUID;

        }
    }
}
