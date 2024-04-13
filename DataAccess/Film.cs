using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class Film
    {
        public static List<DTO.vFilm> GetList(string keyword, int? genreId, string firstLetter)
        {
            IQueryable<DTO.vFilm> query = Common.DataContext.vFilm;

            if (genreId.HasValue)
            {
                query = query.Where(x => x.GenreId == genreId.Value);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => (x.FilmName.Contains(keyword)));
            }           

            if (!string.IsNullOrEmpty(firstLetter))
            {
                query = query.Where(x => x.FilmName.StartsWith(firstLetter));
            }

            return query.Where(x => x.Enabled == true).OrderBy(x => x.FilmName).ToList();
        }

        public static void Deletefilm(int filmId)
        {
            var id = new SqlParameter("@FilmId", filmId);
            try
            {
                Common.DataContext.Database.ExecuteSqlCommand("EXEC Delete_FilmSP @FilmId", id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ExistsByName(string name)
        {
            return Common.DataContext.Film.Any(x => x.Name == name);
        }
    }
}