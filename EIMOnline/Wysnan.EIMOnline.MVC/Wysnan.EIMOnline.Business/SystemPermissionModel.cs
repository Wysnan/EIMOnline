using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using System.Linq;
using Wysnan.EIMOnline.Common.ViewModel;
using System;
using Wysnan.EIMOnline.Injection.Transaction;

namespace Wysnan.EIMOnline.Business
{
    public class SystemPermissionModel : GenericBusinessModel<SystemPermission>, ISystemPermission
    {
        public SystemPermissionModel()
        {
            // var tt = Model.List<SystemPermission>();

        }

        [TransactionAttribute]
        public override IQueryable<SystemPermission> List()
        {
            return base.List();
        }
    }
}
