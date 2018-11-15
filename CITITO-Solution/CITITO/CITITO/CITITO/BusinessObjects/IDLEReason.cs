using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class IDLEReason
    {

        //IDLE_ID       int             Unchecked
        //IDLE_Reason   varchar(1000)   Checked

        private int mIDLE_ID;
        private string mIDLE_Reason;

        public int IDLE_ID
        {
            set
            {
                mIDLE_ID = value;
            }
            get
            {
                return mIDLE_ID;
            }
        }
        public String IDLE_Reason
        {
            set
            {
                mIDLE_Reason = value;
            }
            get
            {
                return mIDLE_Reason;
            }
        }

    }
}
