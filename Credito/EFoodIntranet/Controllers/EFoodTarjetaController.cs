using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class EFoodTarjetaController : ApiController
    {
        // GET: api/EFoodTarjeta
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EFoodTarjeta/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EFoodTarjeta
        //public string Post([FromBody]EFoodTarjeta tarjeta)
        //{
        //    return tarjeta.agregar_tarjeta("Insertar") ? " Tarjeta aceptada" :
        //        "Error al procesar la tarjeta";

        //}

        public string Post([FromBody]EFoodTarjeta tarjeta)
        {
            return tarjeta.valida_tarjeta("Insertar") ? "Tarjeta aceptada" :
                "Error al procesar la tarjeta";

        }

        // PUT: api/EFoodTarjeta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EFoodTarjeta/5
        public void Delete(int id)
        {
        }
    }
}
