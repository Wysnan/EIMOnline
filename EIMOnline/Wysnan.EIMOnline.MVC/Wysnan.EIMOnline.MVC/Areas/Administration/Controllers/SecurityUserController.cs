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
            var aa = GlobalEntity.Instance.Cache_JqGrid.JqGrids[GridEnum.SecurityUser];

            List<SecurityUser> users = Model.List().ToList();
            //HtmlHelper a = null;
            //a.Grid<SecurityUser, SecurityUser>(GridEnum.SecurityUser);
            return View(users);
        }

        public ActionResult Add()
        {
            Model.Add2(); 
            return View();
        }
    }
}
