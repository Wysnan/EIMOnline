using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Web.Routing;
using System.ComponentModel;
using Wysnan.EIMOnline.Business.Framework;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.MVC.Controllers
{
    public class MenuController : GeneralController
    {
        public ActionResult ModuleMenu()
        {
            var area = this.SystemEntity.CurrentArea;
            if (string.IsNullOrEmpty(area))
            {
                area = "Personnel";
            }
            IList<SystemModule> systemModules = GlobalEntity.Instance.Cache_SystemModule.GetAllSystemModuleByArea(area);

            StringBuilder menu = new StringBuilder();
            menu.Append("<ul class=\"sf-menu sf-vertical\">");

            foreach (var item in systemModules)
            {
                SystemModuleDetailPage systemModuleDetailPage = GlobalEntity.Instance.Cache_SystemModule.GetSystemModuleDetailPage(item);
                int detailPageId = 0;
                if (systemModuleDetailPage != null)
                {
                    detailPageId = systemModuleDetailPage.ID;
                }
                menu.AppendFormat("<li class=\"current\"><a onclick=\"Navigation('{0}_{1}','{2}', '{3}', '{4}')\">{2}</a>", item.ID, detailPageId, item.ModuleName, item.ModuleMainUrl, item.ImageUrl);
                InitSubModuleMenu(menu, item);
                menu.Append("</li>");
            }

            menu.Append("</ul>");

            return Content(menu.ToString());
        }


        private void InitSubModuleMenu(StringBuilder menu, SystemModule systemModule)
        {
            if (systemModule.SystemModules != null && systemModule.SystemModules.Count > 0)
            {
                menu.Append("<ul>");
                foreach (var item in systemModule.SystemModules)
                {
                    SystemModuleDetailPage systemModuleDetailPage = GlobalEntity.Instance.Cache_SystemModule.GetSystemModuleDetailPage(item);
                    int detailPageId = 0;
                    if (systemModuleDetailPage != null)
                    {
                        detailPageId = systemModuleDetailPage.ID;
                    }
                    menu.AppendFormat("<li class=\"current\"><a onclick=\"Navigation('{0}_{1}','{2}', '{3}', '{4}')\">{2}</a>", item.ID, detailPageId, item.ModuleName, item.ModuleMainUrl, item.ImageUrl);
                    InitSubModuleMenu(menu, item);
                    menu.Append("</li>");
                }
                menu.Append("</ul>");
            }
        }
    }
}
