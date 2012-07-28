using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.MVC.Controllers;

namespace Wysnan.EIMOnline.MVC.Areas.Personnel.Controllers
{
    public class SecurityRoleController : BaseController<ISecurityRole, SecurityRole>
    {
        //public ActionResult Index()
        //{
        //    return View(Model.List());
        //}
        ////
        //// GET: /Administration/SecurityRole/Details/5

        //public ActionResult Details(int id)
        //{
        //    SecurityRole editcontex = Model.Get(id);
        //    return View(editcontex);
        //}

        ////
        //// GET: /Administration/SecurityRole/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Administration/SecurityRole/Create

        //[HttpPost]
        //public ActionResult Create(SecurityRole securityrole)
        //{
        //    try
        //    {
        //        //操作数据的代码
        //        Model.Add(securityrole);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Administration/SecurityRole/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    SecurityRole editcontex = Model.Get(id);
        //    return View(editcontex);
        //}

        ////
        //// POST: /Administration/SecurityRole/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, SecurityRole securityrole)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
        //        Model.Update(securityrole);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Administration/SecurityRole/Delete/5

        //public ActionResult Delete(int id)
        //{           
        //    return View();
        //}

        ////
        //// POST: /Administration/SecurityRole/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, SecurityRole securityrole)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        Model.Delete(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            //return View();
            return PartialView("PartialAdd");
        }

        public ActionResult Edit()
        {
            return PartialView("PartialEdit");
        }


        public ActionResult List2()
        {
            // ViewBag.test = "ads将法律skf加拉斯柯达将法律上飞机阿斯顿口附近阿斯顿发烧的考虑非";
            SecurityRole dd = new SecurityRole { ID = 1, RoleName = "wag" };
            ViewBag.test = dd;
            return View();
        }
    }
}
