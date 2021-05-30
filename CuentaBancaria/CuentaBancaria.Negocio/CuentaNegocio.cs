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
        private CuentaMapper _cuentaMapper;

        public CuentaNegocio()
        {
            _listaCuentas = new List<Cuenta>();
            _cuentaMapper = new CuentaMapper();
        }                  

        public Cuenta Agregar (int idCliente, string descripcion) 
        {
            Cuenta cuenta = new Cuenta();
            cuenta.IdCliente = idCliente;
            cuenta.Tipo = descripcion;
            TransactionResult resultado = _cuentaMapper.Insertar(cuenta);
            if (resultado.IsOk)
                return _cuentaMapper.TraerCuentaCliente(idCliente);
            else
                return cuenta = null;
        }

        public Cuenta Modificar(Cuenta cuenta)
        {
            TransactionResult resultado = _cuentaMapper.Insertar(cuenta);
            if (resultado.IsOk)
                return cuenta;
            else
                return _cuentaMapper.TraerCuentaCliente(cuenta.IdCliente);
        }

    }
}
