using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.ViewModel;

namespace Wysnan.EIMOnline.Business
{
    public class SecurityRoleModel : GenericBusinessModel<SecurityRole>, ISecurityRole
    {
        public SecurityRoleModel()
        {
        }
        public IQueryable<CombinedSecurityRole> ListCombined()
        {
            throw new NotImplementedException();
        }
    }
}
