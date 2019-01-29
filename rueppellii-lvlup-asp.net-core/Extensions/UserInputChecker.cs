using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Extensions
{
    public static class UserInputChecker
    {
        public static bool IsAnyPropertyNull(this Object o)
        {
            var properties = o.GetType().GetProperties();
            foreach(var property in properties)
            {
                if(property.GetValue(o) == null)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsAnyStringPropertyEmpty(this Object o)
        {
            var properties = o.GetType().GetProperties();
            foreach(var property in properties)
            {
                if(property.PropertyType.Name == "String" && property.GetValue(o) == string.Empty)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
