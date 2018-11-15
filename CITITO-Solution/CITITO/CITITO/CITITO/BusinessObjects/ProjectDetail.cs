using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class ProjectDetail
    {
        //Project_Index	        bigint	        Unchecked
        //ProjectName           varchar(50)     Unchecked
        //PIC_UID               varchar(50)     Unchecked
        //SkipOutputValidation	int	            Checked     /* 0 - No , 1 - Yes */

        private int mProject_Index;
        private string mProjectName;
        private string mPIC_UID;
        private int mSkipOutputValidation;

        public int Project_Index
        {
            set
            {
                mProject_Index = value;
            }
            get
            {
                return mProject_Index;
            }
        }

        public String ProjectName
        {
            set
            {
                mProjectName = value;
            }
            get
            {
                return mProjectName;
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
