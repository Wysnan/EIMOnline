using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;
using System.Linq.Expressions;

namespace Wysnan.EIMOnline.IDAL
{
    public interface IModel
    {
        #region Add

        Result Add<T>(T t) where T : class,IBaseEntity;

        #endregion

        #region Update

        Result Update<T>(T t) where T : class,IBaseEntity;

        #endregion

        #region Delete

        Result Delete<T>(T t) where T : class,IBaseEntity;

        Result Delete<T>(int id) where T : class,IBaseEntity;

        Result LogicDelete<T>(T t) where T : class,IBaseEntity;

        Result LogicDelete<T>(int id) where T : class,IBaseEntity;

        Result LogicDelete<T>(IEnumerable<int> ids) where T : class,IBaseEntity;

        Result Undelete<T>(int id) where T : class,IBaseEntity;
        #endregion

        #region Get

        IQueryable<T> List<T>() where T : class,IBaseEntity;

        IQueryable<T> List<T, U>(Expression<Func<T, U>> expression) where T : class,IBaseEntity;

        T Get<T>(int id) where T : class,IBaseEntity;

        #endregion
    }    
}
