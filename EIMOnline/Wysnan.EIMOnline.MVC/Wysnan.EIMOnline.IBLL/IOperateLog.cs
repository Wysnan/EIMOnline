﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.IBLL
{
    public interface IOperateLog : IBusinessLogicModel<OperateLog>
    {
        Result test();
       // Result Add(OperateLog t);
    }
}
