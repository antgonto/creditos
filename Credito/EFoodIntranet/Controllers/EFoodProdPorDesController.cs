using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class EFoodProdPorDesController : ApiController
    {
        // GET: api/EFoodProdPorDes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EFoodProdPorDes/5
        public string Get(string descripcion)
        {
            return new EFoodProdPorDescrip().carga_lista_productosPorDesc(descripcion);
        }

        // POST: api/EFoodProdPorDes
        

      
    }
}
