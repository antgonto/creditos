using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;


namespace EFoodIntranet.Controllers
{
    public class CreditCardController : ApiController
    {
        public string Get(int id)
        {
            return new CreditCard().carga_CreditCard(id);
        }


        // POST api/values      
        public string Post([FromBody] CreditCard creditCard)
        {
            return creditCard.agregar_creditcard("Insertar") ? "Se guardo la tarjeta" : "No se guardo tarjeta.";

        }

        //PUT api/values/5      
        public string Put(string id, [FromBody] CreditCard creditcard)
        {
            return creditcard.modificarCreditCard("Actualizar") ? "Se actualizo la tarjeta" :
               "No se actualizo la tarjeta";
        }

    }

}
