using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.Business
{
    public class SecurityUserModel : GenericBusinessModel<SecurityUser>, ISecurityUser
    {
        public SecurityUserModel()
        {

        }

        //public int Add(Common.Poco.SecurityUser t)
        //{
        //    return Model.Add(t);
        //}

        //public int Update(Common.Poco.SecurityUser t)
        //{
        //    return Model.Update(t);
        //}

        //public int Delete(Common.Poco.SecurityUser t)
        //{
        //    return Model.Delete(t);
        //}

        //public IQueryable<Common.Poco.SecurityUser> List()
        //{
        //    return Model.List();
        //}
    }
}
