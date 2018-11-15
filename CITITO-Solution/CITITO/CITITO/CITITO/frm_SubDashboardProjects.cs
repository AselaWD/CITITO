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
    public partial class frm_SubDashboardProjects : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_SubDashboardProjects _instance;
        public static frm_SubDashboardProjects GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_SubDashboardProjects(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_SubDashboardProjects(string uMUID, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

            lblUIDToFill.Text = uMUID;
            lblPICToFill.Text = uPIC;
            //lblPICToFill.Text = "ZDQ"; /*ZDQ, 16V, EC4, AV1, LR3, TL6, 36W, 23S*/

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            DateTime uFrom = startDate;
            DateTime uTo = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        private void frm_SubDashboardProjects_Load(object sender, EventArgs e)
        {

        }

        private void btnClrAll_Click(object sender, EventArgs e)
        {

        }
    }
}
