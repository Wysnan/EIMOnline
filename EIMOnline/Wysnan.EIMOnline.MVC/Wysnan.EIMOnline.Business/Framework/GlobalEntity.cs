using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Common.Framework.Enum;

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
            this.Cache_JqGrid = Cache_JqGrid.Instance;
            this.Cache_Message = Cache_Message.Instance;
        }

        static readonly GlobalEntity instance = new GlobalEntity();

        public static GlobalEntity Instance
        {
            get { return instance; }
        }

        public Cache_JqGrid Cache_JqGrid { get; private set; }

        public Cache_Message Cache_Message { get; private set; }
    }
}
