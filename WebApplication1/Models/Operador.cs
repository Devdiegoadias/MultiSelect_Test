using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Operador
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        List<object> Roles { get; set; }

    }
}