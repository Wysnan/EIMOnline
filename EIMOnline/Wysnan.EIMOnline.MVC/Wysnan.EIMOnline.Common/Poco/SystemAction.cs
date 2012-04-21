using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Wysnan.EIMOnline.Common.Poco
{
    public class SystemAction : IBaseEntity
    {
        public SystemAction()
        {
            this.SystemPermissions = new List<SystemPermission>();
        }
        public int ID { get; set; }

        public byte? SystemStatus { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string SyAction { get; set; }
        public string Value { get; set; }
        public string Brief { get; set; }
        public int SystemModuleDetailPageID { get; set; }

        public virtual SystemModuleDetailPage SystemModuleDetailPage { get; set; }
        public virtual ICollection<SystemPermission> SystemPermissions { get; set; }
    }
}
