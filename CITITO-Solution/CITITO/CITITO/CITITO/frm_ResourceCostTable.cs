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
    public partial class frm_ResourceCostTable : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_ResourceCostTable _instance;
        public static frm_ResourceCostTable GetInstance()
        {


            if (_instance == null || _instance.IsDisposed)
            {


                _instance = new frm_ResourceCostTable();


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_ResourceCostTable()
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

        }

        private void frm_ResourceCostTable_Load(object sender, EventArgs e)
        {
            //Refresh data fields
            RefreshData();

            this.BindGrid();

            dataGridViewResourceCostDetails.Columns[0].Width = 30;

            this.dataGridViewResourceCostDetails.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            this.dataGridViewResourceCostDetails.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewResourceCostDetails.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewResourceCostDetails.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewResourceCostDetails.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewResourceCostDetails.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewResourceCostDetails.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            this.dataGridViewResourceCostDetails.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewResourceCostDetails.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewResourceCostDetails.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewResourceCostDetails.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewResourceCostDetails.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewResourceCostDetails.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewResourceCostDetails.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        CheckBox headerCheckBox = new CheckBox();

        private void BindGrid()
        {
            //Add a CheckBox Column to the DataGridView Header Cell.

            //Find the Location of Header Cell.
            Point headerCellLocation = this.dataGridViewResourceCostDetails.GetCellDisplayRectangle(0, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 10);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dataGridViewResourceCostDetails.Controls.Add(headerCheckBox);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridViewResourceCostDetails.Columns.Insert(0, checkBoxColumn);

            //Assign Click event to the DataGridView Cell.
            dataGridViewResourceCostDetails.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dataGridViewResourceCostDetails.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dataGridViewResourceCostDetails.Rows)
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
            dataGridViewResourceCostDetails.DataSource = new PTR_QA_StdRatesMng(this.conn).GetAllPTRCostDetails();

        }

        private void btnBulkImport_Click(object sender, EventArgs e)
        {
           
            frm_BulkImport_PTRCodes form = frm_BulkImport_PTRCodes.GetInstance();
            if (!form.Visible)
            {

                form.Show();

            }
            else
            {
                form.BringToFront();
            }
        }

        //Refresh button
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridViewResourceCostDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewResourceCostDetails.SelectedRows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                if (isSelected)
                {
                    row.Cells[0].Value = false;

                    //Loop to verify whether all row CheckBoxes are checked or not.
                    bool isChecked = true;
                    foreach (DataGridViewRow row2 in dataGridViewResourceCostDetails.Rows)
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
                    foreach (DataGridViewRow row2 in dataGridViewResourceCostDetails.Rows)
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

        private void dataGridViewResourceCostDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                foreach (DataGridViewRow row in dataGridViewResourceCostDetails.SelectedRows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                    if (isSelected)
                    {
                        row.Cells[0].Value = false;

                        //Loop to verify whether all row CheckBoxes are checked or not.
                        bool isChecked = true;
                        foreach (DataGridViewRow row2 in dataGridViewResourceCostDetails.Rows)
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
                        foreach (DataGridViewRow row2 in dataGridViewResourceCostDetails.Rows)
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

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_ResourceCostTable"].BringToFront();
            this.Close();
        }

        //Export to Excel
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewResourceCostDetails.Columns)
            {

                dt.Columns.Add(column.HeaderText);

            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewResourceCostDetails.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Value.ToString();

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
                                var ws = wb.Worksheets.Add(dt, "CITITO_Admin_PTR Resource Cost");
                                ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);

                                ws.Range("B2:C1048576").CellsUsed().SetDataType(XLDataType.Number);
                                ws.Range("E2:J1048576").CellsUsed().SetDataType(XLDataType.Number);

                                ws.Columns().AdjustToContents();
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPTR Resource Cost table successfully export to \"" + fileName + "\".", "PTR Resource Cost Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, "CITITO_Admin_PTR Resource Cost");
                            ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);

                            ws.Range("B2:C1048576").CellsUsed().SetDataType(XLDataType.Number);
                            ws.Range("E2:J1048576").CellsUsed().SetDataType(XLDataType.Number);

                            ws.Columns().AdjustToContents();
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPTR Resource Cost table successfully saved to \"" + fileName + "\" path.", "PTR Resource Cost Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        //Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewResourceCostDetails.Rows.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is no data to be processed.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Check if there any checkbox checked/unchecked in cloumn 0

            for (int j = 0; j < dataGridViewResourceCostDetails.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewResourceCostDetails[0, j].Value) == false)
                {

                    if ((dataGridViewResourceCostDetails.RowCount - 1) == j)
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

            PTR_QA_StdRates mPTR_QA_StdRates = new PTR_QA_StdRates();
            PTR_QA_StdRatesMng mPTR_QA_StdRatesMng = new PTR_QA_StdRatesMng(this.conn);

            int records = 0;

            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to delete selected record(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                for (int j = 0; j < dataGridViewResourceCostDetails.RowCount; j++)
                {
                    //initialize       
                    string sResourceID = dataGridViewResourceCostDetails[1, j].Value.ToString();


                    if (Convert.ToBoolean(dataGridViewResourceCostDetails[0, j].Value) == true)
                    {
                        if (mPTR_QA_StdRatesMng.IsExistPTRResourceRecord(sResourceID))
                        {
                            mPTR_QA_StdRatesMng.DeletePTRDetailByResourceID(sResourceID);
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
                    //ClearFields();
                }
                else
                {
                    //Show Completed Message
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nSelected record(s) has been deleted.", "Record(s) Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                    //ClearFields();
                }

            }
        }

        //Modify button
        private void btnModifyFileSize_Click(object sender, EventArgs e)
        {
            //Check if there any checkbox checked/unchecked in cloumn 0
            for (int j = 0; j < dataGridViewResourceCostDetails.RowCount; j++)
            {
                if (Convert.ToBoolean(dataGridViewResourceCostDetails[0, j].Value) == false)
                {

                    if ((dataGridViewResourceCostDetails.RowCount - 1) == j)
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
            List<DataGridViewRow> selectedRows = (from row in dataGridViewResourceCostDetails.Rows.Cast<DataGridViewRow>()
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
            for (int j = 0; j < dataGridViewResourceCostDetails.RowCount; j++)
            {


                if (Convert.ToBoolean(dataGridViewResourceCostDetails[0, j].Value) == true)
                {
                    //Initialize PCP User Detail                
                    string sResourceID = dataGridViewResourceCostDetails[1, j].Value.ToString();

   
                    frm_ModifyFileSize form = frm_ModifyFileSize.GetInstance(sResourceID);

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
    }
}
