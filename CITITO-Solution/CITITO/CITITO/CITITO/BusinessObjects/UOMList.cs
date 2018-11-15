using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITITO.BusinessObjects
{
    class UOMList
    {
        //UOM_Index	int	            Unchecked
        //UOM_Unit  varchar(100)    Unchecked

        private int mUOM_Index;
        private string mUOM_Unit;

        public int UOM_Index
        {
            set
            {
                mUOM_Index = value;
            }
            get
            {
                return mUOM_Index;
            }
        }
        public String UOM_Unit
        {
            set
            {
                mUOM_Unit = value;
            }
            get
            {
                return mUOM_Unit;
            }
        }
    }
}
