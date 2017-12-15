using System;
using Anki2.Models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Anki2.Adapters
{

    public class BaralhoAdapter
    {
        private Baralho adapt(SqlCommand cmd)
        {
            SqlDataReader Dr = cmd.ExecuteReader();
            Baralho baralho = new Baralho()
            {
                CodBaralho = Convert.ToInt32(Dr["CodBaralho"]),
                NomeBaralho = Convert.ToString(Dr["NomeBaralho"])
            };
            return baralho;
        }

        public Baralho adaptOne(SqlCommand cmd)
        {
            SqlDataReader Dr = cmd.ExecuteReader();
            Baralho baralho = null;
            if (Dr.Read())
            {
                baralho = this.adapt(cmd);
            }
            return baralho;
        }


        public List<Baralho> adaptList(SqlCommand cmd)
        {
            SqlDataReader Dr = cmd.ExecuteReader();
            List<Baralho> baralhos = new List<Baralho>();
            while (Dr.Read())
            {
                baralhos.Add(this.adapt(cmd));
            }
            return baralhos;
        }

    }
}