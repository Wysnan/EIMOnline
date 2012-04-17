using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Injection.Transaction;
using Wysnan.EIMOnline.Common.Framework.Grid.POCO;
using Wysnan.EIMOnline.Common.Framework.Grid;
<<<<<<< HEAD
using Wysnan.EIMOnline.Injection.Logs;
=======
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq.Expressions;
using Wysnan.EIMOnline.Tool.Extensions;
>>>>>>> origin/Task_Wushuangqi_BuildFramework

namespace Wysnan.EIMOnline.Business
{
    public class SecurityUserModel : GenericBusinessModel<SecurityUser>, ISecurityUser
    {
        public SecurityUserModel()
        {
        }

        public override IQueryable<SecurityUser> List()
        {
<<<<<<< HEAD
            return null;
        }

        [LogList]
        public new Result Add2()
        {
            return null;
        }
        //public int Add(Common.Poco.SecurityUser t)
        //{
        //    return Model.Add(t);
        //}

        //public int Update(Common.Poco.SecurityUser t)
        //{
        //    return Model.Update(t);
        //}
=======
            var query = base.List();
            //string str = query.Select(a => a.UserName).FirstOrDefault();
>>>>>>> origin/Task_Wushuangqi_BuildFramework

            Expression<Func<SecurityUser, SecurityUser>> selector = null;
            query.Select("id", "");

            var temp = query.Select(selector);
            return base.List();
        }

        public IQueryable<CombinedSecurityUser> ListCombined()
        {
            throw new NotImplementedException();
        }
    }
}
