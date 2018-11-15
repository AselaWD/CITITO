using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using ClosedXML.Excel;
using System.Windows.Forms;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;

namespace CITITO
{
    public partial class frm_ModifyPTRResourceCost : MetroForm
    {
        SqlConnection conn;
        string sPTRResourceID;

        //Start Pass insatance when form is already opend or not
        private static frm_ModifyPTRResourceCost _instance;
        public static frm_ModifyPTRResourceCost GetInstance(string uPTRResourceID)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mPTRResourceID = uPTRResourceID;

                _instance = new frm_ModifyPTRResourceCost(mPTRResourceID);

            }
            return _instance;

        }

        public frm_ModifyPTRResourceCost(string uPTRResourceID)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            //Initialize Data
            sPTRResourceID = uPTRResourceID;
        }
    }
}
