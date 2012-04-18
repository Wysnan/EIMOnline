using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AopAlliance.Intercept;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.Injection.Logs
{
    public class OperateLogInterceptor : IMethodInterceptor
    {
        public IOperateLog OperateLog { get; set; }
        public object Invoke(IMethodInvocation invocation)
        {
            //var model = BusinessModel
            var attributes = invocation.Method.GetCustomAttributes(typeof(OperateLogAttribute), false).OfType<OperateLogAttribute>();
            var attributes1 = invocation.Method.Name;
            var attr = invocation.Method.DeclaringType.Name;
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
                var result = invocation.Proceed();
                bool ex = result is Result;
                string exinfo = string.Format("用户在：{0}时调用的类是：{1}，调用的方法是：{2}", DateTime.Now, attr, attributes1);
                OperateLog op = new OperateLog();
                op.OperateDate = DateTime.Now;
                op.OperateLogInfo = exinfo;
                Result resultOperateLog;
                if (ex)
                {
                    exinfo = string.Format("用户在：{0}时调用的类是：{1}，调用的方法是：{2}!且操作失败。", DateTime.Now, attr, attributes1);
                    resultOperateLog = OperateLog.Add(op);
                    throw new ApplicationException("操作失败。");
                }

                resultOperateLog = OperateLog.Add(op);
                if (!resultOperateLog.ResultStatus)
                {
                    throw new ApplicationException("添加日志失败。");
                }

                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
