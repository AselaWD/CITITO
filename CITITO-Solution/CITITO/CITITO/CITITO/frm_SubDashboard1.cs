using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using ClosedXML.Excel;
using CITITO.BusinessObjects;
using CITITO.BusinessServices;
using CITITO.BusinessControls;
using System.Data.SqlClient;
using MetroFramework.Forms;
using LiveCharts.WinForms;
using LiveCharts;
using LiveCharts.Wpf;
using MetroFramework.Animation;

namespace CITITO
{
    public partial class frm_SubDashboard1 : MetroForm
    {
        int PH;
        int PHP;
        bool Hidden;
        bool PHPHidden;

        SqlConnection conn;

        //Start Pass insatance when form is already opend or not
        private static frm_SubDashboard1 _instance;
        public static frm_SubDashboard1 GetInstance(string uMUID, string uPIC)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                String mMUID = uMUID;
                String mPIC = uPIC;


                _instance = new frm_SubDashboard1(mMUID, mPIC);

            }
            return _instance;

        }

        public frm_SubDashboard1(string uMUID, string uPIC)
        {
            InitializeComponent();

            PH = pnlDetailLate5Min.Height;
            PHP = pnlDetailProductivity150.Height;
            Hidden = false;
            PHPHidden = false;


            //Global Variables
            conn = new SqlConnection(Properties.Settings.Default.CITITOConnectionString);
            
            conn.Open();
            
            lblUIDToFill.Text = uMUID;
            lblPICToFill.Text = uPIC;
            //lblPICToFill.Text = "ZDQ"; /*ZDQ, 16V, EC4, AV1, LR3, TL6, 36W, 23S*/

        }

        public void frm_SubDashboard1_Load(object sender, EventArgs e)
        {
            ClearFields();

            //Common Initialization
            string uPIC = lblPICToFill.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);
            ProjectDetailMng mProjectDetailMng = new ProjectDetailMng(this.conn);
            ManagerHeaderMng mManagerHeaderMng = new ManagerHeaderMng(this.conn);
            UserManagementDetailMng mUserManagementDetailMng = new UserManagementDetailMng(this.conn);
            UserManagementHeaderMng mUserManagementHeaderMng = new UserManagementHeaderMng(this.conn);

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            DateTime uFrom = startDate;
            DateTime uTo = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            //Summary For PIC
            FillPICTeams.Text = mManagerHeaderMng.PICTeamCount(uPIC).ToString(); /*Get Active Team Count*/
            fillPICOperators.Text = mUserManagementHeaderMng.PICOperatorCount(uPIC).ToString(); /*Get Active Operator Count*/
            fillPICDCDStaff.Text = mManagerHeaderMng.PICDCDCount(uPIC).ToString(); /*Get Active DCD Count*/
            fillPICProjects.Text = mProjectDetailMng.PICProjectCount(uPIC).ToString(); /*Get Project Count*/
            fillPICTaskAndQuota.Text = mProjectDetailMng.PICTaskAndQuotaCount(uPIC).ToString(); /*Get Task and Quota Count*/
            fillPICIDLEAndWastage.Text = mTaskRecordDetailMng.DboardIDLEkAndWastageCount(uPIC, uFrom, uTo).ToString();/*Get IDLE and Wastage Count*/

            //Exceed 5mins 
            pnlDetailLate5Min.Height = pnlDetailLate5Min.Height - pnlDetailLate5Min.Height;
            pnlProductivity150.Top = pnlDetailLate5Min.Height + tileLate5Min.Height;
            pnlDetailProductivity150.Top = pnlDetailLate5Min.Height + tileLate5Min.Height + pnlProductivity150.Height;
            tileLate5Min.Text = "Daily waste hours                                                             (Show)";
            timer1.Start();

            //Productivity 150%
            pnlDetailProductivity150.Height = pnlDetailProductivity150.Height - pnlDetailProductivity150.Height;
            tileProductivity150.Text = "Productivity above 150%                                                (Show)";            
            timer2.Start();

            //DataGridView
            dataGridViewProductivity150.DataSource = mTaskRecordDetailMng.GetUsersProductivityExceeded15ByPIC(uPIC, uFrom, uTo);
            
            dataGridViewProductivity150.Columns[0].Width = 20;
            

            //Dropdown
            cmbProject.DataSource = mProjectDetailMng.GetListOfProjectNamesByPIC(uPIC);
            cmbProject.SelectedIndex = -1;
            cmbMUID.DataSource = mManagerHeaderMng.GetActiveManagerUIDByPIC(uPIC);
            cmbMUID.SelectedIndex = -1;
            cmbUID.DataSource = mUserManagementDetailMng.ListActiveUIDByPIC(uPIC);
            cmbUID.SelectedIndex = -1;

            RefreshData();

        }

        private void tileLate5Min_Click(object sender, EventArgs e)
        {
            if (Hidden) tileLate5Min.Text = "Daily waste hours                                                            (Hide)";
            else tileLate5Min.Text = "Daily waste hours                                                             (Show)";
            timer1.Start();
        }

        private void tileProductivity150_Click(object sender, EventArgs e)
        {
            if (PHPHidden) tileProductivity150.Text = "Productivity above 150%                                                (Hide)";
            else tileProductivity150.Text = "Productivity above 150%                                                (Show)";
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hidden)
            {
                pnlDetailLate5Min.Height = pnlDetailLate5Min.Height + 20;

                if (pnlDetailLate5Min.Height>=PH)
                {
                    timer1.Stop();
                    Hidden = false;
                    this.Refresh();
                }
                pnlProductivity150.Top = pnlDetailLate5Min.Height + tileLate5Min.Height;
                pnlDetailProductivity150.Top = pnlDetailLate5Min.Height + tileLate5Min.Height+ pnlProductivity150.Height;


            }
            else
            {
                pnlDetailLate5Min.Height = pnlDetailLate5Min.Height - 20;
                if (pnlDetailLate5Min.Height <= 0)
                {
                    timer1.Stop();
                    Hidden = true;
                    this.Refresh();
                }
                pnlProductivity150.Top = pnlDetailLate5Min.Height + tileLate5Min.Height;
                pnlDetailProductivity150.Top = pnlDetailLate5Min.Height + tileLate5Min.Height + pnlProductivity150.Height;

            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (PHPHidden)
            {
                pnlDetailProductivity150.Height = pnlDetailProductivity150.Height + 20;

                if (pnlDetailProductivity150.Height >= PHP)
                {
                    timer2.Stop();
                    PHPHidden = false;
                    this.Refresh();
                }

            }
            else
            {
                pnlDetailProductivity150.Height = pnlDetailProductivity150.Height - 20;
                if (pnlDetailProductivity150.Height <= 0)
                {
                    timer2.Stop();
                    PHPHidden = true;
                    this.Refresh();
                }

            }
        }



        //Filter By Date
        private void metroDateTime1From_ValueChanged(object sender, EventArgs e)
        {
            ClearFields();
            RefreshData();

        }

        private void metroDateTime1To_ValueChanged(object sender, EventArgs e)
        {
            ClearFields();
            RefreshData();
        }

        //Refresh Object
        private void RefreshData()
        {
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Clear();

            cChartProjectWise.Series.Clear();
            cChartProjectWise.AxisY.Clear();
            cChartProjectWise.AxisX.Clear();

            cChartTeamWise.Series.Clear();
            cChartTeamWise.AxisY.Clear();
            cChartTeamWise.AxisX.Clear();

            cChartUserWise.Series.Clear();
            cChartUserWise.AxisY.Clear();
            cChartUserWise.AxisX.Clear();


            string uPIC = lblPICToFill.Text;
                TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

                //Update From Changed
                DateTime uFrom = metroDateTime1From.Value;
                DateTime uTo = metroDateTime1To.Value;

                //Charts

                //BarChart - Projectwise

                DataTable dtproject = mTaskRecordDetailMng.GetProjectProductivityByPIC(uPIC, uFrom, uTo);

                List<double> allValues = new List<double>();
                List<string> allLables = new List<string>();

                //Cast values and lables
                for (int i = 0; i < dtproject.Rows.Count; i++)
                {
                    allLables.Add(Convert.ToString(dtproject.Rows[i][0].ToString()));
                    allValues.Add(Convert.ToDouble(dtproject.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtproject.Rows.Count; i++)
                {
                cChartProjectWise.Series.Add(new ColumnSeries
                {
                    Title = Convert.ToString(dtproject.Rows[i][0].ToString()),
                    Values = new ChartValues<double> { Convert.ToDouble(dtproject.Rows[i][1].ToString()) },
                    DataLabels = false
                    


                });
                }

                //Lables
                cChartProjectWise.AxisX.Add(new Axis
                {
                   //Title = "PROJECT",
                    Labels = new List<string> { "PROJECT" }
                });



            //BarChart - Teamwise

            DataTable dtTeam = mTaskRecordDetailMng.GetTeamProductivityByPIC(uPIC, uFrom, uTo);

                List<double> allValuesTeam = new List<double>();
                List<string> allLablesTeam = new List<string>();

                //Cast values and lables
                for (int i = 0; i < dtTeam.Rows.Count; i++)
                {
                    allLablesTeam.Add(Convert.ToString(dtTeam.Rows[i][0].ToString()));
                    allValuesTeam.Add(Convert.ToDouble(dtTeam.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtTeam.Rows.Count; i++)
                {
                    cChartTeamWise.Series.Add(new ColumnSeries
                    {
                        Title = Convert.ToString(dtTeam.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dtTeam.Rows[i][1].ToString()) },
                        DataLabels = false

                    });
                }

            //Lables
            cChartTeamWise.AxisX.Add(new Axis
            {
                //Title = "TEAM",
                Labels = new List<string> { "TEAM" }
            });




            //BarChart - Userwise

            DataTable dtUser = mTaskRecordDetailMng.GetUserProductivityByPIC(uPIC, uFrom, uTo);


                List<double> allValuesUser = new List<double>();
                List<string> allLablesUser = new List<string>();

                //Cast values and lables
                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    allLablesUser.Add(Convert.ToString(dtUser.Rows[i][0].ToString()));
                    allValuesUser.Add(Convert.ToDouble(dtUser.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    cChartUserWise.Series.Add(new ColumnSeries
                    {
                        Title = Convert.ToString(dtUser.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dtUser.Rows[i][1].ToString()) },
                        DataLabels = false

                    });
                }

            //Lables
            cChartUserWise.AxisX.Add(new Axis
            {
                //Title = "USER",
                Labels = new List<string> { "USER" }
            });



            //PieChart     

            //CurrentCapacity
            //DataTable dttask = mTaskRecordDetailMng.GetTaskWiseProductivityByPIC(uPIC, uFrom, uTo);
            DataTable dttask = mTaskRecordDetailMng.CurrentCapacityPIC(uPIC);
                for (int i = 0; i < dttask.Rows.Count; i++)
                {
                    pieChart1.Series.Add(new PieSeries
                    {
                        Title = Convert.ToString(dttask.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dttask.Rows[i][1].ToString()) },
                        DataLabels = true,
                       
                    });
                }

            //WorkLoad
            DataTable wload = mTaskRecordDetailMng.WorkLoadPIC(uPIC);
                for (int i = 0; i < wload.Rows.Count; i++)
                {
                    pieChart2.Series.Add(new PieSeries
                    {
                        Title = Convert.ToString(wload.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(wload.Rows[i][1].ToString()) },
                        DataLabels = true,
                    });
                }

                //BarChart - Waste by Date
                DataTable dtWaste = mTaskRecordDetailMng.DboradWastageGraphDatewise(lblPICToFill.Text, uFrom, uTo);

                List<string> allLablesWaste = new List<string>();
                List<double> allMorningWaste = new List<double>();
                List<double> allShift = new List<double>();
                List<double> allAfternoonWaste = new List<double>();

                //Cast values and lables
                for (int i = 0; i < dtWaste.Rows.Count; i++)
                {
                    allLablesWaste.Add(Convert.ToString(DateTime.Parse((dtWaste.Rows[i][0]).ToString()).ToString("dd-MM-yyyy")));
                    allMorningWaste.Add(Convert.ToDouble(dtWaste.Rows[i][1].ToString()));
                    allShift.Add(Convert.ToDouble(dtWaste.Rows[i][2].ToString()));
                    allAfternoonWaste.Add(Convert.ToDouble(dtWaste.Rows[i][3].ToString()));
                }

                cartesianChart1.Series = new SeriesCollection
                    {
                        new StackedRowSeries
                        {
                            Title = Convert.ToString(dtWaste.Columns[1].ToString()),
                            Values = new ChartValues<double> (allMorningWaste),
                            StackMode = StackMode.Percentage,
                            DataLabels = false,
                            Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(243, 67, 54)),
                            LabelPoint = p => p.X.ToString()
                            

                        },
                        new StackedRowSeries
                        {
                            Title = Convert.ToString(dtWaste.Columns[2].ToString()),
                            Values = new ChartValues<double> (allShift),
                            StackMode = StackMode.Percentage,
                            DataLabels = false,                            
                            Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(33, 149, 242)),
                            LabelPoint = p => p.X.ToString()
                        }
                    };

                //adding series updates and animates the chart
                cartesianChart1.Series.Add(new StackedRowSeries
                {
                    Title = Convert.ToString(dtWaste.Columns[3].ToString()),
                    Values = new ChartValues<double>(allAfternoonWaste),
                    StackMode = StackMode.Percentage,
                    DataLabels = false,
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(223, 0, 68)),
                    LabelPoint = p => p.X.ToString()
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "WORK DATE",
                    Labels = new ChartValues<string>(allLablesWaste)
                    
                });
                cartesianChart1.AxisX.Add(new Axis
                {
                    LabelFormatter = val => val.ToString("P")
                });

                

            var tooltip = new DefaultTooltip { SelectionMode = TooltipSelectionMode.SharedYValues };

                


            //DataGridView
            dataGridViewProductivity150.DataSource = mTaskRecordDetailMng.GetUsersProductivityExceeded15ByPIC(uPIC, uFrom, uTo);
                
            dataGridViewProductivity150.Columns[0].Width = 50;
            
            

        }

        //Clear Object
        private void ClearFields()
        {
            pieChart1.Series.Clear();
            pieChart2.Series.Clear();
            cChartTeamWise.Series.Clear();
            cChartUserWise.Series.Clear();
            cChartProjectWise.Series.Clear();
            
            dataGridViewProductivity150.DataSource = null;
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();
            
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Clear();

            cChartProjectWise.Series.Clear();
            cChartProjectWise.AxisY.Clear();
            cChartProjectWise.AxisX.Clear();

            cChartTeamWise.Series.Clear();
            cChartTeamWise.AxisY.Clear();
            cChartTeamWise.AxisX.Clear();

            cChartUserWise.Series.Clear();
            cChartUserWise.AxisY.Clear();
            cChartUserWise.AxisX.Clear();


            string uPIC = lblPICToFill.Text;
            string uProject = cmbProject.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            if (!String.IsNullOrEmpty(uProject))
            {

                DateTime uFrom = metroDateTime1From.Value;
                DateTime uTo = metroDateTime1To.Value;

                //Charts

                //BarChart - Projectwise

                DataTable dtproject = mTaskRecordDetailMng.GetProjectProductivityByPICAndProject(uPIC, uFrom, uTo, uProject);

                List<double> allValues = new List<double>();
                List<string> allLables = new List<string>();


                //Cast values and lables
                for (int i = 0; i < dtproject.Rows.Count; i++)
                {
                    allLables.Add(Convert.ToString(dtproject.Rows[i][0].ToString()));
                    allValues.Add(Convert.ToDouble(dtproject.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtproject.Rows.Count; i++)
                {
                    cChartProjectWise.Series.Add(new ColumnSeries
                    {
                        Title = Convert.ToString(dtproject.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dtproject.Rows[i][1].ToString()) },
                        DataLabels = false,

                    });
                }

                //Lables
                cChartProjectWise.AxisX.Add(new Axis
                {
                    //Title = "PROJECT",
                    Labels = new List<string> { "PROJECT" }
                });


                //BarChart - Teamwise

                DataTable dtTeam = mTaskRecordDetailMng.GetTeamProductivityByPICAndProject(uPIC, uFrom, uTo, uProject);

                List<double> allValuesTeam = new List<double>();
                List<string> allLablesTeam = new List<string>();


                //Cast values and lables
                for (int i = 0; i < dtTeam.Rows.Count; i++)
                {
                    allLablesTeam.Add(Convert.ToString(dtTeam.Rows[i][0].ToString()));
                    allValuesTeam.Add(Convert.ToDouble(dtTeam.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtTeam.Rows.Count; i++)
                {
                    cChartTeamWise.Series.Add(new ColumnSeries
                    {
                        Title = Convert.ToString(dtTeam.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dtTeam.Rows[i][1].ToString()) },
                        DataLabels = false,

                    });
                }

                //Lables
                cChartTeamWise.AxisX.Add(new Axis
                {
                    //Title = "TEAM",
                    Labels = new List<string> { "TEAM" }
                });

                //BarChart - Userwise

                DataTable dtUser = mTaskRecordDetailMng.GetUserProductivityByPICAndProject(uPIC, uFrom, uTo, uProject);

                List<double> allValuesUser = new List<double>();
                List<string> allLablesUser = new List<string>();

                //Cast values and lables
                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    allLablesUser.Add(Convert.ToString(dtUser.Rows[i][0].ToString()));
                    allValuesUser.Add(Convert.ToDouble(dtUser.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    cChartUserWise.Series.Add(new ColumnSeries
                    {
                        Title = Convert.ToString(dtUser.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dtUser.Rows[i][1].ToString()) },
                        DataLabels = false,

                    });
                }

                //Lables
                cChartUserWise.AxisX.Add(new Axis
                {
                    //Title = "USER",
                    Labels = new List<string> { "USER" }
                });


                //PieChart            
                DataTable dttask = mTaskRecordDetailMng.CurrentCapacityPIC(uPIC);
                //DataTable dttask = mTaskRecordDetailMng.GetTaskWiseProductivityByPICAndProject(uPIC, uFrom, uTo, uProject);

                for (int i = 0; i < dttask.Rows.Count; i++)
                {
                    pieChart1.Series.Add(new PieSeries
                    {
                        Title = Convert.ToString(dttask.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dttask.Rows[i][1].ToString()) },
                        DataLabels = true,
                    });
                }

                pieChart1.LegendLocation = LegendLocation.Bottom;

                //WorkLoad
                DataTable wload = mTaskRecordDetailMng.WorkLoadPIC(uPIC);
                for (int i = 0; i < wload.Rows.Count; i++)
                {
                    pieChart2.Series.Add(new PieSeries
                    {
                        Title = Convert.ToString(wload.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(wload.Rows[i][1].ToString()) },
                        DataLabels = true,
                    });
                }

                pieChart2.LegendLocation = LegendLocation.Bottom;

                
                //BarChart - Waste by Date
                DataTable dtWaste = mTaskRecordDetailMng.DboradWastageGraphDatewise(lblPICToFill.Text, uFrom, uTo);

                List<string> allLablesWaste = new List<string>();
                List<double> allMorningWaste = new List<double>();
                List<double> allShift = new List<double>();
                List<double> allAfternoonWaste = new List<double>();

                //Cast values and lables
                for (int i = 0; i < dtWaste.Rows.Count; i++)
                {
                    allLablesWaste.Add(Convert.ToString(DateTime.Parse((dtWaste.Rows[i][0]).ToString()).ToString("dd-MM-yyyy")));
                    allMorningWaste.Add(Convert.ToDouble(dtWaste.Rows[i][1].ToString()));
                    allShift.Add(Convert.ToDouble(dtWaste.Rows[i][2].ToString()));
                    allAfternoonWaste.Add(Convert.ToDouble(dtWaste.Rows[i][3].ToString()));
                }
                

                //DataGridView
                dataGridViewProductivity150.DataSource = mTaskRecordDetailMng.GetUsersProductivityExceeded15ByPICAndProject(uPIC, uFrom, uTo, uProject);
                dataGridViewProductivity150.Columns[0].Width = 50;
                
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            
            cmbProject.SelectedIndex = -1;
            cmbMUID.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;

            ////Header Panel
            //DateTime now = DateTime.Now;
            //var startDate = new DateTime(now.Year, now.Month, 1);
            //var endDate = startDate.AddMonths(1).AddDays(-1);

            //metroDateTime1From.Value = startDate;
            //metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }

        private void cmbMUID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Clear();

            cChartProjectWise.Series.Clear();
            cChartProjectWise.AxisY.Clear();
            cChartProjectWise.AxisX.Clear();

            cChartTeamWise.Series.Clear();
            cChartTeamWise.AxisY.Clear();
            cChartTeamWise.AxisX.Clear();

            cChartUserWise.Series.Clear();
            cChartUserWise.AxisY.Clear();
            cChartUserWise.AxisX.Clear();

            string uPIC = lblPICToFill.Text;
            string uMID = cmbMUID.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            if (!String.IsNullOrEmpty(uMID))
            {

                DateTime uFrom = metroDateTime1From.Value;
                DateTime uTo = metroDateTime1To.Value;

                //Charts

                //BarChart - Projectwise

                DataTable dtproject = mTaskRecordDetailMng.GetProjectProductivityByPICAndManager(uPIC, uFrom, uTo, uMID);

                List<double> allValues = new List<double>();
                List<string> allLables = new List<string>();

                Func<ChartPoint, string> labelPoint = chartPoint =>
                    string.Format("{0}%", chartPoint.Y, chartPoint.Participation);

                //Cast values and lables
                for (int i = 0; i < dtproject.Rows.Count; i++)
                {
                    allLables.Add(Convert.ToString(dtproject.Rows[i][0].ToString()));
                    allValues.Add(Convert.ToDouble(dtproject.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtproject.Rows.Count; i++)
                {
                    cChartProjectWise.Series.Add(new ColumnSeries
                    {
                        Title = Convert.ToString(dtproject.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dtproject.Rows[i][1].ToString()) },
                        DataLabels = false,

                    });
                }

                //Lables
                cChartProjectWise.AxisX.Add(new Axis
                {
                    //Title = "PROJECT",
                    Labels = new List<string> { "PROJECT" }
                });


                //BarChart - Teamwise

                DataTable dtTeam = mTaskRecordDetailMng.GetTeamProductivityByPICAndManager(uPIC, uFrom, uTo, uMID);

                List<double> allValuesTeam = new List<double>();
                List<string> allLablesTeam = new List<string>();

                Func<ChartPoint, string> labelPointTeam = chartPointTeam =>
                    string.Format("{0}%", chartPointTeam.Y, chartPointTeam.Participation);

                //Cast values and lables
                for (int i = 0; i < dtTeam.Rows.Count; i++)
                {
                    allLablesTeam.Add(Convert.ToString(dtTeam.Rows[i][0].ToString()));
                    allValuesTeam.Add(Convert.ToDouble(dtTeam.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtTeam.Rows.Count; i++)
                {
                    cChartTeamWise.Series.Add(new ColumnSeries
                    {
                        Title = Convert.ToString(dtTeam.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dtTeam.Rows[i][1].ToString()) },
                        DataLabels = false,

                    });
                }

                //Lables
                cChartTeamWise.AxisX.Add(new Axis
                {
                    //Title = "TEAM",
                    Labels = new List<string> { "TEAM" }
                });

                //BarChart - Userwise

                DataTable dtUser = mTaskRecordDetailMng.GetUserProductivityByPICAndManager(uPIC, uFrom, uTo, uMID);

                List<double> allValuesUser = new List<double>();
                List<string> allLablesUser = new List<string>();

                Func<ChartPoint, string> labelPointUser = chartPointUser =>
                    string.Format("{0}%", chartPointUser.Y, chartPointUser.Participation);

                //Cast values and lables
                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    allLablesUser.Add(Convert.ToString(dtUser.Rows[i][0].ToString()));
                    allValuesUser.Add(Convert.ToDouble(dtUser.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    cChartUserWise.Series.Add(new ColumnSeries
                    {
                        Title = Convert.ToString(dtUser.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dtUser.Rows[i][1].ToString()) },
                        DataLabels = false,

                    });
                }

                //Lables
                cChartUserWise.AxisX.Add(new Axis
                {
                    //Title = "USER",
                    Labels = new List<string> { "USER" }
                });


                //PieChart            
                DataTable dttask = mTaskRecordDetailMng.CurrentCapacityPIC(uPIC);
                //DataTable dttask = mTaskRecordDetailMng.GetTaskWiseProductivityByPICAndManager(uPIC, uFrom, uTo, uMID);

                for (int i = 0; i < dttask.Rows.Count; i++)
                {
                    pieChart1.Series.Add(new PieSeries
                    {
                        Title = Convert.ToString(dttask.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dttask.Rows[i][1].ToString()) },
                        DataLabels = true,
                    });
                }


                pieChart1.LegendLocation = LegendLocation.Bottom;

                //WorkLoad
                DataTable wload = mTaskRecordDetailMng.WorkLoadPIC(uPIC);
                for (int i = 0; i < wload.Rows.Count; i++)
                {
                    pieChart2.Series.Add(new PieSeries
                    {
                        Title = Convert.ToString(wload.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(wload.Rows[i][1].ToString()) },
                        DataLabels = true,
                    });
                }

                pieChart2.LegendLocation = LegendLocation.Bottom;

                //DataGridView
                dataGridViewProductivity150.DataSource = mTaskRecordDetailMng.GetUsersProductivityExceeded15ByPICAndManager(uPIC, uFrom, uTo, uMID);
                
                dataGridViewProductivity150.Columns[0].Width = 50;
                
            }
        }

        private void cmbUID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Clear();

            cChartProjectWise.Series.Clear();
            cChartProjectWise.AxisY.Clear();
            cChartProjectWise.AxisX.Clear();

            cChartTeamWise.Series.Clear();
            cChartTeamWise.AxisY.Clear();
            cChartTeamWise.AxisX.Clear();

            cChartUserWise.Series.Clear();
            cChartUserWise.AxisY.Clear();
            cChartUserWise.AxisX.Clear();

            string uPIC = lblPICToFill.Text;
            string uUID = cmbUID.Text;
            TaskRecordDetailMng mTaskRecordDetailMng = new TaskRecordDetailMng(this.conn);

            if (!String.IsNullOrEmpty(uUID))
            {
                
                DateTime uFrom = metroDateTime1From.Value;
                DateTime uTo = metroDateTime1To.Value;

                //Charts

                //BarChart - Projectwise

                DataTable dtuser = mTaskRecordDetailMng.GetProjectProductivityByPICAndUID(uPIC, uFrom, uTo, uUID);

                List<double> allValues = new List<double>();
                List<string> allLables = new List<string>();

                Func<ChartPoint, string> labelPoint = chartPoint =>
                    string.Format("{0}%", chartPoint.Y, chartPoint.Participation);

                //Cast values and lables
                for (int i = 0; i < dtuser.Rows.Count; i++)
                {
                    allLables.Add(Convert.ToString(dtuser.Rows[i][0].ToString()));
                    allValues.Add(Convert.ToDouble(dtuser.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtuser.Rows.Count; i++)
                {
                    cChartProjectWise.Series.Add(new ColumnSeries
                    {
                        Title = Convert.ToString(dtuser.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dtuser.Rows[i][1].ToString()) },
                        DataLabels = false,

                    });
                }

                //Lables
                cChartProjectWise.AxisX.Add(new Axis
                {
                    //Title = "PROJECT",
                    Labels = new List<string> { "PROJECT" }
                });


                //BarChart - Teamwise

                DataTable dtTeam = mTaskRecordDetailMng.GetTeamProductivityByPICAndUID(uPIC, uFrom, uTo, uUID);

                List<double> allValuesTeam = new List<double>();
                List<string> allLablesTeam = new List<string>();

                Func<ChartPoint, string> labelPointTeam = chartPointTeam =>
                    string.Format("{0}%", chartPointTeam.Y, chartPointTeam.Participation);

                //Cast values and lables
                for (int i = 0; i < dtTeam.Rows.Count; i++)
                {
                    allLablesTeam.Add(Convert.ToString(dtTeam.Rows[i][0].ToString()));
                    allValuesTeam.Add(Convert.ToDouble(dtTeam.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtTeam.Rows.Count; i++)
                {
                    cChartTeamWise.Series.Add(new ColumnSeries
                    {
                        Title = Convert.ToString(dtTeam.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dtTeam.Rows[i][1].ToString()) },
                        DataLabels = false,

                    });
                }

                //Lables
                cChartTeamWise.AxisX.Add(new Axis
                {
                    //Title = "TEAM",
                    Labels = new List<string> { "TEAM" }
                });


                //BarChart - Userwise

                DataTable dtUser = mTaskRecordDetailMng.GetUserProductivityByPICAndUID(uPIC, uFrom, uTo, uUID);

                List<double> allValuesUser = new List<double>();
                List<string> allLablesUser = new List<string>();

                Func<ChartPoint, string> labelPointUser = chartPointUser =>
                    string.Format("{0}%", chartPointUser.Y, chartPointUser.Participation);

                //Cast values and lables
                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    allLablesUser.Add(Convert.ToString(dtUser.Rows[i][0].ToString()));
                    allValuesUser.Add(Convert.ToDouble(dtUser.Rows[i][1].ToString()));
                }


                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    cChartUserWise.Series.Add(new ColumnSeries
                    {
                        Title = Convert.ToString(dtUser.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dtUser.Rows[i][1].ToString()) },
                        DataLabels = false,

                    });
                }

                //Lables
                cChartUserWise.AxisX.Add(new Axis
                {
                    //Title = "USER",
                    Labels = new List<string> { "USER" }
                });



                //PieChart            
                DataTable dttask = mTaskRecordDetailMng.CurrentCapacityPIC(uPIC);
                //DataTable dttask = mTaskRecordDetailMng.GetTaskWiseProductivityByPICAndUID(uPIC, uFrom, uTo, uUID);

                for (int i = 0; i < dttask.Rows.Count; i++)
                {
                    pieChart1.Series.Add(new PieSeries
                    {
                        Title = Convert.ToString(dttask.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(dttask.Rows[i][1].ToString()) },
                        DataLabels = true,
                    });
                }


                pieChart1.LegendLocation = LegendLocation.Bottom;

                //WorkLoad
                DataTable wload = mTaskRecordDetailMng.WorkLoadPIC(uPIC);
                for (int i = 0; i < wload.Rows.Count; i++)
                {
                    pieChart2.Series.Add(new PieSeries
                    {
                        Title = Convert.ToString(wload.Rows[i][0].ToString()),
                        Values = new ChartValues<double> { Convert.ToDouble(wload.Rows[i][1].ToString()) },
                        DataLabels = true,
                    });
                }

                pieChart2.LegendLocation = LegendLocation.Bottom;

                //DataGridView
                dataGridViewProductivity150.DataSource = mTaskRecordDetailMng.GetUsersProductivityExceeded15ByPICAndUID(uPIC, uFrom, uTo, uUID);
                

                dataGridViewProductivity150.Columns[0].Width = 50;
                
            }
        }

        private void fillPICTaskAndQuota_Click(object sender, EventArgs e)
        {

            //Load Modified records
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboard_TaskAndQuota myForm = frm_SubDashboard_TaskAndQuota.GetInstance(uPIC, uMUID);
            frm_MainReportDashboard myForm1 = frm_MainReportDashboard.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_MainReportDashboard form1 = (frm_MainReportDashboard)Application.OpenForms["frm_MainReportDashboard"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();

            //Call public methods of frm_ApprovalTaskInOut form to hover
            myForm1.panelHover.Height = myForm1.tileTaskwise.Height;
            myForm1.panelHover.Top = myForm1.tileTaskwise.Top + myForm1.line.Top + 3;
        }

        //Go button Date Time
        private void btnGo_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshData();
        }

        //IDLE and Wastage Click
        private void fillPICIDLEAndWastage_Click(object sender, EventArgs e)
        {
            //Load Modified records
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboardWastage myForm = frm_SubDashboardWastage.GetInstance(uMUID, uPIC);
            frm_MainReportDashboard myForm1 = frm_MainReportDashboard.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_MainReportDashboard form1 = (frm_MainReportDashboard)Application.OpenForms["frm_MainReportDashboard"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();

            //Call public methods of frm_ApprovalTaskInOut form to hover
            myForm1.panelHover.Height = myForm1.tileIDLEAndwastage.Height;
            myForm1.panelHover.Top = myForm1.tileIDLEAndwastage.Top;
        }

        //Team Click
        private void FillPICTeams_Click(object sender, EventArgs e)
        {

            //Load Modified records
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboardTeamDetails myForm = frm_SubDashboardTeamDetails.GetInstance(uPIC, uMUID);
            frm_MainReportDashboard myForm1 = frm_MainReportDashboard.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_MainReportDashboard form1 = (frm_MainReportDashboard)Application.OpenForms["frm_MainReportDashboard"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();

            //Call public methods of frm_ApprovalTaskInOut form to hover
            myForm1.panelHover.Height = myForm1.metroTile1.Height;
            myForm1.panelHover.Top = myForm1.metroTile1.Top + myForm1.line.Top + 3;
        }

        //Team Graph Click
        private void cChartTeamWise_DataClick(object sender, ChartPoint chartPoint)
        {
            //Load Modified records
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboardX3ByTeam myForm = frm_SubDashboardX3ByTeam.GetInstance(uPIC, uMUID);
            frm_MainReportDashboard myForm1 = frm_MainReportDashboard.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_MainReportDashboard form1 = (frm_MainReportDashboard)Application.OpenForms["frm_MainReportDashboard"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();

            //Call public methods of frm_ApprovalTaskInOut form to hover
            myForm1.panelHover.Height = myForm1.tileX3Team.Height;
            myForm1.panelHover.Top = myForm1.tileX3Team.Top + myForm1.line.Top + 3;
        }

        //Project Data Clicked
        private void cChartProjectWise_DataClick(object sender, ChartPoint chartPoint)
        {
            //Load Modified records
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboardX3ByProject myForm = frm_SubDashboardX3ByProject.GetInstance(uPIC, uMUID);
            frm_MainReportDashboard myForm1 = frm_MainReportDashboard.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_MainReportDashboard form1 = (frm_MainReportDashboard)Application.OpenForms["frm_MainReportDashboard"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();

            //Call public methods of frm_ApprovalTaskInOut form to hover
            myForm1.panelHover.Height = myForm1.tileX3Project.Height;
            myForm1.panelHover.Top = myForm1.tileX3Project.Top + myForm1.line.Top + 3;
        }

        //User Graph Click
        private void cChartUserWise_DataClick(object sender, ChartPoint chartPoint)
        {
            //Load Modified records
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboardX3Performance myForm = frm_SubDashboardX3Performance.GetInstance(uPIC, uMUID);
            frm_MainReportDashboard myForm1 = frm_MainReportDashboard.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_MainReportDashboard form1 = (frm_MainReportDashboard)Application.OpenForms["frm_MainReportDashboard"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();

            //Call public methods of frm_ApprovalTaskInOut form to hover
            myForm1.panelHover.Height = myForm1.tileX3User.Height;
            myForm1.panelHover.Top = myForm1.tileX3User.Top + myForm1.line.Top + 3;
        }

   
        //Current Capacity Cliked
        private void pieChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            //Load Modified records
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboardTeamDetails myForm = frm_SubDashboardTeamDetails.GetInstance(uPIC, uMUID);
            frm_MainReportDashboard myForm1 = frm_MainReportDashboard.GetInstance(uPIC, uMUID);

            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_MainReportDashboard form1 = (frm_MainReportDashboard)Application.OpenForms["frm_MainReportDashboard"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();

            //Call public methods of frm_ApprovalTaskInOut form to hover
            myForm1.panelHover.Height = myForm1.metroTile1.Height;
            myForm1.panelHover.Top = myForm1.metroTile1.Top + myForm1.line.Top + 3;
        }

        //Work Load Cliked
        private void pieChart2_DataClick(object sender, ChartPoint chartPoint)
        {
            //Load Modified records
            String uPIC = lblPICToFill.Text;
            String uMUID = lblUIDToFill.Text;

            frm_SubDashboardWorkLoad_Summary myForm = frm_SubDashboardWorkLoad_Summary.GetInstance(uPIC, uMUID);
            frm_MainReportDashboard myForm1 = frm_MainReportDashboard.GetInstance(uPIC, uMUID);

            //Close Detailed Workload Window
            
            myForm.TopLevel = false;
            myForm.TopMost = true;
            myForm.AutoScroll = false;
            myForm.Dock = DockStyle.Fill;
            frm_MainReportDashboard form1 = (frm_MainReportDashboard)Application.OpenForms["frm_MainReportDashboard"];
            Panel panel1 = (Panel)form1.Controls["panelLoadUserTasks"];
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.BringToFront();

            //Call public methods of frm_ApprovalTaskInOut form to hover
            myForm1.panelHover.Height = myForm1.tileWorkLoad.Height;
            myForm1.panelHover.Top = myForm1.tileWorkLoad.Top + myForm1.line.Top + 3;
        }


        //Export Excel
        private void pBoxExportExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridViewProductivity150.Columns)
            {
                dt.Columns.Add(column.HeaderText);
                //dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridViewProductivity150.Rows)
            {
                dt.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    try
                    {
                        if (i == 2)
                        {
                            dt.Rows[dt.Rows.Count - 1][2] = double.Parse(row.Cells[2].Value.ToString()).ToString("0.###") + "%";
                        }
                        else
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Value.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        if (ex.HResult == -2147024809)
                        {
                            //cell.Value = DateTime.ParseExact(cell.Value.ToString(), "dd MM yyyy hh:mm:ss tt", null);
                        }

                    }


                }

            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.Title = "Export Excel Files";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = false;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "All files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;

                try
                {
                    //Exporting to Excel           

                    if (!System.IO.File.Exists(fileName))
                    {
                        using (System.IO.FileStream fs = System.IO.File.Create(fileName))
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "CITITO_" + lblPICToFill.Text + "_Productivity > 150%");
                                wb.SaveAs(fs);

                                MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to \"" + fileName + "\".", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                    else
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "CITITO_" + lblPICToFill.Text + "_Productivity > 150%");
                            wb.SaveAs(fileName);

                            MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nRecords successfully export to \"" + fileName + "\" path.", "Records Export!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2147024864)
                    {
                        MetroFramework.MetroMessageBox.Show(MetroForm.ActiveForm, "\nFile is already opened in another programme.", "Application Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Message: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void dataGridViewProductivity150_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Round Up
            if (e.ColumnIndex == 2)
            {
                if (String.IsNullOrEmpty(e.Value.ToString()))
                {

                }
                else
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.###") + "%";
                }

            }
        }

        private void cmbProject_MouseClick(object sender, MouseEventArgs e)
        {
            cmbMUID.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;
        }

        private void cmbMUID_MouseClick(object sender, MouseEventArgs e)
        {
            cmbProject.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;
        }

        private void cmbUID_MouseClick(object sender, MouseEventArgs e)
        {
            cmbProject.SelectedIndex = -1;
            cmbMUID.SelectedIndex = -1;
        }

        private void btnClrAll_Click(object sender, EventArgs e)
        {
            ClearFields();

            cmbProject.SelectedIndex = -1;
            cmbMUID.SelectedIndex = -1;
            cmbUID.SelectedIndex = -1;

            //Header Panel
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            metroDateTime1From.Value = startDate;
            metroDateTime1To.Value = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            RefreshData();
        }
    }
}
