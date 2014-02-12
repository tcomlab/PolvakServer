using System;
using MySql.Data.MySqlClient;
using System.Threading;

namespace PolvakServer.Sources
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class Database
    {
        private readonly Avtoklav[] _cl;
        private MySqlConnection _myConnect;
        //public  bool connected{set;get;}

        public Database(Avtoklav[] cl)
        {
            _cl = cl;
            connect_to_db();
            #if !DEBUG
            new Thread(WriteCyclicData) { IsBackground = true }.Start();
            #endif
        }

        //public bool is_connect()
        //{
        //    return connected;
        //}

        private void connect_to_db()
        {
            _myConnect = new MySqlConnection(Properties.Settings.Default.polvak_db2_cs);
            try
            {
                _myConnect.Open();
            }
            catch
            {
                //connected = false;
            }

            //if (MyConnect == null)
            //{
            //    connected = false;
            //}
            //else
            //{ 
            //    connected = true; 
            //}
        }

        private void WriteCyclicData()
        {
            var time = Properties.Settings.Default.save_to_db_record_time;
            var time2 = Properties.Settings.Default.save_p68_period;
            while (true)
            {
                if (_myConnect.State == System.Data.ConnectionState.Open)
                {
                    if (time-- == 0)
                    {
                        SaveData(0);
                        SaveData(1);
                        SaveData(2);
                        SaveData(3);
                        SaveData(4);
                        Save_gradirnya();
                        time = Properties.Settings.Default.save_to_db_record_time;
                    }

                    if (time2-- == 0)
                    {
                        SaveP68();
                        time2 = Properties.Settings.Default.save_p68_period;
                    }
                }
                else
                {
                    connect_to_db();
                    time = Properties.Settings.Default.save_to_db_record_time;
                    time2 = Properties.Settings.Default.save_p68_period;
                }
                Thread.Sleep(1000); // 1 sec timer dalay
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private void Save_gradirnya()
        {
            try
            {
                MySqlCommand cmd = _myConnect.CreateCommand();
                cmd.CommandText = String.Format(
                    "INSERT INTO `polvak_db2`.`gmv_20`(" +
                    "`DT`," +
                    "`to_gradirnya`," +
                    "`t_ot_avtoklava`," +
                    "`ot_gradirnya`," +
                    "`tank6`," +
                    "`tank7`," +
                    "`tank8`)" +
                    "VALUES (NOW()," +
                    "{0},{1},{2},{3},{4},{5});",
                    Convert.ToString(Controller.Sensor[130].result).Replace(",","."),
                    Convert.ToString(Controller.Sensor[131].result).Replace(",","."),
                    Convert.ToString(Controller.Sensor[132].result).Replace(",", "."),
                    Convert.ToString(Controller.Sensor[133].result).Replace(",", "."),
                    Convert.ToString(Controller.Sensor[134].result).Replace(",", "."),
                    Convert.ToString(Controller.Sensor[135].result).Replace(",","."));
                var res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                SaveLogDb(ex.Message);
                LogEx.WriteLineintoLog(ex.Message);
            }

            try
            {
                MySqlCommand cmd = _myConnect.CreateCommand();
                cmd.CommandText = String.Format(
                    "INSERT INTO `polvak_db2`.`gmv_60`(" +
                    "`DT`," +
                    "`to_gradirnya`," +
                    "`ot_gradirnya`)" +
                    "VALUES (NOW()," +
                    "{0},{1});",
                    Convert.ToString(Controller.Sensor[128].result).Replace(",", "."),
                    Convert.ToString(Controller.Sensor[129].result).Replace(",", "."));
                var res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                SaveLogDb(ex.Message);
                LogEx.WriteLineintoLog(ex.Message);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Проверка запросов SQL на уязвимости безопасности")]
        public void SaveData(int id)
        {
            var apparat = new[] { "ce4", "be16000", "be16001", "ce25","ce3" };
            try
            {
                var cmd = _myConnect.CreateCommand();
                if (_cl[id] == null) return;
                var arg0 = String.Format("{0:0.0}", _cl[id].PApparat.result).Replace(",", ".");
                var arg1 = String.Format("{0:0.0}", _cl[id].Apparat.result).Replace(",", ".");
                var arg2 = String.Format("{0:0.0}", _cl[id].Podachpara.result).Replace(",", ".");
                var arg3 = String.Format("{0:0.0}", _cl[id].Rybashkaniz.result).Replace(",", ".");
                var arg4 = String.Format("{0:0.0}", _cl[id].RubashkaVerh.result).Replace(",", ".");
                var arg5 = String.Format("{0:0.0}", _cl[id].Uroven.result).Replace(",", ".");

                cmd.CommandText = cmd1(apparat[id], arg0, arg1, arg2, arg3, arg4, arg5);
                var res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                SaveLogDb(ex.Message);
                LogEx.WriteLineintoLog(ex.Message);
            }
        }

        private string cmd1 (string name,string davAparat,string tAparat,string tPodPara,string tRubNiz,string tRubVerh,string uroven)
        {
            return String.Format(@"
            INSERT INTO `polvak_db2`.`{0}`
            (
                `DT`,
                `dav_aparat`,
                `t_aparat`,
                `t_pod_para`,
                `t_rub_niz`,
                `t_rub_verh`,
                `uroven`
            )
            VALUES
            (
                NOW(),{1},{2},{3},{4},{5},{6}
            );", name, davAparat, tAparat, tPodPara, tRubNiz, tRubVerh, uroven);
        }

        private void SaveP68()
        {
            try
            {
                MySqlCommand cmd = _myConnect.CreateCommand();
                cmd.CommandText = String.Format(@"
                INSERT INTO `polvak_db2`.`P68`
                (
                `DT`,
                `t_aluminat`,
                `t_voda`,
                `t_smesitel`,
                `q_voda`,
                `q_aluminat`,
                `q_hlorid`,
                `t_hlorid`,
                `t_prg`)
                VALUES (NOW(),{0},{1},{2},{3},{4},{5},{6},{7});",
                String.Format("{0:0.0}", Controller.PLCsensor[0].result).Replace(",", "."),
                String.Format("{0:0.0}", Controller.PLCsensor[1].result).Replace(",", "."),
                String.Format("{0:0.0}", Controller.PLCsensor[2].result).Replace(",", "."),
                String.Format("{0:0.0}", Controller.PLCsensor[3].result).Replace(",", "."),
                String.Format("{0:0.0}", Controller.PLCsensor[4].result).Replace(",", "."),
                String.Format("{0:0.0}", Controller.PLCsensor[5].result).Replace(",", "."),
                String.Format("{0:0.0}", Controller.Sensor[15].result).Replace(",", "."),
                String.Format("{0:0.0}", Controller.Sensor[14].result).Replace(",", "."));
                int res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                SaveLogDb(ex.Message);
                LogEx.WriteLineintoLog(ex.Message);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public void SaveLogDb(string log)
        {
            //INSERT INTO `polvak_db2`.`log`(`DT`,`Message`)VALUES(NOW(),{0});
            try
            {
                MySqlCommand cmd = _myConnect.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO `polvak_db2`.`log`(`DT`,`Message`)VALUES(NOW(),{0});",log);
                int res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                LogEx.WriteLineintoLog(ex.Message);
            }
        }

    }
}
