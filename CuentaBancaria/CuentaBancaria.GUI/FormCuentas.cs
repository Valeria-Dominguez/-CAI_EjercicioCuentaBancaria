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
using CuentaBancaria.Entidades.Modelos;
using CuentaBancaria.Negocio;

namespace CuentaBancaria.GUI
{
    public partial class FormCuentas : Form
    {
        private CuentaNegocio _cuentaNegocio;
        private ClienteNegocio _clienteNegocio;
        private Cliente _clienteSeleccionado; 

        public FormCuentas()
        {
            _cuentaNegocio = new CuentaNegocio();
            _clienteNegocio = new ClienteNegocio();
            InitializeComponent();
        }
                
        private void FormCuentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                cmbClientes.DataSource = null;
                cmbClientes.DataSource = _clienteNegocio.Traer();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.DataSource != null)
            {
                CargarCamposCuenta();
            }
        }

        private void CargarCamposCuenta()
        {
            Cuenta cuenta = ((Cliente)cmbClientes.SelectedValue).Cuenta;
            if (cuenta!= null)
            {
                txtNumCuenta.Text = cuenta.Numero.ToString();
                txtDescripcion.Text = cuenta.Tipo;
                chkEstadoActiva.Checked = cuenta.Activa;
                //if (cuenta.Activa == true) { chkEstadoActiva.Checked = true; } else { chkEstadoActiva.Checked = false; }
                txtSaldo.Text = cuenta.Saldo.ToString("0.00");
                txtFechaApertura.Text = cuenta.FechaApertura.ToString("yyyy-MM-dd");
                txtDescripcion.Enabled = false;
                txtSaldo.Enabled = true;
            }
            else
            {
                LimpiarCampos();
                txtDescripcion.Enabled = true;
                txtSaldo.Enabled = false;
            }
        }

        private void LimpiarCampos()
        {
            txtNumCuenta.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            chkEstadoActiva.Checked = false;
            txtSaldo.Text = string.Empty;
            txtFechaApertura.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteSeleccionado = (Cliente)cmbClientes.SelectedItem;

                if (clienteSeleccionado.Cuenta == null)
                {
                    ValidarCamposAlta();
                    AltaCuenta(clienteSeleccionado);
                }

                else
                {
                    ValidarCamposModificacion();
                    ModificarSaldo(clienteSeleccionado);
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message);
            }
        }
        private void ValidarCamposAlta()
        {
            if (
                txtDescripcion.Text == string.Empty
                )
                throw new Exception("Debe ingresar una descripción");
        }
        private void ValidarCamposModificacion()
        {
            if (
                !(double.TryParse(txtSaldo.Text, out double valor))
                )
                throw new Exception("Saldo : Debe ingresar un número");
        }

        private void AltaCuenta(Cliente clienteSeleccionado)
        {
            clienteSeleccionado.Cuenta = _cuentaNegocio.Agregar(clienteSeleccionado.Id, txtDescripcion.Text);
            cmbClientes.SelectedIndex = 0;
            MessageBox.Show("Cuenta agregada");
        }

        private void ModificarSaldo(Cliente clienteSeleccionado)
        {
            clienteSeleccionado.Cuenta.Saldo = double.Parse(txtSaldo.Text);
            clienteSeleccionado.Cuenta = _cuentaNegocio.Modificar(clienteSeleccionado.Cuenta);
            cmbClientes.SelectedIndex = 0;
            MessageBox.Show("Cuenta actualizada");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }


        //Btn activar / desactivar: visible = false
        //No se puede modificar estado

        /*
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            bool activa = false;
            ModificarEstado(activa);
        }
        private void btnActivar_Click(object sender, EventArgs e)
        {
            bool activa = true;
            ModificarEstado(activa);
        }
        private void ModificarEstado(bool activa)
        {
            try
            {
                Cliente ClienteSeleccionado = (Cliente)cmbClientes.SelectedValue;
                if (ClienteSeleccionado.Cuenta == null) { throw new Exception("El cliente no posee cuentas"); }

                else
                {
                    ClienteSeleccionado.Cuenta.Activa = activa;
                    ClienteSeleccionado.Cuenta = _cuentaNegocio.Modificar(ClienteSeleccionado.Cuenta);
                    cmbClientes.SelectedIndex = 0;
                    MessageBox.Show("Cuenta actualizada");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        */

    }
}
