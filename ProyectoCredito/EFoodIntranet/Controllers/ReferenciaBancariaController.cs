using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
namespace EFoodIntranet.Controllers
{
    public class ReferenciaBancariaController : ApiController
    {
        public string Get(int id)
        {
            return new ReferenciaBancaria().carga_ReferenciaBancaria(id);
        }


        // POST api/values      
        public string Post([FromBody] ReferenciaBancaria referencia)
        {
            return referencia.agregar_ReferenciaBancaria("Insertar") ? " Se guardó la referencia bancaria" : "No se guardaron los cambios a referencia bancaria.";

        }

        //PUT api/values/5      
        public string Put(string id, [FromBody] ReferenciaBancaria referencia)
        {
            return referencia.modificar_ReferenciaBancaria("Actualizar") ? "Se actualizó referencia bancaria" :
               "No se actualizó referencia bancaria";
        }
    }
}
