using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Wysnan.EIMOnline.Common.Poco
{
    public class SecurityRole : IBaseEntity
    {
        public int ID { get; set; }

        public byte? SystemStatus { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string RoleName { get; set; }
        public SecurityRole()
        {
            this.SecurityUserRoles = new List<SecurityUserRole>();
            this.SystemPermissions = new List<SystemPermission>();           
        }
       
        public virtual ICollection<SecurityUserRole> SecurityUserRoles { get; set; }
        public virtual ICollection<SystemPermission> SystemPermissions { get; set; }
    }
}
