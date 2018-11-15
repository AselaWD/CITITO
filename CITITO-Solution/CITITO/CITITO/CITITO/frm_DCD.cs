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
    public partial class frm_DCD : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_DCD _instance;
        public static frm_DCD GetInstance(string uUID, string uName, string uAccess, DateTime uLogTime)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUID = uUID;
                String mName = uName;
                String mAccess = uAccess;
                DateTime mLogTime = uLogTime;

                _instance = new frm_DCD(mUID, mName, mAccess, uLogTime);

            }
            return _instance;

        }

        public frm_DCD(string uUID, string uName, string uAccess, DateTime uLogTime)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            string mM_UID = new PICDetailMng(this.conn).GetPICUIDByMUID(uUID);

            lblUIDToFill.Text = uUID;
            lblUserNameToFill.Text = uName;
            lblTimeToFill.Text = uLogTime.ToString();
            lblManagerToFill.Text = new PICDetailMng(this.conn).GetPICNamByMUID(uUID) + " (" + mM_UID + ")";


            dataGridViewPCPRegister.MultiSelect = true;
            dataGridViewPCPRegister.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /*CITITO Server Time*/
        public DateTime ServerDateTime()
        {
            ServerTime mServerTime = new ServerTime(this.conn);
            DateTime sDate = mServerTime.getServerTime();
            return sDate;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frm_DCD_Load(object sender, EventArgs e)
        {
            cmbShipment.AutoSize = false;

            PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);
            string uUID = lblUIDToFill.Text;



            //Refresh data fields
            RefreshData();
                        
            

            this.BindGrid();

            dataGridViewPCPRegister.Columns[0].Width = 30;            
            dataGridViewPCPRegister.Columns[11].Width = 90;
            this.dataGridViewPCPRegister.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPCPRegister.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            
            cmbDCDUser.DataSource = mPCPDetailMng.GetListOfDCDUID(uUID);
            cmbDCDUser.SelectedIndex = -1;

            //Clear All Fields when Load
            ClearFields();

        }

        CheckBox headerCheckBox = new CheckBox();

        private void BindGrid()
        {
            //Add a CheckBox Column to the DataGridView Header Cell.

            //Find the Location of Header Cell.
            Point headerCellLocation = this.dataGridViewPCPRegister.GetCellDisplayRectangle(0, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 20);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dataGridViewPCPRegister.Controls.Add(headerCheckBox);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridViewPCPRegister.Columns.Insert(0, checkBoxColumn);

            //Assign Click event to the DataGridView Cell.
            dataGridViewPCPRegister.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dataGridViewPCPRegister.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dataGridViewPCPRegister.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Refresh Object
        public void RefreshData()
        {
            string uUID = lblUIDToFill.Text;
            cmbProjectName.DataSource = new ManagerDetailMng(this.conn).ListAllActiveProjectsByDCDUser(uUID);                 
            dataGridViewPCPRegister.DataSource = new PCPDetailMng(this.conn).GetAllPCPDetailsByUserUID(uUID);


        }

        //Clear Object
        public void ClearFields()
        {
            //RefreshData();

            //Clear All Fields when Load
            cmbProjectName.SelectedIndex = -1;
            cmbShipment.SelectedIndex = -1;
            cmbShipment.Text = String.Empty;
            cmbProcessCode.SelectedIndex = -1;
            cmbDCDUser.SelectedIndex = -1;

            txtFileName.Text = String.Empty;
            
            numericUpDownFileSize.Value = 0;
            chkSelectAll.Checked = false;
            

            //Uncheck all items in check list
            for (int index = 0; index < checkedListBoxTaskCodes.Items.Count; ++index)
            {
                checkedListBoxTaskCodes.SetItemChecked(index, false);
            }   

            //DatagridView
            for (int index = 0; index < dataGridViewPCPRegister.Rows.Count; ++index)
            {
                dataGridViewPCPRegister.Rows[index].Cells[0].Value=false;
            }

            headerCheckBox.Checked = false;

        }

        //Clear Object
        public void ClearFields2()
        {

            //Clear All Fields when Load
            //cmbProjectName.SelectedIndex = -1;
            //cmbShipment.SelectedIndex = -1;
            //cmbShipment.Text = String.Empty;
            cmbProcessCode.SelectedIndex = -1;

            //txtFileName.Text = String.Empty;

            numericUpDownFileSize.Value = 0;
            chkSelectAll.Checked = false;

            //Uncheck all items in check list
            for (int index = 0; index < checkedListBoxTaskCodes.Items.Count; ++index)
            {
                checkedListBoxTaskCodes.SetItemChecked(index, false);
            }
            headerCheckBox.Checked = false;

            //DatagridView
            for (int index = 0; index < dataGridViewPCPRegister.Rows.Count; ++index)
            {
                dataGridViewPCPRegister.Rows[index].Cells[0].Value=false;
            }


            string uUID = lblUIDToFill.Text;
            dataGridViewPCPRegister.DataSource = new PCPDetailMng(this.conn).GetAllPCPDetailsByUserUID(uUID);

        }

        //DCD Log out
        private void tglLogut_CheckedChanged(object sender, EventArgs e)
        {
            if (tglLogut.Checked == false)
            {
                ////Get user Confirmation
                //DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to LogOut from CITITO?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == DialogResult.Yes)
                //{


                    frm_Login form = frm_Login.GetInstance();
                    if (!form.Visible)
                    {

                        form.Show();
                        this.Close();
                    }
                    else
                    {
                        form.BringToFront();
                    }


                //}
                //else
                //{
                //    tglLogut.Checked = true;
                //}
            }
        }

        //Selected Index Changed
        private void cmbProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProcessCode.DataSource = new ProcessCodeHeaderMng(this.conn).GetListProcessCodesByProject(cmbProjectName.Text);
            cmbProcessCode.SelectedIndex = -1;
            cmbProcessCode.Text = String.Empty;

            cmbShipment.DataSource = new PCPHeaderMng(this.conn).GetListShipmentsByProject(cmbProjectName.Text);
            cmbShipment.SelectedIndex = -1;
            cmbShipment.Text = String.Empty;
        }


        private void cmbProcessCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                checkedListBoxTaskCodes.DataSource = new TaskDetailMng(this.conn).GetAllTaskCodeDetailsByProcessCode(cmbProcessCode.Text);


            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147467261)
                {

                }
                else
                {
                    MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        //View Task Codes with Description
        private void lnkTaskCodeList_Click(object sender, EventArgs e)
        {
            frm_TaskCodeList_DCD form = frm_TaskCodeList_DCD.GetInstance();
            if (!form.Visible)
            {

                form.Show();

            }
            else
            {
                form.BringToFront();
            }
        }

        //Bulk Import
        private void btnBulkImport_Click_1(object sender, EventArgs e)
        {
            string uUID = lblUIDToFill.Text;
            //Form Open by PIC System Access Level

            frm_BulkImport_PCPCodes form = frm_BulkImport_PCPCodes.GetInstance(uUID);
            if (!form.Visible)
            {
                
                form.Show();

            }
            else
            {
                form.BringToFront();
            }
        }
        /// <summary>
        /// DEGUB if Book Count file size update as 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Register Code
        private void btnRegisterCode_Click(object sender, EventArgs e)
        {
            //Validate Fields is null or empty

            if (String.IsNullOrEmpty(cmbProjectName.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Project name field cannot be empty..!", "Project Name Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtFileName.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "File name field cannot be empty.", "File Name Not Enterd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFileName.Focus();
                return;
            }

            if (chkBytes.Checked==false)
            {
                if (String.IsNullOrEmpty(numericUpDownFileSize.Text) || numericUpDownFileSize.Value == 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "File size cannot be zero or empty.", "File Size Not Enterd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numericUpDownFileSize.Focus();
                    return;
                }
            }
            
            if (String.IsNullOrEmpty(cmbProcessCode.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Process code field cannot be empty.", "Process Code Not Enterd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProcessCode.Focus();
                return;
            }

            if (checkedListBoxTaskCodes.Items.Count==0)
            {
                MetroFramework.MetroMessageBox.Show(this, "There is no task code registered for this process code. Please check again.", "Empty Task Codes!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProcessCode.Focus();
                return;
            }

            if (checkedListBoxTaskCodes.CheckedItems.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Please select at least one task code.", "Task Codes Not Selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProcessCode.Focus();
                return;
            }

            for (int i = 0; i < checkedListBoxTaskCodes.Items.Count; i++)
            {
                if (checkedListBoxTaskCodes.GetItemChecked(i))
                {
                    //Create Task Code by splitting details
                    string source = checkedListBoxTaskCodes.Items[i].ToString();
                    string[] stringSeparators = new string[] { " - " };
                    string[] result;
                    result = source.Split(stringSeparators, StringSplitOptions.None);
                    string cTaskCode = result[0].ToString();
                    string cTaskDescription = result[1].ToString();

                    if (new PCPDetailMng(this.conn).IsExistHearedRecord(cmbProcessCode.Text, cmbShipment.Text, txtFileName.Text, cTaskCode))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "\nJob code is found for following details. Please check again.\n\nProcess Code: " + cmbProcessCode.Text + "\nShipment: " + cmbShipment.Text + "\nTask Code: " + cTaskCode, "Job Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            //DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "Do you want to create new Job?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (resulta == DialogResult.Yes)
            //{
                //Create Object From PCPDetail
                PCPDetail mPCPDetail = new PCPDetail();
                PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

                //Create Object From PCPHeader
                PCPHeader mPCPHeader = new PCPHeader();
                PCPHeaderMng mPCPHeaderMng = new PCPHeaderMng(this.conn);
                TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);

                //Task Code from List part 01                
                int cLastRowCount = (mPCPDetailMng.GetLastRowCount(cmbProjectName.Text));                
                int cNewInt = (cLastRowCount + 1);


                for (int i = 0; i < checkedListBoxTaskCodes.Items.Count; i++)
                {
                    if (checkedListBoxTaskCodes.GetItemChecked(i))
                    {
                        //Task Code from List part 02
                        //Create Task Code by splitting details
                        string source = checkedListBoxTaskCodes.Items[i].ToString();
                        string[] stringSeparators = new string[] { " - " };
                        string[] result;
                        result = source.Split(stringSeparators, StringSplitOptions.None);
                        string cTaskCode = result[0].ToString();
                        string cTaskDescription = result[1].ToString();

                        string cProject = cTaskCode.Substring(0, 3);
                        string cMonthYear = ServerDateTime().ToString("MMyy");
                        string cProcessCode = cTaskCode.Substring(4, 2);
                        string cPCPCode = cProject + cMonthYear + cProcessCode + cNewInt;
                        string cPCPCode_Same = mPCPDetailMng.GetPCPCodeByShipmentAndFileName_TaskInOut(cmbShipment.Text, txtFileName.Text);

                        bool cPCPCode_Same_ProcessCode = mPCPDetailMng.GetPCPCodeByShipmentAndFileName(cmbShipment.Text, txtFileName.Text, cmbProcessCode.Text);

                        //get UOM and Quota form Task Code
                        string cUOM = mTaskDetailMng.GetUOMFromTaskCode(cTaskCode, cmbProcessCode.Text);
                        int cQuota = mTaskDetailMng.GetQuotaFromTaskCode(cTaskCode, cmbProcessCode.Text);

                        //Initialize PCPHeader
                        mPCPHeader.PCP_ID = cPCPCode;
                        mPCPHeader.PCP_Shipment = cmbShipment.Text;
                        mPCPHeader.PC_ProcessCode = cmbProcessCode.Text;
                        //mPCPHeader.Task_ID = cTaskCode;

                        //Initialize PCPDetail
                        mPCPDetail.PCP_ID = cPCPCode;
                        mPCPDetail.PCP_File = txtFileName.Text;                        
                        mPCPDetail.PCP_Status = 0; /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                        mPCPDetail.PCP_Project = cmbProjectName.Text;
                        mPCPDetail.Task_UOM = cUOM;
                        mPCPDetail.Task_Quota = cQuota;
                        mPCPDetail.PCP_StartDate =ServerDateTime();
                        //mPCPDetail.PCP_EndDate = "NULL";
                        mPCPDetail.PCP_CreatorUID = lblUIDToFill.Text;
                        mPCPDetail.Task_ID = cTaskCode;
                        mPCPDetail.PC_ProcessCode = cmbProcessCode.Text;
                        
                        //Check byte size checked
                        if (chkBytes.Checked)
                        {
                            mPCPDetail.PCP_FileSize = 0;

                            if (cUOM != "Byte Size")
                            {
                                MetroFramework.MetroMessageBox.Show(this, "\nUOM is not regitsered as Byte Size for \"" + cTaskCode + "\" task code. Please check correct tack code.", "Incorrect UOM!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        //Update File to 1 if UOM is Book Count
                        else if (cUOM == "Book Count")
                        {
                            mPCPDetail.PCP_FileSize = 1;
                        }                        
                        else
                        {
                            mPCPDetail.PCP_FileSize = int.Parse(numericUpDownFileSize.Value.ToString());
                        }

                        //Validate Header Already Exist && Same Process Code
                        if (new PCPHeaderMng(this.conn).IsExistHeader(cPCPCode_Same))
                        {
                            if (cPCPCode_Same_ProcessCode)
                            {
                                //Validate Detail Not Exist
                                if (!mPCPDetailMng.IsExistPCPRecord(cTaskCode, cmbProcessCode.Text, cmbProjectName.Text, txtFileName.Text, mPCPDetail.PCP_FileSize, cUOM, cmbShipment.Text) || !mPCPDetailMng.IsExistHearedRecord(cmbProcessCode.Text, cmbShipment.Text, txtFileName.Text, cTaskCode))
                                {
                                    mPCPDetail.PCP_ID = cPCPCode_Same;
                                    mPCPDetailMng.AddPCPDetail(mPCPDetail);
                                }
                            }
                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "\nThis file is already registered in a different process code. Please check again or add alias after filename and re-register.\n Ex: " + txtFileName.Text+ "_{alias}", "Invalid Registration!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtFileName.Focus();
                                return;
                            } 
                        }
                        else
                        {
                            if (mPCPHeaderMng.AddPCPHeader(mPCPHeader) > 0)
                            {
                                mPCPDetailMng.AddPCPDetail(mPCPDetail);

                            }
                        }

                    }
                }
                
                //Done Message
                MetroFramework.MetroMessageBox.Show(this, "Job has been successfully registered.", "Registered!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //RefreshData();
                //ClearFields();
                ClearFields2();
                return;
                
                
            //}
        }

        //Check Byte Size
        private void chkBytes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBytes.Checked)
            {
                numericUpDownFileSize.Enabled = false;
            }
            else
            {
                numericUpDownFileSize.Enabled = true;
            }
        }

        //Refresh
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtJobCode.Text = String.Empty;
            txtFShipmnet.Text = String.Empty;
            txtFProcessCode.Text = String.Empty;
            txtFTaskCode.Text = String.Empty;
            txtFFileName.Text = String.Empty;
        }

        //Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //string uUID = lblUIDToFill.Text;
            ////Form Open by PIC System Access Level

            //frm_PCPDelete form = frm_PCPDelete.GetInstance(uUID);
            //if (!form.Visible)
            //{

            //    form.Show();

            //}
            //else
            //{
            //    form.BringToFront();
            //}

            if (dataGridViewPCPRegister.Rows.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Check if there any checkbox checked/unchecked in cloumn 0

            for (int j = 0; j < dataGridViewPCPRegister.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewPCPRegister[0, j].Value) == false)
                {

                    if ((dataGridViewPCPRegister.RowCount - 1) == j)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select at least one record.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    break;
                }
            }

            PCPDetail mPCPDetail = new PCPDetail();
            PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

            int records = 0;

            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to delete selected record(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                for (int j = 0; j < dataGridViewPCPRegister.RowCount; j++)
                {
                    //initialize Approval Header
                    /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */

                    int cStatus = 0; //Only Fresh Status

                    string cPCPCode = dataGridViewPCPRegister[2, j].Value.ToString();
                    string cTaskCode = dataGridViewPCPRegister[5, j].Value.ToString();
                    mPCPDetail.PCP_Status = cStatus;
                    
                    //initialize Approval Details
                    mPCPDetail.PCP_ID = dataGridViewPCPRegister[1, j].Value.ToString();
                    mPCPDetail.Task_ID = dataGridViewPCPRegister[4, j].Value.ToString();
                    

                    if (Convert.ToBoolean(dataGridViewPCPRegister[0, j].Value) == true)
                    {
                        if (mPCPDetailMng.DeletePCPRecordByStatus(cPCPCode, cTaskCode, cStatus) > 0)
                        {
                            if (mPCPDetailMng.GetCountPCPDeatails(cPCPCode) == 0)
                            {
                                new PCPHeaderMng(this.conn).DeletePCPHeader(cPCPCode);

                            }

                        }
                        else
                        {                            
                            records += 1;
                        }
                    }

                }

                if (records != 0)
                {
                    //Show Completed Message
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been deleted except already active record(s).", "Record(s) Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                    ClearFields();
                }
                else
                {
                    //Show Completed Message
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been deleted.", "Record(s) Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                    ClearFields();
                }

            }
        }

        private void frm_DCD_Activated(object sender, EventArgs e)
        {
            //string uUID = lblUIDToFill.Text;

            //dataGridViewPCPRegister.DataSource = new PCPDetailMng(this.conn).GetAllPCPDetailsByUserUID(uUID);
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                for (int index = 0; index < checkedListBoxTaskCodes.Items.Count; ++index)
                {
                    checkedListBoxTaskCodes.SetItemChecked(index, true);
                }
            }
            else
            {
                for (int index = 0; index < checkedListBoxTaskCodes.Items.Count; ++index)
                {
                    checkedListBoxTaskCodes.SetItemChecked(index, false);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to exit from CITITO?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                Application.Exit();

            }
            else
            {
               //...
            }
        }

        //GridVeiw Export to Excel
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewPCPRegister.Columns)
            {

                dt.Columns.Add(column.HeaderText);

            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewPCPRegister.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {
                        if (i==8)
                        {
                            //MessageBox.Show(row.Cells[7].Value.ToString(), "Row 7");

                            if ((Int32)row.Cells[8].Value == 0)
                            {                                
                                dt.Rows[dt.Rows.Count - 1][8] = "Fresh";
                            }
                            else if ((Int32)row.Cells[8].Value == 1)
                            {
                                dt.Rows[dt.Rows.Count - 1][8] = "Hold";
                            }
                            else if ((Int32)row.Cells[8].Value == 2)
                            {
                                dt.Rows[dt.Rows.Count - 1][8] = "Pending";
                            }
                            else if ((Int32)row.Cells[8].Value == 3)
                            {
                                dt.Rows[dt.Rows.Count - 1][8] = "Done";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][8] = row.Cells[8].Value.ToString();
                            }
                            
                        }
                        else
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Value.ToString();
                        }
                                           

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
                                var ws = wb.Worksheets.Add(dt, "CITITO_" + lblUIDToFill.Text + "_PCP Inventory");
                                ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPCP Codes successfully export to \"" + fileName + "\".", "PCP Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + lblUIDToFill.Text + "_PCP Inventory");
                            ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPCP Codes successfully saved to \"" + fileName + "\" path.", "PCP Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        //Filter 
        private void txtJobCode_KeyUp(object sender, KeyEventArgs e)
        {
            string uUID = lblUIDToFill.Text;
            string uJobCode = txtJobCode.Text;
            if (!String.IsNullOrEmpty(uJobCode))
            {
                dataGridViewPCPRegister.DataSource = new PCPDetailMng(this.conn).FilterJobCodesByUserUID(uUID, uJobCode);
            }
            else
            {
                RefreshData();
                ClearFields();
            }
        }

        private void txtFShipmnet_KeyUp(object sender, KeyEventArgs e)
        {
            string uUID = lblUIDToFill.Text;
            string uShipmnet = txtFShipmnet.Text;
            if (!String.IsNullOrEmpty(uShipmnet))
            {
                dataGridViewPCPRegister.DataSource = new PCPDetailMng(this.conn).FilterShipmentByUserUID(uUID, uShipmnet);
            }
            else
            {
                RefreshData();
                ClearFields();
            }
        }

        private void txtFProcessCode_KeyUp(object sender, KeyEventArgs e)
        {
            string uUID = lblUIDToFill.Text;
            string uProcessCode = txtFProcessCode.Text;
            if (!String.IsNullOrEmpty(uProcessCode))
            {
                dataGridViewPCPRegister.DataSource = new PCPDetailMng(this.conn).FilterProcessCodeByUserUID(uUID, uProcessCode);
            }
            else
            {
                RefreshData();
                ClearFields();
            }
        }

        private void txtFTaskCode_KeyUp(object sender, KeyEventArgs e)
        {
            string uUID = lblUIDToFill.Text;
            string uTaskCode = txtFTaskCode.Text;
            if (!String.IsNullOrEmpty(uTaskCode))
            {
                dataGridViewPCPRegister.DataSource = new PCPDetailMng(this.conn).FilterTaskCodeByUserUID(uUID, uTaskCode);
            }
            else
            {
                RefreshData();
                ClearFields();
            }
        }

        private void txtFFileName_KeyUp(object sender, KeyEventArgs e)
        {
            string uUID = lblUIDToFill.Text;
            string uFileName = txtFFileName.Text;
            if (!String.IsNullOrEmpty(uFileName))
            {
                dataGridViewPCPRegister.DataSource = new PCPDetailMng(this.conn).FilterFileNameByUserUID(uUID, uFileName);
            }
            else
            {
                RefreshData();
                ClearFields();
            }
        }


        private void cmbDCDUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //string uUID = lblUIDToFill.Text;
            //string uDCDUID = cmbDCDUser.Text;
            //if (!String.IsNullOrEmpty(uDCDUID))
            //{
            //    dataGridViewPCPRegister.DataSource = new PCPDetailMng(this.conn).GetAllPCPDetailsByDCDUID(uUID, uDCDUID);
            //}
            //else
            //{
            //    RefreshData();
            //    ClearFields();
            //}
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            string uUID = lblUIDToFill.Text;
            string uDCDUID = cmbDCDUser.Text;
            if (!String.IsNullOrEmpty(uDCDUID))
            {
                dataGridViewPCPRegister.DataSource = new PCPDetailMng(this.conn).GetAllPCPDetailsByDCDUID(uUID, uDCDUID);
            }
            else
            {
                RefreshData();
                ClearFields();
            }
        }


        //Hold or Release file
        private void btnHold_Click(object sender, EventArgs e)
        {
            if (dataGridViewPCPRegister.Rows.Count == 0)
            {
                //MessageBox.Show("There is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //Check if there any checkbox checked/unchecked in cloumn 0
            for (int j = 0; j < dataGridViewPCPRegister.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewPCPRegister[0, j].Value) == false)
                {
                    if ((dataGridViewPCPRegister.RowCount - 1) == j)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select at least one record.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    break;
                }
            }

            PCPDetail mPCPDetail = new PCPDetail();
            PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

            TaskRecordDetail mTaskRecordDetail = new TaskRecordDetail();
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Get user Confirmation
            DialogResult results = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to hold or release selected record(s)?\n\n- Please verify job status is \"Fresh\" or \"Pending\".\n- Status done file(s) can not hold.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (results == DialogResult.Yes)
            {
                
                for (int j = 0; j < dataGridViewPCPRegister.RowCount; j++)
                {
                    if (Convert.ToBoolean(dataGridViewPCPRegister[0, j].Value) == true)
                    {
                        MessageBox.Show(j.ToString(), "Values");
                    }
                    //if (Convert.ToBoolean(dataGridViewPCPRegister[0, j].Value) == true)
                    //{
                        

                    //    //string cPCPCode = dataGridViewPCPRegister[2, j].Value.ToString();
                    //    //string cTaskCode = dataGridViewPCPRegister[5, j].Value.ToString();
                    //    //string cJobStatus = dataGridViewPCPRegister[8, j].Value.ToString();

                    //    //MessageBox.Show(cPCPCode + "\n" + cTaskCode + "\n" + cJobStatus, "Values");


                    //    //if (mTaskRecordDetailMng.TaskTaskInDetailIsExistForDCDHold(cTaskCode, cPCPCode))
                    //    //{

                    //    //}
                    //}
                }
            }
        }

        //private void btnHold_MouseEnter(object sender, EventArgs e)
        //{
        //    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
        //    ToolTip1.SetToolTip(this.btnHold, "- Please verify job status is \"Fresh\" or \"Pending\" before you click the Hold/Release.\n- Status done file(s) can not hold.");
        //}


        private void dataGridViewPCPRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                foreach (DataGridViewRow row in dataGridViewPCPRegister.SelectedRows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                    if (isSelected)
                    {
                        row.Cells[0].Value = false;

                        //Loop to verify whether all row CheckBoxes are checked or not.
                        bool isChecked = true;
                        foreach (DataGridViewRow row2 in dataGridViewPCPRegister.Rows)
                        {
                            if (Convert.ToBoolean(row2.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                            {
                                isChecked = false;

                            }

                        }
                        headerCheckBox.Checked = isChecked;

                    }
                    else
                    {
                        row.Cells[0].Value = true;

                        //Loop to verify whether all row CheckBoxes are checked or not.
                        bool isChecked = true;
                        foreach (DataGridViewRow row2 in dataGridViewPCPRegister.Rows)
                        {
                            if (Convert.ToBoolean(row2.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                            {
                                isChecked = false;

                            }

                        }
                        headerCheckBox.Checked = isChecked;


                    }

                }
            }
        }

        private void dataGridViewPCPRegister_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewPCPRegister.SelectedRows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                if (isSelected)
                {
                    row.Cells[0].Value = false;

                    //Loop to verify whether all row CheckBoxes are checked or not.
                    bool isChecked = true;
                    foreach (DataGridViewRow row2 in dataGridViewPCPRegister.Rows)
                    {
                        if (Convert.ToBoolean(row2.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                        {
                            isChecked = false;

                        }

                    }
                    headerCheckBox.Checked = isChecked;

                }
                else
                {
                    row.Cells[0].Value = true;

                    //Loop to verify whether all row CheckBoxes are checked or not.
                    bool isChecked = true;
                    foreach (DataGridViewRow row2 in dataGridViewPCPRegister.Rows)
                    {
                        if (Convert.ToBoolean(row2.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                        {
                            isChecked = false;

                        }

                    }
                    headerCheckBox.Checked = isChecked;


                }

            }
        }

        private void dataGridViewPCPRegister_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */

            if (e.ColumnIndex == 8)
            {
                if ((int)e.Value == 0)
                {
                    e.Value = "Fresh";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                }
                else if ((int)e.Value == 1)
                {
                    e.Value = "On Hold";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FD7C66");
                }
                else if ((int)e.Value == 2)
                {
                    e.Value = "Pending";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");

                }
                else if ((int)e.Value == 3)
                {
                    e.Value = "Done";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9FEB");
                }
            }
        }

        private void dataGridViewPCPRegister_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                foreach (DataGridViewRow row in dataGridViewPCPRegister.SelectedRows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                    if (isSelected)
                    {
                        row.Cells[0].Value = false;

                        //Loop to verify whether all row CheckBoxes are checked or not.
                        bool isChecked = true;
                        foreach (DataGridViewRow row2 in dataGridViewPCPRegister.Rows)
                        {
                            if (Convert.ToBoolean(row2.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                            {
                                isChecked = false;

                            }

                        }
                        headerCheckBox.Checked = isChecked;

                    }
                    else
                    {
                        row.Cells[0].Value = true;

                        //Loop to verify whether all row CheckBoxes are checked or not.
                        bool isChecked = true;
                        foreach (DataGridViewRow row2 in dataGridViewPCPRegister.Rows)
                        {
                            if (Convert.ToBoolean(row2.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                            {
                                isChecked = false;

                            }

                        }
                        headerCheckBox.Checked = isChecked;


                    }

                }
            }
        }

        private void btnHoldRelease_Click(object sender, EventArgs e)
        {
            if (dataGridViewPCPRegister.Rows.Count == 0)
            {
                //MessageBox.Show("There is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //Check if there any checkbox checked/unchecked in cloumn 0
            for (int j = 0; j < dataGridViewPCPRegister.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewPCPRegister[0, j].Value) == false)
                {
                    if ((dataGridViewPCPRegister.RowCount - 1) == j)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select at least one record.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    break;
                }
            }

            PCPDetail mPCPDetail = new PCPDetail();
            PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

            TaskRecordDetail mTaskRecordDetail = new TaskRecordDetail();
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Text for temp prompt     
            string outputStr = String.Empty;

            //Get user Confirmation
            DialogResult results = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to hold or release selected record(s)?\n\n- Please verify job status is \"Fresh\" or \"Pending\".\n- Status done file(s) can not hold.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (results == DialogResult.Yes)
            {

                for (int j = 0; j < dataGridViewPCPRegister.RowCount; j++)
                {

                    if (Convert.ToBoolean(dataGridViewPCPRegister[0, j].Value) == true)
                    {
                        string cPCPCode = dataGridViewPCPRegister[2, j].Value.ToString();
                        string cTaskCode = dataGridViewPCPRegister[5, j].Value.ToString();
                        int cJobStatus = int.Parse(dataGridViewPCPRegister[8, j].Value.ToString());
                        DateTime cDateTime = ServerDateTime();

                        if (!String.IsNullOrEmpty(mTaskRecordDetailMng.TaskTaskInDetailIsExistForDCDHoldCheckTaskedIn(cTaskCode, cPCPCode)))
                        {
                            string uUIDLbl = mTaskRecordDetailMng.TaskTaskInDetailIsExistForDCDHoldCheckTaskedIn(cTaskCode, cPCPCode);
                            outputStr += (uUIDLbl + " , ").ToString();
                            continue;

                        }
                        else
                        {
                            
                            //PCP /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                            if (cJobStatus != 3)
                            {
                                if (cJobStatus != 1)
                                {
                                    cJobStatus = 1;
                                    mPCPDetailMng.UpdatePCPDetailToHold(cPCPCode, cJobStatus, cTaskCode, cDateTime);
                                }
                                else
                                {
                                    //Trask record is available
                                    if (mTaskRecordDetailMng.TaskTaskInDetailIsExistForDCDHold(cTaskCode, cPCPCode))
                                    {
                                        
                                        cJobStatus = 2;
                                        mPCPDetailMng.UpdatePCPDetailToFresh(cPCPCode, cJobStatus, cTaskCode);
                                        MessageBox.Show("True" + cPCPCode +" "+ cJobStatus, "Pending Task");
                                    }
                                    else
                                    {
                                        cJobStatus = 0;
                                        mPCPDetailMng.UpdatePCPDetailToFresh(cPCPCode, cJobStatus, cTaskCode);
                                    }
                                            
                                }
                            }
                        }
                    }
                }

                //Check ouput string status
                if (outputStr != "")
                {

                    string moutputProject = "Please task out user(s) from following file(s).," + outputStr;

                    frm_ExistHoldReleaseMessage ExistFrom = new frm_ExistHoldReleaseMessage(moutputProject);
                    RefreshData();
                    ClearFields();
                    ExistFrom.Show();
                }
                else
                {
                    //Show Completed Message
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been processed!", "Record(s) Hold/Released!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                    ClearFields();
                }
            }
        }

        //Modify button
        private void btnModifyFileSize_Click(object sender, EventArgs e)
        {
            //Check if there any checkbox checked/unchecked in cloumn 0
            for (int j = 0; j < dataGridViewPCPRegister.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewPCPRegister[0, j].Value) == false)
                {

                    if ((dataGridViewPCPRegister.RowCount - 1) == j)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select a record first.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                else
                {
                    break;
                }
            }

            //Check if there any checkbox checked/unchecked in cloumn more than 1
            List<DataGridViewRow> selectedRows = (from row in dataGridViewPCPRegister.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells[0].Value) == true
                                                  select row).ToList();

            foreach (DataGridViewRow row in selectedRows)
            {
                if (selectedRows.Count > 1)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nMultiple selection cannot be modified at once. Please select one record.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            //Pass modify data to Modify form as parameters
            for (int j = 0; j < dataGridViewPCPRegister.RowCount; j++)
            {


                if (Convert.ToBoolean(dataGridViewPCPRegister[0, j].Value) == true)
                {
                    //Initialize PCP User Detail                
                    string mPCPIndex = dataGridViewPCPRegister[1, j].Value.ToString();
                    int mStatus = int.Parse(dataGridViewPCPRegister[8, j].Value.ToString());

                    //Validation is staus Done
                    if (mStatus==3)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nStatus \"Done\" records cannot be modified. Please select \"Fresh, Pending or Hold\" record.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    frm_ModifyFileSize form = frm_ModifyFileSize.GetInstance(mPCPIndex);

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

        private void frm_DCD_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

    }
}
   