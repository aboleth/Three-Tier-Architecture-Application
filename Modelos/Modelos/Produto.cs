using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Modelos
{
    public class Produto
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

        private decimal preco;
        public decimal Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        private decimal estoque;
        public decimal Estoque
        {
            get { return estoque; }
            set { estoque = value; }
        }
    }
}
