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
using Wysnan.EIMOnline.MVC.Tool.MvcExpand;
using Wysnan.EIMOnline.Tool.Extensions;

namespace Wysnan.EIMOnline.MVC.Areas.Personnel.Controllers
{
    public class SecurityUserController : BaseController<ISecurityUser, SecurityUser>
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return PartialView("PartialAdd");
        }

        [HttpPost]
        public ActionResult Add(SecurityUser user)
        {
            Model.Add(user);
            return this.Alert("添加成功。", AlertAction.CloseCurrentWindow);
        }

        public ActionResult Edit(int id)
        {
            var entity = Model.Get(id);
            return PartialView("PartialEdit", entity);
        }

        [HttpPost]
        public ActionResult Edit(SecurityUser user)
        {
            var result = Model.Update(user);

            if (result.ResultStatus == false)
            {
                return this.Alert(result.Message);
            }
            return this.Alert("修改成功。", AlertAction.CloseCurrentWindow);
        }

        public ActionResult Delete(string ids)
        {
            Model.LogicDelete(ids.ConvertToArray());
            return this.Alert("删除成功。");
        }

        public ActionResult View(int id)
        {
            return View(PartialView(id));
        }
    }
}
