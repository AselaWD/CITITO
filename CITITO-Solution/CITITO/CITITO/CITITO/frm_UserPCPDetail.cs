using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;

namespace CITITO
{
    public partial class frm_UserPCPDetail : MetroForm
    {
        SqlConnection conn;

        public frm_UserPCPDetail()
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            String mUID = "7AO";
            


            txtUserID.Text = mUID;
        }


        //Close button
        private void pboxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frm_UserPCPDetail_Load(object sender, EventArgs e)
        {
            // Set the Format type and the CustomFormat string.
           dateTimePickerTaskIn.Format = DateTimePickerFormat.Custom;
           dateTimePickerTaskIn.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";

            dateTimePickerTaskOut.Format = DateTimePickerFormat.Custom;
           dateTimePickerTaskOut.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";

            timer1.Enabled = true;
            timer1.Interval = 1000;

            //Load data
            RefreshData();
            ClearFields();

            cmbtaskCode.Enabled = false;
            numericUpDownFileSize.Enabled = false;
            cmbTaskStatus.Enabled = false;

        }

        //Add button
        private void btnFileTask_Click(object sender, EventArgs e)
        {
            //Validate fields
            if (string.IsNullOrEmpty(txtPCPCode.Text))
            {
                MessageBox.Show("PCP Code cannot be empty!", "Invalid PCP Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPCPCode.BackColor = Color.OrangeRed;
                txtPCPCode.Focus();
                return;
            }
            if (String.IsNullOrEmpty(numericUpDownFileSize.Text) || int.Parse(numericUpDownFileSize.Text) <= 0)
            {
                MessageBox.Show("Quota Size cannot be zero or text type..!", "Invalid Quota Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDownFileSize.Focus();
                numericUpDownFileSize.BackColor = Color.OrangeRed;
                return;
            }

            //Get user Confirmation
            DialogResult result = MessageBox.Show("Do you really want to apply task \"" + cmbtaskCode.Text + "\" for PCP Code \"" + txtPCPCode.Text + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (new PCPDetailMng(this.conn).PCPCodeIsExist(txtPCPCode.Text) == false)
                {
                    MessageBox.Show("PCP Code not found! Please check again.", "Invalid PCP Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPCPCode.BackColor = Color.OrangeRed;
                    txtPCPCode.Focus();
                    return;

                }
                else
                {

                    //Create Object From PCPUserDetail
                    PCPUserDetail mPCPUserDetail = new PCPUserDetail();
                    PCPUserDetailMng mPCPUserDetailMng = new PCPUserDetailMng(this.conn);

                    //Project Matrix
                    ProjectMatrix mProjectMatrix = new ProjectMatrix();
                    ProjectMatrixMng mProjectMatrixMng = new ProjectMatrixMng(this.conn);

                    PCPDetail mPCPDetail = new PCPDetail();
                    PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

                    //Time Calculation
                    TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;
                   
                    double hours = diff.TotalHours;

                    //Calculate productivity
                    
                    String mItemCode = mPCPDetailMng.GetItemCodeAndTaskCodeByPCPCode(txtPCPCode.Text).Rows[0][0].ToString();
                    String mTaskCode = mPCPDetailMng.GetItemCodeAndTaskCodeByPCPCode(txtPCPCode.Text).Rows[0][1].ToString();



                    int QuotaSize = mProjectMatrixMng.GetQuotaSize(mItemCode, mTaskCode);

                    float PrductDivedeByQuota = float.Parse(numericUpDownFileSize.Value.ToString()) / QuotaSize;
                    float PrductDivedeByTime = (9/float.Parse(hours.ToString()));

                    float mProductivity = (PrductDivedeByQuota * PrductDivedeByTime) * 100;

                    //

                    //Assign User Interface data to UserPCPDetails Object
                    mPCPUserDetail.PCPUserID = txtUserID.Text;
                    mPCPUserDetail.PCPTaskInTime = dateTimePickerTaskIn.Value;
                    mPCPUserDetail.PCPTaskOutTime = dateTimePickerTaskOut.Value;
                    mPCPUserDetail.PCPHours = float.Parse(hours.ToString());
                    mPCPUserDetail.PCPCode = txtPCPCode.Text;
                    mPCPUserDetail.PCPTaskCode = cmbtaskCode.Text;
                    mPCPUserDetail.PCPUserDoneSize = int.Parse(numericUpDownFileSize.Value.ToString());
                    mPCPUserDetail.PCPUserStatus = cmbTaskStatus.Text;
                    mPCPUserDetail.PCPLogTime = dateTimePickerTaskOut.Value;
                    mPCPUserDetail.PCPUserProductivity = mProductivity;
                    mPCPUserDetail.ApproveStatus = "";
                    mPCPUserDetail.UserImmediateReporter = "Ajith Perera";

                    //PCPDetails initialize
                    mPCPDetail.PCPCode= txtPCPCode.Text;
                    mPCPDetail.TaskCode = cmbtaskCode.Text;
                    mPCPDetail.PCPStatus = cmbTaskStatus.Text;
                    mPCPDetail.PCPDoneTime = dateTimePickerTaskOut.Value;
                    mPCPDetail.PCPDoneUID = txtUserID.Text;

                    

                    //Check DoneSize is match to the Task history
                    int ActualFileSize= mPCPDetailMng.GetActualFileSize(txtPCPCode.Text, cmbtaskCode.Text);
                    int PendingHistoryCount = mPCPUserDetailMng.GetActualFileSizeFroPending(txtPCPCode.Text, cmbtaskCode.Text);

                    //Validate from PCP Details table
                    if (ActualFileSize < numericUpDownFileSize.Value)
                    {

                        MessageBox.Show("File size exceeded actual file size.\n\nActual File Size: "+ActualFileSize+ "\nEntered File Size: " + numericUpDownFileSize.Value, "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        numericUpDownFileSize.BackColor = Color.OrangeRed;
                        numericUpDownFileSize.Focus();
                        return;

                    }

                    //Validate from User PCP Details history
                    if (ActualFileSize < numericUpDownFileSize.Value + PendingHistoryCount)
                    {

                        MessageBox.Show("File size exceeded actual file size.\n\nActual File Size: "+ActualFileSize+ "\nHistory of File Size: " + PendingHistoryCount + "\nRest File Size: ["+ (ActualFileSize- PendingHistoryCount)+"]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        numericUpDownFileSize.BackColor = Color.OrangeRed;
                        numericUpDownFileSize.Focus();
                        return;

                    }

                    //Pending validate
                    if (ActualFileSize == numericUpDownFileSize.Value + PendingHistoryCount && cmbTaskStatus.Text=="Pending")
                    {

                        MessageBox.Show("File size is matching to Actual file size on \"Pending\" category.\nPlease reduce the file size or select task \"Done\".\n\nActual File Size: " + ActualFileSize + "\nHistory of File Size: " + PendingHistoryCount + "\nRest File Size: [" + (ActualFileSize - PendingHistoryCount) + "]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        numericUpDownFileSize.BackColor = Color.OrangeRed;
                        numericUpDownFileSize.Focus();
                        return;

                    }

                    //Done validate
                    if (ActualFileSize != numericUpDownFileSize.Value + PendingHistoryCount && cmbTaskStatus.Text == "Done")
                    {

                        MessageBox.Show("File size is not matching to Actual file size on \"Done\" category.\nPlease verify your file size to the actual page count.\n\nActual File Size: " + ActualFileSize + "\nHistory of File Size: " + PendingHistoryCount + "\nRest File Size: [" + (ActualFileSize - PendingHistoryCount) + "]", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        numericUpDownFileSize.BackColor = Color.OrangeRed;
                        numericUpDownFileSize.Focus();
                        return;

                    }

                    //Calculate process pecentage
                    int pecentage = ActualFileSize*(3/4);

                    if (pecentage<= numericUpDownFileSize.Value + PendingHistoryCount)
                    {
                        
                        //Get user Confirmation
                        DialogResult fileresult = MessageBox.Show("It seems the process of your task is reaching to last 25%.\nPlease task \"Done\" or proceed anyway?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (fileresult == DialogResult.Yes)
                        {
                            if (mPCPUserDetailMng.AddUserPCPRecord(mPCPUserDetail) > 0)
                            {
                                //Update PCP Status on PCP Details
                                if (cmbTaskStatus.Text == "Pending")
                                {
                                    mPCPDetailMng.UpdatePCPStatusPending(mPCPDetail);
                                }
                                if (cmbTaskStatus.Text == "Done")
                                {
                                    mPCPDetailMng.UpdatePCPStatusDone(mPCPDetail);
                                }

                                //Show Completed Message
                                MessageBox.Show("Your task successfully filed..!", "Task Filed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshData();
                                ClearFields();
                            }
                        }
                    }

                }

            }

            else
            {
                return;
            }

        }

        //Run Timmer
        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePickerTaskOut.Text = DateTime.Now.ToLongTimeString();
        }

        //Start >> frm_UserManagement enable move using mouse left down
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
    
        private void frm_UserPCPDetail_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }
        //End >> frm_UserManagement enable move using mouse left down


        //Enter key press on PCP Code filed
        private void txtPCPCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Validate fields
                if (string.IsNullOrEmpty(txtPCPCode.Text))
                {
                    MessageBox.Show("PCP Code cannot be empty!", "Invalid PCP Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPCPCode.BackColor = Color.OrangeRed;
                    txtPCPCode.Focus();
                    return;
                }

                try
                {
                    if (new PCPDetailMng(this.conn).PCPCodeIsExist(txtPCPCode.Text) == false)
                    {
                        MessageBox.Show("PCP Code not found! Please check again.", "Invalid PCP Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPCPCode.BackColor = Color.OrangeRed;
                        txtPCPCode.Focus();
                        return;

                    }
                    else
                    {
                        //Validate task Done
                        if (new PCPDetailMng(this.conn).GetTaskCodeByPCPCodeAndStatusNotDoneOrHold(txtPCPCode.Text).Count() == 0)
                        {
                            MessageBox.Show("All the tasks for the PCP "+txtPCPCode.Text+" are done.\nPlease enter a new PCP Code.", "Invalid PCP Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPCPCode.BackColor = Color.OrangeRed;
                            txtPCPCode.Focus();
                            return;
                        }
                        else
                        {
                            //Activate fileds
                            cmbtaskCode.Enabled = true;
                            numericUpDownFileSize.Enabled = true;
                            cmbTaskStatus.Enabled = true;


                            //Next to be fill
                            cmbtaskCode.Focus();

                            //Update fields with PCP Code
                            txtShipment.Text = new PCPDetailMng(conn).GetShipmentByPCPCode(txtPCPCode.Text);
                            txtComplexcity.Text = new PCPDetailMng(conn).GetComplexcityByPCPCode(txtPCPCode.Text);
                            cmbtaskCode.DataSource = new PCPDetailMng(this.conn).GetTaskCodeByPCPCodeAndStatusNotDoneOrHold(txtPCPCode.Text);
                            cmbTaskStatus.DataSource = new StatusMng(conn).GetPendingAndDoneStatus();

                            //Clear Fileds
                            cmbtaskCode.SelectedIndex = -1;
                            cmbTaskStatus.SelectedIndex = -1;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtPCPCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtPCPCode.BackColor = Control.DefaultBackColor;
        }

        //Avoid manual enter data
        private void cmbtaskCode_TextChanged(object sender, EventArgs e)
        {
            this.cmbtaskCode.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmbTaskStatus_TextChanged(object sender, EventArgs e)
        {
            this.cmbTaskStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //Refresh Object
        private void RefreshData()
        {

            //Load data
            dataGridViewUserPCPDetails.DataSource = new PCPUserDetailMng(this.conn).GetPCPRecordByUserID(txtUserID.Text);

            cmbtaskCode.Enabled = false;
            numericUpDownFileSize.Enabled = false;
            cmbTaskStatus.Enabled = false;


        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();

            //Clear All Fields when Load

            txtPCPCode.Text = String.Empty;
            txtShipment.Text = String.Empty;
            cmbtaskCode.SelectedIndex = -1;
            cmbTaskStatus.SelectedIndex = -1;
            txtComplexcity.Text = String.Empty;
            numericUpDownFileSize.Value = 0;
            
        }

        //Reset field colors
        private void txtPCPCode_TextChanged(object sender, EventArgs e)
        {
            txtPCPCode.BackColor = Control.DefaultBackColor;
        }

        private void numericUpDownFileSize_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownFileSize.BackColor = Control.DefaultBackColor;
        }

        private void numericUpDownFileSize_MouseClick(object sender, MouseEventArgs e)
        {
            numericUpDownFileSize.BackColor = Control.DefaultBackColor;
        }

        //Minimize button
        private void pboxMinimize_Click(object sender, EventArgs e)
        {
            //minimize window
            this.WindowState = FormWindowState.Minimized;
        }

        //Referesh button
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
