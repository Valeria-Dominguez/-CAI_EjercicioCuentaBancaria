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
        public Cuenta TraerCuentaCliente(int idCliente)
        {
            string json = WebHelper.Get("cuenta/" + idCliente.ToString());
            Cuenta resultado = Map(json);
            return resultado;
        }
        private List<Cuenta> MapList(string json)
        {
            List<Cuenta> cuentas = JsonConvert.DeserializeObject<List<Cuenta>>(json);
            return cuentas;
        }

        private Cuenta Map(string json)
        {
            Cuenta cuenta = JsonConvert.DeserializeObject<Cuenta>(json);
            return cuenta;
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
            nCuenta.Add("id", cuenta.Id.ToString());
            nCuenta.Add("idCliente", cuenta.IdCliente.ToString());
            nCuenta.Add("descripcion", cuenta.Tipo);
            nCuenta.Add("activo", cuenta.Activa.ToString());
            nCuenta.Add("saldo", cuenta.Saldo.ToString());
            nCuenta.Add("fechaApertura", cuenta.FechaApertura.ToString("yyyy-MM-dd"));
            return nCuenta;
        }

    }
}
