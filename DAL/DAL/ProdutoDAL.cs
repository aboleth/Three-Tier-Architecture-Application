using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Loja.Modelos;

namespace Loja.DAL
{
    public class ProdutoDAL
    {
        public ArrayList ProdutosEmFalta()
        {
            SqlConnection cn = new SqlConnection(Dados.StringDeConexao);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Produto WHERE estoque < 10", cn);

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            ArrayList lista = new ArrayList();

            while(dr.Read())
            {
                Produto produto = new Produto();
                produto.Codigo = Convert.ToInt32(dr["codigo"]);
                produto.Nome = dr["nome"].ToString();
                produto.Estoque = Convert.ToInt32(dr["estoque"]);
                produto.Preco = Convert.ToInt32(dr["preco"]);
                lista.Add(produto);
            }

            dr.Close();
            cn.Close();
            return lista;
        }

        public void Incluir (Produto produto)
        {
            // Conexao com SQL
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Dados.StringDeConexao;

                // Comandos ao SQL
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO Produto (nome,preco,estoque) VALUES (@nome,@preco,@estoque); SELECT @@IDENTITY;";
                cmd.Parameters.AddWithValue("@nome", produto.Nome);
                cmd.Parameters.AddWithValue("@preco", produto.Preco);
                cmd.Parameters.AddWithValue("@estoque", produto.Estoque);

                cn.Open();
                produto.Codigo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Alterar (Produto produto)
        {
            // Conexão com SQL
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Dados.StringDeConexao;

                // Comandos ao SQL
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "AlterarProduto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", produto.Codigo);
                cmd.Parameters.AddWithValue("@nome", produto.Nome);
                cmd.Parameters.AddWithValue("@preco", produto.Preco);
                cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                cmd.Parameters.Add("@valorEstoque", SqlDbType.Int);
                cmd.Parameters["@valorEstoque"].Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                decimal valorEstoque = Convert.ToDecimal(cmd.Parameters["@valorEstoque"]);

                if (valorEstoque<500)
                {
                    throw new Exception("Atenção! Valor abaixo no estoque");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Excluir(int codigo)
        {
            // Conexão com SQL
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringDeConexao;

                // Comandos ao SQL
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from Produto where codigo = " + codigo;
                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o produto " + codigo);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public DataTable Listagem()
        {
            DataTable tabela = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select * from Produto", Dados.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }

    }
}
