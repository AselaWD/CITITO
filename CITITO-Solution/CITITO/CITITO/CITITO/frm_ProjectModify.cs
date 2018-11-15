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
    public partial class frm_ProjectModify : MetroForm
    {

        //Start Pass insatance when form is already opend or not
        private static frm_ProjectModify _instance;
        public static frm_ProjectModify GetInstance(string uProjectName, string uProcessCode, string uUID, int uCheck)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mProjectName = uProjectName;
                String mProcessCode = uProcessCode;
                String mUID = uUID;
                int mCheck = uCheck;


                _instance = new frm_ProjectModify(mProjectName, mProcessCode, mUID, mCheck);

            }
            return _instance;

        }

        SqlConnection conn;

        public frm_ProjectModify(string mProjectName, string mProcessCode, string uUID, int uCheck)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            //Get project name by Parameter
            txtCurrentProjectName.Text = mProjectName;
            txtCurrentProcessCode.Text = mProcessCode;
            lblUID.Text = uUID;

            //Validation avoid for user output
            if (uCheck==0)
            {
                chkOutputValidation.Checked = false;
            }
            if (uCheck==1)
            {
                chkOutputValidation.Checked = true;
            }            

            //Radio button
            rdoProjectCode.Checked = false;
            rdoProcessCode.Checked = false;
            

            lblCurrentProjectName.Visible = false;
            txtCurrentProjectName.Visible = false;
            lblNewProjectName.Visible = false;
            txtNewProjectName.Visible = false;

            lblCurrentProcessCode.Visible = false;
            txtCurrentProcessCode.Visible = false;
            lblNewProcessCode.Visible = false;
            txtNewProcessCode.Visible = false;

            chkOutputValidation.Visible = false;
            chkExistingCode.Visible = false;
        }

        //Close button
        private void pboxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
            Application.OpenForms["frm_ProjectRegistrationPanel"].Refresh();
            this.Close();
        }

        //Modify button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Process Code Modify
            if (rdoProjectCode.Checked)
            {
                if (chkExistingCode.Checked)
                {
                    DialogResult d = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {

                        ProcessCodeHeaderMng mProcessCodeHeaderMng = new ProcessCodeHeaderMng(this.conn);
                        ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);

                        //Avoid User output validation
                        int cCheck = 0; /* 0 - No , 1 - Yes */
                        if (chkOutputValidation.Checked)
                        {
                            cCheck = 1;
                        }
                        else
                        {
                            cCheck = 0;
                        }

                        if (mProjectDetailMng.UpdateProjectDetailWithSkippValidation(txtCurrentProjectName.Text.ToUpper(), lblUID.Text.ToUpper(), cCheck) > 0)
                        {
                            //if (mProcessCodeHeaderMng.UpdateProcessCode(txtCurrentProjectName.Text.ToUpper(), txtNewProjectName.Text.ToUpper()) > 0)
                            //{
                            MetroFramework.MetroMessageBox.Show(this, "\nProject " + txtCurrentProjectName.Text + " has been updated!", "Project Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
                            Application.OpenForms["frm_ProjectRegistrationPanel"].Refresh();
                            this.Close();
                            //}
                        }
                    }
                }

                if(chkExistingCode.Checked==false)
                {
                    if (String.IsNullOrEmpty(txtNewProjectName.Text))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "\nPlease Enter New Project Name.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNewProjectName.Focus();
                        return;
                    }

                    if (txtNewProjectName.Text.Length != 5)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "\nProject Name Strandard Lenght is 5 characters.\nPlease enter valid cheracter length for project name.", "Invalid Character Length!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNewProjectName.Focus();
                        return;
                    }

                    if (txtCurrentProjectName.Text == txtNewProjectName.Text)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "\nNew Project name is same as to the curent project!", "Project Names Same!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNewProjectName.Focus();
                        return;
                    }

                    DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resulta == DialogResult.Yes)
                    {
                        ProcessCodeHeaderMng mProcessCodeHeaderMng = new ProcessCodeHeaderMng(this.conn);
                        ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);

                        //Avoid User output validation
                        int cCheck = 0; /* 0 - No , 1 - Yes */
                        if (chkOutputValidation.Checked)
                        {
                            cCheck = 1;
                        }
                        else
                        {
                            cCheck = 0;
                        }

                        if (mProjectDetailMng.UpdateProjectDetail(txtCurrentProjectName.Text.ToUpper(), txtNewProjectName.Text.ToUpper(), lblUID.Text.ToUpper(), cCheck) > 0)
                        {
                            //if (mProcessCodeHeaderMng.UpdateProcessCode(txtCurrentProjectName.Text.ToUpper(), txtNewProjectName.Text.ToUpper()) > 0)
                            //{
                            MetroFramework.MetroMessageBox.Show(this, "\nProject " + txtCurrentProjectName.Text + " has been updated to " + txtNewProjectName.Text, "Project Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
                            Application.OpenForms["frm_ProjectRegistrationPanel"].Refresh();
                            this.Close();
                            //}
                        }

                    }
                    else
                    {
                        Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
                        this.Close();
                    }
                } 
            }

            //Process Code modify
            if (rdoProcessCode.Checked)
            {
                if (String.IsNullOrEmpty(txtNewProcessCode.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nPlease Enter New Process Code.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewProcessCode.Focus();
                    return;
                }
                if (txtCurrentProcessCode.Text == txtNewProcessCode.Text)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nNew process code is same as to the curent process code!", "Process Codes Same!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewProcessCode.Focus();
                    return;
                }

                DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify process code?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    try
                    {
                        ProcessCodeHeaderMng mProcessCodeHeaderMng = new ProcessCodeHeaderMng(conn);
                        ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(conn);


                        if (mProcessCodeHeaderMng.UpdateProcessCode(txtCurrentProjectName.Text.ToUpper(), txtCurrentProcessCode.Text.ToUpper(), txtNewProcessCode.Text.ToUpper()) > 0)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "\nProcess code " + txtCurrentProcessCode.Text.ToUpper() + " has been updated to " + txtNewProcessCode.Text.ToUpper(), "Process Code Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
                            Application.OpenForms["frm_ProjectRegistrationPanel"].Refresh();
                            this.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.HResult== -2146232060)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "\nEntered process code already exist under this project!", "Duplicate Process Codes!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNewProcessCode.Focus();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Message: " + ex.Message,"Exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
   
                }
                else
                {
                    Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
                    this.Close();
                }

            }

            if (rdoProjectCode.Checked==false && rdoProcessCode.Checked==false)
            {
                MetroFramework.MetroMessageBox.Show(this, "\nThere is no action selected to modify!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        //Reset Field colors
        private void txtNewProjectName_TextChanged(object sender, EventArgs e)
        {
            txtNewProjectName.BackColor = Control.DefaultBackColor;
        }

        private void txtNewProjectName_MouseClick(object sender, MouseEventArgs e)
        {
            txtNewProjectName.BackColor = Control.DefaultBackColor;
        }


        //Start >> frm_UserManagement enable move using mouse left down

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Form movement        
        private void frm_DepartmentModify_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //End >> frm_UserManagement enable move using mouse left down

        private void rdoProjectCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoProjectCode.Checked)
            {
                rdoProcessCode.Checked = false;

                lblCurrentProjectName.Visible = true;
                txtCurrentProjectName.Visible = true;
                lblNewProjectName.Visible = true;
                txtNewProjectName.Visible = true;

                lblCurrentProcessCode.Visible = false;
                txtCurrentProcessCode.Visible = false;
                lblNewProcessCode.Visible = false;
                txtNewProcessCode.Visible = false;

                chkOutputValidation.Visible = true;
                chkExistingCode.Visible = true;
            }
        }

        private void rdoProcessCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoProcessCode.Checked)
            {
                rdoProjectCode.Checked = false;

                lblCurrentProcessCode.Visible = true;
                txtCurrentProcessCode.Visible = true;
                lblNewProcessCode.Visible = true;
                txtNewProcessCode.Visible = true;

                lblCurrentProjectName.Visible = false;
                txtCurrentProjectName.Visible = false;
                lblNewProjectName.Visible = false;
                txtNewProjectName.Visible = false;

                chkOutputValidation.Visible = false;
                chkExistingCode.Visible = false;

            }
        }

        private void frm_ProjectModify_Load(object sender, EventArgs e)
        {

        }

        //If Keep Existing Project Name cehecked
        private void chkExistingCode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExistingCode.Checked)
            {
                txtNewProjectName.Enabled = false;
            }
            else
            {
                txtNewProjectName.Enabled = true;
            }
            
        }
    }
}
