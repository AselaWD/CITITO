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
    public partial class frm_SubDashboardPTR : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_SubDashboardPTR _instance;
        public static frm_SubDashboardPTR GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_SubDashboardPTR(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_SubDashboardPTR(string uMUID, string uPIC)
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

        private void frm_SubDashboardPTR_Load(object sender, EventArgs e)
        {
            //ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            DateTime uFrom = startDate;
            DateTime uTo = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);


            //DataGridView
            dataGridViewDteailofPTR.DataSource = mTaskRecordDetailMng.DboradPTRByPIC(uPIC, uFrom, uTo);


            //DataGridvew Alignmnet
            dataGridViewDteailofPTR.Columns[0].Width = 50;
            dataGridViewDteailofPTR.Columns[1].Width = 130;
            dataGridViewDteailofPTR.Columns[9].Width = 155;

            this.dataGridViewDteailofPTR.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridViewDteailofPTR.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //RefreshData();
        }

        private void RefreshData()
        {
            //Common Initialization
            string uPIC = lblPICToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            //Update From Changed
            DateTime uFrom = metroDateTime1From.Value;
            DateTime uTo = metroDateTime1To.Value;

            //DataGridView
            dataGridViewDteailofPTR.DataSource = mTaskRecordDetailMng.DboradPTRByPIC(uPIC, uFrom, uTo);


            //DataGridvew Alignmnet
            dataGridViewDteailofPTR.Columns[0].Width = 50;
            dataGridViewDteailofPTR.Columns[1].Width = 130;
            dataGridViewDteailofPTR.Columns[9].Width = 155;

            this.dataGridViewDteailofPTR.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridViewDteailofPTR.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        //Clear Object
        private void ClearFields()
        {
            dataGridViewDteailofPTR.DataSource = null;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshData();
        }

        private void dataGridViewDteailofPTR_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Round Up
            if (e.ColumnIndex == 10)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.###");
                }


            }
        }

        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Date Time
            string uFrom = metroDateTime1From.Value.ToString("dd/MM/yyyy");
            string uTo = metroDateTime1To.Value.ToString("dd/MM/yyyy");

            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewDteailofPTR.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewDteailofPTR.Rows)
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

                                var ws = wb.Worksheets.Add("CITITO_" + lblPICToFill.Text + "_PTR");
                        
                                // Set the titles
                                ws.Cell(1, 1).Value = "Facility:";
                                ws.Cell(1, 1).Style.Font.Bold = true;
                                ws.Cell(1, 2).Value = "SRI";

                                ws.Cell(2, 1).Value = "Period:";
                                ws.Cell(2, 1).Style.Font.Bold = true;                          
                                ws.Cell(2, 2).Value = uFrom + " - " + uTo;

                                ws.Cell(3, 1).Value = "Location:";
                                ws.Cell(3, 1).Style.Font.Bold = true;
                                ws.Cell(3, 2).Value = "INNODATA(Sri Lanka)";

                                // Let's play with the rows and columns
                                ws.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.FromArgb(10, 180, 200);
                                ws.Cell(2, 1).Style.Fill.BackgroundColor = XLColor.FromArgb(10, 180, 200);
                                ws.Cell(3, 1).Style.Fill.BackgroundColor = XLColor.FromArgb(10, 180, 200);

                                //Border
                                ws.Range("A1:B3").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;


                                // From a DataTable
                                var dataTable = dt;
                                var tableWithData = ws.Cell(6, 1).InsertTable(dataTable.AsEnumerable());

                                ws.Range("G7:G1048576").CellsUsed().SetDataType(XLDataType.DateTime);
                                ws.Range("K7:K1048576").CellsUsed().SetDataType(XLDataType.Number);

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
                            var ws = wb.Worksheets.Add("CITITO_" + lblPICToFill.Text + "_PTR");

                            // Set the titles
                            ws.Cell(1, 1).Value = "Facility:";
                            ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 2).Value = "SRI";

                            ws.Cell(2, 1).Value = "Period:";
                            ws.Cell(2, 1).Style.Font.Bold = true;
                            ws.Cell(2, 2).Value = uFrom + " - " + uTo;

                            ws.Cell(3, 1).Value = "Location:";
                            ws.Cell(3, 1).Style.Font.Bold = true;
                            ws.Cell(3, 2).Value = "INNODATA(Sri Lanka)";

                            // Let's play with the rows and columns
                            ws.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.FromArgb(10, 180, 200);
                            ws.Cell(2, 1).Style.Fill.BackgroundColor = XLColor.FromArgb(10, 180, 200);
                            ws.Cell(3, 1).Style.Fill.BackgroundColor = XLColor.FromArgb(10, 180, 200);

                            //Border
                            ws.Range("A1:B3").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                            // From a DataTable
                            var dataTable = dt;
                            var tableWithData = ws.Cell(6, 1).InsertTable(dataTable.AsEnumerable());

                            ws.Range("G7:G1048576").CellsUsed().SetDataType(XLDataType.DateTime);
                            ws.Range("K7:K1048576").CellsUsed().SetDataType(XLDataType.Number);

                            ws.Columns().AdjustToContents();

                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnClrAll_Click(object sender, EventArgs e)
        {
            ClearFields();

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }
    }
}
