using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class TarjetasController : ApiController
    {
        // GET api/values
        // [Authorize(Roles="Administrador ")]
        public string Get()
        {
            return new Tarjetas().carga_lista_tarjeta();
        }

        // GET api/values/5
        // [Authorize(Roles="Administrador ")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        // [Authorize(Roles="Administrador ")]
        public string Post([FromBody]Tarjetas tarjetas)
        {
            return tarjetas.agregar_tarjeta("Insertar") ? " Se guardó con éxito la tarjeta" : "No se guardó la tarjeta";

        }

        // PUT api/values/5
        // [Authorize(Roles="Administrador ")]
        public string Put(string id, [FromBody]Tarjetas tarjetas)
        {
            return tarjetas.modificar_tarjeta("Actualizar") ? "Se actualizó la tarjeta con éxito" :
               "No se actualizó la tarjeta";
        }

        // DELETE api/values/5
        // [Authorize(Roles="Administrador ")]
        public string Delete(string id, [FromBody]Tarjetas tarjetas)
        {
            return tarjetas.eliminar_tarjeta(id) ? "Se eliminó la tarjeta con éxito" : "No se eliminó la tarjeta, revise si tiene procesadores asociados ";
        }
    }
}
