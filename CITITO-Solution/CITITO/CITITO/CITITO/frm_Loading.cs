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
    public partial class frm_Loading : MetroForm
    {
        public Action Worker { get; set; }

        public frm_Loading(Action worker)
        {
            InitializeComponent();

            if (worker == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                Worker = worker;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
