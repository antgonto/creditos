using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
namespace EFoodIntranet.Controllers
{
    public class ConsultaPedidoController : ApiController
    {

        // GET: api/ConsultaPedido/5
        public string Get()
        {
            return new EFoodPedido().carga_lista_Pedido();
        }

        public string Get(string fecha1, string fecha2)
        {
            return new EFoodPedido().carga_lista_erroresRango(fecha1, fecha2);
        }

    }
}
