using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDale.Models
{
    public class producto
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public double valorUnitario { get; set; }
    }
}