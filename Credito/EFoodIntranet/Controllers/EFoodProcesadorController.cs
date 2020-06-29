using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
namespace EFoodIntranet.Controllers
{
    public class EFoodProcesadorController : ApiController
    {
        // GET: api/EFoodProcesador
        public string Get()
        {
            return new EFoodProcesador().carga_lista_procesadorActivo();
        }
    }
}
