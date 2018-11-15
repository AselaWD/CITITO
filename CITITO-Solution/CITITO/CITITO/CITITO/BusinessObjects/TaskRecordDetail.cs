using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class TaskRecordDetail
    {
        //TR_Index        bigint            Unchecked
        //TR_ID           varchar(50)       Unchecked
        //PCP_ID          varchar(50)       Unchecked
        //TR_Status       int               Unchecked
        //TR_InDate       datetime          Unchecked
        //TR_OutDate      datetime          Unchecked
        //TR_TaskStatus   int               Unchecked
        //TR_Shipment     varchar(1000)     Unchecked
        //TR_File         varchar(500)      Unchecked
        //TR_FileSize     bigint            Unchecked
        //TR_UOM          varchar(100)      Unchecked
        //TR_Quota        bigint            Unchecked
        //TR_UID          varchar(50)       Unchecked
        //TR_MID          varchar(50)       Unchecked
        //TR_PIC          varchar(50)       Unchecked
        //TR_Apporval     int               Unchecked
        //TR_ApprovalTime datetime          Unchecked
        //TR_Hours        float             Unchecked
        //TR_Productivity float             Unchecked
        //Task_ID         varchar(50)       Unchecked
        //TR_ActualTaskIn datetime          Checked

        private int mTR_Index;
        private string mTR_ID;
        private string mPCP_ID;
        private int mTR_Status;
        private DateTime mTR_InDate;
        private DateTime mTR_OutDate;
        private int mTR_TaskStatus;
        private string mTR_Shipment;
        private string mTR_File;
        private int mTR_FileSize;
        private string mTR_UOM;
        private int mTR_Quota;
        private string mTR_UID;
        private string mTR_MID;
        private string mTR_PIC;
        private int mTR_Apporval;
        private DateTime mTR_ApprovalTime;
        private float mTR_Hours;
        private float mTR_Productivity;
        private string mTask_ID;
        private DateTime mTR_ActualTaskIn;

        public int TR_Index
        {
            set
            {
                mTR_Index = value;
            }
            get
            {
                return mTR_Index;
            }
        }
        public string TR_ID
        {
            set
            {
                mTR_ID = value;
            }
            get
            {
                return mTR_ID;
            }
        }
        public string PCP_ID
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
        public int TR_Status
        {
            set
            {
                mTR_Status = value;
            }
            get
            {
                return mTR_Status;
            }
        }
        public DateTime TR_InDate
        {
            set
            {
                mTR_InDate = value;
            }
            get
            {
                return mTR_InDate;
            }
        }
        public DateTime TR_OutDate
        {
            set
            {
                mTR_OutDate = value;
            }
            get
            {
                return mTR_OutDate;
            }
        }
        public int TR_TaskStatus
        {
            set
            {
                mTR_TaskStatus = value;
            }
            get
            {
                return mTR_TaskStatus;
            }
        }
        public string TR_Shipment
        {
            set
            {
                mTR_Shipment = value;
            }
            get
            {
                return mTR_Shipment;
            }
        }
        public string TR_File
        {
            set
            {
                mTR_File = value;
            }
            get
            {
                return mTR_File;
            }
        }
        public int TR_FileSize
        {
            set
            {
                mTR_FileSize = value;
            }
            get
            {
                return mTR_FileSize;
            }
        }
        public string TR_UOM
        {
            set
            {
                mTR_UOM = value;
            }
            get
            {
                return mTR_UOM;
            }
        }
        public int TR_Quota
        {
            set
            {
                mTR_Quota = value;
            }
            get
            {
                return mTR_Quota;
            }
        }
        public string TR_UID
        {
            set
            {
                mTR_UID = value;
            }
            get
            {
                return mTR_UID;
            }
        }
        public string TR_MID
        {
            set
            {
                mTR_MID = value;
            }
            get
            {
                return mTR_MID;
            }
        }
        public string TR_PIC
        {
            set
            {
                mTR_PIC = value;
            }
            get
            {
                return mTR_PIC;
            }
        }
        public int TR_Apporval
        {
            set
            {
                mTR_Apporval = value;
            }
            get
            {
                return mTR_Apporval;
            }
        }
        public DateTime TR_ApprovalTime
        {
            set
            {
                mTR_ApprovalTime = value;
            }
            get
            {
                return mTR_ApprovalTime;
            }
        }
        public float TR_Hours
        {
            set
            {
                mTR_Hours = value;
            }
            get
            {
                return mTR_Hours;
            }
        }
        public float TR_Productivity
        {
            set
            {
                mTR_Productivity = value;
            }
            get
            {
                return mTR_Productivity;
            }
        }
        public string Task_ID
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
        public DateTime TR_ActualTaskIn
        {
            set
            {
                mTR_ActualTaskIn = value;
            }
            get
            {
                return mTR_ActualTaskIn;
            }
        }
    }
}
