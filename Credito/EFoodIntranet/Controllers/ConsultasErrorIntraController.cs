using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class ConsultasErrorIntraController : ApiController
    {
        // GET api/values
        // [Authorize(Roles="Administrador, Consulta")]
        public string Get()
        {
            return new Consultas_Error_Intra().carga_lista_consultas_errores_intra();
        }

       // GET api/values/5
        public string Get(string fecha1, string fecha2)
        {
            return new Consultas_Error_Intra().carga_lista_erroresRango(fecha1, fecha2);
        }

        // POST api/values
        //public string Post([FromBody]Consultas_Error_Intra consulta)
        //{
        //    return consulta.carga_lista_erroresRango("Buscar") ? " Se buscó con éxito los errores" : "No se logró buscar";

        //}

        // PUT api/values/5

    }
}
