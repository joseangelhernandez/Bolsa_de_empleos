using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Request
{
    public class PuestoRequest
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string como_aplicar { get; set; }
        public string Ubicacion { get; set; }
        public string Compania { get; set; }
        public string Logo { get; set; }
        public string Tipo { get; set; }
        public string Url { get; set; }
        public bool Estado { get; set; }
    }
}