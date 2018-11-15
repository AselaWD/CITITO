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
    public partial class frm_PCPDelete : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_PCPDelete _instance;
        public static frm_PCPDelete GetInstance(string uUID)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mUID = uUID;


                _instance = new frm_PCPDelete(mUID);

            }
            return _instance;

        }

        public frm_PCPDelete(string uUID)
        {
            InitializeComponent();

            lblUID.Text = uUID;
            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        private void frm_PCPDelete_Load(object sender, EventArgs e)
        {
            //Refresh data fields
            RefreshData();
                        

            //Clear All Fields when Load
            ClearFields();
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

        //All check
        private void checkBoxAllTasks_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAllTasks.Checked == true)
            {
                cmbTaskCode.Enabled = false;
                cmbPCPStatus.Enabled = false;
            }
            else
            {
                cmbTaskCode.Enabled = true;
                cmbPCPStatus.Enabled = true;
            }
        }


        //Start >> frm_PCPDelete enable move using mouse left down
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void frm_PCPDelete_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pboxMinimize_Click(object sender, EventArgs e)
        {
            //minimize window
            this.WindowState = FormWindowState.Minimized;
        }

        //End >> frm_PCPDelete enable move using mouse left down

        
        //Refresh Object
        private void RefreshData()
        {
            cmbPCPCode.DataSource = new PCPHeaderMng(this.conn).GetListPCPCodeByUser(lblUID.Text);

        }

        //Clear Object
        private void ClearFields()
        {
            //Clear All Fields when Load
            cmbTaskCode.SelectedIndex = -1;
            cmbPCPCode.SelectedIndex = -1;
            cmbPCPStatus.SelectedIndex = -1;
            checkBoxAllTasks.Checked=false;
  
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkBoxAllTasks.Checked == true)
            {
                //Get user Confirmation
                DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Do you want to delete all records for job [" + cmbPCPCode.Text + "]?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (new PCPHeaderMng(this.conn).IsExistPCPCode(cmbPCPCode.Text))
                    {
                        PCPDetail mPCPDetail = new PCPDetail();
                        PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

                        mPCPDetail.PCP_ID = cmbPCPCode.Text;

                        //This will be up[date with relationships
                        if (new PCPDetailMng(conn).FreshDeletePCPRecordByPCPID(mPCPDetail) > 0)
                        {
                            if (mPCPDetailMng.GetCountPCPDeatails(cmbPCPCode.Text) == 0)
                            {
                                new PCPHeaderMng(this.conn).DeletePCPHeader(cmbPCPCode.Text);

                                MetroFramework.MetroMessageBox.Show(this, "All Job Codes for " + cmbPCPCode.Text + " sucessfully deleted!", "Job Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.OpenForms["frm_DCD"].BringToFront();
                                this.Close();
                            }
                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "All Job Codes for " + cmbPCPCode.Text + " sucessfully deleted!", "Job Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.OpenForms["frm_DCD"].BringToFront();
                                this.Close();
                            }

                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Job Code is active under production!", "Cannot Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbPCPCode.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Job Code not found!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbPCPCode.Focus();
                        return;
                    }
                }

            }
            else
            {
                if (String.IsNullOrEmpty(cmbPCPCode.Text) || new PCPHeaderMng(this.conn).IsExistPCPCode(cmbPCPCode.Text) == false)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Job Code not found!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbPCPCode.Focus();
                    cmbPCPCode.BackColor = Color.OrangeRed;
                    return;
                }

                if (String.IsNullOrEmpty(cmbTaskCode.Text) || new TaskHeaderMng(this.conn).TaskCodeIsExist2(cmbTaskCode.Text, cmbPCPCode.Text) == false)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Task Code not found!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTaskCode.Focus();
                    cmbTaskCode.BackColor = Color.OrangeRed;
                    return;
                }

                DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Do you want to delete job for " + cmbPCPCode.Text + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    PCPDetail mPCPDetail = new PCPDetail();
                    PCPDetailMng mPCPDetailMng = new PCPDetailMng(this.conn);

                    mPCPDetail.PCP_ID = cmbPCPCode.Text;
                    mPCPDetail.Task_ID = cmbTaskCode.Text;

                    /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
                    string cStatus = cmbTaskCode.Text;

                    if (cStatus== "Fresh")
                    {
                        mPCPDetail.PCP_Status = 0;
                    }
                    if (cStatus == "Hold")
                    {
                        mPCPDetail.PCP_Status = 1;
                    }
                    if (cStatus == "Pending")
                    {
                        mPCPDetail.PCP_Status = 2;
                    }
                    if (cStatus == "Done")
                    {
                        mPCPDetail.PCP_Status = 3;
                    }

                    if (mPCPDetailMng.DeletePCPRecordByStatus(cmbPCPCode.Text,cmbTaskCode.Text, mPCPDetail.PCP_Status) > 0)
                    {
                        if (mPCPDetailMng.GetCountPCPDeatails(cmbPCPCode.Text)==0)
                        {
                            new PCPHeaderMng(this.conn).DeletePCPHeader(cmbPCPCode.Text);

                            MetroFramework.MetroMessageBox.Show(this, "Job Code " + cmbPCPCode.Text + " sucessfully deleted!", "Job Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.OpenForms["frm_DCD"].BringToFront();
                            this.Close();
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Job Code " + cmbPCPCode.Text + " sucessfully deleted!", "Job Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.OpenForms["frm_DCD"].BringToFront();
                            this.Close();
                        }
                        
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Job Code is active under production!", "Cannot Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.OpenForms["frm_DCD"].BringToFront();
                        this.Close();
                    }
                }
            }
        }

        //Avoid text Manual enter
        private void cmbPCPStatus_TextChanged(object sender, EventArgs e)
        {
            this.cmbPCPStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //Change focus color
        private void cmbPCPCode_MouseClick(object sender, MouseEventArgs e)
        {
            cmbPCPCode.BackColor = Control.DefaultBackColor;
        }

        private void cmbPCPCode_TextChanged(object sender, EventArgs e)
        {
            cmbPCPCode.BackColor = Control.DefaultBackColor;
        }

        private void cmbTaskCode_MouseClick(object sender, MouseEventArgs e)
        {
            cmbTaskCode.BackColor = Control.DefaultBackColor;
        }

        private void cmbTaskCode_TextChanged(object sender, EventArgs e)
        {
            cmbTaskCode.BackColor = Control.DefaultBackColor;
        }

        //Load item codes onece Project selected
        private void cmbPCPCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTaskCode.DataSource = new PCPDetailMng(this.conn).GetTaskCodeByPCPCode(cmbPCPCode.Text);
            cmbTaskCode.SelectedIndex = -1;
        }

        private void cmbTaskCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPCPStatus.DataSource = new PCPDetailMng(this.conn).GetStatusByTaskCode(cmbPCPCode.Text, cmbTaskCode.Text);
            cmbPCPStatus.Text = String.Empty;
            
        }

    }
}
