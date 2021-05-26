using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuentaBancaria.Datos;
using CuentaBancaria.Entidades;
using CuentaBancaria.Entidades.Modelos;

namespace CuentaBancaria.Negocio
{
    public class CuentaNegocio
    {
        private List<Cuenta> _listaCuentas;
        private List<Cuenta> _cuentasFiltradas;
        private CuentaMapper _cuentaMapper;

        public CuentaNegocio()
        {
            _listaCuentas = new List<Cuenta>();
            _cuentasFiltradas = new List<Cuenta>();
            _cuentaMapper = new CuentaMapper();
        }

        public List<Cuenta> Traer()
        {
            _listaCuentas = _cuentaMapper.TraerTodos();
            _cuentasFiltradas = FiltrarCuentas(_listaCuentas);
            if (_cuentasFiltradas.Count == 0) throw new Exception("No existen cuentas");
            return _cuentasFiltradas;
        }

        private List<Cuenta> FiltrarCuentas(List<Cuenta> todas)
        {
            List<Cuenta> cuentasFiltradas = new List<Cuenta>();
            foreach (Cuenta cuenta in todas)
            {
                if (ValidarParametros(cuenta) == true )
                    cuentasFiltradas.Add(cuenta);
            }
            return cuentasFiltradas;
        }

        private bool ValidarParametros(Cuenta cuenta)
        {
            bool valido = true;            
            if (
                cuenta.Numero == 0 ||
                cuenta.Id == 0
                )
                valido = false;

            if (string.IsNullOrEmpty(cuenta.Tipo)) cuenta.Tipo = string.Empty; 

            return valido;
        }
        
        
        public List<Cuenta> TraerCuentasCliente (int idCliente)
        {
            List<Cuenta> cuentasCliente = new List<Cuenta>();
            _cuentasFiltradas = Traer();
            foreach (Cuenta cuenta in _cuentasFiltradas)
            {
                if (cuenta.IdCliente == idCliente)
                    cuentasCliente.Add(cuenta);
            }
            if (cuentasCliente.Count == 0) throw new Exception("No existen cuentas");
            return cuentasCliente;
        }
        

        public TransactionResult Agregar (int idCliente, string descripcion) 
        {
            Cuenta cuenta = new Cuenta();
            cuenta.IdCliente = idCliente;
            cuenta.Tipo = descripcion;
            TransactionResult resultado = _cuentaMapper.Insertar(cuenta);
            return resultado;
        }


    }
}
