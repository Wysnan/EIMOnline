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
namespace Wysnan.EIMOnline.MVC.Areas.Reimbursement.Controllers
{
    public class ReimbursementTypeController : BaseController<IReimbursementTypeModel, ReimbursementType>
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
        public ActionResult Add(ReimbursementType reimbursementType)
        {
            Model.Add(reimbursementType);
            return this.Alert("添加成功", AlertAction.CloseCurrentWindow);
        }


        public ActionResult Edit(int id)
        {
            var model = Model.Get(id);
            return PartialView("PartialEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(ReimbursementType reimbursementType)
        {
            Model.Add(reimbursementType);
            return this.Alert("修改成功。", AlertAction.CloseCurrentWindow);
        }

        public ActionResult Delete(int id)
        {
            Model.LogicDelete(id);
            return this.Alert("删除成功。");
        }

        public ActionResult View(int id)
        {
            return View(PartialView(id));
        }
    }
}
