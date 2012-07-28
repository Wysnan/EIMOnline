using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Enum;

namespace Wysnan.EIMOnline.IBLL
{
    public interface ILookupModel : IBusinessLogicModel<Lookup>
    {
        IQueryable<Lookup> Get(LookupCodeEnum lookupCode);
    }
}
