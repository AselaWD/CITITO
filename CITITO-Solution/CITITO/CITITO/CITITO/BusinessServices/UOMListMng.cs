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
    class UOMListMng
    {
        //UOM_Index	int	            Unchecked
        //UOM_Unit  varchar(100)    Unchecked

        SqlConnection mConnectionUser;

        //Default connection
        public UOMListMng()
        {

        }

        //Constructor Overload
        public UOMListMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public List<String> GetUOMList() //This will be updated with JOIN once Operators table Created
        {
            List<String> uUOM = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT UOM_Unit FROM tbl_UOMList", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUOM.Add(row[0].ToString());
            }
            return uUOM;
        }

    }
}
