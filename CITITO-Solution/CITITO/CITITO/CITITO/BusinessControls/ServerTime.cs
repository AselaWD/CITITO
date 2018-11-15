using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CITITO.BusinessControls
{
    class ServerTime
    {
        SqlConnection mConnectionUser;

        //Default connection
        public ServerTime()
        {

        }

        //Constructor Overload
        public ServerTime(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public DateTime getServerTime() /*CITITO Server Timespan*/
        {
            DateTime uDateTime = DateTime.Now;

            //SP to get servertime
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "getSeverTime";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);

            int rowCount = table.Rows.Count;

            if (rowCount > 0)
            {
                uDateTime= DateTime.Parse(table.Rows[0][0].ToString());
            }
            else
            {
                uDateTime= DateTime.Now;
            }

            return uDateTime;
        }

    }
}
