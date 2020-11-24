using System;
using System.Windows.Forms;

namespace ConsultaCep
{
    public partial class FrmConsultaCep : Form
    {
        public FrmConsultaCep()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                WSCorreios.AtendeClienteClient correios = new WSCorreios.AtendeClienteClient();
                WSCorreios.enderecoERP endereco = correios.consultaCEP(mtbCep.Text);

                mtbCep.Clear();
                mtbCep.Focus();

                mtbCepReultado.Mask = "00000-000";
                mtbCepReultado.Text = endereco.cep;
                txtEndereco.Text = endereco.end;
                txtBairro.Text = endereco.bairro;
                txtComplemento.Text = endereco.complemento2.TrimStart(new Char[] { '-', ' '});
                txtCidade.Text = endereco.cidade;
                txtUf.Text = endereco.uf;
            }
            catch (Exception)
            {
                mtbCepReultado.Mask = "";
                mtbCepReultado.Clear();
                txtEndereco.Clear();
                txtBairro.Clear();
                txtComplemento.Clear();
                txtCidade.Clear();
                txtUf.Clear();

                MessageBox.Show("Não foi possível realizar a busca, \ntente novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                mtbCep.Clear();
                mtbCep.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
