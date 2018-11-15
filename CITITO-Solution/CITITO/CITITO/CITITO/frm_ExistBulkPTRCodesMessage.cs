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
    public partial class frm_ExistBulkPTRCodesMessage : MetroForm
    {
        public frm_ExistBulkPTRCodesMessage(string mcoutputStr, string mcoutputStr1)
        {
            InitializeComponent();
            
            if (mcoutputStr1.Trim() != "Newly Registered Resource ID(s),")
            {
                string strText2 = mcoutputStr1.Trim();
                string[] strArr2 = strText2.Split(',');

                for (int i = 0; i < strArr2.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr2[i].Trim() + "\n";
                }
            }

            if (mcoutputStr.Trim() != "Following existing Resource ID(s) were updated,")
            {
                string strText1 = mcoutputStr.Trim();
                string[] strArr1 = strText1.Split(',');

                for (int i = 0; i < strArr1.Length; i++)
                {
                    richTextBoxExistCodes.Text += strArr1[i].Trim() + "\n";
                }
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frm_ResourceCostTable"].BringToFront();
            this.Close();
        }

        private void frm_ExistBulkPTRCodesMessage_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                Application.OpenForms["frm_ResourceCostTable"].BringToFront();
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

        private void frm_ExistBulkPTRCodesMessage_Load(object sender, EventArgs e)
        {

        }
    }
}
