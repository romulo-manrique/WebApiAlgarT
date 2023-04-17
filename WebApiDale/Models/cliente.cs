using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDale.Models
{
    public class cliente
    {
        public string cedula { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public string telefonoCliente { get; set; }
    }
}