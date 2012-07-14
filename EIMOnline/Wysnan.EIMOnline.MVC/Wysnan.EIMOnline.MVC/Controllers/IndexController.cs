using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.MVC.Tool.MvcExpand;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Business.Framework;

namespace Wysnan.EIMOnline.MVC.Controllers
{
    public class IndexController : GeneralController
    {
        ISecurityUser SecurityUserModel { get; set; }

        public ActionResult Index(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(SecurityUser user)
        {
            SecurityUserModel = GlobalEntity.Instance.ApplicationContext.GetObject("SecurityUserModel") as ISecurityUser;
            var result = SecurityUserModel.Login(user);

            if (result.ResultStatus == false)
            {
                return this.Alert(result.Message);
            }
            else
            {
                SystemEntity.CurrentSecurityUser = result.ResultObject;
                return this.RedirectUrl("Index");
            }
            //if (user.UserLoginID == "admin" && user.UserLoginPwd == "admin")
            //{
            //    if (SystemEntity != null)
            //    {
            //        SystemEntity.CurrentSecurityUser = user;
            //        //return RedirectToRoute("Administration_default", new { controller = "SecurityUser", action = "Index" });
            //        return RedirectToAction("Index");
            //    }
            //}
            //return this.Alert("用户名或密码错误");
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (SystemEntity.CurrentSecurityUser != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}