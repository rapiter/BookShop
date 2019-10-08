using System;
using System.IO;
using System.Reflection;

namespace BookShop.Core.Entities
{
    public static class IsNullOrEmpty
    {
        public static String Check(object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string) pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new InvalidDataException(pi.Name + " is missing");
                    }
                }
            }
            return null;

        }
    }
}