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
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;

namespace CITITO
{
    public partial class frm_ProjectRegisterPanel : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_ProjectRegisterPanel _instance;
        public static frm_ProjectRegisterPanel GetInstance(string uUID, string uName)
        {


            if (_instance == null || _instance.IsDisposed)
            {
                string mUID = uUID;
                string mName = uName;

                _instance = new frm_ProjectRegisterPanel(mUID, mName);


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_ProjectRegisterPanel(string uUID, string uName)
        {
            InitializeComponent();

            lblUID.Text = uUID;
            lblManagerName.Text = uName;

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        private void frm_DepartmentRegisterPanel_Load(object sender, EventArgs e)
        {
            //Refresh data fields
            RefreshData();

            //cmbProjectName.DataSource = new UserDepartmentMng(this.conn).GetAllDepartment();

            //Clear All Fields when Load
            ClearFields();


            // Initialize the button column.
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Text = "Remove";
            buttonColumn.AutoSizeMode =
            DataGridViewAutoSizeColumnMode.AllCells;

            // Use the Text property for the button text for all cells rather
            // than using each cell's value as the text for its own button.
            buttonColumn.UseColumnTextForButtonValue = true;

            // Add the button column to the control.
            dataGridViewDepartmentRegister.Columns.Insert(0, buttonColumn);


            //Change remove column to last-child
            DataGridViewColumnCollection columnCollection = dataGridViewDepartmentRegister.Columns;

            DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
            DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

            int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
            firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
            //lastVisibleColumn.DisplayIndex = firstColumn_sIndex;


        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //Close button
        private void pboxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //Minimize button
        private void pboxMinimize_Click(object sender, EventArgs e)
        {
            //minimize window
            this.WindowState = FormWindowState.Minimized;
        }

        //Start >> frm_UserManagement enable move using mouse left down

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Form movement        
        private void frm_DepartmentRegisterPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //End >> frm_UserManagement enable move using mouse left down


        //Refresh Object
        private void RefreshData()
        {
            //cmbProjectName.DataSource = new UserDepartmentMng(this.conn).GetAllDepartment();
            dataGridViewDepartmentRegister.DataSource = new ProjectDetailMng(this.conn).GetAllProjectDetailsByPIC(lblUID.Text.ToUpper());

        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();
            //Clear All Fields when Load
            cmbProjectName.Text = String.Empty;
            txtProcessName.Text = String.Empty;
            cmbProjectName.ReadOnly = false;
            cmbProjectName.Enabled = true;
            chkQA.Checked = false;
            chkQA.Enabled = true;
            chkOutputValidation.Checked = false;

            dataGridViewProcessCode.Rows.Clear();
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }

        //Add button
        private void btnAddProject_Click(object sender, EventArgs e)
        {
            //Add new Project 
            //Validate Fields is null or empty
            if (String.IsNullOrEmpty(cmbProjectName.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject name field cannot be empty..!", "Project Name Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }

            if (dataGridViewProcessCode.Rows.Count==0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess code(s) not found in \"Proccess Code List\".\nPlease add to list first.", "Process Codes Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }

            if (cmbProjectName.Text.ToUpper().Length != 5)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject name strandard lenght is 5 characters.\nPlease enter valid cheracter length for project name.", "Invalid Character Length!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }
            if (txtProcessName.Text.ToUpper().Length <= 5)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess code lenght shuld be at more than 5 characters.\nPlease enter valid cheracter length for process code.", "Invalid Character Length!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcessName.Focus();
                return;
            }

            //DialogResult resulta = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to add new project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (resulta == DialogResult.Yes)
            //{
                //IF QA project
                if (chkQA.Checked)
                {
                    
                    string QAProject = cmbProjectName.Text.ToUpper() + "QA";
                    if (new ProjectDetailMng(conn).ProjectDetailIsExist(QAProject, lblUID.Text))
                    {
                        try
                        {
                            //Create Object From Userdepartmets
                            ProcessCodeHeader mProcessCodeHeader = new ProcessCodeHeader();
                            ProcessCodeHeaderMng mProcessCodeHeaderMng = new ProcessCodeHeaderMng(conn);

                            //Loop until total Shipment File Count Registerd into the ShipmentDetails Tabele
                            for (int i = 0; i < dataGridViewProcessCode.Rows.Count; i++)
                            {
                                //Assign ProcessCodeHeader Interface data
                                mProcessCodeHeader.PIC_Project = QAProject;
                                mProcessCodeHeader.PC_ProcessCode = dataGridViewProcessCode.Rows[i].Cells[1].Value.ToString();
                                mProcessCodeHeader.PIC_UID = lblUID.Text;

                                if (mProcessCodeHeaderMng.AddProcessCode(mProcessCodeHeader) > 0)
                                {

                                }

                            }

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nNew Proccess code(s) added to the existing project name \"" + QAProject + "\".", "New Project Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshData();
                            ClearFields();
                        }
                        catch (Exception ex)
                        {
                            if (ex.HResult == -2146233079)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject \"" + QAProject + "\" is already registered!", "Project Already Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbProjectName.Focus();
                                return;
                            }
                            if (ex.HResult == -2146232060)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject \"" + QAProject + "\" is already registered!", "Project Already Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbProjectName.Focus();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    else
                    {
                        try
                        {
                            //Create Object From Userdepartmets
                            ProjectDetail mProjectDetail = new ProjectDetail();
                            ProcessCodeHeader mProcessCodeHeader = new ProcessCodeHeader();

                            // Assign ProjectDetail Interface data
                            mProjectDetail.ProjectName = QAProject;
                            mProjectDetail.PIC_UID = lblUID.Text;

                            //Avoid user output validation
                            if (chkOutputValidation.Checked)
                            {
                                /* 0 - No , 1 - Yes */
                                mProjectDetail.SkipOutputValidation = 1;
                            }
                            else
                            {
                                /* 0 - No , 1 - Yes */
                                mProjectDetail.SkipOutputValidation = 0;
                            }

                            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(conn);
                            ProcessCodeHeaderMng mProcessCodeHeaderMng = new ProcessCodeHeaderMng(conn);

                            if (mProjectDetailMng.AddProjectDetail(mProjectDetail) > 0)
                            {

                                //Loop until total Shipment File Count Registerd into the ShipmentDetails Tabele
                                for (int i = 0; i < dataGridViewProcessCode.Rows.Count; i++)
                                {
                                    //Assign ProcessCodeHeader Interface data
                                    mProcessCodeHeader.PIC_Project = QAProject;
                                    mProcessCodeHeader.PC_ProcessCode = dataGridViewProcessCode.Rows[i].Cells[1].Value.ToString();
                                    mProcessCodeHeader.PIC_UID = lblUID.Text;

                                    if (mProcessCodeHeaderMng.AddProcessCode(mProcessCodeHeader) > 0)
                                    {

                                    }

                                }

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nNew project \"" + QAProject + "\" has been registered..!", "New Project Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshData();
                                ClearFields();
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex.HResult == -2146233079)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject \"" + QAProject + "\" is already registered!", "Project Already Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbProjectName.Focus();
                                return;
                            }
                            if (ex.HResult == -2146232060)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject \"" + QAProject + "\" is already registered!", "Project Already Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbProjectName.Focus();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                }
                else
                {
                    if (new ProjectDetailMng(conn).ProjectDetailIsExist(cmbProjectName.Text.ToUpper(), lblUID.Text))
                    {
                        try
                        {
                            //Create Object From Userdepartmets
                            ProcessCodeHeader mProcessCodeHeader = new ProcessCodeHeader();
                            ProcessCodeHeaderMng mProcessCodeHeaderMng = new ProcessCodeHeaderMng(conn);

                            //Loop until total Shipment File Count Registerd into the ShipmentDetails Tabele
                            for (int i = 0; i < dataGridViewProcessCode.Rows.Count; i++)
                            {
                                //Assign ProcessCodeHeader Interface data
                                mProcessCodeHeader.PIC_Project = cmbProjectName.Text.ToUpper();
                                mProcessCodeHeader.PC_ProcessCode = dataGridViewProcessCode.Rows[i].Cells[1].Value.ToString();
                                mProcessCodeHeader.PIC_UID = lblUID.Text;

                                if (mProcessCodeHeaderMng.AddProcessCode(mProcessCodeHeader) > 0)
                                {

                                }

                            }

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nNew Proccess code(s) added to the existing project name \"" + cmbProjectName.Text.ToUpper() + "\".", "New Project Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshData();
                            ClearFields();
                        }
                        catch (Exception ex)
                        {
                            if (ex.HResult == -2146233079)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject \"" + cmbProjectName.Text + "\" is already registered!", "Project Already Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbProjectName.Focus();
                                return;
                            }
                            if (ex.HResult == -2146232060)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject \"" + cmbProjectName.Text + "\" is already registered!", "Project Already Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbProjectName.Focus();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    else
                    {
                        try
                        {
                            //Create Object From Userdepartmets
                            ProjectDetail mProjectDetail = new ProjectDetail();
                            ProcessCodeHeader mProcessCodeHeader = new ProcessCodeHeader();

                            // Assign ProjectDetail Interface data
                            mProjectDetail.ProjectName = cmbProjectName.Text.ToUpper();
                            mProjectDetail.PIC_UID = lblUID.Text;

                            //Avoid user output validation
                            if (chkOutputValidation.Checked)
                            {
                                /* 0 - No , 1 - Yes */
                                mProjectDetail.SkipOutputValidation = 1;
                            }
                            else
                            {
                                /* 0 - No , 1 - Yes */
                                mProjectDetail.SkipOutputValidation = 0;
                            }

                            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(conn);
                            ProcessCodeHeaderMng mProcessCodeHeaderMng = new ProcessCodeHeaderMng(conn);

                            if (mProjectDetailMng.AddProjectDetail(mProjectDetail) > 0)
                            {

                                //Loop until total Shipment File Count Registerd into the ShipmentDetails Tabele
                                for (int i = 0; i < dataGridViewProcessCode.Rows.Count; i++)
                                {
                                    //Assign ProcessCodeHeader Interface data
                                    mProcessCodeHeader.PIC_Project = cmbProjectName.Text.ToUpper();
                                    mProcessCodeHeader.PC_ProcessCode = dataGridViewProcessCode.Rows[i].Cells[1].Value.ToString();
                                    mProcessCodeHeader.PIC_UID = lblUID.Text;

                                    if (mProcessCodeHeaderMng.AddProcessCode(mProcessCodeHeader) > 0)
                                    {

                                    }

                                }

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nNew project \"" + cmbProjectName.Text.ToUpper() + "\" has been registered..!", "New Project Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshData();
                                ClearFields();
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex.HResult == -2146233079)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject \"" + cmbProjectName.Text + "\" is already registered!", "Project Already Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbProjectName.Focus();
                                return;
                            }
                            if (ex.HResult == -2146232060)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject \"" + cmbProjectName.Text + "\" is already registered!", "Project Already Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbProjectName.Focus();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                }

            //}
        }

        ////Modify button
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(cmbProjectName.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject name field cannot be empty..!\nPlease select a project name.", "Project Not Selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }
            if (!new ProjectDetailMng(conn).ProjectDetailIsExist(cmbProjectName.Text.ToUpper(), lblUID.Text))
            {

                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject " + cmbProjectName.Text.ToUpper() + " is not found.", "Project No Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }

            else
            {
                int cCheck = new ProjectDetailMng(this.conn).GetProjectOutputValidation(cmbProjectName.Text.ToUpper(), lblUID.Text.ToUpper());

                frm_ProjectModify frmMofidy = new frm_ProjectModify(cmbProjectName.Text.ToUpper(), txtProcessName.Text.ToUpper(), lblUID.Text.ToUpper(), cCheck);
                frmMofidy.Show();
            }

        }

        ////Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbProjectName.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject Name field cannot be empty..!\nPlease select a project name.", "Project Not Selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }
            if (!new ProjectDetailMng(conn).ProjectDetailIsExist(cmbProjectName.Text.ToUpper(), lblUID.Text))
            {

                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject " + cmbProjectName.Text.ToUpper() + " is not found.", "Project No Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }
            else
            {

             DialogResult resulta = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to delete " + cmbProjectName.Text.ToUpper() + " project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    try
                    {
                        ProjectDetail mProjectDetail = new ProjectDetail();

                        ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(conn);

                        //Initialize
                        mProjectDetail.ProjectName = cmbProjectName.Text;
                        mProjectDetail.PIC_UID = lblUID.Text;

                        if (mProjectDetailMng.DeleteProjectDetail(mProjectDetail) > 0)
                        {

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject " + mProjectDetail.ProjectName + " has been deleted.", "Project Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshData();
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.HResult== -2146232060)
                        {
                            

                            String uPIC = lblUID.Text;
                            String uProject = cmbProjectName.Text;

                            if(new ManagerDetailMng(this.conn).GetUsersInDeletableProjectIsExist(cmbProjectName.Text))
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUsers are already registred under " + uProject + " project. Only user can be assigned to the another project.", "Active Project!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                frm_AssignManager form = frm_AssignManager.GetInstance(uPIC, uProject);
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
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\n" + uProject + " project is currently active. You cannot be deleted.", "Active Project!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                        else
                        {
                            MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }

        }

        //Reset back color
        private void cmbProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProjectName.BackColor = Control.DefaultBackColor;
        }

        private void cmbProjectName_TextChanged(object sender, EventArgs e)
        {
            cmbProjectName.BackColor = Control.DefaultBackColor;
        }

        private void cmbProjectName_MouseClick(object sender, MouseEventArgs e)
        {
            cmbProjectName.BackColor = Control.DefaultBackColor;
        }

        //Refresh
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }

        //Filter Project name once project filed update
        private void cmbProjectName_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbProjectName.Text))
            {
                dataGridViewDepartmentRegister.DataSource = new ProjectDetailMng(this.conn).GetAllProjectDetailsByPICANDProjectName(lblUID.Text.ToUpper(), cmbProjectName.Text);
            }
            else {
                RefreshData();
            }

        }

        //Add Process Code button
        private void btnAddProcessCode_Click(object sender, EventArgs e)
        {
            //Validation
            if (String.IsNullOrEmpty(cmbProjectName.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject name field cannot be empty..!", "Project Name Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }

           
            if (cmbProjectName.Text.ToUpper().Length != 5)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject name strandard lenght is 5 characters.\nPlease enter valid cheracter length for project name.", "Invalid Character Length!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }
            if (cmbProjectName.Text.ToUpper().Length < 5)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject name strandard lenght is 5 characters.\nPlease enter valid cheracter length for project name.", "Invalid Character Length!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }

            if (txtProcessName.Text.ToUpper().Length != 8)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nItem Code strandard lenght is 8 characters. Please enter valid cheracter length for item code.\n Ex: \n" + cmbProjectName.Text + "CAK\n" + cmbProjectName.Text + "CAO", "Invalid Character Length!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcessName.Focus();
                return;
            }

            if (txtProcessName.Text.ToUpper().Length < 8)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nItem Code strandard lenght is 8 characters. Please enter valid cheracter length for item code.\n Ex: \n" + cmbProjectName.Text + "CAK\n" + cmbProjectName.Text + "CAO", "Invalid Character Length!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcessName.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtProcessName.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess name filed cannot be empty.", "Process Name Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcessName.Focus();
                return;
            }

            if (new ProjectDetailMng(this.conn).ProjectDetailIsExist(cmbProjectName.Text.ToUpper(), lblUID.Text.ToUpper()))
            {
                DialogResult resulta = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\n\"" + cmbProjectName.Text.ToUpper() + "\" project is already exist. Do you want to add process code under \"" + cmbProjectName.Text.ToUpper() + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridViewProcessCode.Rows.Count;)
                    {

                        foreach (DataGridViewRow row in dataGridViewProcessCode.Rows)
                        {
                            string s = row.Cells[1].Value.ToString().ToUpper();

                            if (txtProcessName.Text.ToUpper() == s)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess name is already exist!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtProcessName.Focus();
                                return;

                            }

                        }

                        //increment i
                        i = dataGridViewProcessCode.Rows.Count + 1;

                        dataGridViewProcessCode.Rows.Add(i, txtProcessName.Text.ToUpper(), "Remove");
                        dataGridViewProcessCode.Refresh();

                        //Lock Project Code
                        cmbProjectName.Enabled = false;
                        cmbProjectName.ReadOnly = true;
                        chkQA.Enabled = false;
                        return;
                    }
                    
                }
                else
                {
                    return;
                }

            }

            if (new ProjectDetailMng(this.conn).ProjectIsExistNotUnderPIC(cmbProjectName.Text, lblUID.Text) && chkQA.Checked == false)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject \"" + cmbProjectName.Text + "\" is already registered under another PIC!\nPlease enter a different project name.", "Project Already Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Enabled = true;
                cmbProjectName.Focus();
                return;
            }

