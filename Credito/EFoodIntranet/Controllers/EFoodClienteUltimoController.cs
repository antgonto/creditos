using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;


namespace EFoodIntranet.Controllers
{
    public class EFoodClienteUltimoController : ApiController
    {
        // GET: api/EFoodClienteUltimo
        public string Get()
        {
            return new EFoodCliente().carga_UltimoCliente();
        }

      
    }
}
