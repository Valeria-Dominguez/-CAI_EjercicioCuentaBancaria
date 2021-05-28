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
                lstClientes.DataSource = null;
                lstClientes.DataSource = _clienteNegocio.Traer();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
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
            CargarCamposCliente();
        }

        private void CargarCamposCliente()
        {
            if (lstClientes.DataSource != null)
            {
                Cliente clienteSeleccionado = (Cliente)lstClientes.SelectedValue;

                txtIdCliente.Text = clienteSeleccionado.Id.ToString();
                txtDni.Text = clienteSeleccionado.Dni.ToString();
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
                TransactionResult resultado = _clienteNegocio.Agregar(int.Parse(txtDni.Text), txtNombre.Text, txtDomicilio.Text, txtTelefono.Text, txtEmail.Text);
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
                Cliente clienteSeleccionado = (Cliente)lstClientes.SelectedValue;
                if (clienteSeleccionado.Id.ToString() != txtIdCliente.Text) { throw new Exception("No puede modificarse el ID"); }

                ValidarCampos();
                _clienteNegocio.Modificar(int.Parse(txtIdCliente.Text), int.Parse(txtDni.Text), txtNombre.Text, txtDomicilio.Text, txtTelefono.Text, txtEmail.Text);
                MessageBox.Show("Cliente modificado");
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
                _clienteNegocio.Eliminar(clienteSeleccionado.Id);
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
                txtDni.Text == string.Empty ||
                txtNombre.Text == string.Empty ||
                txtDomicilio.Text == string.Empty ||
                txtTelefono.Text == string.Empty ||
                txtEmail.Text == string.Empty
                )
                throw new Exception("Ningún campo puede estar vacío");
            else if (
                !int.TryParse(txtDni.Text, out int dni) 
                )
                throw new Exception("DNI : Debe ingresar un dni");
        }

        private void LimpiarCampos()
        {
            txtIdCliente.Text = string.Empty;
            txtDni.Text = string.Empty;
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
