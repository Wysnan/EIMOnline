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
    public class AttendanceBaseController : BaseController<ILookupModel, Lookup>
    {
        public ActionResult Index()
        {
            var entitys = GlobalEntity.Instance.Cache_Lookup.LookupDictionary[Common.Enum.LookupCodeEnum.EnumAttendanceBase];
            return View(entitys);
        }

        public ActionResult Attence()
        {
            var perAttendanceModel = GlobalEntity.Instance.ApplicationContext.GetObject("PersonnelAttendanceModel") as IPersonnelAttendanceModel;
            var user = SystemEntity.CurrentSecurityUser;
            PersonnelAttendance perAttendance = new PersonnelAttendance();
            perAttendance.SecurityUserID = user.ID;
            perAttendance.BeginWorkTime = DateTime.Now.ToLocalTime();
            perAttendanceModel.Add(perAttendance);

            return this.Alert("成功。");
        }

        public ActionResult AttenceOut()
        {
            return this.Alert("成功。");
        }

    }
}
