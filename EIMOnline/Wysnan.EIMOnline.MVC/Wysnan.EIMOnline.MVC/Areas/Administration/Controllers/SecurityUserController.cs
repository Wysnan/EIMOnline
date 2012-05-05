using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.MVC.Controllers;
using Wysnan.EIMOnline.Business;
using Wysnan.EIMOnline.Business.Framework;
using Wysnan.EIMOnline.Common.Framework.Enum;
using Wysnan.EIMOnline.MVC.Framework.Extensions;
using Wysnan.EIMOnline.Injection.JqGrid;

namespace Wysnan.EIMOnline.MVC.Areas.Administration.Controllers
{
    public class SecurityUserController : BaseController<ISecurityUser, SecurityUser>
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            //return View();
             return PartialView("PartialAdd");
        }

        public ActionResult Edit()
        {
            return PartialView("PartialEdit");
        }

        public ActionResult View(int id)
        {
            return PartialView("PartialView", id);
        }

        public ActionResult List2()
        {
            // ViewBag.test = "ads将法律skf加拉斯柯达将法律上飞机阿斯顿口附近阿斯顿发烧的考虑非";
            SecurityRole dd = new SecurityRole { ID = 1, RoleName = "wag" };
            ViewBag.test = dd;
            return View();
        }
        //public PartialView
    }
}
