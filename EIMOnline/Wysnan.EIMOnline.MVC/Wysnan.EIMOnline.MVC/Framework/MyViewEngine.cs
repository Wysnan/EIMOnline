using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wysnan.EIMOnline.MVC.Framework
{
    public class MyViewEngine : RazorViewEngine
    {
        public MyViewEngine()
        {
            MasterLocationFormats = new[] {
                "~/Controls/Views/{1}/{0}.master",
                "~/Controls/Views/Shared/{0}.master"
            };
            ViewLocationFormats = new[] {
                "~/Controls/Views/{1}/{0}.cshtml",
                "~/Controls/Views/Shared/{0}.cshtml"
            };

            PartialViewLocationFormats = ViewLocationFormats;
        }
    }
}