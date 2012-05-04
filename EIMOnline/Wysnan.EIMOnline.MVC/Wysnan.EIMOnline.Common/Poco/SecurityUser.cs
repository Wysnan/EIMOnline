using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Wysnan.EIMOnline.Common.Poco
{
    public class SecurityUser : IBaseEntity
    {
        public int ID { get; set; }

        public byte? SystemStatus { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string UserName { get; set; }

        public string UserLoginID { get; set; }

        public string UserLoginPwd { get; set; }

        public SecurityUser()
        {
            this.OperateLogs = new List<OperateLog>();
            this.SecurityUserRoles = new List<SecurityUserRole>();
            this.PersonnelAttendances = new List<PersonnelAttendance>();
        }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<OperateLog> OperateLogs { get; set; }
        public virtual ICollection<SecurityUserRole> SecurityUserRoles { get; set; }
        public virtual ICollection<PersonnelAttendance> PersonnelAttendances { get; set; }

    }
}
