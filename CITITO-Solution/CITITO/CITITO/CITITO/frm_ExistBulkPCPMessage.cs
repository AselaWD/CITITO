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
    public partial class frm_ExistBulkPCPMessage : MetroForm
    {
        public frm_ExistBulkPCPMessage(string moutput, string mcoutputStr, string mtoutputStr, string mtoutputStr_PC)
        {
            InitializeComponent();

            
            richTextBoxExistCodes.Text = "";

            if (moutput.Trim() != "Invalid Project Name(s) Found..!,")
            {
                string strText = moutput.Trim();
                string[] strArr = strText.Split(',');

                for (int i = 0; i < strArr.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr[i].Trim() + "\n";
                }
            }

            if (mcoutputStr.Trim() != "Invalid Process Code(s) Found..!,")
            {
                string strText1 = mcoutputStr.Trim();
                string[] strArr1 = strText1.Split(',');

                for (int i = 0; i < strArr1.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr1[i].Trim() + "\n";
                }
            }

            if (mtoutputStr.Trim() != "Task Code(s) Already Exist..!,")
            {
                string strText2 = mtoutputStr.Trim();
                string[] strArr2 = strText2.Split(',');

                for (int i = 0; i < strArr2.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr2[i].Trim() + "\n";
                }
            }

            if (mtoutputStr_PC.Trim() != "Already Registered File(s) Found with Different Process Codes..!,")
            {
                string strText3 = mtoutputStr_PC.Trim();
                string[] strArr3 = strText3.Split(',');

                for (int i = 0; i < strArr3.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr3[i].Trim() + "\n";
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

        private void frm_ExistBulkPCPMessage_MouseDown(object sender, MouseEventArgs e)
        {
            //Form movement

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pboxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_DCD"].BringToFront();
            this.Close();
        }

        private void frm_ExistBulkPCPMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.OpenForms["frm_DCD"].BringToFront();                
            }
            catch (Exception ex)
            {
                if(ex.HResult== -2147023895)
                {
                    //Do nothing
                }
                else
                {
                    MessageBox.Show("Message: " + ex.Message, "Exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            
        }

    }
}
