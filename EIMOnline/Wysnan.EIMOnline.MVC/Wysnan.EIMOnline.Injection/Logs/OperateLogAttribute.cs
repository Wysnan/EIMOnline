using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Injection.Logs
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class OperateLogAttribute : Attribute
    {
        public OperateLogAttribute() { 
        }

    }
}
