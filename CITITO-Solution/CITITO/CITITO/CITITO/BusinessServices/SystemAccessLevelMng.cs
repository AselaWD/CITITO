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
    class SystemAccessLevelMng
    {
        //SysAccessLevel          varchar(50)     Unchecked
        //SysAccessDescription    varchar(500)    Checked

        SqlConnection mConnectionUser;

        //Default connection
        public SystemAccessLevelMng()
        {

        }

        //Constructor Overload
        public SystemAccessLevelMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public List<String> GetAccessLevelsForUserAndDCD() //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT SysAccessLevel FROM tbl_SysAccessLevel WHERE SysAccessLevel='Common User' ORDER BY SysAccessLevel", this.mConnectionUser);
            

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUID.Add(row[0].ToString());
            }
            return uUID;
        }

        public List<String> GetAccessLevelsForManagerAndDCDInPIC(String mCurrentAccess) //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT SysAccessLevel FROM tbl_SysAccessLevel EXCEPT SELECT SysAccessLevel FROM tbl_SysAccessLevel WHERE SysAccessLevel = '"+ mCurrentAccess +"' OR(SysAccessLevel = 'Project In Charge' OR SysAccessLevel = 'Common User') ORDER BY SysAccessLevel", this.mConnectionUser);
            //da.SelectCommand = new SqlCommand("SELECT SysAccessLevel FROM tbl_SysAccessLevel WHERE SysAccessLevel='Immediate Manager' ORDER BY SysAccessLevel", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUID.Add(row[0].ToString());
            }
            return uUID;
        }

        public List<String> GetAccessLevelsForManagerAndDCD() //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT SysAccessLevel FROM tbl_SysAccessLevel WHERE SysAccessLevel='DCD' OR SysAccessLevel='Immediate Manager' ORDER BY SysAccessLevel", this.mConnectionUser);


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
