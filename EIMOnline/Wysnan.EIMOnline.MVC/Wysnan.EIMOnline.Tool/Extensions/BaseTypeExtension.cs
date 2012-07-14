using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Tool.Extensions
{
    public static class BaseTypeExtension
    {
        /// <summary>
        /// bool转换成 string
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="isLower"></param>
        /// <returns></returns>
        public static string ConvertToString(this bool obj, bool isLower = false)
        {
            if (isLower)
            {
                return obj.ToString().ToLower();
            }
            return obj.ToString();
        }

        /// <summary>
        /// 转换成 类名.值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ConvertToString<T>(this T obj)
        {
            if (obj != null)
            {
                string type = obj.GetType().Name;
                string value = obj.ToString();
                return type + "." + value;
            }
            return null;
        }
    }
}
