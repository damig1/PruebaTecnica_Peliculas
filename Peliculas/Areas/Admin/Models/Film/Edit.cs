using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Areas.Admin.Models.Film
{
    public class Edit
    {
        public int FilmId { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public int GenreId { get; set; }
        public IEnumerable<SelectListItem> GenreList { get; set; }

        public void SetFilm(DTO.Film film)
        {
            FilmId = film.FilmId;
            Name = film.Name;
            Enabled = film.Enabled.Value;
            GenreId = film.GenreId;
        }

        public void GetFilm(ref DTO.Film film)
        {
            film.Name = Name;
            film.Enabled = Enabled;
            film.GenreId = GenreId;
        }
    }
}