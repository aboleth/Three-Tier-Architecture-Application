using System;
using System.Data;
using Loja.Modelos;
using Loja.DAL;


namespace Loja.BLL
{
    public class ClienteBLL
    {
        public void incluir(Cliente cliente)
        {
            // Obrigatório: Nome do cliente
            if (cliente.Nome.Trim().Length == 0)
            {
                throw new Exception("*Favor preencher os campos obrigatórios!*");
            }

            //Obrigatório: Email do cliente
            if (cliente.Email.Trim().Length == 0)
            {
                throw new Exception("*Favor preencher os campos obrigatórios!*");
            }

            // Letras Minúsculas: Email do cliente
            cliente.Email = cliente.Email.ToLower();

            ClienteDAL obj = new ClienteDAL();

            // Email deve ser único

            if (obj.CheckEmail(cliente.Email))
            {
                throw new Exception("Este email já está cadastrado!");
            }
            // Caso seja único: incluir cliente
            else
            {
                obj.Incluir(cliente);
            }

            
        }

        public void Alterar(Cliente cliente)
        {
            ClienteDAL obj = new ClienteDAL();
            obj.Alterar(cliente);
        }

        public void Excluir(int codigo)
        {
            if(codigo<1)
            {
                throw new Exception("Selecione um clientes antes de excluí-lo!");
            }

            ClienteDAL obj = new ClienteDAL();
            obj.Excluir(codigo);
        }

        public DataTable Listagem()
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.Listagem();
        }
    }
}
