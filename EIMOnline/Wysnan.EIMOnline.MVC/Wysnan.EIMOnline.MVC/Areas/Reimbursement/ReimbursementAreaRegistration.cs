using System.Web.Mvc;

namespace Wysnan.EIMOnline.MVC.Areas.Reimbursement
{
    public class ReimbursementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Reimbursement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Reimbursement_default",
                "Reimbursement/{controller}/{action}/{id}",
                new { area = "Reimbursement", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
