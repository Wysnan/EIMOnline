using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq;
using System;

namespace Wysnan.EIMOnline.Business
{
    public class SystemModuleDetailPageModel : GenericBusinessModel<SystemModuleDetailPage>, ISystemModuleDetailPage
    {
        public SystemModuleDetailPageModel()
        {
            var tt = Model.List<SystemModuleDetailPage>();

        }

        public IQueryable<CombinedSystemModuleDetailPage> ListCombined()
        {
            throw new NotImplementedException();
        }
    }
}
