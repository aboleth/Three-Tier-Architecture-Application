using System;
using System.Collections.Generic;
using System.Text;
using Loja.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace Loja.DAL
{
    public class ClienteDAL
    {
        public void Incluir (Cliente cliente)
        {
            // Conexão com SQL
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Dados.StringDeConexao;

                //Comandos ao SQL
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO Cliente(nome,email,telefone) VALUES (@nome,@email,@telefone); SELECT @@IDENTITY;";
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                cn.Open();
                cliente.Codigo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Alterar (Cliente cliente)
        {
            // Conexão com SQL
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Dados.StringDeConexao;

                // Comandos ao SQL
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE Cliente SET nome = @nome, email = @email, telefone = @telefone where codigo = @codigo;";
                cmd.Parameters.AddWithValue("@codigo", cliente.Codigo);
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                cn.Open();
                cmd.ExecuteNonQuery();
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
                cmd.CommandText = "delete from Cliente where codigo = " + codigo;
                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o cliente " + codigo);
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

            SqlDataAdapter da = new SqlDataAdapter("select * from Cliente", Dados.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }

        public bool CheckEmail(String email)
        {
            // Conexão com SQL
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Dados.StringDeConexao;

                // Comandos ao SQL
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT COUNT(email) FROM Cliente WHERE @email=email; SELECT @@IDENTITY;";
                cmd.Parameters.AddWithValue("@email", email);
                cn.Open();

                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number);
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
    }
}
