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
    public partial class frm_IDLEApprovalHistory : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_IDLEApprovalHistory _instance;
        public static frm_IDLEApprovalHistory GetInstance(string uPIC, string uMUID)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mPIC = uPIC;
                String mMUID = uMUID;


                _instance = new frm_IDLEApprovalHistory(mPIC, mMUID);

            }
            return _instance;

        }

        public frm_IDLEApprovalHistory(string uPIC, string uMUID)
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

        private void frm_IDLEApprovalHistory_Load(object sender, EventArgs e)
        {
            string uMID = lblMUID.Text;
            string uPIC = lblPIC.Text;
            DateTime uFrom = DateTime.Parse(dateTimePickerFrom.Value.ToString("MM-dd-yyyy 00:00:00"));
            DateTime uTo = DateTime.Parse(dateTimePickerTo.Value.ToString("MM-dd-yyyy 23:59:59"));

            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                cmbMUID1.DataSource = new ManagerHeaderMng(this.conn).GetActiveManagerUIDByPIC(uPIC);
                cmbMUID1.SelectedIndex = -1;
                cmbMUID1.Enabled = true;

                //Fill Datagridview
                dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByPIC(uPIC, uFrom, uTo);

            }
            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMID))
            {
                cmbMUID1.Items.Add(uMID);
                cmbMUID1.SelectedIndex = 0;
                cmbMUID1.Enabled = false;

                dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByManager(uMID, uFrom, uTo);

            }

            this.BindGrid();

            dataGridViewIDLEForApproval.Columns[0].Width = 30;
            dataGridViewIDLEForApproval.Columns[2].Width = 40;
            dataGridViewIDLEForApproval.Columns[3].Width = 55;
            //dataGridViewIDLEForApproval.Columns[5].Width = 105;
            dataGridViewIDLEForApproval.Columns[7].Width = 55;
            //dataGridViewIDLEForApproval.Columns[12].Width = 50;
        }

        //Go back button
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshData()
        {
            string uMID = lblMUID.Text;
            string uPIC = lblPIC.Text;
            DateTime uFrom = DateTime.Parse(dateTimePickerFrom.Value.ToString("MM-dd-yyyy 00:00:00"));
            DateTime uTo = DateTime.Parse(dateTimePickerTo.Value.ToString("MM-dd-yyyy 23:59:59"));

            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                cmbMUID1.DataSource = new ManagerHeaderMng(this.conn).GetActiveManagerUIDByPIC(uPIC);
                cmbMUID1.SelectedIndex = -1;
                cmbMUID1.Enabled = true;

                //Fill Datagridview
                dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByPIC(uPIC, uFrom, uTo);

            }
            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMID))
            {
                cmbMUID1.Items.Add(uMID);
                cmbMUID1.SelectedIndex = 0;
                cmbMUID1.Enabled = false;

                dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByManager(uMID, uFrom, uTo);

            }

            headerCheckBox.Checked = false;
        }

        CheckBox headerCheckBox = new CheckBox();

        private void BindGrid()
        {
            //Add a CheckBox Column to the DataGridView Header Cell.

            //Find the Location of Header Cell.
            Point headerCellLocation = this.dataGridViewIDLEForApproval.GetCellDisplayRectangle(0, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 10);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dataGridViewIDLEForApproval.Controls.Add(headerCheckBox);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridViewIDLEForApproval.Columns.Insert(0, checkBoxColumn);

            //Assign Click event to the DataGridView Cell.
            dataGridViewIDLEForApproval.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dataGridViewIDLEForApproval.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dataGridViewIDLEForApproval.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ClearFields()
        {
            RefreshData();

        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();

            cmbUserID.Text = String.Empty;
            cmbFApproved.Text = String.Empty;
            txtProject.Text = String.Empty;
            cmbUserID.Text = String.Empty;

            dateTimePickerFrom.Value = ServerDateTime();
            dateTimePickerTo.Value = ServerDateTime();
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void dataGridViewIDLEForApproval_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewIDLEForApproval.SelectedRows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                if (isSelected)
                {
                    row.Cells[0].Value = false;

                    //Loop to verify whether all row CheckBoxes are checked or not.
                    bool isChecked = true;
                    foreach (DataGridViewRow row2 in dataGridViewIDLEForApproval.Rows)
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
                    foreach (DataGridViewRow row2 in dataGridViewIDLEForApproval.Rows)
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

        private void dataGridViewIDLEForApproval_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set the background to red for negative values in the Balance column.
            if (dataGridViewIDLEForApproval.Rows.Count != 0)
            {

                if (dataGridViewIDLEForApproval.Columns[e.ColumnIndex].Index == 7)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.###");
                }

                if (dataGridViewIDLEForApproval.Columns[e.ColumnIndex].Index == 8)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.Value = "No Status";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                    }
                    else if (e.Value.ToString() == "1")
                    {
                        e.Value = "Pending";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");
                    }
                    else if (e.Value.ToString() == "2")
                    {
                        e.Value = "Approved";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9FEB");
                    }
                    else if (e.Value.ToString() == "3")
                    {
                        e.Value = "Disapproved";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FD7C66");
                    }
                }

            }
        }

        private void dataGridViewIDLEForApproval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                foreach (DataGridViewRow row in dataGridViewIDLEForApproval.SelectedRows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                    if (isSelected)
                    {
                        row.Cells[0].Value = false;

                        //Loop to verify whether all row CheckBoxes are checked or not.
                        bool isChecked = true;
                        foreach (DataGridViewRow row2 in dataGridViewIDLEForApproval.Rows)
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
                        foreach (DataGridViewRow row2 in dataGridViewIDLEForApproval.Rows)
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

        //Refresh button
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        //Filter 
        private void cmbMUID1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uUID = cmbUserID.Text;
            string uMUID = cmbMUID1.Text;
            DateTime uFrom = DateTime.Parse(dateTimePickerFrom.Value.ToString("MM-dd-yyyy 00:00:00"));
            DateTime uTo = DateTime.Parse(dateTimePickerTo.Value.ToString("MM-dd-yyyy 23:59:59"));

            dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByManager(uMUID, uFrom, uTo);
        }

        private void cmbFApproved_SelectedIndexChanged(object sender, EventArgs e)
        {
            string uApproval = cmbFApproved.Text;
            string uMUID = cmbMUID1.Text;
            string uPIC = lblPIC.Text;

            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                if (uApproval == "Approved")
                {
                    uApproval = "2";
                    dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByApprovedAndPIC(uPIC, uApproval);
                }
                if (uApproval == "Disapproved")
                {
                    uApproval = "3";
                    dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByApprovedAndPIC(uPIC, uApproval);
                }

            }

            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMUID))
            {

                if (uApproval == "Approved")
                {
                    uApproval = "2";
                    dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByApprovedAndManager(uMUID, uApproval);
                }
                if (uApproval == "Disapproved")
                {
                    uApproval = "3";
                    dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByApprovedAndManager(uMUID, uApproval);
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
                    dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByPICAndUID(uUID, uPIC);
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
                    dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByManagerAndUID(uUID, uMUID);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
        }

        private void txtProject_KeyUp(object sender, KeyEventArgs e)
        {
            string uProject = txtProject.Text;
            string uMUID = cmbMUID1.Text;
            string uPIC = lblPIC.Text;

            if (cmbMUID1.Enabled)
            {
                if (!String.IsNullOrEmpty(uProject))
                {
                    dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByPICAndProject(uProject, uPIC);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(uProject))
                {
                    dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByManagerAndProject(uProject, uMUID);
                }
                else
                {
                    RefreshData();
                    //ClearFields();
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dataGridViewIDLEForApproval.Rows.Count == 0)
            {
                //MessageBox.Show("There is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //Check if there any checkbox checked/unchecked in cloumn 0
            for (int j = 0; j < dataGridViewIDLEForApproval.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewIDLEForApproval[0, j].Value) == false)
                {
                    if ((dataGridViewIDLEForApproval.RowCount - 1) == j)
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


            IDLEDetail mIDLEDetail = new IDLEDetail();
            IDLEDetailMng mIDLEDetailMng = new IDLEDetailMng(this.conn);

            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to rollback selected record(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
                for (int j = 0; j < dataGridViewIDLEForApproval.RowCount; j++)
                {
                    if (Convert.ToBoolean(dataGridViewIDLEForApproval[0, j].Value) == true)
                    {

                        //initialize Approval Details part 2
                        mIDLEDetail.IDLE_ID = dataGridViewIDLEForApproval[1, j].Value.ToString();
                        mIDLEDetail.IDLE_UID = dataGridViewIDLEForApproval[2, j].Value.ToString();
                        mIDLEDetail.IDLE_Apporval = int.Parse(dataGridViewIDLEForApproval[8, j].Value.ToString()); /*1 - Pending, 2 - Approved, 3 - Disapproved*/

                        if (mIDLEDetailMng.UpdateIDLERecordDetailToRollback(mIDLEDetail) > 0)
                        {

                        }

                    }
                }

                //Show Completed Message
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been rollback!", "Record(s) Rollback!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
                //ClearFields();

            }
        }

        //Export button
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewIDLEForApproval.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewIDLEForApproval.Rows)
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
                            dt.Rows[dt.Rows.Count - 1][7] = double.Parse(row.Cells[7].Value.ToString()).ToString("0.###");

                        }
                        else if (i == 8)
                        {

                            if ((Int32)row.Cells[8].Value == 0)
                            {
                                dt.Rows[dt.Rows.Count - 1][8] = "No Status";
                            }
                            else if ((Int32)row.Cells[8].Value == 1)
                            {
                                dt.Rows[dt.Rows.Count - 1][8] = "Pending";
                            }
                            else if ((Int32)row.Cells[8].Value == 2)
                            {
                                dt.Rows[dt.Rows.Count - 1][8] = "Approved";
                            }
                            else if ((Int32)row.Cells[8].Value == 3)
                            {
                                dt.Rows[dt.Rows.Count - 1][8] = "Disapproved";
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

                //Exporting to Excel           

                try
                {

                    if (!System.IO.File.Exists(fileName))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(fileName))
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {

                                var ws = wb.Worksheets.Add(dt, "CITITO_" + lblMUID.Text + "_IDLE History");
                                ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIDLE approval history records successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + lblMUID.Text + "_IDLE History");
                            ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nIDLE approval history records successfully export to \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string uMID = lblMUID.Text;
            string uPIC = lblPIC.Text;
            DateTime uFrom = DateTime.Parse(dateTimePickerFrom.Value.ToString("MM-dd-yyyy 00:00:00"));
            DateTime uTo = DateTime.Parse(dateTimePickerTo.Value.ToString("MM-dd-yyyy 23:59:59"));

            //Check PIC or Manager and Fill cmbManagersUID.Datasource
            if (new PICHeaderMng(this.conn).PICIsExist(uPIC))
            {
                cmbMUID1.DataSource = new ManagerHeaderMng(this.conn).GetActiveManagerUIDByPIC(uPIC);
                cmbMUID1.SelectedIndex = -1;
                cmbMUID1.Enabled = true;

                //Fill Datagridview
                dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByPIC(uPIC, uFrom, uTo);

            }
            if (!new PICHeaderMng(this.conn).PICIsExist(uPIC) && new ManagerHeaderMng(this.conn).ManagerIsExist(uMID))
            {
                cmbMUID1.Items.Add(uMID);
                cmbMUID1.SelectedIndex = 0;
                cmbMUID1.Enabled = false;

                dataGridViewIDLEForApproval.DataSource = new IDLEDetailMng(this.conn).GetApprovedIDLERecordByManager(uMID, uFrom, uTo);

            }

            headerCheckBox.Checked = false;
        }
    }
}
