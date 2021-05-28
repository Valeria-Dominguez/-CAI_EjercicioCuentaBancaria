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
        private Cliente _clienteSeleccionado; 

        public FormCuentas(Cliente cliente)
        {
            _cuentaNegocio = new CuentaNegocio();
            _clienteSeleccionado = cliente;
            InitializeComponent();
        }
                
        private void FormCuentas_Load(object sender, EventArgs e)
        {
            if (_clienteSeleccionado != null)
            {
                lbIdCliente.Text = $"{_clienteSeleccionado.Nombre} - {_clienteSeleccionado.Id}";
                CargarLista();
                LimpiarCampos();
            }
        }

        private void CargarLista()
        {
            try
            {
                lstCuentas.DataSource = null;
                lstCuentas.DataSource = _cuentaNegocio.TraerCuentasCliente(_clienteSeleccionado.Id);
                //lstCuentas.DataSource = _cuentaNegocio.Traer();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNumCuenta.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            chkEstadoActiva.Checked = false;
            txtSaldo.Text = string.Empty;
        }

        private void lstCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCamposCuenta();
        }

        private void CargarCamposCuenta()
        {
            if (lstCuentas.DataSource != null)
            {
                Cuenta cuentaSeleccionada = (Cuenta)lstCuentas.SelectedValue;
                txtNumCuenta.Text = cuentaSeleccionada.Numero.ToString();
                txtDescripcion.Text = cuentaSeleccionada.Tipo;
                if (cuentaSeleccionada.Activa == true) { chkEstadoActiva.Checked = true; }
                txtSaldo.Text = cuentaSeleccionada.Saldo.ToString();

                DeshabilitarEdicion();
            }
        }

        private void DeshabilitarEdicion()
        {
            txtDescripcion.Enabled = false;
        }

        private void btnAltaCuenta_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarEdicion();
        }

        private void HabilitarEdicion()
        {
            txtDescripcion.Enabled = true;
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                TransactionResult resultado =  _cuentaNegocio.Agregar(_clienteSeleccionado.Id, txtDescripcion.Text);
                MessageBox.Show(resultado.ToString());
                CargarLista();
                LimpiarCampos();
                DeshabilitarEdicion();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message);
            }
        }

        private void ValidarCampos()
        {
            if (
                txtDescripcion.Text == string.Empty  
                )
                throw new Exception("Ningún campo puede estar vacío");
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
                _cuentaNegocio.ModificarSaldo(cuentaSeleccionada.Id, cuentaSeleccionada.Saldo);
                MessageBox.Show($"Transacción exitosa");
                LimpiarCampos();
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
        private void ActivarODesactivarCuenta(bool activa)
        {
            try
            {
                Cuenta cuentaSeleccionada = (Cuenta)lstCuentas.SelectedValue;
                if (cuentaSeleccionada == null) { throw new Exception("Debe seleccionar una cuenta"); }
                _cuentaNegocio.ModificarEstado(cuentaSeleccionada.Id, activa);
                MessageBox.Show($"Modificación exitosa");
                LimpiarCampos();
                CargarLista();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        //visible: false
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cuenta cuentaSeleccionada = (Cuenta)lstCuentas.SelectedValue;
                if (cuentaSeleccionada == null) { throw new Exception("Debe seleccionar una cuenta"); }
                _cuentaNegocio.Eliminar(cuentaSeleccionada.Id);
                MessageBox.Show($"Cuenta eliminada");
                CargarLista();
                LimpiarCampos();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
        
    }
}
