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
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;
using MetroFramework.Animation;

namespace CITITO
{
    public partial class frm_Dashboard_RecordsForViewWorkLoadPCP : MetroForm
    {
        SqlConnection conn;
        string mPIC;

        //Start Pass insatance when form is already opend or not
        private static frm_Dashboard_RecordsForViewWorkLoadPCP _instance;
        public static frm_Dashboard_RecordsForViewWorkLoadPCP GetInstance(string uPIC, string uPCPCode)
        {

            if (_instance == null || _instance.IsDisposed)
            {

                String mPIC = uPIC;
                String mPCPCode = uPCPCode;

                _instance = new frm_Dashboard_RecordsForViewWorkLoadPCP(mPIC, mPCPCode);

            }
            return _instance;

        }

        public frm_Dashboard_RecordsForViewWorkLoadPCP(string uPIC, string uPCPCode)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

            mPIC = uPIC;

            //Initialization
            fillTPCPCode.Text = uPCPCode;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            dataGridViewHoldRecords.DataSource = mTaskRecordDetailMng.DboardWorkLoadDataSetTitlesByPICAndPCPCode(uPIC, uPCPCode);
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        //Export excel
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewHoldRecords.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewHoldRecords.Rows)
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

                //Exporting to Excel           

                try
                {

                    if (!System.IO.File.Exists(fileName))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(fileName))
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                var ws = wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_Title Details");

                                ws.Range("E2:E1048576").CellsUsed().SetDataType(XLDataType.Number);
                                ws.Range("G2:G1048576").CellsUsed().SetDataType(XLDataType.Number);

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
                            var ws = wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_Title Details");

                            ws.Range("E2:E1048576").CellsUsed().SetDataType(XLDataType.Number);
                            ws.Range("G2:G1048576").CellsUsed().SetDataType(XLDataType.Number);

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

        private void dataGridViewHoldRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10)
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
    }
}
