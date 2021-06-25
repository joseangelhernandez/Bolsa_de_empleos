using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestEF.Models
{
    public class Operaciones
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public int Nombre { get; set; }
        public int Id_modulo { get; set; }
    }
}
