using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Loja.Modelos;
using Loja.DAL;

namespace Loja.DAL
{
    public class VendaDAL
    {
        public DataTable ListaProduto
        {
            get
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = Dados.StringDeConexao;
                cn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Produto", cn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                cn.Close();
                return dt;
            }
        }
        
        public DataTable ListaCliente
        {
            get
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = Dados.StringDeConexao;
                cn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Cliente", cn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                cn.Close();
                return dt;
            }
        }

        public void Incluir(Venda venda)
        {
            // Conexao com SQL
            SqlConnection cn = new SqlConnection();
            SqlTransaction t = null;

            try
            {
                cn.ConnectionString = Dados.StringDeConexao;
                // Comandos ao SQL
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = cn;
                cmd1.CommandText = @"INSERT INTO Venda (codigoCliente,codigoProduto,data,quantidade,faturado) VALUES (@codigoCliente,@codigoProduto,@data,@quantidade,@faturado); SELECT @@IDENTITY;";
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = cn;
                cmd2.CommandText = @"UPDATE Produto SET estoque = estoque - @quantidade WHERE codigo = @codigoProduto";
                cn.Open();

                t = cn.BeginTransaction(IsolationLevel.Serializable); // Padrão
                cmd1.Transaction = t;
                cmd2.Transaction = t;
                cmd1.Parameters.AddWithValue("@codigoCliente", venda.CodigoCliente);
                cmd1.Parameters.AddWithValue("@codigoProduto", venda.CodigoProduto);
                cmd1.Parameters.AddWithValue("@data", venda.Data);
                cmd1.Parameters.AddWithValue("@quantidade", venda.Quantidade);
                cmd1.Parameters.AddWithValue("@faturado", venda.Faturado);
                cmd2.Parameters.AddWithValue("@quantidade", venda.Quantidade);
                cmd2.Parameters.AddWithValue("@codigoProduto", venda.CodigoProduto);
                cmd2.ExecuteNonQuery();

                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                throw new Exception("Erro no Servidor:" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
