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
            if (_listaClientes.Count == 0) throw new Exception("Clientes inexistentes");
            return _listaClientes;
        }

        private List<Cliente> FiltrarClientes (List<Cliente> todos)
        {
            List<Cliente> clientesFiltrados = new List<Cliente>();
            foreach (Cliente cliente in todos)
            {
                if (ValidarCampos(cliente) == true)
                    clientesFiltrados.Add(cliente);
            }
            return clientesFiltrados;
        }

        private bool ValidarCampos(Cliente cliente)
        {
            bool valido = true;
            if (
                string.IsNullOrEmpty(cliente.Nombre) ||
                string.IsNullOrEmpty(cliente.Domicilio) ||
                string.IsNullOrEmpty(cliente.NumeroTel) ||
                string.IsNullOrEmpty(cliente.Email) 
                )
                valido = false;
            if (
                cliente.NumeroTel!=null && !int.TryParse(cliente.NumeroTel.ToString(), out int telefono)
                    )
                valido = false;
            return valido;
        }

        public TransactionResult Agregar(string nombre, string domicilio, string telefono, string email)
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = nombre;
            cliente.Domicilio = domicilio;
            cliente.NumeroTel = telefono;
            cliente.Email = email;
            TransactionResult c = _clienteMapper.Insertar(cliente);
            return c;
        }


        /*
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
        */


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


        /*
        public Cliente BuscarCliente(string idCliente)
        {
            Cliente clienteEncontrado = null;
            foreach (Cliente cliente in this._listaClientes)
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
        */
        

    }
}
