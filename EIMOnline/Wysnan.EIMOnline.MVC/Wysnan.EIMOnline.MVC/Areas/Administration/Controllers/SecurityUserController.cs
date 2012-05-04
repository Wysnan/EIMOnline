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
        public IzMetaFormLayout zMetaFormLayoutModel{get;set;}

      

        public ActionResult Add()
        {
            return PartialView("PartialAdd");
        }

        public ActionResult Edit()
        {
            return PartialView("PartialEdit");
        }

        public ActionResult Test()
        {
            zMetaFormLayoutModel dd = new Business.zMetaFormLayoutModel();
            // IList<zMetaFormLayout> ViewLayout = zMetaFormLayoutModel.List().Where(t => t.EntityName == "SecurityUser").ToList();
            IList<zMetaFormLayout> ViewLayout = dd.List().Where(t => t.EntityName == "SecurityUser").ToList();
            if (ViewLayout != null && ViewLayout.Count > 0)
            {
                ViewBag.ViewLayout = ViewLayout;
            }
            else
            {
                throw new ArgumentException("not config data");
            }
            ISecurityUser cc = new SecurityUserModel();
            var userEntity=cc.List().FirstOrDefault();
            // var userEntity = Model.List().FirstOrDefault();
            ViewBag.entity = userEntity;

            return View();
        }
        //public PartialView
    }
}
