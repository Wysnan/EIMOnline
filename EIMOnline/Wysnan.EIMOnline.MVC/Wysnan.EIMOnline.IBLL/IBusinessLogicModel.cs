using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.IBLL
{
    public interface IBusinessLogicModel<T> where T : IBaseEntity
    {

        Result Add(T t);

        Result Update(T t);

        Result Delete(T t);
        Result Delete(int id);
        Result LogicDelete(T t);
        Result LogicDelete(int id);
        Result Undelete(int id);

        IQueryable<T> List();

        IQueryable<T> List(PageInfo page);

        List<T> All();

        T Get(int id);

        T Get(string key, string value);
    }
}
