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
    public partial class frm_AssignManager : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_AssignManager _instance;
        public static frm_AssignManager GetInstance(string uPIC, string uProject)
        {


            if (_instance == null || _instance.IsDisposed)
            {
                string mPIC = uPIC;
                string mProject = uProject;

                _instance = new frm_AssignManager(mPIC, mProject);


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not
        public frm_AssignManager(string uPIC, string uProject)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblPIC.Text = uPIC;
            lblProject.Text = uProject;
            txtCurrentProject.Text = lblProject.Text;

        }

        private void frm_AssignManager_Load(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();

        }

        //Refresh Object
        private void RefreshData()
        {

            cmbAssignProject.DataSource = new ProjectDetailMng(this.conn).GetListOfProjectNamesByPICExceptParameterProjectName(lblPIC.Text, txtCurrentProject.Text);
            checkedListBoxProjectToUsers.DataSource = new ManagerDetailMng(this.conn).GetUsersInDeletableProject(txtCurrentProject.Text);

        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();
            //Clear All Fields when Load
            cmbAssignProject.SelectedIndex = -1;

            //Uncheck all items in check list
            for (int index = 0; index < checkedListBoxProjectToUsers.Items.Count; ++index)
            {
                checkedListBoxProjectToUsers.SetItemChecked(index, false);
            }

        }

        //Check All
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                for (int index = 0; index < checkedListBoxProjectToUsers.Items.Count; ++index)
                {
                    checkedListBoxProjectToUsers.SetItemChecked(index, true);
                }
            }
            else
            {
                for (int index = 0; index < checkedListBoxProjectToUsers.Items.Count; ++index)
                {
                    checkedListBoxProjectToUsers.SetItemChecked(index, false);
                }
            }
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
        }

        //Assign button
        private void btnAssign_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(cmbAssignProject.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPlease select project to assign first.", "Project Name Not Enterd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbAssignProject.Focus();
                return;
            }
            if (checkedListBoxProjectToUsers.CheckedItems.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPlease select at least one user.", "User ID Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkedListBoxProjectToUsers.Focus();
                return;
            }

            string cCurrProject = txtCurrentProject.Text;
            string cAssignProject = cmbAssignProject.Text;
            DateTime cCurrDate = DateTime.Now;

            ManagerDetail mManagerDetail = new ManagerDetail();
            //Assign User Interface data to User Object
            // Assign PIC Detail

            
            mManagerDetail.M_Project_Availability = "Active";
            mManagerDetail.M_Activate_Date = DateTime.Now;
            mManagerDetail.M_Project = cAssignProject;
            mManagerDetail.PIC_UID = lblPIC.Text;

            ManagerDetailMng mManagerDetailMng = new ManagerDetailMng(this.conn);

            for (int i = 0; i < checkedListBoxProjectToUsers.Items.Count; i++)
            {
                if (checkedListBoxProjectToUsers.GetItemChecked(i))
                {
                    //MessageBox.Show(checkedListBoxTaskCode.Items[i].ToString());
                    string cUID = checkedListBoxProjectToUsers.Items[i].ToString();                  
                    
                    //Inactivate Project
                    if (new ManagerDetailMng(this.conn).UpdateManagerProjectToInactive(cUID, cCurrProject, cCurrDate)>0)
                    {
                        //Assign project if Inactivated
                        if (new ManagerDetailMng(this.conn).ManagerInactiveProjectDetaiIsExist(cUID, cAssignProject))
                        {
                            new ManagerDetailMng(this.conn).UpdateManagerProjectFromInactiveToActive(cUID, cAssignProject, cCurrDate);
                        }
                        else
                        {

                            mManagerDetail.M_UID = cUID;
                            mManagerDetailMng.AddManagerDetail(mManagerDetail);
                        }
                        
                    }

                }
            }

            MetroFramework.MetroMessageBox.Show(this, "\n\""+ cCurrProject + "\" project users has been assign to the \"" + cAssignProject + "\".", "Project Changed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshData();
            ClearFields();

            

        }
    }
}
