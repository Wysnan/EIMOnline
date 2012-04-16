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
            //List<SecurityUser> users = Model.List().ToList();

            //return View(users);
            return View();
        }

        public ActionResult Add()
        {
            Model.Add(null);
            return View();
        }
    }
}
