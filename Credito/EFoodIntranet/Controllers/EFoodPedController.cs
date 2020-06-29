using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class EFoodPedController : ApiController
    {

        public string Get()
        {
            return new EFoodPedido().carga_lista_UltimoPedido();
        }


        // POST: api/EFoodPed
        public string Post([FromBody]EFoodPedido pedido)
        {
            return pedido.agregar_pedido("Insertar") ? " Se guardó el pedido" : "No se guardó el pedido";
        }

        
        
    }
}
