using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class PersonaController : ApiController
    {
        // GET api/values

        public string Get(int id, string accion)
        {
            return new Persona().carga_Persona(id, accion);
        }


        // POST api/values      
        public string Post([FromBody] Persona persona)
        {
            return persona.agregar_persona("Insertar") ? "Se guardó con éxito la persona" : "No se guardaron los datos.";

        }

        //PUT api/values/5      
        public string Put(string id, [FromBody] Persona persona)
        {
            return persona.modificarPersona("Actualizar") ? "Se actualizó  la persona con éxito" :
               "No se actualizó la persona";
        }




    }
}
