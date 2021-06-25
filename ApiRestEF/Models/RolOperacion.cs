using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestEF.Models
{
    public class RolOperacion
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public int Id_rol { get; set; }
        public int Id_ope { get; set; }
    }
}
