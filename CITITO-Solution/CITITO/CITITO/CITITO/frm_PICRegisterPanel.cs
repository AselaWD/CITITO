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
using CITITO.BusinessControls;
using CITITO.BusinessServices;
using System.Data.SqlClient;
using System.Security.Cryptography;
using MetroFramework.Forms;

namespace CITITO
{
    public partial class frm_PICRegisterPanel : MetroForm
    {
        
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_PICRegisterPanel _instance;
        public static frm_PICRegisterPanel GetInstance()
        {


            if (_instance == null || _instance.IsDisposed)
            {


                _instance = new frm_PICRegisterPanel();


            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_PICRegisterPanel()
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
            
        }
        private void frm_PICRegisterPanel_Load(object sender, EventArgs e)
        {
            Activate();

            //Refresh data fields
            RefreshData();

            //Clear All Fields when Load
            ClearFields();
        }

        private void btnAddManager_Click(object sender, EventArgs e)
        {
            //Validate Fields is null or empty
            if (String.IsNullOrEmpty(txtUID.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nUser ID field cannot be empty..!", "User ID Name Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtManagerName.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nManager Name field cannot be empty..!", "Manager Name Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtManagerName.Focus();
                return;
            }
            if (lblPasswordMessage.Text != "Matched!")
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPasswords cannot be mismatched..!", "Mismatched Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            if (lblPasswordMessage.Text != "Matched!")
            {
                MetroFramework.MetroMessageBox.Show(this, "\nPasswords cannot be mismatched..!", "Mismatched Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            //DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to add new manager?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (resulta == DialogResult.Yes)
            //{
                if (new PICHeaderMng(conn).PICIsExist(txtUID.Text.ToUpper()))
                {

                    MetroFramework.MetroMessageBox.Show(this, "\nUser ID " + txtUID.Text.ToUpper() + " already exists!", "Manager Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUID.Focus();
                    return;
                }
                else
                {

                    //Create Object From Userdepartmets
                    PICHeader mPICHeader = new PICHeader();
                    PICDetail mPICDetail = new PICDetail();

                    using (MD5 md5Hash = MD5.Create())
                    {
                        // Assign PIC Header
                        mPICHeader.PIC_UID = txtUID.Text.ToUpper();
                        mPICHeader.PIC_AccessLevel = "Project In Charge";

                        // Assign PIC Detail
                        mPICDetail.PIC_UID = txtUID.Text.ToUpper();
                        mPICDetail.PIC_Name = txtManagerName.Text;
                        txtPassword.Text = ControlsHash.GetMd5Hash(md5Hash, txtPassword.Text);
                        mPICDetail.PIC_Password = txtPassword.Text;
                        
                    }
                    PICHeaderMng mPICHeaderMng = new PICHeaderMng(conn);
                    PICDetailMng mPICDetailMng = new PICDetailMng(conn);


                    if (mPICHeaderMng.AddPICHeader(mPICHeader) > 0)
                    {
                        mPICDetailMng.AddPICDetail(mPICDetail);

                        MetroFramework.MetroMessageBox.Show(this, "\nNew manager " + mPICDetail.PIC_UID + " has been registered..!", "New Manager Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshData();
                        ClearFields();
                    }
                    
                }

            //}
        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();

            //Clear All Fields when Load
            txtUID.Text = String.Empty;
            txtManagerName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtRePassword.Text = String.Empty;

            lblPasswordMessage.Visible = false;
            pBoxCorrect.Visible = false;
            pBoxError.Visible = false;

        }

        //Refresh Object
        private void RefreshData()
        {
            dataGridViewImmediateManagerRegister.DataSource = new PICDetailMng(this.conn).GetAllPICDetails();

        }

        //Refresh button
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }
        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                pBoxCorrect.Visible = false;
                pBoxError.Visible = true;
                lblPasswordMessage.Visible = true;
                lblPasswordMessage.Text = "Password cannot be empty!";
                lblPasswordMessage.ForeColor = Color.Red;
            }
            else
            {
                if (txtPassword.Text.Length.Equals(txtRePassword.Text.Length))
                {
                    if (txtPassword.Text == txtRePassword.Text)
                    {
                        pBoxCorrect.Visible = true;
                        pBoxError.Visible = false;
                        lblPasswordMessage.Visible = true;
                        lblPasswordMessage.Text = "Matched!";
                        lblPasswordMessage.ForeColor = Color.Green;
                    }
                    else
                    {
                        pBoxCorrect.Visible = false;
                        pBoxError.Visible = true;
                        lblPasswordMessage.Visible = true;
                        lblPasswordMessage.Text = "Mismatched!";
                        lblPasswordMessage.ForeColor = Color.Red;
                    }
                }

                else if (txtPassword.Text.Length < txtRePassword.Text.Length)
                {
                    pBoxCorrect.Visible = false;
                    pBoxError.Visible = true;
                    lblPasswordMessage.Visible = true;
                    lblPasswordMessage.Text = "Mismatched!";
                    lblPasswordMessage.ForeColor = Color.Red;
                }
                else
                {
                    lblPasswordMessage.Visible = false;
                    pBoxCorrect.Visible = false;
                    pBoxError.Visible = false;
                }
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length <= 7)
            {
                pBoxCorrect.Visible = false;
                pBoxError.Visible = true;
                lblPasswordMessage.Visible = true;
                lblPasswordMessage.Text = "Length should be at least 8 Characters!";
                lblPasswordMessage.ForeColor = Color.Red;
            }
            else
            {
                lblPasswordMessage.Visible = false;
                pBoxCorrect.Visible = false;
                pBoxError.Visible = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewImmediateManagerRegister_Click(object sender, EventArgs e)
        {
            txtUID.Text = dataGridViewImmediateManagerRegister.SelectedRows[0].Cells[0].Value.ToString();
        }

        //Modifybutton
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Validate Fields is null or empty
            if (String.IsNullOrEmpty(txtUID.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nUser ID field cannot be empty..!", "User ID Not Enterd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }

            if (!new PICHeaderMng(conn).PICIsExist(txtUID.Text.ToUpper()))
            {

                MetroFramework.MetroMessageBox.Show(this, "\nUser ID " + txtUID.Text.ToUpper() + " is not found!", "User ID Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                return;
            }
            else
            {
                frm_PICModify frmMofidy = new frm_PICModify(txtUID.Text);
                frmMofidy.Show();
            }
        }

        //Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUID.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "\nUser ID field cannot be empty..!", "User ID Not Selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUID.Focus();
                txtUID.BackColor = Color.OrangeRed;
                return;
            }
            else
            {
                DialogResult resulta = MetroFramework.MetroMessageBox.Show(this, "\nDo you want to delete User ID " + txtUID.Text.ToUpper() + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {

                    if (!new PICHeaderMng(conn).PICIsExist(txtUID.Text.ToUpper()))
                    {

                        MetroFramework.MetroMessageBox.Show(this, "\nManager UID " + txtUID.Text.ToUpper() + " is not found!", "User ID Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUID.Focus();
                        return;
                    }
                    else
                    {
                        PICHeader mPICHeader = new PICHeader();
                        PICDetail mPICDetail = new PICDetail();

                        mPICHeader.PIC_UID = txtUID.Text.ToUpper();
                        mPICDetail.PIC_UID = txtUID.Text.ToUpper();


                        PICHeaderMng mPICHeaderMng = new PICHeaderMng(this.conn);
                        PICDetailMng mPICDetailMng = new PICDetailMng(this.conn);

                        DataTable uPICDetail = mPICDetailMng.GetAllPICDetailsByUIDForTemp(txtUID.Text.ToUpper());

                        String uPICNameTemp = uPICDetail.Rows[0][0].ToString();
                        String uPassTemp = uPICDetail.Rows[0][1].ToString();


                        try
                        {

                            if (mPICDetailMng.DeletePICDetail(mPICDetail) > 0)
                            {
                                //Delete PIC
                                mPICHeaderMng.DeletePICHeader(mPICHeader);

                                MetroFramework.MetroMessageBox.Show(this, "\nUser ID " + mPICDetail.PIC_UID + " has been deleted.", "Manager Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshData();
                                ClearFields();
                            }
                        }
                        catch (Exception ex)
                        {

                            if (ex.HResult== -2146232060)
                            {

                                frm_AssignPIC frmMofidy = new frm_AssignPIC(txtUID.Text, uPICNameTemp, uPassTemp);
                                frmMofidy.Show();
                            }
                        }
                        

                    }
                }
            }
        }


        //UID filter
        private void txtUID_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUID.Text))
            {
                dataGridViewImmediateManagerRegister.DataSource = new PICDetailMng(this.conn).GetAllPICDetailsBYUID(txtUID.Text);
            }
            else
            {
                RefreshData();
            }
        }

        private void frm_PICRegisterPanel_Activated(object sender, EventArgs e)
        {
            RefreshData();
        }

        //Export Excel
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {


            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewImmediateManagerRegister.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewImmediateManagerRegister.Rows)
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
                                wb.Worksheets.Add(dt, "CITITO_Admin_PIC Details");
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPIC details successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "CITITO_Admin_PIC Details");
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPIC details successfully saved to \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
