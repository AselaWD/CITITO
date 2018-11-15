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
    public partial class frm_ManagerModify : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_ManagerModify _instance;
        public static frm_ManagerModify GetInstance(string uPIC, string uManager)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mPIC = uPIC;
                String mManager = uManager;
                _instance = new frm_ManagerModify(mPIC, mManager);

            }
            return _instance;

        }

        public frm_ManagerModify(string uPIC, string uManager)
        {

            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblPIC.Text = uPIC;
            lblManagerUID.Text = uManager;

        }
        private void frm_ManagerModify_Load(object sender, EventArgs e)
        {
            string uPIC = lblPIC.Text;
            string uManager = lblManagerUID.Text;

            //Basic Detail
            txtCurrentName.Text = new ManagerHeaderMng(this.conn).GetManagerNameByUID(uPIC, uManager);
            txtCurrentAccess.Text = new ManagerHeaderMng(this.conn).GetCurrentAccessLeveleByManagerUID(uManager, uPIC);

            cmbSystemAccess.DataSource = new SystemAccessLevelMng(this.conn).GetAccessLevelsForManagerAndDCDInPIC(txtCurrentAccess.Text);
            cmbSystemAccess.SelectedIndex = -1;

            //Project Detail
            //checkedListBoxRemoveProjects.DataSource = new ManagerDetailMng(this.conn).GetAllProjectsByManagerExceptActives(uPIC, uManager);
            //checkedListBoxAddProjects.DataSource = new ManagerDetailMng(this.conn).GetAllActiveProjectsByManager(uPIC, uManager);

            //Remove List
            DataTable removeList = new ManagerDetailMng(this.conn).GetAllProjectsByManagerExceptActives(uPIC, uManager);

            foreach (DataRow row in removeList.Rows)
            {
                checkedListBoxRemoveProjects.Items.Add(row[0]);
            }

            //Remove List
            DataTable addList = new ManagerDetailMng(this.conn).GetAllActiveProjectsByManager(uPIC, uManager);

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


            checkedListBoxAddProjects.Visible = false;
            checkedListBoxRemoveProjects.Visible = false;
            btnAddToList.Visible = false;
            btnRemoveToList.Visible = false;
            btnMultiAdd.Visible = false;
            btnMultiRemove.Visible = false;
            lblAdd.Visible = false;
            lblRemoved.Visible = false;


            txtCurrentAccess.Visible = false;
            cmbSystemAccess.Visible = false;
            lblCurrentAccess.Visible = false;
            lblChangeAccess.Visible = false;


            if (checkedListBoxRemoveProjects.Items.Count==0 && checkedListBoxAddProjects.Items.Count==0) {
                DataTable RecoverremoveList = new ProjectDetailMng(this.conn).GetAllProjectsByPIC(uPIC);

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

        //Basic detail radio
        private void rdoBasicDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBasicDetails.Checked)
            {
                rdoProjectDetails.Checked = false;
                metroRadioButtonAccessDetails.Checked = false;

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

                //invisible
                txtCurrentAccess.Visible = false;
                cmbSystemAccess.Visible = false;
                lblCurrentAccess.Visible = false;
                lblChangeAccess.Visible = false;

                checkedListBoxAddProjects.Visible = false;
                checkedListBoxRemoveProjects.Visible = false;
                btnAddToList.Visible = false;
                btnRemoveToList.Visible = false;
                btnMultiAdd.Visible = false;
                btnMultiRemove.Visible = false;
                lblAdd.Visible = false;
                lblRemoved.Visible = false;

            }
        }

        //Project detail radio
        private void rdoProjectDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoProjectDetails.Checked)
            {
                rdoBasicDetails.Checked = false;
                metroRadioButtonAccessDetails.Checked = false;

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
                txtCurrentAccess.Visible = false;
                cmbSystemAccess.Visible = false;
                lblCurrentAccess.Visible = false;
                lblChangeAccess.Visible = false;

                lblCurrentName.Visible = false;
                txtCurrentName.Visible = false;
                lblNewName.Visible = false;
                txtNewName.Visible = false;
                chkModifyPassword.Visible = false;
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                lblRePassword.Visible = false;
                txtRePassword.Visible = false;

            }
        }


        //Access details radio button 
        private void metroRadioButtonAccessDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButtonAccessDetails.Checked)
            {
                rdoBasicDetails.Checked = false;
                rdoProjectDetails.Checked = false;

                //Visible
                txtCurrentAccess.Visible = true;
                cmbSystemAccess.Visible = true;
                lblCurrentAccess.Visible = true;
                lblChangeAccess.Visible = true;

                //invisible
                checkedListBoxAddProjects.Visible = false;
                checkedListBoxRemoveProjects.Visible = false;
                btnAddToList.Visible = false;
                btnRemoveToList.Visible = false;
                btnMultiAdd.Visible = false;
                btnMultiRemove.Visible = false;
                lblAdd.Visible = false;
                lblRemoved.Visible = false;

                lblCurrentName.Visible = false;
                txtCurrentName.Visible = false;
                lblNewName.Visible = false;
                txtNewName.Visible = false;
                chkModifyPassword.Visible = false;
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                lblRePassword.Visible = false;
                txtRePassword.Visible = false;

            }
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_ManagerRegisterPanel"].BringToFront();
            this.Close();
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

        //Modify button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Basic details
            if (rdoBasicDetails.Checked==true)
            {
                if (String.IsNullOrEmpty(txtNewName.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nPlease enter new manager name.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewName.Focus();
                    return;
                }

                if (txtCurrentName.Text == txtNewName.Text)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nBoth manager names are same!", "Manager Names Same!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewName.Focus();
                    return;
                }

                DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify basic details of manager?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);

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

                            if (mManagerHeaderMng.UpdateManagerNameWithPassword(lblManagerUID.Text, txtNewName.Text, mPassword) > 0)
                            {
                                MetroFramework.MetroMessageBox.Show(this, "\n Manager details has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Application.OpenForms["frm_ManagerRegisterPanel"].BringToFront();

                                this.Close();

                            }
                        }
                    }
                    //Update Name
                    else
                    {
                        if (mManagerHeaderMng.UpdateManagerName(lblManagerUID.Text, txtNewName.Text) > 0)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "\nManager details has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Application.OpenForms["frm_ManagerRegisterPanel"].BringToFront();
                            this.Close();
                        }
                    }

                }
                else
                {
                    Application.OpenForms["frm_ManagerRegisterPanel"].BringToFront();
                    this.Close();
                }
            }

            //Project details
            if (rdoProjectDetails.Checked == true)
            {
                string uPIC = lblPIC.Text;
                string uManager = lblManagerUID.Text;
                DateTime uActiveTime = DateTime.Now;
                DateTime uInactiveTime = DateTime.Now;


                //if (new UserManagementDetailMng(this.conn).ActiveUserIsExistOnDeletedManager(uManager, uPIC))
                //{
                //    MetroFramework.MetroMessageBox.Show(this, "\nSome users are already active with this projects. Please check them before modify projects.", "Mismatched Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

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
                        if (new ManagerDetailMng(this.conn).GetActiveProjectIsExistByManager(uManager, uPIC, uProject))
                        {
                            //Inactive project
                            new ManagerDetailMng(this.conn).UpdateManagerProjectToInactive(uManager, uProject, uInactiveTime);
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
                    DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify project details of manager?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resulta == DialogResult.Yes)
                    {
                        foreach (var AddItem in checkedListBoxAddProjects.Items)
                        {
                            // use the currently iterated list box item
                            //MessageBox.Show(string.Format(AddItem.ToString()), "Add List", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string uProject = AddItem.ToString();

                            //If Inctive project
                            if (new ManagerDetailMng(this.conn).ManagerInactiveProjectDetaiIsExist(uManager, uProject))
                            {
                                //If Active project with PIC
                                //new ManagerDetailMng(this.conn).UpdateManagerProjectFromInactiveToActiveWithPIC(uManager, uProject, uActiveTime, uPIC);

                                //Add new Active project 

                                //Interface data to Manager Object
                                ManagerDetail mManagerDetail = new ManagerDetail();

                                // Assign Manager Detail
                                mManagerDetail.M_UID = uManager;
                                mManagerDetail.M_Project_Availability = "Active";
                                mManagerDetail.M_Activate_Date = uActiveTime;
                                mManagerDetail.PIC_UID = uPIC;
                                mManagerDetail.M_Project = uProject;

                                if (new ManagerDetailMng(this.conn).GetActiveProjectIsExistByManager(uManager, uPIC, uProject))
                                {
                                    //Do not prompt error
                                }
                                else
                                {
                                    new ManagerDetailMng(this.conn).AddManagerDetail(mManagerDetail);
                                }
                            }

                            else
                            {
                                //Add new Active project 

                                //Interface data to Manager Object
                                ManagerDetail mManagerDetail = new ManagerDetail();

                                // Assign Manager Detail
                                mManagerDetail.M_UID = uManager;
                                mManagerDetail.M_Project_Availability = "Active";
                                mManagerDetail.M_Activate_Date = uActiveTime;
                                mManagerDetail.PIC_UID = uPIC;
                                mManagerDetail.M_Project = uProject;

                                if (new ManagerDetailMng(this.conn).GetActiveProjectIsExistByManager(uManager, uPIC, uProject))
                                {
                                    //Do not prompt error
                                }
                                else
                                {
                                    new ManagerDetailMng(this.conn).AddManagerDetail(mManagerDetail);
                                }
                                
                            }

                        }
                    }
                    else
                    {
                        Application.OpenForms["frm_ManagerRegisterPanel"].BringToFront();
                        this.Close();
                    }

                }

                MetroFramework.MetroMessageBox.Show(this, "\nManager project(s) has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.OpenForms["frm_ManagerRegisterPanel"].BringToFront();

                this.Close();

            }

            //Access Details
            if (metroRadioButtonAccessDetails.Checked == true)
            {
                string uUID = lblManagerUID.Text;

                if (String.IsNullOrEmpty(cmbSystemAccess.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nPlease select access level to be changed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSystemAccess.Focus();
                    return;
                }

                if (txtCurrentAccess.Text == cmbSystemAccess.Text)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nBoth access levels are same!", "Access Levels Same!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSystemAccess.Focus();
                    return;
                }

                DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify system access details of user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    new ManagerHeaderMng(this.conn).UpdateManagerAccessLevel(uUID, cmbSystemAccess.Text);

                    MetroFramework.MetroMessageBox.Show(this, "\nUser system access has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.OpenForms["frm_UserManagementPanel"].BringToFront();

                    this.Close();
                }
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

    }
}
