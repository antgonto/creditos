using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Newtonsoft.Json;

namespace EFoodIntranet.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET api/values       
        public string Get()
        {
            return new Usuarios().carga_lista_usuarios();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values   
        public HttpResponseMessage Post([FromBody]Usuarios usuarios)
        {
            if (usuarios.agregar_usuario("Insertar"))
            {
                var message = string.Format("Se creó con éxito el usuario");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else
            {
                var message = string.Format("Error al crear el usuario, verifique los datos.");
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message);
            }
        }

        // PUT api/values/5
        //[Authorize]
        public string Put(string id, [FromBody]Usuarios usuarios)
        {
            return usuarios.modificar_usuario_contrasena("Actualizar") ? "Se ha actualizado con exito la contraseña del usuario" :
                "No se logró la actualización de la contraseña del usuario";
        }

        // DELETE api/values/5
        // [Authorize(Roles="Administrador")]
        public string Delete(string id, [FromBody]Usuarios usuarios)
        {
            return usuarios.elimina_usuario(id) ? " Se guardó con éxito el usuario"
                : "No se guardó el usuario";

        }
    }
}
