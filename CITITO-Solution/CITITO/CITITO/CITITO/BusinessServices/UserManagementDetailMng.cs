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
    class UserManagementDetailMng
    {
        //P_UID                     varchar(50) Unchecked
        //P_Project                 varchar(50) Unchecked
        //P_Project_Availability    varchar(50) Unchecked
        //P_Activate_Date           datetime    Unchecked
        //P_Inactivate_Date         datetime    Checked
        //M_UID                     varchar(50) Unchecked
        //PIC_UID                   varchar(50) Unchecked

      SqlConnection mConnectionUser;

        //Default connection
        public UserManagementDetailMng()
        {

        }

        //Constructor Overload
        public UserManagementDetailMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddUserManagementDetail(UserManagementDetail mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;
            insetComm.Parameters.Add("@mP_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mP_Project", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mP_Project_Availability", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mP_Activate_Date", SqlDbType.DateTime);
            //insetComm.Parameters.Add("@mP_Inactivate_Date", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mM_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);


            insetComm.Parameters["@mP_UID"].Value = mDetail.P_UID;
            insetComm.Parameters["@mP_Project"].Value = mDetail.P_Project;
            insetComm.Parameters["@mP_Project_Availability"].Value = mDetail.P_Project_Availability;
            insetComm.Parameters["@mP_Activate_Date"].Value = mDetail.P_Activate_Date;
            //insetComm.Parameters["@mP_Inactivate_Date"].Value = mDetail.P_Inactivate_Date;
            insetComm.Parameters["@mM_UID"].Value = mDetail.M_UID;
            insetComm.Parameters["@mPIC_UID"].Value = mDetail.PIC_UID;


            insetComm.CommandText = "INSERT INTO tbl_UserManagementDetail(P_UID,P_Project,P_Project_Availability,P_Activate_Date,M_UID,PIC_UID) VALUES(@mP_UID,@mP_Project,@mP_Project_Availability,@mP_Activate_Date,@mM_UID,@mPIC_UID)";
 
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

        public bool UserIsExistOnSameActiveProject(String mUID, String mProject) //Check User is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mP_UID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mP_Prject", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mP_UID"].Value = mUID;
            SelectCommand.Parameters["@mP_Prject"].Value = mProject;


            SelectCommand.CommandText = "SELECT P_UID FROM tbl_UserManagementDetail WHERE P_UID=@mP_UID AND P_Project=@mP_Prject AND P_Project_Availability='Active'";

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

        public DataTable GetAllUserDetailsByManager(String mManager)//INNER JOIN to get User Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT s.P_UID AS [UID],f.P_Name AS [Name], s.P_Project AS [Project], f.P_AccessLevel [System Access Level], s.M_UID AS [Immediate Manager], s.PIC_UID AS [PIC], f.P_Shift AS [Shift], f.[PTR_Resources] AS [Resource ID] FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.M_UID = '" + mManager + "' AND s.P_Project_Availability = 'Active' AND f.P_Availability = 1";

            //SelectCommand.CommandText = "SELECT s.P_UID AS [UID],f.P_Name AS [Name], s.P_Project AS [Project], f.P_AccessLevel [System Access Level], s.M_UID AS [Immediate Manager], s.PIC_UID AS [PIC], f.P_Shift AS [Shift] FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.M_UID = '" + mManager + "' AND s.P_Project_Availability = 'Active' AND f.P_Availability = 1";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllUserDetailsByPIC(String mPIC)//INNER JOIN to get User Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT s.P_UID AS [UID],f.P_Name AS [Name], s.P_Project AS [Project], f.P_AccessLevel [System Access Level], s.M_UID AS [Immediate Manager], s.PIC_UID AS [PIC], f.P_Shift AS [Shift], f.[PTR_Resources] AS [Resource ID] FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.PIC_UID = '"+ mPIC + "' AND s.P_Project_Availability = 'Active' AND f.P_Availability = 1";

            //SelectCommand.CommandText = "SELECT s.P_UID AS [UID],f.P_Name AS [Name], s.P_Project AS [Project], f.P_AccessLevel [System Access Level], s.M_UID AS [Immediate Manager], s.PIC_UID AS [PIC], f.P_Shift AS [Shift] FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.PIC_UID = '" + mPIC + "' AND s.P_Project_Availability = 'Active' AND f.P_Availability = 1";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllUserDetailsByPICANDPID(String mPIC, String mUID)//INNER JOIN to get User Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.P_UID AS [UID],f.P_Name AS [Name], s.P_Project AS [Project], f.P_AccessLevel [System Access Level], s.M_UID AS [Immediate Manager], s.PIC_UID AS [PIC] , f.P_Shift AS [Shift], f.[PTR_Resources] AS [Resource ID] FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.PIC_UID = '" + mPIC + "' AND s.P_Project_Availability = 'Active' AND f.P_Availability = 1 AND s.P_UID LIKE '"+ mUID + "%' AND s.P_UID LIKE '%" + mUID + "'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllProjectsByUserExceptActives(String mUID, String mManager, String mPIC) //Get all Projects by User UID Codes
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT M_Project FROM tbl_ManagerDetail s WHERE s.M_UID = '" + mManager + "' AND s.PIC_UID = '" + mPIC + "' AND s.M_Project_Availability = 'Active' GROUP BY M_Project EXCEPT SELECT P_Project FROM tbl_UserManagementDetail s INNER JOIN tbl_ManagerDetail f ON s.P_Project = f.M_Project WHERE s.P_UID = '" + mUID +"' AND s.M_UID = '" + mManager + "' AND s.PIC_UID = '" + mPIC + "' AND s.P_Project_Availability = 'Active' GROUP BY s.P_Project";


            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable GetAllActiveProjectsByUser(String mUID, String mManager, String mPIC) //Get all Projects by User UID Codes
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT s.P_Project FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.P_UID = '" + mUID + "' AND s.M_UID = '" + mManager + "' AND s.PIC_UID = '" + mPIC + "' AND s.P_Project_Availability = 'Active'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public List<String> ListAllActiveProjectsByUser(String mUID) //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT s.P_Project FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.P_UID = '" + mUID + "' AND s.P_Project_Availability = 'Active'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUID.Add(row[0].ToString());
            }
            return uUID;
        }

        public DataTable GetAllProjectsByManager(String mManager) //Get all projects
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT M_Project FROM tbl_ManagerDetail WHERE M_UID='"+ mManager + "' AND M_Project_Availability='Active' GROUP BY M_Project";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public bool GetActiveProjectIsExistByUser(String mUID, String mMID, String mPIC, String mProject) //Check Active project is exist by user
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT P_Project FROM tbl_UserManagementDetail WHERE P_UID = '" + mUID + "' AND M_UID = '" + mMID + "' AND PIC_UID = '" + mPIC + "' AND P_Project = '" + mProject + "' AND P_Project_Availability = 'Active'";

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

        public int UpdateUserProjectToInactive(String mUID, String mMID, String mCurrentProject, DateTime mInactive) //Update User Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mP_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_CurrentProject", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_Inactivate_Date", SqlDbType.DateTime);


            updateComm.Parameters["@mP_UID"].Value = mUID;
            updateComm.Parameters["@mM_UID"].Value = mMID;
            updateComm.Parameters["@mM_CurrentProject"].Value = mCurrentProject;
            updateComm.Parameters["@mM_Inactivate_Date"].Value = mInactive;

            updateComm.CommandText = "UPDATE tbl_UserManagementDetail SET P_Project_Availability = 'Inactive', P_Inactivate_Date = @mM_Inactivate_Date WHERE P_UID = @mP_UID AND M_UID = @mM_UID AND P_Project = @mM_CurrentProject";

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

        public bool UserInactiveProjectDetaiIsExist(String mUID, String mMID, String mProject) //Check User is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mP_UID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mM_UID", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mM_Project", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mP_UID"].Value = mUID;
            SelectCommand.Parameters["@mM_UID"].Value = mMID;
            SelectCommand.Parameters["@mM_Project"].Value = mProject;


            SelectCommand.CommandText = "SELECT P_UID FROM tbl_UserManagementDetail WHERE P_UID=@mP_UID AND M_UID=@mM_UID AND P_Project=@mM_Project AND P_Project_Availability='Inactive'";

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

        //Manager Details
        public String GetManagerUIDByUserID(String mUID) //Get Manager UID details
        {
            String mMUID= "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT M_UID FROM tbl_UserManagementDetail WHERE P_UID='"+ mUID + "' AND P_Project_Availability='Active' GROUP BY M_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mMUID = row[0].ToString();
            }

            return mMUID;

        }

        public String GetPICByUserID(String mUID)
        {
            String mMUID = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT PIC_UID FROM tbl_UserManagementDetail WHERE P_UID='"+ mUID + "' AND P_Project_Availability='Active' GROUP BY PIC_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mMUID = row[0].ToString();
            }

            return mMUID;

        }

        public String GetManagerNameByUserID(String mUID) //Get Manager UID details
        {
            String mMUID = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT M_UID FROM tbl_UserManagementDetail WHERE P_UID='" + mUID + "' AND P_Project_Availability='Active' GROUP BY M_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mMUID = row[0].ToString();
            }

            return mMUID;

        }

        public int UpdateUserAsInactive(UserManagementDetail mDetail) //Update Manager with All details in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mUID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mP_Inactivate_Date", SqlDbType.DateTime);


            updateComm.Parameters["@mUID"].Value = mDetail.P_UID;
            updateComm.Parameters["@mP_Inactivate_Date"].Value = mDetail.P_Inactivate_Date;

            updateComm.CommandText = "UPDATE tbl_UserManagementDetail SET P_Project_Availability='Inactive', P_Inactivate_Date=@mP_Inactivate_Date WHERE P_UID=@mUID";

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


        //User Modify by PIC

        public int UpdateUsersManagerByPIC(String UserID, String mManager) //Update User Name and Password in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mP_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_Manager", SqlDbType.NVarChar);


            updateComm.Parameters["@mP_UID"].Value = UserID;
            updateComm.Parameters["@mM_Manager"].Value = mManager;


            updateComm.CommandText = "UPDATE tbl_UserManagementDetail SET M_UID=@mM_Manager WHERE P_UID=@mP_UID AND P_Project_Availability='Active'";

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

        public bool ActiveUserIsExistOnDeletedManager(String mManager, String mPIC) //Check User is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mMnager", SqlDbType.NVarChar);
            SelectCommand.Parameters.Add("@mPIC", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mMnager"].Value = mManager;
            SelectCommand.Parameters["@mPIC"].Value = mPIC;


            SelectCommand.CommandText = "SELECT s.P_UID FROM tbl_UserManagementHeader s INNER JOIN tbl_UserManagementDetail f ON s.P_UID = f.P_UID WHERE f.M_UID = @mMnager AND f.PIC_UID = @mPIC AND P_Project_Availability = 'Active'";

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

        public List<String> GetActiveUserUsersInDeletableManager(String mManager, String mPIC) //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT s.P_UID FROM tbl_UserManagementHeader s INNER JOIN tbl_UserManagementDetail f ON s.P_UID = f.P_UID WHERE f.M_UID = '"+ mManager + "' AND f.PIC_UID = '"+ mPIC + "' AND P_Project_Availability = 'Active' GROUP BY s.P_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUID.Add(row[0].ToString());
            }
            return uUID;
        }

        public List<String> ListActiveUIDByPIC(String mPIC) //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT s.P_UID FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.PIC_UID = '"+ mPIC + "' AND s.P_Project_Availability = 'Active' AND f.P_Availability = 1 GROUP BY s.P_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUID.Add(row[0].ToString());
            }
            return uUID;
        }

        public List<String> ListActiveUIDByManager(String mPIC, String mMUID) //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT s.P_UID FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.PIC_UID = '"+ mPIC + "' AND s.P_Project_Availability = 'Active' AND f.P_Availability = 1 AND s.M_UID = '"+ mMUID + "' GROUP BY s.P_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUID.Add(row[0].ToString());
            }
            return uUID;
        }
    }
}
