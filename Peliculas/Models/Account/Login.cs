using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Peliculas.Models.Account
{
    public class Login
    {
        [Required(ErrorMessage = "Ingrese el usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ingrese la contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}