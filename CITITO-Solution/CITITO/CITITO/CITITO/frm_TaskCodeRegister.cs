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
using MetroFramework.Forms;

namespace CITITO
{
    public partial class frm_TaskCodeRegister : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_TaskCodeRegister _instance;
        public static frm_TaskCodeRegister GetInstance(string uUID, string uName)
        {


            if (_instance == null || _instance.IsDisposed)
            {
                string mUID = uUID;
                string mName = uName;

                _instance = new frm_TaskCodeRegister(mUID, mName);


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_TaskCodeRegister(string uUID, string uName)
        {
            InitializeComponent();

            lblUID.Text = uUID;
            lblManagerName.Text = uName;

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

        }

        private void frm_TaskCodeRegister_Load(object sender, EventArgs e)
        {
            //Activate();

            //Refresh data fields
            RefreshData();

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
            dataGridViewTaskCodes.Columns.Insert(0, buttonColumn);


            //Change remove column to last-child
            DataGridViewColumnCollection columnCollection = dataGridViewTaskCodes.Columns;

            DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
            DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

            int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
            firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
            //lastVisibleColumn.DisplayIndex = firstColumn_sIndex;



        }

        //Refresh Object
        private void RefreshData()
        {
            cmbProjectName.DataSource = new ProjectDetailMng(this.conn).GetListOfProjectNamesByPIC(lblUID.Text);
            cmbProcessCode.DataSource = new ProcessCodeHeaderMng(this.conn).GetListProcessCodesByProject(cmbProjectName.Text);
            dataGridViewTaskCodes.DataSource = new TaskDetailMng(this.conn).GetAllTaskCodeDetailsByPICUID(lblUID.Text.ToUpper());
            UOM.DataSource = new UOMListMng(this.conn).GetUOMList();//UOM Dropdown list

        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();
            //Clear All Fields when Load
            cmbProjectName.SelectedIndex = -1;
            cmbProcessCode.SelectedIndex = -1;
            dataGridViewTaskCodeList.Rows.Clear();
            cmbProjectName.Enabled = true;
            cmbProcessCode.Enabled = true;
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        //Filter Process Codes
        private void cmbProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProcessCode.DataSource = new ProcessCodeHeaderMng(this.conn).GetListProcessCodesByProject(cmbProjectName.Text);
            cmbProcessCode.SelectedIndex = -1;

            if (!String.IsNullOrEmpty(cmbProjectName.Text))
            {
                dataGridViewTaskCodes.DataSource = new TaskDetailMng(this.conn).GetAllTaskCodeDetailsByPICUIDANDProject(lblUID.Text.ToUpper(), cmbProjectName.Text);
            }
            

        }

        //Task Code Add
        private void btnAddProcessCode_Click(object sender, EventArgs e)
        {
            //Validation
            if (String.IsNullOrEmpty(cmbProjectName.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProject name field cannot be empty..!", "Project Name Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }

            if (String.IsNullOrEmpty(cmbProcessCode.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess code filed cannot be empty.", "Process Code Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProcessCode.Focus();
                return;
            }

            else
            {
                string SplitProjectName = cmbProjectName.Text.Substring(0, 3);
                string SplitProcessCode = cmbProcessCode.Text.Substring(3, 2);

                string ChunkCode = SplitProjectName + "_" + SplitProcessCode;

                //Check Count of Exists Task IDs
                String uCount = new TaskHeaderMng(this.conn).TaskCodeExisltMAXCount(ChunkCode, cmbProcessCode.Text, cmbProjectName.Text);
               

                //If grid view null
                if (dataGridViewTaskCodeList.Rows.Count != 0)
                {
                    //If Task Code ID not exists
                    if (String.IsNullOrEmpty(uCount))
                    {
                        for (int i = 0; i < dataGridViewTaskCodeList.Rows.Count; i++)
                        {

                            if (dataGridViewTaskCodeList.Rows.Count - 1 == i)
                            {
                                try
                                {
                                    String mTask_Code = dataGridViewTaskCodeList.Rows[i].Cells[0].Value.ToString();
                                    String mDescription = dataGridViewTaskCodeList.Rows[i].Cells[1].Value.ToString();
                                    String mUOM = dataGridViewTaskCodeList.Rows[i].Cells[2].Value.ToString();
                                    String mQuota = dataGridViewTaskCodeList.Rows[i].Cells[3].Value.ToString();
                                    String mProcessCode = cmbProcessCode.Text;

                                    if (String.IsNullOrEmpty(mTask_Code))
                                    {
                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask code field cannot be empty.", "Task Code Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[0];
                                        dataGridViewTaskCodeList.CurrentCell = cell;
                                        dataGridViewTaskCodeList.BeginEdit(true);
                                        return;
                                    }

                                    if (String.IsNullOrEmpty(mDescription))
                                    {
                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDescription field cannot be empty.", "Description Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[1];
                                        dataGridViewTaskCodeList.CurrentCell = cell;
                                        dataGridViewTaskCodeList.BeginEdit(true);
                                        return;
                                    }

                                    if (String.IsNullOrEmpty(mUOM))
                                    {
                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUOM field cannot be empty.", "UOM Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[2];
                                        dataGridViewTaskCodeList.CurrentCell = cell;
                                        dataGridViewTaskCodeList.BeginEdit(true);
                                        return;
                                    }
                                    if (String.IsNullOrEmpty(mQuota) || mQuota == "0")
                                    {
                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nQuota field cannot be empty.", "Quota Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[3];
                                        dataGridViewTaskCodeList.CurrentCell = cell;
                                        dataGridViewTaskCodeList.BeginEdit(true);
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (ex.HResult == -2147467261)
                                    {
                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask code field cannot be empty.", "Task Code Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        dataGridViewTaskCodeList.Focus();
                                        DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[0];
                                        dataGridViewTaskCodeList.CurrentCell = cell;
                                        dataGridViewTaskCodeList.BeginEdit(true);
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                            }

                        }

                        for (int i = 0; i < dataGridViewTaskCodeList.Rows.Count; i++)
                        {
                            

                            if (dataGridViewTaskCodeList.Rows.Count - 1 == i && dataGridViewTaskCodeList.Rows.Count !=1)
                            {
                                String mDescription1 = dataGridViewTaskCodeList.Rows[i-1].Cells[1].Value.ToString();
                                String mUOM1 = dataGridViewTaskCodeList.Rows[i - 1].Cells[2].Value.ToString();
                                String mQuota1 = dataGridViewTaskCodeList.Rows[i - 1].Cells[3].Value.ToString();

                                String mDescription = dataGridViewTaskCodeList.Rows[i].Cells[1].Value.ToString();
                                String mUOM = dataGridViewTaskCodeList.Rows[i].Cells[2].Value.ToString();
                                String mQuota = dataGridViewTaskCodeList.Rows[i].Cells[3].Value.ToString();

                                if (mDescription1 == mDescription && mUOM1 == mUOM && mQuota1== mQuota)
                                {
                                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nEntered task details alrady exist! Please check and change following details.\n- Description\n- UOM\n- Quota", "Task Code Vaditaion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cmbProcessCode.Focus();
                                    return;
                                }

                            }

                        }

                        for (int i = 0; i < dataGridViewTaskCodeList.Rows.Count;)
                        {
                            //increment i
                            i = dataGridViewTaskCodeList.Rows.Count + 1;

                            dataGridViewTaskCodeList.Rows.Add(ChunkCode + i, "", "", 0, false, "Remove");
                            dataGridViewTaskCodeList.Refresh();

                            //Lock Project Code
                            cmbProjectName.Enabled = false;
                            cmbProcessCode.Enabled = false;
                            break;

                        }

                    }
                    //If taskcode exists
                    else
                    {
                        if (dataGridViewTaskCodeList.Rows.Count != 0)
                        {
                            
                            for (int i = 0; i < dataGridViewTaskCodeList.Rows.Count;i++)
                            {

                                if (dataGridViewTaskCodeList.Rows.Count-1 == i)
                                {
                                    String mDescription = dataGridViewTaskCodeList.Rows[i].Cells[1].Value.ToString();
                                    String mUOM = dataGridViewTaskCodeList.Rows[i].Cells[2].Value.ToString();
                                    String mQuota = dataGridViewTaskCodeList.Rows[i].Cells[3].Value.ToString();
                                    String mProcessCode = cmbProcessCode.Text;

                                    if (new TaskDetailMng(this.conn).TaskCodeDetailIsExixts(mDescription, mUOM, mQuota, mProcessCode))
                                    {
                                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nEntered task details alrady exist! Please check and change following details.\n- Description\n- UOM\n- Quota", "Task Code Vaditaion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        cmbProcessCode.Focus();
                                        return;
                                    }

                                }

                            }

                            for (int i = 0; i < dataGridViewTaskCodeList.Rows.Count; i++)
                            {

                                if (dataGridViewTaskCodeList.Rows.Count - 1 == i)
                                {
                                    try
                                    {
                                        String mTask_Code = dataGridViewTaskCodeList.Rows[i].Cells[0].Value.ToString();
                                        String mDescription = dataGridViewTaskCodeList.Rows[i].Cells[1].Value.ToString();
                                        String mUOM = dataGridViewTaskCodeList.Rows[i].Cells[2].Value.ToString();
                                        String mQuota = dataGridViewTaskCodeList.Rows[i].Cells[3].Value.ToString();
                                        String mProcessCode = cmbProcessCode.Text;

                                        if (String.IsNullOrEmpty(mTask_Code))
                                        {
                                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask code field cannot be empty.", "Task Code Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[0];
                                            dataGridViewTaskCodeList.CurrentCell = cell;
                                            dataGridViewTaskCodeList.BeginEdit(true);
                                            return;
                                        }

                                        if (String.IsNullOrEmpty(mDescription))
                                        {
                                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDescription field cannot be empty.", "Description Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[1];
                                            dataGridViewTaskCodeList.CurrentCell = cell;
                                            dataGridViewTaskCodeList.BeginEdit(true);
                                            return;
                                        }

                                        if (String.IsNullOrEmpty(mUOM))
                                        {
                                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUOM field cannot be empty.", "UOM Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[2];
                                            dataGridViewTaskCodeList.CurrentCell = cell;
                                            dataGridViewTaskCodeList.BeginEdit(true);
                                            return;
                                        }
                                        if (String.IsNullOrEmpty(mQuota) || mQuota == "0")
                                        {
                                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nQuota field cannot be empty.", "Quota Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[3];
                                            dataGridViewTaskCodeList.CurrentCell = cell;
                                            dataGridViewTaskCodeList.BeginEdit(true);
                                            return;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        if(ex.HResult == -2147467261)
                                        {
                                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask code field cannot be empty.", "Task Code Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            dataGridViewTaskCodeList.Focus();
                                            DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[0];
                                            dataGridViewTaskCodeList.CurrentCell = cell;
                                            dataGridViewTaskCodeList.BeginEdit(true);
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

                        for (int i = 0; i < dataGridViewTaskCodeList.Rows.Count;)
                        {
                            //increment i
                            i = dataGridViewTaskCodeList.Rows.Count + 1;

                            dataGridViewTaskCodeList.Rows.Add(ChunkCode + (i + int.Parse(uCount)), "", "", 0, false, "Remove");
                            dataGridViewTaskCodeList.Refresh();

                            //Lock Project Code
                            cmbProjectName.Enabled = false;
                            cmbProcessCode.Enabled = false;
                            break;

                        }
                    }

                }
                else
                {
                    //If grid view not null and not exists
                    if (String.IsNullOrEmpty(uCount))
                    {
                        dataGridViewTaskCodeList.Rows.Add(ChunkCode + 1, "", "", 0, false, "Remove");

                        cmbProjectName.Enabled = false;
                        cmbProcessCode.Enabled = false;
                    }
                    //If grid view not null and exists
                    else
                    {
                        
                        for (int i = 0; i < dataGridViewTaskCodeList.Rows.Count+1;)
                        {
                            //increment i
                            i = dataGridViewTaskCodeList.Rows.Count + 1;

                            dataGridViewTaskCodeList.Rows.Add(ChunkCode + (i + int.Parse(uCount)), "", "", 0, false, "Remove");
                            dataGridViewTaskCodeList.Refresh();

                            //Lock Project Code
                            cmbProjectName.Enabled = false;
                            cmbProcessCode.Enabled = false;
                            break;

                        }

                    }

                }

            }
        }

        //Remove Temperary added task codes
        private void dataGridViewTaskCodeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    dataGridViewTaskCodeList.Rows[e.RowIndex].Cells[0].ReadOnly = true;

                }

                if (e.ColumnIndex == 5)
                {
                    String currentValue = dataGridViewTaskCodeList.CurrentRow.Cells[0].Value.ToString();

                    DialogResult resulta = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nAre you sure want to delete task code \"" + currentValue + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resulta == DialogResult.Yes)
                    {
                        if (dataGridViewTaskCodeList.Columns[e.ColumnIndex].Index == 5)
                        {
                            dataGridViewTaskCodeList.Rows.RemoveAt(dataGridViewTaskCodeList.CurrentRow.Index);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147467261)
                {
                    return;
                }
                else
                {
                    return;
                    //MessageBox.Show("Message: " + ex.HResult, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            dataGridViewTaskCodeList.Rows.Clear();

            cmbProjectName.Enabled = true;
            cmbProcessCode.Enabled = true;
        }


        //Register Task Code button
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
            if (String.IsNullOrEmpty(cmbProcessCode.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nProcess code field cannot be empty..!", "Process Code Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProcessCode.Focus();
                return;
            }

            if (dataGridViewTaskCodeList.Rows.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask code(s) not found in \"Task Code List\".\nPlease add tasks to list first.", "Task Codes Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }

            if (dataGridViewTaskCodeList.Rows.Count != 0)
            {

                for (int i = 0; i < dataGridViewTaskCodeList.Rows.Count; i++)
                {

                    if (dataGridViewTaskCodeList.Rows.Count - 1 == i)
                    {
                        String mDescription = dataGridViewTaskCodeList.Rows[i].Cells[1].Value.ToString();
                        String mUOM = dataGridViewTaskCodeList.Rows[i].Cells[2].Value.ToString();
                        String mQuota = dataGridViewTaskCodeList.Rows[i].Cells[3].Value.ToString();
                        String mProcessCode = cmbProcessCode.Text;

                        if (new TaskDetailMng(this.conn).TaskCodeDetailIsExixts(mDescription, mUOM, mQuota, mProcessCode))
                        {
                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nFinally entered task detail is alrady exist! Please check and change following details.\n- Description\n- UOM\n- Quota", "Task Code Vaditaion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbProcessCode.Focus();
                            return;
                        }

                    }

                }
                for (int i = 0; i < dataGridViewTaskCodeList.Rows.Count; i++)
                {

                    if (dataGridViewTaskCodeList.Rows.Count - 1 == i)
                    {
                        try
                        {
                            String mTask_Code = dataGridViewTaskCodeList.Rows[i].Cells[0].Value.ToString();
                            String mDescription = dataGridViewTaskCodeList.Rows[i].Cells[1].Value.ToString();
                            String mUOM = dataGridViewTaskCodeList.Rows[i].Cells[2].Value.ToString();
                            String mQuota = dataGridViewTaskCodeList.Rows[i].Cells[3].Value.ToString();                            
                            String mProcessCode = cmbProcessCode.Text;

                            if (String.IsNullOrEmpty(mTask_Code))
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask code field cannot be empty.", "Task Code Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[0];
                                dataGridViewTaskCodeList.CurrentCell = cell;
                                dataGridViewTaskCodeList.BeginEdit(true);
                                return;
                            }

                            if (String.IsNullOrEmpty(mDescription))
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDescription field cannot be empty.", "Description Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[1];
                                dataGridViewTaskCodeList.CurrentCell = cell;
                                dataGridViewTaskCodeList.BeginEdit(true);
                                return;
                            }

                            if (String.IsNullOrEmpty(mUOM))
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUOM field cannot be empty.", "UOM Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[2];
                                dataGridViewTaskCodeList.CurrentCell = cell;
                                dataGridViewTaskCodeList.BeginEdit(true);
                                return;
                            }
                            if (String.IsNullOrEmpty(mQuota) || mQuota == "0")
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nQuota field cannot be empty.", "Quota Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[3];
                                dataGridViewTaskCodeList.CurrentCell = cell;
                                dataGridViewTaskCodeList.BeginEdit(true);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex.HResult == -2147467261)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask code field cannot be empty.", "Task Code Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dataGridViewTaskCodeList.Focus();
                                DataGridViewCell cell = dataGridViewTaskCodeList.Rows[i].Cells[0];
                                dataGridViewTaskCodeList.CurrentCell = cell;
                                dataGridViewTaskCodeList.BeginEdit(true);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Message: " + ex.HResult, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }

                }
            }

            //DialogResult resulta = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to add new task code?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (resulta == DialogResult.Yes)
            //{
                string SplitProjectName = cmbProjectName.Text.Substring(0, 3);
                string SplitProcessCode = cmbProcessCode.Text.Substring(3, 2);

                string ChunkCode = SplitProjectName + "_" + SplitProcessCode;

                //Check Count of Exists Task IDs
                String uCount = new TaskHeaderMng(this.conn).TaskCodeExisltMAXCount(ChunkCode, cmbProcessCode.Text, cmbProjectName.Text);

                //Create Object
                TaskHeader mTaskHeader = new TaskHeader();
                TaskDetail mTaskDetail = new TaskDetail();
                TaskHeaderMng mTaskHeaderMng = new TaskHeaderMng(this.conn);
                TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);


                //Initalize Objects

                //Loop until total Shipment File Count Registerd into the ShipmentDetails Tabele
                for (int i = 0; i < dataGridViewTaskCodeList.Rows.Count; i++)
                {
                    //Assign ProcessCodeHeader Interface data
                    //Header
                    mTaskHeader.Task_ID = dataGridViewTaskCodeList.Rows[i].Cells[0].Value.ToString();
                    mTaskHeader.PC_ProcessCode = cmbProcessCode.Text.ToUpper();
                    mTaskHeader.PIC_Project = cmbProjectName.Text.ToUpper();
                    bool mCheck = bool.Parse(dataGridViewTaskCodeList.Rows[i].Cells[4].Value.ToString());

                    //Check User output validation  /* 0 - Yes, 1 - No */
                    if (mCheck)
                    {
                        mTaskHeader.SkipOutputValidation = 1; /* 1 - No */
                    }
                    else
                    {
                        mTaskHeader.SkipOutputValidation = 0; /* 0 -  Yes */
                    }
                   

                    //Detail
                    mTaskDetail.Task_ID = dataGridViewTaskCodeList.Rows[i].Cells[0].Value.ToString();
                    mTaskDetail.Task_Description = dataGridViewTaskCodeList.Rows[i].Cells[1].Value.ToString();
                    mTaskDetail.Task_UOM = dataGridViewTaskCodeList.Rows[i].Cells[2].Value.ToString();
                    mTaskDetail.Task_Quota = int.Parse(dataGridViewTaskCodeList.Rows[i].Cells[3].Value.ToString());
                    mTaskDetail.PC_ProcessCode = cmbProcessCode.Text.ToUpper();
                    mTaskDetail.PIC_Project = cmbProjectName.Text.ToUpper();

                    if (mTaskHeaderMng.AddTaskCode(mTaskHeader) > 0)
                    {
                        if (mTaskDetailMng.AddTaskDetail(mTaskDetail) > 0)
                        {
                               
                        }
                            
                    }

                }

                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nNew task code(s) added under \"" + cmbProcessCode.Text.ToUpper() + "\" process code..!", "New Task Codes Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
                ClearFields();

            //}
        }

        //Modify button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewTaskCodes.SelectedRows.Count > 0)
            {
                try
                {
                    String mTask_Code = dataGridViewTaskCodes.SelectedRows[0].Cells[1].Value.ToString();
                    String mDescription = dataGridViewTaskCodes.SelectedRows[0].Cells[2].Value.ToString();
                    String mUOM = dataGridViewTaskCodes.SelectedRows[0].Cells[3].Value.ToString();
                    String mQuota = dataGridViewTaskCodes.SelectedRows[0].Cells[4].Value.ToString();
                    String mProject = dataGridViewTaskCodes.SelectedRows[0].Cells[5].Value.ToString(); ;
                    String mProcessCode = dataGridViewTaskCodes.SelectedRows[0].Cells[6].Value.ToString(); ;
                    int mSkipvalidation = int.Parse(dataGridViewTaskCodes.SelectedRows[0].Cells[7].Value.ToString());

                    if (String.IsNullOrEmpty(mTask_Code))
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask code field cannot be empty.", "Task Code Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    frm_TaskCodeModify frmMofidy = new frm_TaskCodeModify(mTask_Code, mDescription, mUOM, mQuota, mProject, mProcessCode, mSkipvalidation);
                    frmMofidy.Show();

                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2147467261)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask code field cannot be empty.", "Task Code Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select a record fisrt.", "Invalid Task Code!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //Refresh button
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbProjectName.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select a project first.", "Project Not Enterd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProjectName.Focus();
                return;
            }

            if (String.IsNullOrEmpty(cmbProcessCode.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select process code first.", "Process Code Not Enterd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProcessCode.Focus();
                return;
            }

            DialogResult resultab = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to delete all task codes under \"" + cmbProcessCode.Text + "\" process code?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultab == DialogResult.Yes)
            {
                TaskHeader mTaskHeader = new TaskHeader();
                mTaskHeader.PIC_Project = cmbProjectName.Text;
                mTaskHeader.PC_ProcessCode = cmbProcessCode.Text;


                if (new TaskHeaderMng(this.conn).DeleteTaskCodebyProcessCode(mTaskHeader) > 0)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask codes deleted under \"" + cmbProcessCode.Text + "\" process code.", "Task Codes Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                    ClearFields();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere are no task code for selected process code.", "Process Code Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbProcessCode.Focus();
                    return;
                }
            }
        }


        //Delete task code by grid
        private void dataGridViewTaskCodes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewTaskCodes.Columns[e.ColumnIndex].Index == 0)
            {
                String mTaskCode = dataGridViewTaskCodes.CurrentRow.Cells[1].Value.ToString();
                String dProject = dataGridViewTaskCodes.CurrentRow.Cells[5].Value.ToString();
                String dProcessCode = dataGridViewTaskCodes.CurrentRow.Cells[6].Value.ToString();

                DialogResult resulta = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nAre you sure want to delete task code \"" + mTaskCode + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {

                    TaskDetail mTaskDetail = new TaskDetail();
                    TaskHeader mTaskHeader = new TaskHeader();


                    //Initialize Detail
                    mTaskDetail.Task_ID = mTaskCode;
                    mTaskDetail.PIC_Project = dProject;
                    mTaskDetail.PC_ProcessCode = dProcessCode;

                    //Initialize Header
                    mTaskHeader.Task_ID = mTaskCode;
                    


                    if (new TaskDetailMng(this.conn).DeleteTaskDetail(mTaskDetail) > 0)
                    {
                        if (new TaskHeaderMng(this.conn).DeleteTaskCodeHeader(mTaskHeader) > 0)
                        {
                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask code \"" + mTaskCode + "\" has been deleted.", "Task Code Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshData();
                            ClearFields();
                        }

                    }

                }
            }

        }

        private void dataGridViewTaskCodes_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            try
            {
                if (e.RowIndex1 == 0)
                    e.Handled = true;
                if (e.RowIndex2 == 0)
                    e.Handled = true;
                return;
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233079)
                {
                    //..
                }
                else
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
        }

        private void cmbProcessCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbProjectName.Text)&& !String.IsNullOrEmpty(cmbProcessCode.Text))
            {
                dataGridViewTaskCodes.DataSource = new TaskDetailMng(this.conn).GetAllTaskCodeDetailsByPICUID_Project_ProcessCode(lblUID.Text.ToUpper(), cmbProjectName.Text,cmbProcessCode.Text);
            }
        }

        //Exit button
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void frm_TaskCodeRegister_Enter(object sender, EventArgs e)
        {
            //Refresh data fields
            RefreshData();

            //Clear All Fields when Load
            ClearFields();

        }

        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewTaskCodes.Columns)
            {
                try
                {
                    dt.Columns.Add(column.HeaderText);
                    //dt.Columns.Add(column.HeaderText, column.ValueType);
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2147467261)
                    {
                        //Do niothing...
                    }
                }

            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewTaskCodes.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {
                        if (i == 0)
                        {

                        }
                        else if (i == 7)
                        {
                            if ((Int32)row.Cells[7].Value == 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][7] = "Yes";
                            }
                            else if ((Int32)row.Cells[7].Value == 1)
                            {
                                dt.Rows[dt.Rows.Count - 1][7] = "No";
                            }

                        }
                        else
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Value.ToString();
                        }

                        //foreach (DataGridViewCell cell in row.Cells)
                        //{
                        //    try
                        //    {                        
                        //        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex - 1] = cell.Value.ToString();

                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        if (ex.HResult == -2147024809)
                        //        {
                        //            //cell.Value = DateTime.ParseExact(cell.Value.ToString(), "dd MM yyyy hh:mm:ss tt", null);
                        //        }

                        //    }

                        //}
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
                               var ws = wb.Worksheets.Add(dt, "CITITO_" + lblUID.Text + "_Task Code Details");
                               ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask Code details successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + lblUID.Text + "_Task Code Details");
                            ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask Code details successfully saved to \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        //bulk import button
        private void btnBulkImport_Click(object sender, EventArgs e)
        {
            //MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThis is under construction.", "Bulk User Registration!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string uPIC = lblUID.Text;

            //Form Open by PIC System Access Level

            frm_BulkImport_Quota form = frm_BulkImport_Quota.GetInstance(uPIC);
            if (!form.Visible)
            {

                form.Show();

            }
            else
            {
                form.BringToFront();
            }
        }

        private void dataGridViewTaskCodeList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTaskCodeList.Rows.Count!=0)
            {
                if (e.ColumnIndex == 0)
                {
                    dataGridViewTaskCodeList.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                    
                    return;
                }
            }
            
            
        }

        private void dataGridViewTaskCodeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTaskCodeList.Rows.Count != 0)
            {
                if (e.ColumnIndex == 0)
                {
                    dataGridViewTaskCodeList.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                    
                    return;
                }
            }
        }

        private void dataGridViewTaskCodes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //User output validation /* 0 - Yes, 1 - No */
            if (e.ColumnIndex == 7)
            {
                if ((int)e.Value == 0)
                {
                    e.Value = "Yes";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                }
                else if ((int)e.Value == 1)
                {
                    e.Value = "No";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");
                }
                
            }
        }
    }
}
