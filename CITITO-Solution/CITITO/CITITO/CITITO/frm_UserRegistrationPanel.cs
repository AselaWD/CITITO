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
using CITITO.BusinessControls;
using CITITO.BusinessServices;
using System.Data.SqlClient;
using System.Security.Cryptography;
using MetroFramework.Forms;

namespace CITITO
{
    public partial class frm_UserRegistrationPanel : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_UserRegistrationPanel _instance;
        public static frm_UserRegistrationPanel GetInstance(string mUID)
        {


            if (_instance == null || _instance.IsDisposed)
            {
                String uUID = mUID;

                _instance = new frm_UserRegistrationPanel(uUID);


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_UserRegistrationPanel(string mUID)
        {
            InitializeComponent();

            lblUID.Text = mUID;

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        private void frm_UserRegistrationPanel_Load(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();

            // Set the Format type and the CustomFormat string.
            dateTimePickerTaskIn.Format = DateTimePickerFormat.Time;
            dateTimePickerTaskIn.CustomFormat = "hh:mm tt";
            dateTimePickerTaskIn.ShowUpDown = true;

            dateTimePickerTaskIn.Value = DateTime.Parse("07:00 AM");

            dateTimePickerTaskOut.Format = DateTimePickerFormat.Time;
            dateTimePickerTaskOut.CustomFormat = "hh:mm tt";
            dateTimePickerTaskOut.ShowUpDown = true;

            dateTimePickerTaskOut.Value = DateTime.Parse("4:00 PM");

        }

        //Selected index changed on Manager UID
        private void cmbManagersUID_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBoxProjects.DataSource = new ManagerDetailMng(this.conn).GetActiveProjectsByManage(cmbManagersUID.Text);
        }

        //Chack/Uncheck all
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                for (int index = 0; index < checkedListBoxProjects.Items.Count; ++index)
                {
                    checkedListBoxProjects.SetItemChecked(index, true);
                }
            }
            else
            {
                for (int index = 0; index < checkedListBoxProjects.Items.Count; ++index)
                {
                    checkedListBoxProjects.SetItemChecked(index, false);
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

        //Clear Object
        private void ClearFields()
        {
            RefreshData();

            //Clear All Fields when Load
            txtUID.Text = String.Empty;
            txtManagerName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtRePassword.Text = String.Empty;
            txtResourceId.Text = String.Empty;

            lblPasswordMessage.Visible = false;
            pBoxCorrect.Visible = false;
            pBoxError.Visible = false;
            lblErrorResourceID.Visible = false;

            cmbSystemAccess.SelectedIndex = -1;


            //Uncheck all items in check list
            for (int index = 0; index < checkedListBoxProjects.Items.Count; ++index)
            {
                checkedListBoxProjects.SetItemChecked(index, false);
            }

        }

        //Refresh Object
        private void RefreshData()
        {
            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(lblUID.Text))
            {
                cmbManagersUID.DataSource = new ManagerHeaderMng(this.conn).GetActiveManagerUIDByPIC(lblUID.Text);
                cmbManagersUID.SelectedIndex = -1;

                //Fill Datagridview
                dataGridViewUserRegister.DataSource = new UserManagementDetailMng(this.conn).GetAllUserDetailsByPIC(lblUID.Text.ToUpper());

                lblPICTemp.Text = lblUID.Text;

            }
            if (!new PICHeaderMng(this.conn).PICIsExist(lblUID.Text) && new ManagerHeaderMng(this.conn).ManagerIsExist(lblUID.Text))
            {
                cmbManagersUID.Items.Add(lblUID.Text);
                cmbManagersUID.SelectedIndex = 0;
                cmbManagersUID.Enabled = false;

                //Fill Project List
                checkedListBoxProjects.DataSource = new ManagerDetailMng(this.conn).GetActiveProjectsByManage(lblUID.Text);

                //Fill Datagridview
                dataGridViewUserRegister.DataSource = new UserManagementDetailMng(this.conn).GetAllUserDetailsByManager(cmbManagersUID.Text.ToUpper());

                lblPICTemp.Text = new ManagerDetailMng(this.conn).GetManagerNameByUID(cmbManagersUID.Text);
            }

            cmbSystemAccess.DataSource = new SystemAccessLevelMng(this.conn).GetAccessLevelsForUserAndDCD();

        }

        //UID filter
        private void txtUID_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUID.Text))
            {
                dataGridViewUserRegister.DataSource = new UserManagementDetailMng(this.conn).GetAllUserDetailsByPICANDPID(lblPICTemp.Text.ToUpper(), txtUID.Text);
            }
            else
            {
                if (String.IsNullOrEmpty(txtUID.Text))
                {
                    cmbSystemAccess.SelectedIndex = -1;
                }
                else
                {
                    RefreshData();
                }

            }
            
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //Add User
        private void btnAddManager_Click(object sender, EventArgs e)
        {
            //Validate Fields is null or empty
            PTR_QA_StdRatesMng mPTR_QA_StdRatesMng = new PTR_QA_StdRatesMng(this.conn);

            if (String.IsNullOrEmpty(txtResourceId.Text) || !mPTR_QA_StdRatesMng.IsExistPTRResourceRecord(txtResourceId.Text))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nEmpty or invalid Resource ID.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResourceId.Focus();
                return;
            }

