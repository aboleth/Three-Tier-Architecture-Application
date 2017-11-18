using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Loja.Modelos;
using Loja.DAL;


namespace Loja.BLL
{
    class VendaBLL
    {
        // Campo privado para armazenar uma instância da classe DAL
        private VendaDAL objDAL;

        // Construtor da classe VendaBLL
        public VendaBLL()
        {
            objDAL = new VendaDAL();
        }

        public DataTable ListaProduto
        {
            get
            {
                return objDAL.ListaProduto;
            }
        }

        public DataTable ListaCliente
        {
            get
            {
                return objDAL.ListaCliente;
            }
        }

        public void Incluir (Venda venda)
        {
            objDAL.Incluir(venda);
        }
    }
}
