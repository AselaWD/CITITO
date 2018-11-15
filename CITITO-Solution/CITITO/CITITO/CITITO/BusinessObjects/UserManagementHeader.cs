using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class UserManagementHeader
    {
        //P_UID                 varchar(50)     Unchecked
        //P_Name                varchar(200)    Unchecked
        //P_Password            varchar(1000)   Unchecked
        //P_AccessLevel         varchar(50)     Unchecked
        //P_Availability        int             Unchecked
        //P_Activate_Date       datetime        Unchecked
        //P_Inactivate_Date     datetime        Checked
        //P_Shift	            varchar(100)	Checked
        //PTR_Resources	        varchar(50)	    Checked

        private string mP_UID;
        private string mP_Name;
        private string mP_Password;
        private string mP_AccessLevel;
        private int mP_Availability;
        private DateTime mP_Activate_Date;
        private DateTime mP_Inactivate_Date;
        private string mP_Shift;
        private string mPTR_Resources;

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
        public String P_Name
        {
            set
            {
                mP_Name = value;
            }
            get
            {
                return mP_Name;
            }
        }
        public String P_Password
        {
            set
            {
                mP_Password = value;
            }
            get
            {
                return mP_Password;
            }
        }
        public String P_AccessLevel
        {
            set
            {
                mP_AccessLevel = value;
            }
            get
            {
                return mP_AccessLevel;
            }
        }
        public int P_Availability
        {
            set
            {
                mP_Availability = value;
            }
            get
            {
                return mP_Availability;
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

        public String P_Shift
        {
            set
            {
                mP_Shift = value;
            }
            get
            {
                return mP_Shift;
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
    }
}
