using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Anki2.Models
{
    public class Usuario
    {
        private SqlConnection Con;
        public SqlCommand Cmd;
        public SqlDataReader Dr;
        public Conexao con;
        private int codUsuario;
        private string nomeUsuario;
        private string email;
        private string senha;

        public int CodUsuario
        {
            get
            {
                return codUsuario;
            }

            set
            {
                codUsuario = value;
            }
        }

        public string NomeUsuario
        {
            get
            {
                return nomeUsuario;
            }

            set
            {
                nomeUsuario = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        public Usuario() { }

        public Usuario(int codUsuario, string nomeUsuario, string email, string senha)
        {
            this.codUsuario = codUsuario;
            this.nomeUsuario = nomeUsuario;
            this.email = email;
            this.senha = senha;
        }

        public Usuario AutenticarUsuario([FromBody] string email, string senha)
        {
            try
            {
                Cmd = new SqlCommand("select * from Usuario WHERE Email=@v1 AND Senha=@v2", Con);
                Cmd.Parameters.AddWithValue("@v1", email);
                Cmd.Parameters.AddWithValue("@v2", senha);
                Dr = Cmd.ExecuteReader();
                Usuario u = null;

                if (Dr.Read())
                {
                    u = new Usuario
                    {
                        CodUsuario = Convert.ToInt32(Dr["CodUsuario"]),
                        NomeUsuario = Convert.ToString(Dr["NomeUsuario"]),
                        Email = Convert.ToString(Dr["Email"]),
                        Senha = Convert.ToString(Dr["Senha"])
                    };
                }
                return u;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }
    }
}