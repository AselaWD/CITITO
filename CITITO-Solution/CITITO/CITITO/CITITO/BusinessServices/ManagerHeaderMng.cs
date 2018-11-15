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
    class ManagerHeaderMng
    {

        //M_UID                 varchar(50)     Unchecked
        //M_Name                varchar(200)    Unchecked
        //M_Password            varchar(1000)   Unchecked
        //M_AccessLevel         varchar(50)     Unchecked
        //M_Availability        int             Unchecked
        //M_Activate_Date       datetime        Checked
        //M_Inactivate_Date     datetime        Checked


        SqlConnection mConnectionUser;

        //Default connection
        public ManagerHeaderMng()
        {

        }

        //Constructor Overload
        public ManagerHeaderMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddManagerHeader(ManagerHeader mDetail)
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;

            insetComm.Parameters.Add("@mM_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mM_Name", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mM_Password", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mM_AccessLevel", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mM_Availability", SqlDbType.Int);
            insetComm.Parameters.Add("@mM_Activate_Date", SqlDbType.DateTime);
            //insetComm.Parameters.Add("@mM_Inactivate_Date", SqlDbType.DateTime);


            insetComm.Parameters["@mM_UID"].Value = mDetail.M_UID;
            insetComm.Parameters["@mM_Name"].Value = mDetail.M_Name;
            insetComm.Parameters["@mM_Password"].Value = mDetail.M_Password;
            insetComm.Parameters["@mM_AccessLevel"].Value = mDetail.M_AccessLevel;
            insetComm.Parameters["@mM_Availability"].Value = mDetail.M_Availability;
            insetComm.Parameters["@mM_Activate_Date"].Value = mDetail.M_Activate_Date;
            //insetComm.Parameters["@mM_Inactivate_Date"].Value = mDetail.M_Inactivate_Date;


            insetComm.CommandText = "INSERT INTO tbl_ManagerHeader(M_UID,M_Name,M_Password,M_AccessLevel,M_Availability,M_Activate_Date) VALUES(@mM_UID,@mM_Name,@mM_Password,@mM_AccessLevel,@mM_Availability,@mM_Activate_Date)";
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

        public bool ManagerIsExist(String mDetail) //Check Manager is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mM_UID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mM_UID"].Value = mDetail;


            SelectCommand.CommandText = "SELECT M_UID FROM tbl_ManagerHeader WHERE M_UID=@mM_UID AND M_Availability=1";

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

        public bool ManagerIsExistWithInactive(String mDetail) //Check Manager is already exists

        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@mM_UID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mM_UID"].Value = mDetail;


            SelectCommand.CommandText = "SELECT M_UID FROM tbl_ManagerHeader WHERE M_UID=@mM_UID AND M_Availability=0";

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

        public bool ManagerIsExistUnderPIC(String mPIC, String mManger) //Check Manager is already exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.M_UID, s.PIC_UID FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID  WHERE s.PIC_UID = '"+ mPIC +"' AND s.M_UID = '"+ mManger + "'";

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
        public String GetManagerNameByUID(String mPIC, String mManger) //Get Manager Name details
        {
            String mName = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT f.M_Name FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID  WHERE s.PIC_UID = '"+ mPIC + "' AND s.M_UID = '"+ mManger + "' AND f.M_Availability=1 GROUP BY f.M_Name", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = row[0].ToString();
            }

            return mName;

        }

        public String GetManagerNameByMUID(String mManger) //Get Manager Name details
        {
            String mName = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT f.M_Name FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID  WHERE s.M_UID = '" + mManger + "' AND f.M_Availability=1 GROUP BY f.M_Name", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = row[0].ToString();
            }

            return mName;

        }

        /// <summary>
        /// UPDATE: Manager access level to filter DCD from data table
        /// </summary>
        /// <param name="mPIC"></param>
        /// <returns></returns>
        public List<String> GetActiveManagerUIDByPIC(String mPIC) //Get Manager Name details
        {           
            List<String> uPICUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT s.M_UID FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID WHERE s.PIC_UID = '" + mPIC + "' AND f.M_AccessLevel='Immediate Manager' AND f.M_Availability = 1 GROUP BY s.M_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uPICUID.Add(row[0].ToString());
            }
            return uPICUID;

        }

        public DataTable GetActiveManagerUIDByPIC1(String mPIC) //Get Manager Name details
        {
            //Select databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT s.M_UID FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID WHERE s.PIC_UID = '" + mPIC + "' AND f.M_Availability = 1 GROUP BY s.M_UID";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            return table;

        }

        public List<String> GetListOfManagerByPICExceptParameterManager(String mPIC, String mManager) //Get Project Names
        {

            List<String> uProjectName = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT s.M_UID FROM tbl_ManagerHeader f INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID WHERE s.PIC_UID = '"+ mPIC +"' AND s.M_UID != '"+ mManager +"' AND f.M_Availability = 1 GROUP BY s.M_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProjectName.Add(row[0].ToString());
            }
            return uProjectName;

        }
        public int UpdateManagerNameWithAllDetails(ManagerHeader mDetail) //Update Manager with All details in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mUID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mNewName", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPassword", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_Availability", SqlDbType.Int);
            updateComm.Parameters.Add("@mM_Activate_Date", SqlDbType.DateTime);
            //updateComm.Parameters.Add("@mM_Inactivate_Date", SqlDbType.DateTime);


            updateComm.Parameters["@mUID"].Value = mDetail.M_UID;
            updateComm.Parameters["@mNewName"].Value = mDetail.M_Name;
            updateComm.Parameters["@mPassword"].Value = mDetail.M_Password;
            updateComm.Parameters["@mM_Availability"].Value = mDetail.M_Availability;
            updateComm.Parameters["@mM_Activate_Date"].Value = mDetail.M_Activate_Date;
            //updateComm.Parameters["@mM_Inactivate_Date"].Value = mDetail.M_Inactivate_Date;

            updateComm.CommandText = "UPDATE tbl_ManagerHeader SET M_Name=@mNewName, M_Password=@mPassword, M_Availability=@mM_Availability, M_Activate_Date=@mM_Activate_Date WHERE M_UID=@mUID";

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

        public int UpdateManagerAsInactive(ManagerHeader mDetail) //Update Manager with All details in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mUID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_Inactivate_Date", SqlDbType.DateTime);


            updateComm.Parameters["@mUID"].Value = mDetail.M_UID; 
            updateComm.Parameters["@mM_Inactivate_Date"].Value = mDetail.M_Inactivate_Date;

            updateComm.CommandText = "UPDATE tbl_ManagerHeader SET M_Availability=0, M_Inactivate_Date=@mM_Inactivate_Date WHERE M_UID=@mUID";

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

        public int UpdateManagerNameWithPassword(String UserID, String NewName, String Password) //Update Manager Name and Password in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mUID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mNewName", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPassword", SqlDbType.NVarChar);


            updateComm.Parameters["@mUID"].Value = UserID;
            updateComm.Parameters["@mNewName"].Value = NewName;
            updateComm.Parameters["@mPassword"].Value = Password;

            updateComm.CommandText = "UPDATE tbl_ManagerHeader SET M_Name=@mNewName, M_Password=@mPassword WHERE M_UID=@mUID";

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

        public int UpdateManagerPassword(String UserID, String Password) //Update PIC Password in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mUID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPassword", SqlDbType.NVarChar);

            updateComm.Parameters["@mUID"].Value = UserID;
            updateComm.Parameters["@mPassword"].Value = Password;

            updateComm.CommandText = "UPDATE tbl_ManagerHeader SET M_Password=@mPassword WHERE M_UID=@mUID";

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

        public int UpdateManagerName(String UserID, String NewName) //Update PIC Name in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mUID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mNewName", SqlDbType.NVarChar);

            updateComm.Parameters["@mUID"].Value = UserID;
            updateComm.Parameters["@mNewName"].Value = NewName;

            updateComm.CommandText = "UPDATE tbl_ManagerHeader SET M_Name=@mNewName WHERE M_UID=@mUID";

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

        public int UpdateManagerAccessLevel(String mUID, String mAccessLevel) //Update User Name in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mM_UID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mM_AccessLevel", SqlDbType.NVarChar);

            updateComm.Parameters["@mM_UID"].Value = mUID;
            updateComm.Parameters["@mM_AccessLevel"].Value = mAccessLevel;

            updateComm.CommandText = "UPDATE tbl_ManagerHeader SET M_AccessLevel=@mM_AccessLevel WHERE M_UID=@mM_UID";

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

        public String GetCurrentAccessLeveleByManagerUID(String mUID, String mPIC) //Get Manager Name details
        {
            String mName = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT h.M_AccessLevel FROM tbl_ManagerHeader h INNER JOIN tbl_ManagerDetail s ON h.M_UID = s.M_UID WHERE s.M_UID = '"+ mUID + "' AND s.PIC_UID = '"+ mPIC + "' AND h.M_Availability = 1 GROUP BY h.M_AccessLevel", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = row[0].ToString();
            }

            return mName;

        }

        public bool ManagerLogin(ManagerHeader mUser)
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@User_ID", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@User_Pass", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@User_Availability", SqlDbType.Int);

            SelectCommand.Parameters["@User_ID"].Value = mUser.M_UID;
            SelectCommand.Parameters["@User_Pass"].Value = mUser.M_Password;
            SelectCommand.Parameters["@User_Availability"].Value = mUser.M_Availability;

            SelectCommand.CommandText = "SELECT M_UID,M_Password,M_Availability FROM tbl_ManagerHeader WHERE M_UID=@User_ID AND M_Password=@User_Pass AND M_Availability=@User_Availability";

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

        public DataTable GetManagerLoginDetails(ManagerHeader mUser)
        {

            //Select databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@User_ID", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@User_Pass", SqlDbType.VarChar);

            SelectCommand.Parameters["@User_ID"].Value = mUser.M_UID;
            SelectCommand.Parameters["@User_Pass"].Value = mUser.M_Password;

            SelectCommand.CommandText = "SELECT M_UID,M_Name,M_Password,M_AccessLevel FROM tbl_ManagerHeader WHERE M_UID=@User_ID AND M_Password=@User_Pass";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            return table;

        }


        //Reports Dashboard

        public int PICTeamCount(String mPIC) //Update PIC Name in exsiting system
        {

            int uPIC = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT COUNT(*) FROM ( SELECT mh.M_UID FROM tbl_ManagerHeader mh INNER JOIN tbl_ManagerDetail md ON md.M_UID = mh.M_UID WHERE md.PIC_UID = '" + mPIC + "' AND mh.M_Availability = 1 AND M_AccessLevel = 'Immediate Manager' GROUP BY mh.M_UID ) TeamCount", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uPIC = int.Parse(row[0].ToString());
            }

            return uPIC;

        }
        public int MIDTeamCount(String mPIC, String mMUID) //Update PIC Name in exsiting system
        {

            int uPIC = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT COUNT(*) FROM ( SELECT mh.M_UID FROM tbl_ManagerHeader mh INNER JOIN tbl_ManagerDetail md ON md.M_UID = mh.M_UID WHERE md.PIC_UID = '" + mPIC + "' AND mh.M_Availability = 1 AND M_AccessLevel = 'Immediate Manager' AND mh.M_UID='" + mMUID + "' GROUP BY mh.M_UID ) TeamCount", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uPIC = int.Parse(row[0].ToString());
            }

            return uPIC;

        }
        public int PICDCDCount(String mPIC) //Update PIC Name in exsiting system
        {

            int uPIC = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT COUNT(*) FROM ( SELECT mh.M_UID FROM tbl_ManagerHeader mh INNER JOIN tbl_ManagerDetail md ON md.M_UID = mh.M_UID WHERE md.PIC_UID = '" + mPIC + "' AND mh.M_Availability = 1 AND M_AccessLevel = 'DCD' GROUP BY mh.M_UID) DCDCount", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uPIC = int.Parse(row[0].ToString());
            }

            return uPIC;

        }

        public int MIDDCDCount(String mPIC, String mMID) //Update PIC Name in exsiting system
        {

            int uPIC = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT COUNT(*) FROM ( SELECT mh.M_UID FROM tbl_ManagerHeader mh INNER JOIN tbl_ManagerDetail md ON md.M_UID = mh.M_UID WHERE md.PIC_UID = '" + mPIC + "' AND mh.M_Availability = 1 AND M_AccessLevel = 'DCD' GROUP BY mh.M_UID) DCDCount", this.mConnectionUser);

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
