using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq;
using System;

namespace Wysnan.EIMOnline.Business
{
    public class SystemModuleModel : GenericBusinessModel<SystemModule>, ISystemModule
    {
        public SystemModuleModel()
        {
            var tt = Model.List<SystemModuleDetailPage>();

        }

        public IQueryable<CombinedSystemModule> ListCombined()
        {
            throw new NotImplementedException();
        }
    }
}
