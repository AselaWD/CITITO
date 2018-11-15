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
    class UserManagementHeaderMng
    {
        //P_UID                 varchar(50)     Unchecked
        //P_Name                varchar(200)    Unchecked
        //P_Password            varchar(1000)   Unchecked
        //P_AccessLevel         varchar(50)     Unchecked
        //P_Availability        int             Unchecked
        //P_Activate_Date       datetime        Unchecked
        //P_Inactivate_Date     datetime        Checked
        //P_Shift	            varchar(100)	Checked
        //PTR_Resources	        varchar(50)	    Checked

        SqlConnection mConnectionUser;

        //Default connection
        public UserManagementHeaderMng()
        {

        }

        //Constructor Overload
        public UserManagementHeaderMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddUserManagementHeader(UserManagementHeader mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;

            insetComm.Parameters.Add("@mP_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mP_Name", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mP_Password", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mP_AccessLevel", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mP_Availability", SqlDbType.Int);
            insetComm.Parameters.Add("@mP_Activate_Date", SqlDbType.DateTime);
            //insetComm.Parameters.Add("@mP_Inactivate_Date", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mP_Shift", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPTR_Resources", SqlDbType.NVarChar);


            insetComm.Parameters["@mP_UID"].Value = mDetail.P_UID;
            insetComm.Parameters["@mP_Name"].Value = mDetail.P_Name;
            insetComm.Parameters["@mP_Password"].Value = mDetail.P_Password;
            insetComm.Parameters["@mP_AccessLevel"].Value = mDetail.P_AccessLevel;
            insetComm.Parameters["@mP_Availability"].Value = mDetail.P_Availability;
            insetComm.Parameters["@mP_Activate_Date"].Value = mDetail.P_Activate_Date;
            //insetComm.Parameters["@mP_Inactivate_Date"].Value = mDetail.P_Inactivate_Date;
            insetComm.Parameters["@mP_Shift"].Value = mDetail.P_Shift;
            insetComm.Parameters["@mPTR_Resources"].Value = mDetail.PTR_Resources;


            insetComm.CommandText = "INSERT INTO tbl_UserManagementHeader(P_UID,P_Name,P_Password,P_AccessLevel,P_Availability,P_Activate_Date,P_Shift,PTR_Resources) VALUES(@mP_UID,@mP_Name,@mP_Password,@mP_AccessLevel,@mP_Availability,@mP_Activate_Date,@mP_Shift, @mPTR_Resources)";
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

        public bool UserIsExist(String mDetail) //Check User is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mP_UID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mP_UID"].Value = mDetail;


            SelectCommand.CommandText = "SELECT P_UID FROM tbl_UserManagementHeader WHERE P_UID=@mP_UID AND P_Availability=1";

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

        public bool UserIsExistWithInactive(String mDetail) //Check Manager is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mP_UID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mP_UID"].Value = mDetail;


            SelectCommand.CommandText = "SELECT P_UID FROM tbl_UserManagementHeader WHERE P_UID=@mP_UID AND P_Availability=0";

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

        public bool UserIsExistUnderManager(String mUID, String mManager, String mPIC) //Check Manager is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.P_UID, s.M_UID, s.PIC_UID FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.P_UID = '" + mUID + "' AND s.M_UID = '" + mManager + "' AND s.PIC_UID = '" + mPIC + "'";

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

        public bool UserIsExistUnderPIC(String mUID, String mPIC) //Check Manager is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.P_UID, s.M_UID, s.PIC_UID FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.P_UID = '" + mUID + "' AND s.PIC_UID = '" + mPIC + "'";

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

        public int UpdateUserNameWithAllDetails(UserManagementHeader mDetail) //Update Manager with All details in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mP_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mP_Name", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mP_Password", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mP_AccessLevel", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mP_Availability", SqlDbType.Int);
            updateComm.Parameters.Add("@mP_Activate_Date", SqlDbType.DateTime);
            //insetComm.Parameters.Add("@mP_Inactivate_Date", SqlDbType.DateTime);

            updateComm.Parameters["@mP_UID"].Value = mDetail.P_UID;
            updateComm.Parameters["@mP_Name"].Value = mDetail.P_Name;
            updateComm.Parameters["@mP_Password"].Value = mDetail.P_Password;
            updateComm.Parameters["@mP_AccessLevel"].Value = mDetail.P_AccessLevel;
            updateComm.Parameters["@mP_Availability"].Value = mDetail.P_Availability;
            updateComm.Parameters["@mP_Activate_Date"].Value = mDetail.P_Activate_Date;
            //insetComm.Parameters["@mP_Inactivate_Date"].Value = mDetail.P_Inactivate_Date;

            updateComm.CommandText = "UPDATE tbl_UserManagementHeader SET P_Name=@mP_Name, P_Password=@mP_Password, P_AccessLevel=@mP_AccessLevel, P_Availability=@mP_Availability, P_Activate_Date=@mP_Activate_Date WHERE P_UID=@mP_UID";

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

        public int UpdateUserNameWithPassword(String UserID, String NewName, String Password, String mResID) //Update User Name and Password in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mP_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mNewP_Name", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mP_Password", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mResID", SqlDbType.NVarChar);


            updateComm.Parameters["@mP_UID"].Value = UserID;
            updateComm.Parameters["@mNewP_Name"].Value = NewName;
            updateComm.Parameters["@mP_Password"].Value = Password;
            updateComm.Parameters["@mResID"].Value = mResID;

            updateComm.CommandText = "UPDATE tbl_UserManagementHeader SET P_Name=@mNewP_Name, P_Password=@mP_Password, PTR_Resources=@mResID WHERE P_UID=@mP_UID";

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

        public int UpdateUserName(String mUID, String NewName, String mResID) //Update User Name in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mP_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mNewP_Name", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mResID", SqlDbType.NVarChar);

            updateComm.Parameters["@mP_UID"].Value = mUID;
            updateComm.Parameters["@mNewP_Name"].Value = NewName;
            updateComm.Parameters["@mResID"].Value = mResID;

            updateComm.CommandText = "UPDATE tbl_UserManagementHeader SET P_Name=@mNewP_Name, PTR_Resources=@mResID WHERE P_UID=@mP_UID";

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

        public int UpdateUserAccessLevel(String mUID, String mAccessLevel) //Update User Name in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mP_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mP_AccessLevel", SqlDbType.NVarChar);

            updateComm.Parameters["@mP_UID"].Value = mUID;
            updateComm.Parameters["@mP_AccessLevel"].Value = mAccessLevel;

            updateComm.CommandText = "UPDATE tbl_UserManagementHeader SET P_AccessLevel=@mP_AccessLevel WHERE P_UID=@mP_UID";

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

        public int UpdateUserShiftDetails(String mUID, String mShift) //Update User Name in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mP_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mP_Shift", SqlDbType.NVarChar);

            updateComm.Parameters["@mP_UID"].Value = mUID;
            updateComm.Parameters["@mP_Shift"].Value = mShift;

            updateComm.CommandText = "UPDATE tbl_UserManagementHeader SET P_Shift=@mP_Shift WHERE P_UID=@mP_UID";

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

        public String GetresourceByUID(String mUID, String mManager, String mPIC) //Get Manager Name details
        {
            String mName = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT f.[PTR_Resources] FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.P_UID='" + mUID + "' AND s.M_UID = '" + mManager + "' AND s.PIC_UID = '" + mPIC + "' AND f.P_Availability=1 GROUP BY f.[PTR_Resources] ", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = row[0].ToString();
            }

            return mName;

        }

        public String GetUserNameByUID(String mUID, String mManager, String mPIC) //Get Manager Name details
        {
            String mName = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT f.P_Name FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.P_UID='" + mUID + "' AND s.M_UID = '" + mManager + "' AND s.PIC_UID = '" + mPIC + "' AND f.P_Availability=1 GROUP BY f.P_Name", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = row[0].ToString();
            }

            return mName;

        }

        public String GetManagerByUID(String mUID, String mPIC) //Get Manager Name details
        {
            String mName = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT s.M_UID FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.P_UID = '" + mUID + "' AND s.PIC_UID = '" + mPIC + "' AND f.P_Availability = 1 AND s.P_Project_Availability='Active' GROUP BY s.M_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = row[0].ToString();
            }

            return mName;

        }

        public DataTable GetProjectByUID(String mUID, String mPIC) //Get Project Name details
        {
            
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.P_Project FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.P_UID = '" + mUID + "' AND s.PIC_UID='" + mPIC + "' AND s.P_Project_Availability = 'Active' GROUP BY s.P_Project";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public String GetCurrentAccessLeveleByUID(String mUID, String mManager, String mPIC) //Get Manager Name details
        {
            String mName = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT f.P_AccessLevel FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE s.P_UID='" + mUID + "' AND s.M_UID = '" + mManager + "' AND s.PIC_UID = '" + mPIC + "' AND f.P_Availability=1 GROUP BY f.P_AccessLevel", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = row[0].ToString();
            }

            return mName;

        }

        public String GetCurrentShiftByUID(String mUID, String mPIC) //Get Manager Name details
        {
            String mName = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT f.P_Shift FROM tbl_UserManagementHeader f INNER JOIN tbl_UserManagementDetail s ON f.P_UID = s.P_UID WHERE f.P_UID = '" + mUID + "' AND s.PIC_UID = '" + mPIC + "' AND f.P_Availability = 1 GROUP BY f.P_Shift ", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = row[0].ToString();
            }

            return mName;

        }

        public int UpdateUserAsInactive(UserManagementHeader mDetail) //Update User with All details in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mUID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mP_Inactivate_Date", SqlDbType.DateTime);


            updateComm.Parameters["@mUID"].Value = mDetail.P_UID;
            updateComm.Parameters["@mP_Inactivate_Date"].Value = mDetail.P_Inactivate_Date;

            updateComm.CommandText = "UPDATE tbl_UserManagementHeader SET P_Availability=0, P_Inactivate_Date=@mP_Inactivate_Date WHERE P_UID=@mUID";

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

        public int UpdateUserPassword(String UserID, String Password) //Update User Password in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mUID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPassword", SqlDbType.NVarChar);

            updateComm.Parameters["@mUID"].Value = UserID;
            updateComm.Parameters["@mPassword"].Value = Password;

            updateComm.CommandText = "UPDATE tbl_UserManagementHeader SET P_Password=@mPassword WHERE P_UID=@mUID";

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

        public bool UserLogin(UserManagementHeader mUser)
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@User_ID", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@User_Pass", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@User_Availability", SqlDbType.Int);

            SelectCommand.Parameters["@User_ID"].Value = mUser.P_UID;
            SelectCommand.Parameters["@User_Pass"].Value = mUser.P_Password;
            SelectCommand.Parameters["@User_Availability"].Value = mUser.P_Availability;

            SelectCommand.CommandText = "SELECT P_UID,P_Password,P_Availability FROM tbl_UserManagementHeader WHERE P_UID=@User_ID AND P_Password=@User_Pass AND P_Availability=@User_Availability";

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

        public DataTable GetUserLoginDetails(UserManagementHeader mUser)
        {

            //Select databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@User_ID", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@User_Pass", SqlDbType.VarChar);

            SelectCommand.Parameters["@User_ID"].Value = mUser.P_UID;
            SelectCommand.Parameters["@User_Pass"].Value = mUser.P_Password;

            SelectCommand.CommandText = "SELECT P_UID,P_Name,P_Password,P_AccessLevel FROM tbl_UserManagementHeader WHERE P_UID=@User_ID AND P_Password=@User_Pass";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            return table;

        }


        //Reports Dashboard

        public int PICOperatorCount(String mPIC) //Update PIC Name in exsiting system
        {

            int uPIC = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT COUNT(*) FROM ( SELECT uh.P_UID FROM tbl_UserManagementHeader uh INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID = uh.P_UID WHERE ud.PIC_UID = '" + mPIC + "' AND uh.P_Availability = 1 AND P_AccessLevel = 'Common User' AND ud.P_Project_Availability='Active' GROUP BY uh.P_UID ) OperatorCount", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uPIC = int.Parse(row[0].ToString());
            }

            return uPIC;

        }

        public int MIDOperatorCount(String mPIC, String uMID) //Update PIC Name in exsiting system
        {

            int uPIC = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT COUNT(*) FROM ( SELECT uh.P_UID FROM tbl_UserManagementHeader uh INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID = uh.P_UID WHERE ud.PIC_UID = '"+ mPIC + "' AND uh.P_AccessLevel = 'Common User' AND ud.M_UID='" + uMID + "' AND uh.P_Availability = 1 AND ud.P_Project_Availability='Active' GROUP BY uh.P_UID) OperatorCount ", this.mConnectionUser);

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
