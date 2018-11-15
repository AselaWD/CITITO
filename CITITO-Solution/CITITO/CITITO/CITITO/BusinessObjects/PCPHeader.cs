using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    //PCP_Index       bigint          Unchecked
    //PCP_ID          varchar(50)     Unchecked
    //PC_ProcessCode  varchar(100)    Unchecked
    //Task_ID         varchar(50)     Unchecked
    //PCP_Shipment    varchar(1000)   Unchecked

    class PCPHeader
    {
        private int mPCP_Index;
        private string mPCP_ID;
        private string mPC_ProcessCode;
       // private string mTask_ID;
        private string mPCP_Shipment;

        public int PCP_Index
        {
            set
            {
                mPCP_Index = value;
            }
            get
            {
                return mPCP_Index;
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
        //public String Task_ID
        //{
        //    set
        //    {
        //        mTask_ID = value;
        //    }
        //    get
        //    {
        //        return mTask_ID;
        //    }
        //}
        public String PCP_Shipment
        {
            set
            {
                mPCP_Shipment = value;
            }
            get
            {
                return mPCP_Shipment;
            }
        }
    }
}
