using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class GestionFormularioController : ApiController
    {
        public string Get(int id)
        {
            return new GestionFormulario().carga_GestionFormulario(id);
        }


        // POST api/values      
        public string Post([FromBody] GestionFormulario gestionFormulario)
        {
            return gestionFormulario.agregar_gestionformulario("Insertar") ? "Se guardo el formulario" : "No se guardo el formulario.";

        }

        //PUT api/values/5      
        public string Put(string id, [FromBody] GestionFormulario gestionFormulario)
        {
            return gestionFormulario.modificar_gestionformulario("Actualizar") ? "Se actualizo el formulario" :
               "No se actualizo el formualrio";
        }

    }

}
