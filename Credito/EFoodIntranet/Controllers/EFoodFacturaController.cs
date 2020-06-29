using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class EFoodFacturaController : ApiController
    {
        public string Get()
        {
            return new EFoodFactura().carga_lista_UltimaFactura();
        }

        // POST: api/EFoodFactura
        public string Post([FromBody]EFoodFactura factura)
        {
            return factura.agregar_factura("Insertar") ? " Se guardó la factura" : "No se guardó la factura";
        }
    }
}
