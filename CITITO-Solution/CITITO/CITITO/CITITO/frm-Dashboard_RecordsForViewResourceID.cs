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
    public partial class frm_Dashboard_RecordsForViewResourceID : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_Dashboard_RecordsForViewResourceID _instance;
        public static frm_Dashboard_RecordsForViewResourceID GetInstance()
        {

            if (_instance == null || _instance.IsDisposed)
            {


                _instance = new frm_Dashboard_RecordsForViewResourceID();

            }
            return _instance;

        }

        public frm_Dashboard_RecordsForViewResourceID()
        {            
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            PTR_QA_StdRatesMng mPTR_QA_StdRatesMng = new PTR_QA_StdRatesMng(this.conn);

            dataGridViewHoldRecords.DataSource = mPTR_QA_StdRatesMng.GetAllPTRCostDetails();

            lblCopied.Visible = false;
        }

        //Exit botton
        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        //Export Excel
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
                                var ws = wb.Worksheets.Add(dt, "CITITO_Resource ID Details");

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
                            var ws = wb.Worksheets.Add(dt, "CITITO_Resource ID Details");

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

        private void dataGridViewHoldRecords_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cResourceID = dataGridViewHoldRecords.SelectedCells[0].Value.ToString();
            if (!String.IsNullOrEmpty(cResourceID))
            {
                Clipboard.SetText(cResourceID);
                lblCopied.Text = cResourceID + " Copied";
                lblCopied.Visible = true;
            }
            
        }

        private void dataGridViewHoldRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCopied.Visible = false;
        }

        private void frm_Dashboard_RecordsForViewResourceID_Load(object sender, EventArgs e)
        {

        }
    }
}
