using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Common.Framework.Enum;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Business.Framework;
using Wysnan.EIMOnline.Tool.Extensions;
using Wysnan.EIMOnline.Tool.ToolMethod;

namespace Wysnan.EIMOnline.MVC.Framework.Extensions
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString Grid(this HtmlHelper helper, GridEnum gridEnum)
        {
            JqGrid jqGrid = GlobalEntity.Instance.Cache_JqGrid.JqGrids[gridEnum];
            if (jqGrid == null)
            {
                return MvcHtmlString.Empty;
            }
            var colModel = jqGrid._ColModel;
            if (colModel == null || colModel.Count == 0)
            {
                return MvcHtmlString.Empty;
            }

            string url = HttpContext.Current.Request.Url.AbsolutePath + "/List";
            StringBuilder grid = new StringBuilder();
            StringBuilder StrColNames = new StringBuilder();
            StringBuilder StrColModel = new StringBuilder();
            foreach (var item in colModel)
            {
                StrColNames.AppendFormat("'{0}',", item.Label);
                StrColModel.AppendFormat("{0} name: '{1}', index: '{2}', width: {3}, editable: {4},align: '{5}',datefmt:'{6}'{7},searchoptions:{8}{9},",
                    "{", item.Name, item.Name, item.Width, item.Editable.ConvertToString(true), item.Align, item.Detefmt, item.Formatter,
                    item.SearchOptions.ToString(), "}");
            }
            StrColNames.Remove(StrColNames.Length - 1, 1);
            StrColModel.Remove(StrColModel.Length - 1, 1);
            grid.Append("<table id=\"list\" style=\"width:100%;\" ");
            grid.Append("</table>");
            grid.Append("<div id=\"pager\"");
            grid.Append("</div>");
            grid.Append("<script type=\"text/javascript\">");
            grid.Append("$(document).ready(function () {");
            grid.Append("$(\"#list\").jqGrid({");
            grid.AppendFormat("url: '{0}',", url);// jqGrid._Url);
            grid.Append("autowidth:true,");
            grid.AppendFormat("datatype: '{0}',", jqGrid._DataType);
            grid.AppendFormat("mtype: '{0}',", jqGrid._Mtype);
            grid.AppendFormat("colNames: [{0}],", StrColNames.ToString());
            grid.Append("colModel: [");
            grid.Append(StrColModel.ToString());
            grid.Append("],");
            grid.Append("pager: '#pager',");
            grid.AppendFormat("sortable: {0},", jqGrid._Sortable.ConvertToString(true));
            grid.AppendFormat("rowNum: {0},", jqGrid.RowNum);
            grid.Append("multiselect: true,");
            grid.Append("prmNames: { page:\"page\",rows:\"rows\", sort: \"sidx\",order:\"sord\", search:\"search\", nd:\"nd\", npage:\"npage\" },");
            grid.Append("jsonReader: {");
            grid.AppendFormat("root: \"{0}\",", "rows");// jqGrid._JsonReader_Root);
            grid.AppendFormat("repeatitems: {0}", jqGrid._JsonReader_Repeatitems.ConvertToString(true));
            grid.Append("},");
            grid.AppendFormat("rowList: [{0}],", jqGrid._RowList.ConvertToString(","));
            grid.AppendFormat("sortname: '{0}',", jqGrid.SortName);
            grid.AppendFormat("sortorder: '{0}',", jqGrid.SortOrder);
            grid.AppendFormat("height:{0},", 250);
            grid.AppendFormat("viewrecords: {0},", jqGrid._ViewRecords.ConvertToString(true));
            grid.AppendFormat("caption: '&nbsp;{0}'", jqGrid._Caption);
            grid.Append("});");
            grid.Append("var grid=$(\"#list\");");
            grid.Append("grid.jqGrid('navGrid', '#pager', { edit: false, add: true, del: true,view:false },{},{},{},{multipleSearch:true,overlay:false});");
            grid.Append("grid.jqGrid('filterToolbar',{stringResult: true,searchOnEnter : true});");
            grid.Append("grid.jqGrid('navButtonAdd','#pager',{caption: \"\",buttonicon: \"ui-icon-calculator\", title:\"Reorder Columns\",onClickButton:function(){grid.jqGrid('columnChooser');}});");
            grid.Append("});");
            grid.Append("</script>");

            string gridHtml = grid.ToString();
            //CookieHelp.WriteCookie("")
            return MvcHtmlString.Create(gridHtml);
        }
    }
}