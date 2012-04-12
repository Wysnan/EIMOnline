using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Wysnan.EIMOnline.Tool.Extensions
{
    public static class ArrayExtension
    {
        /// <summary>
        /// 把数组转换成字符串
        /// </summary>
        /// <param name="array">值类型或string的数组</param>
        /// <param name="splitString"></param>
        /// <returns></returns>
        public static string ConvertToString<T>(this IEnumerable<T> array, string splitString) where T : struct
        {
            if (array == null)
            {
                throw new NullReferenceException("数组引用为空。");
            }
            StringBuilder arrayString = new StringBuilder();
            foreach (var item in array)
            {
                arrayString.AppendFormat("{0},", item);
            }
            int length = arrayString.Length;
            if (length > 0)
            {
                arrayString.Remove(length - 1, 1);
            }
            return arrayString.ToString();
        }

        /// <summary>
        /// 把数组转换成字符串
        /// </summary>
        /// <param name="array">值类型或string的数组</param>
        /// <param name="splitString"></param>
        /// <returns></returns>
        public static string ConvertToString(this IEnumerable<string> array, string splitString)
        {
            if (array == null)
            {
                throw new NullReferenceException("数组引用为空。");
            }
            StringBuilder arrayString = new StringBuilder();
            foreach (var item in array)
            {
                arrayString.AppendFormat("{0},", item);
            }
            int length = arrayString.Length;
            if (length > 0)
            {
                arrayString.Remove(length - 1, 1);
            }
            return arrayString.ToString();
        }

    }
}
