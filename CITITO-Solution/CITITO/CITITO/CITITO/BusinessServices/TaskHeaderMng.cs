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
    //Task_ID               varchar(50)     Unchecked
    //PC_ProcessCode        varchar(100)    Unchecked
    //PIC_Project           varchar(50)     Unchecked
    //TR_Index              bigint          Unchecked
    //SkipOutputValidation  nchar(10)       Checked  /* 0 - Yes, 1 - No */

    class TaskHeaderMng
    {
        SqlConnection mConnectionUser;

        //Default connection
        public TaskHeaderMng()
        {

        }

        //Constructor Overload
        public TaskHeaderMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddTaskCode(TaskHeader mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;

            insetComm.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPIC_Project", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mSkipOutputValidation", SqlDbType.Int);  /* 0 - Yes, 1 - No */

            insetComm.Parameters["@mTask_ID"].Value = mDetail.Task_ID;
            insetComm.Parameters["@mPC_ProcessCode"].Value = mDetail.PC_ProcessCode;
            insetComm.Parameters["@mPIC_Project"].Value = mDetail.PIC_Project;
            insetComm.Parameters["@mSkipOutputValidation"].Value = mDetail.SkipOutputValidation;  /* 0 - Yes, 1 - No */


            insetComm.CommandText = "INSERT INTO tbl_TaskHeader(Task_ID,PC_ProcessCode,PIC_Project,SkipOutputValidation) VALUES(@mTask_ID,@mPC_ProcessCode,@mPIC_Project,@mSkipOutputValidation)";
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

        public int DeleteTaskCodebyProcessCode(TaskHeader mDetail)
        {

            //insert databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mPIC_Project", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);

            deleteComm.Parameters["@mPIC_Project"].Value = mDetail.PIC_Project;
            deleteComm.Parameters["@mPC_ProcessCode"].Value = mDetail.PC_ProcessCode;

            deleteComm.CommandText = "DELETE FROM tbl_TaskHeader WHERE PIC_Project=@mPIC_Project AND PC_ProcessCode=@mPC_ProcessCode";
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

        public int UpdateTaskCodeHeader(String mTaskCode, String mProject, String mProcessCode, int mCheck) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mProject", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mProcessCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mCheck", SqlDbType.Int);

            updateComm.Parameters["@mTaskCode"].Value = mTaskCode;
            updateComm.Parameters["@mProject"].Value = mProject;
            updateComm.Parameters["@mProcessCode"].Value = mProcessCode;
            updateComm.Parameters["@mCheck"].Value = mCheck;

            updateComm.CommandText = "UPDATE tbl_TaskHeader SET SkipOutputValidation=@mCheck WHERE Task_ID=@mTaskCode AND PIC_Project=@mProject AND PC_ProcessCode=@mProcessCode";

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

        public int DeleteTaskCodeHeader(TaskHeader mDetail)
        {

            //insert databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);

            deleteComm.Parameters["@mTaskCode"].Value = mDetail.Task_ID;

            deleteComm.CommandText = "DELETE FROM tbl_TaskHeader WHERE Task_ID=@mTaskCode";
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

        public int CheckTaskCodeSkipValidation(String mTaskCode, String mProject, String mProcessCode)
        {

            int uSkip = 0; 

            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;
            
            SelectCommand.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProject", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mProcessCode", SqlDbType.NVarChar);
            
            SelectCommand.Parameters["@mTaskCode"].Value = mTaskCode;
            SelectCommand.Parameters["@mProject"].Value = mProject;
            SelectCommand.Parameters["@mProcessCode"].Value = mProcessCode;
            
            SelectCommand.CommandText = "SELECT SkipOutputValidation FROM tbl_TaskHeader WHERE Task_ID = @mTaskCode AND PIC_Project = @mProject AND PC_ProcessCode = @mProcessCode";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == null)
                {
                    uSkip = 0;
                }
                else
                {
                    uSkip = int.Parse(row[0].ToString());
                }

            }

            return uSkip;
        }

        public bool TaskCodeIsExist(String mTaskCode, String mProcessCode, String mProjectName) //Check project is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPIC_Project", SqlDbType.NVarChar);
            
            SelectCommand.Parameters["@mTask_ID"].Value = mTaskCode;            
            SelectCommand.Parameters["@mPC_ProcessCode"].Value = mProcessCode;
            SelectCommand.Parameters["@mPIC_Project"].Value = mProjectName;

            SelectCommand.CommandText = "SELECT Task_ID FROM tbl_TaskHeader WHERE Task_ID=@mTask_ID AND PC_ProcessCode=@mPC_ProcessCode AND PIC_Project=@mPIC_Project";

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

        public bool TaskCodeIsExist2(String mTaskCode, String mProcessCode) //Check project is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);


            SelectCommand.Parameters["@mTask_ID"].Value = mTaskCode;
            SelectCommand.Parameters["@mPC_ProcessCode"].Value = mProcessCode;

            //SelectCommand.CommandText = "SELECT Task_ID FROM tbl_PCPHeader WHERE Task_ID=@mTask_ID AND PCP_ID=@mPC_ProcessCode";
            SelectCommand.CommandText = "SELECT d.Task_ID FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON d.PCP_ID = h.PCP_ID WHERE d.Task_ID = @mTask_ID AND h.PCP_ID = @mPC_ProcessCode";

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

        public String TaskCodeExisltMAXCount(String mTaskCode, String mProcessCode, String mProjectName) //Check project is already exists
        {
            String uCount = "";
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            //SelectCommand.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPIC_Project", SqlDbType.NVarChar);

            //SelectCommand.Parameters["@mTask_ID"].Value = mTaskCode;
            SelectCommand.Parameters["@mPC_ProcessCode"].Value = mProcessCode;
            SelectCommand.Parameters["@mPIC_Project"].Value = mProjectName;

           
           SelectCommand.CommandText = "SELECT MAX((CAST (RIGHT(Task_ID, LEN(Task_ID) - 6)AS int))) FROM tbl_TaskHeader WHERE PC_ProcessCode=@mPC_ProcessCode AND PIC_Project=@mPIC_Project AND Task_ID LIKE '"+ mTaskCode + "%'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString()==null)
                {
                    uCount = "0";
                }
                else
                {
                    uCount = row[0].ToString();
                }
                
            }

            return uCount;
        }
    }
}
