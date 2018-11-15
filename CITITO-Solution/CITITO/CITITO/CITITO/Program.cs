using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CITITO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
           // Application.Run(new frm_tempForm());
            //Application.Run(new frm_Login());
            //Application.Run(new frm_MainForm_PIC());
            //Application.Run(new frm_PICRegisterPanel());
            //Application.Run(new frm_ProjectRegisterPanel());
            //Application.Run(new frm_AssignPICToProject());
            //Application.Run(new frm_TaskCodeRegister());
            //Application.Run(new frm_DoneByteSizeFile("1000","01","01","011",1,10,DateTime.Now,2,200,"7AO", "7AO", "ZDQ"));
        }
    }
}
