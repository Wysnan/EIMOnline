using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysnan.EIMOnline.Common.Framework.Enum;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Business.Framework;

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
            string url = "";
            //jqGrid.
            // jqGrid.RowNum

            grid.Append("<table id=\"list\">");
            grid.Append("</table>");
            grid.Append("<div id=\"pager\">");
            grid.Append("</div>");
            grid.Append("$(document).ready(function () {");
            grid.Append("$(\"#list\").jqGrid({");
            grid.AppendFormat("url: '{0}',", url);
            grid.Append("datatype: 'json',");
            grid.Append("mtype: 'GET',");
            grid.Append("colNames: ['编号', '姓名', '年龄', '生日', '班级'],");
            grid.Append("colModel: [");
            grid.Append("{ name: 'Id', index: 'Id', width: 180, editable: false },");
            grid.Append("{ name: 'Name', index: 'Name', width: 120, editable: true },");
            grid.Append("{ name: 'Age', index: 'Age', width: 90, editable: true },");
            grid.Append("{ name: 'Birthday', index: 'Birthday', align: 'center', width: 60, editable: true },");
            grid.Append("{ name: 'ClassId', index: 'ClassId', width: 200, sorttype: \"ClassId\", sortable: false }");
            grid.Append("],");
            grid.Append("pager: '#pager',");
            grid.Append("sortable: true,");
            grid.Append("rowNum: 10,");
            grid.Append("multiselect: true,");
            grid.Append("prmNames: { rows: \"pageSize\", page: \"page\" },");
            grid.Append("jsonReader: {");
            grid.Append("root: \"stus\",");
            grid.Append("repeatitems: false");
            grid.Append("},");
            grid.Append("rowList: [10, 20, 30],");
            grid.Append("sortname: 'Id',");
            grid.Append("sortorder: 'desc',");
            grid.Append("viewrecords: true,");
            grid.Append("caption: 'My first grid'");
            grid.Append("});");
            grid.Append("$(\"#list\").jqGrid('navGrid', '#pager', { edit: true, add: false, del: false });");
            grid.Append("});");
            return MvcHtmlString.Create(grid.ToString());
        }
    }
}