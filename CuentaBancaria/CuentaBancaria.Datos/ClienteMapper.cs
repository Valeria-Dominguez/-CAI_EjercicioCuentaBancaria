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
            string json = WebHelper.Get("cliente/847004");
            List<Cliente> resultado = MapList(json);
            return resultado;
        }

        private List<Cliente> MapList(string json)
        {
            List<Cliente> clientes = JsonConvert.DeserializeObject< List < Cliente >>(json);
            return clientes;
        }

        public TransactionResult Insertar (Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);
            string json = WebHelper.Post("cliente", obj);
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }

        private NameValueCollection ReverseMap (Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("id", cliente.Id.ToString());
            n.Add("dni", cliente.Dni.ToString());
            n.Add("nombre", cliente.Nombre);
            n.Add("apellido", cliente.Apellido);
            n.Add("direccion", cliente.Domicilio);
            n.Add("telefono", cliente.NumeroTel);
            n.Add("email", cliente.Email);
            n.Add("usuario", cliente.Usuario);
            n.Add("fechaNacimiento", cliente.FechaNacimiento.ToString("yyyy-MM-dd"));
            return n;
        }

        public TransactionResult Eliminar(Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);
            string json = WebHelper.Delete("cliente", obj);
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }

        public TransactionResult Modificar(Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);
            string json = WebHelper.Put("cliente", obj);
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }
    }
}
