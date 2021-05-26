
namespace CuentaBancaria.GUI
{
    partial class FormCuentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregarCuenta = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAltaCuenta = new System.Windows.Forms.Button();
            this.lstCuentas = new System.Windows.Forms.ListBox();
            this.lbIdCliente = new System.Windows.Forms.Label();
            this.chkEstadoActiva = new System.Windows.Forms.CheckBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDepositar = new System.Windows.Forms.Button();
            this.btnExtraer = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(742, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Numero";
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.Enabled = false;
            this.txtNumCuenta.Location = new System.Drawing.Point(427, 70);
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.ReadOnly = true;
            this.txtNumCuenta.Size = new System.Drawing.Size(359, 20);
            this.txtNumCuenta.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(428, 109);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(358, 20);
            this.txtDescripcion.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(723, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(559, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Estado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cuenta";
            // 
            // btnAgregarCuenta
            // 
            this.btnAgregarCuenta.Location = new System.Drawing.Point(542, 201);
            this.btnAgregarCuenta.Name = "btnAgregarCuenta";
            this.btnAgregarCuenta.Size = new System.Drawing.Size(61, 23);
            this.btnAgregarCuenta.TabIndex = 12;
            this.btnAgregarCuenta.Text = "Aceptar";
            this.btnAgregarCuenta.UseVisualStyleBackColor = true;
            this.btnAgregarCuenta.Click += new System.EventHandler(this.btnAgregarCuenta_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 355);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 15;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.Location = new System.Drawing.Point(652, 238);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(67, 23);
            this.btnActivar.TabIndex = 13;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(652, 317);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(140, 23);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Baja";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAltaCuenta
            // 
            this.btnAltaCuenta.Location = new System.Drawing.Point(428, 201);
            this.btnAltaCuenta.Name = "btnAltaCuenta";
            this.btnAltaCuenta.Size = new System.Drawing.Size(110, 23);
            this.btnAltaCuenta.TabIndex = 17;
            this.btnAltaCuenta.Text = "Alta Cuenta";
            this.btnAltaCuenta.UseVisualStyleBackColor = true;
            this.btnAltaCuenta.Click += new System.EventHandler(this.btnAltaCuenta_Click);
            // 
            // lstCuentas
            // 
            this.lstCuentas.FormattingEnabled = true;
            this.lstCuentas.Location = new System.Drawing.Point(12, 12);
            this.lstCuentas.Name = "lstCuentas";
            this.lstCuentas.Size = new System.Drawing.Size(391, 212);
            this.lstCuentas.TabIndex = 0;
            this.lstCuentas.SelectedIndexChanged += new System.EventHandler(this.lstCuentas_SelectedIndexChanged);
            // 
            // lbIdCliente
            // 
            this.lbIdCliente.AutoSize = true;
            this.lbIdCliente.Location = new System.Drawing.Point(712, 12);
            this.lbIdCliente.Name = "lbIdCliente";
            this.lbIdCliente.Size = new System.Drawing.Size(76, 13);
            this.lbIdCliente.TabIndex = 18;
            this.lbIdCliente.Text = "NombreCliente";
            // 
            // chkEstadoActiva
            // 
            this.chkEstadoActiva.AutoSize = true;
            this.chkEstadoActiva.Enabled = false;
            this.chkEstadoActiva.Location = new System.Drawing.Point(728, 132);
            this.chkEstadoActiva.Name = "chkEstadoActiva";
            this.chkEstadoActiva.Size = new System.Drawing.Size(56, 17);
            this.chkEstadoActiva.TabIndex = 10;
            this.chkEstadoActiva.Text = "Activa";
            this.chkEstadoActiva.UseVisualStyleBackColor = true;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(609, 154);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(177, 20);
            this.txtSaldo.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(559, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Saldo";
            // 
            // btnDepositar
            // 
            this.btnDepositar.Location = new System.Drawing.Point(652, 290);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(139, 23);
            this.btnDepositar.TabIndex = 18;
            this.btnDepositar.Text = "Depositar saldo";
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // btnExtraer
            // 
            this.btnExtraer.Location = new System.Drawing.Point(652, 263);
            this.btnExtraer.Name = "btnExtraer";
            this.btnExtraer.Size = new System.Drawing.Size(140, 23);
            this.btnExtraer.TabIndex = 19;
            this.btnExtraer.Text = "Extraer saldo";
            this.btnExtraer.UseVisualStyleBackColor = true;
            this.btnExtraer.Click += new System.EventHandler(this.btnExtraer_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Location = new System.Drawing.Point(725, 238);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(67, 23);
            this.btnDesactivar.TabIndex = 23;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // FormCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 390);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnExtraer);
            this.Controls.Add(this.btnDepositar);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkEstadoActiva);
            this.Controls.Add(this.lbIdCliente);
            this.Controls.Add(this.lstCuentas);
            this.Controls.Add(this.btnAltaCuenta);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAgregarCuenta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumCuenta);
            this.Controls.Add(this.label1);
            this.Name = "FormCuentas";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormCuentas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarCuenta;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAltaCuenta;
        private System.Windows.Forms.ListBox lstCuentas;
        private System.Windows.Forms.Label lbIdCliente;
        private System.Windows.Forms.CheckBox chkEstadoActiva;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDepositar;
        private System.Windows.Forms.Button btnExtraer;
        private System.Windows.Forms.Button btnDesactivar;
    }
}