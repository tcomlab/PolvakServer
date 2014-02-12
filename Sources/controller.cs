using System;
using System.Threading;
using Owen;

namespace PolvakServer.Sources
{public class Controller
    {
        private readonly owen_protocol _datap = new owen_protocol();private readonly ModbusTCP.ModbusTCP _mb;

        public static Sensors[] PLCsensor;
        public static Sensors[] Sensor;
        
        private readonly int _sensorsInNetwork = 8 * Properties.Settings.Default.device_in_network;
        public Avtoklav[] Avtokl { set; get; }

        private static Int16 _quatityRegister = 0;

        public Controller()
        {
            Avtokl = new Avtoklav[5];
            _datap.openPort(Properties.Settings.Default.COMPort,9600);
            Sensor = new Sensors[_sensorsInNetwork];
            for (int i = 0; i < Sensor.Length; i++) Sensor[i] = new Sensors();
            PLCsensor = new Sensors[20];
            for (int i = 0; i < PLCsensor.Length; i++) PLCsensor[i] = new Sensors();
            _quatityRegister = 18;
            _mb = new ModbusTCP.ModbusTCP() { port = 503, adress = "192.168.0.205", device_adress = 1 };
            new Thread(Process1) { IsBackground = true }.Start();
            new Thread(Process2) { IsBackground = true }.Start();
        }

        private void Process1()
        {
            var p = 0;
            while (true)
            {
                // Hesh code для ТРМ138
                try
                {
                    var tmp = _datap.ReadFloat32(p, 0x8784);
                    if (tmp.result > 300)
                    {
                        Sensor[p].sensor_state = Sensors.sensor_s.sensor_errore;
                        Sensor[p].result = 0; 
                    }
                    else
                    {
                        Sensor[p].sensor_state = tmp.sensor_state;
                        Sensor[p].result = tmp.result; 
                    }
                    
                }
                catch
                { }
                if (p++ >= _sensorsInNetwork-1) p = 0;
                Thread.Sleep(100);
            }
        }

        private void Process2()
        {
            while (true)
            {
                var f = _mb.ReadDataFloat(ModbusTCP.ModbusTCP.cmd_mode.read_input_register, 0, _quatityRegister);
                if (f != null)
                {
                    for (var i = 0; i < _quatityRegister/2; i++)
                    {
                        PLCsensor[i].result = f[i];
                        PLCsensor[i].sensor_state = Sensors.sensor_s.sensor_ok;
                    }
                }
                else
                {
                    for (var i = 0; i < _quatityRegister/2; i++)
                    {
                        PLCsensor[i].sensor_state = Sensors.sensor_s.sensor_errore;
                    }
                }

                Thread.Sleep(300);
            }   
        }
    }
}
