using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class CITITOVersion
    {
        //Version varchar(1000)   Unchecked
        //LastModifiedDate    datetime Unchecked
        //Developer varchar(1000)   Unchecked

        private string mVersion;
        private DateTime mLastModifiedDate;
        private string mDeveloper;

        public String Version
        {
            set
            {
                mVersion = value;
            }
            get
            {
                return mVersion;
            }
        }

        public DateTime LastModifiedDate
        {
            set
            {
                mLastModifiedDate = value;
            }
            get
            {
                return mLastModifiedDate;
            }
        }

        public String Developer
        {
            set
            {
                mDeveloper = value;
            }
            get
            {
                return mDeveloper;
            }
        }
    }
}
