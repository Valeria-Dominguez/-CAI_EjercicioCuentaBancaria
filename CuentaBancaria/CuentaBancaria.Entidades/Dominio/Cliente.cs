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
        int _id;
        Cuenta _cuenta;
        string _usuario;

        [DataMember(Name = "id")]
        public int Id { get => _id; set => _id = value; }   

        public Cuenta Cuenta { get => _cuenta; set => _cuenta = value; }

        [DataMember(Name = "usuario")]
        public string Usuario { get => _usuario; set => _usuario = value; }

        public Cliente(int id, Cuenta cuenta, string usuario, int dni, string nombre, string apellido, string domicilio, string numeroTel, string email, DateTime fechaNacimiento) : base(dni, nombre, apellido, domicilio, numeroTel, email, fechaNacimiento)
        {
            this._id = id;
            this._cuenta = cuenta;
        }

        public Cliente()
        {
        }
        public override string ToString()
        {
            return $"{Nombre} {Apellido}, DNI: {Dni}\n //{this._id}\n\n";
        }
    }
}
