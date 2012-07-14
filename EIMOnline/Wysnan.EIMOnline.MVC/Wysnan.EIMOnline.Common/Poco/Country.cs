using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Common.Poco
{
    /// <summary>
    /// 国家
    /// todo: 暂未实现 武双琦
    /// </summary>
    public class Country : IBaseEntity
    {
        public int ID { get; set; }

        public byte? SystemStatus { get; set; }

        public byte[] TimeStamp { get; set; }
    }
}
