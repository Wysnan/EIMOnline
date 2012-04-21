using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using System.Linq;
using Wysnan.EIMOnline.Common.ViewModel;
using System;

namespace Wysnan.EIMOnline.Business
{
    public class SystemModuleTypeModel : GenericBusinessModel<SystemModuleType>, ISystemModuleType
    {
        public SystemModuleTypeModel()
        {
            var tt = Model.List<SystemModuleType>();

        }

        public IQueryable<CombinedSystemModuleType> ListCombined()
        {
            throw new NotImplementedException();
        }
    }
}
