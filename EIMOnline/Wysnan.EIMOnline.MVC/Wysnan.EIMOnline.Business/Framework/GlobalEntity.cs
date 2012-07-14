using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Common.Framework.Enum;
using Wysnan.EIMOnline.Business.Framework.Cache;
using Spring.Context;
using Spring.Context.Support;

namespace Wysnan.EIMOnline.Business.Framework
{
    /// <summary>
    /// 全局变量
    /// </summary>
    public sealed class GlobalEntity
    {
        private GlobalEntity()
        {
            /*
             * 初始化属性信息
             */
            this.ApplicationContext = ContextRegistry.GetContext();
        }

        static readonly GlobalEntity instance = new GlobalEntity();

        public static GlobalEntity Instance
        {
            get { return instance; }
        }

        #region 缓存

        public Cache_JqGrid Cache_JqGrid { get; private set; }

        public Cache_Message Cache_Message { get; private set; }

        public Cache_SystemModule Cache_SystemModule { get; private set; }

        public Cache_SystemModuleType Cache_SystemModuleType { get; private set; }

        public Cache_Lookup Cache_Lookup { get; private set; }

        #endregion

        #region Srping.Net

        public IApplicationContext ApplicationContext { get; private set; }

        #endregion

        public void InitAll()
        {
            this.Cache_JqGrid = Cache_JqGrid.Instance;
            this.Cache_Message = Cache_Message.Instance;
            this.Cache_SystemModule = Cache_SystemModule.Instance;
            this.Cache_SystemModuleType = Cache_SystemModuleType.Instance;
            this.Cache_Lookup = Cache_Lookup.Instance;
        }
    }
}
