using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Wysnan.EIMOnline.Common.Poco
{
    public class OperateLog : IBaseEntity
    {
        public int ID { get; set; }

        public byte? SystemStatus { get; set; }
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string OperateLogInfo { get; set; }
        public DateTime OperateDate { get; set; }
        public virtual SecurityUser SecurityUserId { get; set; }
    }
}
