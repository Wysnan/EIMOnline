using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wysnan.EIMOnline.Business.Framework;
using Wysnan.EIMOnline.Business.Framework.Cache;

namespace Wysnan.EIMOnline.MVC.TestFile
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(GlobalEntity.Instance.Cache_Message.GetMessge("1"));
            Cache_Message.Instance.ReLoadData();
        }
    }
}