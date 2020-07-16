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
            return creditCard.agregar_creditcard("Insertar") ? " Se guardaron los gastos" : "No se guardaron los gastos.";

        }

        //PUT api/values/5      
        public string Put(string id, [FromBody] CreditCard creditcard)
        {
            return creditcard.modificarCreditCard("Actualizar") ? "Se actualizaron los gastos" :
               "No se actualizaron los gastos";
        }

    }

}
