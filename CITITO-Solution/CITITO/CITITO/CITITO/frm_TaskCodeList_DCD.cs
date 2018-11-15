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
    public partial class frm_TaskCodeList_DCD : MetroForm
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_TaskCodeList_DCD _instance;
        public static frm_TaskCodeList_DCD GetInstance()
        {

            if (_instance == null || _instance.IsDisposed)
            {
            
                _instance = new frm_TaskCodeList_DCD();

            }
            return _instance;

        }

        public frm_TaskCodeList_DCD()
        {
            InitializeComponent();

            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            conn.Open();
        }

        private void frm_TaskCodeList_DCD_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        //Refresh Object
        private void RefreshData()
        {
            dataGridViewTaskCodeList.DataSource = new TaskDetailMng(this.conn).GetAllTaskCodeDetails();


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_DCD"].BringToFront();
            this.Close();
        }

        private void txtProject_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProject.Text))
            {
                dataGridViewTaskCodeList.DataSource = new TaskDetailMng(this.conn).GetAllTaskCodeDetailsBYProject(txtProject.Text);
            }
            else
            {
                RefreshData();
            }
        }

        private void txtTaskCode_KeyUp(object sender, KeyEventArgs e)
        {
            if(!String.IsNullOrEmpty(txtTaskCode.Text))
            {
                dataGridViewTaskCodeList.DataSource = new TaskDetailMng(this.conn).GetAllTaskCodeDetailsBYTaskCode(txtTaskCode.Text);
            }
            else
            {
                RefreshData();
            }
        }

        private void txtProcessCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProcessCode.Text))
            {
                dataGridViewTaskCodeList.DataSource = new TaskDetailMng(this.conn).GetAllTaskCodeDetailsBYProcessCode(txtProcessCode.Text);
            }
            else
            {
                RefreshData();
            }
        }

        private void dataGridViewTaskCodeList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //User output validation /* 0 - Yes, 1 - No */
            if (e.ColumnIndex == 6)
            {
                if ((int)e.Value == 0)
                {
                    e.Value = "Yes";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#53FF45");

                }
                else if ((int)e.Value == 1)
                {
                    e.Value = "No";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EABC20");
                }

            }
        }
    }
}
