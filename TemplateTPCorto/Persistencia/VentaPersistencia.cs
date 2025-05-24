using Newtonsoft.Json;
using Persistencia.WebService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class VentaPersistencia
    {
        private Guid idUsuario = new Guid("0cdbc5a5-69d9-4ab8-8cb3-9932ce33f54a");

        /*
        public bool agregarVenta(venta)
        {
            var jsonRequest = JsonConvert.SerializeObject(venta);

            HttpResponseMessage response = WebHelper.Post("Venta/AgregarVenta", jsonRequest);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
        */
    }
}
