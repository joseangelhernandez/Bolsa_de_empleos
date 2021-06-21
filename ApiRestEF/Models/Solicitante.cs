using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestEF.Models
{
    public class Solicitante
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int soli_id { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string telefono { get; set; }
    }
}
