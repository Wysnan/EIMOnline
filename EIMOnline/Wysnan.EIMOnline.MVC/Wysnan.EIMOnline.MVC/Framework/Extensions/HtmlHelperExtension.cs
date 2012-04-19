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
    }
}