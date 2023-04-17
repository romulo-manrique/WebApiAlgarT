using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDale.Models
{
    public class ventas
    {
        public int idPedido { get; set; }
        public string cedula { get; set; }
        public DateTime fecha { get; set; }
        public string direccion { get; set; }
        public double PrecioTotal { get; set; }
    }
}