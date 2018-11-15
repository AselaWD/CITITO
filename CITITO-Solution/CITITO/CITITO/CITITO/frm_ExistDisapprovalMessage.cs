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
    public partial class frm_ExistDisapprovalMessage : MetroForm
    {
        public frm_ExistDisapprovalMessage(string moutput)
        {
            InitializeComponent();

            richTextBoxExistCodes.Text = "";

            if (moutput.Trim() != "Please disaprove status done record(s) first.,")
            {
                string strText = moutput.Trim();
                string[] strArr = strText.Split(',');

                for (int i = 0; i < strArr.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr[i].Trim() + "\n";
                }
            }
            else if (moutput.Trim() != "Please delete status done record(s) first.,")
            {
                string strText1 = moutput.Trim();
                string[] strArr1 = strText1.Split(',');

                for (int i = 0; i < strArr1.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr1[i].Trim() + "\n";
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_ApprovalTaskInOut"].BringToFront();
            this.Close();
        }

        private void frm_ExistDisapprovalMessage_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
