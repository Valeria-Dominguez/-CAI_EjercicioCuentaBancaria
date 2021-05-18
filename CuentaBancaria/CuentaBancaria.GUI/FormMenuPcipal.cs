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
    public partial class FormMenuPcipal : Form
    {
        SucBanco sucursal1;
        public FormMenuPcipal()
        {
            sucursal1 = new SucBanco(1, "Sucursal 1 Banco", "Calle 1234", "12345678", "Nombre Encargado");
            InitializeComponent();
        }

        private void FormMenuPcipal_Load(object sender, EventArgs e)
        {
            lblNombreSucBanco.Text = $"{sucursal1.Nombre} - {sucursal1.Domicilio}";
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes frmClientes = new FormClientes(sucursal1);
            frmClientes.Owner = this;
            frmClientes.Show();
            this.Hide();
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            FormPedirCliente FrmPedirCliente = new FormPedirCliente(sucursal1);
            FrmPedirCliente.Owner = this;
            FrmPedirCliente.Show();
            this.Hide();
        }
    }
}
