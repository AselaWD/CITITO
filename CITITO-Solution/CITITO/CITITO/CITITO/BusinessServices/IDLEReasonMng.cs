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
    class IDLEReasonMng
    {
        //IDLE_ID       int             Unchecked
        //IDLE_Reason   varchar(1000)   Checked

        SqlConnection mConnectionUser;

        //Default connection
        public IDLEReasonMng()
        {

        }

        //Constructor Overload
        public IDLEReasonMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public List<String> GetIdleRreason() //Get all Reasons
        {
            List<String> uReason = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT IDLE_Reason FROM tbl_IDLEReason", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uReason.Add(row[0].ToString());
            }
            return uReason;
        }

    }
}
