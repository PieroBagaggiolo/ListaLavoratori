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

        public static SqlCommand GiveQuery(string query)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,

                CommandText = query,
            };

            return cmd;
        }

        public static void AggiungiLavoratore(Lavoratori l)
        {
            DBHelp.GiveQuery("INSERT INTO");

        }

        public static void DropTable(string tabella)
        {
            string deleteQuery = string.Format("DELETE FROM {0}", tabella);

            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = deleteQuery,
            };

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

    }
}
