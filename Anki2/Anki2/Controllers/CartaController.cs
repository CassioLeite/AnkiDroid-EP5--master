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
    public class CartaController : ApiController
    {
        
        private SqlConnection Con;
        private SqlCommand Cmd;
        private CartaAdapter adapter;

        public CartaController()
        {
            Con = Conexao.Con;
            adapter = new CartaAdapter();
        }

		//api/carta
		[HttpGet]
		public List<Carta> Get()
        {
            try
            {
                Cmd = new SqlCommand("select * from Carta", Con);
                List<Carta> cartas = adapter.adaptList(Cmd);

                return cartas;

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

		//api/carta
		[HttpGet]
        public Carta Get(int id)
        {
            try
            {
                Cmd = new SqlCommand("select * from Carta WHERE CodCarta=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);

                Carta c = adapter.adaptOne(Cmd);


                return c;

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

        //api/carta
        [HttpPost]
		public HttpResponseMessage Post([FromBody]Carta c)
        {
            try
            {
                Cmd = new SqlCommand("insert into Carta (Frente, Verso) values(@v1, @v2)", Con);
                Cmd.Parameters.AddWithValue("@v1", c.Frente);
                Cmd.Parameters.AddWithValue("@v2", c.Verso);
                Cmd.ExecuteNonQuery();
                return new HttpResponseMessage(HttpStatusCode.Created);

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

		//api/carta
		[HttpPost]
		public HttpResponseMessage Put(int id, [FromBody]Carta c)
        {
            try
            {
                Cmd = new SqlCommand("update Carta set Frente=@v1, Verso=@v2, CodBaralho=@v3 where CodCarta=@v4", Con);
                Cmd.Parameters.AddWithValue("@v1", c.Frente);
                Cmd.Parameters.AddWithValue("@v2", c.Verso);
                Cmd.Parameters.AddWithValue("@v3", c.CodBaralho);
                Cmd.Parameters.AddWithValue("@v4", c.CodCarta);
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

        //api/carta
        public void Delete(int id)
        {
            try
            {
                Cmd = new SqlCommand("delete from Carta where CodCarta=@v1", Con);
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
