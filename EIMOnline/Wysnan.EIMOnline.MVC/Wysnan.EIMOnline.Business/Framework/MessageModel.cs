using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web;
using System.IO;
using Wysnan.EIMOnline.IBLL.Framework;
using Wysnan.EIMOnline.Common.Framework.Enum;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.Business.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageModel : IMessageModel
    {
        #region 属性定义

        /// <summary>
        ///  
        /// </summary>
        private static string messageConfigPath = HttpContext.Current.Server.MapPath(ConstEntity.Message_ConfigFile);

        #endregion

        #region 内部方法

        /// <summary>
        /// 获取消息配置文件
        /// </summary>
        /// <returns></returns>
        private XElement getElement()
        {
            XElement elements = null;
            if (File.Exists(messageConfigPath))
            {
                elements = XElement.Load(messageConfigPath);
            }
            else
            {
                throw new ArgumentException("未找到消息配置文件");
            }
            return elements;
        }

        #endregion

        #region 对外调用方法

        /// <summary>
        ///读取code对应的value
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetMessage(string code)
        {
            Dictionary<string, string> dicMessage = null;
            string message = string.Empty;
            if (getElement() != null)
            {
                XElement elements = getElement();
                var queryResults = from element in elements.Elements()
                                   select new 
                                   {
                                       code = string.IsNullOrWhiteSpace(element.Attribute(ConstEntity.Message_Code).Value) ? "" : element.Attribute(ConstEntity.Message_Code).Value,
                                       value = string.IsNullOrWhiteSpace(element.Attribute(ConstEntity.Message_Value).Value) ? "" : element.Attribute(ConstEntity.Message_Value).Value,
                                   };
                if (queryResults!=null)
                {
                    dicMessage = new Dictionary<string, string>();
                    foreach (var item in queryResults)
                    {
                        dicMessage.Add(item.code, item.value);
                    }
                }

                var messageMember = from item in queryResults
                                    where item.code == code
                                    select item;
                if (messageMember == null)
                {
                    throw new ArgumentException("消息定义错误");
                }
                else if (messageMember.Count() > 1) throw new ArgumentException("消息定义错误，同一错误有多个类型");
                message = messageMember.FirstOrDefault().value;
            }
            else
            {
                throw new ArgumentException("消息配置文件为空");
            }
            return message;
        }

        #endregion
    }
}
