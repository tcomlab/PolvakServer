using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolvakServer.UControls
{
    public partial class UCP68 : UserControl
    {
        Timer refresh_data = new Timer() {Interval =1000,Enabled = true };
        public UCP68()
        {
            InitializeComponent();
            refresh_data.Tick += refresh_data_Tick;
        }

        void refresh_data_Tick(object sender, EventArgs e)
        {
            if (Sources.Controller.PLCsensor == null) return;

            // температура алимината
            if(Sources.Controller.PLCsensor[0].sensor_state == Owen.Sensors.sensor_s.sensor_ok)
                label6.Text = String.Format("{0:0.0} C*",Sources.Controller.PLCsensor[0].result);
            else
                label6.Text = String.Format("-E- C*");

            // температура воды
          /*  if (Sources.Controller.PLCsensor[1].sensor_state == Owen.Sensors.sensor_s.sensor_ok)
                label11.Text = String.Format("{0:0.0} C*", Sources.Controller.PLCsensor[1].result);
            else
                label11.Text = String.Format("-E- C*");*/
            // температура после смесителя
            if (Sources.Controller.PLCsensor[2].sensor_state == Owen.Sensors.sensor_s.sensor_ok)
                label3.Text = String.Format("{0:0.0} C*", Sources.Controller.PLCsensor[2].result);
            else
                label3.Text = String.Format("-E- C*");

            // Расход воды
            if (Sources.Controller.PLCsensor[3].sensor_state == Owen.Sensors.sensor_s.sensor_ok)
                label1.Text = String.Format("{0:0.00} м3/ч", Sources.Controller.PLCsensor[3].result*0.01);
            else
                label1.Text = String.Format("-E- м3/ч");

            // Расход Алюимината
           // if (Sources.Controller.PLCsensor[4].sensor_state == Owen.Sensors.sensor_s.sensor_ok)
            //    label10.Text = String.Format("{0:0.00} м3/ч", Sources.Controller.PLCsensor[4].result * 0.01);
           // else
            //    label10.Text = String.Format("-E- м3/ч");

            // Расход хлорида
            if (Sources.Controller.PLCsensor[5].sensor_state == Owen.Sensors.sensor_s.sensor_ok)
                label9.Text = String.Format("{0:0.00} м3/ч", Sources.Controller.PLCsensor[5].result * 0.01);
            else
                label9.Text = String.Format("-E- м3/ч");

            // Частота вода
          /*  if (Sources.Controller.PLCsensor[6].sensor_state == Owen.Sensors.sensor_s.sensor_ok)
                label2.Text = String.Format("{0:0.00} Hz", Sources.Controller.PLCsensor[6].result);
            else
                label2.Text = String.Format("-E- Hz");*/

            // Частота алюминат
          /*  if (Sources.Controller.PLCsensor[7].sensor_state == Owen.Sensors.sensor_s.sensor_ok)
                label7.Text = String.Format("{0:0.00} Hz", Sources.Controller.PLCsensor[7].result);
            else
                label7.Text = String.Format("-E- Hz");*/

            // Частота хлорида
           /* if (Sources.Controller.PLCsensor[8].sensor_state == Owen.Sensors.sensor_s.sensor_ok)
                label8.Text = String.Format("{0:0.00} Hz", Sources.Controller.PLCsensor[8].result);
            else
                label8.Text = String.Format("-E- Hz");*/

            // Температура после ПРГ
            if (Sources.Controller.Sensor[14].sensor_state == Owen.Sensors.sensor_s.sensor_ok)
                label5.Text = String.Format("{0:0.0} C*", Sources.Controller.Sensor[14].result);
            else
                label5.Text = String.Format("-E- C*");

            // Температура Хлорида
            if (Sources.Controller.Sensor[15].sensor_state == Owen.Sensors.sensor_s.sensor_ok)
                label4.Text = String.Format("{0:0.0} C*", Sources.Controller.Sensor[15].result);
            else
                label4.Text = String.Format("-E- C*");
        }
    }
}
