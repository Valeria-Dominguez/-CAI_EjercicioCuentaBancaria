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

        [DataMember(Name = "id")]
        public int Id { get => _id; set => _id = value; }

        public Cliente(int id, int dni, string nombre, string domicilio, string numeroTel, string email) : base(dni, nombre, domicilio, numeroTel, email)
        {
            this._id = id;
        }

        public Cliente()
        {
        }
        public override string ToString()
        {
            return $" Id: {this._id}\n Nombre y apellido: {Nombre}\n DNI: {Dni}\n Domicilio: {Domicilio}\n Teléfono: {this.NumeroTel}\n Email: {Email}\n\n";
        }
    }
}
