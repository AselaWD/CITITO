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
    class ProcessCodeHeaderMng
    {
        //PIC_Project       varchar(50)     Unchecked
        //PC_ProcessCode    varchar(100)    Unchecked
        //PIC_UID	        varchar(50)	    Unchecked

        SqlConnection mConnectionUser;

        //Default connection
        public ProcessCodeHeaderMng()
        {

        }

        //Constructor Overload
        public ProcessCodeHeaderMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddProcessCode(ProcessCodeHeader mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;
            insetComm.Parameters.Add("@mPIC_Project", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);

            insetComm.Parameters["@mPIC_Project"].Value = mDetail.PIC_Project;
            insetComm.Parameters["@mPC_ProcessCode"].Value = mDetail.PC_ProcessCode;
            insetComm.Parameters["@mPIC_UID"].Value = mDetail.PIC_UID;


            insetComm.CommandText = "INSERT INTO tbl_ProcessCodeHeader(PIC_Project,PC_ProcessCode,PIC_UID) VALUES(@mPIC_Project,@mPC_ProcessCode,@mPIC_UID)";
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

        public int DeleteProcessCode(ProcessCodeHeader mDetail)
        {

            //insert databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mPIC_Project", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);  

            deleteComm.Parameters["@mPIC_Project"].Value = mDetail.PIC_Project;
            deleteComm.Parameters["@mPC_ProcessCode"].Value = mDetail.PC_ProcessCode;

            deleteComm.CommandText = "DELETE FROM tbl_ProcessCodeHeader WHERE PC_ProcessCode=@mPC_ProcessCode AND PIC_Project=@mPIC_Project";
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

        public int UpdateProcessCode(String mProjectName, String mOldProcessCode, String mProcessCode) //Update Process Code in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mPIC_Project", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mOld_PC_ProcessCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);

            updateComm.Parameters["@mPIC_Project"].Value = mProjectName;
            updateComm.Parameters["@mOld_PC_ProcessCode"].Value = mOldProcessCode;
            updateComm.Parameters["@mPC_ProcessCode"].Value = mProcessCode;

            updateComm.CommandText = "UPDATE tbl_ProcessCodeHeader SET PC_ProcessCode=@mPC_ProcessCode WHERE PIC_Project=@mPIC_Project AND PC_ProcessCode=@mOld_PC_ProcessCode";

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

        public bool ProcessCodeIsExist(String mProject, String mProcessCode) //Check Item Code is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mPIC_Project", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC_Project"].Value = mProject;
            SelectCommand.Parameters["@mPC_ProcessCode"].Value = mProcessCode;

            SelectCommand.CommandText = "SELECT PIC_Project FROM tbl_ProcessCodeHeader WHERE PIC_Project=@mPIC_Project AND PC_ProcessCode=@mPC_ProcessCode";

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

        public bool ProcessCodeIsExist2(String mProcessCode) //Check Item Code is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            
            SelectCommand.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);
            
            SelectCommand.Parameters["@mPC_ProcessCode"].Value = mProcessCode;

            SelectCommand.CommandText = "SELECT PIC_Project FROM tbl_ProcessCodeHeader WHERE PC_ProcessCode=@mPC_ProcessCode";

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

        public int GetProcessCodeCount(String mProject) //Get Actuall Last PCP ID details
        {
            int uProcessCodes = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT COUNT(PIC_Project) FROM tbl_ProcessCodeHeader WHERE PIC_Project = '"+ mProject + "'", this.mConnectionUser);
            

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {

                uProcessCodes = int.Parse(row[0].ToString());

            }
            return uProcessCodes;

        }

        public List<String> GetListProcessCodesByProject(String mProject) //Get ProcessCodes by Project
        {

            List<String> uProcessCodes = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT PC_ProcessCode FROM tbl_ProcessCodeHeader WHERE PIC_Project = '" + mProject + "' ORDER BY PC_ProcessCode", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProcessCodes.Add(row[0].ToString());
            }
            return uProcessCodes;

        }

        public List<String> GetListProcessCodesByPIC(String mPIC) //Get ProcessCodes by Project
        {

            List<String> uProcessCodes = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT PC_ProcessCode FROM tbl_ProcessCodeHeader WHERE PIC_UID = '" + mPIC + "' ORDER BY PC_ProcessCode", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProcessCodes.Add(row[0].ToString());
            }
            return uProcessCodes;

        }

        public List<String> GetListProcessCodesByManager(String mPIC, String mMUID) //Get ProcessCodes by Project
        {

            List<String> uProcessCodes = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT ph.PC_ProcessCode FROM tbl_ProcessCodeHeader ph INNER JOIN tbl_ManagerDetail md ON ph.PIC_Project = md.M_Project AND md.M_Project_Availability = 'Active' WHERE ph.PIC_UID = '"+ mPIC + "' AND md.M_UID = '"+ mMUID + "' ORDER BY ph.PC_ProcessCode", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProcessCodes.Add(row[0].ToString());
            }
            return uProcessCodes;

        }

    }
}
