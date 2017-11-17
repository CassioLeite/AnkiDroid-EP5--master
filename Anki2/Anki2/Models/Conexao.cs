using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Anki2.Models
{
    public class Conexao
    {
        public SqlConnection Con;
        public SqlCommand Cmd;
        public SqlDataReader Dr;
        public const string CONNECTION_STRING = "Server=tcp:ankiservidor.database.windows.net,1433;Database=ankioab;User ID = Anki3528463; Password=Anki43241#@!$;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // Metodo - Abrir Conexão
        public void AbrirConexao()
        {
            try
            {
                Con = new SqlConnection(CONNECTION_STRING);
                Con.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // Metodo - Fechar Conexão
        public void FecharConexao()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}