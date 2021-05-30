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
                LimpiarCampos();
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
                txtApellido.Text = clienteSeleccionado.Apellido;
                txtEmail.Text = clienteSeleccionado.Email;
                txtFechaNacim.Text = clienteSeleccionado.FechaNacimiento.ToString("dd/MM/yyyy");
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
                TransactionResult resultado = _clienteNegocio.Agregar(int.Parse(txtDni.Text), txtNombre.Text, txtApellido.Text, txtDomicilio.Text, txtTelefono.Text, txtEmail.Text, DateTime.Parse(txtFechaNacim.Text + " 00:00:00"));
                MessageBox.Show(resultado.ToString());
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

                ValidarCampos();
                TransactionResult resultado = _clienteNegocio.Modificar(clienteSeleccionado.Id, int.Parse(txtDni.Text), txtNombre.Text, txtApellido.Text, txtDomicilio.Text, txtTelefono.Text, txtEmail.Text, DateTime.Parse(txtFechaNacim.Text + " 00:00:00"));
                
                MessageBox.Show(resultado.ToString());
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
                TransactionResult resultado = _clienteNegocio.Eliminar(clienteSeleccionado);
                MessageBox.Show(resultado.ToString());
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
            if (
                !int.TryParse(txtDni.Text, out int dni) 
                )
                throw new Exception("DNI : Debe ingresar un dni");
            if (
                !DateTime.TryParse(txtFechaNacim.Text + " 00:00:00", out DateTime fecha)
                )
                throw new Exception("Fecha inválida");
        }

        private void LimpiarCampos()
        {
            txtIdCliente.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtFechaNacim.Text = string.Empty;
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
