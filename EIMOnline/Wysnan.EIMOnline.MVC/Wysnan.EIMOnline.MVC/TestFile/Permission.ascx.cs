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
        public ISystemModule SystemModel { get; set; }

        public Permission()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            string typeName = "SystemPermissionModel";
            SystemPermissions = ctx.GetObject(typeName) as ISystemPermission;

            string typeName1 = "SystemModuleModel";
            SystemModel = ctx.GetObject(typeName1) as ISystemModule;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            var roleid = 1;
            var perList = SystemPermissions.List().Where(o => o.RoleID == roleid);
            foreach (var perItem in perList)
            {
                if (perItem.SystemModuleID == 1)
                {
                    this.Button2.Visible = true;
                }
                if (perItem.SystemModuleID == 2)
                {
                    this.Label2.Visible = true;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                ImageButton imgbtn = new ImageButton();
                imgbtn = new ImageButton();
                imgbtn.ID = "";//你可以自己赋ID，也可以不赋，页面框架会自动分配
                //取得ImageButtn.ImageUrl的值
                //imgbtn.ImageUrl = this.DataList1.Items[i].Cells[7].Text;
                //this.DataList1.Items[i].Cells[6].Controls.Add(imgbtn);
            }
        }
    }
}