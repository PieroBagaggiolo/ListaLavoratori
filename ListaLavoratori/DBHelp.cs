using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLavoratori
{
    public static class DBHelp
    {
        private static SqlConnection connessione;

        private static SqlConnection GetConnection()
        {
            if (connessione == null)
            {
                string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
                connessione = new SqlConnection(connectionString);
            }
            return connessione;
        }
        public static DataSet GetWorker()
        {
            DataSet persone = new DataSet();

            string selectQuery = "";

            SqlCommand cmd = new SqlCommand(selectQuery, GetConnection());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(persone);

            return persone;
        }

        public static void GiveQuery(SqlCommand cmd, string query)
        {
            cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,

                CommandText = query,
            };
        }

        public static void AggiungiLavoratore(Lavoratori l)
        {
            DBHelp.GiveQuery(new SqlCommand(), "INSERT INTO");
        }
    }
}
