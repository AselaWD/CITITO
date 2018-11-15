using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class PICDetail
    {
        //PIC_UID       varchar(50)     Unchecked
        //PIC_Name      varchar(200)    Unchecked
        //PIC_Password	varchar(1000)	Unchecked

        private string mPIC_UID;
        private string mPIC_Name;
        private string mPIC_Password;

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
        public String PIC_Name
        {
            set
            {
                mPIC_Name = value;
            }
            get
            {
                return mPIC_Name;
            }
        }
        public String PIC_Password
        {
            set
            {
                mPIC_Password = value;
            }
            get
            {
                return mPIC_Password;
            }
        }

    }
}
