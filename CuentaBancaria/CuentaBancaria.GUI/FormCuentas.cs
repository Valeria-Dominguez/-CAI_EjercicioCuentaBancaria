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
    public partial class FormCuentas : Form
    {
        private ClienteNegocio _clienteNegocio;
        private Cliente _clienteSeleccionado;

        public FormCuentas(Cliente cliente)
        {
            _clienteNegocio = new ClienteNegocio();
            _clienteSeleccionado = cliente;
            InitializeComponent();
        }

        
        private void FormCuentas_Load(object sender, EventArgs e)
        {
            lbIdCliente.Text = $"Cliente: {_clienteSeleccionado.Nombre}";
            CargarLista();
            txtSaldo.Enabled = false;
            chkEstadoActiva.Enabled = false;
        }

        private void lstCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarCuentaSeleccionada();
        }

        private void CambiarCuentaSeleccionada()
        {
            if (lstCuentas.DataSource != null)
            {
                DeshabilitarEdicion();
                Cuenta cuentaSeleccionada = (Cuenta)lstCuentas.SelectedValue;
                txtNumCuenta.Text = cuentaSeleccionada.Numero.ToString();
                txtTipo.Text = cuentaSeleccionada.Tipo;
                txtMoneda.Text = cuentaSeleccionada.Moneda;
                if (cuentaSeleccionada.Activa == true) { chkEstadoActiva.Checked = true; }
                txtSaldo.Text = cuentaSeleccionada.Saldo.ToString();
            }
        }

        private void DeshabilitarEdicion()
        {
            txtNumCuenta.Enabled = false;
            txtTipo.Enabled = false;
            txtMoneda.Enabled = false;
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                Cuenta cuenta = null;
                ValidarCampos();
                cuenta = new Cuenta(int.Parse(txtNumCuenta.Text), txtTipo.Text, txtMoneda.Text, false, 0);
                _clienteSeleccionado.GuardarCuenta(cuenta);
                MessageBox.Show($"Cuenta creada");
                Limpiar();
                CargarLista();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cuenta cuentaSeleccionada = (Cuenta)lstCuentas.SelectedValue;
                if (cuentaSeleccionada == null) { throw new Exception("Debe seleccionar una cuenta"); }
                _clienteSeleccionado.EliminarCuenta(cuentaSeleccionada);
                MessageBox.Show($"Cuenta eliminada");
                Limpiar();
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
                txtTipo.Text == string.Empty ||
                txtMoneda.Text == string.Empty
                )
            {
                throw new Exception("Ningún campo puede estar vacío");
            }
            else if (
                !uint.TryParse(txtNumCuenta.Text, out uint numCuenta)
                )
            {
                throw new Exception("Debe ingresar un número");
            }
        }
        private void Limpiar()
        {
            txtNumCuenta.Text = string.Empty;
            txtTipo.Text = string.Empty;
            txtMoneda.Text = string.Empty;
            chkEstadoActiva.Checked = false;
            txtSaldo.Text = string.Empty;

            HabilitarEdicion();
        }

        private void HabilitarEdicion()
        {
            txtNumCuenta.Enabled = true;
            txtTipo.Enabled = true;
            txtMoneda.Enabled = true;
        }

        private void CargarLista()
        {
            LimpiarLista();
            lstCuentas.DataSource = _clienteSeleccionado.Cuentas;
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {

            CargarLista();
        }

        private void LimpiarLista()
        {
            lstCuentas.DataSource = null;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        private void btnExtraer_Click(object sender, EventArgs e)
        {
            ExtraerODepositar();
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            ExtraerODepositar();
        }
        private void ExtraerODepositar()
        {
            try
            {
                Cuenta cuentaSeleccionada = (Cuenta)lstCuentas.SelectedValue;
                if (cuentaSeleccionada == null) { throw new Exception("Debe seleccionar una cuenta"); }
                cuentaSeleccionada.ExtraerODepositarSaldo();
                MessageBox.Show($"Transacción exitosa");
                Limpiar();
                CargarLista();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            bool activa = false;
            ActivarODesactivarCuenta(activa);
        }
        private void btnActivar_Click(object sender, EventArgs e)
        {
            bool activa = true;
            ActivarODesactivarCuenta(activa);
        }
        private void ActivarODesactivarCuenta (bool activa)
        {
            try
            {
                Cuenta cuentaSeleccionada = (Cuenta)lstCuentas.SelectedValue;
                if (cuentaSeleccionada == null) { throw new Exception("Debe seleccionar una cuenta"); }
                _clienteSeleccionado.CambiarEstadoCuenta(cuentaSeleccionada, activa);
                MessageBox.Show($"Modificación exitosa");
                Limpiar();
                CargarLista();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        
    }
}
