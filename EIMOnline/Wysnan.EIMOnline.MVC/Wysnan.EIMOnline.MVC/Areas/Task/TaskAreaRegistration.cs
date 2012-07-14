using System.Web.Mvc;

namespace Wysnan.EIMOnline.MVC.Areas.Task
{
    public class TaskAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Task";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Task_default",
                "Task/{controller}/{action}/{id}",
                new { area = "Task", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
