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
        public static int UpdatePersona(Lavoratori l)
        {
            int result = 0;

            string updateQuery = "UPDATE  SET Nome = @Nome, Cognome = @Cognome, DataDiNascita =  @DataDiNascita, " +
                "Retribuzione = @Retribuzione, DataAssunzione = @DataAssunzione, Tipo = @Tipo " +
                "WHERE ID = @Persona_ID";

            SqlCommand cmd = GiveQuery(updateQuery);

            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 255).Value = l.Nome;
            cmd.Parameters.Add("@Cognome", SqlDbType.NVarChar, 255).Value = l.Cognome;
            cmd.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = l.DataDiNascita;
            cmd.Parameters.Add("@Retribuzione", SqlDbType.Float).Value = l.RAL;
            cmd.Parameters.Add("@DataAssunzione", SqlDbType.DateTime).Value = l.DataAssunzione;
            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = l.Tipo;

            //cmd.Parameters.AddWithValue("@Persona_ID", l.);

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return result;
        }

    }
}
