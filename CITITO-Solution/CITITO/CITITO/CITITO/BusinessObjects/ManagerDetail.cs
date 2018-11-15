using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class ManagerDetail
    {
        //M_UID                     varchar(50) Unchecked
        //M_Project                 varchar(50) Unchecked
        //M_Project_Availability	varchar(50)	Unchecked
        //M_Activate_Date	        datetime	Unchecked
        //M_Inactivate_Date	        datetime	Checked
        //PIC_UID                   varchar(50) Unchecked

        private string mM_UID;
        private string mM_Project;
        private string mM_Project_Availability;
        private DateTime mM_Activate_Date;
        private DateTime mM_Inactivate_Date;
        private string mPIC_UID;

        public String M_UID
        {
            set
            {
                mM_UID = value;
            }
            get
            {
                return mM_UID;
            }
        }
        public String M_Project
        {
            set
            {
                mM_Project = value;
            }
            get
            {
                return mM_Project;
            }
        }
        public String M_Project_Availability
        {
            set
            {
                mM_Project_Availability = value;
            }
            get
            {
                return mM_Project_Availability;
            }
        }
        public DateTime M_Activate_Date
        {
            set
            {
                mM_Activate_Date = value;
            }
            get
            {
                return mM_Activate_Date;
            }
        }
        public DateTime M_Inactivate_Date
        {
            set
            {
                mM_Inactivate_Date = value;
            }
            get
            {
                return mM_Inactivate_Date;
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
