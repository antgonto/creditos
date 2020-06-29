using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class Procesador_TarjetaController : ApiController
    {
        // GET api/values
        //public string Get()
        //{
        //    return new Procesador_Tarjeta().cargar_lista_procesador_tarjeta();
        //}

        // GET api/values/5
        // [Authorize(Roles="Administrador ")]
        public string Get(string id)
        {
            return new Procesador_Tarjeta().cargar_lista_procesador_tarjeta(id);
        }

        // POST api/values
        // [Authorize(Roles="Administrador ")]
        public string Post([FromBody] Procesador_Tarjeta procesador_tarjeta)
        {
            return procesador_tarjeta.agregar_Procesador_a_Tarjeta("Insertar") ? " Se guardó la tarjeta en el procesador" : "No se guardó la tarjeta en el procesador";

        }

        // PUT api/values/5
        // [Authorize(Roles="Administrador ")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        // [Authorize(Roles="Administrador ")]
        public string Delete(string tipo_tarjeta, string tipo_procesador, [FromBody]  Procesador_Tarjeta procesador_tarjeta)
        {
            return procesador_tarjeta.eliminar__procesador_tarjeta(tipo_tarjeta,tipo_procesador) ? "Se eliminó la tarjeta del procesador con éxito" :
                "No se eliminó la tarjeta del procesador";
        }
    }
}
