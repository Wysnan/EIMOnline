using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AopAlliance.Intercept;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.Injection.Logs
{
    public class OperateLogInterceptor : IMethodInterceptor
    {
       // private IOperateLog OperateLog { get; set; }
        public object Invoke(IMethodInvocation invocation)
        {
            //var model = BusinessModel
            //var attributes = invocation.Method.GetCustomAttributes(typeof(OperateLogAttribute), false).OfType<OperateLogAttribute>();
            ////var attributes1 = invocation.Method.Name;
            ////var attr = invocation.Method.DeclaringType.Name;
            //if (attributes.Count() == 0)
            //{
            //    try
            //    {
            //        var result = invocation.Proceed();
            //        return result;
            //    }
            //    catch
            //    {
            //        throw;
            //    }
            //}

            //if (attributes.Count() > 1)
            //{
            //    throw new InvalidOperationException(
            //        string.Format("GlobalEntity.Instance.Message[\"4\"]: {0}", invocation.Method.Name));
            //}

            //try
            //{                
            //    //OperateLog op = new OperateLog();
            //    //OperateLog.Add(op);
            //    return null;
            //}
            //catch
            //{
            //    throw;
            //}
            return null;
        }
    }
}