            if (new ProcessCodeHeaderMng(this.conn).ProcessCodeIsExist(cmbProjectName.Text,txtProcessName.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess name is already exist under \""+ cmbProjectName.Text.ToUpper() + "\" project!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcessName.Focus();
                return;

            }

            else
            {

                if (dataGridViewProcessCode.Rows.Count == 0)
                {
                    
                    dataGridViewProcessCode.Rows.Add(1, txtProcessName.Text.ToUpper(), "Remove");
                    cmbProjectName.Enabled = false;
                    cmbProjectName.ReadOnly = true;
                    chkQA.Enabled = false;

                }
                else
                {
                    for (int i = 0; i < dataGridViewProcessCode.Rows.Count;)
                    {

                        foreach (DataGridViewRow row in dataGridViewProcessCode.Rows)
                        {
                            string s = row.Cells[1].Value.ToString().ToUpper();

                            if (txtProcessName.Text.ToUpper() == s)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess name is already exist!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtProcessName.Focus();
                                return;

                            }

                        }
                        //increment i
                        i = dataGridViewProcessCode.Rows.Count + 1;

                        dataGridViewProcessCode.Rows.Add(i, txtProcessName.Text.ToUpper(), "Remove");
                        dataGridViewProcessCode.Refresh();

                        //Lock Project Code
                        cmbProjectName.Enabled = false;
                        cmbProjectName.ReadOnly = true;
                        chkQA.Enabled = false;
                        break;  

                    }

                }
            }

        }

        private void txtProcessName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Validation
                if (String.IsNullOrEmpty(cmbProjectName.Text.ToUpper()))
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject name field cannot be empty..!", "Project Name Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbProjectName.Focus();
                    return;
                }

                if (cmbProjectName.Text.ToUpper().Length != 5)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject name strandard lenght is 5 characters.\nPlease enter valid cheracter length for project name.", "Invalid Character Length!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbProjectName.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(txtProcessName.Text.ToUpper()))
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess name filed cannot be empty.", "Process Name Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProcessName.Focus();
                    return;
                }

                if (new ProjectDetailMng(this.conn).ProjectDetailIsExist(cmbProjectName.Text.ToUpper(), lblUID.Text.ToUpper()))
                {
                    DialogResult resulta = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\n\"" + cmbProjectName.Text.ToUpper() + "\" project is already exist. Do you want to add process code under \"" + cmbProjectName.Text.ToUpper() + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resulta == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridViewProcessCode.Rows.Count;)
                        {

                            foreach (DataGridViewRow row in dataGridViewProcessCode.Rows)
                            {
                                string s = row.Cells[1].Value.ToString().ToUpper();

                                if (txtProcessName.Text.ToUpper() == s)
                                {
                                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess name is already exist!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtProcessName.Focus();
                                    return;

                                }

                            }

                            //increment i
                            i = dataGridViewProcessCode.Rows.Count + 1;

                            dataGridViewProcessCode.Rows.Add(i, txtProcessName.Text.ToUpper(), "Remove");
                            dataGridViewProcessCode.Refresh();

                            //Lock Project Code
                            cmbProjectName.Enabled = false;
                            cmbProjectName.ReadOnly = true;
                            chkQA.Enabled = false;
                            return;
                        }

                    }

                }

                if (new ProjectDetailMng(this.conn).ProjectIsExistNotUnderPIC(cmbProjectName.Text, lblUID.Text))
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject \"" + cmbProjectName.Text + "\" is already registered under another PIC!\nPlease enter a different project name.", "Project Already Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbProjectName.Enabled = true;
                    cmbProjectName.Focus();
                    return;
                }

                if (new ProcessCodeHeaderMng(this.conn).ProcessCodeIsExist(cmbProjectName.Text, txtProcessName.Text.ToUpper()))
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess name is already exist under \"" + cmbProjectName.Text.ToUpper() + "\" project!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProcessName.Focus();
                    return;
                }

                else
                {

                    if (dataGridViewProcessCode.Rows.Count == 0)
                    {

                        dataGridViewProcessCode.Rows.Add(1, txtProcessName.Text.ToUpper(), "Remove");
                        cmbProjectName.Enabled = false;
                        cmbProjectName.ReadOnly = true;
                        chkQA.Enabled = false;

                    }
                    else
                    {
                        for (int i = 0; i < dataGridViewProcessCode.Rows.Count;)
                        {

                            foreach (DataGridViewRow row in dataGridViewProcessCode.Rows)
                            {
                                string s = row.Cells[1].Value.ToString().ToUpper();

                                if (txtProcessName.Text.ToUpper() == s)
                                {
                                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess name is already exist!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtProcessName.Focus();
                                    return;

                                }

                            }
                            //increment i
                            i = dataGridViewProcessCode.Rows.Count + 1;

                            dataGridViewProcessCode.Rows.Add(i, txtProcessName.Text.ToUpper(), "Remove");
                            dataGridViewProcessCode.Refresh();

                            //Lock Project Code
                            cmbProjectName.Enabled = false;
                            cmbProjectName.ReadOnly = true;
                            chkQA.Enabled = false;
                            break;

                        }

                    }
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            dataGridViewProcessCode.Rows.Clear();
            cmbProjectName.Enabled = true;
            cmbProjectName.ReadOnly = false;
            chkQA.Enabled = true;
        }

        private void dataGridViewProcessCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String currentValue = dataGridViewProcessCode.CurrentRow.Cells[1].Value.ToString();
            DialogResult resulta = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nAre you sure want to delete process code \""+ currentValue + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                if (dataGridViewProcessCode.Columns[e.ColumnIndex].Index == 2)
                {
                    dataGridViewProcessCode.Rows.RemoveAt(dataGridViewProcessCode.CurrentRow.Index);
                }
            }

        }

        private void dataGridViewDepartmentRegister_Click(object sender, EventArgs e)
        {
            try
            {
                cmbProjectName.Text = dataGridViewDepartmentRegister.SelectedRows[0].Cells[1].Value.ToString();
                txtProcessName.Text = dataGridViewDepartmentRegister.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch(Exception ex)
            {
                if (ex.HResult== -2146233086)
                {

                }
                else
                {
                    MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        /// <summary>
        /// DEBUG: Process code delete with Task code relationship
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Remove Process Code by Clicking remove button on each cell
        private void dataGridViewDepartmentRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridViewDepartmentRegister.Columns[e.ColumnIndex].Index == 0)
            {
                String currentProject = dataGridViewDepartmentRegister.CurrentRow.Cells[1].Value.ToString();
                String currentProcessCode = dataGridViewDepartmentRegister.CurrentRow.Cells[2].Value.ToString();

                DialogResult resulta = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nAre you sure want to delete process code \"" + currentProcessCode + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {

                    ProcessCodeHeader mProcessCodeHeader = new ProcessCodeHeader();
                    ProjectDetail mProjectDetail = new ProjectDetail();

                    mProcessCodeHeader.PIC_Project = currentProject;
                    mProcessCodeHeader.PC_ProcessCode = currentProcessCode;


                    mProjectDetail.PIC_UID = lblUID.Text;
                    mProjectDetail.ProjectName = currentProject;

                    
                    try
                    {

                        if (new ProcessCodeHeaderMng(this.conn).GetProcessCodeCount(currentProject) == 1 || new ProcessCodeHeaderMng(this.conn).GetProcessCodeCount(currentProject) == 0)
                        {
                            if (new ProcessCodeHeaderMng(this.conn).DeleteProcessCode(mProcessCodeHeader) > 0)
                            {
                                new ProjectDetailMng(this.conn).DeleteProjectDetail(mProjectDetail);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess code \"" + currentProcessCode + "\" has been deleted.", "Process Code Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshData();
                                ClearFields();
                            }
                        }
                        else
                        {
                            if (new ProcessCodeHeaderMng(this.conn).DeleteProcessCode(mProcessCodeHeader) > 0)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess code \"" + currentProcessCode + "\" has been deleted.", "Process Code Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshData();
                                ClearFields();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        if(ex.HResult == -2146232060)
                        {
                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nCannot delete process code \"" + currentProcessCode + "\". Please check and delete task codes related this process code.", "Cannot Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }                   

                }
            }
        }

        private void frm_ProjectRegisterPanel_Activated(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txtProcessName_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbProjectName.Text) && !String.IsNullOrEmpty(txtProcessName.Text))
            {
                dataGridViewDepartmentRegister.DataSource = new ProjectDetailMng(this.conn).GetAllProjectDetailsByPIC_ProjectName_ProcessCode(lblUID.Text.ToUpper(), cmbProjectName.Text,txtProcessName.Text);
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

        //Export Details
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewDepartmentRegister.Columns)
            {
                try
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }
                catch(Exception ex)
                {
                    if (ex.HResult == -2147467261)
                    {
                        //Do niothing...
                    }
                }
                
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewDepartmentRegister.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        dt.Rows[dt.Rows.Count-1][cell.ColumnIndex-1] = cell.Value.ToString();
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
                                wb.Worksheets.Add(dt, "CITITO_" + lblUID.Text + "_Project Details");
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject details successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "CITITO_" + lblUID.Text + "_Project Details");
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject details successfully saved to \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
