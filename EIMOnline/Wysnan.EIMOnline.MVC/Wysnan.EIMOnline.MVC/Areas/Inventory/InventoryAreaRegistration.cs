using System.Web.Mvc;

namespace Wysnan.EIMOnline.MVC.Areas.Inventory
{
    public class InventoryAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Inventory";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Inventory_default",
                "Inventory/{controller}/{action}/{id}",
                new { area = "Inventory", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
