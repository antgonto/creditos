using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class OtrosIngresosController : ApiController
    {
        public string Get(int id)
        {
            return new OtrosIngresos().carga_OtrosIngresos(id);
        }


        // POST api/values      
        public string Post([FromBody] OtrosIngresos ingresos)
        {
            return ingresos.agregar_OtrosIngresos("Insertar") ? " Se guardaron los ingresos" : "No se guardaron los ingresos.";

        }

        //PUT api/values/5      
        public string Put(string id, [FromBody] OtrosIngresos ingresos)
        {
            return ingresos.modificar_OtrosIngresos("Actualizar") ? "Se actualizaron los ingresos" :
               "No se actualizaron los ingresos";
        }
    }
}
