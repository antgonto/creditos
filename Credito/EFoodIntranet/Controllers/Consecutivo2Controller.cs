using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class Consecutivo2Controller : ApiController
    {
        // GET api/values
        public string Get()
        {
            return new Consecutivo().carga_lista_consecutivos2();
        }

       
    }
}
