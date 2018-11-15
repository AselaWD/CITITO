using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;

namespace CITITO
{
    public partial class frm_TaskCodeModify : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_TaskCodeModify _instance;
        public static frm_TaskCodeModify GetInstance(String uTaskCode, String uDescription, String uUOM, String uQuota, String uProject, String uProcessCode, int uSkip)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mTaskCode = uTaskCode;
                String mDescription = uDescription;
                String mUOM = uUOM;
                String mQuota = uQuota;
                String mProject = uProject;
                String mProcessCode = uProcessCode;

                int mSkip = uSkip;

                _instance = new frm_TaskCodeModify(mTaskCode, mDescription, mUOM, mQuota, mProject, mProcessCode, mSkip);

            }
            return _instance;

        }

        public frm_TaskCodeModify(String uTaskCode, String uDescription, String uUOM, String uQuota, String uProject, String uProcessCode, int uSkip)
        {
            InitializeComponent();

            //Parameters Initialize
            txtTaskCode.Text = uTaskCode;
            txtDescription.Text = uDescription;
            cmbUOM.Text = uUOM;
            lbltmpProject.Text = uProject;
            lbltmpProcessCode.Text = uProcessCode;
            numericUpDownQuota.Value = int.Parse(uQuota);

            if (uSkip==1)
            {
                chkOutputValidation.Checked = true;
            }
            if (uSkip == 0)
            {
                chkOutputValidation.Checked = false;
            }

            tmpTask.Text = uTaskCode;
            tmpDes.Text = uDescription;
            tmpUOM.Text = uUOM;
            tmpQuota.Text = uQuota;
            lbltmpSkip.Text = uSkip.ToString();



            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {

            Application.OpenForms["frm_TaskCodeRegister"].BringToFront();
            this.Close();
        }

        //Modify
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescription.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nDescription field cannot be empty.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescription.Focus();
                return;
            }

            if (String.IsNullOrEmpty(cmbUOM.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPlease enter UOM.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbUOM.Focus();
                return;
            }
            if (numericUpDownQuota.Value==0)
            {
                MetroFramework.MetroMessageBox.Show(this, "\nQuota cannoth be zero.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDownQuota.Focus();
                return;
            }
            if (String.IsNullOrEmpty(numericUpDownQuota.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nQuota cannoth be empty.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDownQuota.Focus();
                return;
            }
            
            string tempTask = tmpTask.Text;
            string tempDes = tmpDes.Text;
            string tempUOM = tmpUOM.Text;
            int tempQuota = int.Parse(tmpQuota.Text);
            string tempProject = lbltmpProject.Text;
            string tempProcessCode = lbltmpProcessCode.Text;
            int mCheck = 0;

            //Check User output validation  /* 0 - Yes, 1 - No */
            if (chkOutputValidation.Checked) 
            {
                mCheck = 1; /* 1 - No */
            }
            else
            {
                mCheck = 0; /* 0 - Yes */
            }

            DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify task code?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                TaskHeaderMng mTaskHeaderMng = new TaskHeaderMng(this.conn);
                TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);

                if (mTaskDetailMng.UpdateTaskCodeDetail(txtTaskCode.Text, txtDescription.Text, cmbUOM.Text, int.Parse(numericUpDownQuota.Value.ToString()), tempTask, tempDes, tempUOM, tempQuota, tempProcessCode) >0)
                {
                    mTaskHeaderMng.UpdateTaskCodeHeader(tempTask, tempProject, tempProcessCode, mCheck);

                    MetroFramework.MetroMessageBox.Show(this, "\n Task code details has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();

                    this.Close();

                }
            }
            else
            {
                Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
                this.Close();
            }
        }

        private void frm_TaskCodeModify_Load(object sender, EventArgs e)
        {

        }
    }
}
