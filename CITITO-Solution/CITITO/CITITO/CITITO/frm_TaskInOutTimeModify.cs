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
    public partial class frm_TaskInOutTimeModify : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_TaskInOutTimeModify _instance;
        public static frm_TaskInOutTimeModify GetInstance(string uUID, string uTRID, string uJOBCode, string uShipment, string uFileName, int uOutput, string uUOM, string uTask, int uJobStatus, DateTime uTaskIn, DateTime uTaskOut, float uTaskHours)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUID = uUID;
                String mTRID = uTRID;
                String mJOBCode = uJOBCode;
                String mShipment = uShipment;
                String mFileName = uFileName;
                int mOutput = uOutput;
                String mUOM = uUOM;
                String mTask = uTask;
                int mJobStatus = uJobStatus;
                DateTime mTaskIn = uTaskIn;
                DateTime mTaskOut = uTaskOut;
                float mTaskHours = uTaskHours;

                _instance = new frm_TaskInOutTimeModify(mUID, mTRID, mJOBCode, mShipment, mFileName, mOutput, mUOM, mTask, mJobStatus, mTaskIn, mTaskOut, mTaskHours);

            }
            return _instance;

        }

        public frm_TaskInOutTimeModify(string uUID, string uTRID, string uJOBCode, string uShipment, string uFileName, int uOutput, string uUOM, string uTask, int uJobStatus, DateTime uTaskIn, DateTime uTaskOut, float uTaskHours)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblUID.Text = uUID;
            lblTRID.Text= uTRID;
            lblJobCode.Text = uJOBCode;
            lblShipment.Text = uShipment;
            lblFileName.Text = uFileName;
            lblOutput.Text = uOutput.ToString();
            lblUOM.Text = uUOM;
            lblTask.Text = uTask;
            lblJobStatus.Text = uJobStatus.ToString();
            dateTimePickerTaskIn.Value = uTaskIn;
            dateTimePickerTaskOut.Value = uTaskOut;
            txtTaskHours.Text = uTaskHours.ToString("0.###");
        }
        

        private void frm_TaskInOutTimeModify_Load(object sender, EventArgs e)
        {
            // Set the Format type and the CustomFormat string.
            dateTimePickerTaskIn.Format = DateTimePickerFormat.Custom;
            dateTimePickerTaskIn.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            dateTimePickerTaskIn.ShowUpDown = false;

            dateTimePickerTaskOut.Format = DateTimePickerFormat.Custom;
            dateTimePickerTaskOut.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            dateTimePickerTaskOut.ShowUpDown = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
            this.Close();
        }

        private void frm_TaskInOutTimeModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147023895)
                {
                    //Do nothing
                }
                else
                {
                    MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Modify button
        private void btnModify_Click(object sender, EventArgs e)
        {
            //Validation
            if (String.IsNullOrEmpty(txtTaskHours.Text) || float.Parse(txtTaskHours.Text) <= 0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTask hours cannot be less than zero or empty.", "Invalid Task Hours!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerTaskOut.Focus();
                return;
            }

            //Get user Confirmation
            DialogResult result = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you really want to modify time?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Time Calculation
                TimeSpan diff = dateTimePickerTaskOut.Value - dateTimePickerTaskIn.Value;
                double hours = diff.TotalHours;

                TaskRecordDetail mTaskRecordDetail = new TaskRecordDetail();
                TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

                mTaskRecordDetail.TR_UID = lblUID.Text;
                mTaskRecordDetail.TR_ID = lblTRID.Text;
                mTaskRecordDetail.PCP_ID = lblJobCode.Text;
                mTaskRecordDetail.TR_Shipment = lblShipment.Text;
                mTaskRecordDetail.TR_File = lblFileName.Text;
                mTaskRecordDetail.TR_FileSize = int.Parse(lblOutput.Text);
                mTaskRecordDetail.TR_UOM = lblUOM.Text;
                mTaskRecordDetail.Task_ID = lblTask.Text;
                mTaskRecordDetail.TR_Status = int.Parse(lblJobStatus.Text);
                mTaskRecordDetail.TR_InDate = dateTimePickerTaskIn.Value;
                mTaskRecordDetail.TR_OutDate = dateTimePickerTaskOut.Value;
                mTaskRecordDetail.TR_Hours = float.Parse(hours.ToString());

                //Productivity Calculate
                int QuotaSize = mTaskRecordDetailMng.GetQuotaSize(lblTask.Text, lblJobCode.Text, lblUID.Text);

                float PrductDivedeByQuota = float.Parse(lblOutput.Text) / QuotaSize;
                float PrductDivedeByTime = (9 / float.Parse(hours.ToString()));

                float mProductivity = (PrductDivedeByQuota * PrductDivedeByTime) * 100;

                mTaskRecordDetail.TR_Productivity = mProductivity;

                //Update Task record

                if (mTaskRecordDetailMng.UpdateTaskRecordDetailWithTimeModify(mTaskRecordDetail) > 0)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nTime has been successfuly modified.", "Time Modifed!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
                    this.Close();
                }

            }
            else
            {
                Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
                this.Close();
            }
        }

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

        private void txtIDLEHours_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(txtTaskHours.Text) <= 0)
                {

                    lblIDLEMessage.Visible = true;
                    lblIDLEMessage.Text = "Your task out time is earlier than task in time. Please correct!";

                }
                else
                {

                    lblIDLEMessage.Visible = false;
                    lblIDLEMessage.Text = "";
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
    }
}
