namespace ApiRestEF.Models
{
    public class Poster
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int poster_id { get; set; }
        public string nombre {get; set;}
        public string usuario { get; set; }
        public string password { get; set; }
        public string telefono { get; set; }

    }
}
