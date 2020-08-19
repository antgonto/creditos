using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;


namespace EFoodIntranet.Controllers
{
    public class GestionesPendientesController : ApiController
    {
        public string Get()
        {
            return new GestionesPendientes().cargarGestiones();
        }

        public string Get(int id)
        {
            return new GestionesPendientes().carga_InfoUsuario(id);
        }
    }
}
