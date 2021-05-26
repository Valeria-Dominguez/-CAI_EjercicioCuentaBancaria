using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuentaBancaria.Entidades;
using CuentaBancaria.Datos;
using CuentaBancaria.Entidades.Modelos;

namespace CuentaBancaria.Negocio
{
    public class ClienteNegocio
    {
        private List<Cliente> _listaClientes;
        private ClienteMapper _clienteMapper;

        public ClienteNegocio()
        {
            _listaClientes = new List<Cliente>();
            _clienteMapper = new ClienteMapper();
        }

        public List<Cliente> Traer()
        {
            List<Cliente> todos = _clienteMapper.TraerTodos();
            _listaClientes = FiltrarClientes(todos);
            if (_listaClientes.Count == 0) throw new Exception("No existen clientes");
            return _listaClientes;
        }

        private List<Cliente> FiltrarClientes (List<Cliente> todos)
        {
            List<Cliente> clientesFiltrados = new List<Cliente>();
            foreach (Cliente cliente in todos)
            {
                if (ValidarParametros(cliente) == true)
                    clientesFiltrados.Add(cliente);
            }
            return clientesFiltrados;
        }

        private bool ValidarParametros(Cliente cliente)
        {
            bool valido = true;            
            if (
                cliente.Id == 0                  
                )
                valido = false;               

            if (string.IsNullOrEmpty(cliente.Nombre)) cliente.Nombre = string.Empty;
            if (string.IsNullOrEmpty(cliente.Domicilio)) cliente.Domicilio = string.Empty;
            if (string.IsNullOrEmpty(cliente.NumeroTel)) cliente.NumeroTel = string.Empty;
            if (string.IsNullOrEmpty(cliente.Email)) cliente.Email = string.Empty;

            return valido;
        }

        public TransactionResult Agregar(int dni, string nombre, string domicilio, string telefono, string email)
        {
            BuscarCliente(dni);   
            Cliente cliente = new Cliente();
            cliente.Dni = dni;
            cliente.Nombre = nombre;
            cliente.Domicilio = domicilio;
            cliente.NumeroTel = telefono;
            cliente.Email = email;
            TransactionResult c = _clienteMapper.Insertar(cliente);
            return c;
        }

        private void BuscarCliente(int dni)
        {
            foreach (Cliente cliente in Traer())
            {
                if (cliente.Dni==dni)
                    throw new Exception("El cliente ya existe");
            }
        }


        /*
        public void ModificarCliente(Cliente clienteModificado, Cliente clienteAModificar)
        {
            clienteAModificar.Nombre = clienteModificado.Nombre;
            clienteAModificar.Domicilio = clienteModificado.Domicilio;
            clienteAModificar.NumeroTel = clienteModificado.NumeroTel;
            clienteAModificar.Email = clienteModificado.Email;
        }
        */

        /*
        public void EliminarCliente(Cliente cliente)
        {
            if (cliente.Cuentas.Count != 0)
            {
                throw new Exception("No puede eliminarse, existen cuentas activas");
            }
            this._clientes.Remove(cliente);
        }
        */

    }
}
