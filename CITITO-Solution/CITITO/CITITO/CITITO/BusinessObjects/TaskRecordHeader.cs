using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class TaskRecordHeader
    {
        //TR_Index  bigint       Unchecked
        //TR_ID     varchar(50)  Unchecked
        //PCP_ID    varchar(50)  Unchecked
        //TR_UID    varchar(50)  Unchecked
        //TR_MID    varchar(50)  Unchecked
        //TR_PIC    varchar(50)  Unchecked

        private int mTR_Index;
        private string mTR_ID;
        private string mPCP_ID;
        private string mTR_UID;
        private string mTR_MID;
        private string mTR_PIC;
        
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
    }
}
