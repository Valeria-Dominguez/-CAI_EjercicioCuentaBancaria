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
    public partial class FormClientes : Form
    {
        private SucBanco _sucBanco;

        public FormClientes(SucBanco sucBanco)
        {
            _sucBanco = sucBanco;
            InitializeComponent();
        }

        private void FormListaClientes_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            LimpiarLista();
            lstClientes.DataSource = _sucBanco.Clientes;
        }

        private void LimpiarLista()
        {
            lstClientes.DataSource = null;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void lstClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarClienteSeleccionado();
        }

        private void CargarClienteSeleccionado()
        {
            if (lstClientes.DataSource != null)
            {
                Cliente clienteSeleccionado = (Cliente)lstClientes.SelectedValue;
                txtIdCliente.Text = clienteSeleccionado.Id;
                txtNombre.Text = clienteSeleccionado.Nombre;
                txtDomicilio.Text = clienteSeleccionado.Domicilio;
                txtTelefono.Text = clienteSeleccionado.NumeroTel;
                txtEmail.Text = clienteSeleccionado.Email;
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = null;
                ValidarStrings();
                cliente = new Cliente(txtIdCliente.Text, txtNombre.Text, txtDomicilio.Text, txtTelefono.Text, txtEmail.Text);
                _sucBanco.GuardarCliente(cliente);
                MessageBox.Show("Cliente agregado");
                Limpiar();
                CargarLista();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteModificado = null;
                Cliente clienteSeleccionado = (Cliente)lstClientes.SelectedValue;
                if (clienteSeleccionado.Id != txtIdCliente.Text) { throw new Exception("No puede modificarse el ID"); }

                ValidarStrings();
                clienteModificado = new Cliente(txtIdCliente.Text, txtNombre.Text, txtDomicilio.Text, txtTelefono.Text, txtEmail.Text);
                _sucBanco.ModificarCliente(clienteModificado, clienteSeleccionado);
                MessageBox.Show("Cliente modificado:");
                Limpiar();
                CargarLista();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteSeleccionado = (Cliente)lstClientes.SelectedValue;
                _sucBanco.EliminarCliente(clienteSeleccionado);
                MessageBox.Show($"Cliente eliminado");
                Limpiar();
                CargarLista();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void ValidarStrings()
        {
            if (
                txtIdCliente.Text == string.Empty ||
                txtNombre.Text == string.Empty ||
                txtDomicilio.Text == string.Empty ||
                txtTelefono.Text == string.Empty ||
                txtEmail.Text == string.Empty
                )
            {
                throw new Exception("Ningún campo puede estar vacío");
            }
        }

        private void Limpiar()
        {
            txtIdCliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

    }
}
