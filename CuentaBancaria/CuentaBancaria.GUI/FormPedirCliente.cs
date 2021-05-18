using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuentaBancaria.Entidades;
using CuentaBancaria.Negocio;

namespace CuentaBancaria.GUI
{
    public partial class FormPedirCliente : Form
    {
        private SucBanco _sucBanco;
        public FormPedirCliente(SucBanco sucBanco)
        {
            _sucBanco = sucBanco;
            InitializeComponent();
        }

        private void FormPedirCliente_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtIdCliente.Text = string.Empty;
        }

        private void btnAByMCuentas_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = null;
                if (txtIdCliente.Text == string.Empty) { throw new Exception("El campo no puede estar vacío"); }
                cliente = _sucBanco.BuscarCliente(txtIdCliente.Text);
                FormCuentas frmCuentas = new FormCuentas(_sucBanco, cliente);
                frmCuentas.Owner = this;
                frmCuentas.Show();
                this.Hide();
                Limpiar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
