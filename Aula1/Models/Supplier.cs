using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula1.Controllers
{
    public class Supplier
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }
    }
}