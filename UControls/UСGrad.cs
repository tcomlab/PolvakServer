using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Owen;

namespace PolvakServer.UControls
{
    public partial class UСGrad : UserControl
    {
        private readonly Timer _timer = new Timer() { Interval = 1000 };
        private readonly Timer _timerChart = new Timer() { Interval = 10000 };
        private readonly Sensors[] _tmpSensors = new Sensors[8];
        private readonly Sources.DataChart _dChart = new Sources.DataChart();
        private string[] _listChart;
        private string[] _listChartName;
        private int _id;

        public UСGrad()
        {
            InitializeComponent();
            _timer.Tick += timer_Tick;
            _timerChart.Tick += timer_chart_Tick;
            _timer.Enabled = true;
            _timerChart.Enabled = true;
        }

        void timer_chart_Tick(object sender, EventArgs e)
        {
            new System.Threading.Thread(refresh_chart) { IsBackground =true}.Start();
        }

        public UСGrad(Sensors[] tmpSensors, string[] chartlist, string[] listChartName,int id)
        {
            _listChart = chartlist;
            _listChartName = listChartName;
            this._tmpSensors = tmpSensors;
            InitializeComponent();
            _timer.Tick += timer_Tick;
            _timerChart.Tick += timer_chart_Tick;
            _timer.Enabled = true;
            _timerChart.Enabled = true;
            _id = id;
        }

        public void refresh_chart()
        {
            try
            {
                Invoke((MethodInvoker)delegate() { chartControl1.Visible = true; });
                Invoke((MethodInvoker)delegate() { progressPanel1.Visible = true; });
                try
                {
                    chartControl1.DataSource = _dChart.GetDataGradignya(_id).Tables[0];
                }
                catch { }
                Invoke((MethodInvoker)delegate() { progressPanel1.Visible = false; });
            }
            catch { }         
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (_tmpSensors == null) return;

            if (_tmpSensors[0] != null)
            {
                if (_tmpSensors[0].sensor_state == Sensors.sensor_s.sensor_ok)
                    t1.Text = String.Format("{0:0.00} C*", _tmpSensors[0].result);
                else
                    t1.Text = String.Format("-E- C*");
            }

            if (_tmpSensors[1] != null)
            {
                if (_tmpSensors[1].sensor_state == Sensors.sensor_s.sensor_ok)
                    t2.Text = String.Format("{0:0.00} C*", _tmpSensors[1].result);
                else
                    t2.Text = String.Format("-E- C*");
            }

            if (_tmpSensors[2] != null)
            {
                if (_tmpSensors[2].sensor_state == Sensors.sensor_s.sensor_ok)
                    t3.Text = String.Format("{0:0.00} C*", _tmpSensors[2].result);
                else
                    t3.Text = String.Format("-E- C*");
            }

            if (_tmpSensors[3] != null)
            {
                if (_tmpSensors[3].sensor_state == Sensors.sensor_s.sensor_ok)
                    t4.Text = String.Format("{0:0.00} C*", _tmpSensors[3].result);
                else
                    t4.Text = String.Format("-E- C*");
            }

            if (_tmpSensors[4] != null)
            {
                if (_tmpSensors[4].sensor_state == Sensors.sensor_s.sensor_ok)
                    t5.Text = String.Format("{0:0.00} C*", _tmpSensors[4].result);
                else
                    t5.Text = String.Format("-E- C*");
            }

            if (_tmpSensors[5] != null)
            {
                if (_tmpSensors[5].sensor_state == Sensors.sensor_s.sensor_ok)
                    t6.Text = String.Format("{0:0.00} C*", _tmpSensors[5].result);
                else
                    t6.Text = String.Format("-E- C*");
            }
        }

        private void UСGrad_Load(object sender, EventArgs e)
        {
            chartControl1.Series[0].ArgumentDataMember = "DT";
            chartControl1.Series[0].ValueDataMembers.AddRange(_listChart[0]);
            chartControl1.Series[0].Name = _listChartName[0];
            l1.Text = _listChartName[0];

            chartControl1.Series[1].ArgumentDataMember = "DT";
            chartControl1.Series[1].ValueDataMembers.AddRange(_listChart[1]);
            chartControl1.Series[1].Name = _listChartName[1];
            l2.Text = _listChartName[1];

            chartControl1.Series[2].ArgumentDataMember = "DT";
            chartControl1.Series[2].ValueDataMembers.AddRange(_listChart[2]);
            chartControl1.Series[2].Name = _listChartName[2];
            l3.Text = _listChartName[2];

            chartControl1.Series[3].ArgumentDataMember = "DT";
            chartControl1.Series[3].ValueDataMembers.AddRange(_listChart[3]);
            chartControl1.Series[3].Name = _listChartName[3];
            l4.Text = _listChartName[3];

            chartControl1.Series[4].ArgumentDataMember = "DT";
            chartControl1.Series[4].ValueDataMembers.AddRange(_listChart[4]);
            chartControl1.Series[4].Name = _listChartName[4];
            l5.Text = _listChartName[4];

            chartControl1.Series[5].ArgumentDataMember = "DT";
            chartControl1.Series[5].ValueDataMembers.AddRange(_listChart[5]);
            chartControl1.Series[5].Name = _listChartName[5];
            l6.Text = _listChartName[5];

            new System.Threading.Thread(refresh_chart) { IsBackground = true }.Start();
        }

   
    }
}
