using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Business.Framework;
using System.Text;
using Wysnan.EIMOnline.Common.Framework;
using System.Text.RegularExpressions;

namespace Wysnan.EIMOnline.MVC.Framework.Ajax
{
    /// <summary>
    /// Summary description for ModuleMenu1
    /// </summary>
    public class SystemModule : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                int typeId = 0;
                bool isOk = int.TryParse(context.Request.QueryString["typeId"], out typeId);
                if (isOk)
                {
                    switch (typeId)
                    {
                        case 1:
                            GetSystemModule(context);
                            break;
                    }
                }


                //int meetid = int.Parse(context.Request.QueryString["meetid"]);
                //var systemModules = GlobalEntity.Instance.Cache_SystemModule.SystemModules.Where(s => s.ModuleTypeId == meetid);

                //StringBuilder menuStr = new StringBuilder();
                //menuStr.Append("<ul class=\"ui_menu\">");
                //var list = systemModules.ToList();
                //foreach (var item in list)
                //{
                //    menuStr.AppendFormat("<li><a onclick=\"Navigation('{0}','{1}', '{2}', '{3}')\">{1}</a></li>", item.ID, item.ModuleName, item.ModuleMainUrl, "img.jpg");
                //}
                //menuStr.Append("</ul>");
                ////string str = "aas";

                ////MeetingJson meetingJson = new MeetingJson();

                ////if (meetid != 0)
                ////{
                ////    meetingJson.CellerList = returnCellerList(meetid);

                ////}
                ////str = JsonConvert.SerializeObject(meetingJson);
                //context.Response.Write(menuStr);
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }

            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }

        private void GetSystemModule(HttpContext context)
        {
            string url = context.Request.QueryString["url"];
            if (string.IsNullOrEmpty(url))
            {
                return;
            }
            Uri uri = new Uri(url);

            string pattern = "^(/[a-zA-Z]+){3}";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(uri.AbsolutePath);
            string value = match.Value;
            if (!string.IsNullOrEmpty(value))
            {
                SystemModuleDetailPage systemModuleDetailPage = GlobalEntity.Instance.Cache_SystemModule.GetSystemModuleDetailPage(value);
                if (systemModuleDetailPage != null)
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(new { ID = systemModuleDetailPage.ID, SMID = systemModuleDetailPage.SystemModule.ID, Title = systemModuleDetailPage.DetailPageTitle });
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(json);
                }
            }
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