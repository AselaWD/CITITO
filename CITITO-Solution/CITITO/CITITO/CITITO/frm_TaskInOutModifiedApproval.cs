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
    public partial class frm_TaskInOutModifiedApproval : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_TaskInOutModifiedApproval _instance;
        public static frm_TaskInOutModifiedApproval GetInstance(string uPIC, string uMUID)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mPIC = uPIC;
                String mMUID = uMUID;


                _instance = new frm_TaskInOutModifiedApproval(mPIC, mMUID);

            }
            return _instance;

        }

        public frm_TaskInOutModifiedApproval(string uPIC, string uMUID)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblMUID.Text = uMUID;
            lblPIC.Text = uPIC;

        }

        /*CITITO Server Time*/
        public DateTime ServerDateTime()
        {
            ServerTime mServerTime = new ServerTime(this.conn);
            DateTime sDate = mServerTime.getServerTime();
            return sDate;
        }

        //Refresh Object
        public void RefreshData()
        {
            string uMID = lblMUID.Text;
            string uPIC = lblPIC.Text;

            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                cmbMUID1.DataSource = new ManagerHeaderMng(this.conn).GetActiveManagerUIDByPIC(uPIC);
                cmbMUID1.SelectedIndex = -1;
                cmbMUID1.Enabled = true;
                btnApprove.Visible = true;
                btnDisapprove.Visible = true;
                btnHistory.Visible = true;

                //Fill Datagridview
                dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetPendingModifiedTaskRecordByPIC(uPIC);

            }
            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMID))
            {
                cmbMUID1.Items.Add(uMID);
                cmbMUID1.SelectedIndex = 0;
                cmbMUID1.Enabled = false;
                btnApprove.Visible = false;
                btnDisapprove.Visible = false;
                btnHistory.Visible = false;

                dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetPendingModifiedTaskRecordByManager(uMID);

            }

            headerCheckBox.Checked = false;
        }

        public void ClearFields()
        {
            RefreshData();

        }

        private void frm_TaskInOutModifiedApproval_Load(object sender, EventArgs e)
        {
            RefreshData();

            this.BindGrid();

            dataGridViewTaskInOutModifiedApproval.Columns[0].Width = 30;
            dataGridViewTaskInOutModifiedApproval.Columns[1].Width = 80;
            dataGridViewTaskInOutModifiedApproval.Columns[2].Width = 40;
            //dataGridViewTaskInOutModifiedApproval.Columns[5].Width = 40;
            dataGridViewTaskInOutModifiedApproval.Columns[6].Width = 55;
            dataGridViewTaskInOutModifiedApproval.Columns[8].Width = 50;
        }

        CheckBox headerCheckBox = new CheckBox();

        private void BindGrid()
        {
            //Add a CheckBox Column to the DataGridView Header Cell.

            //Find the Location of Header Cell.
            Point headerCellLocation = this.dataGridViewTaskInOutModifiedApproval.GetCellDisplayRectangle(0, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 20);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dataGridViewTaskInOutModifiedApproval.Controls.Add(headerCheckBox);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridViewTaskInOutModifiedApproval.Columns.Insert(0, checkBoxColumn);

            //Assign Click event to the DataGridView Cell.
            dataGridViewTaskInOutModifiedApproval.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dataGridViewTaskInOutModifiedApproval.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dataGridViewTaskInOutModifiedApproval.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }


        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void dataGridViewTaskInOutModifiedApproval_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            foreach (DataGridViewRow row in dataGridViewTaskInOutModifiedApproval.SelectedRows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                if (isSelected)
                {
                    row.Cells[0].Value = false;

                    //Loop to verify whether all row CheckBoxes are checked or not.
                    bool isChecked = true;
                    foreach (DataGridViewRow row2 in dataGridViewTaskInOutModifiedApproval.Rows)
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
                    foreach (DataGridViewRow row2 in dataGridViewTaskInOutModifiedApproval.Rows)
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

        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmbMUID1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uUID = cmbUserID.Text;
            string uMUID = cmbMUID1.Text;

            string uMID = lblMUID.Text;
            string uPIC = lblPIC.Text;

            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetPendingModifiedTaskRecordByPIC(uPIC);
            }
            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMID))
            {
                dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetPendingModifiedTaskRecordByManager(uMUID);
            }
 
        }

        private void dataGridViewTaskInOutModifiedApproval_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set the background to red for negative values in the Balance column.
            if (dataGridViewTaskInOutModifiedApproval.Rows.Count != 0)
            {


                if (dataGridViewTaskInOutModifiedApproval.Columns[e.ColumnIndex].Index == 8)
                {

                    if (e.Value.ToString() != "")
                    {
                        if (e.Value.ToString() == "0")
                        {
                            e.Value = "Fresh";
                            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                        }
                        else if (e.Value.ToString() == "1")
                        {
                            e.Value = "Hold";
                            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FD7C66");
                        }
                        else if (e.Value.ToString() == "2")
                        {
                            e.Value = "Pending";
                            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");
                        }
                        else if (e.Value.ToString() == "3")
                        {
                            e.Value = "Done";
                            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9FEB");
                        }
                    }
                }
                if (dataGridViewTaskInOutModifiedApproval.Columns[e.ColumnIndex].Index == 11)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.###");
                }

                if (dataGridViewTaskInOutModifiedApproval.Columns[e.ColumnIndex].Index == 12)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "No Status";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                    }
                    else if (e.Value.ToString() == "1")
                    {
                        e.Value = "PIC Pending";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");
                    }
                    else if (e.Value.ToString() == "2")
                    {
                        e.Value = "PIC Approved";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9FEB");
                    }
                    else if (e.Value.ToString() == "3")
                    {
                        e.Value = "PIC Disapproved";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FD7C66");
                    }
                }

                if (dataGridViewTaskInOutModifiedApproval.Columns[e.ColumnIndex].Index == 14)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.###") + "%";

                    if (d == 0)
                    {
                        e.Value = "Not Calcutated";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");
                    }
                }

            }
        }

        //Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTaskInOutModifiedApproval.Rows.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Check if there any checkbox checked/unchecked in cloumn 0

            for (int j = 0; j < dataGridViewTaskInOutModifiedApproval.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewTaskInOutModifiedApproval[0, j].Value) == false)
                {

                    if ((dataGridViewTaskInOutModifiedApproval.RowCount - 1) == j)
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

            TaskRecordHeaderModify mTaskRecordHeaderModify = new TaskRecordHeaderModify();
            TaskRecordHeaderModifyMng mTaskRecordHeaderModifyMng = new TaskRecordHeaderModifyMng(this.conn);

            TaskRecordDetailModify mTaskRecordDetailModify = new TaskRecordDetailModify();
            TaskRecordDetailModifyMng mTaskRecordDetailModifyMng = new TaskRecordDetailModifyMng(this.conn);

            int records = 0;

            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to delete selected record(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                for (int j = 0; j < dataGridViewTaskInOutModifiedApproval.RowCount; j++)
                {
                    //initialize Approval Header
                    mTaskRecordHeaderModify.TRM_ID = dataGridViewTaskInOutModifiedApproval[1, j].Value.ToString();
                    mTaskRecordHeaderModify.TR_ID = dataGridViewTaskInOutModifiedApproval[3, j].Value.ToString();
                    mTaskRecordHeaderModify.PCP_ID = dataGridViewTaskInOutModifiedApproval[4, j].Value.ToString();

                    //initialize Approval Details
                    mTaskRecordDetailModify.TRM_ID = dataGridViewTaskInOutModifiedApproval[1, j].Value.ToString();
                    mTaskRecordDetailModify.TR_File = dataGridViewTaskInOutModifiedApproval[5, j].Value.ToString();
                    mTaskRecordDetailModify.TR_Status = int.Parse(dataGridViewTaskInOutModifiedApproval[8, j].Value.ToString());

                    if (Convert.ToBoolean(dataGridViewTaskInOutModifiedApproval[0, j].Value) == true)
                    {
                        if (int.Parse(dataGridViewTaskInOutModifiedApproval[12, j].Value.ToString()) == 1)
                        {
                            if (mTaskRecordDetailModifyMng.DeleteTaskModifiedRecordDetail(mTaskRecordDetailModify) > 0)
                            {
                                mTaskRecordHeaderModifyMng.DeleteTaskModifiedRecordHeader(mTaskRecordHeaderModify);
                            }
                        }
                        else
                        {
                            records += 1;
                        }

                    }

                }
                if (records!=0)
                {
                    //Show Completed Message
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been deleted except \"Approved\" and \"Disapproved\" record(s).", "Record(s) Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //Approve button
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dataGridViewTaskInOutModifiedApproval.Rows.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Check if there any checkbox checked/unchecked in cloumn 0

            for (int j = 0; j < dataGridViewTaskInOutModifiedApproval.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewTaskInOutModifiedApproval[0, j].Value) == false)
                {

                    if ((dataGridViewTaskInOutModifiedApproval.RowCount - 1) == j)
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


            TaskRecordDetailModify mTaskRecordDetailModify = new TaskRecordDetailModify();
            TaskRecordDetailModifyMng mTaskRecordDetailModifyMng = new TaskRecordDetailModifyMng(this.conn);

            TaskRecordDetail mTaskRecordDetail = new TaskRecordDetail();
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);


            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to approve selected record(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Initialize Modifed Record Detail Part 1
                mTaskRecordDetailModify.TRM_ApprovalTime = ServerDateTime();

                //Initialize Task Reocord Part 1
                mTaskRecordDetail.TR_ApprovalTime = ServerDateTime();

                for (int j = 0; j < dataGridViewTaskInOutModifiedApproval.RowCount; j++)
                {

                    //Initialize Modifed Record Detail Part 2
                    mTaskRecordDetailModify.TRM_Apporval = 2; /* 1 - Pending,  2 - Approved, 3 - Disapproved, 4 - Skipped */
                    mTaskRecordDetailModify.TRM_ID = dataGridViewTaskInOutModifiedApproval[1, j].Value.ToString();
                    mTaskRecordDetailModify.TR_File = dataGridViewTaskInOutModifiedApproval[5, j].Value.ToString();
                    mTaskRecordDetailModify.TR_FileSize = int.Parse(dataGridViewTaskInOutModifiedApproval[6, j].Value.ToString());
                    mTaskRecordDetailModify.TR_Status = int.Parse(dataGridViewTaskInOutModifiedApproval[8, j].Value.ToString());

                    //Initialize Task Reocord Part 2
                    mTaskRecordDetail.TR_Apporval = 2; /* 1 - Pending,  2 - Approved, 3 - Disapproved, 4 - Skipped */                  
                    mTaskRecordDetail.TR_ID = dataGridViewTaskInOutModifiedApproval[3, j].Value.ToString();
                    mTaskRecordDetail.TR_File = dataGridViewTaskInOutModifiedApproval[5, j].Value.ToString();
                    mTaskRecordDetail.TR_FileSize = int.Parse(dataGridViewTaskInOutModifiedApproval[6, j].Value.ToString());
                    mTaskRecordDetail.TR_Productivity = float.Parse(dataGridViewTaskInOutModifiedApproval[14, j].Value.ToString());

                    /*Added new Modified Task version 2.0 - (2018-08-06) */
                    mTaskRecordDetail.TR_InDate = DateTime.Parse(dataGridViewTaskInOutModifiedApproval[9, j].Value.ToString());
                    mTaskRecordDetail.TR_OutDate = DateTime.Parse(dataGridViewTaskInOutModifiedApproval[10, j].Value.ToString());
                    mTaskRecordDetail.TR_Hours = float.Parse(dataGridViewTaskInOutModifiedApproval[11, j].Value.ToString());


                    if (Convert.ToBoolean(dataGridViewTaskInOutModifiedApproval[0, j].Value) == true)
                    {
                        //Approve Modified Task record
                        if (mTaskRecordDetailModifyMng.UpdateModifiedTaskRecordDetailToAprroved(mTaskRecordDetailModify) > 0)
                        {
                            //Update User Task Recod
                            mTaskRecordDetailMng.UpdateTaskRecordDetailWithModifiedRecrodAndApprove(mTaskRecordDetail);
                        }
                    }
                }

                //Show Completed Message
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been approved.", "Record(s) Approved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
                ClearFields();

            }

        }

        //Disapprove button
        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            //UpdateModifiedTaskRecordDetailToDisprroved

            if (dataGridViewTaskInOutModifiedApproval.Rows.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Check if there any checkbox checked/unchecked in cloumn 0

            for (int j = 0; j < dataGridViewTaskInOutModifiedApproval.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewTaskInOutModifiedApproval[0, j].Value) == false)
                {

                    if ((dataGridViewTaskInOutModifiedApproval.RowCount - 1) == j)
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

            TaskRecordDetailModify mTaskRecordDetailModify = new TaskRecordDetailModify();
            TaskRecordDetailModifyMng mTaskRecordDetailModifyMng = new TaskRecordDetailModifyMng(this.conn);


            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to disapprove selected record(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Initialize Modifed Record Detail Part 1
                mTaskRecordDetailModify.TRM_ApprovalTime = ServerDateTime();

                for (int j = 0; j < dataGridViewTaskInOutModifiedApproval.RowCount; j++)
                {
                    //Initialize Modifed Record Detail Part 2
                    mTaskRecordDetailModify.TRM_Apporval = 3; /* 1 - Pending,  2 - Approved, 3 - Disapproved, 4 - Skipped */
                    mTaskRecordDetailModify.TRM_ID = dataGridViewTaskInOutModifiedApproval[1, j].Value.ToString();
                    mTaskRecordDetailModify.TR_File = dataGridViewTaskInOutModifiedApproval[5, j].Value.ToString();
                    mTaskRecordDetailModify.TR_FileSize = int.Parse(dataGridViewTaskInOutModifiedApproval[6, j].Value.ToString());
                    mTaskRecordDetailModify.TR_Status = int.Parse(dataGridViewTaskInOutModifiedApproval[8, j].Value.ToString());

                    if (Convert.ToBoolean(dataGridViewTaskInOutModifiedApproval[0, j].Value) == true)
                    {
                        //Disapprove Modified Record
                        mTaskRecordDetailModifyMng.UpdateModifiedTaskRecordDetailToDisprroved(mTaskRecordDetailModify);
                    }
                }

                //Show Completed Message
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been disapproved.", "Record(s) Disapproved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
                ClearFields();
            }
        }

        //Filters
        private void cmbFApproved_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uApproval = cmbFApproved.Text;
            string uMUID = cmbMUID1.Text;
            string uPIC = lblPIC.Text;

            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                if (uApproval == "Pending")
                {
                    uApproval = "1";
                    dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedTaskInOutRecordByApprovedAndPIC(uPIC, uApproval);
                }
                
            }

            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMUID))
            {
                if (uApproval == "Pending")
                {
                    uApproval = "1";
                    dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedTaskInOutRecordByApprovedAndManager(uMUID, uApproval);
                }
                if (uApproval == "Approved")
                {
                    uApproval = "2";
                    dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedTaskInOutRecordByApprovedAndManager(uMUID, uApproval);
                }
                if (uApproval == "Disapproved")
                {
                    uApproval = "3";
                    dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedTaskInOutRecordByApprovedAndManager(uMUID, uApproval);
                }
            }
        }

        private void cmbUserID_KeyUp(object sender, KeyEventArgs e)
        {
            string uUID = cmbUserID.Text;
            string uMUID = cmbMUID1.Text;
            string uPIC = lblPIC.Text;

            if (cmbMUID1.Enabled)
            {
                if (!String.IsNullOrEmpty(uUID))
                {
                    dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedTaskInOutRecordByPICAndUID(uUID, uPIC);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(uUID))
                {
                    dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedTaskInOutRecordByManagerAndUID(uUID, uMUID);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
        }

        private void cmbPCPCode_KeyUp(object sender, KeyEventArgs e)
        {
            string uPCPCode = cmbPCPCode.Text;
            string uMUID = cmbMUID1.Text;
            string uPIC = lblPIC.Text;

            if (cmbMUID1.Enabled)
            {
                if (!String.IsNullOrEmpty(uPCPCode))
                {
                    dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedTaskInOutRecordByPICAndPCPCode(uPCPCode, uPIC);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(uPCPCode))
                {
                    dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedTaskInOutRecordByManagerAndPCPCode(uPCPCode, uMUID);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
        }

        private void cmbFileName_KeyUp(object sender, KeyEventArgs e)
        {
            string uFileName = cmbFileName.Text;
            string uMUID = cmbMUID1.Text;
            string uPIC = lblPIC.Text;

            if (cmbMUID1.Enabled)
            {
                if (!String.IsNullOrEmpty(uFileName))
                {
                    dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedTaskInOutRecordByPICAndFileName(uFileName, uPIC);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(uFileName))
                {
                    dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedTaskInOutRecordByManagerAndFileName(uFileName, uMUID);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string uMUID = lblMUID.Text;
            string uPIC = lblPIC.Text;
            DateTime uFrom = DateTime.Parse(dateTimePickerFrom.Value.ToString("MM-dd-yyyy 00:00:00"));
            DateTime uTo = DateTime.Parse(dateTimePickerTo.Value.ToString("MM-dd-yyyy 23:59:59"));

            if (cmbMUID1.Enabled)
            {
                dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedPCPRecordByDateRangeByPIC(uPIC, uFrom, uTo);
            }
            else
            {
                dataGridViewTaskInOutModifiedApproval.DataSource = new TaskRecordDetailModifyMng(this.conn).GetModifiedPCPRecordByDateRange(uMUID, uFrom, uTo);
            }
        }

        //Export To Excel
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewTaskInOutModifiedApproval.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewTaskInOutModifiedApproval.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {
                        if (i == 0)
                        {

                        }
                        else if (i == 8)
                        {
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
                        else if (i == 11)
                        {
                            dt.Rows[dt.Rows.Count - 1][11] = double.Parse(row.Cells[11].Value.ToString()).ToString("0.###");

                        }
                        else if (i == 12)
                        {

                            if ((Int32)row.Cells[12].Value == 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][12] = "No Status";
                            }
                            else if ((Int32)row.Cells[12].Value == 1)
                            {
                                dt.Rows[dt.Rows.Count - 1][12] = "Pending";
                            }
                            else if ((Int32)row.Cells[12].Value == 2)
                            {
                                dt.Rows[dt.Rows.Count - 1][12] = "Approved";
                            }
                            else if ((Int32)row.Cells[12].Value == 3)
                            {
                                dt.Rows[dt.Rows.Count - 1][12] = "Disapproved";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][12] = row.Cells[12].Value.ToString();
                            }

                        }
                        else if (i == 14)
                        {
                            //MessageBox.Show(row.Cells[14].Value.ToString(), "---");

                            if (row.Cells[14].Value.ToString() == "0")
                            {
                                dt.Rows[dt.Rows.Count - 1][14] = "Not Calcutated";
                            }
                            else
                            {
                                dt.Rows[dt.Rows.Count - 1][14] = double.Parse(row.Cells[14].Value.ToString()).ToString("0.###") + "%";
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

                //Exporting to Excel           

                try
                {

                    if (!System.IO.File.Exists(fileName))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(fileName))
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {

                                var ws = wb.Worksheets.Add(dt, "CITITO_" + lblMUID.Text + "_Modified Tasks");
                                ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nModified task records successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + lblMUID.Text + "_Modified Tasks");
                            ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nModified task records successfully export to \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        //History button
        private void btnHistory_Click(object sender, EventArgs e)
        {
            String uPIC = lblPIC.Text;
            String uMUID = lblMUID.Text;

            frm_TaskInOutModifiedApprovalHistory myForm = frm_TaskInOutModifiedApprovalHistory.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_ApprovalTaskInOut form1 = (frm_ApprovalTaskInOut)Application.OpenForms["frm_ApprovalTaskInOut"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();

            cmbUserID.Text = String.Empty;
            cmbFApproved.Text = String.Empty;
            cmbPCPCode.Text = String.Empty;
            cmbFileName.Text = String.Empty;

            dateTimePickerFrom.Value = ServerDateTime();
            dateTimePickerTo.Value = ServerDateTime();
        }
    }
}
