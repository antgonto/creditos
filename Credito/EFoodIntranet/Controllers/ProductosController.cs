using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class ProductosController : ApiController
    {
        // GET api/values
        // [Authorize(Roles="Administrador, Mantenimient, ")]
        public string Get()
        {
            return new Productos().carga_lista_Productos();
        }

        // GET api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        

        // POST api/values
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Post([FromBody]Productos productos)
        {
            return productos.agregar_producto("Insertar") ? " Se guardó con éxito el producto" : "No se guardó el producto, verifique los datos. (Recuerde que la descripción no se puede repetir)";

        }

        // PUT api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Put(string id, [FromBody]Productos productos)
        {
            return productos.modificar_producto("Actualizar") ? "Se actualizó el producto con éxito" :
               "No se actualizó el precio";
        }
        // DELETE api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Delete(string id, [FromBody]Productos productos)
        {
            return productos.eliminar_producto(id) ? "Se eliminó el producto con éxito" : "No se eliminó el producto";
        }
    }
}
