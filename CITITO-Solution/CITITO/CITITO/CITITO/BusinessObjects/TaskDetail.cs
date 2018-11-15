using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class TaskDetail
    {
        //Task_ID               varchar(50)     Unchecked
        //Task_Description      varchar(500)    Checked
        //Task_UOM              varchar(100)    Checked
        //Task_Quota            bigint          Unchecked
        //PC_ProcessCode        varchar(100)    Unchecked
        //PIC_Project           varchar(50)     Unchecked
        //TR_Index              bigint          Unchecked

        private string mTask_ID;
        private string mTask_Description;
        private string mTask_UOM;
        private int mTask_Quota;
        private string mPC_ProcessCode;
        private string mPIC_Project;
        private int mTR_Index;


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
        public String Task_Description
        {
            set
            {
                mTask_Description = value;
            }
            get
            {
                return mTask_Description;
            }
        }
        public String Task_UOM
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
        public String PIC_Project
        {
            set
            {
                mPIC_Project = value;
            }
            get
            {
                return mPIC_Project;
            }
        }
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
    }
}
