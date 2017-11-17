using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anki2.Models
{
    public class Usuario
    {
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
    }
}