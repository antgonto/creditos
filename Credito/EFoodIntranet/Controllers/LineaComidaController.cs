using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class LineaComidaController : ApiController
    {
        // GET api/values
        // [Authorize(Roles="Administrador, Mantenimiento")]
        public string Get()
        {
            return new Linea_comida().carga_lista_lineas_comida();
        }

        // GET api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Post([FromBody]Linea_comida lineaComida)
        {
            return lineaComida.agregar_linea_comida("Insertar") ? " Se guardó con éxito la línea de comida" : "No se guardó la línea de comida. Recuerde que no pueden haber descripciones duplicadas";

        }

        // PUT api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Put(string id, [FromBody] Linea_comida linea_comida)
        {
            return linea_comida.linea_comida_modificar("Actualizar") ? "Se ha actualizado con exito la linea de comida" :
                "No se logró la actualización de la linea de comida. Recuerde que si tiene productos asociados no se puede actualizar la línea sin antes borrar la asociación.";
        }

        // DELETE api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Delete(string id, [FromBody] Linea_comida linea_comida)
        {
            return linea_comida.eliminar_linea_comida(id) ? "Se eliminó la línea de comida con éxito" : "No se eliminó línea de comida, revise si hay productos asociados.  ";
        }
    }
}
