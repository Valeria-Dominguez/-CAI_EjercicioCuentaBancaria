using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuentaBancaria.Entidades;
using CuentaBancaria.Entidades.Modelos;
using Newtonsoft.Json;

namespace CuentaBancaria.Datos
{
    public class ClienteMapper
    {
        public List <Cliente> TraerTodos()
        {
            string json2 = WebHelper.Get("cliente");
            List<Cliente> resultado = MapList(json2);
            return resultado;
        }

        private List<Cliente> MapList(string json2)
        {
            List<Cliente> lst = JsonConvert.DeserializeObject< List < Cliente >>(json2);
            return lst;
        }

        public TransactionResult Insertar (Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);
            string json = WebHelper.Post("cliente", obj);
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }

        private NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("nombre", cliente.Nombre);
            n.Add("direccion", cliente.Domicilio);
            n.Add("telefono", cliente.NumeroTel.ToString());
            n.Add("email", cliente.Email);
            return n;
        }
    }
}
