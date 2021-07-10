using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models.Request
{
    public class LoginRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage ="Este campo es requerido")]
        public string Email { get; set; }
        public string password { get; set; }
    }
}