using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;
using System.Web.Routing;
using Wysnan.EIMOnline.Business.Framework;

namespace Wysnan.EIMOnline.MVC.Controllers
{
    public class GeneralController : Controller
    {
        public SystemEntity SystemEntity
        {
            get { return Session[ConstEntity.Session_SystemEntity] == null ? null : Session[ConstEntity.Session_SystemEntity] as SystemEntity; }
        }


    }
}