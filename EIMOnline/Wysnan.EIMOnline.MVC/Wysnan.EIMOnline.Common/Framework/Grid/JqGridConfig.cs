using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid.POCO;
using System.Linq.Expressions;
using System.Reflection;
using Wysnan.EIMOnline.Common.Framework.Grid.Enum;

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
                //if (includeType)
                //{
                //    builder.Insert(0, ".");

                //    var declaringType = memberExpression.Member.DeclaringType;
                //    string name;

                //    if (declaringType.IsInterface || declaringType.IsAbstract)
                //        name = typeof(T).Name;
                //    else
                //        name = declaringType.Name;

                //    builder.Insert(0, name);
                //}
                propertyExpression = memberExpression.Expression;

            } while (memberExpression != null);

            return builder.ToString();
        }

        public void DataBind()
        {
            base._ColModel = ConvertToColeModel(this.GridColumnCollection);
        }

        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _Url {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new GridColumnDateType _DataType {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _Mtype {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string[] _ColNames {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new List<ColModel> _ColModel {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _Pager {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new bool _Sortable {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new bool _MultiSelect {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _PrmNames {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _JsonReader_Root {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new bool _JsonReader_Repeatitems {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new int[] _RowList {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new bool _ViewRecords {  get; private set; }
        /// <summary>
        /// 不能使用该属性。框架内部调用。
        /// </summary>
        [Obsolete("不能使用该属性", true)]
        public new string _Caption {  get; private set; }


        #region 私有方法

        private List<ColModel> ConvertToColeModel(GridColumnCollection gridColumnCollection)
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
                models.Add(colModel);
            }
            return models;
        }

        #endregion
    }
}
