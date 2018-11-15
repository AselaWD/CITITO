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
    class TaskDetailMng
    {
        //Task_ID               varchar(50)     Unchecked
        //Task_Description      varchar(500)    Checked
        //Task_UOM              varchar(100)    Checked
        //Task_Quota            bigint          Unchecked
        //PC_ProcessCode        varchar(100)    Unchecked
        //PIC_Project           varchar(50)     Unchecked
        //TR_Index              bigint  Unchecked

      SqlConnection mConnectionUser;

        //Default connection
        public TaskDetailMng()
        {

        }

        //Constructor Overload
        public TaskDetailMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddTaskDetail(TaskDetail mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;
            insetComm.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTask_Description", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTask_UOM", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTask_Quota", SqlDbType.BigInt);
            insetComm.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPIC_Project", SqlDbType.NVarChar);


            insetComm.Parameters["@mTask_ID"].Value = mDetail.Task_ID;
            insetComm.Parameters["@mTask_Description"].Value = mDetail.Task_Description;
            insetComm.Parameters["@mTask_UOM"].Value = mDetail.Task_UOM;
            insetComm.Parameters["@mTask_Quota"].Value = mDetail.Task_Quota;
            insetComm.Parameters["@mPC_ProcessCode"].Value = mDetail.PC_ProcessCode;
            insetComm.Parameters["@mPIC_Project"].Value = mDetail.PIC_Project;

            insetComm.CommandText = "INSERT INTO tbl_TaskDetail(Task_ID,Task_Description,Task_UOM,Task_Quota,PC_ProcessCode,PIC_Project) VALUES(@mTask_ID,@mTask_Description,@mTask_UOM,@mTask_Quota,@mPC_ProcessCode,@mPIC_Project)";
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

        public int DeleteTaskDetail(TaskDetail mDetail)
        {

            //insert databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mPIC_Project", SqlDbType.NVarChar);

            deleteComm.Parameters["@mTask_ID"].Value = mDetail.Task_ID;
            deleteComm.Parameters["@mPC_ProcessCode"].Value = mDetail.PC_ProcessCode;
            deleteComm.Parameters["@mPIC_Project"].Value = mDetail.PIC_Project;


            deleteComm.CommandText = "DELETE FROM tbl_TaskDetail WHERE Task_ID=@mTask_ID AND PC_ProcessCode=@mPC_ProcessCode AND PIC_Project=@mPIC_Project";

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

        /// <summary>
        /// DEBUG: Task modify all at once fixed.
        /// </summary>
        /// <param name="mTaskCode"></param>
        /// <param name="mDescription"></param>
        /// <param name="mUOM"></param>
        /// <param name="mQuota"></param>
        /// <param name="tempTask"></param>
        /// <param name="tempDes"></param>
        /// <param name="tempUOM"></param>
        /// <param name="tempQuota"></param>
        /// <param name="mProcessCode"></param>
        /// <returns></returns>
        public int UpdateTaskCodeDetail(String mTaskCode, String mDescription, String mUOM, int mQuota, String tempTask, String tempDes, String tempUOM, int tempQuota, String mProcessCode) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mTaskCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mDescription", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mUOM", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mQuota", SqlDbType.BigInt);

            updateComm.Parameters["@mTaskCode"].Value = mTaskCode;
            updateComm.Parameters["@mDescription"].Value = mDescription;
            updateComm.Parameters["@mUOM"].Value = mUOM;
            updateComm.Parameters["@mQuota"].Value = mQuota;

            updateComm.CommandText = "UPDATE tbl_TaskDetail SET Task_Description=@mDescription, Task_UOM=@mUOM, Task_Quota=@mQuota WHERE Task_ID='"+ tempTask + "' AND Task_Description='"+ tempDes + "' AND Task_UOM='"+ tempUOM + "' AND Task_Quota='"+ tempQuota + "' AND PC_ProcessCode='"+ mProcessCode + "'";

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

        public DataTable GetAllTaskCodeDetailsByPICUID(String mPIC)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota] , s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code], h.SkipOutputValidation AS [User Output Validation] FROM tbl_TaskDetail s INNER JOIN tbl_TaskHeader h ON s.Task_ID = h.Task_ID AND h.PC_ProcessCode = s.PC_ProcessCode INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName WHERE p.PIC_UID = '" + mPIC + "'";

            //SelectCommand.CommandText = "SELECT s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota] , s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code] FROM tbl_TaskDetail s INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName WHERE p.PIC_UID = '"+ mPIC + "'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllTaskCodeDetailsByPICUIDANDProject(String mPIC, String mProject)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;            

            SelectCommand.CommandText = "SELECT s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota] , s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code], h.SkipOutputValidation AS [User Output Validation] FROM tbl_TaskDetail s INNER JOIN tbl_TaskHeader h ON s.Task_ID = h.Task_ID AND h.PC_ProcessCode = s.PC_ProcessCode INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName WHERE p.PIC_UID = '" + mPIC + "' AND p.ProjectName= '" + mProject + "'";

            //SelectCommand.CommandText = "SELECT s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota] , s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code] FROM tbl_TaskDetail s INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName WHERE p.PIC_UID = '" + mPIC + "' AND p.ProjectName= '"+ mProject + "'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included
        public DataTable GetAllTaskCodeDetailsByPICUID_Project_ProcessCode(String mPIC, String mProject, String mProcessCode)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota] , s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code], h.SkipOutputValidation AS [User Output Validation] FROM tbl_TaskDetail s INNER JOIN tbl_TaskHeader h ON s.Task_ID = h.Task_ID AND h.PC_ProcessCode = s.PC_ProcessCode INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName WHERE p.PIC_UID = '" + mPIC + "' AND p.ProjectName= '" + mProject + "' AND s.PC_ProcessCode='" + mProcessCode + "'";

            // SelectCommand.CommandText = "SELECT s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota] , s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code] FROM tbl_TaskDetail s INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName WHERE p.PIC_UID = '" + mPIC + "' AND p.ProjectName= '" + mProject + "' AND s.PC_ProcessCode='" + mProcessCode + "'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllTaskCodeDetails()//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code], s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota], h.SkipOutputValidation AS [User Output Validation] FROM tbl_TaskDetail s INNER JOIN tbl_TaskHeader h ON h.Task_ID = s.Task_ID AND h.PC_ProcessCode = s.PC_ProcessCode INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName";

            //SelectCommand.CommandText = "SELECT s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code], s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota] FROM tbl_TaskDetail s INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllTaskCodeDetailsBYProject(String mProjectName)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code], s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota], h.SkipOutputValidation AS [User Output Validation] FROM tbl_TaskDetail s INNER JOIN tbl_TaskHeader h ON h.Task_ID = s.Task_ID AND h.PC_ProcessCode = s.PC_ProcessCode INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName WHERE p.ProjectName LIKE '" + mProjectName + "%' OR  p.ProjectName LIKE '%" + mProjectName + "'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllTaskCodeDetailsBYTaskCode(String mTaskCode)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code], s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota], h.SkipOutputValidation AS [User Output Validation] FROM tbl_TaskDetail s INNER JOIN tbl_TaskHeader h ON h.Task_ID = s.Task_ID AND h.PC_ProcessCode = s.PC_ProcessCode INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName WHERE s.Task_ID LIKE '" + mTaskCode + "%' OR s.Task_ID LIKE '%" + mTaskCode + "'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllTaskCodeDetailsBYProcessCode(String mProcessCode)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code], s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota], h.SkipOutputValidation AS [User Output Validation] FROM tbl_TaskDetail s INNER JOIN tbl_TaskHeader h ON h.Task_ID = s.Task_ID AND h.PC_ProcessCode = s.PC_ProcessCode INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName WHERE s.PC_ProcessCode LIKE '" + mProcessCode + "%' OR s.PC_ProcessCode LIKE '%" + mProcessCode + "'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public bool TaskCodeDetailIsExixts(String mDescription, String mUOM, String mQuota, String mProcessCode) //Check project is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT f.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota], f.PC_ProcessCode AS [Item/Process Code] FROM tbl_TaskHeader f INNER JOIN tbl_TaskDetail s ON f.Task_ID = s.Task_ID WHERE s.Task_Description = '"+ mDescription + "' AND s.Task_UOM = '"+ mUOM + "' AND s.Task_Quota = '"+ mQuota + "' AND f.PC_ProcessCode = '"+ mProcessCode + "'";

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

        public List<String> GetAllTaskCodeDetailsByProcessCode(String mProcessCode) //This will be updated with JOIN once Operators table Created
        {
            List<String> uTaskCode = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT s.Task_ID, s.Task_Description FROM tbl_TaskDetail s WHERE s.PC_ProcessCode = '" + mProcessCode + "' GROUP BY s.Task_ID, s.Task_Description", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT f.Task_ID, s.Task_Description FROM tbl_TaskHeader f INNER JOIN tbl_TaskDetail s ON f.Task_ID = s.Task_ID WHERE f.PC_ProcessCode = '" + mProcessCode + "' GROUP BY f.Task_ID, s.Task_Description", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uTaskCode.Add(row[0].ToString() + " - "+ row[1].ToString());
            }
            return uTaskCode;
        }

        /// <summary>
        /// DEBUG: UOM and Quota filter withour process code error.
        /// </summary>
        /// <param name="mTaskCode"></param>
        /// <param name="mProcessCode"></param>
        /// <returns></returns>
        public String GetUOMFromTaskCode(String mTaskCode, String mProcessCode)
        {
            String uUOM = "";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT Task_UOM FROM tbl_TaskDetail WHERE Task_ID='"+ mTaskCode + "' AND PC_ProcessCode='"+ mProcessCode + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUOM = row[0].ToString();
            }
            return uUOM;
        }
        public int GetQuotaFromTaskCode(String mTaskCode, String mProcessCode)
        {
            int uQuota = 0;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT Task_Quota FROM tbl_TaskDetail WHERE Task_ID='"+ mTaskCode + "' AND PC_ProcessCode='"+ mProcessCode + "'", this.mConnectionUser);
            //da.SelectCommand = new SqlCommand("SELECT Task_Quota FROM tbl_TaskDetail WHERE Task_ID='" + mTaskCode + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uQuota = int.Parse(row[0].ToString());
            }
            return uQuota;
        }


        public List<String> GetAllTaskCodeDetailsByPIC(String mPIC) //This will be updated with JOIN once Operators table Created
        {
            List<String> uTaskCode = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT s.Task_ID FROM tbl_TaskDetail s INNER JOIN tbl_ProjectDetail pr ON pr.ProjectName = s.PIC_Project WHERE pr.PIC_UID = '" + mPIC + "' GROUP BY s.Task_ID ", this.mConnectionUser);


            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uTaskCode.Add(row[0].ToString());
            }
            return uTaskCode;
        }

        public List<String> GetAllTaskCodeDetailsByManager(String mPIC, String mMUID) //This will be updated with JOIN once Operators table Created
        {
            List<String> uTaskCode = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT s.Task_ID FROM tbl_TaskDetail s INNER JOIN tbl_ProjectDetail pr ON pr.ProjectName = s.PIC_Project INNER JOIN tbl_ManagerDetail md ON pr.ProjectName = md.M_Project AND md.M_Project_Availability = 'Active' WHERE pr.PIC_UID = '"+ mPIC + "' AND md.M_UID = '"+ mMUID + "' GROUP BY s.Task_ID", this.mConnectionUser);


            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uTaskCode.Add(row[0].ToString());
            }
            return uTaskCode;
        }

    }
}
