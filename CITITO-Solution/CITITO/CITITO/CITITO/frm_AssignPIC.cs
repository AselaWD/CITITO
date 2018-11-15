using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;

namespace CITITO
{
    public partial class frm_AssignPIC : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_AssignPIC _instance;
        public static frm_AssignPIC GetInstance(string uID, string uPICName, string uPassword)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUserID = uID;
                String mPICName = uPICName;
                String mPassword = uPassword;

                _instance = new frm_AssignPIC(mUserID, mPICName, mPassword);

            }
            return _instance;

        }

        public frm_AssignPIC(string uID, string uPICName, string uPassword)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblManagerUID.Text = uID;
            lblName.Text = uPICName;
            lblPass.Text = uPassword;
        }

        private void frm_AssignPIC_Load(object sender, EventArgs e)
        {
            txtCurrentOIC.Text = lblManagerUID.Text;
            cmbAssignPIC.DataSource = new PICHeaderMng(this.conn).GetPICListExceptSentUID(lblManagerUID.Text.ToUpper());
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            String OldPIC = txtCurrentOIC.Text;
            String NewPIC = cmbAssignPIC.Text;

            PICHeader mPICHeader = new PICHeader();

            mPICHeader.PIC_UID = OldPIC;

            PICHeaderMng mPICHeaderMng = new PICHeaderMng(this.conn);

            if (new ProjectDetailMng(this.conn).UpdateProjectPIC(OldPIC, NewPIC) >0)
            {
                if (mPICHeaderMng.DeletePICHeader(mPICHeader)>0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nNew PIC " + NewPIC + " has been assigned with PIC \""+ OldPIC + "\"", "PIC Assigned!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.OpenForms["frm_PICRegisterPanel"].BringToFront();

                    this.Close();
                }

                
            }
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            PICDetail mPICDetail = new PICDetail();
            PICDetailMng mPICDetailMng = new PICDetailMng(this.conn);

            mPICDetail.PIC_UID = lblManagerUID.Text;
            mPICDetail.PIC_Name = lblName.Text;
            mPICDetail.PIC_Password = lblPass.Text;
        
            mPICDetailMng.AddPICDetail(mPICDetail);

            Application.OpenForms["frm_PICRegisterPanel"].BringToFront();
            this.Close();
        }
              
    }
}
