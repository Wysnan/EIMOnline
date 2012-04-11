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
using Wysnan.EIMOnline.Business.Framework.Cache;

namespace Wysnan.EIMOnline.Business.Framework
{
    /// <summary>
    /// 系统消息管理
    /// </summary>
    public class MessageModel : IMessageModel
    {
        private MessageModel()
        {
            this.DicMessage = GetMessage();
        }

        #region 属性定义

        /// <summary>
        ///  消息文件路径
        /// </summary>
        private static string messageConfigPath = HttpContext.Current.Server.MapPath(ConstEntity.Message_ConfigFile);

        static readonly MessageModel instance = new MessageModel();

        public static MessageModel Instance
        {
            get
            {
                return instance;
            }
        }

        public Dictionary<string, string> DicMessage { get; set; }

        #endregion

        public void Reload()
        {
            this.DicMessage = GetMessage();
        }

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
        /// 根据消息code读取消息内容
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetMessage()
        {
            Dictionary<string, string> dicMessage = new Dictionary<string, string>();
            if (getElement() != null)
            {
                XElement elements = getElement();
                var queryResults = from element in elements.Elements()
                                   select new MessageEntity
                                   {
                                       Code = string.IsNullOrWhiteSpace(element.Attribute(ConstEntity.Message_Code).Value) ? "" : element.Attribute(ConstEntity.Message_Code).Value,
                                       Value = string.IsNullOrWhiteSpace(element.Attribute(ConstEntity.Message_Value).Value) ? "" : element.Attribute(ConstEntity.Message_Value).Value,
                                   };

                /// 定义错误缓存
                if (queryResults != null && queryResults.ToList().Count > 0)
                {
                    foreach (var item in queryResults)
                    {
                        dicMessage.Add(item.Code, item.Value);
                    }
                }
            }
            else
            {
                throw new ArgumentException("消息配置文件为空");
            }
            return dicMessage;
        }
    }
        #endregion
}
