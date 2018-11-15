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

namespace CITITO
{
    public partial class frm_UserPCPPanel :MetroForm
    {
        //Start Pass insatance when form is already opend or not
        private static frm_UserPCPPanel _instance;
        public static frm_UserPCPPanel GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {

                _instance = new frm_UserPCPPanel();

            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public frm_UserPCPPanel()
        {
            InitializeComponent();
        }

        private void pboxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frm_UserPCPPanel_Load(object sender, EventArgs e)
        {
            frm_UserPCPDetail myForm = new frm_UserPCPDetail();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            panel1.Controls.Add(myForm);
            myForm.Show();

            btnTaskInOut.FlatAppearance.BorderSize = 1;
        }

        private void btnTaskInOut_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frm_UserPCPDetail myForm = new frm_UserPCPDetail();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            panel1.Controls.Add(myForm);
            myForm.Show();

            btnTaskInOut.FlatAppearance.BorderSize = 1;

            //Inactive buttons
            btnIdleTask.BackColor = Color.LightBlue;
            btnIdleTask.ForeColor = Color.Gray;

            //Active buttons
            btnTaskInOut.BackColor = Color.DeepSkyBlue;
            btnTaskInOut.ForeColor = Color.Black;
        }

        private void btnIdleTask_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frm_UserIdleDetails myForm = new frm_UserIdleDetails();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            panel1.Controls.Add(myForm);
            myForm.Show();

            btnIdleTask.FlatAppearance.BorderSize = 1;

            //Inactive buttons
            btnTaskInOut.BackColor = Color.LightBlue;
            btnTaskInOut.ForeColor = Color.Gray;

            //Active buttons
            btnIdleTask.BackColor = Color.DeepSkyBlue;
            btnIdleTask.ForeColor = Color.Black;
        }

        private void pboxMinimize_Click(object sender, EventArgs e)
        {
            //minimize window
            this.WindowState = FormWindowState.Minimized;
        }

        //Start >> frm_UserManagement enable move using mouse left down

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        private void frm_UserPCPPanel_MouseDown(object sender, MouseEventArgs e)
        {
            //Form movement

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        //End >> frm_UserManagement enable move using mouse left down

    }
}
