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
    public partial class frm_ExistBulkUserRegisterMessage : MetroForm
    {
        public frm_ExistBulkUserRegisterMessage(string moutput, string mcoutputStr, string mcoutputMStr, string mcoutputAccessStr, string mcoutputResourceStr)
        {
            InitializeComponent();

            richTextBoxExistCodes.Text = "";

            if (moutput.Trim() != "Registered User Name(s) Found..!,")
            {
                string strText = moutput.Trim();
                string[] strArr = strText.Split(',');

                for (int i = 0; i < strArr.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr[i].Trim() + "\n";
                }
            }

            if (mcoutputStr.Trim() != "Invalid Project(s) Found..!,")
            {
                string strText1 = mcoutputStr.Trim();
                string[] strArr1 = strText1.Split(',');

                for (int i = 0; i < strArr1.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr1[i].Trim() + "\n";
                }
            }

            if (mcoutputMStr.Trim() != "Manager(s) Not Found..!,")
            {
                string strText2 = mcoutputMStr.Trim();
                string[] strArr2 = strText2.Split(',');

                for (int i = 0; i < strArr2.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr2[i].Trim() + "\n";
                }
            }

            if (mcoutputAccessStr.Trim() != "Invalid Access Level Found..!,")
            {
                string strText3 = mcoutputAccessStr.Trim();
                string[] strArr3 = strText3.Split(',');

                for (int i = 0; i < strArr3.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr3[i].Trim() + "\n";
                }
            }

            if (mcoutputResourceStr.Trim() != "Invalid Resource ID(s) Found..!,")
            {
                string strText4 = mcoutputResourceStr.Trim();
                string[] strArr4 = strText4.Split(',');

                for (int i = 0; i < strArr4.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr4[i].Trim() + "\n";
                }
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_UserManagementPanel"].BringToFront();
            this.Close();
        }

        private void frm_ExistBulkUserRegisterMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.OpenForms["frm_UserManagementPanel"].BringToFront();
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

        private void frm_ExistBulkUserRegisterMessage_Load(object sender, EventArgs e)
        {

        }
    }
}
