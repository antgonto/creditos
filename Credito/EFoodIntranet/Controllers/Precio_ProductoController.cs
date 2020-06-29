using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class Precio_ProductoController: ApiController
    {
        // GET api/values
        //public string Get()
        //{
        //    return new Procesador_Tarjeta().cargar_lista_procesador_tarjeta();
        //}

        // GET api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Get(string id)
        {
            return new Precio_Producto().cargar_lista_precio_producto(id);
        }

        // POST api/values
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Post([FromBody] Precio_Producto precio_Producto)
        {
            return precio_Producto.agregar_Precio_a_Producto("Insertar") ? " Se guardó el precio en el producto" : "No se guardó el precio en el producto, recuerde que solo" +
                " puede haber un precio por tipo ";

        }

        // PUT api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento")]
        public string Put(string id, [FromBody]Precio_Producto precio_Producto)
        {
            return precio_Producto.modificar_precio_prod("Actualizar") ? "Se actcualizó el precio del producto con éxito" :
                "No se actualizó precio del producto";
        }
        // DELETE api/values/5
        // [Authorize(Roles="Administrador, Mantenimiento ")]
        public string Delete(string idCod, string idPrecio,  [FromBody] Precio_Producto precio_Producto)
        {
            return precio_Producto.eliminar_precio_producto(idCod, idPrecio) ? "Se eliminó el precio del producto con éxito" 
                : "No se eliminó el precio del producto";
        }
    }
}
