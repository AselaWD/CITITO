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
    class ProjectDetailMng
    {
        //Project_Index	        bigint	        Unchecked
        //ProjectName           varchar(50)     Unchecked
        //PIC_UID               varchar(50)     Unchecked
        //SkipOutputValidation	int     	    Checked     /* 0 - No , 1 - Yes */

        SqlConnection mConnectionUser;

        //Default connection
        public ProjectDetailMng()
        {

        }

        //Constructor Overload
        public ProjectDetailMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddProjectDetail(ProjectDetail mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;
            insetComm.Parameters.Add("@mProjectName", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mSkipOutputValidation", SqlDbType.Int);


            insetComm.Parameters["@mProjectName"].Value = mDetail.ProjectName;
            insetComm.Parameters["@mPIC_UID"].Value = mDetail.PIC_UID;
            insetComm.Parameters["@mSkipOutputValidation"].Value = mDetail.SkipOutputValidation;

            insetComm.CommandText = "INSERT INTO tbl_ProjectDetail(ProjectName,PIC_UID,SkipOutputValidation) VALUES(@mProjectName,@mPIC_UID,@mSkipOutputValidation)";
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

        public int DeleteProjectDetail(ProjectDetail mDetail)
        {

            //insert databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mProjectName", SqlDbType.NVarChar);
            deleteComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);


            deleteComm.Parameters["@mProjectName"].Value = mDetail.ProjectName;
            deleteComm.Parameters["@mPIC_UID"].Value = mDetail.PIC_UID;

            deleteComm.CommandText = "DELETE FROM tbl_ProjectDetail WHERE ProjectName=@mProjectName AND PIC_UID=@mPIC_UID";
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

        public int UpdateProjectDetail(String mOldProjectName, String mProjectName, String mUID, int mCheck) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mOldProjectName", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mProjectName", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mSkipOutputValidation", SqlDbType.Int);

            updateComm.Parameters["@mOldProjectName"].Value = mOldProjectName;
            updateComm.Parameters["@mProjectName"].Value = mProjectName;
            updateComm.Parameters["@mPIC_UID"].Value = mUID;
            updateComm.Parameters["@mSkipOutputValidation"].Value = mCheck;

            updateComm.CommandText = "UPDATE tbl_ProjectDetail SET ProjectName=@mProjectName, SkipOutputValidation=@mSkipOutputValidation WHERE PIC_UID=@mPIC_UID AND ProjectName=@mOldProjectName";

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

        public int UpdateProjectDetailWithSkippValidation(String mProjectName, String mUID, int mCheck) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mProjectName", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mSkipOutputValidation", SqlDbType.Int);

            updateComm.Parameters["@mProjectName"].Value = mProjectName;
            updateComm.Parameters["@mPIC_UID"].Value = mUID;
            updateComm.Parameters["@mSkipOutputValidation"].Value = mCheck;

            updateComm.CommandText = "UPDATE tbl_ProjectDetail SET SkipOutputValidation=@mSkipOutputValidation WHERE PIC_UID=@mPIC_UID AND ProjectName=@mProjectName";

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

        public int UpdateProjectPIC(String mOldPIC, String mNewPIC) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.CommandText = "UPDATE tbl_ProjectDetail SET PIC_UID='"+ mNewPIC + "' WHERE PIC_UID='"+ mOldPIC + "'";

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

        public int UpdateProjectPICForProject(String mProject, String mOldPIC, String mNewPIC) //Update Project in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.CommandText = "UPDATE tbl_ProjectDetail SET PIC_UID='" + mNewPIC + "' WHERE PIC_UID='" + mOldPIC + "' AND ProjectName='"+ mProject + "'";

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

        public bool ProjectDetailIsExist(String mPName, String mUID) //Check project is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mProjectName", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mProjectName"].Value = mPName;
            SelectCommand.Parameters["@mPIC_UID"].Value = mUID;
 
            SelectCommand.CommandText = "SELECT ProjectName FROM tbl_ProjectDetail WHERE ProjectName=@mProjectName AND PIC_UID=@mPIC_UID";

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

        public bool ProjectIsExistNotUnderPIC(String mPName, String mUID) //Check project is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mProjectName", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mProjectName"].Value = mPName;
            SelectCommand.Parameters["@mPIC_UID"].Value = mUID;

            SelectCommand.CommandText = "SELECT ProjectName, PIC_UID FROM tbl_ProjectDetail WHERE ProjectName=@mProjectName AND PIC_UID!=@mPIC_UID";

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

        public DataTable GetAllProjectDetailsByPIC(String mUID)//INNER JOIN to get Project Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.ProjectName AS [Project Name],f.PC_ProcessCode AS [Process Code], s.PIC_UID AS [PIC] FROM tbl_ProcessCodeHeader f INNER JOIN tbl_ProjectDetail s ON f.PIC_Project = s.ProjectName WHERE s.PIC_UID='" + mUID + "'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included
        public DataTable GetAllProjectDetailsByPICANDProjectName(String mUID, String mProjectName)//INNER JOIN to get Project Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.ProjectName AS [Project Name],f.PC_ProcessCode AS [Process Code], s.PIC_UID AS [PIC] FROM tbl_ProcessCodeHeader f INNER JOIN tbl_ProjectDetail s ON f.PIC_Project = s.ProjectName WHERE s.PIC_UID='"+ mUID + "' AND s.ProjectName LIKE '" + mProjectName + "%'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllProjectDetailsByPIC_ProjectName_ProcessCode(String mUID, String mProjectName, String mProcessCode)//INNER JOIN to get Project Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.ProjectName AS [Project Name],f.PC_ProcessCode AS [Process Code], s.PIC_UID AS [PIC] FROM tbl_ProcessCodeHeader f INNER JOIN tbl_ProjectDetail s ON f.PIC_Project = s.ProjectName WHERE s.PIC_UID='" + mUID + "' AND s.ProjectName ='" + mProjectName + "' AND f.PC_ProcessCode LIKE '"+ mProcessCode + "%'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllProjectDetails()//INNER JOIN to get Project Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.ProjectName AS [Project Name],f.PC_ProcessCode AS [Process Code], s.PIC_UID AS [PIC] FROM tbl_ProcessCodeHeader f INNER JOIN tbl_ProjectDetail s ON f.PIC_Project = s.ProjectName";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public String GetPICByProject(String mProject) //Get all PCP details
        {
            String mName = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT PIC_UID FROM tbl_ProjectDetail WHERE ProjectName='" + mProject + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = row[0].ToString();
            }

            return mName;

        }

        public int GetProjectOutputValidation(String mProject, String mUID) //Get all PCP details
        {
            int mName = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT SkipOutputValidation FROM tbl_ProjectDetail WHERE ProjectName='" + mProject + "' AND PIC_UID='"+ mUID + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = int.Parse(row[0].ToString());
            }

            return mName;

        }

        public List<String> GetListOfProjectNames() //Get Project Names
        {

            List<String> uProjectName = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT ProjectName FROM tbl_ProjectDetail", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProjectName.Add(row[0].ToString());
            }
            return uProjectName;

        }

        public List<String> GetListOfProjectNamesByPIC(String mPIC) //Get Project Names
        {

            List<String> uProjectName = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT ProjectName FROM tbl_ProjectDetail WHERE PIC_UID='" + mPIC + "' ORDER BY ProjectName", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProjectName.Add(row[0].ToString());
            }
            return uProjectName;

        }

        public List<String> GetListOfProjectNamesByManager(String mPIC, String mMUID) //Get Project Names
        {

            List<String> uProjectName = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT P_Project FROM tbl_UserManagementDetail WHERE PIC_UID = '"+ mPIC + "' AND M_UID = '"+ mMUID + "' AND P_Project_Availability = 'Active' GROUP BY P_Project", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProjectName.Add(row[0].ToString());
            }
            return uProjectName;

        }

        public List<String> GetListOfProjectNamesByPICExceptParameterProjectName(String mPIC, String mProjetc) //Get Project Names
        {

            List<String> uProjectName = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT ProjectName FROM tbl_ProjectDetail WHERE PIC_UID='" + mPIC + "' AND ProjectName!='"+ mProjetc + "' ORDER BY ProjectName", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProjectName.Add(row[0].ToString());
            }
            return uProjectName;

        }

        public List<String> GetAllProjects(String mPIC) //Get all projects
        {
            List<String> uTaskCodes = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT ProjectName FROM tbl_ProjectDetail WHERE PIC_UID='" + mPIC + "' ORDER BY ProjectName", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uTaskCodes.Add(row[0].ToString());
            }
            return uTaskCodes;
        }

        public DataTable GetAllProjectsByPIC(String mPIC) //Get all projects
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT ProjectName FROM tbl_ProjectDetail WHERE PIC_UID='" + mPIC + "' ORDER BY ProjectName";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        public DataTable GetAllUsersByPICAndCurrentProject(String mPIC, String mProject) //Get all projects
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT p.PIC_UID, m.M_UID, u.P_UID FROM tbl_PICHeader p INNER JOIN tbl_ManagerDetail m ON m.PIC_UID = p.PIC_UID INNER JOIN tbl_UserManagementDetail u ON u.M_UID = m.M_UID WHERE p.PIC_UID = '" + mPIC + "' AND m.M_Project='" + mProject + "' AND u.P_Project='" + mProject + "' GROUP BY  p.PIC_UID, m.M_UID, u.P_UID";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        //Reports Dashboard

        public int PICProjectCount(String mPIC) //Update PIC Name in exsiting system
        {

            int uPIC = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT COUNT(ProjectName) FROM tbl_ProjectDetail WHERE PIC_UID = '" + mPIC + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uPIC = int.Parse(row[0].ToString());
            }

            return uPIC;

        }

        public int MIDProjectCount(String mPIC, String mMID) //Update PIC Name in exsiting system
        {

            int uPIC = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand(" SELECT  COUNT(*) FROM( SELECT(P_Project)  FROM tbl_UserManagementDetail WHERE PIC_UID = '"+ mPIC + "' AND M_UID = '"+ mMID + "' AND P_Project_Availability = 'Active' GROUP BY P_Project ) ProjectsCount", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uPIC = int.Parse(row[0].ToString());
            }

            return uPIC;

        }

        public int PICTaskAndQuotaCount(String mPIC) //Update PIC Name in exsiting system
        {

            int uPIC = 0;

            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "Dboard_TaskAndWastageCount";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mPIC"].Value = mPIC;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uPIC = int.Parse(row[0].ToString());
            }

            return uPIC;

        }

    }
}
