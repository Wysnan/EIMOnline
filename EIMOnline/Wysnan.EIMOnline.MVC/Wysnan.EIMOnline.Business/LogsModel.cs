﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Injection.Logs;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.Business
{
    public class OperateLogModel : GenericBusinessModel<OperateLog>, IOperateLog
    {
        public OperateLogModel()
        {
        }       

        [OperateLog]
        public new Result Add()
        {
            OperateLog op=new OperateLog();
            Model.Add<OperateLog>(op);
            return null;
        }
    }
}