            if ((txtUID.Text.ToUpper().Length) != 3)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID standard character length is 3. Please enter correct length.", "User ID Name Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            if ((txtUID.Text.ToUpper().Length) > 3)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID standard character length is 3. Please enter correct length.", "User ID Name Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtUID.Text.ToUpper()))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID field cannot be empty..!", "User ID Name Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            if (new UserManagementHeaderMng(conn).UserIsExist(txtUID.Text.ToUpper()))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID " + txtUID.Text.ToUpper() + " already exists under you or another manager.", "Manager Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtManagerName.Text))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nName field cannot be empty..!", "Name Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtManagerName.Focus();
                return;
            }
            if (lblPasswordMessage.Text != "Matched!")
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPasswords cannot be mismatched..!", "Mismatched Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            if (lblPasswordMessage.Text != "Matched!")
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPasswords cannot be mismatched..!", "Mismatched Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            if ((txtPassword.Text.Length) < 8)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPassword length should be more than 8 character.", "Invalid Password!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            if ((txtRePassword.Text.Length) < 8)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPassword length should be more than 8 character.", "Invalid Password!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRePassword.Focus();
                return;
            }
            if (String.IsNullOrEmpty(cmbManagersUID.Text))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease assign a manager.", "Manager Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbManagersUID.Focus();
                return;
            }

            if (checkedListBoxProjects.CheckedItems.Count == 0)
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select at least one project.", "Project Not Selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkedListBoxProjects.Focus();
                return;
            }

            if (lblIDLEMessage.Visible)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease fix the conflict of shift time.", "Invalid Shift!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerTaskOut.Focus();
                return;
            }

            //DialogResult resulta =MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to add new user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (resulta == DialogResult.Yes)
            //{
                if (new UserManagementHeaderMng(conn).UserIsExistWithInactive(txtUID.Text.ToUpper()))
                {
                    //Create Object From User
                    UserManagementHeader mUserManagementHeader = new UserManagementHeader();
                    UserManagementDetail mUserManagementDetail = new UserManagementDetail();

                    using (MD5 md5Hash = MD5.Create())
                    {
                        // Assign User Header
                        mUserManagementHeader.P_UID = txtUID.Text.ToUpper();
                        mUserManagementHeader.P_Name = txtManagerName.Text;
                        txtPassword.Text = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);
                        mUserManagementHeader.P_Password = txtPassword.Text;
                        mUserManagementHeader.P_AccessLevel = cmbSystemAccess.Text;
                        mUserManagementHeader.P_Availability = 1;
                        mUserManagementHeader.P_Activate_Date = DateTime.Now;
                        mUserManagementHeader.P_Shift = dateTimePickerTaskIn.Value.ToString("hh:mm tt")+ " to " + dateTimePickerTaskOut.Value.ToString("hh:mm tt");
                        mUserManagementHeader.PTR_Resources = txtResourceId.Text;


                    }
                    UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(conn);
                    UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(conn);


                    if (mUserManagementHeaderMng.UpdateUserNameWithAllDetails(mUserManagementHeader) > 0)
                    {
                        //Assign User Interface data to User Object
                        // Assign User Detail
                        mUserManagementDetail.P_UID = txtUID.Text.ToUpper();
                        mUserManagementDetail.P_Project_Availability = "Active";
                        mUserManagementDetail.P_Activate_Date = DateTime.Now;
                        mUserManagementDetail.M_UID = cmbManagersUID.Text.ToUpper();
                        mUserManagementDetail.PIC_UID = lblPICTemp.Text.ToUpper();


                        for (int i = 0; i < checkedListBoxProjects.Items.Count; i++)
                        {
                            if (checkedListBoxProjects.GetItemChecked(i))
                            {
                                //MessageBox.Show(checkedListBoxTaskCode.Items[i].ToString());
                                string cProjectName = checkedListBoxProjects.Items[i].ToString();

                                mUserManagementDetail.P_Project = cProjectName;

                                if (mUserManagementDetailMng.AddUserManagementDetail(mUserManagementDetail) > 0)
                                {

                                }
                            }
                        }

                       MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nNew user " + mUserManagementDetail.P_UID + " has been registered..!", "New User Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshData();
                        ClearFields();
                    }

                }
                else
                {
                    //Create Object From User
                    UserManagementHeader mUserManagementHeader = new UserManagementHeader();
                    UserManagementDetail mUserManagementDetail = new UserManagementDetail();

                    using (MD5 md5Hash = MD5.Create())
                    {
                        
                        // Assign User Header
                        mUserManagementHeader.P_UID = txtUID.Text.ToUpper();
                        mUserManagementHeader.P_Name = txtManagerName.Text;
                        txtPassword.Text = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);
                        mUserManagementHeader.P_Password = txtPassword.Text;
                        mUserManagementHeader.P_AccessLevel = cmbSystemAccess.Text;
                        mUserManagementHeader.P_Availability = 1;
                        mUserManagementHeader.P_Activate_Date = DateTime.Now;
                        mUserManagementHeader.P_Shift = dateTimePickerTaskIn.Value.ToString("hh:mm tt") + " to " + dateTimePickerTaskOut.Value.ToString("hh:mm tt");
                        mUserManagementHeader.PTR_Resources = txtResourceId.Text;


                }
                    UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(conn);
                    UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(conn);


                    if (mUserManagementHeaderMng.AddUserManagementHeader(mUserManagementHeader) > 0)
                    {
                        //Assign User Interface data to User Object
                        // Assign PIC Detail
                        mUserManagementDetail.P_UID = txtUID.Text.ToUpper();
                        mUserManagementDetail.P_Project_Availability = "Active";
                        mUserManagementDetail.P_Activate_Date = DateTime.Now;
                        mUserManagementDetail.M_UID = cmbManagersUID.Text.ToUpper();
                        mUserManagementDetail.PIC_UID = lblPICTemp.Text.ToUpper();


                        for (int i = 0; i < checkedListBoxProjects.Items.Count; i++)
                        {
                            if (checkedListBoxProjects.GetItemChecked(i))
                            {
                                //MessageBox.Show(checkedListBoxTaskCode.Items[i].ToString());
                                string cProjectName = checkedListBoxProjects.Items[i].ToString();

                                mUserManagementDetail.P_Project = cProjectName;

                                if (mUserManagementDetailMng.AddUserManagementDetail(mUserManagementDetail) > 0)
                                {

                                }
                            }
                        }

                       MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nNew user " + mUserManagementDetail.P_UID + " has been registered..!", "New User Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshData();
                        ClearFields();
                    }

                }

            //}
        }

        //Modify button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Validate Fields is null or empty
            if (String.IsNullOrEmpty(txtUID.Text))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID field cannot be empty..!", "User ID Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            if (new UserManagementHeaderMng(conn).UserIsExistWithInactive(txtUID.Text.ToUpper()))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID " + txtUID.Text.ToUpper() + " is not found!", "User ID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            
            else
            {
                //Manager permissions
                if (lblUID.Text==cmbManagersUID.Text)
                {
                    if (!new UserManagementHeaderMng(conn).UserIsExistUnderManager(txtUID.Text.ToUpper(), lblUID.Text.ToUpper(), lblPICTemp.Text.ToUpper()))
                    {
                       MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID " + txtUID.Text.ToUpper() + " is not found!", "User ID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUID.Focus();
                        return;
                    }

                    frm_UserModifyByManager form = frm_UserModifyByManager.GetInstance(txtUID.Text.ToUpper(), cmbManagersUID.Text.ToUpper(), lblPICTemp.Text.ToUpper());

                    if (!form.Visible)
                    {

                        form.Show();
                    }
                    else
                    {
                        form.BringToFront();
                    }
                }
                //PIC permissions
                if (lblUID.Text == lblPICTemp.Text)
                {
                    string uManager = new UserManagementHeaderMng(this.conn).GetManagerByUID(txtUID.Text.ToUpper(),lblPICTemp.Text);

                    if (!new UserManagementHeaderMng(conn).UserIsExistUnderPIC(txtUID.Text.ToUpper(), lblPICTemp.Text.ToUpper()))
                    {
                       MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID " + txtUID.Text.ToUpper() + " is not found!", "User ID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUID.Focus();
                        return;
                    }

                    frm_UserModifyByPIC form = frm_UserModifyByPIC.GetInstance(txtUID.Text.ToUpper(), uManager, lblPICTemp.Text.ToUpper());

                    if (!form.Visible)
                    {

                        form.Show();
                    }
                    else
                    {
                        form.BringToFront();
                    }
                }


            }
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Activated
        private void frm_UserRegistrationPanel_Activated(object sender, EventArgs e)
        {
            RefreshData();
        }

        //Update UID txtbox once click datagridview Cell
        private void dataGridViewManagerRegister_Click(object sender, EventArgs e)
        {
            txtUID.Text = dataGridViewUserRegister.SelectedRows[0].Cells[0].Value.ToString();
        }

        //Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Validate Fields is null or empty
            if (String.IsNullOrEmpty(txtUID.Text))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID field cannot be empty..!", "User ID Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            if (new UserManagementHeaderMng(conn).UserIsExistWithInactive(txtUID.Text.ToUpper()))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID " + txtUID.Text.ToUpper() + " is not found!", "User ID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            else
            {

                DialogResult resulta =MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to delete user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {

                    UserManagementDetail mUserManagementDetail = new UserManagementDetail();

                    mUserManagementDetail.P_UID = txtUID.Text.ToUpper();
                    mUserManagementDetail.P_Inactivate_Date = DateTime.Now;

                    UserManagementHeader mUserManagementHeader = new UserManagementHeader();

                    mUserManagementHeader.P_UID = txtUID.Text.ToUpper();
                    mUserManagementHeader.P_Inactivate_Date = DateTime.Now;


                    UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);
                    UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);


                    if (mUserManagementDetailMng.UpdateUserAsInactive(mUserManagementDetail) > 0)
                    {

                        mUserManagementHeaderMng.UpdateUserAsInactive(mUserManagementHeader);

                       MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser " + mUserManagementDetail.P_UID + " has been deleted..!", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshData();
                        ClearFields();
                    }
                }              
                
            }
        }

        //Refresh button
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }

        //Exit button
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        //User Bulk Import
        private void metroButton1_Click(object sender, EventArgs e)
        {
            //MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThis is under construction.", "Bulk User Registration!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string uMUID = lblUID.Text;
            string uPIC = lblPICTemp.Text;

            //Form Open by PIC System Access Level

            frm_BulkImport_UserRegistration form = frm_BulkImport_UserRegistration.GetInstance(uMUID, uPIC);
            if (!form.Visible)
            {

                form.Show();

            }
            else
            {
                form.BringToFront();
            }
        }

        private void txtUID_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUID.Text))
            {
                cmbSystemAccess.SelectedIndex = -1;
            }
        }

        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewUserRegister.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewUserRegister.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        if (ex.HResult == -2147024809)
                        {
                            //cell.Value = DateTime.ParseExact(cell.Value.ToString(), "dd MM yyyy hh:mm:ss tt", null);
                        }

                    }


                }
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.Title = "Export Excel Files";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = false;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "All files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;


                try
                {
                    //Exporting to Excel           

                    if (!System.IO.File.Exists(fileName))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(fileName))
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "CITITO_" + lblUID.Text + "_User Details");
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser details successfully export to \"" + fileName + "\".", "Manager Details Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "CITITO_" + lblUID.Text + "_User Details");
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser details successfully export to \"" + fileName + "\" path.", "Manager Details Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2147024864)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile is already opened in another programme.", "Application Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }               

            }
        }

        private void frm_UserRegistrationPanel_Enter(object sender, EventArgs e)
        {
            RefreshData();
            //ClearFields();
        }

        private void dateTimePickerTaskIn_ValueChanged(object sender, EventArgs e)
        {
            //Time Calculation
            TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;

            double hours = diff.TotalHours;

            var time = Math.Round(hours, 3);

            if (time <= 0)
            {

                lblIDLEMessage.Visible = true;
                lblIDLEMessage.Text = "Shift-out time is earlier than shift-in time. Please correct!";

            }
            else
            {

                lblIDLEMessage.Visible = false;
                lblIDLEMessage.Text = "";
            }
        }

        private void dateTimePickerTaskOut_ValueChanged(object sender, EventArgs e)
        {
            //Time Calculation
            TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;

            double hours = diff.TotalHours;

            var time = Math.Round(hours, 3);

            if (time <= 0)
            {

                lblIDLEMessage.Visible = true;
                lblIDLEMessage.Text = "Shift-out time is earlier than shift-in time. Please correct!";

            }
            else
            {

                lblIDLEMessage.Visible = false;
                lblIDLEMessage.Text = "";
            }
        }

        private void metroTextBox1_Leave(object sender, EventArgs e)
        {
            //validate entred resource Code

            PTR_QA_StdRatesMng mPTR_QA_StdRatesMng = new PTR_QA_StdRatesMng(this.conn);

            if (!mPTR_QA_StdRatesMng.IsExistPTRResourceRecord(txtResourceId.Text))
            {
                lblErrorResourceID.Visible = true;
                lblErrorResourceID.Text = "Invalid Resource ID. \"View Resource ID List\" for more details.";
            }
            else
            {
                lblErrorResourceID.Visible = false;
            }
        }

        //View resource Code List
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

        private void txtResourceId_TextChanged(object sender, EventArgs e)
        {
            //validate entred resource Code

            PTR_QA_StdRatesMng mPTR_QA_StdRatesMng = new PTR_QA_StdRatesMng(this.conn);

            if (!mPTR_QA_StdRatesMng.IsExistPTRResourceRecord(txtResourceId.Text))
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
