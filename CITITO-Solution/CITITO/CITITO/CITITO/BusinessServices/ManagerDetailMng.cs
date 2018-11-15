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
    class ManagerDetailMng
    {
        //M_UID                     varchar(50) Unchecked
        //M_Project                 varchar(50) Unchecked
        //M_Project_Availability	varchar(50)	Unchecked
        //M_Activate_Date	        datetime	Unchecked
        //M_Inactivate_Date	        datetime	Checked
        //PIC_UID                   varchar(50) Unchecked

        SqlConnection mConnectionUser;

        //Default connection
        public ManagerDetailMng()
        {

        }

        //Constructor Overload
        public ManagerDetailMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddManagerDetail(ManagerDetail mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;
            insetComm.Parameters.Add("@mM_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mM_Project", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mM_Project_Availability", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mM_Activate_Date", SqlDbType.DateTime);
            //insetComm.Parameters.Add("@mM_Inactivate_Date", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);


            insetComm.Parameters["@mM_UID"].Value = mDetail.M_UID;
            insetComm.Parameters["@mM_Project"].Value = mDetail.M_Project;
            insetComm.Parameters["@mM_Project_Availability"].Value = mDetail.M_Project_Availability;
            insetComm.Parameters["@mM_Activate_Date"].Value = mDetail.M_Activate_Date;
            //insetComm.Parameters["@mM_Inactivate_Date"].Value = mDetail.M_Inactivate_Date;
            insetComm.Parameters["@mPIC_UID"].Value = mDetail.PIC_UID;


            insetComm.CommandText = "INSERT INTO tbl_ManagerDetail(M_UID,M_Project,M_Project_Availability,M_Activate_Date,PIC_UID) VALUES(@mM_UID,@mM_Project,@mM_Project_Availability,@mM_Activate_Date,@mPIC_UID)";

           //insetComm.CommandText = "INSERT INTO tbl_ManagerDetail(M_UID,M_Project,M_Project_Availability,M_Activate_Date,M_Inactivate_Date) VALUES(@mM_UID,@mM_Project,@mM_Project_Availability,@mM_Activate_Date,@mM_Inactivate_Date)";
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

        public DataTable GetAllManagerDetailsByPIC(String mUID)//INNER JOIN to get Manager Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.M_UID AS [UID],f.M_Name AS [Name], s.M_Project AS [Project], f.M_AccessLevel [System Access Level], s.PIC_UID AS [PIC] FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID WHERE s.PIC_UID = '" + mUID + "' AND s.M_Project_Availability = 'Active' AND f.M_Availability=1";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllManagerDetailsByPICANDMID(String mUID, String mMID)//INNER JOIN to get Manager Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.M_UID AS [UID],f.M_Name AS [Name], s.M_Project AS [Project], f.M_AccessLevel [System Access Level], s.PIC_UID AS [PIC] FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID WHERE s.PIC_UID = '" + mUID + "' AND s.M_Project_Availability = 'Active' AND f.M_Availability=1 AND s.M_UID LIKE '"+ mMID + "%'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public List<String> GetUsersInDeletableProject(String mProject) //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT M_UID FROM tbl_ManagerDetail WHERE M_Project='" + mProject + "' AND M_Project_Availability='Active' ORDER BY M_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUID.Add(row[0].ToString());
            }
            return uUID;
        }
        public List<String> GetUsersInDeletableProjectAndPIC(String mPIC, String mProject) //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT p.PIC_UID, m.M_UID, u.P_UID FROM tbl_PICHeader p INNER JOIN tbl_ManagerDetail m ON m.PIC_UID = p.PIC_UID INNER JOIN tbl_UserManagementDetail u ON u.M_UID = m.M_UID WHERE p.PIC_UID = '" + mPIC + "' AND m.M_Project='" + mProject + "' AND u.P_Project='" + mProject + "' GROUP BY  p.PIC_UID, m.M_UID, u.P_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                //uUID.Add(row[0].ToString());
                uUID.Add(row[1].ToString());
                uUID.Add(row[2].ToString());
            }
            return uUID;
        }
        public bool GetUsersInDeletableProjectIsExist(String mProject) //Check Manager is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;
      
            SelectCommand.CommandText = "SELECT M_UID FROM tbl_ManagerDetail WHERE M_Project='" + mProject + "' AND M_Project_Availability='Active' ORDER BY M_UID";

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

        public bool UserIsExistonActiveProject(String mUID, String mProject) //Check Manager is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT M_UID FROM tbl_ManagerDetail WHERE M_Project='" + mProject + "' AND M_Project_Availability='Active' AND M_UID='"+ mUID + "'";

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

        public bool GetActiveProjectIsExistByManager(String mID, String mPIC, String mProject) //Check Active project is exist by manager
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT M_Project FROM tbl_ManagerDetail WHERE M_UID='"+ mID + "' AND PIC_UID='"+ mPIC + "' AND M_Project='" + mProject + "' AND M_Project_Availability='Active'";

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

        public List<String> ListAllActiveProjectsByDCDUser(String mUID) //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT s.M_Project FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID WHERE s.M_UID = '" + mUID + "' AND s.M_Project_Availability = 'Active'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUID.Add(row[0].ToString());
            }
            return uUID;
        }

        public bool ManagerInactiveProjectDetaiIsExist(String mUID, String mProject) //Check Manager is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mM_UID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mM_Project", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mM_UID"].Value = mUID;
            SelectCommand.Parameters["@mM_Project"].Value = mProject;


            SelectCommand.CommandText = "SELECT M_UID FROM tbl_ManagerDetail WHERE M_UID=@mM_UID AND M_Project=@mM_Project AND M_Project_Availability='Inactive'";

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

        public int UpdateManagerProjectFromInactiveToActiveWithPIC(String mUID, String mCurrentProject, DateTime mActive, String mPIC) //Update Manager Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mM_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_CurrentProject", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_Activate_Date", SqlDbType.DateTime);
            updateComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);


            updateComm.Parameters["@mM_UID"].Value = mUID;
            updateComm.Parameters["@mM_CurrentProject"].Value = mCurrentProject;
            updateComm.Parameters["@mM_Activate_Date"].Value = mActive;
            updateComm.Parameters["@mPIC_UID"].Value = mPIC;

            updateComm.CommandText = "UPDATE tbl_ManagerDetail SET M_Project_Availability='Active', M_Inactivate_Date=NULL, M_Activate_Date=@mM_Activate_Date, PIC_UID=@mPIC_UID WHERE M_UID=@mM_UID AND M_Project=@mM_CurrentProject";

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

        public int UpdateManagerProjectToInactive(String mUID, String mCurrentProject, DateTime mInactive) //Update Manager Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mM_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_CurrentProject", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_Inactivate_Date", SqlDbType.DateTime);


            updateComm.Parameters["@mM_UID"].Value = mUID;
            updateComm.Parameters["@mM_CurrentProject"].Value = mCurrentProject;
            updateComm.Parameters["@mM_Inactivate_Date"].Value = mInactive;

            updateComm.CommandText = "UPDATE tbl_ManagerDetail SET M_Project_Availability='Inactive', M_Inactivate_Date=@mM_Inactivate_Date WHERE M_UID=@mM_UID AND M_Project=@mM_CurrentProject";

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
        public int UpdateManagerProjectToInactiveByManagerID(String mUID, DateTime mInactive) //Update Manager Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mM_UID", SqlDbType.NVarChar);
            //updateComm.Parameters.Add("@mProject", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_Inactivate_Date", SqlDbType.DateTime);


            updateComm.Parameters["@mM_UID"].Value = mUID;
            //updateComm.Parameters["@mProject"].Value = mProject;
            updateComm.Parameters["@mM_Inactivate_Date"].Value = mInactive;

            updateComm.CommandText = "UPDATE tbl_ManagerDetail SET M_Project_Availability='Inactive', M_Inactivate_Date=@mM_Inactivate_Date WHERE M_UID=@mM_UID AND M_Project_Availability='Active'";
            

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
        public int UpdateManagerProjectFromInactiveToActive(String mUID, String mCurrentProject, DateTime mActive) //Update Manager Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mM_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_CurrentProject", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_Activate_Date", SqlDbType.DateTime);


            updateComm.Parameters["@mM_UID"].Value = mUID;
            updateComm.Parameters["@mM_CurrentProject"].Value = mCurrentProject;
            updateComm.Parameters["@mM_Activate_Date"].Value = mActive;

            updateComm.CommandText = "UPDATE tbl_ManagerDetail SET M_Project_Availability='Active', M_Inactivate_Date=NULL, M_Activate_Date=@mM_Activate_Date WHERE M_UID=@mM_UID AND M_Project=@mM_CurrentProject";

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

        //public List<String> GetAllActiveProjectsByManager1(String mPIC, String mManager) //Get all Projects by manager UID Codes
        //{
        //    List<String> uTaskCodes = new List<string>();

        //    //Data adapter with select command
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = new SqlCommand("SELECT s.M_Project FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID  WHERE s.PIC_UID = '" + mPIC + "' AND s.M_UID = '" + mManager + "' AND s.M_Project_Availability='Active'", this.mConnectionUser);

        //    DataTable table = new DataTable();
        //    da.Fill(table);

        //    foreach (DataRow row in table.Rows)
        //    {
        //        uTaskCodes.Add(row[0].ToString());
        //    }
        //    return uTaskCodes;
        //}
                
        public DataTable GetAllActiveProjectsByManager(String mPIC, String mManager) //Get all Projects by manager UID Codes
        {            
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT s.M_Project FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID  WHERE s.PIC_UID = '" + mPIC + "' AND s.M_UID = '" + mManager + "' AND s.M_Project_Availability='Active'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        //public List<String> GetAllProjectsByManagerExceptActives1(String mPIC, String mManager) //Get all Projects by manager UID Codes
        //{
        //    List<String> uTaskCodes = new List<string>();

        //    //Data adapter with select command
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = new SqlCommand("SELECT M_Project FROM tbl_ManagerDetail s WHERE s.PIC_UID = '"+ mPIC +"' AND s.M_UID != '"+ mManager +"' GROUP BY M_Project INTERSECT SELECT ProjectName FROM tbl_ProjectDetail GROUP BY ProjectName EXCEPT SELECT M_Project FROM tbl_ManagerDetail s WHERE s.PIC_UID = '"+ mPIC +"' AND s.M_UID = '"+ mManager +"'  GROUP BY M_Project", this.mConnectionUser);

        //    DataTable table = new DataTable();
        //    da.Fill(table);

        //    foreach (DataRow row in table.Rows)
        //    {
        //        uTaskCodes.Add(row[0].ToString());
        //    }
        //    return uTaskCodes;
        //}

        public DataTable GetAllProjectsByManagerExceptActives(String mPIC, String mManager) //Get all Projects by manager UID Codes
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;            

            SelectCommand.CommandText = "SELECT ProjectName FROM tbl_ProjectDetail s WHERE s.PIC_UID = '" + mPIC + "' GROUP BY ProjectName EXCEPT SELECT M_Project FROM tbl_ManagerDetail s INNER JOIN tbl_ProjectDetail f ON s.M_Project = f.ProjectName WHERE s.PIC_UID = '" + mPIC + "' AND s.M_UID = '" + mManager + "' AND s.M_Project_Availability = 'Active' GROUP BY s.M_Project";

            //SelectCommand.CommandText = "SELECT M_Project FROM tbl_ManagerDetail s INNER JOIN tbl_ProjectDetail f ON s.M_Project = f.ProjectName WHERE s.PIC_UID = '" + mPIC + "' AND s.M_UID = '" + mManager + "' AND s.M_Project_Availability = 'Active' GROUP BY s.M_Project EXCEPT SELECT M_Project FROM tbl_ManagerDetail s WHERE s.PIC_UID = '" + mPIC + "' AND s.M_UID = '" + mManager + "' AND s.M_Project_Availability != 'Active' GROUP BY M_Project";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public List<String> GetActiveProjectsByManage(String mManager) //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT M_Project FROM tbl_ManagerDetail WHERE M_UID='"+ mManager + "' AND M_Project_Availability='Active' ORDER BY M_Project", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUID.Add(row[0].ToString());
            }
            return uUID;
        }

        public String GetManagerNameByUID(String mManager) //Get Manager Name details
        {
            String mPIC = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT PIC_UID FROM tbl_ManagerDetail WHERE M_UID='" + mManager + "' AND M_Project_Availability='Active' GROUP BY PIC_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mPIC = row[0].ToString();
            }

            return mPIC;

        }

        public String GetProjectNameByManager(String mManager) //Get Manager Name details
        {
            String mPIC = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT PIC_UID FROM tbl_ManagerDetail WHERE M_UID='" + mManager + "' AND M_Project_Availability='Active' GROUP BY PIC_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mPIC = row[0].ToString();
            }

            return mPIC;

        }

    }
}
