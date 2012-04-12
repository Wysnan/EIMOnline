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
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq.Expressions;
using Wysnan.EIMOnline.Tool.Extensions;

namespace Wysnan.EIMOnline.Business
{
    public class SecurityUserModel : GenericBusinessModel<SecurityUser>, ISecurityUser
    {
        public SecurityUserModel()
        {
        }

        public override IQueryable<SecurityUser> List()
        {
            var query = base.List();
            //string str = query.Select(a => a.UserName).FirstOrDefault();

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
