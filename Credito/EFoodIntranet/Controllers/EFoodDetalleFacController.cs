using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class EFoodDetalleFacController : ApiController
    {
        
        // POST: api/EFoodCarrit
        public string Post([FromBody]EFoodDetalleFac carrito)
        {
            return carrito.agregar_detalle("Insertar") ? " Se guardó el item el detalle de factura" :
                "No se guardó el item en el detalle de factura";
        }

    }
}
