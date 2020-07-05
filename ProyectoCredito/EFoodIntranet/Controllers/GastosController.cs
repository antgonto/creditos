using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class GastosController : ApiController
    {
        public string Get(int id)
        {
            return new Gastos().carga_Gastos(id);
        }


        // POST api/values      
        public string Post([FromBody] Gastos gastos)
        {
            return gastos.agregar_Gastos("Insertar") ? " Se guardaron los gastos" : "No se guardaron los gastos.";

        }

        //PUT api/values/5      
        public string Put(string id, [FromBody] Gastos gastos)
        {
            return gastos.modificarGastos("Actualizar") ? "Se actualizaron los gastos" :
               "No se actualizaron los gastos";
        }

    }
}
