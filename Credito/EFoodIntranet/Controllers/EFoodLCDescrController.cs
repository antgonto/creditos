using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class EFoodLCDescrController : ApiController
    {
        // GET: api/EFoodLCDescr
        public string Get()
        {
            return new EFoodProdLCDescripcion().carga_lista_LC();
        }

        
       
    }
}
