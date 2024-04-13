using DataAccess;
using DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Business
{
    public class User
    {
        public static DTO.User Login(string userName, string password)
        {
            DTO.User user = DataAccess.User.GetUser(userName);
            return user;
        }

        public static void Register(string Name, string Lastname, string Document, string Email, string UserName, string Password, int UserRoleId)
        {
            DTO.User newUser = new DTO.User();
            try
            {
                newUser.UserId = Guid.NewGuid();
                newUser.Name = Name;
                newUser.Lastname = Lastname;
                newUser.Document = Document;
                newUser.Email = Email;
                newUser.UserName = UserName;
                newUser.Password = Password;
                newUser.UserRoleId = UserRoleId;

                newUser.Enabled = true;

                using (var transaction = DataAccess.Generic.BeginTransaction())
                {
                    DataAccess.Generic.Save<DTO.User>(newUser);
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool CheckIfExist(string userName)
        {
            return DataAccess.User.CheckIfExist(userName);
        }
    }
}