﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;


namespace EFoodIntranet.Controllers
{
    public class Trabajo_PersonaController : ApiController
    {
        public string Get(int id)
        {
            return new Trabajo_Persona().carga_Trabajo_Persona(id);
        }


        // POST api/values      
        public string Post([FromBody] Trabajo_Persona trabajo_persona)
        {
            return trabajo_persona.agregar_trabajo_persona("Insertar") ? "Se guardó el trabajo para esa persona" : "No se guardó el trabajo para esa persona.";

        }

        //PUT api/values/5      
        public string Put(string id, [FromBody] Trabajo_Persona trabajo_persona)
        {
            return trabajo_persona.modificarTrabajoPersona("Actualizar") ? "Se actualizó el trabajo de la persona" :
               "No se actualizó el trabajo de la persona";
        }

    }
}
