using System;
using Anki2.Models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Anki2.Adapters
{
    public class CartaAdapter
    {

        private Carta adapt(SqlCommand cmd)
        {
            SqlDataReader Dr = cmd.ExecuteReader();
            Carta carta = new Carta()
            {
                CodCarta = Convert.ToInt32(Dr["CodCarta"]),
                CodBaralho = Convert.ToInt32(Dr["CodBaralho"]),
                Frente = Convert.ToString(Dr["Frente"]),
                Verso = Convert.ToString(Dr["Verso"])
            };
            return carta;
        }

        public Carta adaptOne(SqlCommand cmd)
        {
            SqlDataReader Dr = cmd.ExecuteReader();
            Carta carta = null;
            if (Dr.Read())
            {
                carta = this.adapt(cmd);
            }
            return carta;
        }


        public List<Carta> adaptList(SqlCommand cmd)
        {
            SqlDataReader Dr = cmd.ExecuteReader();
            List<Carta> cartas = new List<Carta>();
            while (Dr.Read())
            {
                cartas.Add(this.adapt(cmd));
            }
            return cartas;
        }

    }
}