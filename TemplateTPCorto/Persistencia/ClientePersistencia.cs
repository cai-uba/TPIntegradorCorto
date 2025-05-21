using Datos.Ventas;
using Newtonsoft.Json;
using Persistencia.WebService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ClientePersistencia
    {
        public List<Cliente> obtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            HttpResponseMessage response = WebHelper.Get("/api/Cliente/GetClientes");

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var contentStream = response.Content.ReadAsStringAsync().Result;
                listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(contentStream);
            }

            return listaClientes;
        }

    }
}
