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
namespace Wysnan.EIMOnline.MVC.Areas.Permissions.Controllers
{
    public class PersonnelAttendanceController : BaseController<IPersonnelAttendanceModel, PersonnelAttendance>
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
        public ActionResult Add(PersonnelAttendance pt)
        {
            return PartialView("PartialAdd");
        }

        public ActionResult Edit(int id)
        {
            PersonnelAttendance pt = Model.Get(id);
            return PartialView("PartialEdit", pt);
        }

        [HttpPost]
        public ActionResult Edit(PersonnelAttendance pt)
        {
            return PartialView("PartialEdit", pt);
        }
    }
}
