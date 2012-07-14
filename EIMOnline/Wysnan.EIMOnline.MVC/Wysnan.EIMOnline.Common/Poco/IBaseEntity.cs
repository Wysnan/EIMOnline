using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.Common.Poco
{
    public interface IBaseEntity : ISystemBaseEntity
    {
        int ID { get; set; }

        byte? SystemStatus { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        byte[] TimeStamp { get; set; }
    }
}
