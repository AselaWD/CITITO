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
    public partial class frm_ManagerRegisterPanel : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_ManagerRegisterPanel _instance;
        public static frm_ManagerRegisterPanel GetInstance(string mUID, string mName, DateTime mTime)
        {


            if (_instance == null || _instance.IsDisposed)
            {
                String uUID = mUID;
                String uName = mName;
                DateTime uTime = mTime;

                _instance = new frm_ManagerRegisterPanel(uUID, uName, uTime);


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_ManagerRegisterPanel(string mUID, string mName, DateTime mTime)
        {
            InitializeComponent();

            lblUID.Text = mUID;
            lblManagerName.Text = mName;
            lblTime.Text = mTime.ToString();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        private void frm_ManagerRegisterPanel_Load(object sender, EventArgs e)
        {

            Activate();

            //Refresh data fields
            RefreshData();

            //Clear All Fields when Load
            ClearFields();

            
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

            lblPasswordMessage.Visible = false;
            pBoxCorrect.Visible = false;
            pBoxError.Visible = false;


            //Uncheck all items in check list
            for (int index = 0; index < checkedListBoxProjects.Items.Count; ++index)
            {
                checkedListBoxProjects.SetItemChecked(index, false);
            }

            cmbSystemAccess.SelectedIndex = -1;

        }

        //Refresh Object
        private void RefreshData()
        {
            checkedListBoxProjects.DataSource = new ProjectDetailMng(this.conn).GetAllProjects(lblUID.Text.ToUpper());
            dataGridViewManagerRegister.DataSource = new ManagerDetailMng(this.conn).GetAllManagerDetailsByPIC(lblUID.Text.ToUpper());
            cmbSystemAccess.DataSource = new SystemAccessLevelMng(this.conn).GetAccessLevelsForManagerAndDCD();

        }


        //Check All
        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
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

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Referesh when form activated
        private void frm_ManagerRegisterPanel_Activated(object sender, EventArgs e)
        {
            RefreshData();
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

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //Add Manager
        private void btnAddManager_Click(object sender, EventArgs e)
        {
            //Validate Fields is null or empty
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
            if (new ManagerHeaderMng(conn).ManagerIsExist(txtUID.Text.ToUpper()))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID " + txtUID.Text.ToUpper() + " already exists under you or another PIC.", "Manager Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            if (new PICHeaderMng(conn).PICIsExist(txtUID.Text.ToUpper()))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID " + txtUID.Text.ToUpper() + " already exists as a PIC.", "UID Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (checkedListBoxProjects.CheckedItems.Count==0)
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select at least one project.","Project Not Selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkedListBoxProjects.Focus();
                return;
            }

            //DialogResult resulta =MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to add new manager?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (resulta == DialogResult.Yes)
            //{
                if (new ManagerHeaderMng(conn).ManagerIsExistWithInactive(txtUID.Text.ToUpper()))
                {
                    //Create Object From Manager
                    ManagerHeader mManagerHeader = new ManagerHeader();
                    ManagerDetail mManagerDetail = new ManagerDetail();

                    using (MD5 md5Hash = MD5.Create())
                    {
                        // Assign PIC Header
                        mManagerHeader.M_UID = txtUID.Text.ToUpper();
                        mManagerHeader.M_Name = txtManagerName.Text;
                        txtPassword.Text = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);
                        mManagerHeader.M_Password = txtPassword.Text;
                        //mManagerHeader.M_AccessLevel = "Immediate Manager";
                       mManagerHeader.M_AccessLevel = cmbSystemAccess.Text;//Amended with DCD
                        mManagerHeader.M_Availability = 1;
                        mManagerHeader.M_Activate_Date = DateTime.Now;


                    }
                    ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(conn);
                    ManagerDetailMng mManagerDetailMng = new ManagerDetailMng(conn);

                    
                    if (mManagerHeaderMng.UpdateManagerNameWithAllDetails(mManagerHeader) > 0)
                    {
                        //Assign User Interface data to User Object
                        // Assign PIC Detail
                        mManagerDetail.M_UID = txtUID.Text.ToUpper();
                        mManagerDetail.M_Project_Availability = "Active";
                        mManagerDetail.M_Activate_Date = DateTime.Now;
                        mManagerDetail.PIC_UID = lblUID.Text.ToUpper();


                        for (int i = 0; i < checkedListBoxProjects.Items.Count; i++)
                        {
                            if (checkedListBoxProjects.GetItemChecked(i))
                            {
                                //MessageBox.Show(checkedListBoxTaskCode.Items[i].ToString());
                                string cProjectName = checkedListBoxProjects.Items[i].ToString();

                                mManagerDetail.M_Project = cProjectName;

                                if (mManagerDetailMng.AddManagerDetail(mManagerDetail) > 0)
                                {
                                    
                                }
                            }
                        }

                       MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nNew manager " + mManagerHeader.M_UID + " has been registered..!", "New Manager Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshData();
                        ClearFields();
                    }
                }
                else
                {
                    //Create Object From Manager
                    ManagerHeader mManagerHeader = new ManagerHeader();
                    ManagerDetail mManagerDetail = new ManagerDetail();

                    using (MD5 md5Hash = MD5.Create())
                    {
                        // Assign PIC Header
                        mManagerHeader.M_UID = txtUID.Text.ToUpper();
                        mManagerHeader.M_Name = txtManagerName.Text;
                        txtPassword.Text = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);
                        mManagerHeader.M_Password = txtPassword.Text;
                        //mManagerHeader.M_AccessLevel = "Immediate Manager";
                        mManagerHeader.M_AccessLevel = cmbSystemAccess.Text;//Amended with DCD
                        mManagerHeader.M_Availability = 1;
                        mManagerHeader.M_Activate_Date = DateTime.Now;


                    }
                    ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(conn);
                    ManagerDetailMng mManagerDetailMng = new ManagerDetailMng(conn);


                    if (mManagerHeaderMng.AddManagerHeader(mManagerHeader) > 0)
                    {
                        //Assign User Interface data to User Object
                        // Assign PIC Detail
                        mManagerDetail.M_UID = txtUID.Text.ToUpper();
                        mManagerDetail.M_Project_Availability = "Active";
                        mManagerDetail.M_Activate_Date = DateTime.Now;
                        mManagerDetail.PIC_UID = lblUID.Text.ToUpper();


                        for (int i = 0; i < checkedListBoxProjects.Items.Count; i++)
                        {
                            if (checkedListBoxProjects.GetItemChecked(i))
                            {
                                //MessageBox.Show(checkedListBoxTaskCode.Items[i].ToString());
                                string cProjectName = checkedListBoxProjects.Items[i].ToString();

                                mManagerDetail.M_Project = cProjectName;

                                if (mManagerDetailMng.AddManagerDetail(mManagerDetail) > 0)
                                {

                                }
                            }
                        }

                       MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nNew manager " + mManagerHeader.M_UID + " has been registered..!", "New Manager Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshData();
                        ClearFields();
                    }

                }

           // }
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

            if (!new ManagerHeaderMng(conn).ManagerIsExistUnderPIC(lblUID.Text.ToUpper(), txtUID.Text.ToUpper()))
            {

               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID " + txtUID.Text.ToUpper() + " is not found!", "User ID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            if (new ManagerHeaderMng(conn).ManagerIsExistWithInactive(txtUID.Text.ToUpper()))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID " + txtUID.Text.ToUpper() + " is not found!", "User ID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            else
            {
                frm_ManagerModify form = frm_ManagerModify.GetInstance(lblUID.Text.ToUpper(), txtUID.Text.ToUpper());

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

        //Update UID txtbox once click datagridview Cell
        private void dataGridViewManagerRegister_Click(object sender, EventArgs e)
        {
            txtUID.Text = dataGridViewManagerRegister.SelectedRows[0].Cells[0].Value.ToString();
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
            if (new ManagerHeaderMng(conn).ManagerIsExistWithInactive(txtUID.Text.ToUpper()))
            {
               MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser ID " + txtUID.Text.ToUpper() + " is not found!", "User ID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            else
            {
                DialogResult resulta =MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to delete manager?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    ManagerHeader mManagerHeader = new ManagerHeader();

                    mManagerHeader.M_UID = txtUID.Text.ToUpper();
                    mManagerHeader.M_Inactivate_Date = DateTime.Now;

                    ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);
                    ManagerDetailMng mManagerDetailMng = new ManagerDetailMng(this.conn);
                    UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);

                    if (mUserManagementDetailMng.ActiveUserIsExistOnDeletedManager(txtUID.Text.ToUpper(), lblUID.Text.ToUpper()))
                    {
                        string uManager = txtUID.Text.ToUpper();
                        string uPIC = lblUID.Text.ToUpper();

                        frm_AssignUsersToManager form = new frm_AssignUsersToManager(uManager, uPIC);

                        if (!form.Visible)
                        {

                            form.Show();
                        }
                        else
                        {
                            form.BringToFront();
                        }
                    }
                    else
                    {
                        if (mManagerHeaderMng.UpdateManagerAsInactive(mManagerHeader) > 0)
                        {
                            
                            mManagerDetailMng.UpdateManagerProjectToInactiveByManagerID(txtUID.Text.ToUpper(), mManagerHeader.M_Inactivate_Date);

                           MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nManager " + mManagerHeader.M_UID + " has been deleted..!", "Manager Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshData();
                            ClearFields();
                        }
                    }
                }

            }
        }

        //Refresh
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }

        //UID filter
        private void txtUID_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUID.Text))
            {
                dataGridViewManagerRegister.DataSource = new ManagerDetailMng(this.conn).GetAllManagerDetailsByPICANDMID(lblUID.Text.ToUpper(), txtUID.Text);
            }
            else
            {
                RefreshData();
            }
        }

        //Exit button
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        //Export button
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewManagerRegister.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewManagerRegister.Rows)
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

                //Exporting to Excel           
                try
                {
                    if (!System.IO.File.Exists(fileName))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(fileName))
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "CITITO_" + lblUID.Text + "_Manager Details");
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nManager details successfully export to \"" + fileName + "\".", "Manager Details Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "CITITO_" + lblUID.Text + "_Manager Details");
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nManager details successfully export to \"" + fileName + "\" path.", "Manager Details Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
