using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class ManagerHeader
    {
        //M_UID                 varchar(50)     Unchecked
        //M_Name                varchar(200)    Unchecked
        //M_Password            varchar(1000)   Unchecked
        //M_AccessLevel         varchar(50)     Unchecked
        //M_Availability        int             Unchecked
        //M_Activate_Date       datetime        Checked
        //M_Inactivate_Date     datetime        Checked

        private string mM_UID;
        private string mM_Name;
        private string mM_Password;
        private string mM_AccessLevel;
        private int mM_Availability;
        private DateTime mM_Activate_Date;
        private DateTime mM_Inactivate_Date;



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
        public String M_Name
        {
            set
            {
                mM_Name = value;
            }
            get
            {
                return mM_Name;
            }
        }
        public String M_Password
        {
            set
            {
                mM_Password = value;
            }
            get
            {
                return mM_Password;
            }
        }
        public String M_AccessLevel
        {
            set
            {
                mM_AccessLevel = value;
            }
            get
            {
                return mM_AccessLevel;
            }
        }        
        public int M_Availability
        {
            set
            {
                mM_Availability = value;
            }
            get
            {
                return mM_Availability;
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
    }
}
