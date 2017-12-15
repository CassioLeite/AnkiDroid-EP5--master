using System;
using System.Data.SqlClient;

namespace Anki2.Models
{
    public class Conexao
    {
        private static SqlConnection con;
        
        
        private const string CONNECTION_STRING = "Server=tcp:ankiservidor.database.windows.net,1433;Database=ankioab;User ID = Anki3528463; Password=Anki43241#@!$;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection Con { get { return GetConexaoSingleton(); } }

        // Metodo - Abrir Conexão
        private static SqlConnection GetConexaoSingleton()
        {
            try
            {
                if (con == null || con.State != System.Data.ConnectionState.Open)
                {
                    con = new SqlConnection(CONNECTION_STRING);
                    con.Open();
                }
                return con;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // Metodo - Fechar Conexão
        public static void FecharConexao()
        {
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}