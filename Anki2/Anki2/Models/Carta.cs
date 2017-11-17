using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anki2.Models
{
    public class Carta
    {
        private int codCarta;
        private int codBaralho;
        private string frente;
        private string verso;


        public Carta() { }

        public Carta(int codCarta, int codBaralho, string frente, string verso)
        {
            this.codCarta = codCarta;
            this.codBaralho = codBaralho;
            this.frente = frente;
            this.verso = verso;
        }

        public int CodCarta
        {
            get
            {
                return codCarta;
            }

            set
            {
                codCarta = value;
            }
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

        public string Frente
        {
            get
            {
                return frente;
            }

            set
            {
                frente = value;
            }
        }

        public string Verso
        {
            get
            {
                return verso;
            }

            set
            {
                verso = value;
            }
        }
    }
}