using Wysnan.EIMOnline.MVC.Controllers;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Poco;
using System.Web.Mvc;

namespace Wysnan.EIMOnline.MVC.Areas.Administration.Controllers
{
    public class SecurityUserRoleController : BaseController<ISecurityUser, SecurityUser>
    {
        //
        // GET: /Administration/SecurityUserRole/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Administration/SecurityUserRole/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Administration/SecurityUserRole/Create

        public ActionResult Create()
        {
          //ISecurityRole isr=new ISecurityRole();

          //  ViewBag.SecurityUserID = new SelectList(su.List(), "ID", "UserName");
          //  ViewBag.SecurityRoleID = new SelectList(sr., "ID", "RoleName");
            return View();
        } 

        //
        // POST: /Administration/SecurityUserRole/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Administration/SecurityUserRole/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Administration/SecurityUserRole/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Administration/SecurityUserRole/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Administration/SecurityUserRole/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
