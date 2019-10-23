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
            
            string selectQuery = "SELECT Nome, Cognome, TitoloDiStudio, " +
                "DataDiNascita, DataAssunzione, Tipo FROM Lavoratori";

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

        public static void AddWorker(Lavoratori l)
        {
            SqlCommand cmd = GiveQuery("INSERT INTO Lavoratori" +
                "(ID, Nome, Cognome, TitoloDiStudio, DataDiNascita, DataAssunzione, StipendioMensile, Mensilità) VALUES" +
                "(@IDWorker, @Nome, @Cognome, @DataDiNascita, @DataAssunzione, @StipendioMensile, @Mensilità)");

            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 255).Value = l.Nome;
            cmd.Parameters.Add("@Cognome", SqlDbType.NVarChar, 255).Value = l.Cognome;
            cmd.Parameters.Add("@Titolo", SqlDbType.Int).Value = l.Titolo;
            cmd.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = l.DataDiNascita;
            cmd.Parameters.Add("@DataAssunzione", SqlDbType.DateTime).Value = l.DataAssunzione;
            cmd.Parameters.Add("@StipendioMensile", SqlDbType.Float).Value = l.StipendioMensile;
            

        }

        public static void DropTable(string tabella)
        {
            string deleteQuery = string.Format("DELETE FROM {0}", tabella);

            SqlCommand cmd = DBHelp.GiveQuery(deleteQuery);

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static int EditWorker(Lavoratori l)
        {
            int result = 0;

            string updateQuery = "UPDATE  SET Nome = @Nome, Cognome = @Cognome, TitoloDiStudio = @Titolo, " +
                "DataDiNascita =  @DataDiNascita, DataAssunzione = @DataAssunzione," +
                "StipendioMensile = @StipendioMensile  " +
                "WHERE ID = @IDWorker";

            SqlCommand cmd = GiveQuery(updateQuery);

            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 255).Value = l.Nome;
            cmd.Parameters.Add("@Cognome", SqlDbType.NVarChar, 255).Value = l.Cognome;
            cmd.Parameters.Add("@Titolo", SqlDbType.Int).Value = l.Titolo;
            cmd.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = l.DataDiNascita;
            cmd.Parameters.Add("@DataAssunzione", SqlDbType.DateTime).Value = l.DataAssunzione;
            cmd.Parameters.Add("@StipendioMensile", SqlDbType.Float).Value = l.StipendioMensile;
            

            cmd.Parameters.AddWithValue("@ID", l.IDWorker);

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return result;
        }

        public static int DeleteWorker(Lavoratori l)
        {
            int result = 0;
            string deleteQuery = "DELETE FROM Lavoratori WHERE ID = @Persona_ID";

            SqlCommand cmd = GiveQuery(deleteQuery);
            
            cmd.Parameters.AddWithValue("@ID",l.IDWorker);

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return result;
        }

    }
}
