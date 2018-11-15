using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class TaskHeader
    {
        //Task_ID               varchar(50)     Unchecked
        //PC_ProcessCode        varchar(100)    Unchecked
        //PIC_Project           varchar(50)     Unchecked
        //TR_Index              bigint          Unchecked
        //SkipOutputValidation  nchar(10)       Checked /* 0 - No, 1 - Yes */


        private string mTask_ID;
        private string mPC_ProcessCode;
        private string mPIC_Project;
        private int mTR_Index;
        private int mSkipOutputValidation;

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
        public int SkipOutputValidation
        {
            set
            {
                mSkipOutputValidation = value;
            }
            get
            {
                return mSkipOutputValidation;
            }
        }
    }
}
