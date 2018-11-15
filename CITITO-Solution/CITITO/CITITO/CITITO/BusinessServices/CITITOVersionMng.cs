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
   
    class CITITOVersionMng
    {
        //Version varchar(1000)   Unchecked
        //LastModifiedDate    datetime Unchecked
        //Developer varchar(1000)   Unchecked

        SqlConnection mConnectionUser;

        //Default connection
        public CITITOVersionMng()
        {

        }

        //Constructor Overload
        public CITITOVersionMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public string GetCITITOCurrentVersion() //Get Actuall Last PCP ID details
        {
            
                string uVersion = "";

                //Data adapter with select command

                SqlDataAdapter da = new SqlDataAdapter();

                //Cast Table Data            
                da.SelectCommand = new SqlCommand("SELECT * FROM tbl_CITITOVersion", this.mConnectionUser);

                DataTable table = new DataTable();
                da.Fill(table);

                if (table.Rows.Count == 0)
                {
                    uVersion = "";
                }
                else
                {
                    uVersion = (table.Rows[0][0].ToString());
                }


                return uVersion;

        }

    }
}
