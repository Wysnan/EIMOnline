using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Poco;
using Spring.Context;
using Spring.Context.Support;

namespace Wysnan.EIMOnline.MVC.TestFile
{
    public partial class Permission : System.Web.UI.UserControl
    {
        public ISystemPermission SystemPermissions { get; set; }

        private Permission()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            string typeName = "SystemPermissionModel";
            SystemPermissions = ctx.GetObject(typeName) as ISystemPermission;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var perList = SystemPermissions.List();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Visible = true;
            this.Label2.Visible = true;
            this.Label3.Visible = true;
        }
    }
}