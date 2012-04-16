using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Wysnan.EIMOnline.Tool.ToolMethod
{
    public sealed class CookieHelp
    {
        private CookieHelp() { }

        public static void WriteCookie(string cookieName, string value)
        {

        }

        /// <summary>
        /// 写Cookie
        /// </summary>
        /// <param name="cookieName">key</param>
        /// <param name="value">value</param>
        /// <param name="minute">expires time(minute)</param>
        public static void WriteCookie(string cookieName, Dictionary<string, string> value, long minute)
        {
            WriteCookie(cookieName, value, minute, null);
        }

        /// <summary>
        /// 写Cookie
        /// </summary>
        /// <param name="cookieName">key</param>
        /// <param name="value">value</param>
        /// <param name="minute">expires time(minute)</param>
        /// <param name="path">limit path</param>
        public static void WriteCookie(string cookieName, Dictionary<string, string> value, long minute, string path)
        {
            if (string.IsNullOrEmpty(cookieName))
            {
                throw new ApplicationException("cookieName is null or empty");
            }
            if (value == null || value.Keys.Count == 0)
            {
                throw new ApplicationException("Value of Dictionary is null or empty");
            }
            HttpCookie cookie = new HttpCookie(cookieName);
            foreach (var item in value)
            {
                cookie[item.Key] = item.Value;
            }
            if (minute > 0)
            {
                cookie.Expires = DateTime.Now.AddMinutes(minute);
            }
            if (!string.IsNullOrEmpty(path))
            {
                cookie.Path = path;
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }
    }
}
