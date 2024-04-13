using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class Genre
    {
        public static List<DTO.Genre> GetGenreList()
        {
            return Common.DataContext.Genre.ToList()
            .Select(g => new DTO.Genre
            {
                GenreId = g.GenreId,
                Name = g.Name
            }).ToList();
        }
    }
}