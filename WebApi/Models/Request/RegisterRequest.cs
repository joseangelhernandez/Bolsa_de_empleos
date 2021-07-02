using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models.Request
{
    public class RegisterRequest
    {

        [Required]
        public string Email { get; set; }

        [Required]
        //[StringLength(MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        //[StringLength(MinimumLength = 8)]
        public string Rep_password { get; set; }

        public Nullable<System.DateTime> fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(3)]
        public string Nombre { get; set; }

        public int Rol { get; set; }
    }
}