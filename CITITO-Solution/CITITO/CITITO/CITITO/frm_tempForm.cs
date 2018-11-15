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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CITITO
{
    public partial class frm_tempForm : MetroForm
    {
        SqlConnection conn;

        public frm_tempForm()
        {
            InitializeComponent();
            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

        }

        private void frm_tempForm_Load(object sender, EventArgs e)
        {
            //dataGridViewX3PerformanceDataSet.DataSource = new TaskRecordDetailMng(this.conn).DboardCostAppliedPTRByPICTest();
            dataGridView1.DataSource = new TaskRecordDetailMng(this.conn).DboardCostAppliedPTRByPICTest();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //This is the absolute path to the PDF that we will create
            string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Sample.pdf");

            //Create a standard .Net FileStream for the file, setting various flags
            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //Create a new PDF document setting the size to A4
                using (Document doc = new Document(PageSize.A4))
                {
                    //Bind the PDF document to the FileStream using an iTextSharp PdfWriter
                    using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                    {
                        //Open the document for writing
                        doc.Open();

                        //Create a table with two columns
                        PdfPTable t = new PdfPTable(2);

                        //Borders are drawn by the individual cells, not the table itself.
                        //Tell the default cell that we do not want a border drawn
                        t.DefaultCell.Border = 0;

                        //Add four cells. Cells are added starting at the top left of the table working left to right first, then down
                        t.AddCell("R1C1");
                        t.AddCell("R1C2");
                        t.AddCell("R2C1");
                        t.AddCell("R2C2");

                        //Add the table to our document
                        doc.Add(t);

                        //Close our document
                        doc.Close();
                    }
                }
            }

            this.Close();
        }
        
        public bool IsTheSameCellValue2(int column, int row)
        {
            DataGridViewCell cell1 = dataGridView1[column, row];
            DataGridViewCell cell2 = dataGridView1[column, row - 1];

            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            if (cell1.Value.ToString() + cell2.Value.ToString() == cell1.Value.ToString() + cell2.Value.ToString())
            {
                return cell1.Value.ToString() == cell2.Value.ToString();
            }
           else
                return true;


        }
        

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;

            if (IsTheSameCellValue2(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dataGridView1.AdvancedCellBorderStyle.Top;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue2(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //Date Time
            string uFrom = "1 - ";
            string uTo = "2";

            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
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

                                var ws = wb.Worksheets.Add("CITITO_PTR");

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
                            var ws = wb.Worksheets.Add("CITITO_PTR");

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
    }
}
