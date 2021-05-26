using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria.Entidades
{
    [DataContract]

    public abstract class Persona
    {
        int _dni;
        string _nombre;
        string _domicilio;
        string _numeroTel;
        string _email;

        [DataMember(Name = "dni")]
        public int Dni { get => _dni; set => _dni = value; }

        [DataMember(Name = "nombre")]
        public string Nombre { get => _nombre; set => _nombre = value; }

        [DataMember(Name = "direccion")]
        public string Domicilio { get => _domicilio; set => _domicilio = value; }

        [DataMember(Name = "telefono")]
        public string NumeroTel { get => _numeroTel; set => _numeroTel = value; }

        [DataMember(Name = "email")]
        public string Email { get => _email; set => _email = value; }

        protected Persona(int dni, string nombre, string domicilio, string numeroTel, string email)
        {
            this._dni = dni;
            this._nombre = nombre;
            this._domicilio = domicilio;
            this._numeroTel = numeroTel;
            this._email = email;
        }
        protected Persona()
        {

        }

    }
}
