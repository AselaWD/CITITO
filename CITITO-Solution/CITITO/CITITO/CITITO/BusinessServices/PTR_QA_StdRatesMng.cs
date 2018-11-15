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
    class PTR_QA_StdRatesMng
    {
        //PTR_Index	            bigint	Unchecked
        //PTR_Resources         varchar(50) Unchecked
        //PTR_Location          varchar(50) Unchecked
        //PTR_DC                varchar(50) Unchecked
        //PTR_DepartmentName    varchar(1000)   Unchecked
        //PTR_Min               float Unchecked
        //PTR_Max               float Unchecked
        //PTR_HC                float Unchecked
        //PTR_RT01              float Checked
        //PTR_OT01              float Checked
        //PTR_SP01              float Checked

        SqlConnection mConnectionUser;

        //Default connection
        public PTR_QA_StdRatesMng()
        {

        }

        //Constructor Overload
        public PTR_QA_StdRatesMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddPTRDetail(PTR_QA_StdRates mPTRDetail) //Add
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;

            insetComm.Parameters.Add("@mPTR_Resources", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPTR_Location", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPTR_DC", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPTR_DepartmentName", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPTR_Min", SqlDbType.Float);
            insetComm.Parameters.Add("@mPTR_Max", SqlDbType.Float);
            insetComm.Parameters.Add("@mPTR_HC", SqlDbType.Float);
            insetComm.Parameters.Add("@mPTR_RT01", SqlDbType.Float);
            insetComm.Parameters.Add("@mPTR_OT01", SqlDbType.Float);
            insetComm.Parameters.Add("@mPTR_SP01", SqlDbType.Float);

            insetComm.Parameters["@mPTR_Resources"].Value = mPTRDetail.PTR_Resources;
            insetComm.Parameters["@mPTR_Location"].Value = mPTRDetail.PTR_Location;
            insetComm.Parameters["@mPTR_DC"].Value = mPTRDetail.PTR_DC;
            insetComm.Parameters["@mPTR_DepartmentName"].Value = mPTRDetail.PTR_DepartmentName;
            insetComm.Parameters["@mPTR_Min"].Value = mPTRDetail.PTR_Min;
            insetComm.Parameters["@mPTR_Max"].Value = mPTRDetail.PTR_Max;
            insetComm.Parameters["@mPTR_HC"].Value = mPTRDetail.PTR_HC;
            insetComm.Parameters["@mPTR_RT01"].Value = mPTRDetail.PTR_RT01;
            insetComm.Parameters["@mPTR_OT01"].Value = mPTRDetail.PTR_OT01;
            insetComm.Parameters["@mPTR_SP01"].Value = mPTRDetail.PTR_SP01;


            insetComm.CommandText = "INSERT INTO tbl_PTR_QA_StdRates (PTR_Resources, PTR_Location, PTR_DC, PTR_DepartmentName, PTR_Min, PTR_Max, PTR_HC, PTR_RT01, PTR_OT01, PTR_SP01) VALUES(@mPTR_Resources, @mPTR_Location, @mPTR_DC, @mPTR_DepartmentName, CONVERT(DECIMAL(10,2),@mPTR_Min), CONVERT(DECIMAL(10,2),@mPTR_Max), CONVERT(DECIMAL(10,2),@mPTR_HC), CONVERT(DECIMAL(10,2),@mPTR_RT01), CONVERT(DECIMAL(10,2),@mPTR_OT01), CONVERT(DECIMAL(10,2),@mPTR_SP01))";
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

        public int UpdatePTRDetail(PTR_QA_StdRates mPTRDetail) //Update PIC Name in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mPTR_Resources", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPTR_Location", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPTR_DC", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPTR_DepartmentName", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPTR_Min", SqlDbType.Float);
            updateComm.Parameters.Add("@mPTR_Max", SqlDbType.Float);
            updateComm.Parameters.Add("@mPTR_HC", SqlDbType.Float);
            updateComm.Parameters.Add("@mPTR_RT01", SqlDbType.Float);
            updateComm.Parameters.Add("@mPTR_OT01", SqlDbType.Float);
            updateComm.Parameters.Add("@mPTR_SP01", SqlDbType.Float);

            updateComm.Parameters["@mPTR_Resources"].Value = mPTRDetail.PTR_Resources;
            updateComm.Parameters["@mPTR_Location"].Value = mPTRDetail.PTR_Location;
            updateComm.Parameters["@mPTR_DC"].Value = mPTRDetail.PTR_DC;
            updateComm.Parameters["@mPTR_DepartmentName"].Value = mPTRDetail.PTR_DepartmentName;
            updateComm.Parameters["@mPTR_Min"].Value = mPTRDetail.PTR_Min;
            updateComm.Parameters["@mPTR_Max"].Value = mPTRDetail.PTR_Max;
            updateComm.Parameters["@mPTR_HC"].Value = mPTRDetail.PTR_HC;
            updateComm.Parameters["@mPTR_RT01"].Value = mPTRDetail.PTR_RT01;
            updateComm.Parameters["@mPTR_OT01"].Value = mPTRDetail.PTR_OT01;
            updateComm.Parameters["@mPTR_SP01"].Value = mPTRDetail.PTR_SP01;

            updateComm.CommandText = "UPDATE tbl_PTR_QA_StdRates SET PTR_Location=@mPTR_Location, PTR_DC=@mPTR_DC, PTR_DepartmentName=@mPTR_DepartmentName, PTR_Min=CONVERT(DECIMAL(10,2),@mPTR_Min), PTR_Max=CONVERT(DECIMAL(10,2),@mPTR_Max), PTR_HC=CONVERT(DECIMAL(10,2),@mPTR_HC), PTR_RT01=CONVERT(DECIMAL(10,2),@mPTR_RT01), PTR_OT01=CONVERT(DECIMAL(10,2),@mPTR_OT01), PTR_SP01=CONVERT(DECIMAL(10,2),@mPTR_SP01) WHERE PTR_Resources=@mPTR_Resources";

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

        public int DeletePTRDetailByResourceID(String mPTRResouceID) //Delete
        {

            //insert databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.CommandText = "DELETE FROM tbl_PTR_QA_StdRates WHERE PTR_Resources='" + mPTRResouceID + "'";

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

        public bool IsExistPTRResourceRecord(String mPTRResouceID) //Is Exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT PTR_Resources FROM tbl_PTR_QA_StdRates WHERE PTR_Resources = '" + mPTRResouceID + "'";

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

        public DataTable GetAllPTRCostDetails() //Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "PTR_getRegisteredPTRDetails";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } 
        
    }
}
