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
    class PCPHeaderMng
    {
        //PCP_Index       bigint          Unchecked
        //PCP_ID          varchar(50)     Unchecked
        //PC_ProcessCode  varchar(100)    Unchecked
        //Task_ID         varchar(50)     Unchecked
        //PCP_Shipment    varchar(1000)   Unchecked

        SqlConnection mConnectionUser;

        //Default connection
        public PCPHeaderMng()
        {

        }

        //Constructor Overload
        public PCPHeaderMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddPCPHeader(PCPHeader mPCPH) //Add new PCP Record to the system
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;

            insetComm.Parameters.Add("@mPCP_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);
            //insetComm.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPCP_Shipment", SqlDbType.NVarChar);
          
            insetComm.Parameters["@mPCP_ID"].Value = mPCPH.PCP_ID;
            insetComm.Parameters["@mPC_ProcessCode"].Value = mPCPH.PC_ProcessCode;
            //insetComm.Parameters["@mTask_ID"].Value = mPCPH.Task_ID;
            insetComm.Parameters["@mPCP_Shipment"].Value = mPCPH.PCP_Shipment;

            insetComm.CommandText = "insert into tbl_PCPHeader(PCP_ID,PC_ProcessCode,PCP_Shipment)values(@mPCP_ID,@mPC_ProcessCode,@mPCP_Shipment)";
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

        public int DeletePCPHeader(String mPCP) //Delete Fresh PCP Bulk Record in exsiting system
        {

            //insert databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.CommandText = "DELETE FROM tbl_PCPHeader WHERE PCP_ID='" + mPCP + "'";

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

        //public int DeletePCPHeaderByTask(String mPCP, String mTask) //Delete Fresh PCP Bulk Record in exsiting system
        //{

        //    //insert databse values
        //    SqlCommand deleteComm = new SqlCommand();
        //    deleteComm.Connection = this.mConnectionUser;
        //    deleteComm.CommandType = CommandType.Text;

        //    deleteComm.CommandText = "DELETE FROM tbl_PCPHeader WHERE PCP_ID='" + mPCP + "' AND Task_ID='" + mTask + "'";

        //    int ans = deleteComm.ExecuteNonQuery();
        //    if (ans > 0)
        //    {
        //        return ans;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        public bool IsExistHeader(String mPCPCode)
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT PCP_ID FROM tbl_PCPHeader WHERE PCP_ID='" + mPCPCode + "'";

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


        public bool IsExistPCPCode(String mPCPCode)
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT PCP_ID FROM tbl_PCPHeader WHERE PCP_ID='" + mPCPCode + "'";

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
        /// <summary>
        /// Modified Order of Shipment Filtering
        /// </summary>
        /// <param name="mProject">ORDER BY DESC</param>
        /// <returns></returns>
        public List<String> GetListShipmentsByProject(String mProject) //Get ProcessCodes by Project
        {

            List<String> uProcessCodes = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT h.PCP_Shipment FROM tbl_PCPHeader h LEFT OUTER JOIN tbl_PCPDetail d ON d.PCP_ID = h.PCP_ID WHERE d.PCP_Project = '" + mProject + "' GROUP BY h.PCP_Shipment ORDER BY CASE     WHEN LEFT(h.PCP_Shipment, 1) LIKE '%[A-Za-z]%'     THEN LEFT(h.PCP_Shipment, 1) + RIGHT('0000000000' + SUBSTRING(h.PCP_Shipment, 2, LEN(h.PCP_Shipment) - 1), 9)     ELSE RIGHT('0000000000' + h.PCP_Shipment, 10) END DESC", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT h.PCP_Shipment FROM tbl_PCPHeader h LEFT OUTER JOIN tbl_PCPDetail d ON d.PCP_ID = h.PCP_ID WHERE d.PCP_Project = '" + mProject + "' GROUP BY h.PCP_Shipment ORDER BY MAX(h.PCP_Index) DESC", this.mConnectionUser);

           // da.SelectCommand = new SqlCommand("SELECT h.PCP_Shipment FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON d.PCP_ID = h.PCP_ID WHERE d.PCP_Project = '" + mProject + "' GROUP BY h.PCP_Shipment", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProcessCodes.Add(row[0].ToString());
            }
            return uProcessCodes;

        }

        public List<String> GetListPCPCodeByUser(String mUID) //Get ProcessCodes by Project
        {

            List<String> uProcessCodes = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT h.PCP_ID FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID =d.PCP_ID WHERE d.PCP_CreatorUID = '"+ mUID + "' GROUP BY h.PCP_ID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProcessCodes.Add(row[0].ToString());
            }
            return uProcessCodes;

        }

    }
}
