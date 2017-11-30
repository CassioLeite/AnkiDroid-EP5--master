using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anki2.Models
{
    public class Baralho
    {
        private int codBaralho;
        private string nomeBaralho;

        public Baralho() { }

        public Baralho(int codBaralho, string nomeBaralho)
        {
            this.codBaralho = codBaralho;
            this.nomeBaralho = nomeBaralho;
        }

        public int CodBaralho
        {
            get
            {
                return codBaralho;
            }

            set
            {
                codBaralho = value;
            }
        }

        public string NomeBaralho
        {
            get
            {
                return nomeBaralho;
            }

            set
            {
                nomeBaralho = value;
            }
        }



    }
}