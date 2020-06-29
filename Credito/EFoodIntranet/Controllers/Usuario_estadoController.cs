using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class Usuario_estadoController : ApiController
    {
        // GET api/values
        // [Authorize(Roles="Administrador, Seguridad ")]
        public string Get()
        {
            return new Usuario_Estado().carga_lista_UsuariosEstado();
        }

        // PUT api/values/5
        // [Authorize(Roles="Administrador, Seguridad ")]
        public string Put(string id, [FromBody]Usuario_Estado usuario_Estado)
        {
           return usuario_Estado.agregar_usuario_Estado("Actualizar") ? "Se actcualizó el estado con éxito" :
                "No se actualizó estado";
        }
        
    }
}
