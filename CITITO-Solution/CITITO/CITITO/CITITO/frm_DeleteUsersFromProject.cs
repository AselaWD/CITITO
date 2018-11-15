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
    public partial class frm_DeleteUsersFromProject : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_DeleteUsersFromProject _instance;
        public static frm_DeleteUsersFromProject GetInstance(string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mPIC = uPIC;
                _instance = new frm_DeleteUsersFromProject(mPIC);

            }
            return _instance;

        }

        public frm_DeleteUsersFromProject(string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblPIC.Text = uPIC;
        }

        private void frm_DeleteUsersFromProject_Load(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();

            //Clear All Fields when Load
            cmbCurrentProject.SelectedIndex = -1;

            //Uncheck all items in check list
            for (int index = 0; index < checkedListBoxUsersToDelete.Items.Count; ++index)
            {
                checkedListBoxUsersToDelete.SetItemChecked(index, false);
            }
        }

        //Refresh Object
        private void RefreshData()
        {
            cmbCurrentProject.DataSource = new ProjectDetailMng(this.conn).GetListOfProjectNamesByPIC(lblPIC.Text);

        }

        private void cmbCurrentProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBoxUsersToDelete.DataSource = new ManagerDetailMng(this.conn).GetUsersInDeletableProject(cmbCurrentProject.Text);
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_MainForm_PIC"].BringToFront();
            this.Close();
        }

        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //Select all checked
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                for (int index = 0; index < checkedListBoxUsersToDelete.Items.Count; ++index)
                {
                    checkedListBoxUsersToDelete.SetItemChecked(index, true);
                }
            }
            else
            {
                for (int index = 0; index < checkedListBoxUsersToDelete.Items.Count; ++index)
                {
                    checkedListBoxUsersToDelete.SetItemChecked(index, false);
                }
            }
        }

        //Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {

            //Initialize
            string uCurrentProject = cmbCurrentProject.Text;
            DateTime uTime = DateTime.Now;

            ManagerDetail mManagerDetail = new ManagerDetail();
            ManagerDetailMng mManagerDetailMng = new ManagerDetailMng(this.conn);


            //Validate Fields is null or empty
            if (String.IsNullOrEmpty(cmbCurrentProject.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select current project.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCurrentProject.Focus();
                return;
            }
            if (checkedListBoxUsersToDelete.CheckedItems.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select at least one user.", "Project Not Selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkedListBoxUsersToDelete.Focus();
                return;
            }

            DialogResult resulta = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to delete user(s) from project \"" + uCurrentProject + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                for (int i = 0; i < checkedListBoxUsersToDelete.Items.Count; i++)
                {
                    if (checkedListBoxUsersToDelete.GetItemChecked(i))
                    {
                        //MessageBox.Show(checkedListBoxTaskCode.Items[i].ToString());
                        string uUID = checkedListBoxUsersToDelete.Items[i].ToString();

                        //Inactive Project
                        new ManagerDetailMng(this.conn).UpdateManagerProjectToInactive(uUID, uCurrentProject, uTime);

                    }
                }
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser(s) has been deleted from poject \"" + uCurrentProject + "\".", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
                ClearFields();
            }
        }
    }
}
