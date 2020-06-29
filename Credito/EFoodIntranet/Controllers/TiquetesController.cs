using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class TiquetesController : ApiController
    {
        // GET api/values
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Get()
        {
            return new Tiquete_descuento().carga_lista_tiquetes();
        }

        // GET api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Post([FromBody]Tiquete_descuento tiquete_descuento)
        {
            return tiquete_descuento.agregar_tiquete_descuento("Insertar") ? " Se guardó con éxito el tiquete de descuento" : "No se guardó el el tiquete de descuento, verifique los datos";

        }

        // PUT api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Put(string id, [FromBody]Tiquete_descuento tiquetes_descuento)
        {
            return tiquetes_descuento.modificar_tiquete_descuento("Actualizar") ? " Se actualizó con éxito el tiquete de descuento" :
                "No se actualizó el tiquete de descuento";
        }

        // DELETE api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Delete(string id, [FromBody] Tiquete_descuento tiquetes_descuento)
        {
            return tiquetes_descuento.eliminar_tiquete_descuento(id) ? "Se eliminó el tiquete de descuento con éxito" : "No se eliminó el tiquete de descuento";
        }
    }
}
