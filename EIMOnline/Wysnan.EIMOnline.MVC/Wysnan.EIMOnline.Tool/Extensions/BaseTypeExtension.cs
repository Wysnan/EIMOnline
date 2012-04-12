using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Tool.Extensions
{
    public static class BaseTypeExtension
    {
        public static string ConvertToString(this bool obj, bool isLower=false)
        {
            if (isLower)
            {
                return obj.ToString().ToLower();
            }
            return obj.ToString();
        }
    }
}
