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
    public partial class frm_ExistBulkQuotaMessage : MetroForm
    {
        public frm_ExistBulkQuotaMessage(string moutputProject, string moutputProcesscode, string moutputTaskCode, string moutputDescrtiption, string moutputUOM, string moutputQuota)
        {
            InitializeComponent();

            richTextBoxExistCodes.Text = "";

            if (moutputProject.Trim() != "Invalid Project Name(s) Found..!,")
            {
                string strText = moutputProject.Trim();
                string[] strArr = strText.Split(',');

                for (int i = 0; i < strArr.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr[i].Trim() + "\n";
                }
            }

            if (moutputProcesscode.Trim() != "Invalid Process Code(s) Found..!,")
            {
                string strText1 = moutputProcesscode.Trim();
                string[] strArr1 = strText1.Split(',');

                for (int i = 0; i < strArr1.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr1[i].Trim() + "\n";
                }
            }

            if (moutputTaskCode.Trim() != "Task Code Already Exist For Following Details..!,")
            {
                string strText2 = moutputTaskCode.Trim();
                string[] strArr2 = strText2.Split(',');

                for (int i = 0; i < strArr2.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr2[i].Trim() + "\n";
                }
            }

            if (moutputDescrtiption.Trim() != "Description Cannot Be Empty..!,")
            {
                string strText3 = moutputDescrtiption.Trim();
                string[] strArr3 = strText3.Split(',');

                for (int i = 0; i < strArr3.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr3[i].Trim() + "\n";
                }
            }
            if (moutputUOM.Trim() != "UOM Cannot Be Empty..!,")
            {
                string strText4 = moutputUOM.Trim();
                string[] strArr4 = strText4.Split(',');

                for (int i = 0; i < strArr4.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr4[i].Trim() + "\n";
                }
            }
            if (moutputQuota.Trim() != "Quota Cannot Be Empty..!,")
            {
                string strText5 = moutputQuota.Trim();
                string[] strArr5 = strText5.Split(',');

                for (int i = 0; i < strArr5.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr5[i].Trim() + "\n";
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
            this.Close();
        }

        private void frm_ExistBulkQuotaMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.OpenForms["frm_ProjectRegistrationPanel"].BringToFront();
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
