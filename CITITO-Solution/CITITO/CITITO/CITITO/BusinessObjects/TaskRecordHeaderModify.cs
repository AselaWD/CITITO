using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class TaskRecordHeaderModify
    {
        //TRMH_Index	bigint	    Unchecked
        //TR_ID         varchar(50) Unchecked
        //PCP_ID        varchar(50) Unchecked
        //TRM_ID        varchar(50) Unchecked

        private int mTRMH_Index;
        private string mTR_ID;
        private string mPCP_ID;
        private string mTRM_ID;

        public int TRMH_Index
        {
            set
            {
                mTRMH_Index = value;
            }
            get
            {
                return mTRMH_Index;
            }
        }

        public String TR_ID
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

        public String TRM_ID
        {
            set
            {
                mTRM_ID = value;
            }
            get
            {
                return mTRM_ID;
            }
        }

    }
}
