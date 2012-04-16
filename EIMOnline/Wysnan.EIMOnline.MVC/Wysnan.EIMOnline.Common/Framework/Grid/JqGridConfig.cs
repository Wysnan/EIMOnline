using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using Wysnan.EIMOnline.Common.Framework.Grid.Enum;
using Wysnan.EIMOnline.Common.Framework.Grid.Poco;

namespace Wysnan.EIMOnline.Common.Framework.Grid
{
    public class JqGridConfig<TEntity, TData> : JqGrid
    {
        public JqGridConfig()
        {
            // base.ColeModel
        }

        public GridColumnCollection GridColumnCollection { get; set; }


        public string Path<U>(Expression<Func<TData, U>> expression)
        {
            var propertyExpression = expression.Body;
            MemberExpression memberExpression;
            var builder = new StringBuilder();
            do
            {
                memberExpression = propertyExpression as MemberExpression;

                if (memberExpression == null) { break; }

                if (!(memberExpression.Member is PropertyInfo || memberExpression.Member is FieldInfo))
                {
                    throw new InvalidOperationException("ExpressionHelper:Property/field access expected");
                }
                if (builder.Length > 0)
                {
                    builder.Insert(0, ".");
                }
                builder.Insert(0, memberExpression.Member.Name);

                propertyExpression = memberExpression.Expression;

            } while (memberExpression != null);
            string lamda = builder.ToString();
            string value = string.Format("[Name:{0}][Type:{1}]", lamda, typeof(U).Name.ToLower());
            return value;
        }

        public void DataBind()
        {
            base._ColModel = ConvertToColModel(this.GridColumnCollection);
        }

        #region 属性
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _Url { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new GridColumnDateType _DataType { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _Mtype { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string[] _ColNames { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new List<ColModel> _ColModel { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _Pager { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new bool _Sortable { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new bool _MultiSelect { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _PrmNames { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _JsonReader_Root { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new bool _JsonReader_Repeatitems { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new int[] _RowList { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new bool _ViewRecords { get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _Caption { get; private set; }
        #endregion

        #region 私有方法

        private List<ColModel> ConvertToColModel(GridColumnCollection gridColumnCollection)
        {
            if (gridColumnCollection == null)
            {
                return null;
            }
            List<ColModel> models = new List<ColModel>();
            foreach (var item in gridColumnCollection)
            {
                ColModel colModel = new ColModel();
                colModel.Align = item.Align;
                colModel.Label = item.Label;
                colModel.Name = item.Name;
                colModel.Type = item.Type;
                SearchOptions searchOptions = new SearchOptions();
                ConvertToColModel_Sopt(item.Type, searchOptions);
                colModel.SearchOptions = searchOptions;
                models.Add(colModel);
            }
            return models;
        }

        private void ConvertToColModel_Sopt(string type, SearchOptions searchOptions)
        {
            string sopt = string.Empty;
            switch (type)
            {
                case "string":
                    sopt = "'eq','ne','bw','bn','ew','en','cn','nc','nu','nn'";
                    searchOptions.Sopt = sopt;
                    break;
                case "datetime":
                    sopt = "'eq','ne','gt','ge','le','lt'";
                    searchOptions.DataInit = "datePick";
                    searchOptions.Sopt = sopt;
                    break;
                case "int32":
                case "int64":
                case "int16":
                    sopt = "'eq','ne','lt','le','gt','ge','in','ni'";
                    searchOptions.Sopt = sopt;
                    break;
                default:
                    throw new ApplicationException(string.Format("系统未对该类型[{0}]做配置。请联系武双琦。", type));
            }
        }

        #endregion
    }
}






