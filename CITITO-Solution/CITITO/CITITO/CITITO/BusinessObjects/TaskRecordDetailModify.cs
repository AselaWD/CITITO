using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class TaskRecordDetailModify
    {
        //TRM_Index             bigint          Unchecked
        //TRM_ID                varchar(50)     Unchecked
        //TR_FileSize           bigint          Checked
        //TR_File               varchar(500)    Unchecked
        //TRM_ModifiedlTime     datetime        Unchecked
        //TRM_ApprovalTime      datetime        Checked
        //TRM_Apporval          int             Unchecked /* 1 - Pending, 2 - Approved, 3 - Disapproved */
        //TR_UID	            varchar(50)	    Unchecked
        //TRM_PIC               varchar(50)     Unchecked
        //TRM_MID	            varchar(50)	    Unchecked
        //TRM_Hours	            float	        Checked
        //TRM_Productivity      float           Checked
        //TRM_OutDate           datetime        Checked
        //TRM_InDate            datetime        Unchecked
        //TR_Status             int             Checked
        //TR_UOM	            varchar(100)	Unchecked


        private int mTRM_Index;
        private string mTRM_ID;
        private int mTR_FileSize;
        private string mTR_File;
        private DateTime mTRM_ModifiedlTime;
        private DateTime mTRM_ApprovalTime;
        private int mTRM_Apporval;
        private string mTR_UID;
        private string mTRM_PIC;
        private string mTRM_MID;
        private float mTRM_Hours;
        private float mTRM_Productivity;
        private DateTime mTRM_OutDate;
        private DateTime mTRM_InDate;
        private int mTR_Status;
        private string mTR_UOM;


        public int TRM_Index
        {
            set
            {
                mTRM_Index = value;
            }
            get
            {
                return mTRM_Index;
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
        public String TR_File
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

        public DateTime TRM_ModifiedlTime
        {
            set
            {
                mTRM_ModifiedlTime = value;
            }
            get
            {
                return mTRM_ModifiedlTime;
            }
        }

        public DateTime TRM_ApprovalTime
        {
            set
            {
                mTRM_ApprovalTime = value;
            }
            get
            {
                return mTRM_ApprovalTime;
            }
        }

        public int TRM_Apporval
        {
            set
            {
                mTRM_Apporval = value;
            }
            get
            {
                return mTRM_Apporval;
            }
        }

        public String TR_UID
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

        public String TRM_PIC
        {
            set
            {
                mTRM_PIC = value;
            }
            get
            {
                return mTRM_PIC;
            }
        }

        public String TRM_MID
        {
            set
            {
                mTRM_MID = value;
            }
            get
            {
                return mTRM_MID;
            }
        }

        public float TRM_Hours
        {
            set
            {
                mTRM_Hours = value;
            }
            get
            {
                return mTRM_Hours;
            }
        }

        public float TRM_Productivity
        {
            set
            {
                mTRM_Productivity = value;
            }
            get
            {
                return mTRM_Productivity;
            }
        }

        public DateTime TRM_OutDate
        {
            set
            {
                mTRM_OutDate = value;
            }
            get
            {
                return mTRM_OutDate;
            }
        }

        public DateTime TRM_InDate
        {
            set
            {
                mTRM_InDate = value;
            }
            get
            {
                return mTRM_InDate;
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

    }
}
