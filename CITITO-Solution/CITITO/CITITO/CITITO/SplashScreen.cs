using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CITITO.BusinessObjects;
using CITITO.BusinessControls;
using CITITO.BusinessServices;
using System.Data.SqlClient;
using System.Security.Cryptography;
using MetroFramework.Forms;

namespace CITITO
{
    public partial class SplashScreen : Form
    {
        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static SplashScreen _instance;
        public static SplashScreen GetInstance()
        {
            
            if (_instance == null || _instance.IsDisposed)
            {

                _instance = new SplashScreen();

            }
            return _instance;

        }
        //End Pass insatance when form is already opend or not

        public SplashScreen()
        {
            
            InitializeComponent();

            string version = System.Windows.Forms.Application.ProductVersion;
            metroLabel2.Text = String.Format("Version {0}", version);

            try
            {
                //Global Variables
                conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
                conn.Open();

            }
            catch (Exception ex)
            {
                if(ex.HResult == -2146232060)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is an issue on database connection. Please contact your Technical Assistant.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "Message: "+ ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }


            //Tasks
            //Starting
            lblLoading.Text = "Loading...";

                splashtime.Enabled = true;

                //Set time interval 3 sec
                splashtime.Interval = 3000;

                //Starts the timer
                splashtime.Start();
                splashtime.Tick += splashtime_Tick;

            

        }
 
        private void refresh()
        {
            try
            {
                string tempPath = Path.GetTempPath();
                base.Hide();
                Bitmap bitmap = new Bitmap(base.Width, base.Height, PixelFormat.Format64bppArgb);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(base.Location.X, base.Location.Y, 0, 0, base.Size, CopyPixelOperation.SourceCopy);
                bitmap.Save(tempPath+ "/spls.bin", ImageFormat.Png);
                this.BackgroundImage = bitmap;
                base.Show();
            }
            catch (Exception)
            {

            }
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {
           

        }
        

        public void frmNewFormThread()
        {
            try
            {
                string mVersion = new CITITOVersionMng(this.conn).GetCITITOCurrentVersion();
                            if (metroLabel2.Text != mVersion)
                            {
                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nPlease update your application with latest version.\nLatest version is " + mVersion, "Version Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                            }

                            frm_Login form = frm_Login.GetInstance();

                            if (!form.Visible)
                            {
                                this.Hide();
                                form.Show();


                            }
                            else
                            {
                                this.Hide();
                                form.BringToFront();

                            }

            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232060)
                {
                    MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nThere is an issue on database connection. Please contact your Technical Assistant.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            
        }

        private void splashtime_Tick(object sender, EventArgs e)
        {
            //After 4 sec stop the timer
            splashtime.Stop();
            frmNewFormThread();


        }

        private void SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ProgressSpinner1_Click(object sender, EventArgs e)
        {

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void SplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
