using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
namespace EFoodIntranet.Controllers
{
    public class EfoodProdPorLCController : ApiController
    {
        // GET: api/EfoodProdPorLC
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EfoodProdPorLC/5
        public string Get(string desc_licom)
        {
            return new EFoodProdPorLinea().carga_lista_consultas_productos(desc_licom);
        }

        // POST: api/EfoodProdPorLC
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EfoodProdPorLC/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EfoodProdPorLC/5
        public void Delete(int id)
        {
        }
    }
}
