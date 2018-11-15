using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class ResourceCode
    {
        //RESOURCECLASS	    varchar (4)	    Unchecked
        //DESCRIPTION       varchar (50)    Checked
        //DAILYMINRATE      decimal (18, 2)	Checked
        //DAILYMAXRATE      decimal (18, 2)	Checked

        private string mResourceClass;
        private string mDescription;
        private decimal mDailyMinrate;
        private decimal mDailyMaxrate;

        public String ResourceClass
        {
            set
            {
                mResourceClass = value;
            }
            get
            {
                return mResourceClass;
            }
        }

        public String Description
        {
            set
            {
                mDescription = value;
            }
            get
            {
                return mDescription;
            }
        }

        public Decimal DailyMinrate
        {
            set
            {
                mDailyMinrate = value;
            }
            get
            {
                return mDailyMinrate;
            }
        }

        public Decimal DailyMaxrate
        {
            set
            {
                mDailyMaxrate = value;
            }
            get
            {
                return mDailyMaxrate;
            }
        }
    }
}
