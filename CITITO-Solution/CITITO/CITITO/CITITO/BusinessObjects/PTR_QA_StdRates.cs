using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class PTR_QA_StdRates
    {
        //PTR_Index	            bigint	Unchecked
        //PTR_Resources         varchar(50) Unchecked
        //PTR_Location          varchar(50) Unchecked
        //PTR_DC                varchar(50) Unchecked
        //PTR_DepartmentName    varchar(1000)   Unchecked
        //PTR_Min               float Unchecked
        //PTR_Max               float Unchecked
        //PTR_HC                float Unchecked
        //PTR_RT01              float Checked
        //PTR_OT01              float Checked
        //PTR_SP01              float Checked

        private int mPTR_Index;
        private string mPTR_Resources;
        private string mPTR_Location;
        private string mPTR_DC;
        private string mPTR_DepartmentName;
        private float mPTR_Min;
        private float mPTR_Max;
        private float mPTR_HC;
        private float mPTR_RT01;
        private float mPTR_OT01;
        private float mPTR_SP01;

        public int PTR_Index
        {
            set
            {
                mPTR_Index = value;
            }
            get
            {
                return mPTR_Index;
            }
        }

        public String PTR_Resources
        {
            set
            {
                mPTR_Resources = value;
            }
            get
            {
                return mPTR_Resources;
            }
        }

        public String PTR_Location
        {
            set
            {
                mPTR_Location = value;
            }
            get
            {
                return mPTR_Location;
            }
        }

        public String PTR_DC
        {
            set
            {
                mPTR_DC = value;
            }
            get
            {
                return mPTR_DC;
            }
        }

        public String PTR_DepartmentName
        {
            set
            {
                mPTR_DepartmentName = value;
            }
            get
            {
                return mPTR_DepartmentName;
            }
        }

        public float PTR_Min
        {
            set
            {
                mPTR_Min = value;
            }
            get
            {
                return mPTR_Min;
            }
        }

        public float PTR_Max
        {
            set
            {
                mPTR_Max = value;
            }
            get
            {
                return mPTR_Max;
            }
        }

        public float PTR_HC
        {
            set
            {
                mPTR_HC = value;
            }
            get
            {
                return mPTR_HC;
            }
        }

        public float PTR_RT01
        {
            set
            {
                mPTR_RT01 = value;
            }
            get
            {
                return mPTR_RT01;
            }
        }

        public float PTR_OT01
        {
            set
            {
                mPTR_OT01 = value;
            }
            get
            {
                return mPTR_OT01;
            }
        }

        public float PTR_SP01
        {
            set
            {
                mPTR_SP01 = value;
            }
            get
            {
                return mPTR_SP01;
            }
        }
    }
}
