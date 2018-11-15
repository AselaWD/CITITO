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
    public partial class frm_ModifyFileSize : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_ModifyFileSize _instance;
        public static frm_ModifyFileSize GetInstance(string uPCPIndex)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mPCPIndex = uPCPIndex;

                _instance = new frm_ModifyFileSize(mPCPIndex);

            }
            return _instance;

        }

        public frm_ModifyFileSize(string uPCPIndex)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            //Get Data
            lblPCPIndex.Text = uPCPIndex;

            int mFileSize = new PCPDetailMng(this.conn).GetFileSizeByPCPIndex(lblPCPIndex.Text);          
            numericUpDownFileSize.Value = mFileSize;

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            int mIndex = int.Parse(lblPCPIndex.Text);
            int mMFileSize = int.Parse(numericUpDownFileSize.Value.ToString());

            DialogResult results = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to modify file size.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (results == DialogResult.Yes)
            {
                if (new PCPDetailMng(this.conn).UpdatePCPDetailFileSizeByIndex(mIndex, mMFileSize)>0)
                {
                    //Show Completed Message
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been modified!", "Record Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
   
        }

        private void frm_ModifyFileSize_Load(object sender, EventArgs e)
        {
            
        }

        private void frm_ModifyFileSize_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["frm_DCD"].BringToFront();
            //this.Close();
        }
    }
}
