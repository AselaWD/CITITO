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
using System.Security.Cryptography;
using MetroFramework.Forms;
using ClosedXML.Excel;

namespace CITITO
{
    public partial class frm_BulkImport_UserRegistration : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_BulkImport_UserRegistration _instance;
        public static frm_BulkImport_UserRegistration GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_BulkImport_UserRegistration(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_BulkImport_UserRegistration(string uMUID, string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            if (uMUID==uPIC)
            {
                lblMUID.Text = "-EMPTY-";
                lblPIC.Text = uPIC;
            }
            else
            {
                lblMUID.Text = uMUID;
                lblPIC.Text = uPIC;
            }
            

        }

        private void btnImportSheet_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"Desktop\";
            openFileDialog1.Title = "Import New User Registration Sheet";

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

                //Save the uploaded Excel file.
                //string filePath = filePath;
                //filePath.SaveAs(filePath);

                //Open the Excel file using ClosedXML.

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
                                    

                                    if (i == 5)
                                    {

                                       dt.Rows[dt.Rows.Count - 1][5] = (DateTime.FromOADate(Double.Parse(cell.Value.ToString()))).ToString("hh:mm tt");
                                    }
                                    else if (i == 6)
                                    {
                                        dt.Rows[dt.Rows.Count - 1][6] = (DateTime.FromOADate(Double.Parse(cell.Value.ToString()))).ToString("hh:mm tt");
                                    }
                                    else
                                    {
                                        dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                    }

                                    i++;

                                }
                                
                            }
                            
                            dataGridViewImportUsers.DataSource = dt;
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

        //Save Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewImportUsers.Rows.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "\nThere is no data to import! \nPlease import provided excel template.", "Empty Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnImportSheet.Focus();

            }

            //DialogBox for confirmation
            DialogResult result;
            result = MetroFramework.MetroMessageBox.Show(this, "Do you want to register users at once?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //For PIC
            if (lblMUID.Text == "-EMPTY-")
            {
                try
                {
                    //Text for temp prompt            
                    string outputStrUName = String.Empty;
                    string coutputStrProject = String.Empty;
                    string outputStrManager = String.Empty;
                    string outputStrAccess = String.Empty;
                    string outputStrResource = String.Empty;

                    if (dataGridViewImportUsers.DataSource != null)
                    {

                        if (result == DialogResult.Yes)
                        {
                            //Loop through check items
                            //bool isAnySelected = checkedListBoxTaskCode.CheckedIndices.Count > 0;

                            //DateTime
                            DateTime localDate = DateTime.Now;


                            //Loop until total Shipment File Count Registerd into the ShipmentDetails Tabele
                            for (int i = 0; i < dataGridViewImportUsers.Rows.Count; i++)
                            {
                                //Create Object From User
                                UserManagementHeader mUserManagementHeader = new UserManagementHeader();
                                UserManagementDetail mUserManagementDetail = new UserManagementDetail();

                                UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(conn);
                                UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(conn);


                                //User details from List  
                                string sUID = dataGridViewImportUsers.Rows[i].Cells[0].Value.ToString();
                                string sUName = dataGridViewImportUsers.Rows[i].Cells[1].Value.ToString();
                                /*Password will craete each transaction*/
                                string sSystemAccess = dataGridViewImportUsers.Rows[i].Cells[3].Value.ToString(); /*Common User, Project In Charge, Immediate Reporter, DCD*/
                                string sImmediateReporter = dataGridViewImportUsers.Rows[i].Cells[4].Value.ToString();

                                string sShiftIn = DateTime.Parse(dataGridViewImportUsers.Rows[i].Cells[5].Value.ToString()).ToString("hh:mm tt");

                                string sShiftOut = DateTime.Parse(dataGridViewImportUsers.Rows[i].Cells[6].Value.ToString()).ToString("hh:mm tt");

                                string sResID = dataGridViewImportUsers.Rows[i].Cells[7].Value.ToString();

                                string sPIC = lblPIC.Text;

                                //MessageBox.Show(sSystemAccess);

                                if (!String.IsNullOrEmpty(sUID))
                                {
                                    

                                    //UID Already Registered
                                    if (new UserManagementHeaderMng(conn).UserIsExist(sUID))
                                    {
                                        outputStrUName += (sUID + " , ").ToString();
                                        continue;
                                    }
                                    //Manager Already Registered
                                    if (!new ManagerHeaderMng(conn).ManagerIsExistUnderPIC(sPIC, sImmediateReporter))
                                    {
                                        outputStrManager += (sImmediateReporter + " [" + sUID + "]" + " , ").ToString();
                                        continue;
                                    }
                                    
                                    //Invald Access level given
                                    if (sSystemAccess != "Common User" && sSystemAccess != "DCD")
                                    {
                                        outputStrAccess += (sSystemAccess + " [" + sUID + "]" + " , ").ToString();
                                        continue;
                                    }

                                    //validate entred resource Code
                                    PTR_QA_StdRatesMng mPTR_QA_StdRatesMng = new PTR_QA_StdRatesMng(this.conn);
                                    if (!mPTR_QA_StdRatesMng.IsExistPTRResourceRecord(sResID))
                                    {
                                        outputStrResource += (sResID + " [" + sUID + "]" + " , ").ToString();
                                        continue;
                                    }

                                    //If User Inactive
                                    if (new UserManagementHeaderMng(conn).UserIsExistWithInactive(sUID))
                                    {
                                        using (MD5 md5Hash = MD5.Create())
                                        {
                                            string dUPassword = ControlsHash.GetMd5Hash(md5Hash, dataGridViewImportUsers.Rows[i].Cells[2].Value.ToString());

                                            // Assign User Header
                                            mUserManagementHeader.P_UID = sUID;
                                            mUserManagementHeader.P_Name = sUName;
                                            mUserManagementHeader.P_Password = dUPassword;
                                            mUserManagementHeader.P_AccessLevel = sSystemAccess;
                                            mUserManagementHeader.P_Availability = 1;
                                            mUserManagementHeader.P_Activate_Date = DateTime.Now;
                                            mUserManagementHeader.P_Shift = sShiftIn+ " to " + sShiftOut;
                                            mUserManagementHeader.PTR_Resources = sResID;
                                        }

                                        if (mUserManagementHeaderMng.UpdateUserNameWithAllDetails(mUserManagementHeader) > 0)
                                        {
                                            //Assign User Interface data to User Object
                                            // Assign User Detail
                                            mUserManagementDetail.P_UID = sUID;
                                            mUserManagementDetail.P_Project_Availability = "Active";
                                            mUserManagementDetail.P_Activate_Date = DateTime.Now;
                                            mUserManagementDetail.M_UID = sImmediateReporter;
                                            mUserManagementDetail.PIC_UID = sPIC;

                                            for (int j = 8; j < dataGridViewImportUsers.Columns.Count; j++)
                                            {
                                                if (!String.IsNullOrEmpty(dataGridViewImportUsers.Rows[i].Cells[j].Value.ToString()))
                                                {

                                                    string sProjectName = dataGridViewImportUsers.Rows[i].Cells[j].Value.ToString();

                                                    //Is Exist Pproject
                                                    if (new ManagerDetailMng(this.conn).GetActiveProjectIsExistByManager(sImmediateReporter, sPIC, sProjectName) == false)
                                                    {
                                                        coutputStrProject += (sProjectName + " [" + sUID + "]" + " , ").ToString();
                                                        continue;

                                                    }

                                                    mUserManagementDetail.P_Project = sProjectName;

                                                    if (mUserManagementDetailMng.AddUserManagementDetail(mUserManagementDetail) > 0)
                                                    {

                                                    }
                                                }
                                            }

                                        }

                                    }

                                    else
                                    {

                                        using (MD5 md5Hash = MD5.Create())
                                        {
                                            string dUPassword = ControlsHash.GetMd5Hash(md5Hash, dataGridViewImportUsers.Rows[i].Cells[2].Value.ToString());

                                            // Assign User Header
                                            mUserManagementHeader.P_UID = sUID;
                                            mUserManagementHeader.P_Name = sUName;
                                            mUserManagementHeader.P_Password = dUPassword;
                                            mUserManagementHeader.P_AccessLevel = sSystemAccess;
                                            mUserManagementHeader.P_Availability = 1;
                                            mUserManagementHeader.P_Activate_Date = DateTime.Now;
                                            mUserManagementHeader.P_Shift = sShiftIn + " to " + sShiftOut;
                                            mUserManagementHeader.PTR_Resources = sResID;

                                        }

                                        if (mUserManagementHeaderMng.AddUserManagementHeader(mUserManagementHeader) > 0)
                                        {

                                            //Assign User Interface data to User Object
                                            // Assign User Detail
                                            mUserManagementDetail.P_UID = sUID;
                                            mUserManagementDetail.P_Project_Availability = "Active";
                                            mUserManagementDetail.P_Activate_Date = DateTime.Now;
                                            mUserManagementDetail.M_UID = sImmediateReporter;
                                            mUserManagementDetail.PIC_UID = sPIC;


                                            for (int j = 8; j < dataGridViewImportUsers.Columns.Count; j++)
                                            {
                                                if (!String.IsNullOrEmpty(dataGridViewImportUsers.Rows[i].Cells[j].Value.ToString()))
                                                {

                                                    string sProjectName = dataGridViewImportUsers.Rows[i].Cells[j].Value.ToString();

                                                    //Is Exist Pproject
                                                    if (new ManagerDetailMng(this.conn).GetActiveProjectIsExistByManager(sImmediateReporter, sPIC, sProjectName) == false)
                                                    {
                                                        coutputStrProject += (sProjectName + " [" + sUID + "]" + " , ").ToString();
                                                        continue;

                                                    }

                                                    mUserManagementDetail.P_Project = sProjectName;

                                                    if (mUserManagementDetailMng.AddUserManagementDetail(mUserManagementDetail) > 0)
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }


                            //Check ouput string status
                            if (outputStrUName != "" || coutputStrProject != "" || outputStrManager != "" || outputStrAccess != "" || outputStrResource != "")
                            {

                                //MessageBox.Show("Precess Complete! \nSome Item Codes are already exist in the Project Quota.\n\n" + outputStr, "Project Quota Registerd", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                string moutput = "Registered User Name(s) Found..!," + outputStrUName;
                                string mcoutputStr = "Invalid Project(s) Found..!," + coutputStrProject;
                                string mcoutputMStr = "Manager(s) Not Found..!," + outputStrManager;
                                string mcoutputAccessStr = "Invalid Access Level Found..!," + outputStrAccess;
                                string mcoutputResourceStr = "Invalid Resource ID(s) Found..!," + outputStrResource;

                                frm_ExistBulkUserRegisterMessage ExistFrom = new frm_ExistBulkUserRegisterMessage(moutput, mcoutputStr, mcoutputMStr, mcoutputAccessStr, mcoutputResourceStr);
                                ExistFrom.Show();
                                this.Close();
                            }
                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "User bulk successfully registered..!", "User Registered!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        MetroFramework.MetroMessageBox.Show(this, "\nThere is no data to import! \nPlease import provided excel template.", "Empty Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnImportSheet.Focus();
                    }

                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233086)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "\nUnregistered project name found. Please check your template again.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Message: " + ex.HResult, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            //For Managers
            else
            {
                try
                {
                    //Text for temp prompt            
                    string outputStrUName = String.Empty;
                    string coutputStrProject = String.Empty;
                    string outputStrManager = String.Empty;
                    string outputStrAccess = String.Empty;
                    string outputStrResource = String.Empty;

                    if (dataGridViewImportUsers.DataSource != null)
                    {

                        if (result == DialogResult.Yes)
                        {
                            //Loop through check items
                            //bool isAnySelected = checkedListBoxTaskCode.CheckedIndices.Count > 0;

                            //DateTime
                            DateTime localDate = DateTime.Now;


                            //Loop until total Shipment File Count Registerd into the ShipmentDetails Tabele
                            for (int i = 0; i < dataGridViewImportUsers.Rows.Count; i++)
                            {
                                //Create Object From User
                                UserManagementHeader mUserManagementHeader = new UserManagementHeader();
                                UserManagementDetail mUserManagementDetail = new UserManagementDetail();

                                UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(conn);
                                UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(conn);


                                //User details from List  
                                string sUID = dataGridViewImportUsers.Rows[i].Cells[0].Value.ToString();
                                string sUName = dataGridViewImportUsers.Rows[i].Cells[1].Value.ToString();
                                /*Password will craete each transaction*/
                                string sSystemAccess = dataGridViewImportUsers.Rows[i].Cells[3].Value.ToString(); /*Common User, Project In Charge, Immediate Reporter, DCD*/
                                string sImmediateReporter = lblMUID.Text;
                                string sPIC = lblPIC.Text;

                                string sShiftIn = DateTime.Parse(dataGridViewImportUsers.Rows[i].Cells[5].Value.ToString()).ToString("hh:mm tt");

                                string sShiftOut = DateTime.Parse(dataGridViewImportUsers.Rows[i].Cells[6].Value.ToString()).ToString("hh:mm tt");

                                string sResID= dataGridViewImportUsers.Rows[i].Cells[7].Value.ToString();

                                //UID Already Registered
                                if (new UserManagementHeaderMng(conn).UserIsExist(sUID))
                                {
                                    outputStrUName += (sUID + " , ").ToString();
                                    continue;
                                }
                                //Manager Already Registered
                                if (!new ManagerHeaderMng(conn).ManagerIsExistUnderPIC(sPIC, sImmediateReporter))
                                {
                                    outputStrManager += (sImmediateReporter + " [" + sUID + "]" + " , ").ToString();
                                    continue;
                                }
                                //Invald Access level given
                                if (sSystemAccess!= "Common User" && sSystemAccess!="DCD")
                                {
                                    outputStrAccess += (sSystemAccess + " [" + sUID + "]" + " , ").ToString();
                                    continue;
                                }
                                //validate entred resource Code
                                PTR_QA_StdRatesMng mPTR_QA_StdRatesMng = new PTR_QA_StdRatesMng(this.conn);
                                if (!mPTR_QA_StdRatesMng.IsExistPTRResourceRecord(sResID))
                                {
                                    outputStrResource += (sResID + " [" + sUID + "]" + " , ").ToString();
                                    continue;
                                }


                                //If User Inactive
                                if (new UserManagementHeaderMng(conn).UserIsExistWithInactive(sUID))
                                {
                                    using (MD5 md5Hash = MD5.Create())
                                    {
                                        string dUPassword = ControlsHash.GetMd5Hash(md5Hash, dataGridViewImportUsers.Rows[i].Cells[2].Value.ToString());

                                        // Assign User Header
                                        mUserManagementHeader.P_UID = sUID;
                                        mUserManagementHeader.P_Name = sUName;
                                        mUserManagementHeader.P_Password = dUPassword;
                                        mUserManagementHeader.P_AccessLevel = sSystemAccess;
                                        mUserManagementHeader.P_Availability = 1;
                                        mUserManagementHeader.P_Activate_Date = DateTime.Now;
                                        mUserManagementHeader.P_Shift = sShiftIn + " to " + sShiftOut;
                                        mUserManagementHeader.PTR_Resources = sResID;
                                    }

                                    if (mUserManagementHeaderMng.UpdateUserNameWithAllDetails(mUserManagementHeader) > 0)
                                    {
                                        //Assign User Interface data to User Object
                                        // Assign User Detail
                                        mUserManagementDetail.P_UID = sUID;
                                        mUserManagementDetail.P_Project_Availability = "Active";
                                        mUserManagementDetail.P_Activate_Date = DateTime.Now;
                                        mUserManagementDetail.M_UID = sImmediateReporter;
                                        mUserManagementDetail.PIC_UID = sPIC;

                                        for (int j = 8; j < dataGridViewImportUsers.Columns.Count; j++)
                                        {
                                            if (!String.IsNullOrEmpty(dataGridViewImportUsers.Rows[i].Cells[j].Value.ToString()))
                                            {

                                                string sProjectName = dataGridViewImportUsers.Rows[i].Cells[j].Value.ToString();

                                                //Is Exist Pproject
                                                if (new ManagerDetailMng(this.conn).GetActiveProjectIsExistByManager(sImmediateReporter, sPIC, sProjectName) == false)
                                                {
                                                    coutputStrProject += (sProjectName + " [" + sUID + "]" + " , ").ToString();
                                                    continue;

                                                }

                                                mUserManagementDetail.P_Project = sProjectName;

                                                if (mUserManagementDetailMng.AddUserManagementDetail(mUserManagementDetail) > 0)
                                                {

                                                }
                                            }
                                        }

                                    }

                                }

                                else
                                {

                                    using (MD5 md5Hash = MD5.Create())
                                    {
                                        string dUPassword = ControlsHash.GetMd5Hash(md5Hash, dataGridViewImportUsers.Rows[i].Cells[2].Value.ToString());

                                        // Assign User Header
                                        mUserManagementHeader.P_UID = sUID;
                                        mUserManagementHeader.P_Name = sUName;
                                        mUserManagementHeader.P_Password = dUPassword;
                                        mUserManagementHeader.P_AccessLevel = sSystemAccess;
                                        mUserManagementHeader.P_Availability = 1;
                                        mUserManagementHeader.P_Activate_Date = DateTime.Now;
                                        mUserManagementHeader.P_Shift = sShiftIn + " to " + sShiftOut;
                                        mUserManagementHeader.PTR_Resources = sResID;
                                    }

                                    if (mUserManagementHeaderMng.AddUserManagementHeader(mUserManagementHeader) > 0)
                                    {

                                        //Assign User Interface data to User Object
                                        // Assign User Detail
                                        mUserManagementDetail.P_UID = sUID;
                                        mUserManagementDetail.P_Project_Availability = "Active";
                                        mUserManagementDetail.P_Activate_Date = DateTime.Now;
                                        mUserManagementDetail.M_UID = sImmediateReporter;
                                        mUserManagementDetail.PIC_UID = sPIC;


                                        for (int j = 8; j < dataGridViewImportUsers.Columns.Count; j++)
                                        {
                                            if (!String.IsNullOrEmpty(dataGridViewImportUsers.Rows[i].Cells[j].Value.ToString()))
                                            {

                                                string sProjectName = dataGridViewImportUsers.Rows[i].Cells[j].Value.ToString();

                                                //Is Exist Pproject
                                                if (new ManagerDetailMng(this.conn).GetActiveProjectIsExistByManager(sImmediateReporter, sPIC, sProjectName) == false)
                                                {
                                                    coutputStrProject += (sProjectName + " [" + sUID + "]" + " , ").ToString();
                                                    continue;

                                                }

                                                mUserManagementDetail.P_Project = sProjectName;

                                                if (mUserManagementDetailMng.AddUserManagementDetail(mUserManagementDetail) > 0)
                                                {

                                                }
                                            }
                                        }
                                    }
                                }

                            }

                            //Check ouput string status
                            if (outputStrUName != "" || coutputStrProject != "" || outputStrManager != "" || outputStrAccess != "" || outputStrResource != "")
                            {

                                //MessageBox.Show("Precess Complete! \nSome Item Codes are already exist in the Project Quota.\n\n" + outputStr, "Project Quota Registerd", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                string moutput = "Registered User Name(s) Found..!," + outputStrUName;
                                string mcoutputStr = "Invalid Project(s) Found..!," + coutputStrProject;
                                string mcoutputMStr = "Manager(s) Not Found..!," + outputStrManager;
                                string mcoutputAccessStr = "Invalid Access Level Found..!," + outputStrAccess;
                                string mcoutputResourceStr = "Invalid Resource ID(s) Found..!," + outputStrResource;

                                frm_ExistBulkUserRegisterMessage ExistFrom = new frm_ExistBulkUserRegisterMessage(moutput, mcoutputStr, mcoutputMStr, mcoutputAccessStr, mcoutputResourceStr);
                                ExistFrom.Show();
                                this.Close();
                            }
                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "User bulk successfully registered..!", "User Registered!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.OpenForms["frm_UserManagementPanel"].BringToFront();
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

                        MetroFramework.MetroMessageBox.Show(this, "\nThere is no data to import! \nPlease import provided excel template.", "Empty Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnImportSheet.Focus();
                    }

                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233086)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "\nUnregistered project name found. Please check your template again.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Message: " + ex.HResult, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_UserManagementPanel"].BringToFront();
            this.Close();
        }

        private void dataGridViewImportUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
      
        }
    }
}
