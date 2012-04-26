using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq;
using System;
using Wysnan.EIMOnline.Injection.Transaction;

namespace Wysnan.EIMOnline.Business
{
    public class SystemModuleModel : GenericBusinessModel<SystemModule>, ISystemModule
    {
        public SystemModuleModel()
        {
            // var tt = Model.List<SystemPermission>();

        }

        public IQueryable<CombinedSystemModule> ListCombined()
        {
            throw new NotImplementedException();
        }

        [TransactionAttribute]
        public override IQueryable<SystemModule> List()
        {
            return base.List();
        }

        public IQueryable<SystemModule> GetSecuritySystemModule()
        {
            return base.List();
        }
    }
}
