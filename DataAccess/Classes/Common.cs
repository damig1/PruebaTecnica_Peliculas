using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DataAccess;

namespace DataAccess.Classes
{
    public class Common
    {
        public static DTO.PeliculasEntities MockDataContext { get; set; }
        public static bool IsTesting { get; set; } = false;
        public static DTO.PeliculasEntities DataContext
        {
            get
            {
                if (!IsTesting)
                {
                    if (HttpContext.Current.Items["DataContext"] == null)
                    {
                        HttpContext.Current.Items["DataContext"] = new DTO.PeliculasEntities();
                    }
                    return (DTO.PeliculasEntities)HttpContext.Current.Items["DataContext"];
                }
                else
                {
                    return MockDataContext;
                }
            }
        }
    }
}