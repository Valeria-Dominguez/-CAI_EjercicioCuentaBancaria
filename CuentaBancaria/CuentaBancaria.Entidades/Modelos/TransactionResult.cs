using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria.Entidades.Modelos
{
    [DataContract]
    public class TransactionResult
    {
        [DataMember]
        public bool IsOk { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Error { get; set; }


        public override string ToString()
        {
            if (this.IsOk == true)
                return $"Operación exitosa - ID: {this.Id}";

            else
                return $"La operación no pudo realizarse - {this.Error}";
        }
    }
}
