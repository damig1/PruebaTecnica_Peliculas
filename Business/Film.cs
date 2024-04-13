using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business
{
    public class Film
    {
        public static DTO.Film Load(int filmId)
        {
            return DataAccess.Generic.Load<DTO.Film>(filmId);
        }

        public static List<DTO.vFilm> GetListDataSource(string keyword, int? genreId, string firstLetter)
        {
            return DataAccess.Film.GetList(keyword, genreId, firstLetter);
        }

        public static DTO.Film Save(DTO.Film film)
        {
            film.DateCreated = DateTime.Now;
            using (var transaction = DataAccess.Generic.BeginTransaction())
            {
                DataAccess.Generic.Save<DTO.Film>(film);
                transaction.Commit();
            }
            return film;
        }

        public static void DeleteFilm(int filmId)
        {
            DataAccess.Film.Deletefilm(filmId);
        }

        public static bool FilmExistsByName(string name)
        {
            return DataAccess.Film.ExistsByName(name);
        }
    }
}