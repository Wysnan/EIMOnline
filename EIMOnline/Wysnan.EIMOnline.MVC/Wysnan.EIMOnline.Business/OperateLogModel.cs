using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Injection.Logs;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Injection.Transaction;

namespace Wysnan.EIMOnline.Business
{
    public class OperateLogModel : GenericBusinessModel<OperateLog>, IOperateLog
    {
        public OperateLogModel()
        {
        }

        public override Result Add(OperateLog t)
        {
            var oplog = Model.Add<OperateLog>(t);

            return oplog;
        }

        [OperateLogAttribute]
        public Result test()
        {
            OperateLog op = new OperateLog();
            op.OperateDate = DateTime.Now;
            op.OperateLogInfo = "ss";

            return null;
        }
    }
}
