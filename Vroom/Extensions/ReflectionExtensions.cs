using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Vroom.Extensions
{
    public static class ReflectionExtensions
    {
        public static string GetPropertyValue<T>(this T item , string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();            
        }
    }
}
//Authentication: is the process of obtainig credentials from users and then using those to verify user is valid or not
//authorization: after authentication to provide access to differet roles
//identity feature/system provides all the infrastucture to manage users and roles 