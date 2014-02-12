using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace PolvakServer.Sources
{
    public class setting_adress
    {
        private XmlDocument xconfig;
        private XmlNodeList avtoklav0;
        private int avtoklav_n;

        public setting_adress(int avtoklav_num)
        {
            avtoklav_n = avtoklav_num;
            xconfig = new XmlDocument();
        }

        // Читаем конфиг файл
        public bool read_setting(string path)
        {
            FileStream fs;

            try
            {
                fs = new FileStream(path, FileMode.Open);
                xconfig.Load(fs);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            if (xconfig == null) return false;

            XmlNodeList list = xconfig.GetElementsByTagName("avtoklav");

            if (list == null) return false;

            avtoklav0 = list.Item(avtoklav_n).ChildNodes;

            fs.Close();

            return true;
        }

        public Owen.Sensors av_t_apparat
        {
            get { 
                if (avtoklav0[0].InnerText == "") 
                    return new Owen.Sensors() {result =0,sensor_state = Owen.Sensors.sensor_s.sensor_errore }; 
                else return Controller.Sensor[Convert.ToInt32(avtoklav0[0].InnerText)]; }
        }

        public Owen.Sensors av_p_apparat
        {
            get
            {
                if (avtoklav0[1].InnerText == "")
                    return new Owen.Sensors() { result = 0, sensor_state = Owen.Sensors.sensor_s.sensor_errore };
                else return Controller.Sensor[Convert.ToInt32(avtoklav0[1].InnerText)];
            }
        }

        public Owen.Sensors av_t_rubashkaverh
        {
            get
            {
                if (avtoklav0[2].InnerText == "")
                    return new Owen.Sensors() { result = 0, sensor_state = Owen.Sensors.sensor_s.sensor_errore };
                else return Controller.Sensor[Convert.ToInt32(avtoklav0[2].InnerText)];
            }
        }

        public Owen.Sensors av_t_rubashkaniz
        {
            get {
                if (avtoklav0[3].InnerText == "")
                    return new Owen.Sensors() { result = 0, sensor_state = Owen.Sensors.sensor_s.sensor_errore };
                else return Controller.Sensor[Convert.ToInt32(avtoklav0[3].InnerText)];
            }
        }

        public Owen.Sensors av_t_podachapara
        {
            get { 
                if (avtoklav0[4].InnerText == "")
                    return new Owen.Sensors() { result = 0, sensor_state = Owen.Sensors.sensor_s.sensor_errore };
                else return Controller.Sensor[Convert.ToInt32(avtoklav0[4].InnerText)];
            }
        }

        public Owen.Sensors av_uroven
        {
            get { 
                if (avtoklav0[5].InnerText == "")
                    return new Owen.Sensors() { result = 0, sensor_state = Owen.Sensors.sensor_s.sensor_errore };
                else return Controller.Sensor[Convert.ToInt32(avtoklav0[5].InnerText)];
            }
        }

    }
}
