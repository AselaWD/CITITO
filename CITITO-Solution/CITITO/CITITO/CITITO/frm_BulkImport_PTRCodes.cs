using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Configuration;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;
using ClosedXML.Excel;

namespace CITITO
{
    public partial class frm_BulkImport_PTRCodes : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_BulkImport_PTRCodes _instance;
        public static frm_BulkImport_PTRCodes GetInstance()
        {

            if (_instance == null || _instance.IsDisposed)
            {

                _instance = new frm_BulkImport_PTRCodes();

            }
            return _instance;

        }

        public frm_BulkImport_PTRCodes()
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_ResourceCostTable"].BringToFront();
            this.Close();
        }

        private void btnImportSheet_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"Desktop\";
            openFileDialog1.Title = "Import New PTR Resource Sheet";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "xls";
            openFileDialog1.Filter = "Excel files (*.xls)|*.xlsx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = false;


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string filePath = openFileDialog1.FileName;
                string extension = Path.GetExtension(filePath);
                string fNameOnly = Path.GetFileNameWithoutExtension(filePath);

                try
                {
                    using (XLWorkbook workBook = new XLWorkbook(filePath))
                    {
                        //Read the first Sheet from Excel file.
                        IXLWorksheet workSheet = workBook.Worksheet(1);

                        //Create a new DataTable.
                        DataTable dt = new DataTable();

                        //Loop through the Worksheet rows.
                        bool firstRow = true;
                        foreach (IXLRow row in workSheet.Rows())
                        {
                            //Use the first row to add columns to DataTable.
                            if (firstRow)
                            {
                                foreach (IXLCell cell in row.Cells())
                                {
                                    dt.Columns.Add(cell.Value.ToString());
                                }
                                firstRow = false;
                            }
                            else
                            {
                                //Add rows to DataTable.
                                dt.Rows.Add();
                                int i = 0;
                                foreach (IXLCell cell in row.Cells())
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                    i++;

                                }

                            }

                            dataGridViewImportPCP.DataSource = dt;
                            //dataGridViewImportUsers.DataBind();
                        }

                    }
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "File is already opened by another user.", "Running Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
        }

        //Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            //DialogBox for confirmation
            DialogResult result;
            result = MetroFramework.MetroMessageBox.Show(this, "Do you want to import Resorce Cost Table at once?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            try
            {
                //Text for temp prompt          
                string coutputStr = String.Empty;
                string coutputStr1 = String.Empty;

                if (dataGridViewImportPCP.DataSource != null)
                {

                    if (result == DialogResult.Yes)
                    {
                        //Loop through check items
                        //bool isAnySelected = checkedListBoxTaskCode.CheckedIndices.Count > 0;

                        //Loop until total Shipment File Count Registerd into the ShipmentDetails Tabele
                        for (int i = 0; i < dataGridViewImportPCP.Rows.Count; i++)
                        {

                            //Create Object From PCPDetail
                            PTR_QA_StdRates mPTR_QA_StdRates = new PTR_QA_StdRates();
                            PTR_QA_StdRatesMng mPTR_QA_StdRatesMng = new PTR_QA_StdRatesMng(this.conn);


                            //Task Code from List    
                            string sResourceID = dataGridViewImportPCP.Rows[i].Cells[0].Value.ToString();
                            string sLocation = dataGridViewImportPCP.Rows[i].Cells[1].Value.ToString();
                            string sDC = dataGridViewImportPCP.Rows[i].Cells[2].Value.ToString();
                            string sDepartmentName = dataGridViewImportPCP.Rows[i].Cells[3].Value.ToString();
                            string sMin = dataGridViewImportPCP.Rows[i].Cells[4].Value.ToString();
                            string sMax = dataGridViewImportPCP.Rows[i].Cells[5].Value.ToString();
                            string sHC = dataGridViewImportPCP.Rows[i].Cells[6].Value.ToString();
                            string sRT01 = dataGridViewImportPCP.Rows[i].Cells[7].Value.ToString();
                            string sOT01 = dataGridViewImportPCP.Rows[i].Cells[8].Value.ToString();
                            string sSP01 = dataGridViewImportPCP.Rows[i].Cells[9].Value.ToString();

                            //Assign User Interface data to User Object
                            mPTR_QA_StdRates.PTR_Resources = sResourceID;
                            mPTR_QA_StdRates.PTR_Location = sLocation;
                            mPTR_QA_StdRates.PTR_DC = sDC;
                            mPTR_QA_StdRates.PTR_DepartmentName = sDepartmentName;
                            mPTR_QA_StdRates.PTR_Min = float.Parse(sMin);
                            mPTR_QA_StdRates.PTR_Max = float.Parse(sMax);
                            mPTR_QA_StdRates.PTR_HC = float.Parse(sHC);
                            mPTR_QA_StdRates.PTR_RT01 = float.Parse(sRT01);
                            mPTR_QA_StdRates.PTR_OT01 = float.Parse(sOT01);
                            mPTR_QA_StdRates.PTR_SP01 = float.Parse(sSP01);


                            if (!String.IsNullOrEmpty(sResourceID))
                            {
                                
                                if (mPTR_QA_StdRatesMng.IsExistPTRResourceRecord(sResourceID))
                                {
                                    mPTR_QA_StdRatesMng.UpdatePTRDetail(mPTR_QA_StdRates);
                                    coutputStr += (sResourceID + " , ").ToString();
                                    continue;

                                }
                                else
                                {                                   
                                    mPTR_QA_StdRatesMng.AddPTRDetail(mPTR_QA_StdRates);
                                    coutputStr1 += (sResourceID + " , ").ToString();
                                    continue;
                                }
                            }
                        }

                        //Check ouput string status
                        if (coutputStr != "" || coutputStr1!="")
                        {

                            string mcoutputStr = "Following existing Resource ID(s) were updated," + coutputStr;
                            string mcoutputStr1 = "Newly Registered Resource ID(s)," + coutputStr1;


                            frm_ExistBulkPTRCodesMessage ExistFrom = new frm_ExistBulkPTRCodesMessage(mcoutputStr, mcoutputStr1);
                            ExistFrom.Show();
                            this.Close();
                        }
                        else
                        {

                            MetroFramework.MetroMessageBox.Show(this, "Bulk PTR Cost Table successfully imported.", "PTR Cost Table imported.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.OpenForms["frm_ResourceCostTable"].BringToFront();
                            this.Close();

                        }

                    }
                    else
                    {
                        //.... Dialog No
                    }

                }
                else
                {

                    MetroFramework.MetroMessageBox.Show(this, "There is no PTR Cost Table to import. \nPlease import provided excel template.", "Empty PTR Cost Table.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnImportSheet.Focus();
                }

            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233086)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\nUnregistered PTR code found. Please check your template again.", "Invalid.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Application.OpenForms["frm_ResourceCostTable"].BringToFront();
                    this.Close();
                    //MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
