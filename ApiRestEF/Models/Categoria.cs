﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestEF.Models
{
    public class Categoria
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
