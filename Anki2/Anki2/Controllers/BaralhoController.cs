using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Anki2.Models;
using Anki2.Adapters;
//using Anki2;

namespace Anki2.Controllers
{
    public class BaralhoController : ApiController
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        
        private BaralhoAdapter adapter;

        public BaralhoController()
        {
            Con = Conexao.Con;
            adapter = new BaralhoAdapter();
        }

		//api/baralho
		[HttpGet]
		public List<Baralho> GetAll()
        {
            try
            {
                Cmd = new SqlCommand("select * from Baralho", Con);
                List<Baralho> baralhos = adapter.adaptList(Cmd);

                return baralhos;

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

		//api/baralho
		[HttpGet]
		public Baralho Get(int id)
        {
            try
            {
                Cmd = new SqlCommand("select * from Baralho WHERE CodBaralho=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                
                Baralho b = adapter.adaptOne(Cmd);
                

                return b;

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

		//api/baralho
		[HttpPost]
		public HttpResponseMessage Post([FromBody]Baralho b)
        {
            try
            {
                Cmd = new SqlCommand("insert into Baralho (NomeBaralho) values(@v1)", Con);
                Cmd.Parameters.AddWithValue("@v1", b.NomeBaralho);
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

		//api/baralho
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
                throw new Exception("500, Internal Server Error" + ex.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        //api/baralho/
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

                throw new Exception("500, Internal Server Error" + ex.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }
    }
}
