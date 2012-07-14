using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Wysnan.EIMOnline.Common.Poco
{
    public class SecurityUserRole : IBaseEntity
    {
        public int ID { get; set; }

        public byte? SystemStatus { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public int SecurityUserID { get; set; }

        public int SecurityRoleID { get; set; }

        public virtual SecurityUser SecurityUser { get; set; }

        public virtual SecurityRole SecurityRole { get; set; }
    }
}
