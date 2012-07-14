using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Common.Framework.Enum;
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq.Expressions;
using Wysnan.EIMOnline.Common.Framework.Attributes;
using System.Reflection;
using Wysnan.EIMOnline.Tool.Extensions;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace Wysnan.EIMOnline.Business
{
    /// <summary>
    /// 业务基类
    /// 方法的定义（名称，参数，返回值）都是预先定义的。最终，框架会根据这些预定义内容调用方法。
    /// 注意以下问题：
    ///     1.对于复杂业务的调用，一定要重写（override）基类方法并做业务扩展。
    ///     2.如果1不能满足业务需求（参数或返回值），才可以定义自己的方法。
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class GenericBusinessModel<T> : BusinessModel, IBusinessLogicModel<T> where T : class,IBaseEntity
    {
        #region 属性

        #endregion

        public GenericBusinessModel()
            : base()
        {

        }

        #region 业务方法

        public virtual Result Add(T t)
        {
            var type = typeof(T);
            var customAttribute = Attribute.GetCustomAttribute(type, typeof(CodeAttribute)) as CodeAttribute;
            if (customAttribute != null)
            {
                var fields = customAttribute.Fields;
                foreach (var item in fields)
                {
                    var oldValue = List().OrderByDescending(a => a.ID).Select("new(" + item.Key + ")").Take(1);
                    string value = null;
                    var p = type.GetProperty(item.Key);
                    int length = 0;
                    //得到属性
                    if (p != null)
                    {
                        var stringLength = p.GetCustomAttributes(typeof(StringLengthAttribute), false);
                        if (stringLength != null)
                        {
                            length = (stringLength.FirstOrDefault() as StringLengthAttribute).MaximumLength;
                        }
                    }
                    if (oldValue == null)
                    {
                        if (item.Value.Length >= length)
                        {
                            throw new ApplicationException("CodeAttribute中前缀字符串超过字段定义长度。");
                        }
                        value = item.Value.PadRight(length - item.Value.Length, '0') + 1;
                        value = value.Substring(1);
                    }
                    foreach (dynamic v in oldValue)
                    {
                        value = v.Code;
                        var newCode = Convert.ToInt32(value.Substring(item.Value.Length + 1)) + 1;
                        value = item.Value + newCode.ToString().PadLeft(length - item.Value.Length, '0'); ;
                    }
                    if (p != null)
                    {
                        p.SetValue(t, value, null);
                    }
                }
            }
            return Model.Add<T>(t);
        }
        public virtual Result Update(T t)
        {
            return Model.Update(t);
        }

        #region Delete
        public virtual Result Delete(T t)
        {
            return Model.Delete(t);
        }

        public virtual Result Delete(int id)
        {
            return Model.Delete<T>(id);
        }

        public Result LogicDelete(IEnumerable<int> ids)
        {
            return Model.LogicDelete<T>(ids);
        }

        public virtual Result LogicDelete(T t)
        {
            return Model.LogicDelete(t);
        }

        public virtual Result LogicDelete(int id)
        {
            return Model.LogicDelete<T>(id);
        }

        public virtual Result Undelete(int id)
        {
            return Model.Undelete<T>(id);
        }

        #endregion

        #region Get

        public virtual IQueryable<T> List()
        {
            return Model.List<T>().Where(a => a.SystemStatus.HasValue && a.SystemStatus == (int)SystemStatus.Active);
        }
        public virtual IQueryable<T> List<U>(Expression<Func<T, U>> includeProperty)
        {
            IQueryable<T> query = null;
            query = Model.List<T, U>(includeProperty);
            return query;
        }

        public virtual IQueryable<T> List(PageInfo page)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> All()
        {
            return Model.List<T>().Where(a => a.SystemStatus.HasValue && a.SystemStatus == (int)SystemStatus.Active).ToList();
        }

        public virtual T Get(int id)
        {
            return Model.Get<T>(id);
        }

        public virtual T Get(string key, string value)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region 操作日志

        #endregion

        #region 错误日志

        #endregion

        #region 异常

        #endregion
    }
}
