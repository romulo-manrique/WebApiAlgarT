using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDale.Data;
using WebApiDale.Models;

namespace WebApiDale.Controllers
{
    public class ClienteController : ApiController
    {
        // GET api/<controller>
        public List<cliente> Get()
        {
            return ClienteData.Listar();
        }

        // GET api/<controller>/5
        public cliente Get(string id)
        {
            return ClienteData.obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] cliente oCliente)
        {
            return ClienteData.Registrar(oCliente);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] cliente oCliente)
        {
            return ClienteData.Modificar(oCliente);
        }

        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return ClienteData.Eliminar(id);
        }
    }
}