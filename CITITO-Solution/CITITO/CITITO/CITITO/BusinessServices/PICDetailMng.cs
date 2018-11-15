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
    class PICDetailMng
    {
        //PIC_UID       varchar(50)     Unchecked
        //PIC_Name      varchar(200)    Unchecked
        //PIC_Password	varchar(1000)	Unchecked

        SqlConnection mConnectionUser;

        //Default connection
        public PICDetailMng()
        {

        }

        //Constructor Overload
        public PICDetailMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddPICDetail(PICDetail mDetail)
        {
            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;

            insetComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPIC_Name", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPIC_Password", SqlDbType.NVarChar);

            insetComm.Parameters["@mPIC_UID"].Value = mDetail.PIC_UID;
            insetComm.Parameters["@mPIC_Name"].Value = mDetail.PIC_Name;
            insetComm.Parameters["@mPIC_Password"].Value = mDetail.PIC_Password;


            insetComm.CommandText = "INSERT INTO tbl_PICDetail(PIC_UID,PIC_Name,PIC_Password) VALUES(@mPIC_UID,@mPIC_Name,@mPIC_Password)";
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

        public int DeletePICDetail(PICDetail mDetail)
        {

            //insert databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mPIC_UID", SqlDbType.NVarChar);

            deleteComm.Parameters["@mPIC_UID"].Value = mDetail.PIC_UID;
            

            deleteComm.CommandText = "DELETE FROM tbl_PICDetail WHERE PIC_UID=@mPIC_UID";
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

        public DataTable GetPICLoginDetails(PICDetail mUser)
        {

            //Select databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@User_ID", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@User_Pass", SqlDbType.VarChar);

            SelectCommand.Parameters["@User_ID"].Value = mUser.PIC_UID;
            SelectCommand.Parameters["@User_Pass"].Value = mUser.PIC_Password;

            SelectCommand.CommandText = "SELECT PIC_UID,PIC_Name,PIC_Password FROM tbl_PICDetail where PIC_UID=@User_ID AND PIC_Password=@User_Pass";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            return table;

        }

        public DataTable GetAllPICDetailsByUIDForTemp(String UserID) //Get all PCP details
        {
            //Select databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT PIC_Name, PIC_Password FROM tbl_PICDetail WHERE PIC_UID='" + UserID + "'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            return table;

        }

        public bool PICLogin(PICDetail mUser)
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.Parameters.Add("@User_ID", SqlDbType.VarChar);
            SelectCommand.Parameters.Add("@User_Pass", SqlDbType.VarChar);

            SelectCommand.Parameters["@User_ID"].Value = mUser.PIC_UID;
            SelectCommand.Parameters["@User_Pass"].Value = mUser.PIC_Password;

            SelectCommand.CommandText = "SELECT PIC_UID,PIC_Password FROM tbl_PICDetail where PIC_UID=@User_ID AND PIC_Password=@User_Pass";

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

        public DataTable GetAllPICDetails()//INNER JOIN to get PIC Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT f.PIC_UID AS [UID],s.PIC_Name AS [PIC Name],f.PIC_AccessLevel [System Access Level] FROM tbl_PICHeader f INNER JOIN tbl_PICDetail s ON f.PIC_UID = s.PIC_UID";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public DataTable GetAllPICDetailsBYUID(String mUID)//INNER JOIN to get PIC Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;


            SelectCommand.CommandText = "SELECT f.PIC_UID AS [UID],s.PIC_Name AS [PIC Name],f.PIC_AccessLevel [System Access Level] FROM tbl_PICHeader f INNER JOIN tbl_PICDetail s ON f.PIC_UID = s.PIC_UID WHERE s.PIC_UID LIKE '"+ mUID + "%'";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public String GetAllPICNameByUID(String UserID) //Get all PCP details
        {
            String mName = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT PIC_Name FROM tbl_PICDetail WHERE PIC_UID='" + UserID + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = row[0].ToString();
            }

            return mName;

        }

        public String GetPICNamByMUID(String mManger) //Get Manager Name details
        {
            String mName = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data

            //DEBUG: Ative project PIC show.

            da.SelectCommand = new SqlCommand("SELECT pd.PIC_Name FROM tbl_ManagerDetail f INNER JOIN tbl_PICDetail pd ON pd.PIC_UID = f.PIC_UID WHERE f.M_Project_Availability='Active' AND f.M_UID = '" + mManger + "' GROUP BY pd.PIC_Name ", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT pd.PIC_Name FROM tbl_ManagerDetail f INNER JOIN tbl_PICDetail pd ON pd.PIC_UID = f.PIC_UID WHERE f.M_UID = '"+ mManger + "' GROUP BY pd.PIC_Name", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mName = row[0].ToString();
            }

            return mName;

        }

        public String GetPICUIDByMUID(String mUID) //Get Manager UID details
        {
            String mMUID = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT f.PIC_UID FROM tbl_ManagerDetail f WHERE f.M_UID = '"+ mUID + "' AND M_Project_Availability='Active' GROUP BY f.PIC_UID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                mMUID = row[0].ToString();
            }

            return mMUID;

        }

        public int UpdatePICName(String UserID, String NewName) //Update PIC Name in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mUID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mNewName", SqlDbType.NVarChar);

            updateComm.Parameters["@mUID"].Value = UserID;
            updateComm.Parameters["@mNewName"].Value = NewName;

            updateComm.CommandText = "UPDATE tbl_PICDetail SET PIC_Name=@mNewName WHERE PIC_UID=@mUID";

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
        public int UpdatePICNameWithPassword(String UserID, String NewName, String Password) //Update PIC Name and Password in exsiting system
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

            updateComm.CommandText = "UPDATE tbl_PICDetail SET PIC_Name=@mNewName, PIC_Password=@mPassword WHERE PIC_UID=@mUID";

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
        public int UpdatePICPassword(String UserID,  String Password) //Update PIC Password in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mUID", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPassword", SqlDbType.NVarChar);

            updateComm.Parameters["@mUID"].Value = UserID;
            updateComm.Parameters["@mPassword"].Value = Password;

            updateComm.CommandText = "UPDATE tbl_PICDetail SET PIC_Password=@mPassword WHERE PIC_UID=@mUID";

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


    }
}
