using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class ProcessCodeHeader
    {
        //PIC_Project       varchar(50)     Unchecked
        //PC_ProcessCode    varchar(100)    Unchecked
        //PIC_UID	        varchar(50)	    Unchecked

        private string mPIC_Project;
        private string mPC_ProcessCode;
        private string mPIC_UID;

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
        public String PIC_UID
        {
            set
            {
                mPIC_UID = value;
            }
            get
            {
                return mPIC_UID;
            }
        }

    }
}
