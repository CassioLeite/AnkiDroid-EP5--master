using System;
using Anki2.Models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Anki2.Adapters
{
    public class UsuarioAdapter
    {

        private Usuario adapt(SqlCommand cmd)
        {
            SqlDataReader Dr = cmd.ExecuteReader();
            Usuario usuario = new Usuario
            {
                CodUsuario = Convert.ToInt32(Dr["CodUsuario"]),
                NomeUsuario = Convert.ToString(Dr["NomeUsuario"]),
                Email = Convert.ToString(Dr["Email"]),
                Senha = Convert.ToString(Dr["Senha"])
            };
            return usuario;
        }

        public Usuario adaptOne(SqlCommand cmd)
        {
            SqlDataReader Dr = cmd.ExecuteReader();
            Usuario usuario = null;
            if (Dr.Read())
            {
                usuario = this.adapt(cmd);
            }
            return usuario;
        }


        public List<Usuario> adaptList(SqlCommand cmd)
        {
            SqlDataReader Dr = cmd.ExecuteReader();
            List<Usuario> usuarios = new List<Usuario>();
            while (Dr.Read())
            {
                usuarios.Add(this.adapt(cmd));
            }
            return usuarios;
        }

    }
}