using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.IDAL
{
    public interface IModel
    {
        int Add<T>(T t) where T : class,IBaseEntity;
        int Update<T>(T t) where T : class,IBaseEntity;
        int Delete<T>(T t) where T : class,IBaseEntity;
        IQueryable<T> List<T>() where T : class,IBaseEntity;
    }
}
