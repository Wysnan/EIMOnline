using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Injection.Logs;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.Business
{
    public class LogsModel : GenericBusinessModel<Logs>, ILogs
    {
        public LogsModel()
        {
        }

        [LogList]
        public  new Result Add()
        {
            return null;
        }
    }
}
