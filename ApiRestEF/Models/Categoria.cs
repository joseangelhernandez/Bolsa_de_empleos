using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestEF.Models
{
    public class Categoria
    {
        [Key]
        public int categoria_id {get; set;}
        public string nombre { get; set; }
    }
}
