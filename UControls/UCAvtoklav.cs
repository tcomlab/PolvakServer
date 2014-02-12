using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Owen;
using PolvakServer.Sources;

namespace PolvakServer.UControls
{
    public partial class UCAvtoklav : UserControl
    {
        Timer timer = new Timer();
        Avtoklav av;
        public UCAvtoklav(Avtoklav av)
        {
            this.av = av;
            InitializeComponent();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (av.Podachpara.sensor_state == Sensors.sensor_s.sensor_ok)
                l_fume.Text = String.Format("{0:0.00} C*", av.Podachpara.result);
            else
                l_fume.Text = "-E- C*";

            if (av.Apparat.sensor_state == Sensors.sensor_s.sensor_ok)
                l_tApparat.Text = String.Format("{0:0.00} C*", av.Apparat.result);
            else
                l_tApparat.Text = "-E- C*";

            if (av.PApparat.sensor_state == Sensors.sensor_s.sensor_ok)
                l_pApparat.Text = String.Format("{0:0.00} Bar", av.PApparat.result);
            else
                l_pApparat.Text = "-E- Bar";

            if (av.RubashkaVerh.sensor_state == Sensors.sensor_s.sensor_ok)
                l_tShirt_high.Text = String.Format("{0:0.00} C*", av.RubashkaVerh.result);
            else
                l_tShirt_high.Text = "-E- C*";

            if (av.Rybashkaniz.sensor_state == Sensors.sensor_s.sensor_ok)
                l_tShirt_low.Text = String.Format("{0:0.00} C*", av.Rybashkaniz.result);
            else
                l_tShirt_low.Text = "-E- C*";

            if (av.Uroven.sensor_state == Sensors.sensor_s.sensor_ok)
            {
                lUroven.Text = String.Format("{0:0.00} M", av.Uroven.result);
                try { urovenBar.Position = (int)av.Uroven.result * 25; }
                catch { }
            }
            else
            {
                lUroven.Text = "-E- C*";
                urovenBar.Position = 0; 
            }
        }
    }
}
