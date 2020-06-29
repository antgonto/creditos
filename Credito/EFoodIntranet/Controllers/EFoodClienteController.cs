using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EFoodIntranet.Controllers
{
    public class EFoodClienteController : ApiController
    {
        // GET: api/EFoodCliente
        public string Get()
        {
            return new EFoodCliente().carga_lista_clientes();
        }

       

        // POST: api/EFoodCliente
        public string Post([FromBody]EFoodCliente cliente)
        {
            return cliente.agregar_cliente("Insertar") ? " Se guardó con éxito el cliente" : 
                "No se guardó el cliente. Verifique los datos";

        }
               
    }
}
