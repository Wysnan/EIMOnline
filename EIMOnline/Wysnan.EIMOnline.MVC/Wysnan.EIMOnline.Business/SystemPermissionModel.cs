using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using System.Linq;
using Wysnan.EIMOnline.Common.ViewModel;
using System;

namespace Wysnan.EIMOnline.Business
{
    public class SystemPermissionModel : GenericBusinessModel<SystemPermission>, ISystemPermission
    {
        public SystemPermissionModel()
        {
            var tt = Model.List<SystemPermission>();

        }

        public IQueryable<CombinedSystemPermission> ListCombined()
        {
            throw new NotImplementedException();
        }
    }
}
