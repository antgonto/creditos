using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class ProcesadoresController : ApiController
    {
        // GET api/values
        // [Authorize(Roles="Administrador ")]
        public string Get()
        {
            return new Procesador_pago().carga_lista_procesadores();
        }

        // GET api/values/5
        // [Authorize(Roles="Administrador ")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        // [Authorize(Roles="Administrador ")]
        public string Post([FromBody]Procesador_pago procesador)
        {
            return procesador.agregar_procesador_pago("Insertar") ? " Se guardó con éxito el procesador de pago" : 
                "No se guardó el procesador de pago. Recuerde que solo puede haber un efectivo y  para " +
                "crear una tarjeta o cheque no puede haber ninguno activo ";

        }

        // PUT api/values/5
        // [Authorize(Roles="Administrador ")]
        public string Put(int id, [FromBody]Procesador_pago procesador_pago)
        {
            return procesador_pago.modificar_procesador_pago("Actualizar") ? "Se ha actualizado con exito el procesador_pago" :
                "No se logró la actualización del procesador_pago";
        }

        // DELETE api/values/5
        // [Authorize(Roles="Administrador ")]
        public string Delete(string id, [FromBody] Procesador_pago procesador_pago)
        {
            return procesador_pago.eliminar_procesador_pago(id) ? "Se eliminó el procesador de pago con éxito" : "No se eliminó el procesador de pago ";
        }
    }
}
