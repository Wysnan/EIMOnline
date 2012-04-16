using System;
using System.Linq;
using AopAlliance.Intercept;
using Wysnan.EIMOnline.Injection.Transaction;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Injection.JqGrid;

namespace Wysnan.EIMOnline.Injection.Transaction
{
    public class ListInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            var attributes = invocation.Method.GetCustomAttributes(typeof(ListAttribute), false).OfType<ListAttribute>();

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

            //var transactionAttribute = attributes.First();


            //var message = string.Format("Method {0} of Type {1} invoked", invocation.Method.Name,
            //                            invocation.Method.DeclaringType.Name);
            //var parameterInfo = invocation.Method.GetParameters().Where(p => p.Name == "message").FirstOrDefault();
            //if (parameterInfo != null)
            //{
            //    message = invocation.Arguments[parameterInfo.Position].ToString();
            //}
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
    }
}
