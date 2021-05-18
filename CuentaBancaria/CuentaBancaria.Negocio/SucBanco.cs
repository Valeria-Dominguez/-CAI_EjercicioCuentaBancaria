using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuentaBancaria.Entidades;

namespace CuentaBancaria.Negocio
{
    public class SucBanco
    {
        int _numero;
        string _nombre;
        string _domicilio;
        string _telefono;
        string _encargado;
        List<Cliente> _clientes;
        public string Nombre { get => _nombre; } 
        public string Domicilio { get => _domicilio; }
        public List<Cliente> Clientes { get => _clientes; set => _clientes = value; }

        public SucBanco(int numero, string nombre, string domicilio, string telefono, string encargado)
        {
            this._numero = numero;
            this._nombre = nombre;
            this._domicilio = domicilio;
            this._telefono = telefono;
            this._encargado = encargado;
            _clientes = new List<Cliente>();
        }

        public void GuardarCliente(Cliente clienteAgre)
        {
            foreach (Cliente cliente in this._clientes)
            {
                if (cliente.Equals(clienteAgre))
                {
                    throw new Exception("El cliente ya existe");
                }
            }
            this._clientes.Add(clienteAgre);
        }

        public void ModificarCliente(Cliente clienteModificado, Cliente clienteAModificar)
        {
            clienteAModificar.Nombre = clienteModificado.Nombre;
            clienteAModificar.Domicilio = clienteModificado.Domicilio;
            clienteAModificar.NumeroTel = clienteModificado.NumeroTel;
            clienteAModificar.Email = clienteModificado.Email;
        }

        public void EliminarCliente(Cliente cliente)
        {
            if (cliente.Cuentas.Count != 0)
            {
                throw new Exception("No puede eliminarse, existen cuentas activas");
            }
            this._clientes.Remove(cliente);
        }


        public Cliente BuscarCliente(string idCliente)
        {
            Cliente clienteEncontrado = null;
            foreach (Cliente cliente in this._clientes)
            {
                if (cliente.Id == idCliente)
                {
                    clienteEncontrado = cliente;
                }
            }
            if (clienteEncontrado == null)
            {
                throw new Exception("El cliente no existe\n");
            }
            return clienteEncontrado;
        }
    }
}
