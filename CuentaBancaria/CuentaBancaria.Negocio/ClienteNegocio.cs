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
        private List<Cuenta> _listaCuentas;
        private ClienteMapper _clienteMapper;
        private CuentaMapper _cuentaMapper;

        public ClienteNegocio()
        {
            _listaClientes = new List<Cliente>();
            _listaCuentas = new List<Cuenta>();
            _clienteMapper = new ClienteMapper();
            _cuentaMapper = new CuentaMapper();
        }

        public List<Cliente> Traer()
        {
            _listaCuentas = _cuentaMapper.TraerTodos();

            List<Cliente> todos = _clienteMapper.TraerTodos();
            foreach (Cliente cliente in todos)
            {
                if (ValidarParametros(cliente) == true)
                    _listaClientes.Add(cliente);

                AgregarCuentaCliente(cliente);
            }

            if (_listaClientes.Count == 0) throw new Exception("No existen clientes");
            return _listaClientes;
        }

        private Cliente AgregarCuentaCliente(Cliente cliente)
        {
            foreach (Cuenta cuenta in _listaCuentas)
            {
                if (cliente.Id == cuenta.IdCliente)
                    cliente.Cuenta = cuenta;
            }
            return cliente;
        }

        private bool ValidarParametros(Cliente cliente)
        {
            bool valido = true;            
            if (
                cliente.Id == 0                  
                )
                valido = false;               

            if (string.IsNullOrEmpty(cliente.Nombre)) cliente.Nombre = string.Empty;
            if (string.IsNullOrEmpty(cliente.Apellido)) cliente.Apellido = string.Empty;
            if (string.IsNullOrEmpty(cliente.Domicilio)) cliente.Domicilio = string.Empty;
            if (string.IsNullOrEmpty(cliente.NumeroTel)) cliente.NumeroTel = string.Empty;
            if (string.IsNullOrEmpty(cliente.Email)) cliente.Email = string.Empty;
            if (cliente.FechaNacimiento == null) cliente.FechaNacimiento = DateTime.Parse("01/01/0001 00:00:00");

            return valido;
        }

        public TransactionResult Agregar(int dni, string nombre, string apellido, string domicilio, string telefono, string email, DateTime fechaNacimiento)
        {
            BuscarCliente(dni);   
            Cliente cliente = new Cliente();
            cliente.Dni = dni;
            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
            cliente.Domicilio = domicilio;
            cliente.NumeroTel = telefono;
            cliente.Email = email;
            cliente.FechaNacimiento = fechaNacimiento;
            cliente.Usuario = "847004";
            TransactionResult c = _clienteMapper.Insertar(cliente);
            return c;
        }

        private void BuscarCliente(int dni)
        {
            foreach (Cliente cliente in _clienteMapper.TraerTodos())
            {
                if (cliente.Dni==dni)
                    throw new Exception("El cliente ya existe");
            }
        }

        public TransactionResult Modificar(int id, int dni, string nombre, string apellido, string domicilio, string telefono, string email, DateTime fechaNacimiento)
        {
            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente.Dni = dni;
            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
            cliente.Domicilio = domicilio;
            cliente.NumeroTel = telefono;
            cliente.Email = email;
            cliente.FechaNacimiento = fechaNacimiento;
            TransactionResult c = _clienteMapper.Modificar(cliente);
            return c;
        }

        public TransactionResult Eliminar(Cliente cliente)
        {
            BuscarCuentasCliente(cliente.Id);
            TransactionResult c = _clienteMapper.Eliminar(cliente);
            return c;
        }

        private void BuscarCuentasCliente(int id)
        {
            Cuenta cuentaCliente = _cuentaMapper.TraerCuentaCliente(id);
            if (cuentaCliente != null)
                throw new Exception("El cliente no puede eliminarse, posee cuentas a su nombre");
        }


    }
}
