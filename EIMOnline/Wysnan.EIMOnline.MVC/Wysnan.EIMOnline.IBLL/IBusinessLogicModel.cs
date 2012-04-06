using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.IBLL
{
    public interface IBusinessLogicModel<T> where T:IBaseEntity
    {
        int Add(T t);
        int Update(T t);
        int Delete(T t);
        IQueryable<T> List();
    }
}
