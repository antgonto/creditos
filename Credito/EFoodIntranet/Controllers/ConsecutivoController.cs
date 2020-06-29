using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class ConsecutivoController : ApiController
    {
        // GET api/values
       // [Authorize(Roles="Administrador")]
        public string Get()
        {
            return new Consecutivo().carga_lista_consecutivos();
        }
       

        // GET api/values/5
        public string Get(int id)
        {
            return new Consecutivo().carga_lista_consecutivo_prefijo(id);
        }

        // POST api/values
       // [Authorize(Roles="Administrador")]
        public string Post([FromBody]Consecutivo consecutivo)
        {
            return consecutivo.agregar_consecutivo("Insertar") ? " Se guardó con éxito el consecutivo" : "No se guardó el consecutivo, verifique la información";
        }

        // PUT api/values/5
        // [Authorize(Roles="Administrador")]
        public string Put(int id, [FromBody]Consecutivo consecutivo)
        {
            return consecutivo.actualizar_consecutivo("Actualizar") ? " Se actualizó con éxito el consecutivo" : "No se actualizó el consecutivo, verifique la información";
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
