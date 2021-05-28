﻿using System;
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
        private List<Cuenta> _cuentasValidadas;
        private CuentaMapper _cuentaMapper;

        public CuentaNegocio()
        {
            _listaCuentas = new List<Cuenta>();
            _cuentasValidadas = new List<Cuenta>();
            _cuentaMapper = new CuentaMapper();
        }

        public List<Cuenta> Traer()
        {
            _listaCuentas = _cuentaMapper.TraerTodos();
            _cuentasValidadas = ValidarCuentas(_listaCuentas);
            if (_cuentasValidadas.Count == 0) throw new Exception("No existen cuentas");
            return _cuentasValidadas;
        }

        private List<Cuenta> ValidarCuentas(List<Cuenta> todas)
        {
            List<Cuenta> cuentasValidadas = new List<Cuenta>();
            foreach (Cuenta cuenta in todas)
            {
                if (ValidarParametros(cuenta) == true )
                    cuentasValidadas.Add(cuenta);
            }
            return cuentasValidadas;
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
            _cuentasValidadas = Traer();
            foreach (Cuenta cuenta in _cuentasValidadas)
            {
                if (cuenta.IdCliente == idCliente)
                    cuentasCliente.Add(cuenta);
            }
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

        public TransactionResult ModificarEstado(int id, bool activo)
        {
            Cuenta cuenta = new Cuenta();
            cuenta.Id = id;
            cuenta.Activa = activo;
            TransactionResult resultado = _cuentaMapper.Modificar(cuenta);
            return resultado;
        }

        public TransactionResult ModificarSaldo(int id, double saldo)
        {
            Cuenta cuenta = new Cuenta();
            cuenta.Id = id;
            cuenta.Saldo = saldo;
            TransactionResult resultado = _cuentaMapper.Modificar(cuenta);
            return resultado;
        }

        public TransactionResult Eliminar(int id)
        {
            Cuenta cuenta = new Cuenta();
            cuenta.Id = id;
            TransactionResult resultado = _cuentaMapper.Eliminar(cuenta);
            return resultado;
        }

    }
}
