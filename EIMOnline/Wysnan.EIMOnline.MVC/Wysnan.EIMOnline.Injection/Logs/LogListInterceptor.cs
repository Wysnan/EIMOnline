using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AopAlliance.Intercept;

namespace Wysnan.EIMOnline.Injection.Logs
{
    public class LogListInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            var attributes = invocation.Method.GetCustomAttributes(typeof(LogListAttribute), false).OfType<LogListAttribute>();
            //var attributes1 = invocation.Method.Name;
            //var attr = invocation.Method.DeclaringType.Name;
            if (attributes.Count() == 0)
            {
                try
                {
                    var result = invocation.Proceed();
                    return result;
                }
                catch
                {
                    throw;
                }
            }

            if (attributes.Count() > 1)
            {
                throw new InvalidOperationException(
                    string.Format("GlobalEntity.Instance.Message[\"4\"]: {0}", invocation.Method.Name));
            }
          
            try
            {
                using (System.Transactions.TransactionScope trans = new System.Transactions.TransactionScope())
                {
                    var result = invocation.Proceed();
                    trans.Complete();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
