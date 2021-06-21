using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestEF.Models
{
    public class Puesto
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int puesto_id { get; set; }
        public string descripcion { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string como_aplicar { get; set; }
        public string ubicacion { get; set; }
        public string compania { get; set; }
        public string logo { get; set; }
        public string tipo { get; set; }
        public string _url { get; set; }
        public int categoria_id_pu { get; set; }
        public int poster_id_pu { get; set; }
        public bool estado { get; set; }
    }
}
