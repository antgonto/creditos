using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class EFoodDescuentoValidarController : ApiController
    {
        // GET: api/EFoodDescuentoValidar
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EFoodDescuentoValidar/5
        public string Get(string id)
        {
            return new EFoodDescuentoValidar().carga_lista_TiqueteDescuento(id);
        }
      

    }
}
