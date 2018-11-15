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
    class ResourceCodeMng
    {
        //RESOURCECLASS	    varchar (4)	    Unchecked
        //DESCRIPTION       varchar (50)    Checked
        //DAILYMINRATE      decimal (18, 2)	Checked
        //DAILYMAXRATE      decimal (18, 2)	Checked

        SqlConnection mConnectionUser;

        //Default connection
        public ResourceCodeMng()
        {

        }

        //Constructor Overload
        public ResourceCodeMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public DataTable GetAllresourceID()//Resource ID Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT [RESOURCECLASS] AS [Resouce ID] ,[DESCRIPTION] AS [Description], [DAILYMINRATE]  AS [Min Rate], [DAILYMAXRATE] AS [Max Rate] FROM tbl_ResourceCode";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }

        public bool IsExistPTRResourceID(String mPTRResouceID) //Is Exists
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT RESOURCECLASS FROM tbl_ResourceCode WHERE RESOURCECLASS = '" + mPTRResouceID + "'";

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
    }
}
