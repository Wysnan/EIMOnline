using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Tool.ToolMethod
{
    public sealed class ScriptResourceHelp
    {
        private ScriptResourceHelp() { }

        public static string Load_JqGrid()
        {
            StringBuilder script = new StringBuilder();
            script.Append(ScriptResource.ui_jqgrid_css);
            script.Append(ScriptResource.grid_locale_cn_js);
            script.Append(ScriptResource.jquery_jqGrid_src_js);
            script.Append(ScriptResource.jqGridExtensions);
            return script.ToString();
        }
    }
    public class ScriptResource
    {
        #region JqGrid

        public const string ui_jqgrid_css = "<link href=\"/Content/JqGrid/ui.jqgrid.css\" rel=\"stylesheet\" type=\"text/css\" />";
        public const string grid_locale_cn_js = "<script src=\"/Scripts/JqGrid/i18n/grid.locale-cn.js\" type=\"text/javascript\"></script>";
        public const string jquery_jqGrid_src_js = "<script src=\"/Scripts/JqGrid/jquery.jqGrid.src.js\" type=\"text/javascript\"></script>";
        public const string jqGridExtensions = "<script src=\"/Scripts/JqGrid/jqGridExtensions.js\" type=\"text/javascript\"></script>";

        #endregion
    }
}
