using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class UserRole
    {
        public static List<DTO.UserRole> GetUserRoleList()
        {
            return Common.DataContext.UserRole.ToList()
            .Select(ur => new DTO.UserRole
            {
                UserRoleId = ur.UserRoleId,
                Name = ur.Name
            }).ToList();
        }
    }
}