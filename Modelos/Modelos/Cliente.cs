using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Modelos
{
    public class Cliente
    {
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private String nome;
        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private String email;
        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        private String telefone;
        public String Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
    }
}
