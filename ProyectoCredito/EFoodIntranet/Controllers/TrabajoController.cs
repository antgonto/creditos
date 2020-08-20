using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class TrabajoController : ApiController
    {

        public string Get(int id)
        {
            return new Trabajo().carga_Trabajo(id);
        }


        // POST api/values      
        public string Post([FromBody] Trabajo trabajo)
        {
            return trabajo.agregar_trabajo("Insertar") ? " Se guardó trabajo" : "No se guardó trabajo.";

        }

        //PUT api/values/5      
        public string Put(string id, [FromBody] Trabajo trabajo)
        {
            return trabajo.modificarTrabajo("Actualizar") ? "Se actualizó trabajo" :
               "No se actualizó trabajo";
        }

    }
}

