using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.Business
{
    public class GenericBusinessModel<T> : BusinessModel, IBusinessLogicModel<T> where T : class,IBaseEntity
    {
        public GenericBusinessModel()
            : base()
        {

        }

        public int Add(T t) 
        {
            return Model.Add<T>(t);
        }

        public int Update(T t)
        {
            return Model.Update(t);
        }

        public int Delete(T t)
        {
            return Model.Delete(t);
        }

        public IQueryable<T> List() 
        {
            return Model.List<T>();
        }
    }
}
