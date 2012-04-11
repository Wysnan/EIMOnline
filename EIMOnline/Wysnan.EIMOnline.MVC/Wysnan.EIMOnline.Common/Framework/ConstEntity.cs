using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Common.Framework
{
    /// <summary>
    /// 常量定义类
    /// </summary>
    public class ConstEntity
    {
        private ConstEntity()
        {

        }

        #region  消息管理

        /// <summary>
        ///  消息配置文件路径
        /// </summary>
        public const string Message_ConfigFile = "~/Config/Message.config";

        /// <summary>
        /// 消息节点属性code
        /// </summary>
        public const string Message_Code = "code";

        /// <summary>
        /// 消息节点属性value
        /// </summary>
        public const string Message_Value = "value"; 

        #endregion
    }
}
