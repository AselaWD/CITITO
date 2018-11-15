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
    public partial class frm_UserAssignDeleteFromProjectPanel : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_UserAssignDeleteFromProjectPanel _instance;
        public static frm_UserAssignDeleteFromProjectPanel GetInstance(string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mPIC = uPIC;
                _instance = new frm_UserAssignDeleteFromProjectPanel(mPIC);

            }
            return _instance;

        }

        public frm_UserAssignDeleteFromProjectPanel(string uPIC)
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();

            lblPIC.Text = uPIC;

        }

        private void frm_UserAssignDeleteFromProjectPanel_Load(object sender, EventArgs e)
        {
            String uUID = lblPIC.Text;

            panelUserAssignDeleteFromProject.Controls.Clear();

            frm_AssignUsersToProject myForm = frm_AssignUsersToProject.GetInstance(uUID);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            panelUserAssignDeleteFromProject.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }
        }

        //Assign Tile
        private void tileAssign_Click(object sender, EventArgs e)
        {
            String uUID = lblPIC.Text;

            panelUserAssignDeleteFromProject.Controls.Clear();

            frm_AssignUsersToProject myForm = frm_AssignUsersToProject.GetInstance(uUID);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            panelUserAssignDeleteFromProject.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }
        }

        //Delete Tile
        private void tileDelete_Click(object sender, EventArgs e)
        {
            String uUID = lblPIC.Text;

            panelUserAssignDeleteFromProject.Controls.Clear();

            frm_DeleteUsersFromProject myForm = frm_DeleteUsersFromProject.GetInstance(uUID);

            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            panelUserAssignDeleteFromProject.Controls.Add(myForm);


            if (!myForm.Visible)
            {

                myForm.Show();
            }
            else
            {
                myForm.BringToFront();
            }
        }
        
    }
}
