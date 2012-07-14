using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq;
using System;

namespace Wysnan.EIMOnline.Business
{
    public class SecurityUserRoleModel : GenericBusinessModel<SecurityUserRole>, ISecurityUserRole
    {

        public SecurityUserRoleModel()
        {
            var tt = Model.List<SecurityRole>();
            
        }
    }
}
