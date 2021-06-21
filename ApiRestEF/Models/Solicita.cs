namespace ApiRestEF.Models
{
    public class Solicita
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int solicita_id { get; set; }
        public int solic_id { get; set; }
        public int puesto_id { get; set; }
        public System.DateTime fecha { get; set; }
    }
}
