using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class ConsultasProductoController : ApiController
    {
      

        // GET api/values/5
        public string Get(string desc_licom)
        {
            return new Consultas_Producto().carga_lista_consultas_productos(desc_licom);
        }

        // POST api/values
       
    }
}
