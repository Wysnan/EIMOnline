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
using System.Data;

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

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {

                DataTable dt = new DataTable();

                dt.Columns.Add("abb");

                DataRow row = dt.NewRow();

                ViewState["dt"] = dt;
            }
        }

        #region MyRegion
        //#region Web 窗体设计器生成的代码

        //override protected void OnInit(EventArgs e)
        //{

        //    //

        //    // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。

        //    //

        //    InitializeComponent();

        //    base.OnInit(e);

        //}



        ///// <summary>

        ///// 设计器支持所需的方法 - 不要使用代码编辑器修改

        ///// 此方法的内容。

        ///// </summary>

        //private void InitializeComponent()
        //{

        //    this.DataList1.ItemCreated += new System.Web.UI.WebControls.DataListItemEventHandler(this.DataList1_ItemCreated);

        //    this.Button1.Click += new System.EventHandler(this.Button1_Click);

        //    this.Load += new System.EventHandler(this.Page_Load);

        //}

        //#endregion

        //#region
        //private void Button1_Click(object sender, System.EventArgs e)
        //{

        //    DataTable dt = (DataTable)ViewState["dt"];

        //    DataRow row = dt.NewRow();

        //    dt.Rows.Add(row);

        //    ViewState["dt"] = dt;

        //    this.DataList1.DataSource = dt;

        //    this.DataList1.DataBind();

        //}

        //private void DataList1_ItemCreated(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        //{

        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        ImageButton imgbtn = new ImageButton();
        //        imgbtn = new ImageButton();
        //        imgbtn.ID = "";
        //        //TextBox tb = new TextBox();

        //        e.Item.Controls.Add(imgbtn);

        //    }

        //}
        //#endregion


        //protected void Button1_Click(object sender, EventArgs e)
        //{

        //    var roleid = 1;
        //    var perList = SystemPermissions.List().Where(o => o.RoleID == roleid);
        //    foreach (var perItem in perList)
        //    {
        //        if (perItem.SystemModuleID == 1)
        //        {
        //            this.Button2.Visible = true;
        //        }
        //        if (perItem.SystemModuleID == 2)
        //        {
        //            this.Label2.Visible = true;
        //        }
        //    }
        //} 
        #endregion

        protected void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                ImageButton imgbtn = new ImageButton();
                imgbtn = new ImageButton();
                imgbtn.ID = "";//你可以自己赋ID，也可以不赋，页面框架会自动分配
                //取得ImageButtn.ImageUrl的值
                //imgbtn.ImageUrl = this.DataList1.Items[i].Cells[7].Text;
                //this.DataList1.Items[i].Controls.Add(imgbtn);
                DataTable dt = (DataTable)ViewState["dt"];

                DataRow row = dt.NewRow();

                dt.Rows.Add(row);

                ViewState["dt"] = dt;

                this.DataList1.DataSource = dt;

                this.DataList1.DataBind();
                //this.DataList1.Items[0].Controls.Add(imgbtn);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["dt"];

            DataRow row = dt.NewRow();
            DataRow row1 = dt.NewRow();

            dt.Rows.Add(row1);
            dt.Rows.Add(row);

            ViewState["dt"] = dt;

            this.DataList1.DataSource = dt;

            this.DataList1.DataBind();

        }

        protected void DataList1_ItemCreated(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
              
                //TextBox tb = new TextBox();
                LinkButton lb = new LinkButton();
                lb.Text = "aa";
                lb.ID = "lb1";
                lb.PostBackUrl = "ViewPage1.aspx";

                //ImageButton imgbtn = new ImageButton();
                //imgbtn = new ImageButton();
                //imgbtn.ID = "";
                //imgbtn.ImageUrl = "ViewPage1.aspx";
                //imgbtn.Attributes.Add("onclick", "www.baidu.com");

                e.Item.Controls.Add(lb);
            }
        }

    }
}
