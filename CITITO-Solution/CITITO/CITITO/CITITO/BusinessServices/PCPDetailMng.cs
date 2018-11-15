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
    class PCPDetailMng
    {
       //PCPD_Index        bigint          Unchecked
       //PCP_ID            varchar(50)     Unchecked
       //PCP_File          varchar(500)    Unchecked
       //PCP_FileSize      bigint          Unchecked
       //PCP_Status        int             Unchecked /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
       //PCP_Project       varchar(50)     Unchecked
       //Task_UOM          varchar(100)    Unchecked
       //Task_Quota        bigint          Unchecked
       //PCP_StartDate     datetime        Unchecked
       //PCP_EndDate       datetime        Checked
       //PCP_CreatorUID    varchar(50)     Unchecked
       //Task_ID	       varchar(50)	   Unchecked
       //PC_ProcessCode	   varchar(100)	   Unchecked

       SqlConnection mConnectionUser;

        //Default connection
        public PCPDetailMng()
        {

        }

        //Constructor Overload
        public PCPDetailMng(SqlConnection conn)
        {
            mConnectionUser = conn;
        }

        public int AddPCPDetail(PCPDetail mPCPD) //Add new PCP Record to the system
        {

            //insert databse values
            SqlCommand insetComm = new SqlCommand();
            insetComm.Connection = this.mConnectionUser;
            insetComm.CommandType = CommandType.Text;

            insetComm.Parameters.Add("@mPCP_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPCP_File", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPCP_FileSize", SqlDbType.BigInt);
            insetComm.Parameters.Add("@mPCP_Status", SqlDbType.Int); /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
            insetComm.Parameters.Add("@mPCP_Project", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTask_UOM", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTask_Quota", SqlDbType.BigInt);
            insetComm.Parameters.Add("@mPCP_StartDate", SqlDbType.DateTime);
            //insetComm.Parameters.Add("@mPCP_EndDate", SqlDbType.DateTime);
            insetComm.Parameters.Add("@mPCP_CreatorUID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mTask_ID", SqlDbType.NVarChar);
            insetComm.Parameters.Add("@mPC_ProcessCode", SqlDbType.NVarChar);
                 

            insetComm.Parameters["@mPCP_ID"].Value = mPCPD.PCP_ID;
            insetComm.Parameters["@mPCP_File"].Value = mPCPD.PCP_File;
            insetComm.Parameters["@mPCP_FileSize"].Value = mPCPD.PCP_FileSize;
            insetComm.Parameters["@mPCP_Status"].Value = mPCPD.PCP_Status; /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
            insetComm.Parameters["@mPCP_Project"].Value = mPCPD.PCP_Project;
            insetComm.Parameters["@mTask_UOM"].Value = mPCPD.Task_UOM;
            insetComm.Parameters["@mTask_Quota"].Value = mPCPD.Task_Quota;
            insetComm.Parameters["@mPCP_StartDate"].Value = mPCPD.PCP_StartDate;
            //insetComm.Parameters["@mPCP_EndDate"].Value = mPCPD.PCP_EndDate;
            insetComm.Parameters["@mPCP_CreatorUID"].Value = mPCPD.PCP_CreatorUID;
            insetComm.Parameters["@mTask_ID"].Value = mPCPD.Task_ID;
            insetComm.Parameters["@mPC_ProcessCode"].Value = mPCPD.PC_ProcessCode;


            insetComm.CommandText = "insert into tbl_PCPDetail(PCP_ID,PCP_File,PCP_FileSize,PCP_Status,PCP_Project,Task_UOM,Task_Quota,PCP_StartDate,PCP_CreatorUID,PC_ProcessCode,Task_ID)values(@mPCP_ID,@mPCP_File,@mPCP_FileSize,@mPCP_Status,@mPCP_Project,@mTask_UOM,@mTask_Quota,@mPCP_StartDate,@mPCP_CreatorUID,@mPC_ProcessCode,@mTask_ID)";

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

        public int UpdatePCPDetailToPending(String mPCP, String mTask, int mStatus, DateTime mDoneDate) //Update User Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mPCP", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mTask", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mDoneDate", SqlDbType.DateTime);



            updateComm.Parameters["@mPCP"].Value = mPCP;
            updateComm.Parameters["@mTask"].Value = mTask;
            updateComm.Parameters["@mStatus"].Value = mStatus;
            updateComm.Parameters["@mDoneDate"].Value = mDoneDate;
   

            updateComm.CommandText = "UPDATE tbl_PCPDetail SET PCP_Status = @mStatus, PCP_EndDate = @mDoneDate WHERE PCP_ID = @mPCP AND Task_ID = @mTask";

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

        public int UpdatePCPDetailToOnhold(String mPCP, int mStatus, DateTime mDoneDate) //Update User Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mPCP", SqlDbType.NVarChar);   
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mDoneDate", SqlDbType.DateTime);
            
            updateComm.Parameters["@mPCP"].Value = mPCP; 
            updateComm.Parameters["@mStatus"].Value = mStatus;
            updateComm.Parameters["@mDoneDate"].Value = mDoneDate;
            
            updateComm.CommandText = "UPDATE tbl_PCPDetail SET PCP_Status = @mStatus, PCP_EndDate = @mDoneDate WHERE PCP_ID = @mPCP AND PCP_Status=0";

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

        public int UpdatePCPDetailToHold(String mPCP, int mStatus, String mTask, DateTime mDoneDate) //Update User Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mPCP", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mDoneDate", SqlDbType.DateTime);
            updateComm.Parameters.Add("@mTask", SqlDbType.NVarChar);

            updateComm.Parameters["@mPCP"].Value = mPCP;
            updateComm.Parameters["@mStatus"].Value = mStatus;
            updateComm.Parameters["@mDoneDate"].Value = mDoneDate;
            updateComm.Parameters["@mTask"].Value = mTask;

            updateComm.CommandText = "UPDATE tbl_PCPDetail SET PCP_Status = @mStatus, PCP_EndDate = @mDoneDate WHERE PCP_ID = @mPCP AND PCP_Status!=3 AND Task_ID = @mTask";

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

        public int UpdatePCPDetailToFresh(String mPCP, int mStatus, String mTask) //Update User Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mPCP", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mTask", SqlDbType.NVarChar);


            updateComm.Parameters["@mPCP"].Value = mPCP;
            updateComm.Parameters["@mStatus"].Value = mStatus;
            updateComm.Parameters["@mTask"].Value = mTask;

            updateComm.CommandText = "UPDATE tbl_PCPDetail SET PCP_Status = @mStatus, PCP_EndDate = NULL WHERE PCP_ID = @mPCP AND PCP_Status!=3 AND Task_ID = @mTask";

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

        public int UpdatePCPDetailToPendingFromDisapproval(PCPDetail mPCPD) //Update User Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;
            
            updateComm.Parameters.Add("@mPCP", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mPCP_File", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mTask", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mProject", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mProcessCode", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);


            updateComm.Parameters["@mPCP"].Value = mPCPD.PCP_ID;
            updateComm.Parameters["@mPCP_File"].Value = mPCPD.PCP_File;
            updateComm.Parameters["@mTask"].Value = mPCPD.Task_ID;
            updateComm.Parameters["@mProject"].Value = mPCPD.PCP_Project;
            updateComm.Parameters["@mProcessCode"].Value = mPCPD.PC_ProcessCode;
            updateComm.Parameters["@mStatus"].Value = mPCPD.PCP_Status;



            updateComm.CommandText = "UPDATE tbl_PCPDetail SET PCP_Status = @mStatus, PCP_EndDate = NULL WHERE PCP_ID = @mPCP AND Task_ID = @mTask AND PCP_File=@mPCP_File AND PCP_Project=@mProject AND PC_ProcessCode=@mProcessCode";

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

        public int UpdatePCPDetailToPendingByteSize(String mPCP, String mTask, int mStatus, int mFileSize) //Update User Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mPCP", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mTask", SqlDbType.NVarChar);
            updateComm.Parameters.Add("@mStatus", SqlDbType.Int);
            updateComm.Parameters.Add("@mFileSize", SqlDbType.Int);
            
            updateComm.Parameters["@mPCP"].Value = mPCP;
            updateComm.Parameters["@mTask"].Value = mTask;
            updateComm.Parameters["@mStatus"].Value = mStatus;
            updateComm.Parameters["@mFileSize"].Value = mFileSize;
            
            updateComm.CommandText = "UPDATE tbl_PCPDetail SET PCP_Status = @mStatus, PCP_FileSize=@mFileSize WHERE PCP_ID = @mPCP AND Task_ID = @mTask";

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

        public int UpdatePCPDetailFileSizeByIndex(int mIndex, int mFileSize) //Update User Project as Inactive in exsiting system
        {

            //update databse values
            SqlCommand updateComm = new SqlCommand();
            updateComm.Connection = this.mConnectionUser;
            updateComm.CommandType = CommandType.Text;

            updateComm.Parameters.Add("@mIndex", SqlDbType.BigInt);
            updateComm.Parameters.Add("@mFileSize", SqlDbType.BigInt);


            updateComm.Parameters["@mIndex"].Value = mIndex;
            updateComm.Parameters["@mFileSize"].Value = mFileSize;


            updateComm.CommandText = "UPDATE tbl_PCPDetail SET PCP_FileSize = @mFileSize WHERE PCPD_Index = @mIndex AND PCP_Status != 3";

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

        public int FreshDeletePCPRecordByPCPID(PCPDetail mPCPD) //Delete Fresh PCP Bulk Record in exsiting system
        {

            //insert databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.Parameters.Add("@mPCPCode", SqlDbType.VarChar);

            deleteComm.Parameters["@mPCPCode"].Value = mPCPD.PCP_ID;


            deleteComm.CommandText = "DELETE FROM tbl_PCPDetail WHERE PCP_ID=@mPCPCode AND PCP_Status='0'";
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

        public int DeletePCPRecordByStatus(String mPCP, String mTask, int mStatus) //Delete Fresh PCP Bulk Record in exsiting system
        {

            //insert databse values
            SqlCommand deleteComm = new SqlCommand();
            deleteComm.Connection = this.mConnectionUser;
            deleteComm.CommandType = CommandType.Text;

            deleteComm.CommandText = "DELETE FROM tbl_PCPDetail WHERE PCP_ID='"+ mPCP + "'  AND Task_ID='"+ mTask + "' AND PCP_Status='" + mStatus + "'";

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

        public DataTable GetAllPCPDetailsByUserUID(String mUID)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandText = "DCD_getRegisteredPCPDetails";
            SelectCommand.CommandType = CommandType.StoredProcedure;

            SelectCommand.Parameters.Add("@mUID", SqlDbType.NVarChar);

            SelectCommand.Parameters["@mUID"].Value = mUID;

            //SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], d.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '"+mUID+"' ORDER BY d.PCPD_Index";

            //SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID WHERE d.PCP_CreatorUID = '" + mUID + "' ORDER BY d.PCPD_Index";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        public List<String> GetListOfDCDUID(String mUID) //Get task codes by PCP Code where not Done status
        {

            List<String> uTaskCode = new List<string>();

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT d.PCP_CreatorUID FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project WHERE u.M_UID = '"+ mUID + "' GROUP BY d.PCP_CreatorUID ORDER BY d.PCP_CreatorUID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uTaskCode.Add(row[0].ToString());

            }
            return uTaskCode;

        }

        public DataTable FilterJobCodesByUserUID(String mUID, String mJobCode)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;
            
            SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], d.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '"+ mUID +"' WHERE h.PCP_ID LIKE '" + mJobCode + "%' OR h.PCP_ID LIKE '%" + mJobCode + "' ORDER BY d.PCPD_Index";

            //SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID WHERE d.PCP_CreatorUID = '" + mUID + "' AND h.PCP_ID LIKE '" + mJobCode + "%' OR d.PCP_CreatorUID = '" + mUID + "' AND h.PCP_ID LIKE '%" + mJobCode + "' ORDER BY d.PCPD_Index";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included
        public DataTable FilterShipmentByUserUID(String mUID, String mShipment)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], d.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '"+ mUID + "' WHERE h.PCP_Shipment LIKE '" + mShipment + "%' OR h.PCP_Shipment LIKE '%" + mShipment + "' ORDER BY d.PCPD_Index";

            //SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID WHERE d.PCP_CreatorUID = '" + mUID + "' AND h.PCP_Shipment LIKE '" + mShipment + "%' OR d.PCP_CreatorUID = '" + mUID + "' AND h.PCP_Shipment LIKE '%" + mShipment + "' ORDER BY d.PCPD_Index";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included
        public DataTable FilterProcessCodeByUserUID(String mUID, String mProcessCode)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], d.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '"+ mUID + "' WHERE h.PC_ProcessCode LIKE '" + mProcessCode + "%' OR h.PC_ProcessCode LIKE '%" + mProcessCode + "' ORDER BY d.PCPD_Index";

            //SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID WHERE d.PCP_CreatorUID = '" + mUID + "' AND h.PC_ProcessCode LIKE '" + mProcessCode + "%' OR d.PCP_CreatorUID = '" + mUID + "' AND h.PC_ProcessCode LIKE '%" + mProcessCode + "' ORDER BY d.PCPD_Index";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included
        public DataTable FilterTaskCodeByUserUID(String mUID, String mTaskCode)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], d.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '"+ mUID +"' WHERE d.Task_ID LIKE '" + mTaskCode + "%' OR d.Task_ID LIKE '%" + mTaskCode + "' ORDER BY d.PCPD_Index";

            //SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID WHERE d.PCP_CreatorUID = '" + mUID + "' AND d.Task_ID LIKE '" + mTaskCode + "%' OR d.PCP_CreatorUID = '" + mUID + "' AND d.Task_ID LIKE '%" + mTaskCode + "' ORDER BY d.PCPD_Index";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included
        public DataTable FilterFileNameByUserUID(String mUID, String mFileName)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], d.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '"+ mUID + "' WHERE d.PCP_File LIKE '" + mFileName + "%' OR d.PCP_File LIKE '%" + mFileName + "' ORDER BY d.PCPD_Index";

            //SelectCommand.CommandText = "SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID WHERE d.PCP_CreatorUID = '" + mUID + "' AND d.PCP_File LIKE '" + mFileName + "%' OR d.PCP_CreatorUID = '" + mUID + "' AND d.PCP_File LIKE '%" + mFileName + "' ORDER BY d.PCPD_Index";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included
        public DataTable GetAllPCPDetailsByDCDUID(String mUID, String mDCDUID)//INNER JOIN to get Task Code Details
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT TOP (3000) d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], d.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project WHERE u.M_UID = '" + mUID + "' AND (d.PCP_CreatorUID LIKE '" + mDCDUID + "%' OR d.PCP_CreatorUID LIKE '%" + mDCDUID + "') ORDER BY d.PCPD_Index";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        } //INNER JOIN included

        /// <summary>
        /// DEBUG: Last row count getting issue.
        /// </summary>
        /// <param name="mProject"></param>
        /// <returns></returns>
        /// 
        public int GetLastRowCount(String mProject) //Get Actuall Last PCP ID details
        {
            int uItemCode = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data

            //BUG FIXED: Find more than 99 int from string - 2018-08-30
            da.SelectCommand = new SqlCommand("SELECT MAX(PCPD_Index), MAX(CAST(SUBSTRING(PCP_ID,10, LEN(PCP_ID)) AS INT)) AS [PCPID] FROM tbl_PCPDetail WHERE(PCP_Project = '" + mProject  + "') ORDER BY[PCPID] DESC", this.mConnectionUser);

             //da.SelectCommand = new SqlCommand("SELECT MAX(PCPD_Index), CAST(RIGHT(MAX(PCP_ID) , LEN(MAX(PCP_ID)) -9) AS INT) AS [PCPID] FROM tbl_PCPDetail WHERE(PCP_Project = '" + mProject + "') ORDER BY[PCPID] DESC", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT MAX(PCPD_Index), CAST(RIGHT(MAX(PCP_ID) , LEN(MAX(PCP_ID)) -9) AS INT) AS [PCPID] FROM tbl_PCPDetail WHERE(PCP_Project = '" + mProject + "' AND PCPD_Index = (SELECT MAX(PCPD_Index) FROM tbl_PCPDetail)) OR(PCP_Project = '" + mProject + "') GROUP BY PCPD_Index ORDER BY[PCPID] DESC", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT RIGHT(MAX(PCP_ID) , LEN(MAX(PCP_ID)) -9) FROM tbl_PCPDetail WHERE (PCP_Project='"+mProject+"' AND PCPD_Index=(SELECT MAX(PCPD_Index) FROM tbl_PCPDetail)) OR (PCP_Project='"+ mProject +"')", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);


            if (table.Rows.Count == 0 || String.IsNullOrEmpty(table.Rows[0][1].ToString()))
            {
                uItemCode = 0;
            }
            else
            {
                uItemCode = int.Parse(table.Rows[0][1].ToString());
            }

            return uItemCode;

        }

        public int GetLastRowCountwithTaskCode(String mProject, String mTaskCode) //Get Actuall Last PCP ID details
        {
            int uItemCode = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            //da.SelectCommand = new SqlCommand("SELECT RIGHT(MAX(PCP_ID) , LEN(MAX(PCP_ID)) -9) FROM tbl_PCPDetail WHERE PCP_Project='"+ mProject +"' AND PCPD_Index=(SELECT MAX(PCPD_Index) FROM tbl_PCPDetail)", this.mConnectionUser);
            da.SelectCommand = new SqlCommand("SELECT RIGHT(MAX(PCP_ID) , LEN(MAX(PCP_ID)) -9) FROM tbl_PCPDetail WHERE (PCP_Project='" + mProject + "' AND PCPD_Index=(SELECT MAX(PCPD_Index) FROM tbl_PCPDetail))", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (String.IsNullOrEmpty(row[0].ToString()))
                {
                    uItemCode = 0;
                }
                else
                {
                    uItemCode = int.Parse(row[0].ToString());
                }

            }
            return uItemCode;

        }

        public int GetCountPCPDeatails(String mPCPCode) //Get Actuall Last PCP ID details
        {
            int uPCPCode = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = new SqlCommand("SELECT COUNT(PCP_ID) FROM tbl_PCPDetail WHERE PCP_ID='" + mPCPCode + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (String.IsNullOrEmpty(row[0].ToString()))
                {
                    uPCPCode = 0;
                }
                else
                {
                    uPCPCode = int.Parse(row[0].ToString());
                }

            }
            return uPCPCode;

        }



        public int GetActualFileSize(String mPCPCode, String mTaskCode) //Get all PCP details
        {

            int uActualFileSize = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT PCP_FileSize FROM tbl_PCPDetail WHERE PCP_ID='" + mPCPCode + "' AND Task_ID='" + mTaskCode + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    uActualFileSize = 0;
                }
                else
                {
                    uActualFileSize = int.Parse(row[0].ToString());
                }

            }
            return uActualFileSize;

        }

        public String GetShipmentByPCPCode(String mPCPCode) //Get Shipment Name by PCP Code
        {

            String uShipment = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT PCP_Shipment FROM tbl_PCPDetail WHERE PCP_ID='" + mPCPCode + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uShipment = row[0].ToString();
            }
            return uShipment;

        }

        public String GetProcessCodeByPCPCode(String mTaskCode, String mPCPCode) //Get Shipment Name by PCP Code
        {

            String uShipment = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT PC_ProcessCode FROM tbl_PCPDetail WHERE PCP_ID='" + mPCPCode + "' AND Task_ID='"+ mTaskCode + "' GROUP BY PC_ProcessCode", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uShipment = row[0].ToString();
            }
            return uShipment;

        }

        public String GetPendingTaskByPCPCode(String mPCPCode, String mUID) //Get Shipment Name by PCP Code
        {

            String uShipment = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT p.Task_ID, t.Task_Description, td.Task_ID FROM tbl_PCPDetail p INNER JOIN tbl_TaskDetail t ON p.Task_ID = t.Task_ID AND p.PC_ProcessCode = t.PC_ProcessCode INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = p.PCP_ID AND td.Task_ID = p.Task_ID WHERE p.PCP_ID = '"+ mPCPCode + "' AND p.PCP_Status = '2' AND td.TR_UID = '"+ mUID + "'", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT p.Task_ID, t.Task_Description, td.Task_ID FROM tbl_PCPDetail p INNER JOIN tbl_TaskDetail t ON p.Task_ID = t.Task_ID AND p.PC_ProcessCode = t.PC_ProcessCode INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = p.PCP_ID WHERE p.PCP_ID = '"+ mPCPCode + "' AND p.PCP_Status = '2' AND td.TR_UID = '"+ mUID + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uShipment = (row[0].ToString() +" - "+ row[1].ToString());
            }
            return uShipment;

        }

        public bool IsExistPCPRecord(String mTask, String mProcessCode, String mProject, String mFile, int mFileSize, String mUOM, String mShipment)
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT d.Task_ID FROM tbl_PCPDetail d INNER JOIN tbl_PCPHeader h ON d.PCP_ID = h.PCP_ID AND d.PC_ProcessCode = h.PC_ProcessCode WHERE d.Task_ID = '"+mTask+"' AND d.PC_ProcessCode = '"+mProcessCode+"' AND d.PCP_Project = '"+mProject+"' AND d.PCP_File = '"+mFile+"' AND d.PCP_FileSize = '"+mFileSize+"' AND d.Task_UOM = '"+mUOM+"' AND h.PCP_Shipment = '"+ mShipment + "'";

            //SelectCommand.CommandText = "SELECT Task_ID FROM tbl_PCPDetail WHERE Task_ID = '"+mTask+"' AND PC_ProcessCode = '"+mProcessCode+"' AND PCP_Project = '"+mProject+"' AND PCP_File = '"+mFile+"' AND PCP_FileSize = '"+mFileSize+"' AND Task_UOM = '"+mUOM+"'";

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

        public bool IsExistHearedRecord(String mProcessCode, String mShipment, String mFile, String mTaskID)
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT d.PC_ProcessCode FROM tbl_PCPDetail d INNER JOIN tbl_PCPHeader h ON d.PCP_ID = h.PCP_ID WHERE d.PC_ProcessCode = '" + mProcessCode + "' AND h.PCP_Shipment = '" + mShipment + "' AND d.PCP_File = '"+ mFile +"' AND d.Task_ID = '" + mTaskID + "'";

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

        public bool IsExistFileName(String mShipment, String mFileName)
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT d.PCP_File FROM tbl_PCPDetail d INNER JOIN tbl_PCPHeader h ON d.PCP_ID = h.PCP_ID WHERE d.PCP_File = '"+ mFileName + "' AND h.PCP_Shipment = '"+ mShipment + "' AND d.PCP_Status != '1' GROUP BY d.PCP_File";

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

            SelectCommand.CommandText = "SELECT d.PCP_File, h.PCP_Shipment, d.PCP_Project FROM tbl_PCPDetail d INNER JOIN tbl_PCPHeader h ON d.PCP_ID = h.PCP_ID WHERE d.PCP_ID = '"+ mPCPCode + "' AND d.PCP_Status != '1' GROUP BY d.PCP_File, h.PCP_Shipment, d.PCP_Project";

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



        public List<String> GetTaskCodeByPCPCode(String mPCPCode) //Get ProcessCodes by Project
        {

            List<String> uProcessCodes = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT d.Task_ID FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID =d.PCP_ID WHERE d.PCP_ID = '" + mPCPCode + "' GROUP BY d.Task_ID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProcessCodes.Add(row[0].ToString());
            }
            return uProcessCodes;

        }

        public String GetProjectByPCPCode(String mPCPCode) //Get ProcessCodes by Project
        {

            String uProject = "";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT d.PCP_Project FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID =d.PCP_ID WHERE d.PCP_ID = '" + mPCPCode + "' GROUP BY d.PCP_Project", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uProject = row[0].ToString();
            }

            return uProject;
        }

        public List<String> GetStatusByTaskCode(String mPCPCode,String mTaskCode) //Get ProcessCodes by Project
        {

            List<String> uProcessCodes = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT d.PCP_Status FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID =d.PCP_ID WHERE d.PCP_ID = '"+ mPCPCode + "' AND d.Task_ID = '"+ mTaskCode + "' GROUP BY d.PCP_Status", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                
                if (row[0].ToString()=="0")
                {
                    uProcessCodes.Add("Fresh");
                }
                else if (row[0].ToString() == "1")
                {
                    uProcessCodes.Add("Hold");
                }
                else if (row[0].ToString() == "2")
                {
                    uProcessCodes.Add("Pending");
                }
                else if (row[0].ToString() == "3")
                {
                    uProcessCodes.Add("Done");
                }
            }
            return uProcessCodes;

        }

        public List<String> ListAllActiveShipmentsByManagerUID(String mMUID, String mProject) //This will be updated with JOIN once Operators table Created
        {
            List<String> uUID = new List<string>();

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SELECT h.PCP_Shipment FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON d.PCP_ID = h.PCP_ID INNER JOIN tbl_ManagerDetail m ON m.M_Project = d.PCP_Project WHERE m.M_UID = '" + mMUID + "' AND m.M_Project_Availability = 'Active' AND d.PCP_Project = '" + mProject + "' GROUP BY h.PCP_Shipment", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uUID.Add(row[0].ToString());
            }
            return uUID;
        }

        public DataTable ListAllActiveShipmentsByManagerUID_SuggestBox(String mMUID, String mProject) //This will be updated with JOIN once Operators table Created
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT h.PCP_Shipment FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON d.PCP_ID = h.PCP_ID INNER JOIN tbl_ManagerDetail m ON m.M_Project = d.PCP_Project WHERE m.M_UID = '" + mMUID + "' AND m.M_Project_Availability = 'Active' AND d.PCP_Project = '" + mProject + "' GROUP BY h.PCP_Shipment";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable ListAllFreshFilesByProjectAndShipment(String mMUID, String mProject, String mShipment) //This will be updated with JOIN once Operators table Created
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;
            
            SelectCommand.CommandText = "SELECT d.PCP_File FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON d.PCP_ID = h.PCP_ID INNER JOIN tbl_ManagerDetail m ON m.M_Project = d.PCP_Project WHERE m.M_UID = '"+ mMUID + "' AND m.M_Project_Availability = 'Active' AND d.PCP_Project = '"+ mProject + "' AND h.PCP_Shipment='"+ mShipment + "' AND d.PCP_Status != '3' AND d.PCP_Status != '1' GROUP BY d.PCP_File";

            //Data adapter with select command
            SqlDataAdapter da = new SqlDataAdapter();

            //Cast Table Data
            da.SelectCommand = SelectCommand;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        

        public List<String> GetTaskCodeByPCPCodeAndStatusNotDoneOrHold(String mPCPCode) //Get task codes by PCP Code where not Done status
        {

            List<String> uTaskCode = new List<string>();

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            //da.SelectCommand = new SqlCommand("SELECT p.Task_ID, t.Task_Description FROM tbl_PCPDetail p INNER JOIN tbl_TaskDetail t ON p.Task_ID = t.Task_ID WHERE p.PCP_ID = '" + mPCPCode + "' AND p.PCP_Status != '3' AND p.PCP_Status != '1' GROUP BY p.Task_ID, t.Task_Description", this.mConnectionUser);

            da.SelectCommand = new SqlCommand("SELECT p.Task_ID, t.Task_Description FROM tbl_PCPDetail p INNER JOIN tbl_TaskDetail t ON p.Task_ID = t.Task_ID AND p.PC_ProcessCode = t.PC_ProcessCode WHERE p.PCP_ID = '" + mPCPCode + "' AND p.PCP_Status != '3' AND p.PCP_Status != '1' GROUP BY p.Task_ID, t.Task_Description", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uTaskCode.Add(row[0].ToString() + " - " + row[1].ToString());

            }
            return uTaskCode;

        }
        public List<String> GetTaskCodeByFileAndStatusNotDoneOrHold(String mProject, String mShipment,  String mFile) //Get task codes by PCP Code where not Done status
        {

            List<String> uTaskCode = new List<string>();

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT p.Task_ID, t.Task_Description FROM tbl_PCPDetail p INNER JOIN tbl_TaskDetail t ON p.Task_ID = t.Task_ID INNER JOIN tbl_PCPHeader ph ON ph.PCP_ID = p.PCP_ID WHERE p.PCP_Project = '"+ mProject +"' AND ph.PCP_Shipment = '"+ mShipment +"' AND p.PCP_File = '"+ mFile +"' AND p.PCP_Status != '3' AND p.PCP_Status != '1'", this.mConnectionUser);

            //da.SelectCommand = new SqlCommand("SELECT Task_ID FROM tbl_PCPDetail WHERE PCP_ID='"+ mPCPCode + "' AND PCP_Status!='3' AND PCP_Status!='1' GROUP BY Task_ID", this.mConnectionUser);
            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uTaskCode.Add(row[0].ToString() + " - " + row[1].ToString());

            }
            return uTaskCode;

        }


        public bool GetPCPCodeByShipmentAndFileName(String mShipment, String mFileName, String mProcessCode) //Get Shipment Name by PCP Code
        {
            //insert databse values
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.Connection = this.mConnectionUser;
            SelectCommand.CommandType = CommandType.Text;

            SelectCommand.CommandText = "SELECT h.PCP_ID, th.PC_ProcessCode FROM tbl_PCPDetail d INNER JOIN tbl_PCPHeader h ON d.PCP_ID = h.PCP_ID INNER JOIN tbl_TaskHeader th ON th.Task_ID = d.Task_ID AND d.PC_ProcessCode = th.PC_ProcessCode WHERE d.PCP_File = '" + mFileName + "' AND h.PCP_Shipment = '" + mShipment + "' AND d.PCP_Status != '1' AND th.PC_ProcessCode = '" + mProcessCode + "' GROUP BY h.PCP_ID, th.PC_ProcessCode";

            //da.SelectCommand = new SqlCommand("SELECT h.PCP_ID FROM tbl_PCPDetail d INNER JOIN tbl_PCPHeader h ON d.PCP_ID = h.PCP_ID WHERE d.PCP_File = '"+ mFileName + "' AND h.PCP_Shipment = '"+ mShipment + "' AND d.PCP_Status != '1' GROUP BY h.PCP_ID", this.mConnectionUser);

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

        public String GetPCPCodeByShipmentAndFileName_TaskInOut(String mShipment, String mFileName) //Get Shipment Name by PCP Code
        {

            String uShipment = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT h.PCP_ID FROM tbl_PCPDetail d INNER JOIN tbl_PCPHeader h ON d.PCP_ID = h.PCP_ID WHERE d.PCP_File = '"+ mFileName + "' AND h.PCP_Shipment = '"+ mShipment + "' AND d.PCP_Status != '1' GROUP BY h.PCP_ID", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uShipment = row[0].ToString();
            }
            return uShipment;

        }

        public String GetFileNameByPCPCode_TaskInOut(String mPCPCode) //Get File Name by PCP Code
        {

            String uShipment = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT d.PCP_File FROM tbl_PCPDetail d INNER JOIN tbl_PCPHeader h ON d.PCP_ID = h.PCP_ID  WHERE d.PCP_ID = '"+ mPCPCode + "' AND d.PCP_Status != '1' GROUP BY d.PCP_File", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uShipment = row[0].ToString();
            }
            return uShipment;

        }

        public String GetShipmentByPCPCode_TaskInOut(String mPCPCode) //Get Shipment Name by PCP Code
        {

            String uShipment = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT h.PCP_Shipment FROM tbl_PCPDetail d INNER JOIN tbl_PCPHeader h ON d.PCP_ID = h.PCP_ID  WHERE d.PCP_ID = '"+ mPCPCode + "' AND d.PCP_Status != '1' GROUP BY h.PCP_Shipment", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uShipment = row[0].ToString();
            }
            return uShipment;

        }

        public String GetProjectByPCPCode_TaskInOut(String mPCPCode) //Get Project Name by PCP Code
        {

            String uShipment = "";

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT d.PCP_Project FROM tbl_PCPDetail d INNER JOIN tbl_PCPHeader h ON d.PCP_ID = h.PCP_ID  WHERE d.PCP_ID = '"+ mPCPCode + "' AND d.PCP_Status != '1' GROUP BY  d.PCP_Project", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                uShipment = row[0].ToString();
            }
            return uShipment;

        }

        public int GetFileSizeByPCPIndex(string mPCPIndex)
        {
            int uActualFileSize = 0;

            //Data adapter with select command

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = new SqlCommand("SELECT PCP_FileSize FROM tbl_PCPDetail WHERE PCPD_Index = '" + mPCPIndex + "'", this.mConnectionUser);

            DataTable table = new DataTable();
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == "")
                {
                    uActualFileSize = 0;
                }
                else
                {
                    uActualFileSize = int.Parse(row[0].ToString());
                }

            }
            return uActualFileSize;

        }
    }
}
