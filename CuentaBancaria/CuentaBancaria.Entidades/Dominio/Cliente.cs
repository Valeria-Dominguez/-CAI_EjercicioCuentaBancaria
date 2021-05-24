using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria.Entidades
{
    [DataContract]

    public class Cliente:Persona
    {
        List<Cuenta> _cuentas;

        public List<Cuenta> Cuentas { get => _cuentas; set => _cuentas = value; }

        public Cliente(string id, string nombre, string domicilio, string numeroTel, string email) : base(id, nombre, domicilio, numeroTel, email)
        {
            this._cuentas = new List<Cuenta>();
        }
        public Cliente()
        {
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (!(obj is Cliente))
            {
                return false;
            }
            else
            {
                Cliente cliente = (Cliente)obj;
                return cliente.Id == this.Id;
            }
        }

        public void GuardarCuenta(Cuenta cuenta)
        {
            this._cuentas.Add(cuenta);
        }

        public void EliminarCuenta(Cuenta cuenta)
        {
            if (cuenta.Saldo!=0)
            {
                throw new Exception("No puede darse de baja una cuenta con saldo");
            }
            this._cuentas.Remove(cuenta);
        }

        public void CambiarEstadoCuenta(Cuenta cuenta, bool nuevoEstado)
        {
            cuenta.Activa = nuevoEstado;
        }


    }
}
