using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Anki2.Models;
using Anki2.Adapters;

namespace Anki2.Controllers
{
    public class UsuarioController : ApiController
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private UsuarioAdapter adapter;

        public UsuarioController()
        {
            Con = Conexao.Con;
            adapter = new UsuarioAdapter();
        }

		//api/usuario
		[HttpGet]
		public List<Usuario> GetAll()
		{
			try
            {
                Cmd = new SqlCommand("select * from Usuario", Con);
                List<Usuario> usuarios = adapter.adaptList(Cmd);

                return usuarios;

            }
            catch (Exception ex)
			{
				throw new Exception("500, Internal Server Error" + ex.Message);
			}
			finally
			{
                Conexao.FecharConexao();
			}
		}

		//api/usuario
		[HttpGet]
		public Usuario Get(string id)
		{
			try
            {
                Cmd = new SqlCommand("select * from Usuario WHERE CodUsuario=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);

                Usuario u = adapter.adaptOne(Cmd);


                return u;

            }
            catch (Exception ex)
			{
				throw new Exception("500, Internal Server Error" + ex.Message);
			}
			finally
			{
                Conexao.FecharConexao();
			}
		}

		//api/usuario
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
				throw new Exception("500, Internal Server Error" + ex.Message);
			}
			finally
			{
                Conexao.FecharConexao();
			}
		}

		//api/usuario/
		[HttpPost]
		public HttpResponseMessage Put(int id, [FromBody]Usuario u)
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
				throw new Exception("500, Internal Server Error" + ex.Message);
			}
			finally
			{
                Conexao.FecharConexao();
			}
		}

		//api/usuario
		public void Delete(int id)
		{
			try
			{
				Cmd = new SqlCommand("delete from Usuario where CodUsuario=@v1", Con);
				Cmd.Parameters.AddWithValue("@v1", id);
				Cmd.ExecuteNonQuery();

			}
			catch (Exception ex)
			{

				throw new Exception("500, Internal Server Error" + ex.Message);
			}
			finally
			{
                Conexao.FecharConexao();
			}
		}
	}
}
