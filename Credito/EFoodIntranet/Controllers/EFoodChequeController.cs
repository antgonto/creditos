using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class EFoodChequeController : ApiController
    {
        public string Post([FromBody]EFoodCheque cheque)
        {
            return cheque.valida_cheque("Insertar") ? "Cheque aceptado" :
                "Error al procesar el cheque";

        }
    }
}
