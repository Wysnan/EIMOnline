using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Business.Framework;
using Wysnan.EIMOnline.Common.Framework.Enum;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Tool.JqGridExtansions;

namespace Wysnan.EIMOnline.MVC.Controls.Controllers
{
    public class JqGridController : Controller
    {
        //
        // GET: /JqGrid/
        [OutputCache(Duration = 50000, VaryByParam = "none")]
        public ActionResult Index(GridEnum gridEnum)
        {
            JqGrid jqGrid = GlobalEntity.Instance.Cache_JqGrid.JqGrids[gridEnum];
            if (jqGrid == null)
            {
                return Content("");
            }
            var colModel = jqGrid._ColModel;
            if (colModel == null || colModel.Count == 0)
            {
                return Content("");
            }
            string gridHtml = jqGrid.ConvertToHtml();

            return Content("");
        }

    }
}
