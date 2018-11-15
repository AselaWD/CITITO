using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class PCPDetail
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

        private int mPCPD_Index;
        private string mPCP_ID;
        private string mPCP_File;
        private int mPCP_FileSize;
        private int mPCP_Status; /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
        private string mPCP_Project;
        private string mTask_UOM;
        private int mTask_Quota;
        private DateTime mPCP_StartDate;
        private DateTime mPCP_EndDate;
        private string mPCP_CreatorUID;
        private string mTask_ID;
        private string mPC_ProcessCode;

        public int PCPD_Index
        {
            set
            {
                mPCPD_Index = value;
            }
            get
            {
                return mPCPD_Index;
            }
        }

        public String PCP_ID
        {
            set
            {
                mPCP_ID = value;
            }
            get
            {
                return mPCP_ID;
            }
        }
        public String PCP_File
        {
            set
            {
                mPCP_File = value;
            }
            get
            {
                return mPCP_File;
            }
        }
        public int PCP_FileSize
        {
            set
            {
                mPCP_FileSize = value;
            }
            get
            {
                return mPCP_FileSize;
            }
        }
        public int PCP_Status
        {
            set
            {
                mPCP_Status = value;
            }
            get
            {
                return mPCP_Status;
            }
        }
        public string PCP_Project
        {
            set
            {
                mPCP_Project = value;
            }
            get
            {
                return mPCP_Project;
            }
        }
        public string Task_UOM
        {
            set
            {
                mTask_UOM = value;
            }
            get
            {
                return mTask_UOM;
            }
        }
        public int Task_Quota
        {
            set
            {
                mTask_Quota = value;
            }
            get
            {
                return mTask_Quota;
            }
        }
        public DateTime PCP_StartDate
        {
            set
            {
                mPCP_StartDate = value;
            }
            get
            {
                return mPCP_StartDate;
            }
        }
        public DateTime PCP_EndDate
        {
            set
            {
                mPCP_EndDate = value;
            }
            get
            {
                return mPCP_EndDate;
            }
        }
        public String PCP_CreatorUID
        {
            set
            {
                mPCP_CreatorUID = value;
            }
            get
            {
                return mPCP_CreatorUID;
            }
        }
        public String Task_ID
        {
            set
            {
                mTask_ID = value;
            }
            get
            {
                return mTask_ID;
            }
        }
        public String PC_ProcessCode
        {
            set
            {
                mPC_ProcessCode = value;
            }
            get
            {
                return mPC_ProcessCode;
            }
        }
    }
}
