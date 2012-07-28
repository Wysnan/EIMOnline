using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using System.Web;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.Common.Framework
{
    /// <summary>
    /// 业务属性类
    /// </summary>
    public sealed class SystemEntity
    {
        public SystemEntity() { }

        public SecurityUser CurrentSecurityUser
        {
            get;
            set;
        }

        public string CurrentArea
        {
            get;
            set;
        }
    }
}
