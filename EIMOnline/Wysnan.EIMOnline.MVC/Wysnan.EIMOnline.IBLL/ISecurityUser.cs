﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.ViewModel;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.IBLL
{
    public interface ISecurityUser : IBusinessLogicModel<SecurityUser>
    {
        Result Login(SecurityUser user);
    }
}
