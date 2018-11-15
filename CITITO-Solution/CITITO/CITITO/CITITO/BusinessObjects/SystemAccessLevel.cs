using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class SystemAccessLevel
    {
        //SysAccessLevel          varchar(50)     Unchecked
        //SysAccessDescription    varchar(500)    Checked

        private string mSysAccessLevel;
        private string mSysAccessDescription;

        public String SysAccessLevel
        {
            set
            {
                mSysAccessLevel = value;
            }
            get
            {
                return mSysAccessLevel;
            }
        }
        public String SysAccessDescription
        {
            set
            {
                mSysAccessDescription = value;
            }
            get
            {
                return mSysAccessDescription;
            }
        }
    }
}
