using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using ClosedXML.Excel;
using ClosedXML;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;
using MetroFramework.Animation;

namespace CITITO
{
    public partial class frm_SubDashboardWorkLoadDataSet : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_SubDashboardWorkLoadDataSet _instance;
        public static frm_SubDashboardWorkLoadDataSet GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;

                _instance = new frm_SubDashboardWorkLoadDataSet(mMUID, mPIC);

            }
            return _instance;

        }
        public frm_SubDashboardWorkLoadDataSet(string uMUID, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

            lblUIDToFill.Text = uMUID;
            lblPICToFill.Text = uPIC;

            //lblPICToFill.Text = "ZDQ"; /*ZDQ, 16V, EC4, AV1, LR3, TL6, 36W, 23S*/

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            DateTime uFrom = startDate;
            DateTime uTo = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

        }

        private void btnBackToWL_Click(object sender, EventArgs e)
        {
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboardWorkLoad_Summary myForm = frm_SubDashboardWorkLoad_Summary.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_MainReportDashboard form1 = (frm_MainReportDashboard)Application.OpenForms["frm_MainReportDashboard"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();
            this.Close();
        }

        private void frm_SubDashboardWorkLoadDataSet_Load(object sender, EventArgs e)
        {
            //Common Initialization
            string uPIC = lblPICToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);
            ProcessCodeHeaderMng mProcessCodeHeaderMng = new ProcessCodeHeaderMng(this.conn);
            TaskDetailMng mTaskDetailMng = new TaskDetailMng(this.conn);

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            DateTime uFrom = startDate;
            DateTime uTo = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            //DataGridView
            dataGridViewWorkloadSummary.DataSource = mTaskRecordDetailMng.DboardWorkLoadDataSetTitlesByPIC(uPIC);


            /* Fresh */
            // Initialize the button column.
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Text = "View Records";
            buttonColumn.AutoSizeMode =
            DataGridViewAutoSizeColumnMode.AllCells;

            // Use the Text property for the button text for all cells rather
            // than using each cell's value as the text for its own button.
            buttonColumn.UseColumnTextForButtonValue = true;

            // Add the button column to the control.
            dataGridViewWorkloadSummary.Columns.Insert(0, buttonColumn);


            //Change remove column to last-child
            DataGridViewColumnCollection columnCollection = dataGridViewWorkloadSummary.Columns;

            DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
            DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

            int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
            firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
            //lastVisibleColumn.DisplayIndex = firstColumn_sIndex;

            //Dropdown
            cmbProject.DataSource = mProjectDetailMng.GetListOfProjectNamesByPIC(uPIC);
            cmbProject.SelectedIndex = -1;

            //RefreshData();
        }

        private void dataGridViewWorkloadSummary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 11)
                {
                
                    if ((string)e.Value == "Fresh")
                    {
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");
                        e.CellStyle.ForeColor = System.Drawing.Color.Black;

                    }
                    else if ((string)e.Value == "Hold")
                    {
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FD7C66");
                        e.CellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                    else if ((string)e.Value == "In-Process")
                    {
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");
                        e.CellStyle.ForeColor = System.Drawing.Color.Black;

                    }
                    else if ((string)e.Value == "Done")
                    {
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9FEB");
                        e.CellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                if(ex.HResult == -2147467262)
                {

                }
            }
            
        }

        //Refresh Object
        private void RefreshData()
        {
            //Common Initialization
            string uPIC = lblPICToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;

            //DataGridView
            dataGridViewWorkloadSummary.DataSource = mTaskRecordDetailMng.DboardWorkLoadDataSetTitlesByPIC(uPIC);

            //Change remove column to last-child
            DataGridViewColumnCollection columnCollection = dataGridViewWorkloadSummary.Columns;

            DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
            DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

            int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
            firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
            //lastVisibleColumn.DisplayIndex = firstColumn_sIndex;

            ////DataGridvew Alignmnet
            //this.dataGridViewWorkloadSummary.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewWorkloadSummary.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            //this.dataGridViewWorkloadSummary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewWorkloadSummary.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        //Clear Object
        private void ClearFields()
        {
            dataGridViewWorkloadSummary.DataSource = null;
        }

        //Filter By project
        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ClearFields();

            ////Common Initialization
            //string uPIC = lblPICToFill.Text;
            //string uProject = cmbProject.Text;

            //TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            ////Update From Changed
            //DateTime uFrom = metroDateTime1From.Value;
            //DateTime uTo = metroDateTime1To.Value;


            //if (!String.IsNullOrEmpty(uProject))
            //{

            //    //DataGridView
            //    dataGridViewWorkloadSummary.DataSource = mTaskRecordDetailMng.DboardWorkLoadDataSetTitlesByPICAndProject(uPIC, uProject);


            //    //Change remove column to last-child
            //    DataGridViewColumnCollection columnCollection = dataGridViewWorkloadSummary.Columns;

            //    DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
            //    DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

            //    int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
            //    firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
            //    //lastVisibleColumn.DisplayIndex = firstColumn_sIndex;

            //    ////DataGridvew Alignmnet
            //    //this.dataGridViewWorkloadSummary.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    //this.dataGridViewWorkloadSummary.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            //    //this.dataGridViewWorkloadSummary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    //this.dataGridViewWorkloadSummary.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //}
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();

            cmbProject.SelectedIndex = -1;
            txtFileName.Text = String.Empty;
            txtShipment.Text = String.Empty;
            cmbStatus.SelectedIndex = -1;

            ////Header Panel
            //DateTime now = DateTime.Now;
            //var startDate = new DateTime(now.Year, now.Month, 1);
            //var endDate = startDate.AddMonths(1).AddDays(-1);

            //metroDateTime1From.Value = startDate;
            //metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }

        //Filter By Shipment
        private void txtShipment_KeyDown(object sender, KeyEventArgs e)
        {
            ////Common Initialization
            //string uPIC = lblPICToFill.Text;
            //string uShipment = txtShipment.Text;

            //TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);


            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (!String.IsNullOrEmpty(uShipment))
            //    {
            //        dataGridViewWorkloadSummary.DataSource = mTaskRecordDetailMng.DboardWorkLoadDataSetTitlesByPICAndShipment(uPIC, uShipment);

            //        ////Change remove column to last-child
            //        //DataGridViewColumnCollection columnCollection = dataGridViewWorkloadSummary.Columns;

            //        //DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
            //        //DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

            //        //int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
            //        //firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
            //        ////lastVisibleColumn.DisplayIndex = firstColumn_sIndex;

            //        //////DataGridvew Alignmnet
            //        ////this.dataGridViewWorkloadSummary.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //        ////this.dataGridViewWorkloadSummary.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            //        ////this.dataGridViewWorkloadSummary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //        ////this.dataGridViewWorkloadSummary.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //    }
            //}
        }

        //Filter By Shipment
        private void txtFileName_KeyDown(object sender, KeyEventArgs e)
        {
            ////Common Initialization
            //string uPIC = lblPICToFill.Text;
            //string uFileName = txtFileName.Text;

            //TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);


            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (!String.IsNullOrEmpty(uFileName))
            //    {
            //        dataGridViewWorkloadSummary.DataSource = mTaskRecordDetailMng.DboardWorkLoadDataSetTitlesByPICAndFileName(uPIC, uFileName);

            //        ////Change remove column to last-child
            //        //DataGridViewColumnCollection columnCollection = dataGridViewWorkloadSummary.Columns;

            //        //DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
            //        //DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

            //        //int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
            //        //firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
            //        ////lastVisibleColumn.DisplayIndex = firstColumn_sIndex;

            //        //////DataGridvew Alignmnet
            //        ////this.dataGridViewWorkloadSummary.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //        ////this.dataGridViewWorkloadSummary.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


            //        ////this.dataGridViewWorkloadSummary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //        ////this.dataGridViewWorkloadSummary.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //    }
            //}
        }

        //Export to Excel
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Common Initialization
            string mPIC = lblPICToFill.Text;

            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewWorkloadSummary.Columns)
            {
               dt.Columns.Add(column.HeaderText);
               //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewWorkloadSummary.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {

                        
                        dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Value.ToString();
                        
                        //dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Value.ToString();


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
                                var ws = wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_Workload DataSet");
                                ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);

                                //Cell Data Type Formatting
                                ws.Range("F2:J1048576").CellsUsed().SetDataType(XLDataType.Number);
                                ws.Range("A2:A1048576").CellsUsed().SetDataType(XLDataType.DateTime);


                                ws.Columns().AdjustToContents();
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_Workload DataSet");
                            ws.Range("A1:A1048576").Delete(XLShiftDeletedCells.ShiftCellsLeft);

                            //Cell Data Type Formatting
                            ws.Range("F2:J1048576").CellsUsed().SetDataType(XLDataType.Number);
                            ws.Range("A2:A1048576").CellsUsed().SetDataType(XLDataType.DateTime);

                            ws.Columns().AdjustToContents();
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to  \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void dataGridViewWorkloadSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewWorkloadSummary.Columns[e.ColumnIndex].Index == 0)
            {
                string uPIC = lblPICToFill.Text;
                string cPCPCode = dataGridViewWorkloadSummary.CurrentRow.Cells[3].Value.ToString();

                frm_Dashboard_RecordsForViewWorkLoadPCP form = frm_Dashboard_RecordsForViewWorkLoadPCP.GetInstance(uPIC, cPCPCode);
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

        private void dataGridViewWorkloadSummary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string uPIC = lblPICToFill.Text;
            string cPCPCode = dataGridViewWorkloadSummary.CurrentRow.Cells[3].Value.ToString();

            frm_Dashboard_RecordsForViewWorkLoadPCP form = frm_Dashboard_RecordsForViewWorkLoadPCP.GetInstance(uPIC, cPCPCode);
            if (!form.Visible)
            {

                form.Show();

            }
            else
            {
                form.BringToFront();
            }

            
        }

        //Clear filter by event Mouse Click
        private void cmbProject_MouseClick(object sender, MouseEventArgs e)
        {
            //txtFileName.Text = String.Empty;
            //txtShipment.Text = String.Empty;
        }

        private void txtShipment_MouseClick(object sender, MouseEventArgs e)
        {
            //txtFileName.Text = String.Empty;
            //cmbProject.SelectedIndex = -1;
        }

        private void txtFileName_MouseClick(object sender, MouseEventArgs e)
        {
            //cmbProject.SelectedIndex = -1;
            //txtShipment.Text = String.Empty;
        }


        //Go button
        private void btnGo_Click(object sender, EventArgs e)
        {
            //Common Initialization
            string uPIC = lblPICToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;

            //DataGridView
            dataGridViewWorkloadSummary.DataSource = mTaskRecordDetailMng.DboardWorkLoadDataSetTitlesByPICAndDate(uPIC,uFrom,uTo);
        }

        //Clear All
        private void btnClrAll_Click(object sender, EventArgs e)
        {
            ClearFields();

            cmbProject.SelectedIndex = -1;
            txtFileName.Text = String.Empty;
            txtShipment.Text = String.Empty;

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
           
            string mPIC;
            string mProject;
            string mShipment;
            string mFileName;
            string mStatus="";
            string mWhere;

            string mFilteQuery;

            mPIC = lblPICToFill.Text;

            if (String.IsNullOrEmpty(cmbProject.Text))
            {
                mProject = "";
            }
            else
            {
                mProject = " AND pd.PCP_Project='" + cmbProject.Text + "'";
            }

            if (String.IsNullOrEmpty(txtShipment.Text))
            {
                mShipment = "";
            }
            else
            {
                mShipment = " AND ph.PCP_Shipment='" + txtShipment.Text + "'";
            }

            if (String.IsNullOrEmpty(txtFileName.Text))
            {
                mFileName = "";
            }
            else
            {
                mFileName = " AND pd.PCP_File='" + txtFileName.Text + "'";
            }

            if (String.IsNullOrEmpty(cmbStatus.Text))
            {
                mStatus = "";
            }
            else
            {
                if (cmbStatus.Text == "Fresh")
                {
                    mStatus = " [STATUS]='Fresh'";
                }
                if (cmbStatus.Text == "In-Process")
                {
                    mStatus = " [STATUS]='In-Process'";
                }
                if (cmbStatus.Text == "Done")
                {
                    mStatus = " [STATUS]='Done'";
                }
                if (cmbStatus.Text == "Hold")
                {
                    mStatus = " [STATUS]='Hold'";
                }

            }

            if (String.IsNullOrEmpty(mStatus))
            {
                mWhere = "";
            }
            else
            {
                mWhere = "WHERE ";
            }


            if (String.IsNullOrEmpty(mProject) && String.IsNullOrEmpty(mShipment) && String.IsNullOrEmpty(mFileName) && String.IsNullOrEmpty(mStatus))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select any field to filter data.", "Filter Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ClearFields();

                mFilteQuery = "SELECT * " +
                    "FROM(" +
                    "SELECT[CREATED DATE], PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS[FRESH TASKS], [IN - PROCESS COUNT] AS[IN - PROCESS TASKS], [DONE COUNT] AS[DONE TASKS], [HOLD COUNT] AS[HOLD TASKS]," +
                    "    CASE WHEN([IN - PROCESS COUNT] >= 1 AND[HOLD COUNT] = 0) THEN('In-Process') ELSE(CASE WHEN([HOLD COUNT] >= 1 AND[IN - PROCESS COUNT] = 0) THEN('Hold') ELSE(CASE WHEN([TASK COUNT] =[DONE COUNT]) THEN('Done') ELSE(CASE WHEN([DONE COUNT] != 0 AND[TASK COUNT] = ([DONE COUNT] +[FRESH COUNT])) THEN('In-Process') ELSE(CASE WHEN([TASK COUNT] =[FRESH COUNT]) THEN('Fresh') END) END) END) END) END AS[STATUS]" +
                    "    FROM(" +
                    "        SELECT MIN(CONVERT(Date, pd.PCP_StartDate)) AS[CREATED DATE], pd.PCP_Project AS[PROJECT], pd.PCP_ID AS[JOB CODE], ph.PCP_Shipment AS[SHIPMENT], pd.PCP_File AS[FILE NAME], COUNT(pd.PCP_Status) AS[TASK COUNT]," +
                    "        (SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 0 AND  pd.PCP_File = cd.PCP_File AND  pd.PCP_ID = cd.PCP_ID) AS[FRESH COUNT]," +
                    "		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 2 AND pd.PCP_File = cd.PCP_File AND pd.PCP_ID = cd.PCP_ID) AS[IN - PROCESS COUNT]," +
                    "		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 3 AND pd.PCP_File = cd.PCP_File AND pd.PCP_ID = cd.PCP_ID) AS[DONE COUNT]," +
                    "		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 1 AND pd.PCP_File = cd.PCP_File AND pd.PCP_ID = cd.PCP_ID) AS[HOLD COUNT]" +
                    "                FROM tbl_PCPDetail pd" +
                    "                INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode = pch.PC_ProcessCode AND pd.PCP_Project = pch.PIC_Project" +
                    "        INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID = ph.PCP_ID" +
                    "        WHERE pch.PIC_UID ='" + mPIC + "'" + mProject + mShipment + mFileName +
                    "        GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File" +
                    "	)WLResource" +
                    ") WLDataSet " +
                    mWhere + mStatus +
                    " ORDER BY[CREATED DATE] DESC";

                //MessageBox.Show(mFilteQuery);
                //Initialize Object
                TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

                //DataGridView
                dataGridViewWorkloadSummary.DataSource = mTaskRecordDetailMng.DboardWorkLoadDataSetFitersByCustomized(mFilteQuery);


                //Change remove column to last - child
                DataGridViewColumnCollection columnCollection = dataGridViewWorkloadSummary.Columns;

                DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
                DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

                int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
                firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
                //lastVisibleColumn.DisplayIndex = firstColumn_sIndex;

                ////DataGridvew Alignmnet
                //this.dataGridViewWorkloadSummary.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewWorkloadSummary.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;


                //this.dataGridViewWorkloadSummary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridViewWorkloadSummary.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            }
        }
    }
}
