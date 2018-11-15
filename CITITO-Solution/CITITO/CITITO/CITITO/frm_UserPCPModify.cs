using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;

namespace CITITO
{
    public partial class frm_UserPCPModify : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_UserPCPModify _instance;
        public static frm_UserPCPModify GetInstance(String uRecordID, String uUserID, String uPCPCode, String uTaskCode, DateTime uTaskIn, DateTime uTaskOut, int uSize, String uPCPStatus)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                String mRecordID = uRecordID;
                String mUserID = uUserID;
                String mPCPCode = uPCPCode;
                String mTaskCode = uTaskCode;
                DateTime mTaskIn = uTaskIn;
                DateTime mTaskOut = uTaskOut;
                String mPCPStatus = uPCPStatus;
                int mSize = uSize;

                _instance = new frm_UserPCPModify(mRecordID, mUserID, mPCPCode, mTaskCode, mTaskIn, mTaskOut, mSize, mPCPStatus);

                
            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_UserPCPModify(String uRecordID, String uUserID, String uPCPCode, String uTaskCode, DateTime uTaskIn, DateTime uTaskOut, int uSize, String uPCPStatus)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            //Parameters asign            
            lblID.Text = uRecordID;
            lblPCPCode.Text = uPCPCode;
            lblOldTaskCode.Text = uTaskCode;
            dateTimePickerTaskIn.Value = uTaskIn;
            dateTimePickerTaskOut.Value = uTaskOut;
            lblSize.Text = uSize.ToString();

        }

        private void frm_UserPCPModify_Load(object sender, EventArgs e)
        {
            // Set the Format type and the CustomFormat string.
            dateTimePickerTaskIn.Format = DateTimePickerFormat.Custom;
            dateTimePickerTaskIn.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";

            dateTimePickerTaskOut.Format = DateTimePickerFormat.Custom;
            dateTimePickerTaskOut.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
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

        //Data time picker 
        private void dateTimePickerTaskIn_ValueChanged(object sender, EventArgs e)
        {
            //Time Calculation
            TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;

            double hours = diff.TotalHours;

            txtTaskHours.Text = Math.Round(hours, 3).ToString();
        }

        private void dateTimePickerTaskOut_ValueChanged(object sender, EventArgs e)
        {
            //Time Calculation
            TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;

            double hours = diff.TotalHours;

            txtTaskHours.Text = Math.Round(hours, 3).ToString();
        }

        //Task Hours calculate
        private void txtIdleHours_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(txtTaskHours.Text) <= 0)
                {
                    pictureBoxWarning.Show();
                    lblWarning.Show();
                    lblWarning.Text = "Task out time is erliest than task in time. Please correct!";

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

        //Start >> frm_UserManagement enable move using mouse left down
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void frm_UserPCPModify_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //End >> frm_UserManagement enable move using mouse left down

        //Modify button
        private void btnModify_Click(object sender, EventArgs e)
        {
            //Get user Confirmation
            DialogResult result = MessageBox.Show("Do you really want to modify record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
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
                String mItemCode = mPCPDetailMng.GetItemCodeAndTaskCodeByPCPCode(lblPCPCode.Text).Rows[0][0].ToString();
                String mTaskCode = mPCPDetailMng.GetItemCodeAndTaskCodeByPCPCode(lblPCPCode.Text).Rows[0][1].ToString();

                int mFileSize = int.Parse(lblSize.Text);
                String mTaskStatus = lblPCPStatus.Text;


                int QuotaSize = mProjectMatrixMng.GetQuotaSize(mItemCode, mTaskCode);

                float PrductDivedeByQuota = float.Parse(mFileSize.ToString()) / QuotaSize;
                float PrductDivedeByTime = (9 / float.Parse(hours.ToString()));

                float mProductivity = (PrductDivedeByQuota * PrductDivedeByTime) * 100;

                //Assign User Interface data to UserPCPDetails Object
                mPCPUserDetail.ID = int.Parse(lblID.Text);
                mPCPUserDetail.PCPTaskInTime = dateTimePickerTaskIn.Value;
                mPCPUserDetail.PCPTaskOutTime = dateTimePickerTaskOut.Value;
                mPCPUserDetail.PCPHours = float.Parse(hours.ToString());
                mPCPUserDetail.PCPCode = lblPCPCode.Text;
                mPCPUserDetail.PCPTaskCode = lblOldTaskCode.Text;
                mPCPUserDetail.PCPUserDoneSize = mFileSize;
                mPCPUserDetail.PCPUserStatus = lblPCPStatus.Text;
                mPCPUserDetail.PCPLogTime = dateTimePickerTaskOut.Value;
                mPCPUserDetail.PCPUserProductivity = mProductivity;


                //PCPDetails initialize
                mPCPDetail.PCPCode = lblPCPCode.Text;
                mPCPDetail.TaskCode = lblOldTaskCode.Text;
                mPCPDetail.PCPStatus = lblPCPStatus.Text;
                mPCPDetail.PCPDoneTime = dateTimePickerTaskOut.Value;
                mPCPDetail.PCPDoneUID = lblUID.Text;

                if (mPCPUserDetailMng.UpdatePCPDetailByID(mPCPUserDetail)>0)
                {
                    //Show Completed Message
                    MessageBox.Show("Record has been successfully modified..!", "Record Modified!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();

                }
                
            }

            else
            {
                return;
            }
        }

    }
}
