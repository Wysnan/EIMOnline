using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wysnan.EIMOnline.MVC.TestFile
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Wysnan.EIMOnline.Business.Framework.MessageModel message=new Business.Framework.MessageModel();
            Response.Write(message.GetMessage("1"));
        }
    }
}