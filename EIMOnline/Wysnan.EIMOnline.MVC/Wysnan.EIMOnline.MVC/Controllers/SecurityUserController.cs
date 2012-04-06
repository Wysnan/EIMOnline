using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
namespace Wysnan.EIMOnline.MVC.Controllers
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
