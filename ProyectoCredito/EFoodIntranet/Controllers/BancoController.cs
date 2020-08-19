using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class BancoController : ApiController
    {
        public string Get(int id)
        {
            return new Banco().carga_RespuestaBanco(id);
        }


        // POST api/values      
        public string Post([FromBody] Banco respuestaBanco)
        {
            return respuestaBanco.agregar_RespuestaBanco("Insertar") ? " Se guardó con éxito la respuesta del banco" : "No se guardó la respuesta del banco.";

        }

    }
}
