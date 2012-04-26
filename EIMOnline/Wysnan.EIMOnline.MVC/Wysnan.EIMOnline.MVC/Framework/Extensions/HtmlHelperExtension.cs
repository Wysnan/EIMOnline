using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Common.Framework.Enum;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Business.Framework;
using Wysnan.EIMOnline.Tool.Extensions;
using Wysnan.EIMOnline.Tool.ToolMethod;
using Wysnan.EIMOnline.Tool.JqGridExtansions;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Common.Poco;
using System.Collections.Specialized;
namespace Wysnan.EIMOnline.MVC.Framework.Extensions
{
    public static class HtmlHelperExtension
    {
        //[Obsolete("由于cookie大小有限制，对于多字段的cookie缓存不适用，弃用这个方法", false)]
        public static MvcHtmlString Grid(this HtmlHelper helper, GridEnum gridEnum)
        {
            string key = SystemEntity.Instance.CurrentSecurityUser.ID + "_" + gridEnum.ToString();
            string cookieName = ConstEntity.Cookie_JqGridHtml + key;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                //直接读取cooke里内容
                string cookieValue = HttpUtility.UrlDecode(cookie.Value);
                return MvcHtmlString.Create(cookieValue);
            }

            #region jqGrid构造

            JqGrid jqGrid = GlobalEntity.Instance.Cache_JqGrid.JqGrids[gridEnum];
            if (jqGrid == null)
            {
                return MvcHtmlString.Empty;
            }
            var colModel = jqGrid._ColModel;
            if (colModel == null || colModel.Count == 0)
            {
                return MvcHtmlString.Empty;
            }
            string gridHtml = jqGrid.ConvertToHtml();
            #endregion

            #region write cookie
            jqGrid.WriteCookie(gridEnum, HttpUtility.UrlEncode(gridHtml));
            #endregion

            return MvcHtmlString.Create(gridHtml);
        }

        public static MvcHtmlString Menu(this HtmlHelper helper)
        {
            StringBuilder menuStr = new StringBuilder();
            menuStr.Append("");

            return MvcHtmlString.Empty;
        }






        #region 测试，不缓存
        public delegate string MvcCacheCallback(HttpContextBase context);

        public static object Substitute(this HtmlHelper html, MvcCacheCallback cb)
        {
            html.ViewContext.HttpContext.Response.WriteSubstitution(
                c => HttpUtility.HtmlEncode(
                    cb(new HttpContextWrapper(c))
                ));
            return null;
        }
        #endregion


    }
}