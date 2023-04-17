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
    public class ProductoController : ApiController
    {
        // GET api/<controller>
        public List<producto> Get()
        {
            return ProductoData.Listar();
        }

        // GET api/<controller>/5
        public producto Get(int id)
        {
            return ProductoData.obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] producto oProducto)
        {
            return ProductoData.Registrar(oProducto);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] producto oProducto)
        {
            return ProductoData.Modificar(oProducto);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ProductoData.Eliminar(id);
        }
    }
}