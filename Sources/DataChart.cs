using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace PolvakServer.Sources
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class DataChart
    {
        private MySqlConnection _myConnect;

        public DataChart()
        {
            Connect();
        }

        public void Connect()
        {
            _myConnect = new MySqlConnection(Properties.Settings.Default.polvak_db2_cs);
            try
            {
                _myConnect.Open();
            }
            catch
            {
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public DataSet GetData(int pole)
        {
            if (_myConnect.State == ConnectionState.Open)
            {
                var DS = new DataSet();
                try
                {
                    var objec = new string[] { "ce4", "be16000", "be16001", "ce25", "ce3" };
                    var query = String.Format(@"SELECT * FROM polvak_db2.{0} WHERE DT >= '{1}-{2}-{3} 00:00:00' AND DT <= '{1}-{2}-{3} 23:59:59';", objec[pole], DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    var adapter = new MySqlDataAdapter(query, _myConnect);
                    adapter.Fill(DS);
                }
                catch { }
                return DS;
            }
            else
            {
                Connect();
            }
            return null;
        }

        public DataSet GetDataGradignya(int index)
        {
            if (_myConnect.State == ConnectionState.Open)
            {
                var ds = new DataSet();
                try
                {
                    string db = "";
                    switch (index)
                    {
                        case 1:
                            db = "gmv_20";
                            break;
                        case 0:
                            db = "gmv_60";
                            break;
                    }
                    var query =
                        String.Format(
                            @"SELECT * FROM polvak_db2." + db +
                            " WHERE DT >= '{0}-{1}-{2} 00:00:00' AND DT <= '{0}-{1}-{2} 23:59:59';", DateTime.Now.Year,
                            DateTime.Now.Month, DateTime.Now.Day);
                    var adapter = new MySqlDataAdapter(query, _myConnect);
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    
                }
                return ds;
            }
            else
            {
                Connect();
            }
            return null;
        }
    }
}
