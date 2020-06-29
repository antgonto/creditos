using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class PreciosController : ApiController
    {
        // GET api/values
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Get()
        {
            return new Precios().carga_lista_precios();
        }

        // GET api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Post([FromBody]Precios precios)
        {
            return precios.agregar_precio("Insertar") ? " Se guardó con éxito el precio" : "No se guardó el precio";

        }

        // PUT api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Put(string id, [FromBody]Precios precios)
        {
            return precios.modificar_precio("Actualizar") ? "Se actualizó el tipo precio con éxito" :
                "No se actcualizó el tipo precio";
        }

        // DELETE api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Delete(string id, [FromBody]Precios precios)
        {
            return precios.eliminar_precio(id) ? "Se eliminó el tipo precio con éxito" : "No se eliminó el tipo precio, revise si hay productos asociados";
        }
    }
}
