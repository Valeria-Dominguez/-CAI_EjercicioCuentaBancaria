using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria.Entidades
{
    public class Cuenta
    {
        int _numero;
        string _tipo;
        string _moneda;
        bool _activa;
        double _saldo;

        public int Numero { get => _numero; set => _numero = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public string Moneda { get => _moneda; set => _moneda = value; }
        public bool Activa { get => _activa; set => _activa = value; }
        public double Saldo { get => _saldo; }

        public Cuenta(int numero, string tipo, string moneda, bool activa, double saldo)
        {
            this._numero = numero;
            this._tipo = tipo;
            this._moneda = moneda;
            this._activa = activa;
            this._saldo = saldo;
        }

        public override string ToString()
        {
            return $"{this._tipo}/{this.Moneda} - N° {this.Numero}\n";
        }

        public void ExtraerODepositarSaldo()
        {
            double montoDepOExtr = this._saldo;
            this._saldo = _saldo - montoDepOExtr;
        }
    }
}
