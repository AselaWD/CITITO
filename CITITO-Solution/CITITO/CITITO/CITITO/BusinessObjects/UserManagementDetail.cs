using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class UserManagementDetail
    {
        //P_UID                     varchar(50) Unchecked
        //P_Project                 varchar(50) Unchecked
        //P_Project_Availability    varchar(50) Unchecked
        //P_Activate_Date           datetime    Unchecked
        //P_Inactivate_Date         datetime    Checked
        //M_UID                     varchar(50) Unchecked
        //PIC_UID                   varchar(50) Unchecked

        private string mP_UID;
        private string mP_Project;
        private string mP_Project_Availability;
        private DateTime mP_Activate_Date;
        private DateTime mP_Inactivate_Date;
        private string mM_UID;
        private string mPIC_UID;

        public String P_UID
        {
            set
            {
                mP_UID = value;
            }
            get
            {
                return mP_UID;
            }
        }

        public String P_Project
        {
            set
            {
                mP_Project = value;
            }
            get
            {
                return mP_Project;
            }
        }
        public String P_Project_Availability
        {
            set
            {
                mP_Project_Availability = value;
            }
            get
            {
                return mP_Project_Availability;
            }
        }
        public DateTime P_Activate_Date
        {
            set
            {
                mP_Activate_Date = value;
            }
            get
            {
                return mP_Activate_Date;
            }
        }
        public DateTime P_Inactivate_Date
        {
            set
            {
                mP_Inactivate_Date = value;
            }
            get
            {
                return mP_Inactivate_Date;
            }
        }
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
