using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Wysnan.EIMOnline.Tool.MvcExpand
{
    public static class ControllerExpand
    {
        public static ActionResult Alert(this Controller controller, string message)
        {
            string str = string.Format("wAlert('{0}')", message);
            JavaScriptResult result = new JavaScriptResult();
            result.Script = str;
            return result;
        }
    }
}
