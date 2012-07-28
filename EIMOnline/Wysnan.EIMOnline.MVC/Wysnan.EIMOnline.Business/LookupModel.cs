using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Enum;

namespace Wysnan.EIMOnline.Business
{
    public class LookupModel : GenericBusinessModel<Lookup>, ILookupModel
    {
        public LookupModel() { }

        public IQueryable<Lookup> Get(LookupCodeEnum lookupCode)
        {
            return null;
        }
    }
}
