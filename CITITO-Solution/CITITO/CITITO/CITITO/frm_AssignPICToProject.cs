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
    public partial class frm_AssignPICToProject : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_AssignPICToProject _instance;
        public static frm_AssignPICToProject GetInstance()
        {


            if (_instance == null || _instance.IsDisposed)
            {


                _instance = new frm_AssignPICToProject();


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_AssignPICToProject()
        {
            InitializeComponent();

            //lblUID.Text = "ZDQ";
            //lblManagerName.Text = "Ajith Perera";

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        private void frm_AssignPICToProject_Load(object sender, EventArgs e)
        {
            RefreshData();

            ClearFields();
        }

        //Refresh Object
        private void RefreshData()
        {
            cmbProjectName.DataSource = new ProjectDetailMng(this.conn).GetListOfProjectNames();
            cmbAssignPIC.DataSource = new PICHeaderMng(this.conn).GetListOfPICs();
            dataGridViewAssignProject.DataSource = new ProjectDetailMng(this.conn).GetAllProjectDetails();

        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();
            //Clear All Fields when Load
            cmbProjectName.SelectedIndex = -1;
            cmbAssignPIC.SelectedIndex = -1;
            txtCurrentPIC.Text = String.Empty;
        }

        private void cmbProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCurrentPIC.Text = new ProjectDetailMng(this.conn).GetPICByProject(cmbProjectName.Text);
            cmbAssignPIC.DataSource = new PICHeaderMng(this.conn).GetPICListExceptSentUID(txtCurrentPIC.Text);
            cmbAssignPIC.SelectedIndex = -1;            
            
        }

        //Refresh button
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }

        //Asign button
        private void btnAssign_Click(object sender, EventArgs e)
        {
            String Project = cmbProjectName.Text.ToUpper();
            String OldPIC = txtCurrentPIC.Text.ToUpper();
            String NewPIC = cmbAssignPIC.Text.ToUpper();

            PICHeader mPICHeader = new PICHeader();

            mPICHeader.PIC_UID = OldPIC;

            PICHeaderMng mPICHeaderMng = new PICHeaderMng(this.conn);

            DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to assign new PIC \"" + NewPIC + "\" to \""+ Project + "\" project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                if (new ProjectDetailMng(this.conn).UpdateProjectPICForProject(Project, OldPIC, NewPIC) > 0)
                {

                    MetroFramework.MetroMessageBox.Show(this, "\nNew PIC " + NewPIC + " has been assigned with PIC \"" + OldPIC + "\"", "PIC Assigned!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshData();
                    ClearFields();

                }
            }
            
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Export Details
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewAssignProject.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewAssignProject.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
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
                                wb.Worksheets.Add(dt, "CITITO_" + lblUID.Text + "_Assigned Details");
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nAssigned details successfully export to \"" + fileName + "\".", "Manager Details Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "CITITO_" + lblUID.Text + "_Assigned Details");
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nAssigned details successfully export to \"" + fileName + "\" path.", "Manager Details Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
