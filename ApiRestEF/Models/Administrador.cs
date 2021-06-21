using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestEF.Models
{
    public class Administrador
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int admin_id { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
