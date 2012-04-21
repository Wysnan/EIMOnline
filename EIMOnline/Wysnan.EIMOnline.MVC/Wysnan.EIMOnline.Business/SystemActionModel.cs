using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq;
using System;

namespace Wysnan.EIMOnline.Business
{
    public class SystemActionModel : GenericBusinessModel<SystemAction>, ISystemAction
    {
        public SystemActionModel()
        {
            var tt = Model.List<SystemAction>();

        }

        public IQueryable<CombinedSystemAction> ListCombined()
        {
            throw new NotImplementedException();
        }
    }
}
