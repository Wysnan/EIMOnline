using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.MVC.Controllers;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Business;

namespace Wysnan.EIMOnline.MVC.Areas.Administration.Controllers
{
    public class LogController : BaseController<IOperateLog, OperateLog>
    //
    // GET: /Administration/Log/
    {
        public ActionResult Index()
        {
            //List<OperateLog> users = Model.te
            OperateLogModel dd = new OperateLogModel();
            var tt = dd.test();

            return View();
        }

    }
}
