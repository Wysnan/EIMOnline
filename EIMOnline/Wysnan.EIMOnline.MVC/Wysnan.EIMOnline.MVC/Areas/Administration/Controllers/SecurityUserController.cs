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
namespace Wysnan.EIMOnline.MVC.Areas.Administration.Controllers
{
    public class SecurityUserController : BaseController<ISecurityUser, SecurityUser>
    {
        public ActionResult Index()
        {
            //HtmlHelper a = null;
            //a.Grid<SecurityUser, SecurityUser>(GridEnum.SecurityUser);
            List<SecurityUser> users = new List<SecurityUser>();
            users.Add(new SecurityUser() { ID = 1, Name = "zhangsan" });
            return View(users);
        }

        public ActionResult Add()
        {
            //Model.Add(null);;
            return View();
        }
    }
}
