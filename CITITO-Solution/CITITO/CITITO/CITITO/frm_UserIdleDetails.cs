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
    public partial class frm_UserIdleDetails : MetroForm
    {
        SqlConnection conn;

        public frm_UserIdleDetails()
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

        //Minimize button
        private void pboxMinimize_Click(object sender, EventArgs e)
        {
            //Minimize window
            this.WindowState = FormWindowState.Minimized;
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frm_UserIdleDetails_Load(object sender, EventArgs e)
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

            dateTimePickerTaskIn.Enabled = false;
            dateTimePickerTaskOut.Enabled = false;
            cmbReason.Enabled = false;
        }

        //Start >> frm_UserManagement enable move using mouse left down
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void frm_UserIdleDetails_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //End >> frm_UserManagement enable move using mouse left down

        //Refresh Object
        private void RefreshData()
        {

            //Load data
            dataGridViewUserIdleDetails.DataSource = new IdleUserDetailMng(this.conn).GetIdleRecordByUserID(txtUserID.Text);
            cmbProjectCode.DataSource = new UserDepartmentMng(this.conn).GetAllDepartment();
            cmbReason.DataSource = new IdleReasonMng(this.conn).GetIdleRreason();

            cmbReason.Enabled = false;
            dateTimePickerTaskIn.Enabled = false;
            dateTimePickerTaskOut.Enabled = false;


        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();

            //Remove item at Index 1
            cmbProjectCode.SelectedIndex = -1;
            cmbReason.SelectedIndex = -1;

            //Clear All Fields when Load
            txtIdleHours.Text = "0";
            cmbReason.Enabled = false;
            dateTimePickerTaskIn.Enabled = false;
            dateTimePickerTaskOut.Enabled = false;

            pictureBoxWarning.Hide();
            lblWarning.Hide();
            lblWarning.Text = "";

        }


        //Avoid manual enter 
        private void cmbProjectCode_TextChanged(object sender, EventArgs e)
        {
            this.cmbProjectCode.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmbReason_TextChanged(object sender, EventArgs e)
        {
            this.cmbReason.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void cmbProjectCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbReason.Enabled = true;
            dateTimePickerTaskIn.Enabled = true;
            dateTimePickerTaskOut.Enabled = true;
        }

        //Idle hours Calculate
        private void dateTimePickerTaskOut_ValueChanged(object sender, EventArgs e)
        {
            //Time Calculation
            TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;

            double hours = diff.TotalHours;

            txtIdleHours.Text = Math.Round(hours, 3).ToString();

        }

        private void dateTimePickerTaskIn_ValueChanged(object sender, EventArgs e)
        {
            //Time Calculation
            TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;

            double hours = diff.TotalHours;

            txtIdleHours.Text = Math.Round(hours, 3).ToString();

        }

        //Idle Hours update and prompt error message
        private void txtIdleHours_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(txtIdleHours.Text) <= 0)
                {
                    pictureBoxWarning.Show();
                    lblWarning.Show();
                    lblWarning.Text = "Your task out time is erliest than task in time. Please correct!";

                }
                else
                {
                    pictureBoxWarning.Hide();
                    lblWarning.Hide();
                    lblWarning.Text = "";
                }
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233033)
                {
                    //Skip
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        //Add button
        private void btnFileTask_Click(object sender, EventArgs e)
        {
            //Validate fields
            if (string.IsNullOrEmpty(cmbProjectCode.Text))
            {
                MessageBox.Show("Project Code cannot be empty!", "Invalid Project Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbReason.Text))
            {
                MessageBox.Show("Reason cannot be empty!", "Invalid Reason", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txtIdleHours.Text) || float.Parse(txtIdleHours.Text) <= 0)
            {
                MessageBox.Show("Idle hours cannot be zero or text type..!", "Invalid Idle Hours", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Get user Confirmation
            DialogResult result = MessageBox.Show("Do you really want to apply idle hours?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Time Calculation
                TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;
                double hours = diff.TotalHours;

                //Current Time
                DateTime mNow = DateTime.Now;

                //Productivity
                float PrductDivedeByTime = (float.Parse(hours.ToString())/9);
                float mProductivity = (PrductDivedeByTime) * 100;

                //Create Object From IdleUserDetail
                IdleUserDetail mIdleUserDetail = new IdleUserDetail();
                IdleUserDetailMng mIdleUserDetailMng = new IdleUserDetailMng(this.conn);

                //Initialize object values
                mIdleUserDetail.IdleUserID = txtUserID.Text;
                mIdleUserDetail.IdleProject = cmbProjectCode.Text;
                mIdleUserDetail.IdleTaskInTime = dateTimePickerTaskIn.Value;
                mIdleUserDetail.IdleTaskOutTime = dateTimePickerTaskOut.Value;
                mIdleUserDetail.IdleHours= float.Parse(hours.ToString());
                mIdleUserDetail.IdleTaskCode = cmbReason.Text;
                mIdleUserDetail.IdleLogTime = mNow;
                mIdleUserDetail.IdleUserProductivity = mProductivity;
                mIdleUserDetail.IdleApproveStatus = "";
                mIdleUserDetail.UserImmediateReporter = "Ajith Perera";


                if (mIdleUserDetailMng.UserIdleIsExist(mIdleUserDetail) == false)
                {
                    if (mIdleUserDetailMng.AddUserIdleRecord(mIdleUserDetail) > 0)
                    {
                        //Show Completed Message
                        MessageBox.Show("Your task successfully filed..!", "Task Filed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshData();
                        ClearFields();
                    }

                }
                else
                {
                    MessageBox.Show("Idle Task is already exist for this time span! Please check again.", "Idle Task Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        //Refresh button
        private void pBoxRefersh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
