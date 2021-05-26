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
        private ClienteNegocio _clienteNegocio;
        private Cliente _clienteSeleccionado;

        public FormPedirCliente()
        {
            InitializeComponent();
            _clienteNegocio = new ClienteNegocio();
            _clienteSeleccionado = new Cliente();
        }
        
        private void FormPedirCliente_Load(object sender, EventArgs e)
        {
            _clienteSeleccionado = null;
            CargarLista();
        }

        private void CargarLista()
        {
            try
            {
                lstClientes.DataSource = null;
                lstClientes.DataSource = _clienteNegocio.Traer();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void lstClientes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstClientes.DataSource != null)
            {
                this._clienteSeleccionado = (Cliente)lstClientes.SelectedValue;
                lblNombreCliente.Text = _clienteSeleccionado.Nombre;
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            FormCuentas frmCuentas = new FormCuentas(this._clienteSeleccionado);
            frmCuentas.Owner = this;
            this.Hide();
            frmCuentas.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
