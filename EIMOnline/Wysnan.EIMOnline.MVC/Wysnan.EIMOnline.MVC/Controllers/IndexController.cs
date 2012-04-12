using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Tool.MvcExpand;

namespace Wysnan.EIMOnline.MVC.Controllers
{
    public class IndexController : GeneralController
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SecurityUser user)
        {
            if (user.LoginID == "admin" && user.Pwd == "admin")
            {
                return RedirectToRoute("Administration_default", new { controller = "SecurityUser", action = "Index" });
                //return RedirectToAction("Index", "SecurityUser", new { area = "Administration" });
                //Response.Redirect("~/Administration/SecurityUser/Index",true);
            }
            return this.Alert("用户名或密码错误");
        }
    }
}
