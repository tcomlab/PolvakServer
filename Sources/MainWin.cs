using System;
using System.Threading;
using System.Windows.Forms;

namespace PolvakServer.Sources
{
    public partial class Form1 : Form
    {
        private readonly Controller _control = new Controller();
        private readonly DataChart _dChart = new DataChart();
        private readonly ServerDataProvider _dprovider = new ServerDataProvider();

        private int _currentCintrol;
        private int CurrentCintrol
        {
            set
            {
                _currentCintrol = value;
                new Thread(ShowDataChart) { IsBackground = true }.Start();
            }
        }

        public Form1()
        {
            InitializeComponent();            //      Tap/Pap/UR/rVE/Rnz/Ppar
            _control.Avtokl[0] = new Avtoklav(new []{ 16, 20, 30, 18, 17, 19}); // CE4
            _control.Avtokl[1] = new Avtoklav(new[] { 24, 999, 28, 26, 25, 27 }); // BE16000
            _control.Avtokl[2] = new Avtoklav(new[] { 8, 13, 12, 10, 9, 11 }); // BE16001
            _control.Avtokl[3] = new Avtoklav(new[] { 0, 30, 999, 2, 1, 3 }); // CE25
            _control.Avtokl[4] = new Avtoklav(new[] { 22, 999, 999, 21, 23, 999 }); // CE3
            var db = new Database(_control.Avtokl);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
#if !DEBUG
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
#endif

            try
            {
                chartControl1.Series[0].ArgumentDataMember = "DT";
                chartControl1.Series[0].ValueDataMembers.AddRange("t_aparat");

                chartControl1.Series[1].ArgumentDataMember = "DT";
                chartControl1.Series[1].ValueDataMembers.AddRange("dav_aparat");

                chartControl1.Series[2].ArgumentDataMember = "DT";
                chartControl1.Series[2].ValueDataMembers.AddRange("t_pod_para");

                chartControl1.Series[3].ArgumentDataMember = "DT";
                chartControl1.Series[3].ValueDataMembers.AddRange("t_rub_verh");

                chartControl1.Series[4].ArgumentDataMember = "DT";
                chartControl1.Series[4].ValueDataMembers.AddRange("t_rub_niz");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowDataChart()
        {
            try
            {
                if (_currentCintrol > 4)
                {
                    this.Invoke((MethodInvoker)delegate() { chartControl1.Visible = false; });
                    return;
                }
                this.Invoke((MethodInvoker)delegate() { chartControl1.Visible = true; });
                this.Invoke((MethodInvoker)delegate() { progressPanel1.Visible = true; });
                try
                {
                    chartControl1.DataSource = _dChart.GetData(_currentCintrol).Tables[0];
                }
                catch { }
                Invoke((MethodInvoker)delegate() { progressPanel1.Visible = false; });
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lDate.Text = String.Format("{0:00}-{1:00}-{2:00}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            lTime.Text = String.Format("{0:00}:{1:00}:{2:00}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            l_greb_par.Text = String.Format("{0:0.00} Bar", Controller.Sensor[7].result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentCintrol = 0;
            mainVisual.Controls.Clear();
            mainVisual.Controls.Add(_control.Avtokl[0].AvtoklavControl);
            label1.Text = "CE4";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainVisual.Controls.Clear();
            mainVisual.Controls.Add(_control.Avtokl[1].AvtoklavControl);
            label1.Text = "BE16000";
            CurrentCintrol = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainVisual.Controls.Clear();
            mainVisual.Controls.Add(_control.Avtokl[2].AvtoklavControl);
            label1.Text = "BE16001";
            CurrentCintrol = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainVisual.Controls.Clear();
            mainVisual.Controls.Add(_control.Avtokl[3].AvtoklavControl);
            label1.Text = "CE25-1";
            CurrentCintrol = 3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // CE 3
            mainVisual.Controls.Clear();
            mainVisual.Controls.Add(_control.Avtokl[4].AvtoklavControl);
            label1.Text = "CE3";
            CurrentCintrol = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Градирня ГМВ-60
            var sens = new Owen.Sensors[6];
            sens[0] = Controller.Sensor[128];
            sens[1] = Controller.Sensor[129];
            mainVisual.Controls.Clear();
            mainVisual.Controls.Add(new UControls.UСGrad(
                sens,
                new string[] { "to_gradirnya", "ot_gradirnya", "", "", "", "" },
                new string[] { "на градирню", "от градирни", "", "", "", "" },0
                ));
            label1.Text = "Градирня ГМВ-60";
            CurrentCintrol = 5;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Градирня ГМВ-20
            var sens = new Owen.Sensors[6];
            sens[0] = Controller.Sensor[130];
            sens[1] = Controller.Sensor[131];
            sens[2] = Controller.Sensor[132];
            sens[3] = Controller.Sensor[133];
            sens[4] = Controller.Sensor[134];
            sens[5] = Controller.Sensor[135];
            mainVisual.Controls.Clear();
            mainVisual.Controls.Add(new UControls.UСGrad(
                sens,
                new[] { "to_gradirnya","t_ot_avtoklava", "ot_gradirnya", "tank6", "tank7", "tank8"},
                new[] { "на градирню","от автоклава", "от градирни", "емкость №6", "емкость №7", "емкость №8"},1));
            label1.Text = "Градирня ГМВ-20";
            CurrentCintrol = 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // П68
            mainVisual.Controls.Clear();
            mainVisual.Controls.Add(new UControls.UCP68());
            label1.Text = "П68";
            CurrentCintrol = 6;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            new Thread(ShowDataChart) { IsBackground = true }.Start();
        }

    }

}
