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
        public FormMenuPcipal()
        {
            InitializeComponent();
        }

        private void FormMenuPcipal_Load(object sender, EventArgs e)
        {
            lblTituloMenuPcipal.Text = "Menú principal";
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes frmClientes = new FormClientes();
            frmClientes.Owner = this;
            frmClientes.Show();
            this.Hide();
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            FormPedirCliente FrmPedirCliente = new FormPedirCliente();
            FrmPedirCliente.Owner = this;
            FrmPedirCliente.Show();
            this.Hide();
        }
    }
}
