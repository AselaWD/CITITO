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
using MetroFramework;
using MetroFramework.Forms;
namespace CITITO
{
    public partial class frm_Dashboard_RecordsForViewIDLEAndWastage : MetroForm
    {
        SqlConnection conn;
        string mPIC;
        string mUID;

        //Start Pass insatance when form is already opend or not
        private static frm_Dashboard_RecordsForViewIDLEAndWastage _instance;
        public static frm_Dashboard_RecordsForViewIDLEAndWastage GetInstance(string uPIC, DateTime uFrom, DateTime uTo, string uUID)
        {

            if (_instance == null || _instance.IsDisposed)
            {

                String mPIC = uPIC;
                DateTime mFrom = uFrom;
                DateTime mTo = uTo;
                String mUID = uUID;

                _instance = new frm_Dashboard_RecordsForViewIDLEAndWastage(mPIC, mFrom, mTo, mUID);

            }
            return _instance;

        }

        public frm_Dashboard_RecordsForViewIDLEAndWastage(string uPIC, DateTime uFrom, DateTime uTo, string uUID)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

            mPIC = uPIC;
            mUID = uUID;

            //Initialization
            fillTaskIDAndProcessCode.Text = uUID;

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            dataGridViewIDLEAndWasteViewRecords.DataSource = mTaskRecordDetailMng.DboardIDLEAndWastageRecords(uPIC, uFrom, uTo, uUID);

        }

        private void frm_Dashboard_RecordsForViewIDLEAndWastage_Load(object sender, EventArgs e)
        {
            //DataGridvew Alignmnet

            dataGridViewIDLEAndWasteViewRecords.Columns[1].Width = 50;
            dataGridViewIDLEAndWasteViewRecords.Columns[2].Width = 50;

            this.dataGridViewIDLEAndWasteViewRecords.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewIDLEAndWasteViewRecords.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewIDLEAndWasteViewRecords.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewIDLEAndWasteViewRecords.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridViewIDLEAndWasteViewRecords.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewIDLEAndWasteViewRecords.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewIDLEAndWasteViewRecords.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewIDLEAndWasteViewRecords.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        //Export to Excel
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewIDLEAndWasteViewRecords.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewIDLEAndWasteViewRecords.Rows)
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

                //foreach (DataGridViewCell cell in row.Cells)
                //{
                //    try
                //    {
                //        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
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
                                wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_IDLE & Waste for " + mUID);
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_IDLE & Waste for " + mUID);
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

        private void dataGridViewIDLEAndWasteViewRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Round Up
            if (e.ColumnIndex == 7)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.##");
                }
                
            }
            if (e.ColumnIndex == 8)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.##");
                }
            }
            if (e.ColumnIndex == 9)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.##");
                }
            }
            if (e.ColumnIndex == 10)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.##");
                }
            }
        }
    }
}
