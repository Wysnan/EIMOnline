using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Common.Poco
{
    /// <summary>
    /// 业务属性类
    /// </summary>
    public sealed class SystemEntity
    {
        private SystemEntity() { }

        static readonly SystemEntity instance = new SystemEntity();

        public static SystemEntity Instance
        {
            get { return instance; }
        }

        public SecurityUser CurrentSecurityUser
        {
            get;
            set;
        }
    }
}
