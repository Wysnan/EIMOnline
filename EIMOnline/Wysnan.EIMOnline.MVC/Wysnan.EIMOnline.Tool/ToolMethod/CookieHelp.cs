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
        /// <param name="minute">expires time(minute) 0:临时cookie,关闭浏览器后删除 -1:有效期1年</param>
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
                cookie.Values[item.Key] = item.Value;
            }
            if (minute > 0)
            {
                cookie.Expires = DateTime.Now.AddMinutes(minute);
            }
            if (minute <= -1)
            {
                cookie.Expires = DateTime.Now.AddMinutes(525600);//1 year
            }
            if (!string.IsNullOrEmpty(path))
            {
                //cookie.Path = path;
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }

    }
}
