using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Request
{
    public class CategoriaRequest
    {
        public int categoria_id { get; set; }
        public string nombre { get; set; }
    }
}