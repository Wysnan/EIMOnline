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
            return Model.Add<T>(t);
        }
        public Result Update(T t)
        {
            return Model.Update(t);
        }

        #region Delete

        public Result Delete(T t)
        {
            return Model.Delete(t);
        }

        public Result Delete(int id)
        {
            return Model.Delete<T>(id);
        }

        public Result LogicDelete(T t)
        {
            return Model.LogicDelete(t);
        }

        public Result LogicDelete(int id)
        {
            return Model.LogicDelete<T>(id);
        }

        public Result Undelete(int id)
        {
            return Model.Undelete<T>(id);
        }

        #endregion

        #region Get

        public virtual IQueryable<T> List()
        {
            return Model.List<T>().Where(a => a.SystemStatus.HasValue && a.SystemStatus == (int)SystemStatus.Active);
        }
        public virtual IQueryable<T> List<U>(params Expression<Func<T, U>>[] includeProperty)
        {
            IQueryable<T> query = null;
            foreach (var item in includeProperty)
            {
                query = Model.List<T, U>(item);
            }
            return query;
        }

        public IQueryable<T> List(PageInfo page)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> All()
        {
            return Model.List<T>().Where(a => a.SystemStatus.HasValue && a.SystemStatus == (int)SystemStatus.Active).ToList();
        }

        public T Get(int id)
        {
            return Model.Get<T>(id);
        }

        public T Get(string key, string value)
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
