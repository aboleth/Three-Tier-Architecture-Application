using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Loja.BLL;
using Loja.DAL;
using Loja.Modelos;

namespace Loja.UIWindows
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        public void AtualizaGrid ()
        {
            // Comunicação com a camada BLL
            ClienteBLL obj = new ClienteBLL();
            datagridCliente.DataSource = obj.Listagem();

            // Atualizando os objetos TextBox
            txtboxCodigo.Text = datagridCliente[0, datagridCliente.CurrentRow.Index].Value.ToString();
            txtboxNome.Text = datagridCliente[1, datagridCliente.CurrentRow.Index].Value.ToString();
            txtboxEmail.Text = datagridCliente[2, datagridCliente.CurrentRow.Index].Value.ToString();
            txtboxTelefone.Text = datagridCliente[3, datagridCliente.CurrentRow.Index].Value.ToString();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
            txtboxNome.Focus();
        }
        
        private void txtboxTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLer_Click(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtboxCodigo.Text = "";
            txtboxEmail.Text = "";
            txtboxNome.Text = "";
            txtboxTelefone.Text = "";
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Nome = txtboxNome.Text;
                cliente.Email = txtboxEmail.Text;
                cliente.Telefone = txtboxTelefone.Text;

                ClienteBLL obj = new ClienteBLL();
                obj.incluir(cliente);

                MessageBox.Show("O cliente foi incluído com sucesso!");
                txtboxCodigo.Text = Convert.ToString(cliente.Codigo);
                AtualizaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if(txtboxCodigo.Text.Length == 0)
            {
                MessageBox.Show("Um cliente deve ser selecionado para alteração.");
            }
            else
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.Codigo = int.Parse(txtboxCodigo.Text);
                    cliente.Nome = txtboxNome.Text;
                    cliente.Email = txtboxEmail.Text;
                    cliente.Telefone = txtboxTelefone.Text;

                    ClienteBLL obj = new ClienteBLL();
                    obj.Alterar(cliente);
                    MessageBox.Show("O cliente foi alterado com sucesso!");
                    AtualizaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtboxCodigo.Text.Length == 0)
            {
                MessageBox.Show("Um cliente deve ser selecionado antes da exclusão.");
            }
            else
            {
                try
                {
                    int codigo = Convert.ToInt32(txtboxCodigo.Text);

                    ClienteBLL obj = new ClienteBLL();
                    obj.Excluir(codigo);
                    MessageBox.Show("O cliente foi excluído com sucesso!");
                    AtualizaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void datagridCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Atualizando os objetos TextBox
            txtboxCodigo.Text = datagridCliente[0, datagridCliente.CurrentRow.Index].Value.ToString();
            txtboxNome.Text = datagridCliente[1, datagridCliente.CurrentRow.Index].Value.ToString();
            txtboxEmail.Text = datagridCliente[2, datagridCliente.CurrentRow.Index].Value.ToString();
            txtboxTelefone.Text = datagridCliente[3, datagridCliente.CurrentRow.Index].Value.ToString();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
