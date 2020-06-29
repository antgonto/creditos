using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class Imagenes_ProductoController: ApiController
    {
        // GET api/values
        //public string Get()
        //{
        //    return new Procesador_Tarjeta().cargar_lista_procesador_tarjeta();
        //}

        // GET api/values/5
        public string Get(string cod_prod)
        {
            return new Imagenes_Producto().cargar_ruta_imagen_producto(cod_prod);
        }

        // POST api/values
        public string Post([FromBody] Imagenes_Producto imagenes_producto)
        {
            return imagenes_producto.agregar_Imagen_a_Producto("Insertar") ? " Se guardó la ruta de la imagen del  producto" :
                "No se guardó la ruta de la imagen del producto";

        }

        // PUT api/values/5
        //public string Put(string id, [FromBody]Precio_Producto precio_Producto)
        //{
        //    return precio_Producto.modificar_precio_prod("Actualizar") ? "Se actcualizó el precio del producto con éxito" :
        //        "No se actcualizó precio del producto";
        //}
        // DELETE api/values/5
        //public string Delete(string idCod, string idPrecio,  [FromBody] Precio_Producto precio_Producto)
        //{
        //    return precio_Producto.eliminar_precio_producto(idCod, idPrecio) ? "Se eliminó el precio del producto con éxito" 
        //        : "No se eliminó el precio del producto";
        //}
    }
}
