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
    public partial class frm_Dashboard_RecordsForViewTask : MetroForm
    {
        SqlConnection conn;
        string mPIC;

        //Start Pass insatance when form is already opend or not
        private static frm_Dashboard_RecordsForViewTask _instance;
        public static frm_Dashboard_RecordsForViewTask GetInstance(string uPIC, DateTime uFrom, DateTime uTo, string uProject, string uProcessCode, string uTaskCode, string uTaskDesc)
        {

            if (_instance == null || _instance.IsDisposed)
            {

                String mPIC = uPIC;
                DateTime mFrom = uFrom;
                DateTime mTo = uTo;
                String mProject = uProject;
                String mProcessCode = uProcessCode;
                String mTaskCode = uTaskCode;
                String mTaskDesc = uTaskDesc;

                _instance = new frm_Dashboard_RecordsForViewTask(mPIC, mFrom, mTo, mProject, mProcessCode, mTaskCode, mTaskDesc);

            }
            return _instance;

        }

        public frm_Dashboard_RecordsForViewTask(string uPIC, DateTime uFrom, DateTime uTo, string uProject, string uProcessCode, string uTaskCode, string uTaskDesc)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);

            conn.Open();

            mPIC = uPIC;

            //Initialization
            fillTaskIDAndProcessCode.Text = uTaskCode + "(" + uProcessCode + ")";

            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            dataGridViewTaskAndQuotaRecords.DataSource = mTaskRecordDetailMng.DboardPICTaskAndQuotaRecords(uPIC, uFrom, uTo, uProject, uProcessCode, uTaskCode, uTaskDesc);

            //MessageBox.Show(uPIC+ " / " + uFrom.ToString() +" / " + uTo.ToString() + " / " + uProject + " / " + uProcessCode + " / " + uTaskCode + " / " + uTaskDesc);

        }

        private void frm_Dashboard_RecordsForViewTask_Load(object sender, EventArgs e)
        {
            //DataGridvew Alignmnet
            this.dataGridViewTaskAndQuotaRecords.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridViewTaskAndQuotaRecords.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();

        }

        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewTaskAndQuotaRecords.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewTaskAndQuotaRecords.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {
                        if (i == 8)
                        {
                            dt.Rows[dt.Rows.Count - 1][8] = double.Parse(row.Cells[8].Value.ToString()).ToString("0.###") + "%";
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
                                wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_Task & Quota Records");
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "CITITO_" + mPIC + "_Task & Quota Records");
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

        private void dataGridViewTaskAndQuotaRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("0.##");
            }
        }
    }
}
