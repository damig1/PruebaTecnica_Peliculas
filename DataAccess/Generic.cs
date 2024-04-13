using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace DataAccess
{
    public class Generic
    {
        public static T Load<T>(int Id) where T : class
        {
            string pk = GetPrimaryKeyInfo<T>().Name;
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, pk);
            var constant = Expression.Constant(Id);
            var equal = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(equal, parameter);

            return Common.DataContext.Set<T>().Where(lambda).FirstOrDefault();
        }

        private static PropertyInfo GetPrimaryKeyInfo<T>()
        {
            Type type = typeof(T);
            string keyName = type.Name + "s";
            PropertyInfo key = type.GetProperties().FirstOrDefault(p => p.Name.Equals("ID", StringComparison.OrdinalIgnoreCase) || p.Name.Equals(type.Name + "ID", StringComparison.OrdinalIgnoreCase));
            return key;
        }

        public static void Save<T>(T entity, bool saveChanges = true) where T : class
        {
            Common.DataContext.Set<T>().AddOrUpdate(entity);
            if (saveChanges)
            {
                Common.DataContext.SaveChanges();
            }
        }

        public static DbContextTransaction BeginTransaction()
        {
            return Common.DataContext.Database.BeginTransaction();
        }
    }
}