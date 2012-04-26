using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Wysnan.EIMOnline.Common.Poco
{
    public class SystemModule : IBaseEntity
    {
        public SystemModule()
        {
            this.SystemModuleDetailPages =new List<SystemModuleDetailPage>();
            this.SystemPermissions = new List<SystemPermission>();
        }
        public int ID { get; set; }

        public byte? SystemStatus { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string ControllerModule { get; set; }
        public string ModuleName { get; set; }
        public int SortOrder { get; set; }
        public string ModuleMainUrl { get; set; }

        public int ModuleTypeId { get; set; }

        public virtual SystemModuleType ModuleType { get; set; }

        public virtual ICollection<SystemModuleDetailPage> SystemModuleDetailPages { get; set; }
        public virtual ICollection<SystemPermission> SystemPermissions { get; set; }
    }
}
