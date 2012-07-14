using System.Web.Mvc;

namespace Wysnan.EIMOnline.MVC.Areas.Assets
{
    public class AssetsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Assets";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Assets_default",
                "Assets/{controller}/{action}/{id}",
                new { area = "Assets", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
