using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Modelos{
    public class Venda
    {
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        private int quantidade;
        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        private bool faturado;
        public bool Faturado
        {
            get { return faturado; }
            set { faturado = value; }
        }

        private int codigoCliente;
        public int CodigoCliente
        {
            get { return codigoCliente; }
            set { codigoCliente = value; }
        }

        private int codigoProduto;
        public int CodigoProduto
        {
            get { return codigoProduto; }
            set { codigoProduto = value; }
        }

        private String nomeCliente;
        public String NomeCliente
        {
            get { return nomeCliente; }
            set { nomeCliente = value; }
        }

    }
}
