using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Anki2.Models;

namespace Anki2.Controllers
{
    public class BaralhoController : ApiController
    {
        private Conexao con;
        public SqlConnection Con;
        public SqlCommand Cmd;
        public SqlDataReader Dr;

        public BaralhoController()
        {
            con = new Conexao();
            con.AbrirConexao();
            Con = con.Con;
        }

		// GET: api/Baralho/GetAll
		[HttpGet]
		public List<Baralho> GetAll()
        {
            try
            {
                Cmd = new SqlCommand("select * from Baralho", Con);
                
                Dr = Cmd.ExecuteReader();
                Baralho b = null;
                List<Baralho> baralhos = new List<Baralho>();

                while (Dr.Read())
                {
					b = new Baralho
					{
						CodBaralho = Convert.ToInt32(Dr["CodBaralho"]),
						NomeBaralho = Convert.ToString(Dr["NomeBaralho"])
					};
					baralhos.Add(b);
                }

                return baralhos;

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

		// GET: api/Baralho/Get?id=string
		[HttpGet]
		public Baralho Get(int id)
        {
            try
            {
                Cmd = new SqlCommand("select * from Baralho WHERE CodBaralho=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();
                Baralho b = null;

                if (Dr.Read())
                {
					b = new Baralho
					{
						CodBaralho = Convert.ToInt32(Dr["CodBaralho"]),
						NomeBaralho = Convert.ToString(Dr["NomeBaralho"])
					};
				}

                return b;

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

		// POST: api/Baralho
		[HttpPost]
		public HttpResponseMessage Post([FromBody]Baralho b)
        {
            try
            {
                Cmd = new SqlCommand("insert into Baralho (NomeBaralho) values(@v1)", Con);
                Cmd.Parameters.AddWithValue("@v1", b.NomeBaralho); ;
                Cmd.ExecuteNonQuery();
                return new HttpResponseMessage(HttpStatusCode.Created);
                //return base.Created(new Uri(Request.RequestUri + id), content);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Baralho: " + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }

		// PUT: api/Baralho/5
		[HttpPost]
		public HttpResponseMessage Put(int id, [FromBody]Baralho b)
        {
            try
            {
                Cmd = new SqlCommand("update Baralho set NomeBaralho=@v1 where CodBaralho=@v2", Con);
                Cmd.Parameters.AddWithValue("@v1", b.NomeBaralho);
                Cmd.Parameters.AddWithValue("@v2", b.CodBaralho);
                Cmd.ExecuteNonQuery();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o Baralho: " + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }

        // DELETE: api/Baralho/5
        public void Delete(int id)
        {
            try
            {
                Cmd = new SqlCommand("delete from Baralho where CodBaralho=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir Baralho" + ex.Message);
            }
            finally
            {
                con.FecharConexao();
            }
        }
    }
}
