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
    public partial class frm_AssignUsersToProject : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_AssignUsersToProject _instance;
        public static frm_AssignUsersToProject GetInstance(string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mPIC = uPIC;
                _instance = new frm_AssignUsersToProject(mPIC);

            }
            return _instance;

        }

        public frm_AssignUsersToProject(string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblPIC.Text = uPIC;
        }

        private void frm_AssignUsersToProject_Load(object sender, EventArgs e)
        {
            RefreshData();
            ClearFields();
        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_MainForm_PIC"].BringToFront();
            this.Close();
        }

        //Clear Object
        private void ClearFields()
        {
            RefreshData();

            //Clear All Fields when Load
            cmbCurrentProject.SelectedIndex = -1;
            cmbAssignProject.SelectedIndex = -1;

            //Uncheck all items in check list
            for (int index = 0; index < checkedListBoxUsers.Items.Count; ++index)
            {
                checkedListBoxUsers.SetItemChecked(index, false);
            }
        }
    
        //Refresh Object
        private void RefreshData()
        {
            cmbCurrentProject.DataSource = new ProjectDetailMng(this.conn).GetListOfProjectNamesByPIC(lblPIC.Text);

        }

        //Check all Nodes
        private void treeViewUserList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckTreeViewNode(e.Node, e.Node.Checked);
        }

        private void CheckTreeViewNode(TreeNode node, Boolean isChecked)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;

                if (item.Nodes.Count > 0)
                {
                    this.CheckTreeViewNode(item, isChecked);
                }
            }
        }


        //Current project index changed
        private void cmbCurrentProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAssignProject.DataSource = new ProjectDetailMng(this.conn).GetListOfProjectNamesByPICExceptParameterProjectName(lblPIC.Text, cmbCurrentProject.Text);
            cmbAssignProject.SelectedIndex = -1;
            //checkedListBoxUsers.DataSource = new ManagerDetailMng(this.conn).GetUsersInDeletableProject(cmbCurrentProject.Text);
            checkedListBoxUsers.DataSource = new ManagerDetailMng(this.conn).GetUsersInDeletableProjectAndPIC(lblPIC.Text, cmbCurrentProject.Text);
            DataTable uProjets = new ProjectDetailMng(this.conn).GetAllUsersByPICAndCurrentProject(lblPIC.Text, cmbCurrentProject.Text);

            //Clear Nodes
            TreeNode listLeafNodes = new TreeNode();
            treeViewUserList.Nodes.Clear();

            //Load Nodes from table
            treeViewUserList.Nodes.Add(lblPIC.Text);

            for (int a = 0; a < uProjets.Rows.Count; a++)
            {
                TreeNode tn = new TreeNode(uProjets.Rows[a][1].ToString());
                tn.Nodes.Add(uProjets.Rows[a][2].ToString());

                treeViewUserList.Nodes[0].Nodes.Add(tn);                

            }

            //Add Check box
            treeViewUserList.CheckBoxes = true;

        }


        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();            

        }
        

        //Select All
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                for (int index = 0; index < checkedListBoxUsers.Items.Count; ++index)
                {
                    checkedListBoxUsers.SetItemChecked(index, true);
                }
            }
            else
            {
                for (int index = 0; index < checkedListBoxUsers.Items.Count; ++index)
                {
                    checkedListBoxUsers.SetItemChecked(index, false);
                }
            }
        }

        //Assign Button
        private void btnAssign_Click(object sender, EventArgs e)
        {

            //Initialize
            string uCurrentProject = cmbCurrentProject.Text;
            string uAssignProject = cmbAssignProject.Text;
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
            if (String.IsNullOrEmpty(cmbAssignProject.Text.ToUpper()))
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select a project to be assigned.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbAssignProject.Focus();
                return;
            }
            if (checkedListBoxUsers.CheckedItems.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease select at least one user.", "Project Not Selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkedListBoxUsers.Focus();
                return;
            }

            DialogResult resulta = MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nDo you want to assign user(s) from project \""+ uCurrentProject + "\" to \""+ uAssignProject + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {

                //for (int i = 0; i < checkedListBoxUsers.Items.Count; i++)
                //{
                //    if (checkedListBoxUsers.GetItemChecked(i))
                //    {
                //        //MessageBox.Show(checkedListBoxTaskCode.Items[i].ToString());
                //        string uUID = checkedListBoxUsers.Items[i].ToString();

                //        //Inactive Project
                //        if (new ManagerDetailMng(this.conn).UpdateManagerProjectToInactive(uUID, uCurrentProject, uTime) > 0)
                //        {
                //            //Add new Active project
                //            mManagerDetail.M_UID = uUID;
                //            mManagerDetail.M_Project_Availability = "Active";
                //            mManagerDetail.M_Activate_Date = uTime;
                //            mManagerDetail.PIC_UID = lblPIC.Text.ToUpper();
                //            mManagerDetail.M_Project = uAssignProject;

                //            //Create new active project
                //            if (!mManagerDetailMng.UserIsExistonActiveProject(uUID, uAssignProject))
                //            {
                //                mManagerDetailMng.AddManagerDetail(mManagerDetail);
                //            }

                //        }
                //    }
                //}


                //string count = treeViewUserList.CheckBoxes.ToString();
                //MessageBox.Show(count,"Count");        


                //foreach (TreeNode managerChildNode in treeViewUserList.Nodes[0].Nodes)
                //{
                //    //Manager Assign to Project
                //    if (managerChildNode.Checked == true)
                //    {
                //        string index = managerChildNode.Index.ToString();
                //        string mMID = managerChildNode.Text;
                //        //MessageBox.Show(index + " Manager " + managerChildNode.Text + "/" + tNodes);

                //    }
                //}

                int tNodes = (treeViewUserList.Nodes[0].Nodes.Count + treeViewUserList.Nodes[0].Nodes.Count);

                for (int a = 0; a < 3; a++)
                {
                    //User Assign to Project
                    foreach (TreeNode userChildChildNode in treeViewUserList.Nodes[0].Nodes[a].Nodes)
                    {
                        if (userChildChildNode.Checked == true)
                        {
                            UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);

                            string index = userChildChildNode.Index.ToString();
                            string mUID = userChildChildNode.Text;
                            string mMID = mUserManagementDetailMng.GetManagerUIDByUserID(mUID);

                            UserManagementDetail mUserManagementDetail = new UserManagementDetail();

                            mUserManagementDetail.PIC_UID = lblPIC.Text;
                            mUserManagementDetail.P_UID = mUID;
                            mUserManagementDetail.M_UID = mMID;
                            mUserManagementDetail.P_Activate_Date = uTime;
                            mUserManagementDetail.P_Project = uAssignProject;
                            mUserManagementDetail.P_Project_Availability = "Active";

                            //MessageBox.Show(index + " User " + mUID + "/" + tNodes);

                            if (mUserManagementDetailMng.UpdateUserProjectToInactive(mUID, mMID, uCurrentProject, uTime) > 0)
                            {
                                mUserManagementDetailMng.AddUserManagementDetail(mUserManagementDetail);
                            }

                        }
                    }
                }



                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nUser(s) has been assigned from poject \"" + uCurrentProject + "\" to \""+ uAssignProject + "\".", "Assigned!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
                ClearFields();

            }
  
        }

    }
}
