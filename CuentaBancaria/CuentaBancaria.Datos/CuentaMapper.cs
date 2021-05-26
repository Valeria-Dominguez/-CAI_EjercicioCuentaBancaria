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
    public class CuentaMapper
    {
        public List <Cuenta> TraerTodos ()
        {
            string json = WebHelper.Get("cuenta");
            List<Cuenta> resultado = MapList(json);
            return resultado;
        }
        private List<Cuenta> MapList(string json)
        {
            List<Cuenta> cuentas = JsonConvert.DeserializeObject<List<Cuenta>>(json);
            return cuentas;
        }

        public TransactionResult Insertar (Cuenta cuenta)
        {
            NameValueCollection nCuenta = ReverseMap(cuenta);
            string json = WebHelper.Post("cuenta", nCuenta);
            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json);
            return resultado;
        }

        private NameValueCollection ReverseMap (Cuenta cuenta)
        {
            NameValueCollection nCuenta = new NameValueCollection();
            nCuenta.Add("idCliente", cuenta.IdCliente.ToString());
            nCuenta.Add("descripcion", cuenta.Tipo);
            return nCuenta;
        }

    }
}
