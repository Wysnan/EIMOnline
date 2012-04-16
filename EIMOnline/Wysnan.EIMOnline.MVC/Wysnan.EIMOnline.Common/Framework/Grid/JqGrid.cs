using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Wysnan.EIMOnline.Common.Framework.Grid.Poco;

namespace Wysnan.EIMOnline.Common.Framework.Grid
{
    /// <summary>
    /// JqGrid配置类
    /// </summary>
    [Serializable]
    public class JqGrid
    {
        public JqGrid()
        {
            this._Url = "";
            this._DataType = GridColumnDateType.json;
            this._Mtype = "GET";
            this._ColNames = null;
            this._ColModel = new List<ColModel>();
            this._Pager = "#page";
            this._Sortable = true;
            this.RowNum = 20;
            this._MultiSelect = true;
            this._PrmNames = "none";
            this._JsonReader_Root = "";
            this._JsonReader_Repeatitems = false;
            this._RowList = new int[] { 10, 20, 50 };
            this.SortName = "ID";
            this.SortOrder = "desc";
            this._ViewRecords = true;
            this._Caption = "";
        }

        /// <summary>
        /// 请求数据的url地址
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string _Url { get; set; }

        /// <summary>
        /// 定义表格希望获得的数据的类型
        /// </summary>
        public GridColumnDateType _DataType { get; set; }

        /// <summary>
        /// 定义提交类型POST或GET
        /// </summary>
        public string _Mtype { get; set; }

        /// <summary>
        /// 列名称数组。该名称将在Header中显示。名称以逗号分隔，数量应与colModel 数组数量相等
        /// </summary>
        public string[] _ColNames { get; set; }

        /// <summary>
        /// 描述列参数数组
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<ColModel> _ColModel { get; set; }

        /// <summary>
        /// 定义分页浏览导航条。必须是一个HTML元素，如<div id="page"></div>
        /// </summary>
        public string _Pager { get; set; }

        /// <summary>
        /// 启用此项，允许使用鼠标重新排序列。
        /// </summary>
        public bool _Sortable { get; set; }

        /// <summary>
        /// 表格中可见的记录数
        /// </summary>
        public int RowNum { get; set; }

        /// <summary>
        /// 此属性设为true时启用多行选择，出现复选框
        /// </summary>
        public bool _MultiSelect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string _PrmNames { get; set; }

        public string _JsonReader_Root { get; set; }

        public bool _JsonReader_Repeatitems { get; set; }

        /// <summary>
        /// 用于改变显示行数的下拉列表框的元素数组。
        /// </summary>
        public int[] _RowList { get; set; }

        /// <summary>
        /// 从服务器读取XML或JSON数据时初始的排序名，此名被加到URL中。
        /// </summary>
        public string SortName { get; set; }

        /// <summary>
        /// asc或desc
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// 是否显示记录总数
        /// </summary>
        public bool _ViewRecords { get; set; }

        /// <summary>
        /// 表格的标题。显示在Header上。若为空时将不会显示。
        /// </summary>
        public string _Caption { get; set; }

        #region 内部类

        public class ColModel
        {
            public ColModel()
            {
                this.Align = GridColumnAlign.left;
                this.Classes = "empty";
                this.Detefmt = "Y-m-d";
                this.Defval = "empty";
                this.Editable = false;
                this.EditOptions = null;//"empty";
                this.Editrules = null;//"empty";
                this.Edittype = GridColumnEdittype.text;
                this.Fixed = true;
                this.Formoptions = null;//"empty";
                this.Hidedlg = false;
                this.Hidden = false;
                this.Index = "empty";
                this.Key = false;
                this.Label = "none";
                this.Name = "name";
                this.Resizable = true;
                this.Sortable = true;
                this.Sorttype = GridColumnSorttype._text;
                this.Title = true;
                this.Width = "150";
                this.Formatter = string.Empty;
                this.Type = typeof(String).Name.ToLower();
            }

            /// <summary>
            /// 对齐方式
            /// </summary>
            public GridColumnAlign Align { get; set; }

            /// <summary>
            /// 列的类名
            /// </summary>
            public string Classes { get; set; }

            /// <summary>
            /// 日期格式
            /// </summary>
            public string Detefmt { get; set; }

            /// <summary>
            /// 搜索字段的缺省值，此参数只用于自定义搜索是的初始值。
            /// </summary>
            public string Defval { get; set; }

            /// <summary>
            /// 定义字段是否可编辑，用于单元格编辑、行编辑和表单模式
            /// </summary>
            public bool Editable { get; set; }

            /// <summary>
            /// 根据edittype 参数定义可用的值数组
            /// </summary>
            public string[] EditOptions { get; set; }

            /// <summary>
            /// 设置可编辑字段的补充规则
            /// </summary>
            public string[] Editrules { get; set; }

            /// <summary>
            /// 定义行编辑和表单模式的编辑类型
            /// </summary>
            public GridColumnEdittype Edittype { get; set; }

            /// <summary>
            /// 若设为true，即使shrinkToFit设置为true，列宽也不允许重新计算。GridWidth方法改变表格宽度时，列宽也不会改变。
            /// </summary>
            public bool Fixed { get; set; }

            /// <summary>
            /// 定义表单编辑的各种选项
            /// </summary>
            public string[] Formoptions { get; set; }

            /// <summary>
            /// 若设置为true，该列将不出现在模式对话框中，用户可以此控制列的显示或隐藏
            /// </summary>
            public bool Hidedlg { get; set; }

            /// <summary>
            /// 定义初始化时，列是否隐藏。
            /// </summary>
            public bool Hidden { get; set; }

            /// <summary>
            /// 设置排序时的索引名。
            /// </summary>
            public string Index { get; set; }

            /// <summary>
            /// 在未从服务器获得ID的情况下，该列可设置为行ID。只有一列可设置该属性，若出现多列，表格只采用将第一个设置了该属性的列，其他列忽略。
            /// </summary>
            public bool Key { get; set; }

            /// <summary>
            /// 当colNames数组为空时，定义此列的标题。若colNames数组和此属性都为空，标题为该列的name属性值。
            /// </summary>
            public string Label { get; set; }

            /// <summary>
            /// 设置列在表格中的唯一名称，此属性是必须的。
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 定义是否可变列宽
            /// </summary>
            public bool Resizable { get; set; }

            /// <summary>
            /// 定义是否可以排序
            /// </summary>
            public bool Sortable { get; set; }

            /// <summary>
            /// 当datatype为local时，用于定义排序列类型。
            /// </summary>
            public GridColumnSorttype Sorttype { get; set; }

            /// <summary>
            /// 当设置为false时，鼠标滑向单元格时不显示title属性
            /// </summary>
            public bool Title { get; set; }

            /// <summary>
            /// 设置列的初始宽度，可用pixels和百分比
            /// </summary>
            public string Width { get; set; }

            private string type = string.Empty;

            public string Type
            {
                get { return type; }
                set
                {
                    type = value;
                    if (value == "datetime")
                    {
                        this.Formatter = string.Format(",formatter:'date',formatoptions:{{srcformat: 'Y-m-d H:i:s', newformat: 'Y-m-d H:i:s'}}");
                        //this.Formatter = string.Format(",formatter:'date',formatoptions:{{srcformat: '{0}', newformat: '{0}'}}", Detefmt);
                    }
                }
            }

            public string Formatter { get; set; }

            public SearchOptions SearchOptions { get; set; }
        }

        #endregion
    }
}
