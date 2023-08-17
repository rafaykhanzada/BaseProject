using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class DBUtil
    {
        public static string GenerateSearchQuery<T>(string searchValue)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            string query = "";

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(string) || Nullable.GetUnderlyingType(property.PropertyType) == typeof(int))
                {
                    query += $"{property.Name} like '%{searchValue}%' OR ";
                }
            }

            query = query.TrimEnd(" OR ".ToCharArray()); // Remove trailing " OR "

            return query;
        }
    }
}
