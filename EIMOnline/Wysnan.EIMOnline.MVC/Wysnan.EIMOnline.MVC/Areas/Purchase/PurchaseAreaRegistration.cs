using System.Web.Mvc;

namespace Wysnan.EIMOnline.MVC.Areas.Purchase
{
    public class PurchaseAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Purchase";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Purchase_default",
                "Purchase/{controller}/{action}/{id}",
                new { area = "Purchase", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
