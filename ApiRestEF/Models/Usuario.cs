using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestEF.Models
{
    public class Usuario
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int id_rol { get; set; }
    }
}
