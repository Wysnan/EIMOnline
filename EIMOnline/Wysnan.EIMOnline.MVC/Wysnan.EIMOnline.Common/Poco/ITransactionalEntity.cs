using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Wysnan.EIMOnline.Common.Poco
{
    public interface ITransactionalEntity
    {
        [ConcurrencyCheck]
        [Timestamp]
        byte[] TimeStamp { get; set; }
    }
}
