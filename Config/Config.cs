using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Config
{
    public class Config
    {
        public enum UserRole
        {
            Administrador = 1,
            Asistente = 2
        }

        public class Pager
        {
            public const Int32 DefaultPageSize = 50;

            public static List<int> ItemsPerPageOptions
            {
                get
                {
                    return new List<int>() { 50, 100, 150 };
                }
            }
        }
    }
}