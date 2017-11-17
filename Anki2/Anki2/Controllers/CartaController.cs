using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Anki2.Models;

namespace Anki2.Controllers
{
    public class CartaController : ApiController
    {
        private Conexao con;
        public SqlConnection Con;
        public SqlCommand Cmd;
        public SqlDataReader Dr;

        public CartaController()
        {
            con = new Conexao();
            con.AbrirConexao();
            Con = con.Con;
        }

		// GET: api/Carta/GetAll
		[HttpGet]
		public List<Carta> Get()
        {
            try
            {
                Cmd = new SqlCommand("select * from Carta", Con);
                
                Dr = Cmd.ExecuteReader();
                Carta c = null;
                List<Carta> cartas = new List<Carta>();

                while (Dr.Read())
                {
					c = new Carta
					{
						CodCarta = Convert.ToInt32(Dr["CodCarta"]),
						Frente = Convert.ToString(Dr["Frente"]),
						Verso = Convert.ToString(Dr["Verso"]),
						CodBaralho = Convert.ToInt32(Dr["CodBaralho"])
					};
					cartas.Add(c);
                }
                return cartas;
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

		// GET: api/Carta/Get?id=string
		[HttpGet]
		public List<Carta> Get(int id)
        {
            try
            {
                Cmd = new SqlCommand("select * from Carta WHERE CodBaralho=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();
                Carta c = null;
                List<Carta> cartas = new List<Carta>();

                while (Dr.Read())
                {
					c = new Carta
					{
						CodCarta = Convert.ToInt32(Dr["CodCarta"]),
						Frente = Convert.ToString(Dr["Frente"]),
						Verso = Convert.ToString(Dr["Verso"]),
						CodBaralho = Convert.ToInt32(Dr["CodBaralho"])
					};
					cartas.Add(c);
                }
                return cartas;
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

		// POST: api/Carta
		[HttpPost]
		public HttpResponseMessage Post([FromBody]Carta c)
        {
            try
            {
                Cmd = new SqlCommand("insert into Carta (Frente, Verso, CodBaralho) values(@v1, @v2, @v3)", Con);
                Cmd.Parameters.AddWithValue("@v1", c.Frente);
                Cmd.Parameters.AddWithValue("@v2", c.Verso);
                Cmd.Parameters.AddWithValue("@v3", c.CodBaralho);
                Cmd.ExecuteNonQuery();
                return new HttpResponseMessage(HttpStatusCode.Created);
                //return base.Created(new Uri(Request.RequestUri + id), content);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Carta: " + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }

		// PUT: api/Carta/5
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
                throw new Exception("Erro ao atualizar o Carta: " + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }

        // DELETE: api/Carta/5
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
                throw new Exception("Erro ao excluir Carta" + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }
    }
}
