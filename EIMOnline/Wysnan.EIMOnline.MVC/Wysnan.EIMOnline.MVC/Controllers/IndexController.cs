using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Tool.MvcExpand;
using Wysnan.EIMOnline.Common.Framework;

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
        public ActionResult Login(SecurityUser user)
        {
            if (user.UserLoginID == "admin" && user.UserLoginPwd == "admin")
            {
                SystemEntity.Instance.CurrentSecurityUser = user;
                return RedirectToRoute("Administration_default", new { controller = "SecurityUser", action = "Index" });
                //return RedirectToAction("Index");
            }
            return this.Alert("用户名或密码错误");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}