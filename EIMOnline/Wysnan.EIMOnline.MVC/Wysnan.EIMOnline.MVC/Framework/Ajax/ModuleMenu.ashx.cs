using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Business.Framework;
using System.Text;

namespace Wysnan.EIMOnline.MVC.Framework.Ajax
{
    /// <summary>
    /// Summary description for ModuleMenu1
    /// </summary>
    public class ModuleMenu1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";


            try
            {
                int meetid = int.Parse(context.Request.QueryString["meetid"]);
                var systemModules = GlobalEntity.Instance.Cache_SystemModule.SystemModules.Where(s => s.ModuleTypeId == meetid);
              
                StringBuilder menuStr = new StringBuilder();
                menuStr.Append("<ul class=\"ui_menu\">");
                var list = systemModules.ToList();
                foreach (var item in list)
                {
                    menuStr.AppendFormat("<li><a onclick=\"Navigation('{0}','{1}', '{2}', '{3}')\">{1}</a></li>", item.ID, item.ModuleName, item.ModuleMainUrl, "img.jpg");
                }
                menuStr.Append("</ul>");
                //string str = "aas";

                //MeetingJson meetingJson = new MeetingJson();

                //if (meetid != 0)
                //{
                //    meetingJson.CellerList = returnCellerList(meetid);

                //}
                //str = JsonConvert.SerializeObject(meetingJson);
                context.Response.Write(menuStr);
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}