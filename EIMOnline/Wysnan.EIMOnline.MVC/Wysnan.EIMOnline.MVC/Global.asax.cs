using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Wysnan.EIMOnline.MVC.Framework;
using Wysnan.EIMOnline.Business.Framework;
using System.Configuration;
using System.Data.SqlClient;
using Spring.Context;
using Spring.Context.Support;

namespace Wysnan.EIMOnline.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Index", action = "Login", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            //ViewEngines.Engines.Add(new MyViewEngine());
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            SystemInitialization.Application_Start();
        }

        protected void Session_Start()
        {
            SystemInitialization.Session_Start();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception unhandledException = Server.GetLastError();
            // string errorMessager = unhandledException.InnerException.Message.ToString();

            //1 将错误写入日志
            //2 将错误用Html格式发送邮件

            //Server.ClearError();
            //HttpException httpEx = Server.GetLastError() as HttpException;
        }
    }
}