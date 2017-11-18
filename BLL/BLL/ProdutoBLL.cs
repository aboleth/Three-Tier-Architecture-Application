using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Loja.Modelos;
using Loja.DAL;

namespace Loja.BLL
{
    public class ProdutoBLL
    {
        public ArrayList ProdutosEmFalta()
        {
            ProdutoDAL obj = new ProdutoDAL();
            return obj.ProdutosEmFalta();
        }

        public void Incluir(Produto produto)
        {
            // Obrigatório: Nome do produto
            if (produto.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório!");
            }

            // Preço não pode ser negativo
            if (produto.Preco<0)
            {
                throw new Exception("Preço do produto não pode ser negativo!");
            }

            // O estoque do produto não pode ser negativo
            if (produto.Estoque <0)
            {
                throw new Exception("Estoque do produto não pode ser negativo!");
            }

            // Incluir no SQL
            ProdutoDAL obj = new ProdutoDAL();
            obj.Incluir(produto);
        }

        public void Alterar (Produto produto)
        {
            ProdutoDAL obj = new ProdutoDAL();
            obj.Alterar(produto);
        }

        public void Excluir(int codigo)
        {
            ProdutoDAL obj = new ProdutoDAL();
            obj.Excluir(codigo);
        }

        public DataTable Listagem()
        {
            ProdutoDAL obj = new ProdutoDAL();
            return obj.Listagem();
        }
    }
}
