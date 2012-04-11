using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.IBLL.Framework
{
    public interface IMessageModel : IBaseConfigModel
    {
        /// <summary>
        /// 根据Code值获取消息
        /// </summary>
        /// <param name="code">Message.Config中Code属性值</param>
        /// <returns>消息字符串</returns>
        string GetMessage(string code);
    }
}
