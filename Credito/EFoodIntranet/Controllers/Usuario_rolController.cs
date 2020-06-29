using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class Usuario_rolController : ApiController
    {
        // GET api/values
        //public string Get()
        //{
        //    return new Procesador_Tarjeta().cargar_lista_procesador_tarjeta();
        //}

        // GET api/values/5
        // [Authorize(Roles="Administrador, Seguridad ")]
        public string Get(string id)
        {
            return new Usuario_Rol().carga_lista_usuarios_rol(id);
        }

        // POST api/values
        // [Authorize(Roles="Administrador, Seguridad ")]
        public HttpResponseMessage Post([FromBody] Usuario_Rol usuario_rol)
        {          

            if (usuario_rol.agregar_usuario_rol("Insertar"))
            {
                var message = string.Format("Se guardó el rol en el usuario");
                return Request.CreateResponse(HttpStatusCode.OK, message);
            }
            else
            {
                var message = string.Format("No se guardó el rol en el usuario.");
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message);
            }

        }

        // PUT api/values/5
        //public string Put(string id, [FromBody]Precio_Producto precio_Producto)
        //{
        //    return precio_Producto.modificar_precio_prod("Actualizar") ? "Se actcualizó el precio del producto con éxito" :
        //        "No se actcualizó precio del producto";
        //}
        // DELETE api/values/5
        // [Authorize(Roles="Administrador ")]
        public string Delete(int rol_cod, string nom_usu,  [FromBody] Usuario_Rol usuario_rol)
        {
            return usuario_rol.elimina_usuario_rol(rol_cod, nom_usu) ? "Se eliminó el rol del usuario" : 
                "No se eliminó el rol del usuario";
        }
    }
}
