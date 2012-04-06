using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.MVC.Controllers;
namespace Wysnan.EIMOnline.MVC.Areas.Administration.Controllers
{
    public class SecurityUserController : BaseController<ISecurityUser,SecurityUser>
    {
        public ActionResult Index()
        {
            List<SecurityUser> users = Model.List().ToList();
            return View(users);
        }

    }
}
