using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Models.Account
{
    public class Register
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [Display(Name = "Apellido")]

        public string Lastname { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public IEnumerable<SelectListItem> UserRoleList { get; set; }
    }
}