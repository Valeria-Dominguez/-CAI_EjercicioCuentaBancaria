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
using CuentaBancaria.Entidades.Modelos;

namespace CuentaBancaria.GUI
{
    public partial class FormClientes : Form
    {
        private ClienteNegocio _clienteNegocio;

        public FormClientes()
        {
            InitializeComponent();
            _clienteNegocio = new ClienteNegocio();
        }

        private void FormListaClientes_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            try
            {
                LimpiarLista();
                lstClientes.DataSource = _clienteNegocio.Traer();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
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
            try
            {
                CargarLista();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
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
                txtTelefono.Text = clienteSeleccionado.NumeroTel.ToString();
                txtEmail.Text = clienteSeleccionado.Email;
            }
        }

        
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                TransactionResult resultado = _clienteNegocio.Agregar(txtNombre.Text, txtDomicilio.Text, txtTelefono.Text, txtEmail.Text);
                MessageBox.Show(resultado.ToString());
                LimpiarCampos();
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

                ValidarCampos();
                clienteModificado = new Cliente(txtIdCliente.Text, txtNombre.Text, txtDomicilio.Text, txtTelefono.Text, txtEmail.Text);
                //_clienteNegocio.ModificarCliente(clienteModificado, clienteSeleccionado);
                MessageBox.Show("Cliente modificado:");
                LimpiarCampos();
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
                //_clienteNegocio.EliminarCliente(clienteSeleccionado);
                MessageBox.Show($"Cliente eliminado");
                LimpiarCampos();
                CargarLista();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }       


        private void ValidarCampos()
        {
            if (
                txtNombre.Text == string.Empty ||
                txtDomicilio.Text == string.Empty ||
                txtTelefono.Text == string.Empty ||
                txtEmail.Text == string.Empty
                )

                throw new Exception("Ningún campo puede estar vacío");
            else if (
                !int.TryParse(txtTelefono.Text, out int tel)
                )
                throw new Exception("Teléfono : Debe ingresar un número");
        }

        private void LimpiarCampos()
        {
            txtIdCliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

    }
}
