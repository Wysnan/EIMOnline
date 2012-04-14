using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wysnan.EIMOnline.Business.Framework;
using Wysnan.EIMOnline.Business.Framework.Cache;
using System.IO;
using System.Configuration;
using System.Data;
using System.Web.Caching;
using System.Data.Linq;

namespace Wysnan.EIMOnline.MVC.TestFile
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// 测试一般的缓存（更新缓存）
            /// 
            //Response.Write(GlobalEntity.Instance.Cache_Message.GetMessge("1"));
            //Cache_Message.Instance.ReLoadData();

            /// 文件缓存依赖
            object obj = new object();
            FileInfo file = new FileInfo(HttpContext.Current.Server.MapPath("~/Config/FileDependency1.txt"));
            if (CacheModel.GetCache("filecahce1") != null)
            {
                FileInfo testFile = CacheModel.GetCache("filecahce1") as FileInfo;
                StreamReader read = new StreamReader(testFile.FullName);
                Response.Write(read.ReadToEnd());
                read.Close();
                read.Dispose();
            }
            else
            {
                CacheModel.SetFileDenpendencyCahce("filecahce1", file, HttpContext.Current.Server.MapPath("~/Config/FileDependency1.txt"));
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            using (DataClasses1DataContext dd = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["DbCacheTest"].ToString()))
            {
                if (CacheModel.GetCache("T_Student2Cahce") != null)
                {
                    this.GridView1.DataSource = CacheModel.GetCache("T_Student2Cahce") as Table<T_Student2>;
                    GridView1.DataBind();
                }
                else
                {
                    var studentTable = dd.T_Student2s;
                    this.GridView1.DataSource = dd.GetTable<T_Student2>();
                    GridView1.DataBind();
                    CacheModel.SetSqlDenpendencyCahce("T_Student2Cahce", studentTable, "T_Student2");
                }
            }
        }


    }
}
