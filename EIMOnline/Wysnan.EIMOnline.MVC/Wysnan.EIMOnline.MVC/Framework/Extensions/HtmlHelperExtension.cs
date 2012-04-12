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

namespace Wysnan.EIMOnline.MVC.Framework.Extensions
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString Grid(this HtmlHelper helper, GridEnum gridEnum)
        {
            StringBuilder grid = new StringBuilder();
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

            StringBuilder StrColNames = new StringBuilder();
            StringBuilder StrColModel = new StringBuilder();
            foreach (var item in colModel)
            {
                StrColNames.AppendFormat("'{0}',", item.Label);
                StrColModel.AppendFormat("{5} name: '{0}', index: '{1}', width: {2}, editable: {3},align: '{4}'{6},",
                    item.Name, item.Name, item.Width, item.Editable, item.Align, "{", "}");
            }
            StrColNames.Remove(StrColNames.Length - 1, 1);
            StrColModel.Remove(StrColModel.Length - 1, 1);
            grid.Append("<table id=\"list\">");
            grid.Append("</table>");
            grid.Append("<div id=\"pager\">");
            grid.Append("</div>");
            grid.Append("<script type=\"text/javascript\">");
            grid.Append("$(document).ready(function () {");
            grid.Append("$(\"#list\").jqGrid({");
            grid.AppendFormat("url: '{0}',", jqGrid._Url);
            grid.AppendFormat("datatype: '{0}',", jqGrid._DataType);
            grid.AppendFormat("mtype: '{0}',", jqGrid._Mtype);
            grid.AppendFormat("colNames: [{0}],", StrColNames.ToString());
            grid.Append("colModel: [");
            grid.Append(StrColModel.ToString());
            //grid.Append("{ name: 'Id', index: 'Id', width: 180, editable: false },");
            //grid.Append("{ name: 'Name', index: 'Name', width: 120, editable: true },");
            //grid.Append("{ name: 'Age', index: 'Age', width: 90, editable: true },");
            //grid.Append("{ name: 'Birthday', index: 'Birthday', align: 'center', width: 60, editable: true },");
            //grid.Append("{ name: 'ClassId', index: 'ClassId', width: 200, sorttype: \"ClassId\", sortable: false }");
            grid.Append("],");
            grid.Append("pager: '#pager',");
            grid.AppendFormat("sortable: {0},", jqGrid._Sortable);
            grid.AppendFormat("rowNum: {0},", jqGrid.RowNum);
            grid.Append("multiselect: true,");
            grid.Append("prmNames: { rows: \"pageSize\", page: \"page\" },");
            grid.Append("jsonReader: {");
            grid.AppendFormat("root: \"{0}\",", jqGrid._JsonReader_Root);
            grid.AppendFormat("repeatitems: {0}", jqGrid._JsonReader_Repeatitems);
            grid.Append("},");
            grid.AppendFormat("rowList: [{0}],", jqGrid._RowList.ConvertToString(","));
            grid.AppendFormat("sortname: '{0}',", jqGrid.SortName);
            grid.AppendFormat("sortorder: '{0}',", jqGrid.SortOrder);
            grid.AppendFormat("viewrecords: {0},", jqGrid._ViewRecords);
            grid.AppendFormat("caption: '{0}'", jqGrid._Caption);
            grid.Append("});");
            grid.Append("$(\"#list\").jqGrid('navGrid', '#pager', { edit: true, add: false, del: false });");
            grid.Append("alert(\"123\")});");
            grid.Append("</script>");
            return MvcHtmlString.Create(grid.ToString());
        }
    }
}