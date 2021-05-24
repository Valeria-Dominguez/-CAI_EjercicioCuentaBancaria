
namespace CuentaBancaria.GUI
{
    partial class FormMenuPcipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTituloMenuPcipal = new System.Windows.Forms.Label();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnCuentas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombreSucBanco
            // 
            this.lblTituloMenuPcipal.AutoSize = true;
            this.lblTituloMenuPcipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblTituloMenuPcipal.Location = new System.Drawing.Point(23, 19);
            this.lblTituloMenuPcipal.Name = "lblNombreSucBanco";
            this.lblTituloMenuPcipal.Size = new System.Drawing.Size(48, 17);
            this.lblTituloMenuPcipal.TabIndex = 0;
            this.lblTituloMenuPcipal.Text = "Banco";
            this.lblTituloMenuPcipal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(91, 92);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(170, 23);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCuentas
            // 
            this.btnCuentas.Location = new System.Drawing.Point(91, 130);
            this.btnCuentas.Name = "btnCuentas";
            this.btnCuentas.Size = new System.Drawing.Size(170, 23);
            this.btnCuentas.TabIndex = 2;
            this.btnCuentas.Text = "Cuentas";
            this.btnCuentas.UseVisualStyleBackColor = true;
            this.btnCuentas.Click += new System.EventHandler(this.btnCuentas_Click);
            // 
            // FormMenuPcipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 307);
            this.Controls.Add(this.btnCuentas);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.lblTituloMenuPcipal);
            this.Name = "FormMenuPcipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMenuPcipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloMenuPcipal;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnCuentas;
    }
}

