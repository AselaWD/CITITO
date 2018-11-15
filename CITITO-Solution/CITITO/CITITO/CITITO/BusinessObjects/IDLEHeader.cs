using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class IDLEHeader
    {
        //IDLE_Index    bigint      Unchecked
        //IDLE_ID       varchar(50) Unchecked    
        //IDLE_Project	varchar(50)	Unchecked
        //IDLE_UID      varchar(50) Unchecked
        //IDLE_MID      varchar(50) Unchecked
        //IDLE_PIC      varchar(50) Unchecked

        private int mIDLE_Index;
        private string mIDLE_ID;
        private string mIDLE_Project;
        private string mIDLE_UID;
        private string mIDLE_MID;
        private string mIDLE_PIC;

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
        public String IDLE_Project
        {
            set
            {
                mIDLE_Project = value;
            }
            get
            {
                return mIDLE_Project;
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
    }
}
