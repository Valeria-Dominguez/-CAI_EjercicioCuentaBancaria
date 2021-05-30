using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria.Entidades
{
    [DataContract]
    public class Cuenta
    {
        int _id;
        int _idCliente;
        int _numero;
        string _tipo;
        bool _activa;
        double _saldo;
        DateTime _fechaApertura;

        [DataMember(Name ="id")]
        public int Id { get => _id; set => _id = value; }

        [DataMember(Name="idCliente")]
        public int IdCliente { get => _idCliente; set => _idCliente = value; }

        [DataMember(Name ="nroCuenta")]
        public int Numero { get => _numero; set => _numero = value; }

        [DataMember(Name ="descripcion")]
        public string Tipo { get => _tipo; set => _tipo = value; }

        [DataMember(Name ="activo")]
        public bool Activa { get => _activa; set => _activa = value; }

        [DataMember(Name ="saldo")]
        public double Saldo { get => _saldo; set => _saldo = value; }

        [DataMember(Name = "fechaApertura")]
        public DateTime FechaApertura { get => _fechaApertura; set => _fechaApertura = value; }

        public Cuenta(int id, int idCliente, int numero, string tipo, bool activa, double saldo, DateTime fechaApertura)
        {
            this._id = id;
            this._idCliente = idCliente;
            this._numero = numero;
            this._tipo = tipo;
            this._activa = activa;
            this._saldo = saldo;
            this._fechaApertura = fechaApertura;
        }

        public Cuenta ()
        {

        }

        public override string ToString()
        {
            return $"Id: {this.Id} - Tipo: {this._tipo} - N° {this.Numero} / Id Cliente: {this._idCliente}\n";
        }
    }
}
