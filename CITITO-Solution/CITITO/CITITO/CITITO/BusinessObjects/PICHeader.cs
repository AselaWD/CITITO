using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class PICHeader
    {
        //PIC_UID           varchar(50) Unchecked
        //PIC_AccessLevel   varchar(50) Checked

        private string mPIC_UID;
        private string mPIC_AccessLevel;

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
        public string PIC_AccessLevel
        {
            set
            {
                mPIC_AccessLevel = value;
            }
            get
            {
                return mPIC_AccessLevel;
            }
        }
    }
}
