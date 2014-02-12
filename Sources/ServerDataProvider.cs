
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PolvakServer.Sources
{
    class ServerDataProvider
    {
        private readonly TCPServer _tcpServer = new TCPServer(3000);

        public bool DataValid = false;
        private bool _flag = false;
        public float[] KotTemperature = new float[8];

        private readonly Timer _timer = new Timer() { Interval = 4000 };

        public ServerDataProvider()
        {
         /*   _tcpServer.ClientConnectEx += tcp_server_ClientConnectEx;
            _timer.Elapsed += timer_Elapsed;
            _timer.Enabled = true;*/
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_flag) DataValid = true; else DataValid = false;
            _flag = false;
        }

        void tcp_server_ClientConnectEx(bool state)
        {
            if (!state) return;
            foreach (var t in TCPServer.Clients)
            {
                t.Recive += ServerDataProvider_Recive;
            }
        }

        void ServerDataProvider_Recive(byte[] data, int datalengh, ServerData sdata)
        {
        /*    // Приниманием данные от клиента и десириализируем их
            try
            {
                var indata = (IN_Data)new BinaryFormatter().Deserialize(new MemoryStream(data));
                KotTemperature = indata.args;
            }
            catch (Exception ex)
            {
                LogEx.WriteLineintoLog(ex.Message);
            }
            _flag = true;

            // Сериализируем и отправляем ответ в виде давления пара на гребёнке
            var outdata = new OUT_Data() { CMD = 0x12 };
            var dav = new float[8];
            if (Controller.Sensor[7] == null) return;
            if (Controller.Sensor[7].sensor_state == Owen.Sensors.sensor_s.sensor_ok) dav[0] = Controller.Sensor[7].result;
            else dav[0] = 0;
            outdata.args = dav;
            try
            {
                var ms = new MemoryStream();
                new BinaryFormatter().Serialize(ms, outdata);
                byte[] dataToSend = ms.ToArray();
                sdata.SendMessage(dataToSend);
            }
            catch (Exception ex)
            {
                LogEx.WriteLineintoLog(ex.Message);
            }
            */}
    }

}
