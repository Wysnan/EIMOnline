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

        #region 缓存

        /// <summary>
        /// Message缓存key
        /// </summary>
        public const string Cache_Message = "Cache_Message";

        /// <summary>
        /// JqGrid缓存key
        /// </summary>
        public const string Cache_JqGrid = "Cache_JqGrid";

        /// <summary>
        /// SystemModule表，数据库依赖缓存字符串
        /// </summary>
        public const string Cache_DB_SystemModule = "Cache_DB_SystemModule";

        public const string Cache_DB_SystemModuleType = "Cache_DB_SystemModuleType";

        #endregion

        #region cookie

        public const string Cookie_JqGridHtml = "Cookie_JqGridHtml";

        #endregion

        #region RenderAction Name

        public const string Control_JqGrid = "JqGrid";

        #endregion

        #region Session

        public const string Session_CurrentSecurityUser = "CurrentSecurityUser";
        public const string Session_SystemEntity = "Session_SystemEntity";

        #endregion
    }
}
