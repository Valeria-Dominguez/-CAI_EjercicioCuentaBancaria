using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria.Entidades
{
    public abstract class Persona
    {
        string _id;
        string _nombre;
        string _domicilio;
        string _numeroTel;
        string _email;

        public string Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Domicilio { get => _domicilio; set => _domicilio = value; }
        public string NumeroTel { get => _numeroTel; set => _numeroTel = value; }
        public string Email { get => _email; set => _email = value; }

        protected Persona(string id, string nombre, string domicilio, string numeroTel, string email)
        {
            this._id = id;
            this._nombre = nombre;
            this._domicilio = domicilio;
            this._numeroTel = numeroTel;
            this._email = email;
        }

        public override string ToString()
        {
            return $" Id: {this._id}\n Nombre y apellido: {this._nombre}\n Domicilio: {this._domicilio}\n Teléfono: {this._numeroTel}\n Email: {this._email}\n\n";
        }
    }
}
