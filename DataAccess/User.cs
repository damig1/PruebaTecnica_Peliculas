using DataAccess;
using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class User
    {
        public static DTO.User GetUser(string userName)
        {
            return Common.DataContext.User.FirstOrDefault(x => x.UserName == userName && x.Enabled == true);
        }

        public static bool CheckIfExist(string userName)
        {
            var query = Common.DataContext.User.FirstOrDefault(x => x.UserName == userName);

            if (query != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}