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
        private List<Cliente> _clientesValidados;
        private ClienteMapper _clienteMapper;

        public ClienteNegocio()
        {
            _listaClientes = new List<Cliente>();
            _clientesValidados = new List<Cliente>();
            _clienteMapper = new ClienteMapper();
        }

        public List<Cliente> Traer()
        {
            _listaClientes = _clienteMapper.TraerTodos();
            _clientesValidados = ValidarClientes(_listaClientes);
            if (_clientesValidados.Count == 0) throw new Exception("No existen clientes");
            return _clientesValidados;
        }

        private List<Cliente> ValidarClientes (List<Cliente> todos)
        {
            List<Cliente> clientesValidados = new List<Cliente>();
            foreach (Cliente cliente in todos)
            {
                if (ValidarParametros(cliente) == true)
                    clientesValidados.Add(cliente);
            }
            return clientesValidados;
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
            //BuscarCliente(dni);   
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

        public TransactionResult Modificar(int id, int dni, string nombre, string domicilio, string telefono, string email)
        {
            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente.Dni = dni;
            cliente.Nombre = nombre;
            cliente.Domicilio = domicilio;
            cliente.NumeroTel = telefono;
            cliente.Email = email;
            TransactionResult c = _clienteMapper.Modificar(cliente);
            return c;
        }

        public TransactionResult Eliminar(int id)
        {
            BuscarCuentasCliente(id);
            Cliente cliente = new Cliente();
            cliente.Id = id;
            TransactionResult c = _clienteMapper.Eliminar(cliente);
            return c;
        }

        private void BuscarCuentasCliente(int id)
        {
            CuentaNegocio cuentaNegocio = new CuentaNegocio();
            List<Cuenta> cuentasClientes = cuentaNegocio.TraerCuentasCliente(id);
            if (cuentasClientes.Count != 0)
                throw new Exception("El cliente no puede eliminarse, posee cuentas");
        }

    }
}
