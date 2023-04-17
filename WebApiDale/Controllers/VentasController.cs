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
    public class VentasController : ApiController
    {
        // GET api/<controller>
        public List<ventas> Get()
        {
            return VentaData.Listar();
        }

        // GET api/<controller>/5
        public ventas Get(int id)
        {
            return VentaData.obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] ventas oVenta)
        {
            return VentaData.Registrar(oVenta);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] ventas oVenta)
        {
            return VentaData.Modificar(oVenta);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return VentaData.Eliminar(id);
        }
    }
}