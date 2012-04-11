using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Common.Framework.Grid;

namespace Wysnan.EIMOnline.Business
{
    public class GenericBusinessModel<T> : BusinessModel, IBusinessLogicModel<T> where T : class,IBaseEntity
    {
        #region 属性
        
        #endregion

        public GenericBusinessModel()
            : base()
        {

        }

        #region 业务方法

        public Result Add(T t)
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

        public IQueryable<T> List()
        {
            return Model.List<T>();
        }

        public IQueryable<T> List(PageInfo page)
        {
            throw new NotImplementedException();
        }

        public List<T> All()
        {
            return Model.List<T>().ToList();
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
