using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class IDLEDetail
    {
        //IDLE_Index            bigint          Unchecked
        //IDLE_ID               varchar(50)     Unchecked
        //IDLE_InDate           datetime        Unchecked
        //IDLE_OutDate          datetime        Checked
        //IDLE_Reason           varchar(800)    Unchecked
        //IDLE_UID              varchar(50)     Unchecked
        //IDLE_MID              varchar(50)     Unchecked
        //IDLE_PIC              varchar(50)     Unchecked
        //IDLE_Apporval         int             Unchecked /*1 - Pending, 2 - Approved, 3 - Disapproved*/
        //IDLE_ApprovalTime     datetime        Checked
        //IDLE_Hours            float           Checked
        //IDLE_LogCreateTime    datetime        Unchecked
        //IDLE_Remark           varchar(800)    Checked

        private int mIDLE_Index;
        private string mIDLE_ID;
        private DateTime mIDLE_InDate;
        private DateTime mIDLE_OutDate;
        private string mIDLE_Reason;
        private string mIDLE_UID;
        private string mIDLE_MID;
        private string mIDLE_PIC;
        private int mIDLE_Apporval;
        private DateTime mIDLE_ApprovalTime;
        private float mIDLE_Hours;
        private DateTime mIDLE_LogCreateTime;
        private string mIDLE_Remark;


        public int IDLE_Index
        {
            set
            {
                mIDLE_Index = value;
            }
            get
            {
                return mIDLE_Index;
            }
        }
        public String IDLE_ID
        {
            set
            {
                mIDLE_ID = value;
            }
            get
            {
                return mIDLE_ID;
            }
        }
        public DateTime IDLE_InDate
        {
            set
            {
                mIDLE_InDate = value;
            }
            get
            {
                return mIDLE_InDate;
            }
        }
        public DateTime IDLE_OutDate
        {
            set
            {
                mIDLE_OutDate = value;
            }
            get
            {
                return mIDLE_OutDate;
            }
        }
        public String IDLE_Reason
        {
            set
            {
                mIDLE_Reason = value;
            }
            get
            {
                return mIDLE_Reason;
            }
        }
        public String IDLE_UID
        {
            set
            {
                mIDLE_UID = value;
            }
            get
            {
                return mIDLE_UID;
            }
        }
        public String IDLE_MID
        {
            set
            {
                mIDLE_MID = value;
            }
            get
            {
                return mIDLE_MID;
            }
        }
        public String IDLE_PIC
        {
            set
            {
                mIDLE_PIC = value;
            }
            get
            {
                return mIDLE_PIC;
            }
        }
        public int IDLE_Apporval
        {
            set
            {
                mIDLE_Apporval = value;
            }
            get
            {
                return mIDLE_Apporval;
            }
        }
        public DateTime IDLE_ApprovalTime
        {
            set
            {
                mIDLE_ApprovalTime = value;
            }
            get
            {
                return mIDLE_ApprovalTime;
            }
        }
        public float IDLE_Hours
        {
            set
            {
                mIDLE_Hours = value;
            }
            get
            {
                return mIDLE_Hours;
            }
        }
        public DateTime IDLE_LogCreateTime
        {
            set
            {
                mIDLE_LogCreateTime = value;
            }
            get
            {
                return mIDLE_LogCreateTime;
            }
        }
        public String IDLE_Remark
        {
            set
            {
                mIDLE_Remark = value;
            }
            get
            {
                return mIDLE_Remark;
            }
        }
    }
}
