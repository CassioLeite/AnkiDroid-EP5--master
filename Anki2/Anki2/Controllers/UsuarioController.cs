using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Anki2.Models;

namespace Anki2.Controllers
{
    public class UsuarioController : ApiController
    {
        private SqlConnection Con;
        public SqlCommand Cmd;
        public SqlDataReader Dr;
        public Conexao con;
        public Usuario usuario;

        public UsuarioController()
        {
            con = new Conexao();
            con.AbrirConexao();
            Con = con.Con;
        }

		// GET: api/Usuario/GetAll
		[HttpGet]
		public List<Usuario> GetAll()
		{
			try
			{
				Cmd = new SqlCommand("select * from Usuario", Con);
				Dr = Cmd.ExecuteReader();
				Usuario u = null;
				List<Usuario> usuarios = new List<Usuario>();

				while (Dr.Read())
				{
					u = new Usuario
					{
						CodUsuario = Convert.ToInt32(Dr["CodUsuario"]),
						NomeUsuario = Convert.ToString(Dr["NomeUsuario"]),
						Email = Convert.ToString(Dr["Email"]),
						Senha = Convert.ToString(Dr["Senha"])
					};
					usuarios.Add(u);
				}
				return usuarios;
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

		// POST: api/Usuario/Get
		[HttpPost]
		public Usuario Get([FromBody] string email, string senha)
		{
            return usuario.AutenticarUsuario(email, senha);
		}

		// POST: api/Usuario/Post
		[HttpPost]
		public HttpResponseMessage Post([FromBody]Usuario value)
		{
			try
			{
				Cmd = new SqlCommand("insert into Usuario (NomeUsuario, Email, Senha) values(@v1, @v2, @v3)", Con);
				Cmd.Parameters.AddWithValue("@v1", value.NomeUsuario);
				Cmd.Parameters.AddWithValue("@v2", value.Email);
				Cmd.Parameters.AddWithValue("@v3", value.Senha);
				Cmd.ExecuteNonQuery();
				return new HttpResponseMessage(HttpStatusCode.Created);
				//return base.Created(new Uri(Request.RequestUri + id), content);

			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao gravar Usuário: " + ex.Message);
			}
			finally
			{
				con.FecharConexao();
			}
		}

		// POST: api/Usuario/Put
		[HttpPost]
		public HttpResponseMessage Put([FromBody]Usuario u)
		{
			try
			{
				Cmd = new SqlCommand("update Usuario set NomeUsuario=@v1, Email=@v2, Senha=@v3 where CodUsuario=@v4", Con);
				Cmd.Parameters.AddWithValue("@v1", u.NomeUsuario);
				Cmd.Parameters.AddWithValue("@v2", u.Email);
				Cmd.Parameters.AddWithValue("@v3", u.Senha);
				Cmd.Parameters.AddWithValue("@v4", u.CodUsuario);
				Cmd.ExecuteNonQuery();

				return new HttpResponseMessage(HttpStatusCode.OK);
			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao atualizar o Usuário: " + ex.Message);
			}
			finally
			{
				con.FecharConexao();
			}
		}

		// POST: api/Usuario/Delete
        [HttpPost]
		public void Delete([FromBody] int id)
		{
			try
			{
				Cmd = new SqlCommand("delete from Usuario where CodUsuario=@v1", Con);
				Cmd.Parameters.AddWithValue("@v1", id);
				Cmd.ExecuteNonQuery();

			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao excluir Usuário" + ex.Message);
			}
			finally
			{
				con.FecharConexao();
			}
		}
	}
}
