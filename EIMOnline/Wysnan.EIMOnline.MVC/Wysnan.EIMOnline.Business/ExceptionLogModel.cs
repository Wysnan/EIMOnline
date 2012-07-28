using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;


namespace Wysnan.EIMOnline.Business
{
    public static class ExceptionLogModel
    {
        public static void WriteErrorMessage(string message)
        {
            if (ConfigurationManager.AppSettings["ExceptionLogPath"] != null)
            {
                string directoryPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ExceptionLogPath"].ToString());
                DirectoryInfo exceptionDictory = new DirectoryInfo(directoryPath);
                if (!exceptionDictory.Exists) exceptionDictory.Create();
                string filepath = Path.Combine(directoryPath, DateTime.Now.ToString("yyyy-MM-dd") + ".log");

                FileInfo file = new FileInfo(filepath);

                FileStream filestream = null;
                if (!file.Exists)
                {
                    filestream = file.Create();
                }
                else
                {
                    filestream = new FileStream(filepath, FileMode.OpenOrCreate);
                }
                StreamWriter writer = new StreamWriter(filestream);
                writer.WriteLine(string.Format("『{0}』〖error:{1}〗", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + AppDomain.CurrentDomain.BaseDirectory, message),Encoding.GetEncoding("utf-8"));
                writer.Close();
                filestream.Close();
            }
        }
    }
}
