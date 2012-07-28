using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Business.Framework;
using System.Text;
using Wysnan.EIMOnline.Common.Framework;
using System.Text.RegularExpressions;
using System.IO;

namespace Wysnan.EIMOnline.MVC.Framework.Ajax
{
    /// <summary>
    /// Summary description for ModuleMenu1
    /// </summary>
    public class UploadFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                string fileName = context.Request.Headers["X-File-Name"];

                using (FileStream inputStram = File.Create(context.Server.MapPath("/UpLoadFiles/") + fileName))
                {
                    SaveFile(context.Request.InputStream, inputStram);
                }

            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        protected void SaveFile(Stream stream, FileStream inputStream)
        {
            int bufSize = 1024;
            int byteGet = 0;
            byte[] buf = new byte[bufSize];
            while ((byteGet = stream.Read(buf, 0, bufSize)) > 0)
            {
                inputStream.Write(buf, 0, byteGet);
            }
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