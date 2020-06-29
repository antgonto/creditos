using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class ConsultasController : ApiController
    {
        // GET api/values
        // [Authorize(Roles="Administrador, Consulta")]
        public string Get(string usuario)
        {
            return new Consultas().carga_lista_consultas(usuario);
        }

        // GET api/values/5
     
    }
}
