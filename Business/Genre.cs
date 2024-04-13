using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business
{
    public class Genre
    {
        public static List<DTO.Genre> GetGenreList()
        {
            return DataAccess.Genre.GetGenreList();
        }
    }
}