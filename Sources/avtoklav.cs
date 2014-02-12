using Owen;

namespace PolvakServer.Sources
{
    public class Avtoklav
    {
        public Sensors Apparat;
        public Sensors PApparat; 
        public Sensors Uroven;
        public Sensors RubashkaVerh;  
        public Sensors Rybashkaniz;
        public Sensors Podachpara;      
        public string Name;     
        public UControls.UCAvtoklav AvtoklavControl;
    
        public Avtoklav(int[] adreses)
        {
            AvtoklavControl = new UControls.UCAvtoklav(this);
            // ------------------------------------------
            Apparat = adreses[0] == 999 ? new Sensors(Sensors.sensor_s.sensor_nodata) : Controller.Sensor[adreses[0]];
            PApparat = adreses[1] == 999 ? new Sensors(Sensors.sensor_s.sensor_nodata) : Controller.Sensor[adreses[1]];
            Uroven = adreses[2] == 999 ? new Sensors(Sensors.sensor_s.sensor_nodata) : Controller.Sensor[adreses[2]];
            RubashkaVerh = adreses[3] == 999 ? new Sensors(Sensors.sensor_s.sensor_nodata) : Controller.Sensor[adreses[3]];
            Rybashkaniz = adreses[4] == 999 ? new Sensors(Sensors.sensor_s.sensor_nodata) : Controller.Sensor[adreses[4]];
            Podachpara = adreses[5] == 999 ? new Sensors(Sensors.sensor_s.sensor_nodata) : Controller.Sensor[adreses[5]];
        }
    }
}
