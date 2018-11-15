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
using CITITO.BusinessControls;
using CITITO.BusinessServices;
using System.Data.SqlClient;
using System.Security.Cryptography;
using MetroFramework.Forms;


namespace CITITO
{
    public partial class frm_UserModifyByPIC : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_UserModifyByPIC _instance;
        public static frm_UserModifyByPIC GetInstance(string uUID, string uManager, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUID = uUID;
                String mManager = uManager;
                String mPIC = uPIC;
                _instance = new frm_UserModifyByPIC(mUID, mManager, mPIC);

            }
            return _instance;

        }

        public frm_UserModifyByPIC(string uUID, string uManager, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblUID.Text = uUID;
            lblManagerUID.Text = uManager;
            lblPIC.Text = uPIC;
        }

        private void frm_UserModifyByPIC_Load(object sender, EventArgs e)
        {
            string uUID = lblUID.Text;
            string uManager = lblManagerUID.Text;
            string uPIC = lblPIC.Text;

            //Basic Detail
            txtCurrentName.Text = new UserManagementHeaderMng(this.conn).GetUserNameByUID(uUID, uManager, uPIC);
            txtCurrentManager.Text = uManager;
            txtCurrentAccess.Text = new UserManagementHeaderMng(this.conn).GetCurrentAccessLeveleByUID(uUID, uManager, uPIC);
            cmbManagersUID.DataSource = new ManagerHeaderMng(this.conn).GetActiveManagerUIDByPIC(uPIC);
            cmbManagersUID.SelectedIndex = -1;
            cmbSystemAccess.DataSource = new SystemAccessLevelMng(this.conn).GetAccessLevelsForManagerAndDCD();
            cmbSystemAccess.SelectedIndex = -1;
            txtResourceID.Text = new UserManagementHeaderMng(this.conn).GetresourceByUID(uUID, uManager, uPIC);

            string mShift = new UserManagementHeaderMng(this.conn).GetCurrentShiftByUID(uUID, uPIC);

            
            string sourcea = mShift;
            string[] stringSeparatorsa = new string[] { " to " };
            string[] resultu;
            resultu = sourcea.Split(stringSeparatorsa, StringSplitOptions.None);

            string cShiftIn = resultu[0].ToString();
            string cShiftOut = resultu[1].ToString();

            //chunk shift in
            string sourceas = cShiftIn;
            string[] stringSeparatorsas = new string[] { " " };
            string[] resultus;
            resultus = sourceas.Split(stringSeparatorsas, StringSplitOptions.None);

            //chunk shift out
            string sourceao = cShiftOut;
            string[] stringSeparatorsao = new string[] { " " };
            string[] resultuo;
            resultuo = sourceao.Split(stringSeparatorsao, StringSplitOptions.None);

            //Secods added to time
            string cShiftIns = resultus[0].ToString() + ":00 " + resultus[1].ToString();
            string cShiftOuts = resultuo[0].ToString() + ":00 " + resultuo[1].ToString();


            //MessageBox.Show(cShiftIns);
            //MessageBox.Show(cShiftOuts);

            dateTimePickerTaskIn.Value = DateTime.Parse(cShiftIns);
            dateTimePickerTaskOut.Value = DateTime.Parse(cShiftOuts);


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
            lblManager.Visible = false;
            cmbManagersUID.Visible = false;
            lblCurrentManager.Visible = false;
            txtCurrentManager.Visible = false;
            chkModifyPassword.Visible = false;
            chkModifyImmediateManager.Visible = false;
            lblPassword.Visible = false;
            txtPassword.Visible = false;
            lblRePassword.Visible = false;
            txtRePassword.Visible = false;
            groupBoxShift.Visible = false;
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


            txtCurrentAccess.Visible = false;
            cmbSystemAccess.Visible = false;
            lblCurrentAccess.Visible = false;
            lblChangeAccess.Visible = false;

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


            // Set the Format type and the CustomFormat string.
            dateTimePickerTaskIn.Format = DateTimePickerFormat.Time;
            dateTimePickerTaskIn.CustomFormat = "hh:mm tt";
            dateTimePickerTaskIn.ShowUpDown = true;

            dateTimePickerTaskOut.Format = DateTimePickerFormat.Time;
            dateTimePickerTaskOut.CustomFormat = "hh:mm tt";
            dateTimePickerTaskOut.ShowUpDown = true;


        }


        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_UserRegistrationPanel"].BringToFront();
            this.Close();
        }

        //Basic details radio button 
        private void rdoBasicDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBasicDetails.Checked)
            {
                rdoProjectDetails.Checked = false;
                metroRadioButtonAccessDetails.Checked = false;
                metroRadioButtonShiftDetails.Checked = false;

                //Visible
                lblCurrentName.Visible = true;
                txtCurrentName.Visible = true;
                lblNewName.Visible = true;
                txtNewName.Visible = true;
                lblManager.Visible = true;
                cmbManagersUID.Visible = true;
                lblCurrentManager.Visible = true;
                txtCurrentManager.Visible = true;
                chkModifyPassword.Visible = true;
                chkModifyImmediateManager.Visible = true;
                lblPassword.Visible = true;
                txtPassword.Visible = true;
                lblRePassword.Visible = true;
                txtRePassword.Visible = true;
                lblResourceID.Visible = true;
                txtResourceID.Visible = true;
                lblviewResourceList.Visible = true;

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
                groupBoxShift.Visible = false;

            }
        }

        //Project details radio button 
        private void rdoProjectDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoProjectDetails.Checked)
            {
                rdoBasicDetails.Checked = false;
                metroRadioButtonAccessDetails.Checked = false;
                metroRadioButtonShiftDetails.Checked = false;

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
                chkModifyImmediateManager.Visible = false;
                lblManager.Visible = false;
                cmbManagersUID.Visible = false;
                lblCurrentManager.Visible = false;
                txtCurrentManager.Visible = false;
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                lblRePassword.Visible = false;
                txtRePassword.Visible = false;
                groupBoxShift.Visible = false;
                lblResourceID.Visible = false;
                txtResourceID.Visible = false;
                lblErrorResourceID.Visible = false;
                lblviewResourceList.Visible = false;

            }
        }

        //Access details radio button 
        private void metroRadioButtonAccessDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButtonAccessDetails.Checked)
            {
                rdoBasicDetails.Checked = false;
                rdoProjectDetails.Checked = false;
                metroRadioButtonShiftDetails.Checked = false;

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
                chkModifyImmediateManager.Visible = false;
                lblManager.Visible = false;
                cmbManagersUID.Visible = false;
                lblCurrentManager.Visible = false;
                txtCurrentManager.Visible = false;
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                lblRePassword.Visible = false;
                txtRePassword.Visible = false;
                groupBoxShift.Visible = false;
                lblResourceID.Visible = false;
                txtResourceID.Visible = false;
                lblErrorResourceID.Visible = false;
                lblviewResourceList.Visible = false;


            }
        }


        private void metroRadioButtonShiftDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButtonShiftDetails.Checked)
            {

                rdoBasicDetails.Checked = false;
                rdoProjectDetails.Checked = false;
                metroRadioButtonAccessDetails.Checked = false;


                //Visible
                groupBoxShift.Visible = true;

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
                chkModifyImmediateManager.Visible = false;
                lblManager.Visible = false;
                cmbManagersUID.Visible = false;
                lblCurrentManager.Visible = false;
                txtCurrentManager.Visible = false;
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

            }
                

        }

        //Check/Uncheck Password
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

        //Modify button
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

                if (String.IsNullOrEmpty(txtNewName.Text) && chkModifyImmediateManager.Checked== false)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nPlease enter new user name.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewName.Focus();
                    return;
                }

                if (txtCurrentName.Text == txtNewName.Text && chkModifyImmediateManager.Checked == false)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nBoth user names are same!", "User Names Same!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewName.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(cmbManagersUID.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nPlease select a manager.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbManagersUID.Focus();
                    return;
                }

                DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify basic details of user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);

                    //Update Only Manager
                    if (chkModifyImmediateManager.Checked == true)
                    {
                        //Update Manager
                        new UserManagementDetailMng(this.conn).UpdateUsersManagerByPIC(lblUID.Text, cmbManagersUID.Text);

                        MetroFramework.MetroMessageBox.Show(this, "\nUser details has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Application.OpenForms["frm_UserManagementPanel"].BringToFront();

                        this.Close();
                    }
                    //Update Name with Passsword
                    else if (chkModifyPassword.Checked == true)
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
                                //Update Manager
                                new UserManagementDetailMng(this.conn).UpdateUsersManagerByPIC(lblUID.Text, cmbManagersUID.Text);

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
                            //Update Manager
                            new UserManagementDetailMng(this.conn).UpdateUsersManagerByPIC(lblUID.Text, cmbManagersUID.Text);

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
                else
                {
                    Application.OpenForms["frm_UserManagementPanel"].BringToFront();
                    this.Close();
                }

            }

            //Access Details
            if (metroRadioButtonAccessDetails.Checked == true)
            {
                string uUID = lblUID.Text;

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
                    new UserManagementHeaderMng(this.conn).UpdateUserAccessLevel(uUID, cmbSystemAccess.Text);

                    MetroFramework.MetroMessageBox.Show(this, "\nUser system access has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.OpenForms["frm_UserManagementPanel"].BringToFront();

                    this.Close();
                }

            }

            //Access Details
            if (metroRadioButtonShiftDetails.Checked == true)
            {
                string uUID = lblUID.Text;


                if (lblIDLEMessage.Visible)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease fix the conflict of shift time.", "Invalid Shift!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerTaskOut.Focus();
                    return;
                }

                DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to modify shift details of user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {

                    string sShift = dateTimePickerTaskIn.Value.ToString("hh:mm tt") + " to " + dateTimePickerTaskOut.Value.ToString("hh:mm tt");

                    new UserManagementHeaderMng(this.conn).UpdateUserShiftDetails(uUID, sShift);

                    MetroFramework.MetroMessageBox.Show(this, "\nUser shift details has been updated!", "Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.OpenForms["frm_UserManagementPanel"].BringToFront();

                    this.Close();
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

        private void chkModifyImmediateManager_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModifyImmediateManager.Checked == true)
            {
                chkModifyPassword.Enabled = false;
                txtNewName.Enabled = false;
                txtResourceID.Enabled = false;

            }
            else
            {
                chkModifyPassword.Enabled = true;
                txtNewName.Enabled = true;
                txtResourceID.Enabled = true;
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
