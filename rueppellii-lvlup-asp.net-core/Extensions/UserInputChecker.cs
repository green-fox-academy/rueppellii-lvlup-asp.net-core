﻿namespace rueppellii_lvlup_asp.net_core.Extensions
{
    public static class UserInputChecker
    {
        public static bool IsAnyPropertyNull(this object o)
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

        public static bool IsAnyStringPropertyEmpty(this object o)
        {
            var properties = o.GetType().GetProperties();
            foreach(var property in properties)
            {
                if(property.PropertyType.Name == "String" && (string)property.GetValue(o) == string.Empty)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
