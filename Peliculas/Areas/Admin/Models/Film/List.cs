using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Areas.Admin.Models.Film
{
    public class List
    {
        public List<DTO.vFilm> FilmList { get; set; } = new List<DTO.vFilm>();
        public SearchField SearchFields { get; set; } = new SearchField();
        public IEnumerable<SelectListItem> GenreList { get; set; }

    }
    public class SearchField
    {
        public string Keyword { get; set; }
        public int? GenreId { get; set; }
    }
}