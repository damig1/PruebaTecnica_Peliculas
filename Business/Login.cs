using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business
{
    public class Login
    {
        public static RedirectionResult RedirUserLogin(int userRoleId)
        {
            switch (userRoleId)
            {
                case (int)Config.Config.UserRole.Administrador:
                    return new RedirectionResult { Controller = "Film", Action = "List", Area = "Admin" };

                case (int)Config.Config.UserRole.Asistente:
                    return new RedirectionResult { Controller = "Film", Action = "List", Area = "Admin" };

                default:
                    return new RedirectionResult { IsValid = false, ErrorMessage = "El usuario no tiene permisos para ingresar al sistema" };
            }
        }

        public class RedirectionResult
        {
            public string Area { get; set; }
            public string Controller { get; set; }
            public string Action { get; set; }
            public bool IsValid { get; set; } = true;
            public string ErrorMessage { get; set; }
        }
    }
}