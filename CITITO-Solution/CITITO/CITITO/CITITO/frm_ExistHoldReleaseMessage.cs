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
    public partial class frm_ExistHoldReleaseMessage : MetroForm
    {
        public frm_ExistHoldReleaseMessage(string moutput)
        {
            InitializeComponent();

            richTextBoxExistCodes.Text = "";

            if (moutput.Trim() != "Please task out user(s) from following file(s).,")
            {
                string strText = moutput.Trim();
                string[] strArr = strText.Split(',');

                for (int i = 0; i < strArr.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr[i].Trim() + "\n";
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_DCD"].BringToFront();
            this.Close();
        }

        private void frm_ExistHoldReleaseMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.OpenForms["frm_DCD"].BringToFront();
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
