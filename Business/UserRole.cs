using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business
{
    public class UserRole
    {
        public static List<DTO.UserRole> GetUserRoleList()
        {
            return DataAccess.UserRole.GetUserRoleList();
        }
    }
}