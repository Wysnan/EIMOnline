using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Common.Framework.Enum;
using System.Web;
using Wysnan.EIMOnline.Tool.Extensions;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Tool.ToolMethod;
using Wysnan.EIMOnline.Business.Framework;

namespace Wysnan.EIMOnline.Tool.JqGridExtansions
{
    public static class JqGridHelp
    {
        public static string ConvertToHtml(this JqGrid jqGrid)
        {
            if (jqGrid == null)
            {
                return null;
            }
            var colModel = jqGrid._ColModel;
            if (colModel == null || colModel.Count == 0)
            {
                return null;
            }
            string urlController = HttpContext.Current.Request.Url.AbsolutePath;

            #region 获取模块
            IList<SystemModule> systemModules = GlobalEntity.Instance.Cache_SystemModule.SystemModules;
            SystemModule currentModule = null;
            if (systemModules != null)
            {
                currentModule = systemModules.Where(a => a.ModuleMainUrl.Equals(urlController, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (currentModule == null)
                {
                    throw new ApplicationException("模块信息为空。");
                }
            }
            #endregion
            //根据获取的模块和详细action信息，构造jqGrid路径和action
            string currentModuleName = string.Format("/{0}/{1}", currentModule.ModuleType.Area, currentModule.ControllerModule);
            string urlList = currentModuleName + "/List";
            string urlAdd = currentModuleName + "/Add";
            string urlView = currentModuleName + "/View";
            string urlEdit = currentModuleName + "/Edit";
            string urlDelete = currentModuleName + "/Delete";

            SystemModuleDetailPage detailPageView = GlobalEntity.Instance.Cache_SystemModule.GetSystemModuleDetailPage(currentModule, urlView);
            SystemModuleDetailPage detailPageEdit = GlobalEntity.Instance.Cache_SystemModule.GetSystemModuleDetailPage(currentModule, urlEdit);
            SystemModuleDetailPage detailPageAdd = GlobalEntity.Instance.Cache_SystemModule.GetSystemModuleDetailPage(currentModule, urlAdd);

            string setJqGridColumn = urlController + "/SetJqGridColumn";
            StringBuilder grid = new StringBuilder();
            StringBuilder StrColNames = new StringBuilder();
            StringBuilder StrColModel = new StringBuilder();
            StringBuilder StrShowField = new StringBuilder();//显示的字段
            StrShowField.Append("New(");
            foreach (var item in colModel)
            {
                string queryName = item.Name;
                string showName = GetForeignKeyField(queryName);

                StrColNames.AppendFormat("'{0}',", item.Label);
                StrColModel.AppendFormat("{0} name: '{1}', index: '{2}', width: {3}, editable: {4},align: '{5}',datefmt:'{6}'{7},searchoptions:{8},hidden:{9}{10},",
                    "{", showName, item.Name, item.Width, item.Editable.ConvertToString(true), item.Align, item.Detefmt, item.Formatter,
                    item.SearchOptions.ToString(), item.Hidden.ConvertToString(true), "}");
                StrShowField.AppendFormat("{0} as {1},", queryName, showName);
            }
            StrColNames.Remove(StrColNames.Length - 1, 1);
            StrColModel.Remove(StrColModel.Length - 1, 1);
            if (StrShowField.Length > 4)
            {
                StrShowField.Remove(StrShowField.Length - 1, 1);
            }
            StrShowField.Append(")");

            Random r = new Random();
            int id = r.Next(1000, 9999);
            string list = "list" + id;
            string pager = "pager" + id;

            grid.AppendFormat("<div id=\"div_jq_{0}\" jqid=\"{0}\" style=\"height:100%;width:100%\">", id);
            grid.AppendFormat("<table id=\"{0}\" style=\"width:100%;height:100%\">", list);
            grid.Append("</table>");
            grid.AppendFormat("<div id=\"{0}\">", pager);
            grid.Append("</div>");
            grid.Append("<script type=\"text/javascript\" language=\"javascript\">");
            grid.Append("$(document).ready(function () {");
            grid.AppendFormat("$(\"#{0}\").jqGrid({{", list);
            grid.AppendFormat("url: '{0}',", urlList);// jqGrid._Url);
            grid.Append("autowidth:true,");
            grid.AppendFormat("datatype: '{0}',", jqGrid._DataType);
            grid.AppendFormat("mtype: '{0}',", jqGrid._Mtype);
            grid.AppendFormat("colNames: [{0}],", StrColNames.ToString());
            grid.Append("colModel: [");
            grid.Append(StrColModel.ToString());
            grid.Append("],");
            grid.AppendFormat("pager: '#{0}',", pager);
            grid.AppendFormat("sortable: {0},", jqGrid._Sortable.ConvertToString(true));
            grid.AppendFormat("rowNum: {0},", jqGrid.RowNum);
            grid.Append("multiselect: true,");
            grid.Append("forceFit: true,");
            //grid.Append("hidegrid: true,");
            grid.Append("prmNames: { page:\"page\",rows:\"rows\", sort: \"sidx\",order:\"sord\", search:\"search\", nd:\"nd\", npage:\"npage\" },");
            grid.Append("jsonReader: {");
            grid.AppendFormat("root: \"{0}\",", "rows");// jqGrid._JsonReader_Root);
            grid.AppendFormat("repeatitems: {0}", jqGrid._JsonReader_Repeatitems.ConvertToString(true));
            grid.Append("},");
            grid.AppendFormat("rowList: [{0}],", jqGrid._RowList.ConvertToString(","));
            grid.AppendFormat("sortname: '{0}',", jqGrid.SortName);
            grid.AppendFormat("sortorder: '{0}',", jqGrid.SortOrder);
            grid.AppendFormat("height:{0},", "450");
            grid.AppendFormat("viewrecords: {0},", jqGrid._ViewRecords.ConvertToString(true));
            grid.AppendFormat("caption: '&nbsp;{0}',", jqGrid._Caption);
            grid.AppendFormat("postData:{{showFiled:'{0}'}},", StrShowField.ToString());
            grid.AppendFormat("saerchTextField:'{0}',", jqGrid.SearchBoxField);
            grid.AppendFormat("onCellSelect:function(rowid,iCol){{if(iCol!=0){{var id=$(this).getCell(rowid,'ID');Navigation('{0}_{1}','{2}','{3}'+'/'+id,'{4}')}}}}", currentModule.ID, detailPageView.ID, detailPageView.DetailPageTitle, urlView, currentModule.ImageUrl);
            grid.Append("});");
            grid.AppendFormat("var grid=$(\"#{0}\");", list);
            grid.AppendFormat("grid.jqGrid('navGrid', '#{0}', {{ edit: false, add: false, del: false,view:false }},{{}},{{}},{{}},{{multipleSearch:true,overlay:false,closeAfterSearch:true,closeOnEscape:true}})", pager);
            //ui-icon-pencil
            grid.AppendFormat(".navButtonAdd('#{5}',{{buttonicon:'ui-icon-pencil',caption:'',id:'GridButtonEdit',title:'Edit Record',onClickButton:function(e){{var id=grid.getCell(grid.jqGrid('getGridParam','selarrrow'),'ID');if(id==false){{return;}} Navigation('{0}_{1}','{2}','{3}'+'/'+id,'{4}')}}}}).navSeparatorAdd('#{5}',{{}})", currentModule.ID, detailPageEdit.ID, detailPageEdit.DetailPageTitle, urlEdit, currentModule.ImageUrl, pager);
            grid.AppendFormat(".navButtonAdd('#{5}',{{buttonicon:'ui-icon-plus',caption:'',id:'GridButtonAdd',title:'Add Record',onClickButton:function(e){{Navigation('{0}_{1}','{2}','{3}','{4}')}}}}).navSeparatorAdd('#{5}',{{}})", currentModule.ID, detailPageAdd.ID, detailPageAdd.DetailPageTitle, urlAdd, currentModule.ImageUrl, pager);
            grid.AppendFormat(".navButtonAdd('#{0}',{{buttonicon:'ui-icon-minusthick',caption:'',id:'GridButtonDelete',title:'Delete Record',onClickButton:function(e){{var ids=grid.getGridParam('selarrrow');if(ids==false){{return;}} DeleteRecord(grid,'{1}',ids)}}}}).navSeparatorAdd('#{0}',{{}})", pager, urlDelete);
            grid.AppendFormat(".navButtonAdd('#{0}',{{buttonicon:'ui-icon-calculator',caption:'',id:'GridButtonColumn',title:'Reorder Columns',onClickButton:function(e){{grid.jqGrid('columnChooser',{{ 'done': function(perm) {{ if (perm) {{ this.jqGrid('remapColumns', perm, true); persist(this);}}}}}});}}}}).navSeparatorAdd('#{0}',{{}});", pager);
            grid.Append("grid.jqGrid('filterToolbar',{stringResult: true,searchOnEnter : true});");
            //grid.Append("grid.setGridHeight('100%');");
            grid.Append("});");
            grid.AppendFormat("var SetJqGridColumn='{0}';", setJqGridColumn);
            //grid.AppendFormat("GlobalObj.AddPage(new Page(\"list\"));");


            grid.Append("</script>");
            grid.Append("</div>");
            string gridHtml = grid.ToString();
            return gridHtml;
        }

        public static void WriteCookie(this JqGrid jqGrid, GridEnum gridEnum)
        {
            string gridHtml = jqGrid.ConvertToHtml();
            jqGrid.WriteCookie(gridEnum, HttpUtility.UrlEncode(gridHtml));
        }
        public static void WriteCookie(this JqGrid jqGrid, GridEnum gridEnum, string gridHtml)
        {
            SystemEntity systemEntity = HttpContext.Current.Session[ConstEntity.Session_SystemEntity] as SystemEntity;
            string key = systemEntity.CurrentSecurityUser.ID + "_" + gridEnum.ToString();
            string cookieName = ConstEntity.Cookie_JqGridHtml + key;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            string path = "/";
            CookieHelp.WriteCookie(cookieName, gridHtml, -1, path);
        }

        /// <summary>
        /// 获取外键字段名称。例如：SecurityUser.Name 返回
        /// </summary>
        /// <param name="fullname">SecurityUser.Name</param>
        /// <returns></returns>
        private static string GetForeignKeyField(string fullname)
        {
            int i = fullname.IndexOf('.');
            if (i > 0)
            {
                return fullname.Replace(".", "_");
            }
            return fullname;
        }
    }
}
