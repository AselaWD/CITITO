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
    public partial class frm_AssignUsersToManager : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_AssignUsersToManager _instance;
        public static frm_AssignUsersToManager GetInstance(string uManager, string uPIC)
        {


            if (_instance == null || _instance.IsDisposed)
            {
                string mManager = uManager;
                string mPIC = uPIC;                

                _instance = new frm_AssignUsersToManager(mManager, mPIC);


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_AssignUsersToManager(string uManager, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblManager.Text = uManager;
            lblPIC.Text = uPIC;
            txtCurrentManager.Text = uManager;

        }

        private void frm_AssignUsersToManager_Load(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }

        //Refresh Object
        private void RefreshData()
        {

            cmbAssignManager.DataSource = new ManagerHeaderMng(this.conn).GetListOfManagerByPICExceptParameterManager(lblPIC.Text,txtCurrentManager.Text);
            checkedListBoxManagerToUsers.DataSource = new UserManagementDetailMng(this.conn).GetActiveUserUsersInDeletableManager(txtCurrentManager.Text, lblPIC.Text);

        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();
            //Clear All Fields when Load
            cmbAssignManager.SelectedIndex = -1;

            //Uncheck all items in check list
            for (int index = 0; index < checkedListBoxManagerToUsers.Items.Count; ++index)
            {
                checkedListBoxManagerToUsers.SetItemChecked(index, false);
            }

        }

        //Check/Uncheck All
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                for (int index = 0; index < checkedListBoxManagerToUsers.Items.Count; ++index)
                {
                    checkedListBoxManagerToUsers.SetItemChecked(index, true);
                }
            }
            else
            {
                for (int index = 0; index < checkedListBoxManagerToUsers.Items.Count; ++index)
                {
                    checkedListBoxManagerToUsers.SetItemChecked(index, false);
                }
            }
        }
        /// <summary>
        /// DEBUG: If project alrady registered under manager when a user tansformation. Only users will register to the managaer. 
        /// Duplicate project resolved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Assign button
        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbAssignManager.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPlease select manager to assign first.", "Assign Manager Not Enterd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbAssignManager.Focus();
                return;
            }
            if (checkedListBoxManagerToUsers.CheckedItems.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPlease select at least one user.", "User ID Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkedListBoxManagerToUsers.Focus();
                return;
            }

            string cCurrManager = txtCurrentManager.Text;
            string cAssignManager = cmbAssignManager.Text;
            string cPIC = lblPIC.Text;
            DateTime cCurrDate = DateTime.Now;

            DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to assign manager \""+ cAssignManager + "\" to users intead of \"" + cCurrManager + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {

                ManagerHeader mManagerHeader = new ManagerHeader();
                ManagerDetail mManagerDetail = new ManagerDetail();

                //Assign User Interface data to User Object
                // Assign manager header
                mManagerHeader.M_UID = cCurrManager;
                mManagerHeader.M_Inactivate_Date = DateTime.Now;

                //Assign manager detail
                mManagerDetail.M_UID = cAssignManager;
                mManagerDetail.M_Project_Availability = "Active";
                mManagerDetail.M_Activate_Date = DateTime.Now;
                mManagerDetail.PIC_UID = cPIC;

                ManagerDetailMng mManagerDetailMng = new ManagerDetailMng(this.conn);
                ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);

                for (int i = 0; i < checkedListBoxManagerToUsers.Items.Count; i++)
                {
                    if (checkedListBoxManagerToUsers.GetItemChecked(i))
                    {
                        //MessageBox.Show(checkedListBoxTaskCode.Items[i].ToString());
                        string cUID = checkedListBoxManagerToUsers.Items[i].ToString();

                        //Inactivate Manager
                        if (mManagerHeaderMng.UpdateManagerAsInactive(mManagerHeader) > 0)
                        {
                            DataTable cUsersProject = new UserManagementHeaderMng(this.conn).GetProjectByUID(cUID, cPIC);

                            //Deactive manager details
                            
                             mManagerDetailMng.UpdateManagerProjectToInactiveByManagerID(cCurrManager, mManagerHeader.M_Inactivate_Date);
                            

                            //Add new Project detail for assigend manager
                            if (new UserManagementHeaderMng(this.conn).GetProjectByUID(cUID, cPIC).Rows.Count > 0)
                            {
                                foreach (DataRow dr in cUsersProject.Rows)
                                {
                                    string drProject = dr[0].ToString();

                                    //Project not exists
                                    if (!mManagerDetailMng.UserIsExistonActiveProject(cAssignManager, drProject))
                                    {
                                        //MessageBox.Show("Project: " + drProject, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        mManagerDetail.M_Project = drProject;

                                        //Add manager poject detail
                                        mManagerDetailMng.AddManagerDetail(mManagerDetail);
                                    }

                                }
                            }
                            
                            //Update User's Manager
                            new UserManagementDetailMng(this.conn).UpdateUsersManagerByPIC(cUID, cAssignManager);


                        }
                    }
                }

                MetroFramework.MetroMessageBox.Show(this, "\n\"" + cCurrManager + "\" owned users are now assigned to \"" + cAssignManager + "\".", "Manager Changed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
                ClearFields();
                Application.OpenForms["frm_UserManagementPanel"].BringToFront();
                this.Close();
            }

        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_ManagerRegisterPanel"].BringToFront();
            this.Close();
        }
    }
}
