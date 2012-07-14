using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq.Expressions;

namespace Wysnan.EIMOnline.IBLL
{
    public interface IBusinessLogicModel<T> where T : ISystemBaseEntity
    {
        Result Add(T t);

        Result Update(T t);

        Result Delete(T t);
        Result Delete(int id);
        
        Result LogicDelete(T t);
        Result LogicDelete(int id);
        Result LogicDelete(IEnumerable<int> ids);
        Result Undelete(int id);

        IQueryable<T> List();

        IQueryable<T> List(PageInfo page);

        List<T> All();

        T Get(int id);

        T Get(string key, string value);
    }
}
