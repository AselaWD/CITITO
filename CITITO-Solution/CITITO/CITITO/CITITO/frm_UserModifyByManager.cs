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
using System.Security.Cryptography;

namespace CITITO
{
    public partial class frm_UserModifyByManager : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_UserModifyByManager _instance;
        public static frm_UserModifyByManager GetInstance(string uUID, string uManager, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUID = uUID;
                String mManager = uManager;
                String mPIC = uPIC;
                _instance = new frm_UserModifyByManager(mUID, mManager, mPIC);

            }
            return _instance;

        }

        public frm_UserModifyByManager(string uUID, string uManager, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblUID.Text = uUID;
            lblManagerUID.Text = uManager;
            lblPIC.Text = uPIC;

        }


        private void frm_UserModifyByManager_Load(object sender, EventArgs e)
        {
            string uUID = lblUID.Text;            
            string uManager = lblManagerUID.Text;
            string uPIC = lblPIC.Text;

            //Basic Detail
            txtCurrentName.Text = new UserManagementHeaderMng(this.conn).GetUserNameByUID(uUID, uManager, uPIC);
            txtResourceID.Text = new UserManagementHeaderMng(this.conn).GetresourceByUID(uUID, uManager, uPIC);

            //Project Detail
            //checkedListBoxRemoveProjects.DataSource = new ManagerDetailMng(this.conn).GetAllProjectsByManagerExceptActives(uPIC, uManager);
            //checkedListBoxAddProjects.DataSource = new ManagerDetailMng(this.conn).GetAllActiveProjectsByManager(uPIC, uManager);

            //Remove List
            DataTable removeList = new UserManagementDetailMng(this.conn).GetAllProjectsByUserExceptActives(uUID, uManager, uPIC);

            foreach (DataRow row in removeList.Rows)
            {
                checkedListBoxRemoveProjects.Items.Add(row[0]);
            }

            //Remove List
            DataTable addList = new UserManagementDetailMng(this.conn).GetAllActiveProjectsByUser(uUID, uManager, uPIC);

            foreach (DataRow row in addList.Rows)
            {
                checkedListBoxAddProjects.Items.Add(row[0]);
            }

            //invisible
            lblCurrentName.Visible = false;
            txtCurrentName.Visible = false;
            lblNewName.Visible = false;
            txtNewName.Visible = false;
            chkModifyPassword.Visible = false;
            lblPassword.Visible = false;
            txtPassword.Visible = false;
            lblRePassword.Visible = false;
            txtRePassword.Visible = false;
            lblResourceID.Visible = false;
            txtResourceID.Visible = false;
            lblErrorResourceID.Visible = false;
            lblviewResourceList.Visible = false;


            checkedListBoxAddProjects.Visible = false;
            checkedListBoxRemoveProjects.Visible = false;
            btnAddToList.Visible = false;
            btnRemoveToList.Visible = false;
            btnMultiAdd.Visible = false;
            btnMultiRemove.Visible = false;
            lblAdd.Visible = false;
            lblRemoved.Visible = false;


            if (checkedListBoxRemoveProjects.Items.Count == 0 && checkedListBoxAddProjects.Items.Count == 0)
            {
                DataTable RecoverremoveList = new UserManagementDetailMng(this.conn).GetAllProjectsByManager(uManager);

                foreach (DataRow row in RecoverremoveList.Rows)
                {
                    checkedListBoxRemoveProjects.Items.Add(row[0]);
                }
            }

            //Password diable

            lblPassword.Enabled = false;
            lblRePassword.Enabled = false;
            txtPassword.Enabled = false;
            txtRePassword.Enabled = false;
        }

        //Basic details radio button 
        private void rdoBasicDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBasicDetails.Checked)
            {
                rdoProjectDetails.Checked = false;
                

                //Visible
                lblCurrentName.Visible = true;
                txtCurrentName.Visible = true;
                lblNewName.Visible = true;
                txtNewName.Visible = true;
                chkModifyPassword.Visible = true;
                lblPassword.Visible = true;
                txtPassword.Visible = true;
                lblRePassword.Visible = true;
                txtRePassword.Visible = true;
                lblResourceID.Visible = true;
                txtResourceID.Visible = true;
                lblviewResourceList.Visible = true;

                //invisible                

                checkedListBoxAddProjects.Visible = false;
                checkedListBoxRemoveProjects.Visible = false;
                btnAddToList.Visible = false;
                btnRemoveToList.Visible = false;
                btnMultiAdd.Visible = false;
                btnMultiRemove.Visible = false;
                lblAdd.Visible = false;
                lblRemoved.Visible = false;
                lblErrorResourceID.Visible = false;

            }
        }

        //Project details radio button 
        private void rdoProjectDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoProjectDetails.Checked)
            {
                rdoBasicDetails.Checked = false;
                

                //Visible
                checkedListBoxAddProjects.Visible = true;
                checkedListBoxRemoveProjects.Visible = true;
                btnAddToList.Visible = true;
                btnRemoveToList.Visible = true;
                btnMultiAdd.Visible = true;
                btnMultiRemove.Visible = true;
                lblAdd.Visible = true;
                lblRemoved.Visible = true;

                //invisible               

                lblCurrentName.Visible = false;
                txtCurrentName.Visible = false;
                lblNewName.Visible = false;
                txtNewName.Visible = false;
                chkModifyPassword.Visible = false;
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                lblRePassword.Visible = false;
                txtRePassword.Visible = false;
                lblResourceID.Visible = false;
                txtResourceID.Visible = false;
                lblErrorResourceID.Visible = false;
                lblviewResourceList.Visible = false;

            }
        }
              


        //Nodify button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Basic details
            if (rdoBasicDetails.Checked == true)
            {
                //Validate Fields is null or empty
                PTR_QA_StdRatesMng mPTR_QA_StdRatesMng = new PTR_QA_StdRatesMng(this.conn);

                if (String.IsNullOrEmpty(txtResourceID.Text) || !mPTR_QA_StdRatesMng.IsExistPTRResourceRecord(txtResourceID.Text))
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nEmpty or invalid Resource ID.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtResourceID.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(txtNewName.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nPlease enter new user name.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewName.Focus();
                    return;
                }

                if (txtCurrentName.Text == txtNewName.Text)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nBoth user names are same!", "User Names Same!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewName.Focus();
                    return;
                }

                DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify basic details of user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);

                    //Update Name with Passsword
                    if (chkModifyPassword.Checked == true)
                    {
                        if (lblPasswordMessage.Text != "Matched!")
                        {
                            MetroFramework.MetroMessageBox.Show(this, "\nPasswords cannot be mismatched..!", "Mismatched Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Focus();
                            return;
                        }

                        using (MD5 md5Hash = MD5.Create())
                        {
                            String mPassword = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);

                            if (mUserManagementHeaderMng.UpdateUserNameWithPassword(lblUID.Text, txtNewName.Text, mPassword, txtResourceID.Text) > 0)
                            {
                                MetroFramework.MetroMessageBox.Show(this, "\nUser details has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Application.OpenForms["frm_UserManagementPanel"].BringToFront();

                                this.Close();

                            }
                        }
                    }
                    //Update Name
                    else
                    {
                        if (mUserManagementHeaderMng.UpdateUserName(lblUID.Text, txtNewName.Text, txtResourceID.Text) > 0)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "\nUser details has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Application.OpenForms["frm_UserManagementPanel"].BringToFront();

                            this.Close();
                        }
                    }

                }
            }

            //Project details
            if (rdoProjectDetails.Checked == true)
            {
                string uUID = lblUID.Text;
                string uManager = lblManagerUID.Text;
                string uPIC = lblPIC.Text;
                DateTime uActiveTime = DateTime.Now;
                DateTime uInactiveTime = DateTime.Now;


                DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify project details of user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    //Check Removed List
                    if (checkedListBoxRemoveProjects.Items.Count == 0)
                    {
                        //Do not prompt error
                    }
                    else
                    {


                        foreach (var RemoveItem in checkedListBoxRemoveProjects.Items)
                        {
                            // use the currently iterated list box item
                            //MessageBox.Show(string.Format(RemoveItem.ToString()), "Remove List", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string uProject = RemoveItem.ToString();

                            //If Active project
                            if (new UserManagementDetailMng(this.conn).GetActiveProjectIsExistByUser(uUID, uManager, uPIC, uProject))
                            {
                                //Inactive project
                                new UserManagementDetailMng(this.conn).UpdateUserProjectToInactive(uUID, uManager, uProject, uInactiveTime);
                            }

                        }
                    }

                    //Check Add List
                    if (checkedListBoxAddProjects.Items.Count == 0)
                    {
                        //Do not prompt error
                    }
                    else
                    {


                        foreach (var AddItem in checkedListBoxAddProjects.Items)
                        {
                            // use the currently iterated list box item
                            //MessageBox.Show(string.Format(AddItem.ToString()), "Add List", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string uProject = AddItem.ToString();

                            //If Inctive project
                            if (new UserManagementDetailMng(this.conn).UserInactiveProjectDetaiIsExist(uUID, uManager, uProject))
                            {
                                //If Active project with PIC
                                //new ManagerDetailMng(this.conn).UpdateManagerProjectFromInactiveToActiveWithPIC(uManager, uProject, uActiveTime, uPIC);

                                //Add new Active project 

                                //Interface data to Manager Object
                                UserManagementDetail mUserManagementDetail = new UserManagementDetail();

                                // Assign Manager Detail
                                mUserManagementDetail.P_UID = uUID;
                                mUserManagementDetail.M_UID = uManager;
                                mUserManagementDetail.P_Project_Availability = "Active";
                                mUserManagementDetail.P_Activate_Date = uActiveTime;
                                mUserManagementDetail.PIC_UID = uPIC;
                                mUserManagementDetail.P_Project = uProject;

                                if (new UserManagementDetailMng(this.conn).GetActiveProjectIsExistByUser(uUID, uManager, uPIC, uProject))
                                {
                                    //Do not prompt error
                                }
                                else
                                {
                                    new UserManagementDetailMng(this.conn).AddUserManagementDetail(mUserManagementDetail);
                                }
                            }

                            else
                            {
                                //Add new Active project 

                                //Interface data to Manager Object
                                UserManagementDetail mUserManagementDetail = new UserManagementDetail();

                                // Assign Manager Detail
                                mUserManagementDetail.P_UID = uUID;
                                mUserManagementDetail.M_UID = uManager;
                                mUserManagementDetail.P_Project_Availability = "Active";
                                mUserManagementDetail.P_Activate_Date = uActiveTime;
                                mUserManagementDetail.PIC_UID = uPIC;
                                mUserManagementDetail.P_Project = uProject;

                                if (new UserManagementDetailMng(this.conn).GetActiveProjectIsExistByUser(uUID, uManager, uPIC, uProject))
                                {
                                    //Do not prompt error
                                }
                                else
                                {
                                    new UserManagementDetailMng(this.conn).AddUserManagementDetail(mUserManagementDetail);
                                }

                            }

                        }


                    }


                    MetroFramework.MetroMessageBox.Show(this, "\nUser project(s) has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.OpenForms["frm_UserManagementPanel"].BringToFront();

                    this.Close();
                }

            }

        }

        //Check password modify
        private void chkModifyPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModifyPassword.Checked == true)
            {
                lblPassword.Enabled = true;
                lblRePassword.Enabled = true;
                txtPassword.Enabled = true;
                txtRePassword.Enabled = true;

            }
            else
            {
                lblPassword.Enabled = false;
                lblRePassword.Enabled = false;
                txtPassword.Enabled = false;
                txtRePassword.Enabled = false;
            }
        }

        //Password filed character length
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length <= 7)
            {
                pBoxCorrect.Visible = false;
                pBoxError.Visible = true;
                lblPasswordMessage.Visible = true;
                lblPasswordMessage.Text = "Length should be at least 8 Characters!";
                lblPasswordMessage.ForeColor = Color.Red;
            }
            else
            {
                lblPasswordMessage.Visible = false;
                pBoxCorrect.Visible = false;
                pBoxError.Visible = false;
            }
        }

        //Password filed match
        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                pBoxCorrect.Visible = false;
                pBoxError.Visible = true;
                lblPasswordMessage.Visible = true;
                lblPasswordMessage.Text = "Password cannot be empty!";
                lblPasswordMessage.ForeColor = Color.Red;
            }
            else
            {
                if (txtPassword.Text.Length.Equals(txtRePassword.Text.Length))
                {
                    if (txtPassword.Text == txtRePassword.Text)
                    {
                        pBoxCorrect.Visible = true;
                        pBoxError.Visible = false;
                        lblPasswordMessage.Visible = true;
                        lblPasswordMessage.Text = "Matched!";
                        lblPasswordMessage.ForeColor = Color.Green;
                    }
                    else
                    {
                        pBoxCorrect.Visible = false;
                        pBoxError.Visible = true;
                        lblPasswordMessage.Visible = true;
                        lblPasswordMessage.Text = "Mismatched!";
                        lblPasswordMessage.ForeColor = Color.Red;
                    }
                }

                else if (txtPassword.Text.Length < txtRePassword.Text.Length)
                {
                    pBoxCorrect.Visible = false;
                    pBoxError.Visible = true;
                    lblPasswordMessage.Visible = true;
                    lblPasswordMessage.Text = "Mismatched!";
                    lblPasswordMessage.ForeColor = Color.Red;
                }
                else
                {
                    lblPasswordMessage.Visible = false;
                    pBoxCorrect.Visible = false;
                    pBoxError.Visible = false;
                }
            }
        }

        //Add one-by-one to Add list
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (checkedListBoxRemoveProjects.SelectedIndex == -1)
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPlease select an item to add.", "Invalid Selection!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkedListBoxRemoveProjects.Focus();
                return;
            }
            else
            {
                checkedListBoxAddProjects.Items.Add(checkedListBoxRemoveProjects.SelectedItem);
                checkedListBoxRemoveProjects.Items.Remove(checkedListBoxRemoveProjects.SelectedItem);
            }
        }

        //Multi add projects to add list
        private void btnMultiAdd_Click(object sender, EventArgs e)
        {
            if (checkedListBoxRemoveProjects.SelectedIndex == -1)
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPlease select at leat one item to add.", "Invalid Selection!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkedListBoxRemoveProjects.Focus();
                return;
            }
            else
            {
                while (checkedListBoxRemoveProjects.SelectedItems.Count != 0)
                {
                    checkedListBoxAddProjects.Items.Add(checkedListBoxRemoveProjects.SelectedItems[0]);
                    checkedListBoxRemoveProjects.Items.Remove(checkedListBoxRemoveProjects.SelectedItems[0]);
                }
            }
        }

        //Remove one-by-one to Remove list
        private void btnRemoveToList_Click(object sender, EventArgs e)
        {
            if (checkedListBoxAddProjects.SelectedIndex == -1)
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPlease select an item to remove.", "Invalid Selection!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkedListBoxAddProjects.Focus();
                return;
            }
            else
            {
                checkedListBoxRemoveProjects.Items.Add(checkedListBoxAddProjects.SelectedItem);
                checkedListBoxAddProjects.Items.Remove(checkedListBoxAddProjects.SelectedItem);
            }
        }

        //Multi remove projects to remove list
        private void btnMultiRemove_Click(object sender, EventArgs e)
        {
            if (checkedListBoxAddProjects.SelectedIndex == -1)
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPlease select at leat one item to remove.", "Invalid Selection!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkedListBoxAddProjects.Focus();
                return;
            }
            else
            {
                while (checkedListBoxAddProjects.SelectedItems.Count != 0)
                {
                    checkedListBoxRemoveProjects.Items.Add(checkedListBoxAddProjects.SelectedItems[0]);
                    checkedListBoxAddProjects.Items.Remove(checkedListBoxAddProjects.SelectedItems[0]);
                }
            }
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_UserRegistrationPanel"].BringToFront();
            this.Close();
        }

        //Resource ID validation
        private void txtResourceID_Leave(object sender, EventArgs e)
        {
            //validate entred resource Code

            PTR_QA_StdRatesMng mPTR_QA_StdRatesMng = new PTR_QA_StdRatesMng(this.conn);

            if (!mPTR_QA_StdRatesMng.IsExistPTRResourceRecord(txtResourceID.Text))
            {
                lblErrorResourceID.Visible = true;
                lblErrorResourceID.Text = "Invalid Resource ID. \"View Resource ID List\" for more details.";
            }
            else
            {
                lblErrorResourceID.Visible = false;
            }
        }

        private void lblviewResourceList_Click(object sender, EventArgs e)
        {
            frm_Dashboard_RecordsForViewResourceID form = frm_Dashboard_RecordsForViewResourceID.GetInstance();
            if (!form.Visible)
            {

                form.Show();

            }
            else
            {
                form.BringToFront();
            }
        }

        private void txtResourceID_TextChanged(object sender, EventArgs e)
        {
            //validate entred resource Code

            PTR_QA_StdRatesMng mPTR_QA_StdRatesMng = new PTR_QA_StdRatesMng(this.conn);

            if (!mPTR_QA_StdRatesMng.IsExistPTRResourceRecord(txtResourceID.Text))
            {
                lblErrorResourceID.Visible = true;
                lblErrorResourceID.Text = "Invalid Resource ID. \"View Resource ID List\" for more details.";
            }
            else
            {
                lblErrorResourceID.Visible = false;
            }
        }
    }
}
